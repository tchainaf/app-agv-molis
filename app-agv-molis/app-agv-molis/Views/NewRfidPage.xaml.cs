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
            MessagingCenter.Subscribe<NewRfidPage>(this, "SucessoAoCriar", async (sender) =>
            {
                await DisplayAlert("Uhuul", "RFID criado com sucesso!", "OK");
            });
            MessagingCenter.Subscribe<NewRfidPage, string>(this, "ErroAoCriar", async (sender, arg) =>
            {
                await DisplayAlert("Deu ruim", arg, "OK");
            });
            MessagingCenter.Subscribe<NewRfidPage>(this, "ErroAoBuscarHelixIds", async (sender) =>
            {
                await DisplayAlert("Deu ruim", "Erro ao buscar os ids do Helix", "OK");
            });
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