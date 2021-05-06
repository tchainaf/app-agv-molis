using app_agv_molis.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_agv_molis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeaderContentPage : ContentPage
    {
        private string _userName;
        private string _userRole;
        public HeaderContentPage()
        {
            InitializeComponent();            
        }

        protected override async void OnAppearing()
        {
            UserName = await RoleHelper.GetUserName();
            UserRole = await RoleHelper.GetUserRole();
        }

        public string UserName { get => _userName; set => _userName = value; }
        public string UserRole { get => _userRole; set => _userRole = value; }
    }
}