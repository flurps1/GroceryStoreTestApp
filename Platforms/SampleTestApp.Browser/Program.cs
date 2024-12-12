using System.Threading.Tasks;
using Avalonia;
using Avalonia.Browser;
using SampleTestApp.Core;

namespace SampleTestApp.Browser;

internal sealed partial class Program
{
    private static Task Main(string[] args) => BuildAvaloniaApp()
        .WithInterFont()
        .StartBrowserAppAsync("bin/Release/net8.0-browser/publish/wwwroot");

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>();
}