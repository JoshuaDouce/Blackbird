using Blackbird.Application.Dtos;
using Blackbird.RazorComponents.States;
using FluentAssertions;

namespace Blackbird.RazorComponents.Tests.States
{
    public class BasketStateTests
    {
        private BasketState _basketState;

        public BasketStateTests()
        {
            _basketState = new BasketState();
        }

        [Fact]
        public void AddToBasket_ShouldAddProductToBasket()
        {
            // Arrange
            var product = new ProductDto { ProductId = "1", Name = "Test Product", Price = 10 };

            // Act
            _basketState.AddToBasket(product);

            // Assert
            _basketState.BasketItems.Should().ContainSingle();
            _basketState.BasketItemCount.Should().Be(1);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 1, 3)]
        [InlineData(3, 2, 5)]
        public void AddToBasket_ShouldIncrementProductQuantity_WhenProductAlreadyExists(int initialQuantity, int timesToAdd, int expectedQuantity)
        {
            // Arrange
            var product = new ProductDto { ProductId = "1", Name = "Test Product", Price = 10, Quantity = initialQuantity };
            _basketState.BasketItems.Add(product);

            // Act
            for (int i = 0; i < timesToAdd; i++)
            {
                _basketState.AddToBasket(product);
            }

            // Assert
            _basketState.BasketItems.Should().ContainSingle();
            _basketState.BasketItemCount.Should().Be(expectedQuantity);
        }
    }
}
