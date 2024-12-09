using Avalonia.Controls;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SampleTestApp;

public partial class ProductViewModel : PageViewModel
{
    public string Name { get; }
    public string IconPath { get; }
    
    [ObservableProperty]
    private int _quantity;

    public ProductViewModel(string iconPath, string name, int quantity)
    {
        IconPath = iconPath;
        Name = name;
        Quantity = quantity;
    }

    [RelayCommand]
    private void Buy()
    {
        if (Quantity > 0)
        {
            Quantity--; // Уменьшаем количество
        }
    }
}