using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharma360WebApi.Models.DOTs;
using Pharma360WebApi.Services.Compras;

namespace Pharma360WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _compraService;

        public CompraController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraDto>>> GetAll()
        {
            var compras = await _compraService.GetAllAsync();
            return Ok(compras);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompraDto>> GetById(int id)
        {
            var compra = await _compraService.GetByIdAsync(id);
            if (compra == null)
                return NotFound();

            return Ok(compra);
        }

        [HttpPost]
        public async Task<ActionResult<CompraDto>> Create(CompraDto dto)
        {
            var created = await _compraService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdCompra }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CompraDto dto)
        {
            var updated = await _compraService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _compraService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
