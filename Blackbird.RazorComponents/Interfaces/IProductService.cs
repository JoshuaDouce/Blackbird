using Blackbird.Domain.Entities;

namespace Blackbird.RazorComponents.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
