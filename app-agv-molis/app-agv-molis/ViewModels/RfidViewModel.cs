using app_agv_molis.Models;
using app_agv_molis.Services;
using app_agv_molis.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    public class RfidViewModel : BaseViewModel<Rfid>
    {
        private Rfid _selectedItem;

        private RfidApi _api = new RfidApi();

        public ObservableCollection<Rfid> Rfids { get; }
        public Command LoadRfidsCommand { get; }
        public Command AddRfidCommand { get; }
        public Command<Rfid> RfidTapped { get; }

        public RfidViewModel()
        {
            Rfids = new ObservableCollection<Rfid>();
            LoadRfidsCommand = new Command(async () => await ExecuteLoadRfidsCommand());
            RfidTapped = new Command<Rfid>(OnRfidSelected);
            AddRfidCommand = new Command(OnAddRfid);
        }

        async Task ExecuteLoadRfidsCommand()
        {
            IsBusy = true;

            try
            {
                Rfids.Clear();
                var items = await _api.GetAllItemsAsync();
                foreach (var item in items)
                {
                    Rfids.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            //SelectedItem = null;
        }


        private async void OnAddRfid(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewRfidPage));
        }

        async void OnRfidSelected(Rfid item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(RfidDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item._id}");
        }
    }
}
