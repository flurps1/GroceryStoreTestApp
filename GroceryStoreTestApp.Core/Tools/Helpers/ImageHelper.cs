using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace GroceryStoreTestApp.Core;

public class ImageHelper
{
    public static Bitmap LoadFromResource(Uri resourceUri)
    {
        return new Bitmap(AssetLoader.Open(resourceUri));
    }
}