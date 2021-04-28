using app_agv_molis.Helpers;
using app_agv_molis.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace app_agv_molis.Services
{
    class UserApi : IHttpApi<User>
    {

        public async Task<User> AddItemAsync(User item)
        {
            try
            {
                var result = await HttpHelper.PostAsync<User>(item, "/user");
                return await HttpHelper.GetContentFromResultAsync<User>(result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
        }

        public Task<HttpResponseMessage> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetAllFromHelixAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllItemsAsync(bool forceRefresh = false)
        {
            try
            {
                return await HttpHelper.GetAllAsync<User>("/users");
            } 
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<User> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> UpdateItemAsync(User item)
        {
            throw new NotImplementedException();
        }

        public async Task<UserLoginResponse> LoginAsync(UserLogin userLogin)
        {
            try
            {
                var result = await HttpHelper.PostAsync<object>(userLogin, "/login");
                return await HttpHelper.GetContentFromResultAsync<UserLoginResponse>(result);            
            } catch(Exception ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
        }
    }
}
