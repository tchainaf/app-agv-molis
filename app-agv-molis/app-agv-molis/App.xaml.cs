using app_agv_molis.Helpers;
using app_agv_molis.Services;
using app_agv_molis.Views;
using System;
using Xamarin.Forms;

namespace app_agv_molis
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<RfidApi>();
            DependencyService.Register<UserApi>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
