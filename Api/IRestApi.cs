using System.Net.Http;
using System.Threading.Tasks;

namespace Api
{
    public interface IRestApi
    {
        Task<T> GetAsync<T>(string url);
        Task<byte[]> GetByteAsync(string url);

        Task<HttpResponseMessage> GetResponseAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, object content);
        Task<HttpResponseMessage> PutAsync(string url, object content);
        Task<HttpResponseMessage> PatchAsync(string url, object content);
        Task<HttpResponseMessage> DeleteAsync(string url);
    }
}
