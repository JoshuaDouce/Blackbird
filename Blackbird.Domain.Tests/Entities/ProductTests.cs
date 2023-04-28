using Blackbird.Domain.Entities;
using FluentAssertions;

namespace Blackbird.Domain.Tests.Entities
{
    public class ProductTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        public void CreateProduct_ValidData_ShouldCreateProduct(decimal validPrice)
        {
            // Arrange
            int id = 1;
            string name = "Product A";
            decimal price = validPrice;

            // Act
            var product = new Product(id, name, price);

            // Assert
            product.Id.Should().Be(id);
            product.Name.Should().Be(name);
            product.Price.Should().Be(price);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CreateProduct_InvalidName_ShouldThrowArgumentException(string invalidName)
        {
            // Arrange
            int id = 1;
            decimal price = 10.0m;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Product(id, invalidName, price));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        public void CreateProduct_InvalidPrice_ShouldThrowArgumentException(decimal invalidPrice)
        {
            // Arrange
            int id = 1;
            string name = "Product A";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Product(id, name, invalidPrice));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void CreateProduct_InvalidId_ShouldThrowArgumentException(int invalidId)
        {
            // Arrange
            string name = "Product A";
            decimal price = 10.0m;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Product(invalidId, name, price));
        }
    }
}
