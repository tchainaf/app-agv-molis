using app_agv_molis.Models;
using app_agv_molis.ViewModels;
using Xamarin.Forms;

namespace app_agv_molis.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}