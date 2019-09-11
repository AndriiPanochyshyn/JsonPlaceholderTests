using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api
{
    public static class Extensions
    {
        public static byte[] GetBytes(this Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, string url, HttpContent content)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, url)
            {
                Content = content
            };

            return await client.SendAsync(request);
        }
    }
}
