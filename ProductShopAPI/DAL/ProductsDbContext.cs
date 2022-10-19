using Microsoft.EntityFrameworkCore;
using ProductShopLibrary;

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
