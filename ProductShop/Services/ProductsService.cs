using Newtonsoft.Json;
using ProductShopLibrary.Products;

namespace ProductShop.Services
{
    public class ProductsService
    {
        public List<Product> GetAllProducts()
        {
            using (HttpClient client = new HttpClient())
            {
                List<Product> products;
                
                string response = client.GetStringAsync("https://localhost:7019/api/Products/get_products").Result;
                products = JsonConvert.DeserializeObject<List<Product>>(response);

                return products;
            }
        }
    }
}
