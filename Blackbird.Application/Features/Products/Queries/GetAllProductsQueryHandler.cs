using AutoMapper;
using Blackbird.Application.Dtos;
using Blackbird.Application.Infrastructure.Persistence;
using Blackbird.Domain.Entities;
using MediatR;

namespace Blackbird.Application.Features.Products.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products);

            return productDtos;
        }
    }
}
