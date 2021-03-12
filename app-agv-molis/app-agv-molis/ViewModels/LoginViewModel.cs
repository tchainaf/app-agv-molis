using app_agv_molis.Views;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command GoToLoginFormCommand { get; }
        public Command GoToSignupFormCommand { get; }

        public LoginViewModel()
        {
            GoToLoginFormCommand = new Command(OnGoToLoginFormCommandClicked);
            GoToSignupFormCommand = new Command(OnGoTosignupFormCommandClicked);
        }

        private void OnGoToLoginFormCommandClicked(object obj)
        {
            //await Shell.Current.GoToAsync($"//{nameof(LoginFormPage)}");
            App.Current.MainPage = new LoginFormPage();
        }

        private void OnGoTosignupFormCommandClicked(object obj)
        {
            //await Shell.Current.GoToAsync($"//{nameof(SignupFormPage)}");
            App.Current.MainPage = new SignupFormPage();
        }
    }
}
