using Blackbird.Application.Dtos;
using Blackbird.RazorComponents.Buttons;
using Blackbird.RazorComponents.Interfaces.States;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using NSubstitute;

namespace Blackbird.RazorComponents.Tests.Buttons
{
    public class AddToCartButtonTests
    {
        private readonly TestContext _ctx;
        private readonly IBasketState _basketState;

        public AddToCartButtonTests()
        {
            _basketState = Substitute.For<IBasketState>();
            _ctx = new TestContext();
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
            Assert.NotNull(cut.FindComponent<MudButton>());
            _basketState.Received(1).AddProduct(product);
        }

        [Fact]
        public void AddToBasketButton_UseIcon_ShouldDisplayIconButton()
        {
            // Arrange
            var product = new ProductDto
            {
                ProductId = "1",
                Name = "Test Product",
                Price = 9.99m
            };

            var cut = _ctx.RenderComponent<AddToBasketButton>(parameters => parameters
                .Add(p => p.Product, product)
                .Add(p => p.UseIconButton, true));

            // Act
            cut.Find("button").Click();

            // Assert
            Assert.NotNull(cut.FindComponent<MudIconButton>());
            _basketState.Received(1).AddProduct(product);
        }
    }
}
