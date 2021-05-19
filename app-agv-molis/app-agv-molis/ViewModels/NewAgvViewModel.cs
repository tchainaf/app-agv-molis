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
    class NewAgvViewModel : BaseViewModel<Agv>
    {
        private AgvApi _api;
        private string name;
        private string _selectedHelixId;
        public ObservableCollection<string> HelixIds { get; }

        public NewAgvViewModel()
        {
            _api = new AgvApi();
            HelixIds = new ObservableCollection<string>();
            SaveNewAgvCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveNewAgvCommand.ChangeCanExecute();

            Name = "";
            SelectedHelixId = "";
        }

        private bool ValidateSave()
        {
            return true;
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
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
                MessagingCenter.Send<NewAgvPage>(new NewAgvPage(), "ErroAoBuscarHelixIds");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Command SaveNewAgvCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            IsBusy = true;
            try
            {
                await _api.AddItemAsync(new Agv(Name, SelectedHelixId));

                MessagingCenter.Send<NewAgvPage>(new NewAgvPage(), "SucessoAoCriar");
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send<NewAgvPage, string>(new NewAgvPage(), "ErroAoCriar", new ErrorResponse().GetErrorMessage(ex.Message));
            }
            finally
            {
                IsBusy = false;
            }
        }
        public string SelectedHelixId
        {
            get => _selectedHelixId;
            set
            {
                SetProperty(ref _selectedHelixId, value);
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
