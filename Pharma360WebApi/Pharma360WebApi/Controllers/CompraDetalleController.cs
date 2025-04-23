using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharma360WebApi.Models.DOTs;
using Pharma360WebApi.Services.Compras;

namespace Pharma360WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraDetalleController : ControllerBase
    {
        private readonly ICompraDetalleService _compraService;

        public CompraDetalleController(ICompraDetalleService compraService)
        {
            _compraService = compraService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraConDetallesDto>>> GetAll()
        {
            var compras = await _compraService.GetAllAsync();
            return Ok(compras);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompraConDetallesDto>> GetById(int id)
        {
            var compra = await _compraService.GetByIdAsync(id);
            if (compra == null)
                return NotFound();

            return Ok(compra);
        }
    }
}
