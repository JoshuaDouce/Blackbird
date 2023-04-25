namespace Blackbird.Domain
{
    public class Product
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public decimal Price { get; init; }
        public string Description { get; init; } = "";
        public string ImageUrl { get; init; } = "";

        public Product(int id, string name, decimal price, string description = "", string imageUrl = "")
        {
            if (id > 0)
            {
                throw new ArgumentException(nameof(id));
            }

            if(price < 0)
            {
                throw new ArgumentNullException(nameof(price));
            }

            Id = id;
            Name = name;
            Price = price;
            Description = description;
            ImageUrl = imageUrl;
        }
    }

}