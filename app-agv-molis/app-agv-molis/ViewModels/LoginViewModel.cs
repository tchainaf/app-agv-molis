using app_agv_molis.Views;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    public class LoginViewModel : BaseViewModel<string>
    {
        public Command GoToLoginFormCommand { get; }
        public Command GoToSignupFormCommand { get; }

        public LoginViewModel()
        {
            GoToLoginFormCommand = new Command(OnGoToLoginFormCommandClicked);
            GoToSignupFormCommand = new Command(OnGoTosignupFormCommandClicked);
        }

        private async void OnGoToLoginFormCommandClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginFormPage)}");
        }

        private async void OnGoTosignupFormCommandClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(SignupFormPage)}");
        }
    }
}
