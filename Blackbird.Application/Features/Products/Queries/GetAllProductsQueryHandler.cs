using Blackbird.Application.Dtos;
using Blackbird.Application.Infrastructure.Persistence;
using Blackbird.Domain.Entities;
using MediatR;

namespace Blackbird.Application.Features.Products.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                ImageUrl = p.ImageUrl
            }).ToList();
        }
    }
}
