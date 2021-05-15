using app_agv_molis.ViewModels;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_agv_molis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgvPage : ContentPage
    {
        AgvViewModel _viewModel;
        public AgvPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new AgvViewModel();
            MessagingCenter.Subscribe<AgvPage, string>(this, "ErroAoBuscar", (sender, args) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Deu ruim", "Erro ao buscar os agvs\n" + args, "OK");
                });
            });
            MessagingCenter.Subscribe<AgvPage>(this, "ErroAoBuscarHelixIds", (sender) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Deu ruim", "Erro ao buscar os ids do Helix", "OK");
                });
            });
            MessagingCenter.Subscribe<AgvPage>(this, "SucessoAoCriar", (sender) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Uhuuul", "Agv criado com sucesso!", "OK");
                });
            });
            MessagingCenter.Subscribe<AgvPage, string>(this, "ErroAoCriar", (sender, args) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Deu ruim", "Erro ao criar o agv\n" + args, "OK");
                });
            });
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                _viewModel.OnAppearing();
                await _viewModel.ExecuteLoadAgvsCommand();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}