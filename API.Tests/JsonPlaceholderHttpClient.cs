using System.Net.Http;
using System.Threading.Tasks;

namespace API.Tests
{
    public class JsonPlaceholderHttpClient
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<T> GetAsync<T>(string path) where T : new()
        {
            var obj = default(T);
            var response = await client.GetAsync(path);
            return obj;
        }
    }
}
