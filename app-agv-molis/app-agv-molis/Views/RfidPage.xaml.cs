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