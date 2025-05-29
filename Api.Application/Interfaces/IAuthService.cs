using Api.Application.DTO.Responses;
using Api.Application.DTO.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Interfaces
{
    public interface IAuthService
    {
        Task<RespuestaBaseDTO> RegisterAuthUserAsync(UsuarioNuevoDTO usuarioDTO);
        Task<AuthResponseDTO> LoginAsync(LoginDTO credentials);

    }
}
