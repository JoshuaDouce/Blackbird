using Blackbird.Domain.Entities;
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
                Assert.Contains(product.Description, cards[i].Markup);
                Assert.Contains($"{product.Price}", cards[i].Markup);
            }
        }

        private static List<Product> GetTestProducts()
        {
            return new List<Product>
            {
                new Product(id : 1, name: "Product 1", price: 9.99m, description: "Description 1", imageUrl: "https://example.com/image1.jpg"),
                new Product(id : 2, name: "Product 2", price: 19.99m, description: "Description 2", imageUrl: "https://example.com/image2.jpg"),
                new Product(id : 3, name: "Product 3", price: 29.99m, description: "Description 3", imageUrl: "https://example.com/image3.jpg"),
            };
        }
    }
}
