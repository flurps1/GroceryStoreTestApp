using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using SampleTestApp;

namespace SampleTestApp;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection();
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<ShopViewModel>();
        collection.AddTransient<CartViewModel>();
        collection.AddTransient<ProfileViewModel>();


        collection.AddSingleton<Func<ApplicationPageNames, PageViewModel>>(x => name => name switch
        {
            ApplicationPageNames.Home => x.GetRequiredService<HomeViewModel>(),
            ApplicationPageNames.Shop => x.GetRequiredService<ShopViewModel>(),
            ApplicationPageNames.Cart => x.GetRequiredService<CartViewModel>(),
            ApplicationPageNames.Profile => x.GetRequiredService<ProfileViewModel>(),
            _ => throw new ArgumentOutOfRangeException(nameof(name), name, "Unknown page name")
        });

        collection.AddSingleton<PageFactory>();

        var provider = collection.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.MainWindow = new MainWindow
            {
                DataContext = provider.GetRequiredService<MainWindowViewModel>()
            };

        base.OnFrameworkInitializationCompleted();
    }
}