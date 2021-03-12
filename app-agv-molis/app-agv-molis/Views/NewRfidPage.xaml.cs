using app_agv_molis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_agv_molis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewRfidPage : ContentPage
    {
        public NewRfidPage()
        {
            InitializeComponent();
            this.BindingContext = new NewRfidViewModel();
        }
    }
}