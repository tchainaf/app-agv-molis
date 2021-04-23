
namespace app_agv_molis.Models
{
    class UserLoginResponse
    {
        private User user;
        private string token;

        public UserLoginResponse(User user, string token)
        {
            this.user = user;
            this.token = token;
        }

        public string Token { get => token; set => token = value; }
        internal User User { get => user; set => user = value; }
    }
}
