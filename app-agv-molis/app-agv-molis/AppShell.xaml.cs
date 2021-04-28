using app_agv_molis.Helpers;
using app_agv_molis.Views;
using System;
using Xamarin.Forms;

namespace app_agv_molis
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewAgvPage), typeof(NewAgvPage));
            Routing.RegisterRoute(nameof(NewRfidPage), typeof(NewRfidPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

            var token = RoleHelper.GetToken().Result;
            if (token != null)
            {
                this.Navigation.PushModalAsync(new LoginPage());
            }
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            RoleHelper.RemoveToken();
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
