using System;
using System.Collections.Generic;
using System.Text;

namespace Pharma360WebApi.Models.DOTs
{
    public class ProveedorDto
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
    }
}
