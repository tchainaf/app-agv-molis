using app_agv_molis.Helpers;
using app_agv_molis.Services;
using app_agv_molis.ViewModels;
using app_agv_molis.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace app_agv_molis
{
    public partial class App : Application
    {
        public DashViewModel dashViewModel;

        public App()
        {
            dashViewModel = new DashViewModel();
            Task.Run(async () => await dashViewModel.ExecuteLoadZonesCommand());
            DependencyService.Register<RfidApi>();
            DependencyService.Register<UserApi>();
            DependencyService.Register<ZoneApi>();
            InitializeComponent();
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
