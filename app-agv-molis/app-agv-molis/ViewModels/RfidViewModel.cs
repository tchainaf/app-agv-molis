using app_agv_molis.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    public class RfidViewModel
    {
        public Command AddRfidCommand { get; }

        public RfidViewModel()
        {
            AddRfidCommand = new Command(OnAddRfid);
        }

        private async void OnAddRfid(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewRfidPage));
        }
    }
}
