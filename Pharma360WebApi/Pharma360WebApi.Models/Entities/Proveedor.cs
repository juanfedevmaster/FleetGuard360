using System.Collections.Generic;

namespace Pharma360WebApi.Models.Entities
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }

        public ICollection<Compra> Compras { get; set; } = new List<Compra>();
    }
}
