using Api.Application.DTO;
using Api.Application.DTO.Responses;
using Api.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RespuestaBaseDTO> RegisterAuthUserAsync(UsuarioDTO usuarioDTO)
        {
            var user = new IdentityUser
            {
                UserName = usuarioDTO.NombreUsuario,
                Email = usuarioDTO.Correo,
            };
            var result = await _userManager.CreateAsync(user, usuarioDTO.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return new RespuestaBaseDTO { status = true, mensaje = errors };
            }
            //guardar un usuario normal (UserService)

            return new RespuestaBaseDTO { status = true, mensaje = $"Usuario {user.Id} creado correctamente" };
        }
    }
}
