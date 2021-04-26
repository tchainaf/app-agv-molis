using app_agv_molis.Helpers;
using app_agv_molis.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace app_agv_molis.Services
{
    public class RfidApi : IHttpApi<Rfid>, IHelix<Rfid>
    {
        public async Task<HttpResponseMessage> AddItemAsync(Rfid item)
        {
            try
            {
                return await HttpHelper.PostAsync<Rfid>(item, "/rfid");
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<HttpResponseMessage> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Rfid>> GetAllItemsAsync(bool forceRefresh = false)
        {
            try
            {
                return await HttpHelper.GetAllAsync<Rfid>("/rfid");
            } catch(Exception ex)
            {
                throw ex;
            }
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
            try
            {
                return await HttpHelper.GetAllAsync<string>("/rfid/helix");
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
