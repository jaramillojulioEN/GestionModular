using Api.Application.DTO;
using Api.Application.DTO.Responses;
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
        private AuthService _authService;
        public AuthUseCases(AuthService authService)
        {
            _authService = authService;
        }

        public async Task<RespuestaBaseDTO> AddNewUser(UsuarioDTO user) 
        {
            var resp = new RespuestaBaseDTO { status = false };
            if (user.Correo == null) 
            {
                resp.mensaje = "Correo inválido";
                return resp;
            }
            return await _authService.RegisterAuthUserAsync(user);
        }
    }
}
