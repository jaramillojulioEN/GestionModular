using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.DTO
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ImgUrl { get; set; }
        public int IdCategoria { get; set; }
        public int IdAlmacen { get; set; }
        public CategoriaDTO Categoria { get; set; }
        public AlmacenDTO Almacen { get; set; }
    }
}
