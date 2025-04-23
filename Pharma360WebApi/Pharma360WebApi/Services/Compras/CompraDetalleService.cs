using Microsoft.EntityFrameworkCore;
using Pharma360WebApi.Data;
using Pharma360WebApi.Models.DOTs;

namespace Pharma360WebApi.Services.Compras
{
    public class CompraDetalleService : ICompraDetalleService
    {
        private readonly PharmaDbContext _context;

        public CompraDetalleService(PharmaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompraConDetallesDto>> GetAllAsync()
        {
            return await _context.Compras
                .Include(c => c.Detalles)
                .Select(c => new CompraConDetallesDto
                {
                    IdCompra = c.IdCompra,
                    Fecha = c.Fecha,
                    Total = c.Total,
                    IdProveedor = c.IdProveedor,
                    Detalles = c.Detalles.Select(d => new DetalleCompraDto
                    {
                        IdDetalle = d.IdDetalle,
                        IdCompra = d.IdCompra,
                        IdProducto = d.IdProducto,
                        Cantidad = d.Cantidad,
                        PrecioUnitario = d.PrecioUnitario
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<CompraConDetallesDto?> GetByIdAsync(int id)
        {
            return await _context.Compras
                .Include(c => c.Detalles)
                .Where(c => c.IdCompra == id)
                .Select(c => new CompraConDetallesDto
                {
                    IdCompra = c.IdCompra,
                    Fecha = c.Fecha,
                    Total = c.Total,
                    IdProveedor = c.IdProveedor,
                    Detalles = c.Detalles.Select(d => new DetalleCompraDto
                    {
                        IdDetalle = d.IdDetalle,
                        IdCompra = d.IdCompra,
                        IdProducto = d.IdProducto,
                        Cantidad = d.Cantidad,
                        PrecioUnitario = d.PrecioUnitario
                    }).ToList()
                }).FirstOrDefaultAsync();
        }
    }
}
