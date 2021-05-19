using app_agv_molis.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_agv_molis.Views
{
    public partial class NewAgvPage : ContentPage
    {
        NewAgvViewModel _viewModel;
        public NewAgvPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new NewAgvViewModel();
            MessagingCenter.Subscribe<NewRfidPage>(this, "ErroAoBuscarHelixIds", (sender) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Deu ruim", "Erro ao buscar os ids do Helix", "OK");
                });
            });
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            await _viewModel.ExecuteLoadHelixIdsCommand();
            AgvPicker.ItemsSource = _viewModel.HelixIds;
        }
    }
}