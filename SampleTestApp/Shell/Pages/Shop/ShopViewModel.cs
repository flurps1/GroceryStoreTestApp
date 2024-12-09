using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using Material.Icons;
using Image = Avalonia.Controls.Image;

namespace SampleTestApp;

public partial class ShopViewModel : PageViewModel
{
    [ObservableProperty] private ObservableCollection<ProductViewModel> _products;

    private readonly ProductServices.IProductService _productService;
    private readonly IProductViewModelFactory _productViewModelFactory;

    public ShopViewModel(ProductServices.IProductService productService,
        IProductViewModelFactory productViewModelFactory)
    {
        PageName = ApplicationPageNames.Shop;
        _productService = productService;
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
            Products.Add(productViewModel);
        }
    }
}