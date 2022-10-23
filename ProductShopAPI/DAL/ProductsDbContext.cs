using Microsoft.EntityFrameworkCore;
using ProductShopLibrary.Products;

namespace ProductShopAPI.DAL
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
        }
    }
}
