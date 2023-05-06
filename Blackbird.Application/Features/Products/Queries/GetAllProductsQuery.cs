using Blackbird.Application.Dtos;
using MediatR;

namespace Blackbird.Application.Features.Products.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductDto>>
    {
    }
}
