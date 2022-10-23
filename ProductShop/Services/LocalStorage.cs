using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace ProductShop.Services
{
    public class LocalStorage
    {
        private readonly IJSRuntime jsRuntime;

        public LocalStorage(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task SetAsync<T>(string key, T value)
        {
            string jsValue = null;
            if (value != null)
                jsValue = JsonConvert.SerializeObject(value);
            
            await jsRuntime.InvokeVoidAsync("localStorage.setItem", new object[] { key, jsValue });
        }
        
        public async Task<T> GetAsync<T>(string key)
        {
            string value = await jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
            if (value == null)
                return default;
            
            return JsonConvert.DeserializeObject<T>(value);
        }

        public async Task RemoveAsync(string key)
        {
            await jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }
        
        public async Task ClearAsync()
        {
            await jsRuntime.InvokeVoidAsync("localStorage.clear");
        }
    }
}
