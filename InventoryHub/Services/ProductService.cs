using System.Net.Http.Json;
using InventoryHub.Models;

namespace InventoryHub.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<List<Product>>("api/products")
                ?? new List<Product>();
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await _httpClient
                .GetFromJsonAsync<Product>($"api/products/{id}");
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            var response = await _httpClient
                .PostAsJsonAsync("api/products", product);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var response = await _httpClient
                .PutAsJsonAsync(
                    $"api/products/{product.Id}",
                    product);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var response = await _httpClient
                .DeleteAsync($"api/products/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}