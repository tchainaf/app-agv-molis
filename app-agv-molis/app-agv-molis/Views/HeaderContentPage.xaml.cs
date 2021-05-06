using app_agv_molis.Helpers;
using app_agv_molis.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_agv_molis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeaderContentPage : ContentView
    {
        HeaderContentViewModel _viewModel;
        public HeaderContentPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new HeaderContentViewModel();
            this.LayoutChanged += (s, e) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await _viewModel.GetHeaderInformation();
                });
            };
        }
    }
}