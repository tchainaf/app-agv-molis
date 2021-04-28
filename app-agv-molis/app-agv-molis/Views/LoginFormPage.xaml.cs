using app_agv_molis.ViewModels;
using System;
using Xamarin.Forms;

namespace app_agv_molis.Views
{
    public partial class LoginFormPage : ContentPage
    {
        LoginFormViewModel _viewModel;
        public LoginFormPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new LoginFormViewModel();
            MessagingCenter.Subscribe<LoginFormPage, string>(this, "ErroLogin", async (sender, arg) =>
            {
                await DisplayAlert("Deu ruim", arg, "OK");
            });
        }

        public async void CancelCommand(object sender, EventArgs args)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        public async void LoginCommand(object sender, EventArgs args)
        {
            await _viewModel.ExecuteLoginCommand();
        }
    }
}
