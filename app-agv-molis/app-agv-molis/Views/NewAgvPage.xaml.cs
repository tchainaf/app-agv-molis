using app_agv_molis.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_agv_molis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAgvPage : ContentView
    {
        public NewAgvPage()
        {
            InitializeComponent();
            this.BindingContext = new NewAgvViewModel();
        }
    }
}