using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SampleTestApp.Core;

public partial class ProductViewModel : PageViewModel
{
    public string Name { get; }
    public Bitmap? IconPath { get; }

    [ObservableProperty]
    private int _quantity;

    public ProductViewModel(Bitmap iconPath, string name, int quantity)
    {
        IconPath = iconPath;
        Name = name;
        Quantity = quantity;
    }

    public RelayCommand BuyCommand { get; set; }
}