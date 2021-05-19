using app_agv_molis.Helpers;
using app_agv_molis.Models;
using app_agv_molis.Services;
using app_agv_molis.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace app_agv_molis.ViewModels
{
    class LoginFormViewModel: BaseViewModel<User>
    {
        private string email;
        private string password;
        private UserApi _apiUser = new UserApi();
        private SqliteHelper<User> _sqliteHelper = new SqliteHelper<User>();

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public async Task ExecuteLoginCommand()
        {
            IsBusy = true; 
            try
            {
                UtilsHelper.isValidString(Email.Trim(), "Email");
                UtilsHelper.isValidString(Password, "Senha");
                var response = await _apiUser.LoginAsync(new UserLogin(Email, Password));
                await RoleHelper.SetUserId(response.User.Id);
                await _sqliteHelper.Insert(response.User);
                Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send<LoginFormPage, string>(new LoginFormPage(), "ErroLogin", new ErrorResponse().GetErrorMessage(ex.Message));
            }
            finally
            {
                Email = String.Empty;
                Password = String.Empty;
                IsBusy = false;
            }
        }
    }
}
