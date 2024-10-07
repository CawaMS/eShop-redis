﻿using eShop_API.Models;
namespace eShop_API.Interfaces;

public interface IProductService
{
    Task<Product?> GetProductByIdAsync(int productId);
    Task<List<Product>> GetAllProductsAsync();
    Task AddProduct(Product product);
    Task UpdateProduct(Product product);
    Task DeleteProduct(int productId);
}
