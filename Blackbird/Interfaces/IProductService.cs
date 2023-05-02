using Blackbird.Domain.Entities;

namespace Blackbird.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
