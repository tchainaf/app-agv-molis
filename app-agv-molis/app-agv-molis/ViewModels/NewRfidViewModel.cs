using app_agv_molis.Models;
using app_agv_molis.Services;
using app_agv_molis.Views;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    class NewRfidViewModel : BaseViewModel<Rfid>
    {
        private string name;        
        private string helixId;
        private string _selectedItem;
        private RfidApi _api = new RfidApi();
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

        public ObservableCollection<string> HelixIds { get; }
        public Command SaveRfidCommand { get; }
        public Command CancelCommand { get; }

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
                var items = await _api.GetAllFromHelixAsync();
                foreach (var item in items)
                {
                    HelixIds.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send<NewRfidPage>(new NewRfidPage(), "ErroAoBuscarHelixIds");
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            IsBusy = true;
            try
            {
                await _api.AddItemAsync(new Rfid(Name, SelectedHelixId));

                MessagingCenter.Send<NewRfidPage>(new NewRfidPage(), "SucessoAoCriar");
                await Shell.Current.GoToAsync("..");
            } 
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send<NewRfidPage, string>(new NewRfidPage(), "ErroAoCriar", new ErrorResponse().GetErrorMessage(ex.Message));
            }
            finally
            {
                IsBusy = false;
            }
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
