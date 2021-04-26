using Newtonsoft.Json;

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

        [JsonProperty("email")]
        public string Email { get => email; set => email = value; }
        [JsonProperty("password")]
        public string Password { get => password; set => password = value; }
    }
}
