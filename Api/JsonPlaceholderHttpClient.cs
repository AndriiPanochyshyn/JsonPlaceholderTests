using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    public class JsonPlaceholderHttpClient : IRestApi
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

        public async Task<HttpResponseMessage> GetResponseAsync(string url)
        {
            using (var client = new HttpClient())
            {
                return await client.GetAsync(url);
            }
        }

        public async Task<HttpResponseMessage> PostAsync(string url, object content)
        {
            using (var client = new HttpClient())
            {
                var jsonObject = JsonConvert.SerializeObject(content);
                var postContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                return await client.PostAsync(url, postContent);
            }
        }

        public async Task<HttpResponseMessage> PutAsync(string url, object content)
        {
            using (var client = new HttpClient())
            {
                var jsonObject = JsonConvert.SerializeObject(content);
                var putContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                return await client.PutAsync(url, putContent);
            }
        }

        public async Task<HttpResponseMessage> PatchAsync(string url, object content)
        {
            using (var client = new HttpClient())
            {
                var jsonObject = JsonConvert.SerializeObject(content);
                var patchContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                return await client.PatchAsync(url, patchContent);
            }
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            using (var client = new HttpClient())
            {
                return await client.DeleteAsync(url);
            }
        }
    }
}
