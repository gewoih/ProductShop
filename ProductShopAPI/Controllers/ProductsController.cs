using Microsoft.AspNetCore.Mvc;
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
        public List<Product> GetProducts()
        {
            return productsDbContext.Products.ToList();
        }
    }
}
