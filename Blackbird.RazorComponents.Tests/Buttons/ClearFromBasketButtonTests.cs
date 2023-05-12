using Blackbird.Application.Dtos;
using Blackbird.RazorComponents.Buttons;
using Blackbird.RazorComponents.States;
using Bunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Blackbird.RazorComponents.Tests.Buttons
{
    // ClearFromBasketButtonTests.cs

    public class ClearFromBasketButtonTests : TestContext
    {
        [Fact]
        public void ClearFromBasketButton_Click_ClearsItemFromBasket()
        {
            // Arrange
            var basketState = new BasketState();
            var item = new ProductDto { ProductId = "1", Name = "Test Product", Price = 10 };
            basketState.AddToBasket(item);

            Services.AddSingleton(basketState);
            var cut = RenderComponent<ClearFromBasketButton>(parameters => 
                parameters.Add(P => P.Product, item));

            // Act
            cut.Find("button").Click();

            // Assert
            basketState.BasketItems.Should().BeEmpty();
        }
    }

}
