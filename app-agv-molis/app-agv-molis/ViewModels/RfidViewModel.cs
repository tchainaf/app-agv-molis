using app_agv_molis.Helpers;
using app_agv_molis.Models;
using app_agv_molis.Services;
using app_agv_molis.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    public class RfidViewModel : BaseViewModel<Rfid>
    {
        private Rfid _selectedItem;
        private bool _isVisible;
        private RfidApi _api = new RfidApi();

        public ObservableCollection<Rfid> RfidsList { get; }
        public Command AddRfidCommand { get; }
        public Command<Rfid> RfidTapped { get; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
        private SqliteHelper<User> _sqliteHelper;
        public RfidViewModel()
        {
            _sqliteHelper = new SqliteHelper<User>();
            RfidsList = new ObservableCollection<Rfid>();
            RfidTapped = new Command<Rfid>(OnRfidSelected);
            AddRfidCommand = new Command(OnAddRfid);
        }

        public async Task ExecuteDeleteRfidCommand(string id)
        {
            IsBusy = true;

            try
            {
                await _api.DeleteItemAsync(id);
                MessagingCenter.Send<RfidPage>(new RfidPage(), "SucessoAoDeletar");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send<RfidPage, string>(new RfidPage(), "ErroAoDeletar", new ErrorResponse().GetErrorMessage(ex.Message));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task ExecuteLoadRfidsCommand()
        {
            IsBusy = true;

            try
            {
                RfidsList.Clear();
                var items = await _api.GetAllItemsAsync();
                foreach (var item in items)
                {
                    RfidsList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send<RfidPage, string>(new RfidPage(), "ErroAoBuscar", new ErrorResponse().GetErrorMessage(ex.Message));
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
