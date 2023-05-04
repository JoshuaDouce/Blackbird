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
                new Product(1, "Product 1", 10.00m),
                new Product(2, "Product 2", 20.00m),
            };

            var productRepositoryMock = Substitute.For<IProductRepository>();
            productRepositoryMock
                .GetAllAsync()
                .Returns(products);

            var handler = new GetAllProductsQueryHandler(productRepositoryMock);

            // Act
            var result = await handler.Handle(new GetAllProductsQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(products);
            await productRepositoryMock.Received(1).GetAllAsync();
        }
    }
}
