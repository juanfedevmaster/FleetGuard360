namespace Pharma360WebApi.Models.Entities
{
    public class DetalleVenta
    {
        public int IdDetalle { get; set; }

        public int IdVenta { get; set; }
        public Venta Venta { get; set; } = null!;

        public int IdProducto { get; set; }
        public Producto Producto { get; set; } = null!;

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
