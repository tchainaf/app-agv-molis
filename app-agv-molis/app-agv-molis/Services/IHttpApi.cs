using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace app_agv_molis.Services
{
    public interface IHttpApi<T>
    {
        Task<HttpResponseMessage> AddItemAsync(T item);
        Task<HttpResponseMessage> UpdateItemAsync(T item);
        Task<HttpResponseMessage> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetAllItemsAsync(bool forceRefresh = false);
    }
}
