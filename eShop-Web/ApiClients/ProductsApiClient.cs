using eShop_Web.ViewModels;

namespace eShop_Web.ApiClients
{
    public class ProductsApiClient (HttpClient httpClient)
    {
        public async Task<List<Product>> GetAllProductsAsync()
        {
            var response = await httpClient.GetAsync("api/Products");
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            return products;
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(string category)
        {
            var response = await httpClient.GetAsync($"api/Products/Category/{category}");
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            return products;
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            var response = await httpClient.GetAsync($"api/Products/{productId}");
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadFromJsonAsync<Product>();
            return product;
        }
        public async Task AddProduct(Product product)
        {
            var response = await httpClient.PostAsJsonAsync("api/Products", product);
            response.EnsureSuccessStatusCode();
        }
        public async Task UpdateProduct(Product product)
        {
            var response = await httpClient.PutAsJsonAsync($"api/Products/{product.Id}", product);
            response.EnsureSuccessStatusCode();
        }
        public async Task DeleteProduct(int productId)
        {
            var response = await httpClient.DeleteAsync($"api/Products/{productId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
