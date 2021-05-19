using System;
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
        public async static Task<string> GetUserName()
        {
            return await SecureStorage.GetAsync("userName");
        }
        public async static Task<string> GetUserEmail()
        {
            return await SecureStorage.GetAsync("userEmail");
        }
        public async static Task SetToken(string token)
        {
            await SecureStorage.SetAsync("token", token);
        }
        public async static Task SetUserId(string token)
        {
            await SecureStorage.SetAsync("userId", token);
        }
        public async static Task SetUserName(string name)
        {
            await SecureStorage.SetAsync("userName", name);
        }
        public async static Task SetUserEmail(string role)
        {
            await SecureStorage.SetAsync("userEmail", role);
        }
        public static void RemoveToken()
        {
            SecureStorage.Remove("token");
        }
        public static void RemoveUserName()
        {
            SecureStorage.Remove("userName");
        }
        public static void RemoveUserEmail()
        {
            SecureStorage.Remove("userEmail");
        }
        public static void RemoveUserId()
        {
            SecureStorage.Remove("userId");
        }

        public static async Task RemoveAllZones()
        {
            var length = await SecureStorage.GetAsync("zone-length");
            for (var i = 1; i < Int32.Parse(length); i++)
            {
                SecureStorage.Remove($"zone-{i}");
            }

            SecureStorage.Remove("zone-length");
        }
    }
}
