using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharma360WebApi.Models.DOTs;
using Pharma360WebApi.Services.Ventas;

namespace Pharma360WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentaConDetallesDto>>> GetAll()
        {
            var ventas = await _ventaService.GetAllAsync();
            return Ok(ventas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VentaConDetallesDto>> GetById(int id)
        {
            var venta = await _ventaService.GetByIdAsync(id);
            if (venta == null)
                return NotFound();

            return Ok(venta);
        }
    }
}
