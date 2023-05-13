using Blackbird.Application.Dtos;
using Blackbird.RazorComponents.Interfaces.States;

namespace Blackbird.RazorComponents.States;

public class BasketState : IBasketState
{
    public event Action OnChange;

    private readonly IList<ProductDto> BasketProducts = new List<ProductDto>();

    public int BasketItemCount() => BasketProducts.Sum(x => x.Quantity);

    public IList<ProductDto> GetProducts() => BasketProducts;

    public void AddProduct(ProductDto product)
    {
        var basketItem = BasketProducts.FirstOrDefault(p => p.ProductId == product.ProductId);
        if (basketItem == null)
        {
            BasketProducts.Add(product);
        }
        else
        {
            basketItem.Quantity++;
        }

        NotifyStateChanged();
    }

    public void RemoveProduct(ProductDto product)
    {
        var basketItem = BasketProducts.FirstOrDefault(p => p.ProductId == product.ProductId);
        if (basketItem == null || basketItem.Quantity == 1)
        {
            BasketProducts.Remove(product);
        }
        else
        {
            basketItem.Quantity--;
        }

        NotifyStateChanged();
    }

    public void ClearProduct(ProductDto product)
    {
        var item = BasketProducts.FirstOrDefault(x => x.ProductId == product.ProductId);
        if (item != null)
        {
            BasketProducts.Remove(item);
            NotifyStateChanged();
        }
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
