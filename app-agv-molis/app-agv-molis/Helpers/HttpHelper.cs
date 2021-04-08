using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace app_agv_molis.Helpers
{
    public static class HttpHelper
    {
        private static HttpClient _httpClient;
        private static string _apiUrl;

        private static HttpClient GetHttpClient()
        {
            if (_httpClient == null)
                _httpClient = new HttpClient();
            return _httpClient;
        }

        public static async Task<HttpResponseMessage> CallApi(HttpMethod method, string api = null, object objectToSend = null)
        {
            try
            {
                using (var client = GetHttpClient())
                {
                    client.Timeout = new TimeSpan(0, 0, 5);
                    HttpRequestMessage request = new HttpRequestMessage(method, MountApiUrl(api));
                    if (objectToSend != null)
                    {
                        string contentToSend = JsonConvert.SerializeObject(objectToSend);
                        request.Content = new StringContent(contentToSend, Encoding.UTF8, "application/json");
                    }
                    return await client.SendAsync(request);
                }

            } 
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
                return null;
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
