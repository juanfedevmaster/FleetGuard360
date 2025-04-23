using Microsoft.EntityFrameworkCore;
using Pharma360WebApi.Data;
using Pharma360WebApi.Models.DOTs;
using Pharma360WebApi.Models.Entities;

namespace Pharma360WebApi.Services.Proveedores
{
    public class ProveedorService : IProveedorService
    {
        private readonly PharmaDbContext _context;

        public ProveedorService(PharmaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProveedorDto>> GetAllAsync()
        {
            return await _context.Proveedores
                .Select(p => new ProveedorDto
                {
                    IdProveedor = p.IdProveedor,
                    Nombre = p.Nombre,
                    Telefono = p.Telefono,
                    Direccion = p.Direccion
                }).ToListAsync();
        }

        public async Task<ProveedorDto?> GetByIdAsync(int id)
        {
            return await _context.Proveedores
                .Where(p => p.IdProveedor == id)
                .Select(p => new ProveedorDto
                {
                    IdProveedor = p.IdProveedor,
                    Nombre = p.Nombre,
                    Telefono = p.Telefono,
                    Direccion = p.Direccion
                }).FirstOrDefaultAsync();
        }

        public async Task<ProveedorDto> CreateAsync(ProveedorDto dto)
        {
            var entity = new Proveedor
            {
                Nombre = dto.Nombre,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion
            };

            _context.Proveedores.Add(entity);
            await _context.SaveChangesAsync();
            dto.IdProveedor = entity.IdProveedor;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, ProveedorDto dto)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null) return false;

            proveedor.Nombre = dto.Nombre;
            proveedor.Telefono = dto.Telefono;
            proveedor.Direccion = dto.Direccion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null) return false;

            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
