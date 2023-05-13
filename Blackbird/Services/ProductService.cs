using Blackbird.Application.Dtos;
using Blackbird.RazorComponents.Interfaces.Services;
using System.Net.Http.Json;

namespace Blackbird.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("products");
    }
}
