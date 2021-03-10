using app_agv_molis.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_agv_molis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupFormPage : ContentPage
    {
        public SignupFormPage()
        {
            InitializeComponent();

            this.BindingContext = new SignupFormViewModel();
        }
    }
}