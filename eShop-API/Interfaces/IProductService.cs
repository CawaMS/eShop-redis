using eShop_API.Models;
namespace eShop_API.Interfaces;

public interface IProductService
{
    Task<Product?> GetProductByIdAsync(int productId);
    Task<List<Product>> GetAllProductsAsync();
}
