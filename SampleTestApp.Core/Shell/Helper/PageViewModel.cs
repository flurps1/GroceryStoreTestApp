using CommunityToolkit.Mvvm.ComponentModel;

namespace SampleTestApp.Core;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty] private ApplicationPageNames _pageName;
}