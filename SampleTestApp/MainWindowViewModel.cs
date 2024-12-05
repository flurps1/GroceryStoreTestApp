using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SampleTestApp;

public partial class MainWindowViewModel : ViewModelBase
{
    private PageFactory _pageFactory;
    
    [ObservableProperty] private bool _sideMenuExpanded = true;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomePageIsActive))]
    [NotifyPropertyChangedFor(nameof(ShopPageIsActive))]
    [NotifyPropertyChangedFor(nameof(CartPageIsActive))]
    [NotifyPropertyChangedFor(nameof(ProfilePageIsActive))]
    private PageViewModel _currentPage;
    
    public bool HomePageIsActive => CurrentPage.PageName == ApplicationPageNames.Home;
    public bool ProfilePageIsActive => CurrentPage.PageName == ApplicationPageNames.Shop;
    public bool CartPageIsActive => CurrentPage.PageName == ApplicationPageNames.Cart;
    public bool ShopPageIsActive => CurrentPage.PageName == ApplicationPageNames.Profile;

    public MainWindowViewModel(PageFactory pageFactory)
    {
        _pageFactory = pageFactory;
        GoToHome();
    }
    
    [RelayCommand]
    private void SideMenuResize()
    {
        SideMenuExpanded = !SideMenuExpanded;
    }
    
    [RelayCommand] private void GoToHome() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Home);
    [RelayCommand] private void GoToCart() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Shop);
    [RelayCommand] private void GoToShop() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Cart);
    [RelayCommand] private void GoToProfile() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Profile);
}