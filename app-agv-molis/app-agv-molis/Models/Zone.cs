using app_agv_molis.Helpers;

namespace app_agv_molis.Models
{
    public class Zone
    {
        private string id;
        private string name;
        private Rfid rfid;

        public Zone(string id, string name, Rfid rfid)
        {
            this.Id = id;
            this.Name = name;
            this.Rfid = rfid;
        }

        public string Id
        {
            get => id; set
            {
               id = UtilsHelper.isValidString(value, "Id");
            }
        }
        public string Name
        {
            get => name; set
            {
                name = UtilsHelper.isValidString(value, "Nome");
            }
        }
        public Rfid Rfid
        {
            get => rfid; set
            {
                rfid = value;
            }
        }
    }
}