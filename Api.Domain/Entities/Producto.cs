using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ImgUrl { get; set; }
        public int IdCategoria { get; set; }
        public int IdAlmacen { get; set; }
        public Categoria Categoria { get; set; }
        public Almacen Almacen { get; set; }
    }
}
