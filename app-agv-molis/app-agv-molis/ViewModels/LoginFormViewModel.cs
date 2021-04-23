using app_agv_molis.Models;
using app_agv_molis.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    class LoginFormViewModel: BaseViewModel<User>
    {
        private string email;
        private string password;

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public async Task ExecuteLoginCommand()
        {
            IsBusy = true; 
            try
            {
                await api.LoginAsync(new UserLogin(Email, Password));
                Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send<LoginFormPage, string>(new LoginFormPage(), "ErroLogin", "Erro nas credenciais");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
