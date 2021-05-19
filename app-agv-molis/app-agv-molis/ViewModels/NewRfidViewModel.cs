using app_agv_molis.Models;
using app_agv_molis.Services;
using app_agv_molis.Views;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    class NewRfidViewModel : BaseViewModel<Rfid>
    {
        private string name;        
        private string helixId;
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

        public Command SaveRfidCommand { get; }
        public Command CancelCommand { get; }

        public NewRfidViewModel()
        {
            SaveRfidCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync($"//{nameof(RfidPage)}");
        }

        private async void OnSave()
        {
            IsBusy = true;
            try
            {
                await _api.AddItemAsync(new Rfid(Name, HelixId));

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
    }
}
