using System.Collections.ObjectModel;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GroceryStoreTestApp.Core;

public partial class MainViewModel : ViewModelBase
{
    private readonly PageFactory _pageFactory;
    [ObservableProperty] private MenuItem? _selectedItem;
    [ObservableProperty] private PageViewModel? _currentPage;
    [ObservableProperty] private bool _isMinimal;

    public MainViewModel(PageFactory pageFactory)
    {
        _pageFactory = pageFactory;

        Items = new ObservableCollection<MenuItem>
        {
            new(ApplicationPageNames.Shop, "Shop", new Uri("avares://GroceryStoreTestApp.Core/Assets/png/home.png")),
            new(ApplicationPageNames.Cart, "Cart", new Uri("avares://GroceryStoreTestApp.Core/Assets/png/online-shopping.png")),
            new(ApplicationPageNames.Profile, "Profile", new Uri("avares://GroceryStoreTestApp.Core/Assets/png/user.png"))
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

    private ObservableCollection<MenuItem> Items { get; }
}