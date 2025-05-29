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
        private readonly UserService _UserService;
        public AuthService(UserManager<IdentityUser> userManager, UserService userService)
        {
            _userManager = userManager;
            _UserService = userService;
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
            usuarioDTO.IdAspnetUser = user.Id;
            var newUser = await _UserService.NewUser(usuarioDTO);
            if (newUser.Id > 0) 
            {
                return new RespuestaBaseDTO { status = true, mensaje = $"Usuario {usuarioDTO.NombreCompleto} creado correctamente ({user.Id})" };
            }
            else 
            {
                return new RespuestaBaseDTO { status = false, mensaje = "Error al crear el usuario " };
            }
        }
    }
}
