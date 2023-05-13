using Blackbird.Application.Dtos;
using Blackbird.RazorComponents.Buttons;
using Blackbird.RazorComponents.Interfaces.States;
using Bunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using NSubstitute;

namespace Blackbird.RazorComponents.Tests.Components;

// BasketProductSummaryTests.cs

public class BasketProductSummaryTests : TestContext
{
    [Fact]
    public void BasketProductSummary_DisplaysCorrectInfo()
    {
        // Arrange
        var basketState = Substitute.For<IBasketState>();
        Services.AddSingleton(basketState);

        var basketItem = new ProductDto
        {
            ProductId = "1",
            Name = "Test Product",
            Price = 10,
            Quantity = 2
        };

        // Act
        var cut = RenderComponent<BasketProductSummary>(parameters => parameters
            .Add(p => p.Product, basketItem)
        );

        // Assert
        var textContent = cut.FindComponents<MudText>();
        textContent.Where(mudText => mudText.Markup.Contains(basketItem.Name)).Should().NotBeNullOrEmpty();
        textContent.Where(mudText => mudText.Markup.Contains(basketItem.Price.ToString("C"))).Should().NotBeNullOrEmpty();
        textContent.Where(mudText => mudText.Markup.Contains(basketItem.Quantity.ToString())).Should().NotBeNullOrEmpty();
        textContent.Where(mudText => mudText.Markup.Contains((basketItem.Quantity * basketItem.Price).ToString("C"))).Should().NotBeNullOrEmpty();

        cut.FindComponent<AddToBasketButton>().Should().NotBeNull();
        cut.FindComponent<RemoveFromBasketButton>().Should().NotBeNull();
        cut.FindComponent<ClearFromBasketButton>().Should().NotBeNull();
    }
}
