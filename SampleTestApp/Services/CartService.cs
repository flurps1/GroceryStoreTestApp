using System.Collections.ObjectModel;
using System.Linq;

namespace SampleTestApp;

public interface ICartService
{
    ObservableCollection<CartItemViewModel> CartItems { get; }
    void AddToCart(string name, int quantity);
    void ClearCart();
}

public class CartService : ICartService
{
    public ObservableCollection<CartItemViewModel> CartItems { get; } = new();

    public void AddToCart(string name, int quantity)
    {
        var existingItem = CartItems.FirstOrDefault(item => item.Name == name);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            CartItems.Add(new CartItemViewModel
            {
                Name = name,
                Quantity = quantity
            });
        }
    }

    public void ClearCart() => CartItems.Clear();
}