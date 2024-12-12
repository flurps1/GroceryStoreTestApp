using Avalonia.Media.Imaging;

namespace SampleTestApp.Core;

public class ProductViewModelFactory : IProductViewModelFactory
{
    public ProductViewModel Create(Bitmap iconPath, string name, int quantity)
    {
        return new ProductViewModel(iconPath, name, quantity);
    }
}

public interface IProductViewModelFactory
{
    ProductViewModel Create(Bitmap iconPath, string name, int quantity);
}