using app_agv_molis.Helpers;
using app_agv_molis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace app_agv_molis.Services
{
    public class RfidApi : IHttpApi<Rfid>
    {
        public async Task<HttpResponseMessage> AddItemAsync(Rfid item)
        {
            return await HttpHelper.PostAsync<Rfid>(item, null);
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
        public Task<bool> UpdateItemAsync(Rfid item)
        {
            throw new NotImplementedException();
        }

        Task<HttpResponseMessage> IHttpApi<Rfid>.UpdateItemAsync(Rfid item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string>> GetAllFromHelixAsync()
        {
            return await HttpHelper.GetAllAsync<string>("/helix");
        }

        public Task LoginAsync(object userLogin)
        {
            throw new NotImplementedException();
        }
    }
}
