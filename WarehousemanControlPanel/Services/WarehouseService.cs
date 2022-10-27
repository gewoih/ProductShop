using Newtonsoft.Json;
using ProductShopLibrary.Products;

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

        private void UpdateWorker()
        {
            while (true)
            {
                List<Product> newEndingProducts = GetEndingProducts();

                foreach (Product product in newEndingProducts)
                {
                    Product? updatedProduct = EndingProducts.FirstOrDefault(p => p.Id == product.Id);

                    if (updatedProduct != null)
                    {
                        if (updatedProduct.QuantityInStock != product.QuantityInStock)
                            OnEndingProductsUpdated?.Invoke();
                    }
                    else
                        OnEndingProductsUpdated?.Invoke();
                }

                EndingProducts = newEndingProducts;

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
