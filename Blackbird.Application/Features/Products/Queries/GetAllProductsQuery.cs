using Blackbird.Domain.Entities;
using MediatR;

namespace Blackbird.Application.Features.Products.Queries
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {
    }
}
