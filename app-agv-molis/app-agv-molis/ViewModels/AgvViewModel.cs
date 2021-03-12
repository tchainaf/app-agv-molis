using app_agv_molis.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    public class AgvViewModel
    {
        public Command AddAgvCommand { get; }

        public AgvViewModel()
        {
            AddAgvCommand = new Command(OnAddAgv);
        }

        private async void OnAddAgv(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewAgvPage));
        }
    }
}
