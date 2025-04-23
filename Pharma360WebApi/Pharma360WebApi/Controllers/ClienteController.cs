using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharma360WebApi.Models.DOTs;
using Pharma360WebApi.Services.Clientes;

namespace Pharma360WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetAll()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> GetById(int id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDto>> Create(ClienteDto dto)
        {
            var created = await _clienteService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdCliente }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClienteDto dto)
        {
            var updated = await _clienteService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _clienteService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
