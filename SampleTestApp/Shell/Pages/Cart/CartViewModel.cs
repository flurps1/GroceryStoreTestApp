using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using DynamicData.Binding;
using Material.Icons;

namespace SampleTestApp;

public partial class CartViewModel : PageViewModel
{
    [ObservableProperty] private ObservableCollection<CartItemViewModel> _cartItems;
    [ObservableProperty] private int _totalProducts;

    private readonly ProductServices.IProductService _productService;

    public CartViewModel(ICartService cartService, ProductServices.IProductService productService)
    {
        PageName = ApplicationPageNames.Cart;
        _productService = productService;
        CartItems = cartService.CartItems;

        CartItems.CollectionChanged += (s, e) =>
        {
            if (e.NewItems != null)
            {
                foreach (CartItemViewModel newItem in e.NewItems)
                {
                    newItem.PropertyChanged += (_, _) => _ = UpdateAvailability();
                }
            }

            TotalProducts = CartItems.Sum(x => x.Quantity);
            _ = UpdateAvailability();
        };

        foreach (var item in CartItems)
        {
            item.PropertyChanged += (_, _) => _ = UpdateAvailability();
        }

        _ = UpdateAvailability();
    }

    private async Task UpdateAvailability()
    {
        var products = await _productService.GetProductsAsync();

        foreach (var cartItem in CartItems)
        {
            var product = products.FirstOrDefault(p => p.Name == cartItem.Name);

            if (product != null)
            {
                cartItem.IsAvailable = cartItem.Quantity <= product.Quantity;
            }
        }
    }
}