using app_agv_molis.Helpers;

namespace app_agv_molis.Models
{
    public class Agv
    {
        private string id;
        private string name;
        private string helixId;
        private float batteryPercentage;
        private string location;
        private Zone[] path;

        public Agv(string id, string name, string helixId, float batteryPercentage, string location)
        {
            this.Id = id;
            this.Name = name;
            this.HelixId = helixId;
            this.BatteryPercentage = batteryPercentage;
            this.Location = location;
        }

        public string Id
        {
            get => id; 
            set
            {
                id = UtilsHelper.isValidString(value, "Id");
            }
        }
        public string Name
        {
            get => name; 
            set
            {
                name = UtilsHelper.isValidString(value, "Name");
            }
        }
        public string HelixId
        {
            get => helixId; 
            set
            {
                helixId = UtilsHelper.isValidString(value, "Helix Id");
            }
        }
        public float BatteryPercentage
        {
            get => batteryPercentage; 
            set
            {
                batteryPercentage = value;
            }
        }
        public string Location
        {
            get => location; 
            set
            {
                location = UtilsHelper.isValidString(value, "Id");
            }
        }
        internal Zone[] Path
        {
            get => path; 
            set
            {
                path = value;
            }
        }
    }
}
