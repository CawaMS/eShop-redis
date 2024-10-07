using eShop_API.Data;
using eShop_API.Interfaces;
using eShop_API.Models;
using Microsoft.Extensions.Caching.Hybrid;

namespace eShop_API.Services
{
    public class ProductService : IProductService
    {
        private readonly eShopContext _context;
        //private readonly HybridCache _cache;

        // public ProductService(eShopContext context, HybridCache cache)
        public ProductService(eShopContext context)
        {  
            _context = context;
            //_cache = cache;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            if (_context.Product == null) throw new Exception("Entity set 'eShopContext.Product'  is null.");

            return await Task.Run(() => _context.Product.ToList());
            //return await _cache.GetOrCreateAsync("AllProducts", async entry =>
            //{
            //    //entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            //    return await Task.Run(() => _context.Product.ToList());
            //});
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            var product = await Task.Run(() => _context.Product.Where(product => product.Id == productId).FirstOrDefault());

            return product;
            
        }

    }
}
