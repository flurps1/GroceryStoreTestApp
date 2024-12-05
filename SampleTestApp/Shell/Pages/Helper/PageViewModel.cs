using CommunityToolkit.Mvvm.ComponentModel;

namespace SampleTestApp;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty]
    private ApplicationPageNames _pageName;
}