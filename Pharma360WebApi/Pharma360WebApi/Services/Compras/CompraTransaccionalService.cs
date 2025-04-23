using Pharma360WebApi.Data;
using Pharma360WebApi.Models.DOTs;
using Pharma360WebApi.Models.Entities;

namespace Pharma360WebApi.Services.Compras
{
    public class CompraTransaccionalService : ICompraTransaccionalService
    {
        private readonly PharmaDbContext _context;

        public CompraTransaccionalService(PharmaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearCompraConDetallesAsync(CompraCompletaDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Crear la compra
                var compra = new Compra
                {
                    Fecha = dto.Compra.Fecha == default ? DateTime.Now : dto.Compra.Fecha,
                    Total = dto.Compra.Total,
                    IdProveedor = dto.Compra.IdProveedor
                };
                _context.Compras.Add(compra);
                await _context.SaveChangesAsync();

                // 2. Crear detalles de compra
                foreach (var detalleDto in dto.Detalles)
                {
                    var detalle = new DetalleCompra
                    {
                        IdCompra = compra.IdCompra,
                        IdProducto = detalleDto.IdProducto,
                        Cantidad = detalleDto.Cantidad,
                        PrecioUnitario = detalleDto.PrecioUnitario
                    };
                    _context.DetalleCompras.Add(detalle);

                    // 3. Actualizar stock del producto
                    var producto = await _context.Productos.FindAsync(detalleDto.IdProducto);
                    if (producto == null)
                        throw new Exception($"Producto ID {detalleDto.IdProducto} no encontrado");

                    producto.Stock += detalleDto.Cantidad;
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
