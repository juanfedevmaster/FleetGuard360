using Microsoft.EntityFrameworkCore;
using Pharma360WebApi.Data;
using Pharma360WebApi.Models.DOTs;
using Pharma360WebApi.Models.Entities;

namespace Pharma360WebApi.Services.Compras
{
    public class CompraService : ICompraService
    {
        private readonly PharmaDbContext _context;

        public CompraService(PharmaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompraDto>> GetAllAsync()
        {
            return await _context.Compras
                .Select(c => new CompraDto
                {
                    IdCompra = c.IdCompra,
                    Fecha = c.Fecha,
                    Total = c.Total,
                    IdProveedor = c.IdProveedor
                }).ToListAsync();
        }

        public async Task<CompraDto?> GetByIdAsync(int id)
        {
            return await _context.Compras
                .Where(c => c.IdCompra == id)
                .Select(c => new CompraDto
                {
                    IdCompra = c.IdCompra,
                    Fecha = c.Fecha,
                    Total = c.Total,
                    IdProveedor = c.IdProveedor
                }).FirstOrDefaultAsync();
        }

        public async Task<CompraDto> CreateAsync(CompraDto dto)
        {
            var entity = new Compra
            {
                Fecha = dto.Fecha == default ? DateTime.Now : dto.Fecha,
                Total = dto.Total,
                IdProveedor = dto.IdProveedor
            };

            _context.Compras.Add(entity);
            await _context.SaveChangesAsync();

            dto.IdCompra = entity.IdCompra;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, CompraDto dto)
        {
            var compra = await _context.Compras.FindAsync(id);
            if (compra == null) return false;

            compra.Fecha = dto.Fecha;
            compra.Total = dto.Total;
            compra.IdProveedor = dto.IdProveedor;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var compra = await _context.Compras.FindAsync(id);
            if (compra == null) return false;

            _context.Compras.Remove(compra);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
