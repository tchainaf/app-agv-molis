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
        public async static Task<string> GetUserRole()
        {
            return await SecureStorage.GetAsync("userRole");
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
        public async static Task SetUserRole(string role)
        {
            await SecureStorage.SetAsync("userRole", role);
        }
        public static void RemoveToken()
        {
            SecureStorage.Remove("token");
        }
        public static void RemoveUserName()
        {
            SecureStorage.Remove("userName");
        }
        public static void RemoveUserRole()
        {
            SecureStorage.Remove("userRole");
        }
        public static void RemoveUserId()
        {
            SecureStorage.Remove("userId");
        }
    }
}
