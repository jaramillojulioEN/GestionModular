using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string NombreUsuario { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public bool Activo { get; set; }
        public string IdAspnetUser { get; set; }
    }
}
