using System.Collections.Generic;

namespace Pharma360WebApi.Models.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }

        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
