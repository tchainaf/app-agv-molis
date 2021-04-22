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

        public LoginFormViewModel()
        {
            CancelCommand = new Command(OnCancel);
        }

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

        public Command CancelCommand { get; }

        private void OnCancel()
        {
            // This will pop the current page off the navigation stack
            //await Shell.Current.GoToAsync("..");
            //App.Current.MainPage = new NavigationPage(new LoginPage());
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
