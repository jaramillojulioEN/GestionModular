using Api.Application.DTO.Responses;
using Api.Application.DTO.Usuario;
using Api.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserService _UserService;
        private readonly IConfiguration _Configuration;
        public AuthService(UserManager<IdentityUser> userManager, IUserService userService, IConfiguration configuration)
        {
            _userManager = userManager;
            _UserService = userService;
            _Configuration = configuration;
        }

        public async Task<AuthResponseDTO> LoginAsync(LoginDTO credentials)
        {
            var user = await _userManager.FindByEmailAsync(credentials.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, credentials.Password))
                return new AuthResponseDTO { mensaje="Credenciales incorrectas"};

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_Configuration["IssuerSigningKey"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email!)
            }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var AuthResponse = new AuthResponseDTO { 
                status = true, 
                Token = tokenHandler.WriteToken(token), 
                Expira = DateTime.UtcNow.AddDays(1), 
                mensaje = "Usuario autentifcado correctamente." };
            return AuthResponse;
        }

        public async Task<RespuestaBaseDTO> RegisterAuthUserAsync(UsuarioNuevoDTO usuarioDTO)
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
                return new RespuestaBaseDTO { status = false, mensaje = errors };
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
