using app_agv_molis.Helpers;
using app_agv_molis.Models;
using app_agv_molis.Services;
using app_agv_molis.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    public class DashViewModel : BaseViewModel<Agv>
    {
        private AgvApi _apiAgv = new AgvApi();
        private ZoneApi _apiZones = new ZoneApi();
        public ObservableCollection<Agv> AgvsList { get; set; }
        public ObservableCollection<Zone> ZonesList { get; set; }
        public ObservableCollection<string> ZonesNames { get; set; }
        public Agv OnAgvSelected { get => _onAgvSelected; set => SetProperty(ref _onAgvSelected, value); }

        private Agv _onAgvSelected;

        public DashViewModel()
        {
            AgvsList = new ObservableCollection<Agv>();
            ZonesList = new ObservableCollection<Zone>();
            ZonesNames = new ObservableCollection<string>();
        }

        public async Task ExecuteLoadAgvsCommand()
        {
            IsBusy = true;

            try
            {
                AgvsList.Clear();
                var items = await _apiAgv.GetAllItemsAsync();
                foreach (var item in items)
                {
                    item.BatteryPercentageColor = SetBatteryPercentageColor(item.BatteryPercentage);
                    AgvsList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send<DashPage>(new DashPage(), "ErroAoBuscar");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task ExecuteLoadZonesCommand()
        {
            IsBusy = true;

            try
            {
                ZonesList.Clear();
                var items = await _apiZones.GetAllItemsAsync();
                int length = 0;
                foreach (var item in items)
                {
                    ZonesList.Add(item);
                    length = length + 1;
                    await SecureStorage.SetAsync($"zone-{length}", item.Name);
                }
                await SecureStorage.SetAsync("zone-length", length.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send<DashPage>(new DashPage(), "ErroAoBuscar");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private string SetBatteryPercentageColor(float battery)
        {
            if (battery >= 50)
            {
                return "#32CD32";
            } else if (battery >= 30)
            {
                return "#FF4500";
            }
            else
            {
                return "#FF0000";
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
