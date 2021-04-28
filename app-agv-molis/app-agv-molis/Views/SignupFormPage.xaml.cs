using app_agv_molis.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_agv_molis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupFormPage : ContentPage
    {
        SignupFormViewModel _viewModel;
        public SignupFormPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new SignupFormViewModel();
            TiposUsuarioPicker.ItemsSource = _viewModel.Tipos;
            MessagingCenter.Subscribe<SignupFormPage>(this, "SucessoAoCriar", async (sender) =>
            {
                await DisplayAlert("Uhuul", "Usuário criado com sucesso!", "OK");
            });
            MessagingCenter.Subscribe<SignupFormPage, string>(this, "ErroAoCriar", async (sender, arg) =>
            {
                await DisplayAlert("Deu ruim", arg, "OK");
            });
        }

        public async void CancelCommand(object sender, EventArgs args)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}