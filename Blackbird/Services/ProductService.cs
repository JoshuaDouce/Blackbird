using Blackbird.Domain.Entities;
using Blackbird.Interfaces;
using System.Net.Http.Json;

namespace Blackbird.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("products");
        }
    }
}
