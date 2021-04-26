using app_agv_molis.Helpers;

namespace app_agv_molis.Models
{
    public class Rfid
    {
        private string id;
        private string name;
        private string helixId;

        public Rfid(string id, string name, string helixId)
        {
            this.Id = id;
            this.Name = name;
            this.HelixId = helixId;
        }

        public Rfid(string name, string helixId)
        {
            this.Name = name;
            this.HelixId = helixId;
        }

        public Rfid()
        {
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
                name = UtilsHelper.isValidString(value, "Nome");
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
    }
}