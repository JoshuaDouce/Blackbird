using Blackbird.Application.Dtos;
using Blackbird.RazorComponents.Buttons;
using Blackbird.RazorComponents.Interfaces.States;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace Blackbird.RazorComponents.Tests.Buttons;

// ClearFromBasketButtonTests.cs

public class ClearFromBasketButtonTests : TestContext
{
    [Fact]
    public void ClearFromBasketButton_Click_ClearsItemFromBasket()
    {
        // Arrange
        var basketState = Substitute.For<IBasketState>();
        var product = new ProductDto { ProductId = "1", Name = "Test Product", Price = 10 };

        Services.AddSingleton(basketState);
        var cut = RenderComponent<ClearFromBasketButton>(parameters =>
            parameters.Add(P => P.Product, product));

        // Act
        cut.Find("button").Click();

        // Assert
        basketState.Received().ClearProduct(product);
    }
}
