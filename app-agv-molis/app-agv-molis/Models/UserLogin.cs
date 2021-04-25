namespace app_agv_molis.Models
{
    public class UserLogin
    {
        private string email;
        private string password;

        public UserLogin(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
    }
}
