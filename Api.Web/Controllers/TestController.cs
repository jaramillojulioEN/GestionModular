using Api.Application.DTO;
using Api.Application.DTO.Responses;
using Api.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers
{
    [Route("api/Test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IMapper _mapper;

        public TestController(IMapper mapper) 
        {
            _mapper = mapper;
        }

        [Route("GetTest")]
        [HttpGet]
        public async Task<ProductoDTO> Index()
        {
            var x = new Producto {
                Descripcion  = "Test",
                Nombre = "Test",
                Id =1,
                ImgUrl="www.contoso.com",
                IdAlmacen = 1,
                IdCategoria = 1,
            };
            return _mapper.Map<ProductoDTO>(x);
        }
    }
}
