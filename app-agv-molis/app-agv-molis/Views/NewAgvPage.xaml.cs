using app_agv_molis.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_agv_molis.Views
{
    public partial class NewAgvPage : ContentPage
    {
        public NewAgvPage()
        {
            InitializeComponent();
            BindingContext = new NewAgvViewModel();
        }
    }
}