using app_agv_molis.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    class NewAgvViewModel : BaseViewModel<Agv>
    {
        private string name;
        private string helixIdSelected;
        private List<string> helixIdsList;

        public NewAgvViewModel()
        {
            SaveNewAgvCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveNewAgvCommand.ChangeCanExecute();

            HelixIdsList = new List<string>() { "Id 1", "Id 2" };
            Name = "";
            HelixIdSelected = "";
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

        public string HelixIdSelected
        {
            get => helixIdSelected;
            set => SetProperty(ref helixIdSelected, value);
        }

        public List<string> HelixIdsList
        {
            get => helixIdsList;
            set => SetProperty(ref helixIdsList, value);
        }

        public Command SaveNewAgvCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
