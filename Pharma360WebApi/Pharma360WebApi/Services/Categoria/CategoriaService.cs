using Microsoft.EntityFrameworkCore;
using Pharma360WebApi.Data;
using Pharma360WebApi.Models.DOTs;

namespace Pharma360WebApi.Services.Categoria
{
    public class CategoriaService : ICategoriaService
    {
        private readonly PharmaDbContext _context;

        public CategoriaService(PharmaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoriaDto>> GetAllAsync()
        {
            return await _context.Categorias
                .Select(c => new CategoriaDto
                {
                    IdCategoria = c.IdCategoria,
                    Nombre = c.Nombre
                }).ToListAsync();
        }

        public async Task<CategoriaDto?> GetByIdAsync(int id)
        {
            return await _context.Categorias
                .Where(c => c.IdCategoria == id)
                .Select(c => new CategoriaDto
                {
                    IdCategoria = c.IdCategoria,
                    Nombre = c.Nombre
                }).FirstOrDefaultAsync();
        }

        public async Task<CategoriaDto> CreateAsync(CategoriaDto dto)
        {
            var entity = new Models.Entities.Categoria
            {
                Nombre = dto.Nombre
            };

            _context.Categorias.Add(entity);
            await _context.SaveChangesAsync();

            dto.IdCategoria = entity.IdCategoria;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, CategoriaDto dto)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null) return false;

            categoria.Nombre = dto.Nombre;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null) return false;

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
