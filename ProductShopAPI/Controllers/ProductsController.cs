using Microsoft.AspNetCore.Mvc;
using ProductShopAPI.DAL;
using ProductShopLibrary;

namespace ProductShopAPI.Controllers
{
    [Controller]
    public class ProductsController : Controller
    {
        private readonly ProductsDbContext productsDbContext;
        
        public ProductsController(ProductsDbContext productsDbContext)
        {
            this.productsDbContext = productsDbContext;
        }

        [Route("getProducts")]
        public List<Product> GetProducts()
        {
            return productsDbContext.Products.ToList();
        }
    }
}
