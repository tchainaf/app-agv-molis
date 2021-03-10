using app_agv_molis.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    class SignupFormViewModel : BaseViewModel
    {
        public Command GoToSignupFormCommand { get; }

        public SignupFormViewModel()
        {
            GoToSignupFormCommand = new Command(OnGoToSignupFormCommandClicked);
        }

        private async void OnGoToSignupFormCommandClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(SignupFormPage)}");
        }
    }
}
