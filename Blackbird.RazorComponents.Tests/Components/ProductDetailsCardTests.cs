using Blackbird.Application.Dtos;
using Blackbird.Domain.Entities;
using Blackbird.RazorComponents.Buttons;
using Blackbird.RazorComponents.States;
using Bunit;
using Microsoft.Extensions.DependencyInjection;

namespace Blackbird.RazorComponents.Tests.Components
{
    public class ProductDetailsCardTests
    {
        private readonly TestContext _context;

        public ProductDetailsCardTests()
        {
            _context = new TestContext();
            _context.Services.AddSingleton<BasketState>();
        }

        [Fact]
        public void ProductDetailsCard_ShouldDisplayProductDetails()
        {
            // Arrange
            var product = new ProductDto
            {
                ProductId = "123",
                Name = "Test Product",
                Price = 10.99M,
                ImageUrl = "https://example.com/image.jpg"
            };

            var parameters = new ComponentParameter[]
            {
                ComponentParameter.CreateParameter("Product", product)
            };

            var cut = _context.RenderComponent<ProductDetailsCard>(parameters);

            // Act
            var productName = cut.Find("h5").TextContent;
            var productPrice = cut.Find("p").TextContent;

            // Assert
            Assert.Equal(product.Name, productName);
            Assert.Contains(product.Price.ToString(), productPrice);
            Assert.NotNull(cut.FindComponent<AddToBasketButton>());
            Assert.NotNull(cut.FindComponent<RemoveFromBasketButton>());
        }
    }
}
