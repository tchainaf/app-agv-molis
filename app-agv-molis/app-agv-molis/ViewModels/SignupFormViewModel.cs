using app_agv_molis.Models;
using app_agv_molis.Services;
using app_agv_molis.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    class SignupFormViewModel : BaseViewModel<string>
    {
        private string nome;
        private string email;
        private string senha;
        private string departamento;
        private UserApi _api = new UserApi();
        private string _selectedItem;
        public List<string> Tipos = new List<string>();
        public Command SaveNewUserCommand { get; }

        public SignupFormViewModel()
        {
            this.Tipos.Add("ADMIN");
            this.Tipos.Add("COMUM");
            SaveNewUserCommand = new Command(OnSave);
        }

        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public string SelectedItem { get => _selectedItem; set => SetProperty(ref _selectedItem, value); }

        private async void OnSave()
        {
            IsBusy = true;
            try
            {
                 await _api.AddItemAsync(new User(Nome, Departamento, new User().GetRoleEnumBy(SelectedItem), Email, Senha));

                MessagingCenter.Send<SignupFormPage>(new SignupFormPage(), "SucessoAoCriar");
                Application.Current.MainPage = new LoginPage();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send<SignupFormPage, string>(new SignupFormPage(), "ErroAoCriar", new ErrorResponse().GetErrorMessage(ex.Message));
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
