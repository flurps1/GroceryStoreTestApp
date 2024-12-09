using Avalonia.Controls;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SampleTestApp;

public partial class ProductViewModel : PageViewModel
{
    public string Name { get; }
    public Image IconPath { get; }
    
    // Количество товара
    [ObservableProperty]
    private int _quantity;

    public ProductViewModel(Image iconPath, string name, int quantity)
    {
        IconPath = iconPath;
        Name = name;
        Quantity = quantity;
    }

    // Команда покупки
    [RelayCommand]
    private void Buy()
    {
        if (Quantity > 0)
        {
            Quantity--; // Уменьшаем количество
        }
    }
}