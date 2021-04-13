using app_agv_molis.Models;
using app_agv_molis.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    class NewRfidViewModel : BaseViewModel<Rfid>
    {
        private string name;
        
        private string helixId;

        private string _selectedItem;

        public ObservableCollection<string> HelixIds { get; }

        public Command LoadHelixIdsCommand { get; }

        public NewRfidViewModel()
        {
            HelixIds = new ObservableCollection<string>();
            SaveRfidCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
        }

        public async Task ExecuteLoadHelixIdsCommand()
        {
            IsBusy = true;

            try
            {
                HelixIds.Clear();
                var items = await api.GetAllFromHelixAsync();
                
                Debug.WriteLine(items);

                foreach (var item in items)
                {
                    HelixIds.Add(item);
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

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string HelixId
        {
            get => helixId;
            set => SetProperty(ref helixId, value);
        }

        public Command SaveRfidCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async Task<bool> OnSave()
        {
            var res = await api.AddItemAsync(new Rfid(Name, SelectedHelixId));
            if (res.StatusCode == HttpStatusCode.Created)
            {
                await Shell.Current.GoToAsync("..");
                return true;
            }
            return false;
        }

        public string SelectedHelixId
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnHelixIdSelected(value);
            }
        }

        async void OnHelixIdSelected(string item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item._id}");
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedHelixId = null;
        }
    }
}
