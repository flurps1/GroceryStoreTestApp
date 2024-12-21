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

    public ProductServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7211/");
    }

    public async Task<List<ProductModel>> GetProductsAsync()
    {
        // Очищаем кэш при каждом запросе, так как данные могли измениться
        _cachedProducts = null;
        
        var response = await _httpClient.GetStringAsync("Products");
        _cachedProducts = JsonSerializer.Deserialize<List<ProductModel>>(response)
                          ?? throw new InvalidOperationException();
        return _cachedProducts;
    }

    public async Task<ProductModel> GetProductByIdAsync(int id)
    {
        var response = await _httpClient.GetStringAsync($"Products/{id}");
        return JsonSerializer.Deserialize<ProductModel>(response)
               ?? throw new InvalidOperationException();
    }

    public async Task CreateProductAsync(string name, string iconPath, int quantity)
    {
        var product = new ProductModel
        {
            name = name,
            imageUrl = iconPath,
            quantity = quantity
        };

        var json = JsonSerializer.Serialize(product);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsync("Products", content);
        response.EnsureSuccessStatusCode();
        
        // Очищаем кэш после создания
        _cachedProducts = null;
    }

    public async Task UpdateProductAsync(int id, string newName)
    {
        var response = await _httpClient.PutAsync(
            $"Products/{id}?newName={Uri.EscapeDataString(newName)}", 
            null);
        response.EnsureSuccessStatusCode();
        
        // Очищаем кэш после обновления
        _cachedProducts = null;
    }

    public async Task DeleteProductAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"Products/{id}");
        response.EnsureSuccessStatusCode();
        
        // Очищаем кэш после удаления
        _cachedProducts = null;
    }
}

public class ProductModel
{
    public string imageUrl { get; set; } = string.Empty;
    public string name { get; set; } = string.Empty;
    public int quantity { get; set; }
}