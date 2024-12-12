using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SampleTestApp.Core;

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
            new(ApplicationPageNames.Shop, "Shop"),
            new(ApplicationPageNames.Cart, "Cart"),
            new(ApplicationPageNames.Profile, "Profile")
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