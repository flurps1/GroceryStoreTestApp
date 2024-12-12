namespace SampleTestApp.Core;

public class PageFactory(Func<ApplicationPageNames, PageViewModel> factory)
{
    public PageViewModel GetPageViewModel(ApplicationPageNames pageNames)
    {
        return factory.Invoke(pageNames);
    }
}