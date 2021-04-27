using app_agv_molis.Services;
using app_agv_molis.Views;
using Xamarin.Essentials;
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
            var _token = SecureStorage.GetAsync("token").Result;
            if (_token != null)
            {
                MainPage = new AppShell();
            } 
            else
            {
                MainPage = new LoginPage();
            }
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
