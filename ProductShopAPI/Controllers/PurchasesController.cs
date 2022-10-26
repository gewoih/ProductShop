using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductShopAPI.DAL;
using ProductShopLibrary.Products;
using ProductShopLibrary.Purchases;

namespace ProductShopAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class PurchasesController : Controller
    {
        private readonly ProductsDbContext productsDbContext;

        public PurchasesController(ProductsDbContext productsDbContext)
        {
            this.productsDbContext = productsDbContext;
        }

        [HttpPost]
        [Route("create_purchase")]
        public async Task<IActionResult> CreatePurchase([FromBody] Purchase purchase)
        {
            if (await ValidateProductsStock(purchase.ProductCart.Products))
            {
                foreach (var x in purchase.ProductCart.Products)
                {
                    productsDbContext.Attach(x.Product);
                }

                await productsDbContext.Purchases.AddAsync(purchase);
                await productsDbContext.SaveChangesAsync();

                await UpdateProductsStocksByPurchase(purchase);

                return Ok();
            }

            return BadRequest("Not enough products in stock!");
        }

        private async Task<bool> ValidateProductsStock(List<CartProduct> cartProducts)
        {
            foreach (CartProduct cartProduct in cartProducts)
            {
                Product? purchasedProduct = await productsDbContext.Products.FirstOrDefaultAsync(p => p.Id == cartProduct.Product.Id);

                if (purchasedProduct != null)
                    productsDbContext.Entry(purchasedProduct).State = EntityState.Detached;

                if (purchasedProduct == null || purchasedProduct.QuantityInStock < cartProduct.Quantity)
                    return false;
            }

            return true;
        }

        private async Task UpdateProductsStocksByPurchase(Purchase purchase)
        {
            foreach (CartProduct cartProduct in purchase.ProductCart.Products)
            {
                Product? purchasedProduct = await productsDbContext.Products.FirstOrDefaultAsync(p => p.Id == cartProduct.Product.Id);

                if (purchasedProduct != null)
                {
                    productsDbContext.Entry(purchasedProduct).State = EntityState.Detached;
                    purchasedProduct.QuantityInStock -= cartProduct.Quantity;
                    productsDbContext.Products.Update(purchasedProduct);
                }
            }

            await productsDbContext.SaveChangesAsync();
        }
    }
}
