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
        public string AgvsInZone1 { get => _agvsInZone1; set => SetProperty(ref _agvsInZone1, value); }
        public string AgvsInZone2 { get => _agvsInZone2; set => SetProperty(ref _agvsInZone2, value); }
        public string AgvsInZone3 { get => _agvsInZone3; set => SetProperty(ref _agvsInZone3, value); }
        public string AgvsInZone4 { get => _agvsInZone4; set => SetProperty(ref _agvsInZone4, value); }
        public string AgvsInZone5 { get => _agvsInZone5; set => SetProperty(ref _agvsInZone5, value); }

        private Agv _onAgvSelected;

        private string _agvsInZone1;
        private string _agvsInZone2;
        private string _agvsInZone3;
        private string _agvsInZone4;
        private string _agvsInZone5;

        public DashViewModel()
        {
            AgvsInZone1 = String.Empty;
            AgvsInZone2 = String.Empty;
            AgvsInZone3 = String.Empty;
            AgvsInZone4 = String.Empty;
            AgvsInZone5 = String.Empty;
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
                    item.BatteryPercentageColor = item.SetBatteryPercentageColor(item.BatteryPercentage);
                    AgvsList.Add(item);
                    PutInTheCorrectZone(item);
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
                ZonesList.Clear();
                await RoleHelper.RemoveAllZones();
                MessagingCenter.Send<DashPage>(new DashPage(), "ErroAoBuscar");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void PutInTheCorrectZone(Agv agv)
        {
            if (agv.Location == "Zona Vermelha")
            {
                AgvsInZone1 += $" {agv.Name.ToUpper()}";
            } 
            else if (agv.Location == "Zona Roxa")
            {
                AgvsInZone2 += $" {agv.Name.ToUpper()}";
            }
            else if (agv.Location == "Zona Azul")
            {
                AgvsInZone3 += $" {agv.Name.ToUpper()}";
            }
            else if (agv.Location == "Zona Verde")
            {
                AgvsInZone4 += $" {agv.Name.ToUpper()}";
            }
            else if (agv.Location == "Zona Cinza")
            {
                AgvsInZone5 += $" {agv.Name.ToUpper()}";
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
