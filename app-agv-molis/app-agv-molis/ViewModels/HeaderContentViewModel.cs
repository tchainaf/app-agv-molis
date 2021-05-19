using app_agv_molis.Helpers;
using app_agv_molis.Models;
using System.Threading.Tasks;

namespace app_agv_molis.ViewModels
{
    class HeaderContentViewModel : BaseViewModel<User>
    {
        private string _userName;
        private string _userEmail;

        public HeaderContentViewModel()
        {            
        }

        public async Task GetHeaderInformation()
        {
            UserName = await RoleHelper.GetUserName();
            UserEmail = await RoleHelper.GetUserEmail();
        }

        public string UserName { get => _userName; set => SetProperty(ref _userName, value); }
        public string UserEmail { get => _userEmail; set => SetProperty(ref _userEmail, value); }
    }
}
