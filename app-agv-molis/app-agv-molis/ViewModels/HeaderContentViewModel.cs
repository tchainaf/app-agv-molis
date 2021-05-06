using app_agv_molis.Helpers;
using app_agv_molis.Models;
using System.Threading.Tasks;

namespace app_agv_molis.ViewModels
{
    class HeaderContentViewModel : BaseViewModel<User>
    {
        private string _userName;
        private string _userRole;

        public HeaderContentViewModel()
        {            
        }

        public async Task GetHeaderInformation()
        {
            UserName = await RoleHelper.GetUserName();
            UserRole = await RoleHelper.GetUserRole();
        }

        public string UserName { get => _userName; set => SetProperty(ref _userName, value); }
        public string UserRole { get => _userRole; set => SetProperty(ref _userRole, value); }
    }
}
