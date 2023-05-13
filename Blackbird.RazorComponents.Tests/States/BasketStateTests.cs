using Blackbird.Application.Dtos;
using Blackbird.RazorComponents.States;
using FluentAssertions;

namespace Blackbird.RazorComponents.Tests.States
{
    public class BasketStateTests
    {
        private readonly BasketState _basketState;

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
            _basketState.AddProduct(product);

            // Assert
            _basketState.GetProducts().Should().ContainSingle();
            _basketState.BasketItemCount().Should().Be(1);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 1, 3)]
        [InlineData(3, 2, 5)]
        public void AddToBasket_ShouldIncrementProductQuantity_WhenProductAlreadyExists(int initialQuantity, int timesToAdd, int expectedQuantity)
        {
            // Arrange
            var product = new ProductDto { ProductId = "1", Name = "Test Product", Price = 10, Quantity = initialQuantity };
            _basketState.GetProducts().Add(product);

            // Act
            for (int i = 0; i < timesToAdd; i++)
            {
                _basketState.AddProduct(product);
            }

            // Assert
            _basketState.GetProducts().Should().ContainSingle();
            _basketState.BasketItemCount().Should().Be(expectedQuantity);
        }

        [Fact]
        public void RemoveItemFromBasket_ShouldRemoveEntireItem()
        {
            // Arrange
            var basketState = new BasketState();
            var product = new ProductDto { ProductId = "1", Name = "Test Product", Price = 10, Quantity = 1 };
            basketState.AddProduct(product);

            // Act
            basketState.RemoveProduct(product);

            // Assert
            Assert.Empty(basketState.GetProducts());
        }

        [Fact]
        public void DecreaseQuantity_ShouldDecreaseItemQuantityByOne()
        {
            // Arrange
            var basketState = new BasketState();
            var product = new ProductDto { ProductId = "1", Name = "Test Product", Price = 10, Quantity = 2 };
            basketState.AddProduct(product);

            // Act
            basketState.RemoveProduct(product);

            // Assert
            Assert.Single(basketState.GetProducts());
            Assert.Equal(1, basketState.GetProducts()[0].Quantity);
        }

        [Fact]
        public void ClearItemFromBasket_ShouldClearItems()
        {
            // Arrange
            var basketState = new BasketState();
            var product1 = new ProductDto { ProductId = "1", Name = "Test Product 1", Price = 10, Quantity = 1 };
            var product2 = new ProductDto { ProductId = "2", Name = "Test Product 2", Price = 20, Quantity = 1 };
            basketState.AddProduct(product1);
            basketState.AddProduct(product2);

            // Act
            basketState.ClearProduct(product1);

            // Assert
            Assert.Single(basketState.GetProducts());
            Assert.DoesNotContain(product1, basketState.GetProducts());
            Assert.Contains(product2, basketState.GetProducts());
        }

    }
}
