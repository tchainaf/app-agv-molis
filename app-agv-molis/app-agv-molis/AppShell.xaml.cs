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

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
            await Shell.Current.GoToAsync("//login");
        }
    }
}
