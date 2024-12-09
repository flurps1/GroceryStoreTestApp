using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SampleTestApp;

public class ProductServices
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetProductsAsync();
    }

    public class ProductService(HttpClient httpClient) : IProductService
    {
        public async Task<List<ProductModel>> GetProductsAsync()
        {
            var response = await httpClient.GetStringAsync("http://localhost:3000/products");
            return JsonSerializer.Deserialize<List<ProductModel>>(response) ?? throw new InvalidOperationException();
        }
    }
}
public class ProductModel
{
    public string IconPath { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
}