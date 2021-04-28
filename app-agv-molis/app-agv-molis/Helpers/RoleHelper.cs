using System.Threading.Tasks;
using Xamarin.Essentials;

namespace app_agv_molis.Helpers
{
    public static class RoleHelper
    {
        public async static Task<string> GetToken()
        {
            return await SecureStorage.GetAsync("token");
        }
        public async static Task<string> GetUserId()
        {
            return await SecureStorage.GetAsync("userId");
        }
        public async static Task SetToken(string token)
        {
            await SecureStorage.SetAsync("token", token);
        }
        public async static Task SetUserId(string token)
        {
            await SecureStorage.SetAsync("userId", token);
        }
        public static void RemoveToken()
        {
            SecureStorage.Remove("token");
        }
    }
}
