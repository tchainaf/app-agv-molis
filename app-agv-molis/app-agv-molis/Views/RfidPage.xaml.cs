using app_agv_molis.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_agv_molis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RfidPage : ContentPage
    {
        public RfidPage()
        {
            InitializeComponent();
            this.BindingContext = new RfidViewModel();
        }
    }
}