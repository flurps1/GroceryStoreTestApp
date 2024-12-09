using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using Material.Icons;
using Image = Avalonia.Controls.Image;

namespace SampleTestApp;

public partial class ShopViewModel : PageViewModel
{
    [ObservableProperty]
    private ObservableCollection<ProductViewModel> _products;

    public ShopViewModel()
    {
        PageName = ApplicationPageNames.Shop;
        Icon = MaterialIconKind.Storefront;

        Products =
        [
            new ProductViewModel(new Image(), "Бананы", 10),
            new ProductViewModel(new Image(), "Яблоки", 20),
            new ProductViewModel(new Image(), "Груши", 30),
            new ProductViewModel(new Image(), "Помидоры", 40)
        ];
    }
}