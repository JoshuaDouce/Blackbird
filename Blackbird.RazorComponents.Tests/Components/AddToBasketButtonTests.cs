using Blackbird.Application.Dtos;
using Blackbird.RazorComponents.States;
using Blackbird.RazorComponents.Buttons;
using Bunit;
using Microsoft.Extensions.DependencyInjection;

namespace Blackbird.RazorComponents.Tests.Components
{
    public class AddToCartButtonTests
    {
        private readonly TestContext _ctx;
        private readonly BasketState _basketState;

        public AddToCartButtonTests()
        {
            _ctx = new TestContext();
            _basketState = new BasketState();
            _ctx.Services.AddSingleton(_basketState);
        }

        [Fact]
        public void AddToCartButton_OnClick_ShouldCallAddToBasket()
        {
            // Arrange
            var product = new ProductDto
            {
                ProductId = "1",
                Name = "Test Product",
                Price = 9.99m
            };

            var cut = _ctx.RenderComponent<AddToBasketButton>(parameters => parameters
                .Add(p => p.Product, product));

            // Act
            cut.Find("button").Click();

            // Assert
            Assert.Single(_basketState.BasketItems);
            Assert.Equal(product.ProductId, _basketState.BasketItems.First().ProductId);
        }
    }
}
