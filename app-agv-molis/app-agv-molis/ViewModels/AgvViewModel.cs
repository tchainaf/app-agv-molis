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
    public class AgvViewModel : BaseViewModel<Agv>
    {
        private Agv _selectedItem;
        private AgvApi _api = new AgvApi();
        public ObservableCollection<Agv> AgvsList { get; }
        public ObservableCollection<string> HelixIdsList { get; }        
        public Command AddAgvCommand { get; }
        public Command<Agv> AgvTapped { get; }
        private SqliteHelper<User> _sqliteHelper;
        public AgvViewModel()
        {
            AgvTapped = new Command<Agv>(OnAgvSelected);
            AgvsList = new ObservableCollection<Agv>();
            AddAgvCommand = new Command(OnAddAgv);
            _sqliteHelper = new SqliteHelper<User>();
        }

        public async Task ExecuteLoadAgvsCommand()
        {
            IsBusy = true;

            try
            {
                AgvsList.Clear();
                var items = await _api.GetAllItemsAsync();
                foreach (var item in items)
                {
                    item.BatteryPercentageColor = item.SetBatteryPercentageColor(item.BatteryPercentage);
                    AgvsList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send<AgvPage, string>(new AgvPage(), "ErroAoBuscar", new ErrorResponse().GetErrorMessage(ex.Message));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task ExecuteLoadHelixIdsCommand()
        {
            IsBusy = true;

            try
            {
                HelixIdsList.Clear();
                var items = await _api.GetAllFromHelixAsync();
                foreach (var item in items)
                {
                    HelixIdsList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send<AgvPage, string>(new AgvPage(), "ErroAoBuscarHelixIds", new ErrorResponse().GetErrorMessage(ex.Message));
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

        private async void OnAddAgv()
        {
            await Shell.Current.GoToAsync(nameof(NewAgvPage));
        }

        async void OnAgvSelected(Agv item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(RfidDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item._id}");
        }
    }
}
