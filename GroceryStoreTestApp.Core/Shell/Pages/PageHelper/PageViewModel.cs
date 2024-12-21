using CommunityToolkit.Mvvm.ComponentModel;

namespace GroceryStoreTestApp.Core;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty] private ApplicationPageNames _pageName;
}