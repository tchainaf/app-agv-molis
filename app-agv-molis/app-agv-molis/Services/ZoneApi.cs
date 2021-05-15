using app_agv_molis.Helpers;
using app_agv_molis.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace app_agv_molis.Services
{
    public class ZoneApi : IHttpApi<Zone>
    {
        public Task<Zone> AddItemAsync(Zone item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Zone>> GetAllItemsAsync(bool forceRefresh = false)
        {
            try
            {
                return await HttpHelper.GetAllAsync<Zone>("/zone");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Zone> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> UpdateItemAsync(Zone item)
        {
            throw new NotImplementedException();
        }
    }
}
