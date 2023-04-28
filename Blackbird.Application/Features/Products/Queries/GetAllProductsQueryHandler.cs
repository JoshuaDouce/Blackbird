using Blackbird.Application.Infrastructure.Persistence;
using Blackbird.Domain.Entities;
using MediatR;

namespace Blackbird.Application.Features.Products.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return (await _productRepository.GetAllAsync()).ToList();
        }
    }
}
