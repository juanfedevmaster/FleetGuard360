using System.Collections.Generic;

namespace Pharma360WebApi.Models.Entities
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; } = null!;

        public ICollection<DetalleVenta> DetallesVenta { get; set; } = new List<DetalleVenta>();
        public ICollection<DetalleCompra> DetallesCompra { get; set; } = new List<DetalleCompra>();
    }

}
