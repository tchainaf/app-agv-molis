using app_agv_molis.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    class SignupFormViewModel : BaseViewModel<string>
    {
        public Command GoToSignupFormCommand { get; }
        public Command CancelSignupFormCommand { get; }
        public Command SaveNewUserCommand { get; }

        public SignupFormViewModel()
        {
            GoToSignupFormCommand = new Command(OnGoToSignupFormCommandClicked);
            CancelSignupFormCommand = new Command(OnCancelFormCommandClicked);
            SaveNewUserCommand = new Command(OnSaveNewUserCommandClicked);
        }

        private async void OnGoToSignupFormCommandClicked(object obj)
        {
            App.Current.MainPage = new SignupFormPage();
        }

        private async void OnCancelFormCommandClicked(object obj)
        {
            App.Current.MainPage = new SignupFormPage();
        }

        private void OnSaveNewUserCommandClicked(object obj)
        {
            App.Current.MainPage = new LoginFormPage();
        }
    }
}
