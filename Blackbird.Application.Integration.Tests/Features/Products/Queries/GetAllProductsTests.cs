using AutoMapper;
using Blackbird.Application.Automapper;
using Blackbird.Application.Features.Products.Queries;
using Blackbird.Application.Infrastructure.Persistence;
using Blackbird.Infrastructure;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Blackbird.Application.Integration.Tests.Features.Products.Queries
{
    public class GetAllProductsTests : IClassFixture<TestFixture>
    {
        private readonly TestFixture _fixture;

        public GetAllProductsTests(TestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Handle_ShouldReturnAllProducts()
        {
            // Arrange
            using var scope = _fixture.ServiceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<BlackbirdDbContext>();

            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            var mapper = mappingConfig.CreateMapper();

            var productRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();
            var handler = new GetAllProductsQueryHandler(productRepository, mapper);

            // Act
            var result = await handler.Handle(new GetAllProductsQuery(), default);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(10);
        }
    }
}
