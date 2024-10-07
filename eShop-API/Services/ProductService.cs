using eShop_API.Data;
using eShop_API.Helpers;
using eShop_API.Interfaces;
using eShop_API.Models;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.IdentityModel.Tokens;

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

        public async Task AddProduct(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int productId)
        {
            if (_context.Product == null)
            {
                throw new Exception("Item not found");
            }
            var product = await _context.Product.FindAsync(productId);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    throw new Exception("Item not found");
                }
                else
                {
                    throw;
                }
            }
        }

        private bool ProductExists(int id)
        {
            return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
