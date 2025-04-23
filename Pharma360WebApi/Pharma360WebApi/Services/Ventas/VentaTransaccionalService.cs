using Pharma360WebApi.Data;
using Pharma360WebApi.Models.DOTs;
using Pharma360WebApi.Models.Entities;

namespace Pharma360WebApi.Services.Ventas
{
    public class VentaTransaccionalService : IVentaTransaccionalService
    {
        private readonly PharmaDbContext _context;

        public VentaTransaccionalService(PharmaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearVentaConDetallesAsync(VentaCompletaDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Crear la venta
                var venta = new Venta
                {
                    Fecha = dto.Venta.Fecha == default ? DateTime.Now : dto.Venta.Fecha,
                    Total = dto.Venta.Total,
                    IdCliente = dto.Venta.IdCliente
                };

                _context.Ventas.Add(venta);
                await _context.SaveChangesAsync();

                // 2. Detalles de la venta
                foreach (var detalleDto in dto.Detalles)
                {
                    var producto = await _context.Productos.FindAsync(detalleDto.IdProducto);
                    if (producto == null)
                        throw new Exception($"Producto ID {detalleDto.IdProducto} no encontrado");

                    if (producto.Stock < detalleDto.Cantidad)
                        throw new Exception($"Stock insuficiente para el producto '{producto.Nombre}'");

                    // Disminuir stock
                    producto.Stock -= detalleDto.Cantidad;

                    var detalle = new DetalleVenta
                    {
                        IdVenta = venta.IdVenta,
                        IdProducto = detalleDto.IdProducto,
                        Cantidad = detalleDto.Cantidad,
                        PrecioUnitario = detalleDto.PrecioUnitario
                    };
                    _context.DetalleVentas.Add(detalle);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
