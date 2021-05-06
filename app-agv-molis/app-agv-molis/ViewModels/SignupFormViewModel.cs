using app_agv_molis.Helpers;
using app_agv_molis.Models;
using app_agv_molis.Services;
using app_agv_molis.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private User _user = new User();
        public List<string> Tipos = new List<string>();
        public Command SaveNewUserCommand { get; }

        public SignupFormViewModel()
        {
            this.Tipos.Add(_user.GetRoleNameBy(User.RoleEnum.ADMIN));
            this.Tipos.Add(_user.GetRoleNameBy(User.RoleEnum.COMMON));
            SaveNewUserCommand = new Command(OnSave);
        }

        public string Nome { get => nome; set => SetProperty(ref nome, value); }
        public string Email { get => email; set => SetProperty(ref email, value); }
        public string Senha { get => senha; set => SetProperty(ref senha, value); }
        public string Departamento { get => departamento; set => SetProperty(ref departamento, value); }
        public string SelectedItem { get => _selectedItem; set => SetProperty(ref _selectedItem, value); }

        private async void OnSave()
        {
            IsBusy = true;
            try
            {
                UtilsHelper.isValidString(Nome, "Nome");
                UtilsHelper.isValidString(Email, "Email");
                UtilsHelper.isValidString(Senha, "Senha");
                UtilsHelper.isValidString(Departamento, "Departamento");
                await _api.AddItemAsync(new User(Nome, Departamento, User.RoleEnum.COMMON, Email, Senha));

                MessagingCenter.Send<SignupFormPage>(new SignupFormPage(), "SucessoAoCriar");
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
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
