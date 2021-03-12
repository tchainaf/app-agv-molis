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
        public Command CancelSignupFormCommand { get; }

        public SignupFormViewModel()
        {
            GoToSignupFormCommand = new Command(OnGoToSignupFormCommandClicked);
            CancelSignupFormCommand = new Command(OnGoToSignupFormCommandClicked);
        }

        private async void OnGoToSignupFormCommandClicked(object obj)
        {
            App.Current.MainPage = new SignupFormPage();
        }

        private async void CancelFormCommandClicked(object obj)
        {
            App.Current.MainPage = new SignupFormPage();
        }
    }
}
