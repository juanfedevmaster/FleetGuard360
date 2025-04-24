using Microsoft.AspNetCore.Mvc;
using Pharma360WebApi.Authorization;
using Pharma360WebApi.Models.DOTs;
using Pharma360WebApi.Services.Productos;

namespace Pharma360WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/producto
        [HttpGet]
        [HasPermission("perm.product.read")]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetAll()
        {
            var productos = await _productoService.GetAllAsync();
            return Ok(productos);
        }

        // GET: api/producto/5
        [HttpGet("{id}")]
        [HasPermission("perm.product.read")]
        public async Task<ActionResult<ProductoDto>> GetById(int id)
        {
            var producto = await _productoService.GetByIdAsync(id);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        // POST: api/producto
        [HttpPost]
        [HasPermission("perm.product.create")]
        public async Task<ActionResult<ProductoDto>> Create(ProductoDto dto)
        {
            var created = await _productoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdProducto }, created);
        }

        // PUT: api/producto/5
        [HttpPut("{id}")]
        [HasPermission("perm.product.update")]
        public async Task<IActionResult> Update(int id, ProductoDto dto)
        {
            var updated = await _productoService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/producto/5
        [HttpDelete("{id}")]
        [HasPermission("perm.product.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productoService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
