using app_agv_molis.Helpers;
using app_agv_molis.Views;
using System;
using Xamarin.Essentials;
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
        }

        private void OnMenuItemClicked(object sender, EventArgs e)
        {
            RoleHelper.RemoveToken();
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
