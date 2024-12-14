using Avalonia.Media.Imaging;

namespace SampleTestApp.Core;

public class MenuItem
{
    public MenuItem(ApplicationPageNames pageName, string title, Uri iconUri)
    {
        PageName = pageName;
        Title = title;
        IconUri = iconUri;
    }

    public ApplicationPageNames PageName { get; }
    public string Title { get; }
    public Uri IconUri { get; }
}