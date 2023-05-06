using Blackbird.Application.Dtos;
using Blackbird.Application.Features.Products.Queries;
using Blackbird.Application.Infrastructure.Persistence;
using Blackbird.Domain.Entities;
using FluentAssertions;
using NSubstitute;

namespace Blackbird.Application.Tests.Features.Products.Queries
{
    public class GetAllProductsQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product(1, "Product 1", 10),
                new Product(2, "Product 2", 20),
                new Product(3, "Product 3", 30)
            };

            var productRepository = Substitute.For<IProductRepository>();
            productRepository.GetAllAsync().Returns(products);

            var handler = new GetAllProductsQueryHandler(productRepository);

            // Act
            var result = await handler.Handle(new GetAllProductsQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);

            var expectedProducts = products.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price
            }).ToList();

            result.Should().BeEquivalentTo(expectedProducts);
        }

    }
}
