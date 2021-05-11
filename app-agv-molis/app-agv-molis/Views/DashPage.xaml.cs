using app_agv_molis.ViewModels;
using System;
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
            MessagingCenter.Subscribe<NewRfidPage>(this, "ErroAoBuscar", (sender) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Deu ruim", "Erro ao buscar os agvs", "OK");
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