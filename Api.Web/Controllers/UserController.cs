using Api.Application.DTO;
using Api.Application.DTO.Responses;
using Api.Application.UseCases;
using Api.Domain.Entities;
using AutoMapper;
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
        [HttpGet]
        public async Task<RespuestaBaseDTO> AgregarUsuario(UsuarioDTO usuario)
        {
           return await _UCUsers.AddNewUser(usuario);
        }
    }
}
