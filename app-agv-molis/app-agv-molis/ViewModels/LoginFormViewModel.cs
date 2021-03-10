﻿using System;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    public class LoginFormViewModel : BaseViewModel
    {
        private string email;
        private string password;

        public LoginFormViewModel()
        {
            LoginCommand = new Command(OnLogin, ValidateLogin);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => LoginCommand.ChangeCanExecute();
        }

        private bool ValidateLogin()
        {
            return !String.IsNullOrWhiteSpace(email)
                && !String.IsNullOrWhiteSpace(password);
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

        public Command LoginCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnLogin()
        {
            Console.WriteLine("CHAMA A API");
            Console.WriteLine(email);
            Console.WriteLine(password);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
