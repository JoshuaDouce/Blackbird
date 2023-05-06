using Blackbird.Application.Dtos;
using Blackbird.RazorComponents.Interfaces;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using NSubstitute;

namespace Blackbird.RazorComponents.Tests
{
    public class ProductsListTests : TestContext
    {
        [Fact]
        public void ProductsList_ShouldDisplayProducts()
        {
            // Arrange
            var productService = Substitute.For<IProductService>();
            productService.GetAllProductsAsync().Returns(GetTestProducts());

            Services.AddSingleton(productService);
            Services.AddMudServices();

            // Act
            var cut = RenderComponent<ProductsList>();

            // Assert
            var cards = cut.FindComponents<MudCard>();
            Assert.Equal(3, cards.Count);

            for (int i = 0; i < cards.Count; i++)
            {
                var product = GetTestProducts()[i];
                Assert.Contains(product.Name, cards[i].Markup);
                Assert.Contains(product.ImageUrl, cards[i].Markup);
                Assert.Contains(product.Description, cards[i].Markup);
                Assert.Contains($"{product.Price}", cards[i].Markup);
            }
        }

        private static List<ProductDto> GetTestProducts()
        {
            return new List<ProductDto>
            {
                new ProductDto
                {
                    ProductId = "Id",
                    Name = "Name",
                    Price = 10.99m,
                    Description = "Description 1",
                    ImageUrl = "https://example.com/image1.jpg"
                },
                new ProductDto
                {
                    ProductId = "Id 2",
                    Name = "Name",
                    Price = 10.99m,
                    Description = "Description 2",
                    ImageUrl = "https://example.com/image1.jpg"
                },
                new ProductDto
                {
                    ProductId = "Id 3",
                    Name = "Name",
                    Price = 10.99m,
                    Description = "Description 3",
                    ImageUrl = "https://example.com/image1.jpg"
                },
            };
        }
    }
}
