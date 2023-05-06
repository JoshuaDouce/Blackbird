using Blackbird.Application.Dtos;

namespace Blackbird.RazorComponents.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    }
}
