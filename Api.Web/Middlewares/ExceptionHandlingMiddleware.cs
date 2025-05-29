using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Api.Web.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            LogExceptionDetailed(exception);

            var response = new
            {
                status = false,
                mensaje = "Error inesperado en el servidor",
                detalle = exception.Message
            };

            var json = JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(json);
        }

        private void LogExceptionDetailed(Exception ex)
        {
            if (ex == null) return;

            var errorMessage = new StringBuilder();

            errorMessage.AppendLine("***** EXCEPCIÓN CAPTURADA *****");
            errorMessage.AppendLine($"Mensaje: {ex.Message}");
            errorMessage.AppendLine($"Tipo: {ex.GetType().FullName}");
            errorMessage.AppendLine($"Origen: {ex.Source}");
            errorMessage.AppendLine($"StackTrace: {ex.StackTrace}");

            var inner = ex.InnerException;
            int level = 1;
            while (inner != null)
            {
                errorMessage.AppendLine($"-- Excepción Interna Nivel {level} --");
                errorMessage.AppendLine($"Mensaje: {inner.Message}");
                errorMessage.AppendLine($"Tipo: {inner.GetType().FullName}");
                errorMessage.AppendLine($"Origen: {inner.Source}");
                errorMessage.AppendLine($"StackTrace: {inner.StackTrace}");

                inner = inner.InnerException;
                level++;
            }

            errorMessage.AppendLine("******************************");

            foreach (var line in errorMessage.ToString().Split(Environment.NewLine))
            {
                if (!string.IsNullOrWhiteSpace(line))
                    _logger.LogError(line);
            }
        }

    }
}
