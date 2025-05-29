using Api.Application.DTO;
using Api.Application.DTO.Responses;
using Api.Application.Interfaces;
using Api.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<UsuarioDTO> NewUser(UsuarioDTO entity)
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
