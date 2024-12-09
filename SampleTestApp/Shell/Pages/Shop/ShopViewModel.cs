using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SampleTestApp;

public partial class ShopViewModel : PageViewModel
{
    [ObservableProperty] private ObservableCollection<ProductViewModel> _products;

    private readonly ProductServices.IProductService _productService;
    private readonly ICartService _cartService;
    private readonly IProductViewModelFactory _productViewModelFactory;

    public ShopViewModel(ProductServices.IProductService productService,
        ICartService cartService,
        IProductViewModelFactory productViewModelFactory)
    {
        PageName = ApplicationPageNames.Shop;
        _productService = productService;
        _cartService = cartService;
        _productViewModelFactory = productViewModelFactory;

        Products = new ObservableCollection<ProductViewModel>();
        _ = LoadProductsAsync();
    }

    private async Task LoadProductsAsync()
    {
        var productModels = await _productService.GetProductsAsync();
        foreach (var product in productModels)
        {
            var productViewModel = _productViewModelFactory.Create(product.IconPath, product.Name, product.Quantity);
            
            productViewModel.BuyCommand = new RelayCommand(() =>
            {
                if (productViewModel.Quantity > 0)
                {
                    productViewModel.Quantity--;
                    _cartService.AddToCart(productViewModel.Name, 1);
                }
            });

            Products.Add(productViewModel);
        }
    }
}