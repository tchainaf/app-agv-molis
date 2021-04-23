using app_agv_molis.Helpers;
using app_agv_molis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace app_agv_molis.Services
{
    class UserApi : IHttpApi<User>
    {
        private const string API_BASE_URL = "http://7a0780ee90c7.ngrok.io";
        public UserApi()
        {
            HttpHelper.SetApiUrl(API_BASE_URL);
        }

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

        public Task<IEnumerable<User>> GetAllItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
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
