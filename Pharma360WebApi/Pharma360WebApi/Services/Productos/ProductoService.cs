using Pharma360WebApi.Models.DOTs;
using Pharma360WebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Pharma360WebApi.Data;

namespace Pharma360WebApi.Services.Productos
{
    public class ProductoService : IProductoService
    {
        private readonly PharmaDbContext _context;

        public ProductoService(PharmaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductoDto>> GetAllAsync()
        {
            return await _context.Productos
                .Select(p => new ProductoDto
                {
                    IdProducto = p.IdProducto,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Stock = p.Stock,
                    IdCategoria = p.IdCategoria,
                    Descripcion = "<Falta Llenarlo de la base de datos>"
                }).ToListAsync();
        }

        public async Task<ProductoDto?> GetByIdAsync(int id)
        {
            return await _context.Productos
                .Where(p => p.IdProducto == id)
                .Select(p => new ProductoDto
                {
                    IdProducto = p.IdProducto,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Stock = p.Stock,
                    IdCategoria = p.IdCategoria
                }).FirstOrDefaultAsync();
        }

        public async Task<ProductoDto> CreateAsync(ProductoDto dto)
        {
            var entity = new Producto
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Stock = dto.Stock,
                IdCategoria = dto.IdCategoria
            };
            _context.Productos.Add(entity);
            await _context.SaveChangesAsync();
            dto.IdProducto = entity.IdProducto;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, ProductoDto dto)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;

            producto.Nombre = dto.Nombre;
            producto.Precio = dto.Precio;
            producto.Stock = dto.Stock;
            producto.IdCategoria = dto.IdCategoria;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
