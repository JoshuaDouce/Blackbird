using Blackbird.RazorComponents.States;

namespace Blackbird.RazorComponents.Tests.States
{
    public class BasketStateTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void IncrementBasketItemCount_ShouldIncreaseItemCount(int timesToIncrement, int expectedItemCount)
        {
            // Arrange
            var basketState = new BasketState();

            // Act
            for (int i = 0; i < timesToIncrement; i++)
            {
                basketState.IncrementBasketItemCount();
            }

            // Assert
            Assert.Equal(expectedItemCount, basketState.BasketItemCount);
        }
    }
}
