using Blackbird.Application.Dtos;
using Blackbird.RazorComponents.Buttons;
using Blackbird.RazorComponents.States;
using Bunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Blackbird.RazorComponents.Tests.Buttons
{
    // RemoveFromBasketButtonTests.cs

    public class RemoveFromBasketButtonTests : TestContext
    {
        [Fact]
        public void RemoveFromBasketButton_Click_RemovesItemFromBasket()
        {
            // Arrange
            var basketState = new BasketState();
            var item = new ProductDto { ProductId = "1", Name = "Test Product", Price = 10 };
            basketState.AddToBasket(item);

            Services.AddSingleton(basketState);
            var cut = RenderComponent<RemoveFromBasketButton>(parameters => parameters
                .Add(p => p.Product, item)
            );

            // Act
            cut.Find("button").Click();

            // Assert
            basketState.BasketItems.Should().BeEmpty();
        }
    }

}
