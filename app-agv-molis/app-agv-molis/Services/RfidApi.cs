﻿using app_agv_molis.Helpers;
using app_agv_molis.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace app_agv_molis.Services
{
    public class RfidApi : IHttpApi<Rfid>
    {
        public async Task<Rfid> AddItemAsync(Rfid item)
        {
            try
            {
                var result = await HttpHelper.PostAsync<Rfid>(item, "/rfid");
                return await HttpHelper.GetContentFromResultAsync<Rfid>(result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
        }

        public async Task DeleteItemAsync(string id)
        {
            try
            {
                await HttpHelper.DeleteAsync<Rfid>(id, "/rfid");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
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
    }
}
