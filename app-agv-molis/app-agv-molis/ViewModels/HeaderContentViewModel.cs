using app_agv_molis.Helpers;
using app_agv_molis.Models;
using Xamarin.Essentials;

namespace app_agv_molis.ViewModels
{
    class HeaderContentViewModel : BaseViewModel<User>
    {
        private string userName;
        private string userRole;
        private SqliteHelper<User> _sqliteHelper = new SqliteHelper<User>();

        public async void GetInfoLocalUser()
        {
            var userId = await SecureStorage.GetAsync("userId");
            var userFromDB = await _sqliteHelper.Get((item) => item.Id == userId);
            UserName = userFromDB.Name;
            UserRole = userFromDB.GetRoleNameBy(userFromDB.Role);
        }

        public string UserName { 
            get => userName;
            set => SetProperty(ref userName, value);
        }
        public string UserRole { 
            get => userRole;
            set => SetProperty(ref userRole, value);
        }
    }
}
