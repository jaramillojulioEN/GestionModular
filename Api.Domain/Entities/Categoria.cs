﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string NombreCategoria { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}
