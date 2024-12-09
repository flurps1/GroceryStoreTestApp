using CommunityToolkit.Mvvm.ComponentModel;
using Material.Icons;

namespace SampleTestApp;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty] private ApplicationPageNames _pageName;
}