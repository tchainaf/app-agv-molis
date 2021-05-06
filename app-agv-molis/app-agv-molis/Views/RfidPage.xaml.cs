using app_agv_molis.ViewModels;
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
            MessagingCenter.Subscribe<NewRfidPage, string>(this, "ErroAoBuscar", (sender, args) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Deu ruim", "Erro ao buscar os rfids\n" + args, "OK");
                });
            });
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