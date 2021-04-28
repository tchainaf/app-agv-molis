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
        private string _name;
        private string _helixId;
        private string _location;
        private Zone[] _path;
        private Agv _selectedItem;
        private bool _isVisible;
        private AgvApi _api = new AgvApi();
        public ObservableCollection<Agv> AgvsList { get; }
        public ObservableCollection<string> HelixIdsList { get; }        
        public Command AddAgvCommand { get; }
        public Command<Agv> AgvTapped { get; }
        public string Name { get => _name; set => SetProperty(ref _name, value); }
        public string HelixId { get => _helixId; set => SetProperty(ref _helixId, value); }
        public string Location { get => _location; set => SetProperty(ref _location, value); }
        public Zone[] Path { get => _path; set => SetProperty(ref _path, value); }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
        private SqliteHelper<User> _sqliteHelper;
        public AgvViewModel()
        {
            AgvsList = new ObservableCollection<Agv>();
            AgvTapped = new Command<Agv>(OnAgvSelected);
            AddAgvCommand = new Command(OnAddAgv);
            _sqliteHelper = new SqliteHelper<User>();
            ShouldSeeAdminTasks().Wait();
        }

        public async Task ShouldSeeAdminTasks()
        {
            var currentUserId = await RoleHelper.GetUserId();
            var currentUser = await _sqliteHelper.Get((user) => user.Id == currentUserId);
            if (currentUser.Role == User.RoleEnum.ADMIN)
            {
                IsVisible = true;
            }
            else
            {
                IsVisible = false;
            }
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
            IsBusy = true;
            try
            {
                await _api.AddItemAsync(new Agv(Name, HelixId, Location, Path));

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

        async void OnAgvSelected(Agv item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(RfidDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item._id}");
        }
    }
}
