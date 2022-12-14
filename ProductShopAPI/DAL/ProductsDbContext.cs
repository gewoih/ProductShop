using Microsoft.EntityFrameworkCore;
using ProductShopLibrary.Products;
using ProductShopLibrary.Purchases;

namespace ProductShopAPI.DAL
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CustomerInfo> CustomerInfos { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
        }
    }
}
