using Microsoft.EntityFrameworkCore;
using Pharma360WebApi.Data;
using Pharma360WebApi.Models.DOTs;
using Pharma360WebApi.Models.Entities;

namespace Pharma360WebApi.Services.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly PharmaDbContext _context;

        public ClienteService(PharmaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        {
            return await _context.Clientes
                .Select(c => new ClienteDto
                {
                    IdCliente = c.IdCliente,
                    Nombre = c.Nombre,
                    Direccion = c.Direccion,
                    Telefono = c.Telefono,
                    Correo = c.Correo
                }).ToListAsync();
        }

        public async Task<ClienteDto?> GetByIdAsync(int id)
        {
            return await _context.Clientes
                .Where(c => c.IdCliente == id)
                .Select(c => new ClienteDto
                {
                    IdCliente = c.IdCliente,
                    Nombre = c.Nombre,
                    Direccion = c.Direccion,
                    Telefono = c.Telefono,
                    Correo = c.Correo
                }).FirstOrDefaultAsync();
        }

        public async Task<ClienteDto> CreateAsync(ClienteDto dto)
        {
            var entity = new Cliente
            {
                Nombre = dto.Nombre,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Correo = dto.Correo
            };

            _context.Clientes.Add(entity);
            await _context.SaveChangesAsync();
            dto.IdCliente = entity.IdCliente;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, ClienteDto dto)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            cliente.Nombre = dto.Nombre;
            cliente.Direccion = dto.Direccion;
            cliente.Telefono = dto.Telefono;
            cliente.Correo = dto.Correo;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
