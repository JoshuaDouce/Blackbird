using Blackbird.RazorComponents.States;
using Bunit;
using Microsoft.Extensions.DependencyInjection;

namespace Blackbird.RazorComponents.Tests.Components
{
    public class AddToCartButtonTests
    {
        private readonly TestContext _context;

        public AddToCartButtonTests()
        {
            _context = new TestContext();
            _context.Services.AddSingleton<BasketState>();
        }

        [Fact]
        public void AddToCartButton_OnClick_ShouldIncrementBasketItemCount()
        {
            // Arrange
            var basketState = _context.Services.GetRequiredService<BasketState>();
            var cut = _context.RenderComponent<AddToCartButton>();

            // Act
            cut.Find("button").Click();

            // Assert
            Assert.Equal(1, basketState.BasketItemCount);
        }
    }
}
