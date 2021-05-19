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
            MessagingCenter.Subscribe<NewRfidPage>(this, "SucessoAoCriar", (sender) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Uhuul", "RFID criado com sucesso!", "OK");
                });
            });
            MessagingCenter.Subscribe<NewRfidPage, string>(this, "ErroAoCriar", (sender, arg) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Deu ruim", arg, "OK");
                });
            });
        }
    }
}