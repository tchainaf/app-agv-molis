using app_agv_molis.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_agv_molis.Views
{
    public partial class LoginFormPage : ContentPage
    {
        public LoginFormPage()
        {
            InitializeComponent();
        }

        public void CancelCommand(object sender, EventArgs args)
        {
            Application.Current.MainPage = new LoginPage();
        }

        public async void LoginCommand(object sender, EventArgs args)
        {
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//main");
        }

    }
}
