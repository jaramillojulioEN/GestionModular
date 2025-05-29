using Api.Application.DTO;
using Api.Application.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Interfaces
{
    public interface IUserService
    {
        public Task<UsuarioDTO> NewUser(UsuarioDTO entity);
    }
}
