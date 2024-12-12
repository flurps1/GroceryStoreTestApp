using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media.Imaging;

namespace SampleTestApp.Core;

public class ProductCard : TemplatedControl
{
    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<ProductCard, string>(
        nameof(Title), "testName");

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly StyledProperty<string> QuantityProperty = AvaloniaProperty.Register<ProductCard, string>(
        nameof(Quantity), "1");

    public string Quantity
    {
        get => GetValue(QuantityProperty);
        set => SetValue(QuantityProperty, value);
    }

    public static readonly StyledProperty<Bitmap> IconProperty = AvaloniaProperty.Register<ProductCard, Bitmap>(
        nameof(Icon),  ImageHelper.LoadFromResource(new Uri("avares://SampleTestApp.Core/Assets/png/banana.png")));

    public Bitmap Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public static readonly StyledProperty<ICommand> CommandProperty = AvaloniaProperty.Register<ProductCard, ICommand>(
        nameof(Command));

    public ICommand Command
    {
        get => GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
}