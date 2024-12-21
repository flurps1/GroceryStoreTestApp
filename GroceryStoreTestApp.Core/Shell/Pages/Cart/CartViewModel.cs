using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GroceryStoreTestApp.Core;

public partial class CartViewModel : PageViewModel
{
    [ObservableProperty] private ObservableCollection<CartItemViewModel> _cartItems;
    [ObservableProperty] private int _totalProducts;

    private readonly List<ProductModel> _products;

    public CartViewModel(ICartService cartService, IProductService productService)
    {
        PageName = ApplicationPageNames.Cart;
        CartItems = cartService.CartItems;
        _products = productService.GetProductsAsync().Result;

        CartItems.CollectionChanged += OnCartItemsCollectionChanged;
        SubscribeToCartItems(CartItems);

        UpdateProducts();
    }

    private void OnCartItemsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (CartItemViewModel newItem in e.NewItems)
            {
                newItem.PropertyChanged += OnCartItemPropertyChanged;
            }
        }

        if (e.OldItems != null)
        {
            foreach (CartItemViewModel oldItem in e.OldItems)
            {
                oldItem.PropertyChanged -= OnCartItemPropertyChanged;
            }
        }

        UpdateProducts();
    }

    private void OnCartItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(CartItemViewModel.Quantity))
        {
            UpdateProducts();
        }
    }

    private void SubscribeToCartItems(ObservableCollection<CartItemViewModel> items)
    {
        foreach (var item in items)
        {
            item.PropertyChanged += OnCartItemPropertyChanged;
        }
    }

    private void UpdateProducts()
    {
        TotalProducts = CartItems.Sum(x => x.Quantity);
        foreach (var item in CartItems)
        {
            var product = _products.FirstOrDefault(p => p.name == item.Name);
            if (product != null)
            {
                item.IsAvailable = item.Quantity <= product.quantity;
            }
        }
    }
}