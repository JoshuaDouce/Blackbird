using Blackbird.Application.Dtos;

namespace Blackbird.RazorComponents.Interfaces.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
}
