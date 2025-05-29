using Api.Application.DTO.Responses;
using Api.Application.DTO.Usuario;
using Api.Application.Interfaces;
using Api.Domain.Entities;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Application.Services
{
    public class UserService : IUserService
    {
        private IMapper _Mapper;
        private IGenericRepository<Usuario> _Repository;
        public UserService(IMapper mapper, IGenericRepository<Usuario> repository)
        {
            _Mapper = mapper;
            _Repository = repository;
        }

        public async Task<List<UsuarioDTO>> GetUsers(Expression<Func<Usuario, bool>> filter = null)
        {
            List<UsuarioDTO> list = new List<UsuarioDTO>();
            if (filter == null)
            {
                list = _Mapper.Map<List<UsuarioDTO>>(await _Repository.GetAllAsync());
            }
            else 
            {
                list = _Mapper.Map<List<UsuarioDTO>>(await _Repository.FilterAsync(filter));
            }
            return list;
        }

        public async Task<UsuarioDTO> NewUser(UsuarioNuevoDTO entity)
        {
            var create = await _Repository.AddAsync(_Mapper.Map<Usuario>(entity));
            if (create != null)
            {
                return _Mapper.Map<UsuarioDTO>(create);
            }
            else 
            {
                return new UsuarioDTO();
            }
        }
    }
}
