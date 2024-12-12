using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace SampleTestApp.Core;

public class ImageHelper
{
    public static Bitmap LoadFromResource(Uri resourceUri)
    {
        return new Bitmap(AssetLoader.Open(resourceUri));
    }
}