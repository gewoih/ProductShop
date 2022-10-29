using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductShopAPI.DAL;
using ProductShopLibrary.Products;

namespace ProductShopAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductsDbContext productsDbContext;
        
        public ProductsController(ProductsDbContext productsDbContext)
        {
            this.productsDbContext = productsDbContext;
        }

        [Route("get_products")]
        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            return await productsDbContext.Products.ToListAsync();
        }

        [Route("get_ending_products")]
        [HttpGet]
        public async Task<List<Product>> GetEndingProducts(int maximumQuantityInStock)
        {
            return await productsDbContext.Products.AsNoTracking().Where(p => p.QuantityInStock <= maximumQuantityInStock).ToListAsync();
        }

        [Route("add_products_stocks")]
        [HttpPost]
        public async Task AddProductsStocks([FromBody] Dictionary<Guid, int> productsToSupply)
        {
            foreach (var product in productsToSupply)
            {
                Product? productToRestock = await productsDbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Key);

                if (productToRestock != null)
                {
                    productToRestock.QuantityInStock += product.Value;

                    productsDbContext.Products.Update(productToRestock);
                }
            }

            await productsDbContext.SaveChangesAsync();
        }
    }
}
