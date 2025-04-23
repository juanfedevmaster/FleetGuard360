using System;
using System.Collections.Generic;
using System.Text;

namespace Pharma360WebApi.Models.DOTs
{
    public class ClienteDto
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
    }
}
