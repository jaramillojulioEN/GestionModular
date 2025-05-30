using Api.Application.DTO.Responses;
using Api.Application.DTO.Usuario;
using Api.Application.UseCases;
using Api.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AuthUseCases _UCUsers;

        public UserController(AuthUseCases ucUsers)
        {
            _UCUsers = ucUsers;
        }

        [Route("Nuevo")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<RespuestaBaseDTO> AgregarUsuario(UsuarioNuevoDTO usuario)
        {
            var user = HttpContext.User;
            var claims = user.Claims.ToList();
            return await _UCUsers.AddNewUser(usuario);
        }

        [Route("Login")]
        [HttpPost]
        public async Task<AuthResponseDTO> Login(LoginDTO credentials)
        {
            return await _UCUsers.Login(credentials);
        }
    }
}
