using System.Text.Json;

namespace SampleTestApp.Core;

public interface IProductService
{
    Task<List<ProductModel>> GetProductsAsync();
}

public class ProductServices : IProductService
{
    private readonly HttpClient _httpClient;
    private List<ProductModel>? _cachedProducts;

    public ProductServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProductModel>> GetProductsAsync()
    {
        if (_cachedProducts != null)
            return _cachedProducts;

        var response = await _httpClient.GetStringAsync("http://localhost:3000/products");
        _cachedProducts = JsonSerializer.Deserialize<List<ProductModel>>(response)
                          ?? throw new InvalidOperationException();
        return _cachedProducts;
    }
}

public class ProductModel
{
    public string IconPath { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
}