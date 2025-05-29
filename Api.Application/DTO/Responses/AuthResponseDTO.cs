using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.DTO.Responses
{
    public class AuthResponseDTO : RespuestaBaseDTO
    {
        public string Token { get; set; }
        public DateTime Expira { get; set; }
    }
}
