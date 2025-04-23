using Microsoft.EntityFrameworkCore;
using Pharma360WebApi.Data;
using Pharma360WebApi.Models.DOTs;

namespace Pharma360WebApi.Services.Ventas
{
    public class VentaService : IVentaService
    {
        private readonly PharmaDbContext _context;

        public VentaService(PharmaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VentaConDetallesDto>> GetAllAsync()
        {
            return await _context.Ventas
                .Include(v => v.Detalles)
                .Select(v => new VentaConDetallesDto
                {
                    IdVenta = v.IdVenta,
                    Fecha = v.Fecha,
                    Total = v.Total,
                    IdCliente = v.IdCliente,
                    Detalles = v.Detalles.Select(d => new DetalleVentaDto
                    {
                        IdDetalle = d.IdDetalle,
                        IdVenta = d.IdVenta,
                        IdProducto = d.IdProducto,
                        Cantidad = d.Cantidad,
                        PrecioUnitario = d.PrecioUnitario
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<VentaConDetallesDto?> GetByIdAsync(int id)
        {
            return await _context.Ventas
                .Include(v => v.Detalles)
                .Where(v => v.IdVenta == id)
                .Select(v => new VentaConDetallesDto
                {
                    IdVenta = v.IdVenta,
                    Fecha = v.Fecha,
                    Total = v.Total,
                    IdCliente = v.IdCliente,
                    Detalles = v.Detalles.Select(d => new DetalleVentaDto
                    {
                        IdDetalle = d.IdDetalle,
                        IdVenta = d.IdVenta,
                        IdProducto = d.IdProducto,
                        Cantidad = d.Cantidad,
                        PrecioUnitario = d.PrecioUnitario
                    }).ToList()
                }).FirstOrDefaultAsync();
        }
    }
}
