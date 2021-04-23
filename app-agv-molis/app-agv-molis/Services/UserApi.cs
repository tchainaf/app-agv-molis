using app_agv_molis.Helpers;
using app_agv_molis.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace app_agv_molis.Services
{
    class UserApi : IHttpApi<User>
    {
        public Task<HttpResponseMessage> AddItemAsync(User item)
        {
            throw new NotImplementedException();
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
            return await HttpHelper.GetAllAsync<User>("/users");
        }

        public Task<User> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> UpdateItemAsync(User item)
        {
            throw new NotImplementedException();
        }

        public async Task LoginAsync(object userLogin)
        {
            var result = await HttpHelper.PostAsync<object>(userLogin, "/login");
            var response = await HttpHelper.GetContentFromResultAsync<UserLoginResponse>(result);
            await SecureStorage.SetAsync("token", response.Token);
        }
    }
}
