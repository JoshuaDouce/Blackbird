using Blackbird.Application.Dtos;

namespace Blackbird.RazorComponents.States
{
    public class BasketState
    {
        public event Action OnChange;

        public IList<ProductDto> BasketItems { get; private set; } = new List<ProductDto>();

        public int BasketItemCount => BasketItems.Sum(x => x.Quantity);

        public void AddToBasket(ProductDto product)
        {
            var basketItem = BasketItems.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (basketItem == null)
            {
                BasketItems.Add(product);
            }
            else
            {
                basketItem.Quantity++;
            }

            NotifyStateChanged();
        }

        public void RemoveItemFromBasket(ProductDto product)
        {
            var basketItem = BasketItems.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (basketItem == null || basketItem.Quantity == 1)
            {
                BasketItems.Remove(product);
            }
            else
            {
                basketItem.Quantity--;
            }

            NotifyStateChanged();
        }

        public void ClearItemFromBasket(ProductDto product)
        {
            var item = BasketItems.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (item != null)
            {
                BasketItems.Remove(item);
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
