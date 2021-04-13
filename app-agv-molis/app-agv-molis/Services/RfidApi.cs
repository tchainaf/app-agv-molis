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
        private const string API_BASE_URL = "http://192.168.0.109:3333/rfid"; 
        public RfidApi()
        {
            HttpHelper.SetApiUrl(API_BASE_URL);
        }

        public async Task<HttpResponseMessage> AddItemAsync(Rfid item)
        {
            return await HttpHelper.PostAsync<Rfid>(item);
        }

        public Task<HttpResponseMessage> DeleteItemAsync(string id)
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

        public Task<HttpResponseMessage> UpdateItemAsync(Rfid item)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<string>> IHttpApi<Rfid>.GetAllFromHelixAsync()
        {
            return await HttpHelper.GetAllAsync<string>("/helix");
        }
    }
}
