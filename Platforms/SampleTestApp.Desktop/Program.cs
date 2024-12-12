using System;
using Avalonia;
using SampleTestApp.Core;

namespace SampleTestApp.Desktop;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            // Windows
            .With(new Win32PlatformOptions { OverlayPopups = true })
            // Unix/Linux
            .With(new X11PlatformOptions { OverlayPopups = true, UseDBusFilePicker = false })
            // Mac
            .With(new AvaloniaNativePlatformOptions { OverlayPopups = true })
            .WithInterFont()
            .LogToTrace();
    }
}