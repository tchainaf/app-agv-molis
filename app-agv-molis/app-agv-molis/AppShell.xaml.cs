using app_agv_molis.Helpers;
using app_agv_molis.Models;
using app_agv_molis.ViewModels;
using app_agv_molis.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace app_agv_molis 
{
    public partial class AppShell : Shell
    {
        private SqliteHelper<User> _sqliteHelper = new SqliteHelper<User>();
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewAgvPage), typeof(NewAgvPage));
            Routing.RegisterRoute(nameof(NewRfidPage), typeof(NewRfidPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            var token = RoleHelper.GetToken().Result;
            if (token == null)
            {
                Application.Current.MainPage = new LoginPage();
                Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
            }
            GetInfoLocalUser().ConfigureAwait(true);
        }

        private async Task GetInfoLocalUser()
        {
            try
            {
                var userId = await RoleHelper.GetUserId();
                var userFromDB = await _sqliteHelper.Get((item) => item.Id == userId);
                if (userFromDB != null)
                {
                    await RoleHelper.SetUserName(userFromDB.Name);
                    await RoleHelper.SetUserEmail(userFromDB.Email.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            var userId = await RoleHelper.GetUserId();
            RoleHelper.RemoveToken();
            RoleHelper.RemoveUserId();
            RoleHelper.RemoveUserEmail();
            RoleHelper.RemoveUserName();
            await RoleHelper.RemoveAllZones() ;
            await _sqliteHelper.Delete((u) => u.Id == userId);
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
