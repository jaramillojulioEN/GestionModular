using Api.Application.DTO;
using Api.Application.DTO.Usuario;
using Api.Domain.Entities;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Api.Web.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Producto, ProductoDTO>();
            CreateMap<ProductoDTO, Producto>();

            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<CategoriaDTO, Categoria>();

            CreateMap<Almacen, AlmacenDTO>();
            CreateMap<AlmacenDTO, Almacen>();

            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();

            CreateMap<Usuario, UsuarioNuevoDTO>();
            CreateMap<UsuarioNuevoDTO, Usuario>();
        }
    }
}
