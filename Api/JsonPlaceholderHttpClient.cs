using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    public class JsonPlaceholderHttpClient
    {
        public async Task<T> GetAsync<T>(string url)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(responseBody);
                }
            }
        }

        public async Task<byte[]> GetByteAsync(string url)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsByteArrayAsync();
                }
            }
        }
    }
}
