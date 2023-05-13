using Blackbird.Application.Dtos;
using Blackbird.RazorComponents.Buttons;
using Blackbird.RazorComponents.Interfaces.States;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace Blackbird.RazorComponents.Tests.Buttons;

// RemoveFromBasketButtonTests.cs

public class RemoveFromBasketButtonTests : TestContext
{
    [Fact]
    public void RemoveFromBasketButton_Click_RemovesItemFromBasket()
    {
        // Arrange
        var basketState = Substitute.For<IBasketState>();
        var product = new ProductDto { ProductId = "1", Name = "Test Product", Price = 10 };

        Services.AddSingleton(basketState);
        var cut = RenderComponent<RemoveFromBasketButton>(parameters => parameters
            .Add(p => p.Product, product)
        );

        // Act
        cut.Find("button").Click();

        // Assert
        basketState.Received().RemoveProduct(product);
    }
}
