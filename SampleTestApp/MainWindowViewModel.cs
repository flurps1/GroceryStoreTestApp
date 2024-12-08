using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Material.Icons;

namespace SampleTestApp;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly PageFactory _pageFactory;
    [ObservableProperty] private MenuItem? _selectedItem;
    [ObservableProperty] private PageViewModel? _currentPage;
    [ObservableProperty] private bool _isMinimal = true;
    
    public MainWindowViewModel(PageFactory pageFactory)
    {
        _pageFactory = pageFactory;

        Items = new ObservableCollection<MenuItem>
        {
            new(ApplicationPageNames.Shop, "Shop", MaterialIconKind.Storefront),
            new(ApplicationPageNames.Cart, "Cart", MaterialIconKind.ShoppingCart),
            new(ApplicationPageNames.Profile, "Profile", MaterialIconKind.Person)
        };
        SelectedItem = Items.First();
        CurrentPage = _pageFactory.GetPageViewModel(SelectedItem.PageName);
    }

    partial void OnSelectedItemChanged(MenuItem? value)
    {
        if (value is null) return;
        CurrentPage = _pageFactory.GetPageViewModel(value.PageName);
    }

    partial void OnIsMinimalChanged(bool value)
    {
        IsMinimal = !value;
    }
    
    public ObservableCollection<MenuItem> Items { get; }
}