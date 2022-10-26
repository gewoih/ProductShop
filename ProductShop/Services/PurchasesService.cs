using Newtonsoft.Json;
using ProductShopLibrary.Purchases;
using System.Net;
using System.Text;

namespace ProductShop.Services
{
    public class PurchasesService
    {
        public async Task<bool> TrySubmitPurchase(Purchase purchase)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(purchase), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7019/api/Purchases/create_purchase", content);
                
                if (response.IsSuccessStatusCode)
                    return true;
                    
                return false;
            }
        }
    }
}
