using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace SampleTestApp.Core;

public class Header : TemplatedControl
{
    public static readonly StyledProperty<string> PageNameProperty = AvaloniaProperty.Register<Header, string>(
        nameof(PageName), "Home");

    public string PageName
    {
        get => GetValue(PageNameProperty);
        set => SetValue(PageNameProperty, value);
    }
}