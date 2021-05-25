using app_agv_molis.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace app_agv_molis.Views
{
    public partial class DashPage : ContentPage
    {
        DashViewModel _viewModel;
        public DashPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new DashViewModel();
            Title = "Mapa";
            MessagingCenter.Subscribe<DashPage>(this, "ErroAoBuscar", (sender) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Deu ruim", "Erro ao buscar os agvs", "OK");
                });
            });
            MessagingCenter.Subscribe<DashPage>(this, "Reload", (sender) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    OnAppearing();
                });
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing(); 
            _viewModel.OnAppearing();
            await _viewModel.ExecuteLoadAgvsCommand();
        }
    }
}