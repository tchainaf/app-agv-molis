using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    public class NewRfidViewModel : BaseViewModel
    {
        private string name;
        private string helixId;
        public NewRfidViewModel()
        {
            SaveRfidCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveRfidCommand.ChangeCanExecute();
        }


        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(helixId);
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

        private async void OnSave()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
