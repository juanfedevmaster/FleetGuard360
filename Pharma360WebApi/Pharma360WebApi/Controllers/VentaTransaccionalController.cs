using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharma360WebApi.Models.DOTs;
using Pharma360WebApi.Services.Ventas;

namespace Pharma360WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaTransaccionalController : ControllerBase
    {
        private readonly IVentaTransaccionalService _ventaService;

        public VentaTransaccionalController(IVentaTransaccionalService ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearVentaCompleta([FromBody] VentaCompletaDto dto)
        {
            try
            {
                var resultado = await _ventaService.CrearVentaConDetallesAsync(dto);
                return resultado ? Ok("Venta registrada correctamente") : BadRequest("No se pudo registrar la venta");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }

    /* Ejemplo JSON de una Venta Completa 
        {
          "venta": {
            "fecha": "2025-04-23T11:00:00",
            "total": 100.00,
            "idCliente": 1
          },
          "detalles": [
            {
              "idProducto": 1,
              "cantidad": 2,
              "precioUnitario": 5.50
            },
            {
              "idProducto": 2,
              "cantidad": 3,
              "precioUnitario": 6.75
            }
          ]
        }
     */
}
