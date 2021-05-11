using app_agv_molis.Helpers;
using app_agv_molis.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace app_agv_molis.Services
{
    class AgvApi : IHttpApi<Agv>, IHelix<Agv>
    {
        public async Task<Agv> AddItemAsync(Agv item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string>> GetAllFromHelixAsync()
        {
            try
            {
                return await HttpHelper.GetAllAsync<string>("/agv/helix");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Agv>> GetAllItemsAsync(bool forceRefresh = false)
        {
            try
            {
                return await HttpHelper.GetAllAsync<Agv>("/agv");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Agv> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> UpdateItemAsync(Agv item)
        {
            throw new NotImplementedException();
        }
    }
}
