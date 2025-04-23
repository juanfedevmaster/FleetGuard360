using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharma360WebApi.Models.DOTs;
using Pharma360WebApi.Services.Compras;

namespace Pharma360WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraTransaccionalController : ControllerBase
    {
        private readonly ICompraTransaccionalService _service;

        public CompraTransaccionalController(ICompraTransaccionalService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCompraCompleta([FromBody] CompraCompletaDto dto)
        {
            try
            {
                var resultado = await _service.CrearCompraConDetallesAsync(dto);
                return resultado ? Ok("Compra registrada correctamente") : BadRequest("Fallo al registrar la compra");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }

    /*  Ejemplo JSON Compra transaccional
        {
          "compra": {
            "fecha": "2025-04-23T10:30:00",
            "total": 350.00,
            "idProveedor": 1
          },
          "detalles": [
            {
              "idProducto": 1,
              "cantidad": 20,
              "precioUnitario": 5.00
            },
            {
              "idProducto": 2,
              "cantidad": 10,
              "precioUnitario": 6.75
            }
          ]
        }     
     */
}
