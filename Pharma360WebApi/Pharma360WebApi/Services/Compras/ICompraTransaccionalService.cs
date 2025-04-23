using Pharma360WebApi.Models.DOTs;

namespace Pharma360WebApi.Services.Compras
{
    public interface ICompraTransaccionalService
    {
        Task<bool> CrearCompraConDetallesAsync(CompraCompletaDto compraCompleta);
    }
}
