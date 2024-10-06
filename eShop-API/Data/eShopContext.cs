using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eShop_API.Models;

namespace eShop_API.Data
{
    public class eShopContext : DbContext
    {
        public eShopContext (DbContextOptions<eShopContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<CartItem> cartItems { get; set; } = default!;
        public DbSet<Cart> carts { get; set; } = default!;
    }
}
