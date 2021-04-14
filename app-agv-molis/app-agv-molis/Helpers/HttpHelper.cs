using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace app_agv_molis.Helpers
{
    public static class HttpHelper
    {
        private static HttpClient _httpClient;
        private static string _apiUrl;
        private static JsonSerializerOptions serializerOptions;
        private static HttpClient GetHttpClient()
        {
            serializerOptions = new JsonSerializerOptions
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
                Uri uri = new Uri(string.Format(MountApiUrl(api), string.Empty));

                string json = JsonSerializer.Serialize((T)objectToSend, serializerOptions);
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
                Uri uri = new Uri(string.Format(MountApiUrl(api), string.Empty));
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<T>>(content, serializerOptions);
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
            } else
            {
                return _apiUrl + api;
            }
        }

        internal static void SetApiUrl(string apiUrl)
        {
            _apiUrl = apiUrl;
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