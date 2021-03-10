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

        private async void OnGoToLoginFormCommandClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(LoginFormPage)}");
        }

        private async void OnGoTosignupFormCommandClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(SignupFormPage)}");
        }
    }
}
