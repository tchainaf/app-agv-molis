using app_agv_molis.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace app_agv_molis.Helpers
{
    public static class HttpHelper
    {
        private static HttpClient _httpClient;
        private static string _apiUrl;
        private static string _token;
        private static HttpClient GetHttpClient()
        {
            _apiUrl = "http://7f930e90d6a0.ngrok.io";
            //_apiUrl = "http://191.234.169.132:3333";
            if (_httpClient == null)
                _httpClient = new HttpClient();
            return _httpClient;
        }

        public static async Task<HttpResponseMessage> PostAsync<T>(object objectToSend, string api = null)
        {
            try
            {
                var client = GetHttpClient();
                _token = await RoleHelper.GetToken();
                if (_token != null)
                {
                    var authHeader = new AuthenticationHeaderValue("bearer", _token);
                    client.DefaultRequestHeaders.Authorization = authHeader;
                }

                Uri uri = new Uri(string.Format(MountApiUrl(api), string.Empty));

                string json = JsonConvert.SerializeObject(objectToSend);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                return await client.PostAsync(uri, content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
                throw ex;
            }
        }

        public static async Task<List<T>> GetAllAsync<T>(string api = null)
        {
            try
            {
                var client = GetHttpClient();
                _token = await RoleHelper.GetToken();
                if (_token != null)
                {
                    var authHeader = new AuthenticationHeaderValue("bearer", _token);
                    client.DefaultRequestHeaders.Authorization = authHeader;
                }

                Uri uri = new Uri(string.Format(MountApiUrl(api), string.Empty));
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<T>>(content);
                }
                return new List<T>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
                throw ex;
            }
        }

        internal static string MountApiUrl(string api = null)
        {
            if (api == null)
            {
                return _apiUrl;
            }
            else
            {
                return _apiUrl + api;
            }
        }

        internal static async Task<T> GetContentFromResultAsync<T>(HttpResponseMessage result)
        {
            T retorno = default(T);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<T>(content);
            } else
            {
                var responseForInvalidStatusCode = await result.Content.ReadAsStringAsync();
                throw new Exception(JsonConvert.DeserializeObject<ErrorResponse>(responseForInvalidStatusCode).Message);
            }
            return retorno;
        }
    }
}