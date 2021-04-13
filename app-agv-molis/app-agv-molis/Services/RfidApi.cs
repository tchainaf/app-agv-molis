using app_agv_molis.Helpers;
using app_agv_molis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace app_agv_molis.Services
{
    public class RfidApi : IHttpApi<Rfid>
    {
<<<<<<< HEAD
        private const string API_BASE_URL = "http://192.168.0.109:3333/rfid"; 
=======
        private const string API_BASE_URL = "http://10.0.2.2:3333/rfid";
>>>>>>> ae0f7715e145ecb43f68dfcf2e4a9609b0cbc354
        public RfidApi()
        {
            HttpHelper.SetApiUrl(API_BASE_URL);
        }

<<<<<<< HEAD
        public async Task<HttpResponseMessage> AddItemAsync(Rfid item)
        {
            return await HttpHelper.PostAsync<Rfid>(item);
        }

        public Task<HttpResponseMessage> DeleteItemAsync(string id)
=======
        public Task<bool> AddItemAsync(Rfid item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
>>>>>>> ae0f7715e145ecb43f68dfcf2e4a9609b0cbc354
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Rfid>> GetAllItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<Rfid> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
        public Task<HttpResponseMessage> UpdateItemAsync(Rfid item)
=======
        public Task<bool> UpdateItemAsync(Rfid item)
>>>>>>> ae0f7715e145ecb43f68dfcf2e4a9609b0cbc354
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
        async Task<IEnumerable<string>> IHttpApi<Rfid>.GetAllFromHelixAsync()
        {
            return await HttpHelper.GetAllAsync<string>("/helix");
=======
        public async Task<ObservableCollection<string>> GetAllFromHelix()
        {
            var result = await HttpHelper.CallApi(HttpMethod.Get, "/helix");
            return await HttpHelper.GetContentFromResultAsync<ObservableCollection<string>>(result);

>>>>>>> ae0f7715e145ecb43f68dfcf2e4a9609b0cbc354
        }
    }
}
