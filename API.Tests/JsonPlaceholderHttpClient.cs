using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Tests
{
    public class JsonPlaceholderHttpClient
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<TJsonObject>> GetAsync<TJsonObject>(string path)
        {
            var response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<TJsonObject>>(responseBody);
        }
    }
}
