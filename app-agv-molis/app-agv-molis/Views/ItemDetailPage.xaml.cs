using app_agv_molis.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace app_agv_molis.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}