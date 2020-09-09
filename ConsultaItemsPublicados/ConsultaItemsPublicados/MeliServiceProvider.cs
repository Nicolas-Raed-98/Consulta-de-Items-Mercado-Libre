using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsultaItemsPublicados
{
    public class MeliServiceProvider
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<Site> GetSiteInfo(string siteId, string sellerId)
        {
            AddRequestHeaders();

            var url = $"https://api.mercadolibre.com/sites/{siteId}/search?seller_id={sellerId}";

            var streamTask = client.GetStreamAsync(url);
            var siteInfo = await JsonSerializer.DeserializeAsync<Site>(await streamTask);

            return siteInfo;
        }

        public async Task<Category> GetCategories(string categoryId)
        {
            AddRequestHeaders();

            var url = $"https://api.mercadolibre.com/categories/{categoryId}";

            var streamTask = client.GetStreamAsync(url);
            var category = await JsonSerializer.DeserializeAsync<Category>(await streamTask);

            return category;
        }

        private void AddRequestHeaders()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
        }
    }
}
