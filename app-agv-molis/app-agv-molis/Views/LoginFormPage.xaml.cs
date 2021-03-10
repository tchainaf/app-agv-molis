using app_agv_molis.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_agv_molis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginFormPage : ContentPage
    {
        public LoginFormPage()
        {
            InitializeComponent();
            BindingContext = new LoginFormViewModel();
        }

    }
}
