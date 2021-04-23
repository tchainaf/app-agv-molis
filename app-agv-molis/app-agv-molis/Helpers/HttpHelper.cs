using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace app_agv_molis.Helpers
{
    public static class HttpHelper
    {
        private static HttpClient _httpClient;
        private static string _apiUrl = "http://191.234.169.132:3333";
        private static JsonSerializerOptions _serializerOptions;
        private static string _token;
        private static HttpClient GetHttpClient()
        {
            //_apiUrl = "http://74cf41d54d8f.ngrok.io";
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            if (_httpClient == null)
                _httpClient = new HttpClient();
            return _httpClient;
        }

        public static async Task<HttpResponseMessage> PostAsync<T>(object objectToSend, string api = null)
        {
            try
            {
                var client = GetHttpClient();
                _token = await SecureStorage.GetAsync("token");
                if (_token != null)
                {
                    var authHeader = new AuthenticationHeaderValue("bearer", _token);
                    client.DefaultRequestHeaders.Authorization = authHeader;
                }

                Uri uri = new Uri(string.Format(MountApiUrl(api), string.Empty));

                string json = JsonSerializer.Serialize((T)objectToSend, _serializerOptions);
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
                    return JsonSerializer.Deserialize<List<T>>(content, _serializerOptions);
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
            }
            return retorno;
        }
    }
}