using app_agv_molis.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_agv_molis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RfidPage : ContentPage
    {
        RfidViewModel _viewModel;
        public RfidPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new RfidViewModel();
            MessagingCenter.Subscribe<NewRfidPage, string>(this, "ErroAoBuscar", async (sender, args) =>
            {
                await DisplayAlert("Deu ruim", "Erro ao buscar os rfids\n" + args, "OK");
            });
            MessagingCenter.Subscribe<NewRfidPage, string>(this, "ErroAoDeletar", async (sender, args) =>
            {
                await DisplayAlert("Deu ruim", "Erro ao apagar o rfid\n" + args, "OK");
            });
            MessagingCenter.Subscribe<NewRfidPage>(this, "SucessoAoDeletar", async (sender) =>
            {
                await DisplayAlert("Deu ruim", "Rfid apagado com sucesso!\n", "OK");
            });
        }

        public async void DeleteClicked(object sender, EventArgs e)
        {
            var item = (Button)sender;
            await _viewModel.ExecuteDeleteRfidCommand(item.CommandParameter.ToString());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            await _viewModel.ExecuteLoadRfidsCommand();
            RfidView.ItemsSource = _viewModel.RfidsList;
        }
    }
}