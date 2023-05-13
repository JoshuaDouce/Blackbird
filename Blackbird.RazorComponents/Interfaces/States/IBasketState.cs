using Blackbird.Application.Dtos;

namespace Blackbird.RazorComponents.Interfaces.States
{
    public interface IBasketState
    {
        public event Action OnChange;

        public int BasketItemCount();

        public IList<ProductDto> GetProducts();

        public void AddProduct(ProductDto product);

        public void RemoveProduct(ProductDto product);

        public void ClearProduct(ProductDto product);
    }
}
