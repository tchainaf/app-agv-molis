using app_agv_molis.Helpers;
using Newtonsoft.Json;

namespace app_agv_molis.Models
{
    public class Agv
    {
        private string id;
        private string name;
        private string helixId;
        private float batteryPercentage;
        private string batteryPercentageColor;
        private string location;
        private Zone[] path;

        public Agv()
        {
        }

        public Agv(string id, string name, string helixId, float batteryPercentage, string location, Zone[] path)
        {
            this.Id = id;
            this.Name = name;
            this.HelixId = helixId;
            this.BatteryPercentage = batteryPercentage;
            this.Location = location;
            this.path = path;
        }

        public Agv(string name, string helixId, float batteryPercentage, string location, Zone[] path)
        {
            this.Name = name;
            this.HelixId = helixId;
            this.BatteryPercentage = batteryPercentage;
            this.Location = location;
            this.path = path;
        }

        public Agv(string name, string helixId, string location, Zone[] path)
        {
            this.Name = name;
            this.HelixId = helixId;
            this.Location = location;
            this.path = path;
        }

        [JsonProperty("id")]
        public string Id
        {
            get => id; 
            set
            {
                id = UtilsHelper.isValidString(value, "Id");
            }
        }

        [JsonProperty("name")]
        public string Name
        {
            get => name; 
            set
            {
                name = UtilsHelper.isValidString(value, "Name");
            }
        }

        [JsonProperty("helixId")]
        public string HelixId
        {
            get => helixId; 
            set
            {
                helixId = UtilsHelper.isValidString(value, "Helix Id");
            }
        }

        [JsonProperty("batteryPercentage")]
        public float BatteryPercentage
        {
            get => batteryPercentage; 
            set
            {
                batteryPercentage = value;
            }
        }

        [JsonProperty("location")]
        public string Location
        {
            get => location; 
            set
            {
                location = UtilsHelper.isValidString(value, "Id");
            }
        }

        [JsonProperty("path")]
        internal Zone[] Path
        {
            get => path; 
            set
            {
                path = value;
            }
        }

        public string BatteryPercentageColor { get => batteryPercentageColor; set => batteryPercentageColor = value; }
    }
}