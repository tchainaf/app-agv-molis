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
        private const string API_BASE_URL = "http://10.0.2.2:3333/rfid";
        public RfidApi()
        {
            HttpHelper.SetApiUrl(API_BASE_URL);
        }

        public Task<bool> AddItemAsync(Rfid item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
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

        public async Task<ObservableCollection<string>> GetAllFromHelix()
        {
            var result = await HttpHelper.CallApi(HttpMethod.Get, "/helix");
            return await HttpHelper.GetContentFromResultAsync<ObservableCollection<string>>(result);

        }
    }
}
