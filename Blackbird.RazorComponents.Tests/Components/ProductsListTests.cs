using Blackbird.Application.Dtos;
using Blackbird.RazorComponents.Buttons;
using Blackbird.RazorComponents.Interfaces.Services;
using Blackbird.RazorComponents.Interfaces.States;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using NSubstitute;

namespace Blackbird.RazorComponents.Tests.Components
{
    public class ProductsListTests : TestContext
    {
        [Fact]
        public void ProductsList_ShouldDisplayProducts()
        {
            // Arrange
            var productService = Substitute.For<IProductService>();
            productService.GetAllProductsAsync().Returns(GetTestProducts());

            var basketState = Substitute.For<IBasketState>();

            Services.AddSingleton(productService);
            Services.AddSingleton(basketState);
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
                Assert.Contains("Details", cards[i].Markup);
                Assert.NotNull(cards[i].FindComponent<AddToBasketButton>());
                Assert.NotNull(cards[i].FindComponent<RemoveFromBasketButton>());
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
