using System.Diagnostics.CodeAnalysis;

namespace Blackbird.Domain.Entities
{
    public class Product
    {
        public int Id { get; init; }
        public required string ProductId { get; set; }
        public required string Name { get; init; }
        public decimal Price { get; init; }
        public string Description { get; init; } = "";
        public string ImageUrl { get; init; } = "";

        [SetsRequiredMembers]
        public Product(int id, string name, decimal price, string description = "", string imageUrl = "")
        {
            if (id <= 0)
            {
                throw new ArgumentException(null, nameof(id));
            }

            if (price < 0)
            {
                throw new ArgumentException(null, nameof(price));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(null, nameof(name));
            }

            Id = id;
            ProductId = Guid.NewGuid().ToString();
            Name = name;
            Price = price;
            Description = description;
            ImageUrl = imageUrl;
        }

        public class Dto
        {
        }
    }

}