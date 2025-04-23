namespace Pharma360WebApi.Models.Entities
{
    public class DetalleCompra
    {
        public int IdDetalle { get; set; }

        public int IdCompra { get; set; }
        public Compra Compra { get; set; } = null!;

        public int IdProducto { get; set; }
        public Producto Producto { get; set; } = null!;

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}

