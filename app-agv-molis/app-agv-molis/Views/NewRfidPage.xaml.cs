using app_agv_molis.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_agv_molis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewRfidPage : ContentPage
    {
        NewRfidViewModel _viewModel;

        public NewRfidPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new NewRfidViewModel();
            Title = "Novo Rfid";
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            await _viewModel.ExecuteLoadHelixIdsCommand();
            RfidPicker.ItemsSource = _viewModel.HelixIds;
        }
    }
}