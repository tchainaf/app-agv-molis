using System.Collections.Generic;
<<<<<<< HEAD
using System.Net.Http;
=======
>>>>>>> ae0f7715e145ecb43f68dfcf2e4a9609b0cbc354
using System.Threading.Tasks;

namespace app_agv_molis.Services
{
    public interface IHttpApi<T>
    {
<<<<<<< HEAD
        Task<HttpResponseMessage> AddItemAsync(T item);
        Task<HttpResponseMessage> UpdateItemAsync(T item);
        Task<HttpResponseMessage> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetAllItemsAsync(bool forceRefresh = false);
        Task<IEnumerable<string>> GetAllFromHelixAsync();
=======
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetAllItemsAsync(bool forceRefresh = false);
>>>>>>> ae0f7715e145ecb43f68dfcf2e4a9609b0cbc354
    }
}
