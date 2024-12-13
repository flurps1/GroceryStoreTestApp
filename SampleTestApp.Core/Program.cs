using System.Diagnostics;
using Avalonia;

namespace SampleTestApp.Core;

internal sealed class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.

    [STAThread]
    public static void Main(string[] args)
    {
        // https://docs.avaloniaui.net/ru/docs/concepts/unhandledexceptions
        try
        {
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }
        catch (Exception e)
        {
            if (Debugger.IsAttached) Debugger.Break();
        }
    }

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