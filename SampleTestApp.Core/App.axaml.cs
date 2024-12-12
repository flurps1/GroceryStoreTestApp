using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;

namespace SampleTestApp.Core;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection();
        
        collection.AddSingleton(new HttpClient());
        collection.AddSingleton<ProductServices.IProductService, ProductServices.ProductService>();
        collection.AddSingleton<ICartService, CartService>();
        
        collection.AddSingleton<MainViewModel>();
        collection.AddSingleton<ShopViewModel>();
        collection.AddSingleton<CartViewModel>();
        collection.AddSingleton<ProfileViewModel>();
        

        collection.AddSingleton<Func<ApplicationPageNames, PageViewModel>>(x => name => name switch
        {
            ApplicationPageNames.Shop => x.GetRequiredService<ShopViewModel>(),
            ApplicationPageNames.Cart => x.GetRequiredService<CartViewModel>(),
            ApplicationPageNames.Profile => x.GetRequiredService<ProfileViewModel>(),
            _ => throw new ArgumentOutOfRangeException(nameof(name), name, "Unknown page name")
        });

        collection.AddSingleton<PageFactory>();
        collection.AddSingleton<IProductViewModelFactory, ProductViewModelFactory>();

        var provider = collection.BuildServiceProvider();

        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                desktop.MainWindow = new MainWindow
                {
                    DataContext = provider.GetRequiredService<MainViewModel>()
                };
                break;
            case ISingleViewApplicationLifetime singleView:
                singleView.MainView = new MainView
                {
                    DataContext = provider.GetRequiredService<MainViewModel>()
                };
                break;
        }

        base.OnFrameworkInitializationCompleted();
    }
}