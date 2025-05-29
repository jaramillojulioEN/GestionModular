using Api.Application.DTO.Responses;
using Api.Application.DTO.Usuario;
using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Interfaces
{
    public interface IUserService
    {
        public Task<UsuarioDTO> NewUser(UsuarioNuevoDTO entity);
        public Task<List<UsuarioDTO>> GetUsers(Expression<Func<Usuario, bool>> filter = null);
    }
}
