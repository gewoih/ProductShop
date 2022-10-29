using Newtonsoft.Json;
using ProductShopLibrary.Products;
using ProductShopLibrary.Purchases;
using System.Text;

namespace WarehousemanControlPanel.Services
{
    public class WarehouseService
    {
        public List<Product> EndingProducts;
        public Action OnEndingProductsUpdated;
        private bool IsServiceStarted;

        public WarehouseService()
        {
            EndingProducts = GetEndingProducts();
            IsServiceStarted = false;
        }

        public void StartUpdatingStocks()
        {
            if (IsServiceStarted)
                return;

            Thread workerThread = new Thread(() => UpdateWorker());
            workerThread.Start();
            IsServiceStarted = true;
        }

        public async Task<bool> CreateSupply(Dictionary<Guid, int> productsToSupply)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(productsToSupply), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7019/api/Products/add_products_stocks", content);

                if (response.IsSuccessStatusCode)
                    return true;

                return false;
            }
        }

        private void UpdateWorker()
        {
            while (true)
            {
                List<Product> newEndingProducts = GetEndingProducts();
                bool isUpdated = false;

                foreach (Product product in newEndingProducts)
                {
                    Product? updatedProduct = EndingProducts.FirstOrDefault(p => p.Id == product.Id);

                    if (updatedProduct != null)
                    {
                        if (updatedProduct.QuantityInStock != product.QuantityInStock)
                            isUpdated = true;
                    }
                    else
                        isUpdated = true;
                }

                if (EndingProducts.Count != newEndingProducts.Count)
                    isUpdated = true;

                EndingProducts = newEndingProducts;

                if (isUpdated)
                    OnEndingProductsUpdated?.Invoke();

                Thread.Sleep(5000);
            }
        }

        private List<Product> GetEndingProducts()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = client.GetStringAsync("https://localhost:7019/api/Products/get_ending_products?maximumQuantityInStock=10").Result;
                return JsonConvert.DeserializeObject<List<Product>>(response);
            }
        }
    }
}
