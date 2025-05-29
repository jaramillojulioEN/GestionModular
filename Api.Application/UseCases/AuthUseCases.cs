using Api.Application.DTO.Responses;
using Api.Application.DTO.Usuario;
using Api.Application.Interfaces;
using Api.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.UseCases
{
    public class AuthUseCases
    {
        private IAuthService _authService;
        public AuthUseCases(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<RespuestaBaseDTO> AddNewUser(UsuarioNuevoDTO user) 
        {
            var resp = new RespuestaBaseDTO { status = false };
            if (user.Correo == null) 
            {
                resp.mensaje = "Correo inválido";
                return resp;
            }
            if (user.Password == null)
            {
                resp.mensaje = "contraseña invalida inválido";
                return resp;
            }
            return await _authService.RegisterAuthUserAsync(user);
        }

        public async Task<AuthResponseDTO> Login(LoginDTO login)
        {
            var response = new AuthResponseDTO { status = false };
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
            {
                response.mensaje = "Email y contraseña requeridos";
                return response;
            }
            response = await _authService.LoginAsync(login);
            return response;
        }
    }
}
