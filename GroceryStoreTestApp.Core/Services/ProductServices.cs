using System.Text.Json;

namespace GroceryStoreTestApp.Core;

public interface IProductService
{
    Task<List<ProductModel>> GetProductsAsync();
    Task<ProductModel> GetProductByIdAsync(int id);
    Task CreateProductAsync(string name, string iconPath, int quantity);
    Task UpdateProductAsync(int id, string newName);
    Task DeleteProductAsync(int id);
}

public class ProductServices : IProductService
{
    private readonly HttpClient _httpClient;
    private List<ProductModel>? _cachedProducts;
    private readonly JsonSerializerOptions _jsonOptions;

    public ProductServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7211/");
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async Task<List<ProductModel>> GetProductsAsync()
    {
        _cachedProducts = null;
        
        var response = await _httpClient.GetStringAsync("Products");
        _cachedProducts = JsonSerializer.Deserialize<List<ProductModel>>(response, _jsonOptions)
                          ?? throw new InvalidOperationException();
        return _cachedProducts;
    }

    public async Task<ProductModel> GetProductByIdAsync(int id)
    {
        var response = await _httpClient.GetStringAsync($"Products/{id}");
        return JsonSerializer.Deserialize<ProductModel>(response, _jsonOptions)
               ?? throw new InvalidOperationException();
    }

    public async Task CreateProductAsync(string name, string iconPath, int quantity)
    {
        var product = new ProductModel
        {
            Name = name,
            ImageUrl = iconPath,
            Quantity = quantity
        };

        var json = JsonSerializer.Serialize(product, _jsonOptions);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsync("Products", content);
        response.EnsureSuccessStatusCode();
        
        _cachedProducts = null;
    }

    public async Task UpdateProductAsync(int id, string newName)
    {
        var response = await _httpClient.PutAsync(
            $"Products/{id}?newName={Uri.EscapeDataString(newName)}", 
            null);
        response.EnsureSuccessStatusCode();
        _cachedProducts = null;
    }

    public async Task DeleteProductAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"Products/{id}");
        response.EnsureSuccessStatusCode();
        _cachedProducts = null;
    }
}

public class ProductModel
{
    public string ImageUrl { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
}