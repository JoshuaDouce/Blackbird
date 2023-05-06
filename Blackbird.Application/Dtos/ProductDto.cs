namespace Blackbird.Application.Dtos
{
    public class ProductDto
    {
        public required string ProductId { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
