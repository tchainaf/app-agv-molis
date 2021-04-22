using app_agv_molis.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

            //MessagingCenter.Subscribe<LoginFormPage>(this, "SucessoNoLogin", async (sender) =>
            //{
            //    Application.Current.MainPage = new DashPage();
            //});
        }

        public void CancelCommand(object sender, EventArgs args)
        {
            Application.Current.MainPage = new LoginPage();
        }

        public async void LoginCommand(object sender, EventArgs args)
        {
            await _viewModel.ExecuteLoginCommand();
        }
    }
}
