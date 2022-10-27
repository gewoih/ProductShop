using Newtonsoft.Json;
using ProductShopLibrary.Products;

namespace SupplierControlPanel.Services
{
    public class WarehouseService
    {
        public List<Product> EndingProducts;
        public Action OnEndingProductsUpdated;
        private bool IsServiceStarted;

        public WarehouseService()
        {
            EndingProducts = new List<Product>();
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
                using (HttpClient client = new HttpClient() { Timeout = TimeSpan.FromSeconds(1000) })
                {
                    string response = client.GetStringAsync("https://localhost:7019/api/Products/get_products").Result;
                    EndingProducts = JsonConvert.DeserializeObject<List<Product>>(response);

                    OnEndingProductsUpdated?.Invoke();
                }

                Thread.Sleep(5000);
            }
        }
    }
}
