namespace SampleTestApp;

public class ProductViewModelFactory : IProductViewModelFactory
{
    public ProductViewModel Create(string iconPath, string name, int quantity)
    {
        return new ProductViewModel(iconPath, name, quantity);
    }
}

public interface IProductViewModelFactory
{
    ProductViewModel Create(string iconPath, string name, int quantity);
}