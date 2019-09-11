using System.Net.Http;
using System.Threading.Tasks;

namespace API.Tests
{
    public class JsonPlaceholderHttpClient
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task<T> GetAsync<T>(string path) where T : new()
        {
            var obj = default(T);
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
                obj = await response.Content.ReadAsStringAsync<T>();
            return obj;
        }
    }
}
