<<<<<<< HEAD
using System;

namespace app_agv_molis.Helpers
{
    public static class UtilsHelper
    {
        public static string isValidString(string str, string fieldNameException)
        {
            if (!String.IsNullOrEmpty((string)str) && !String.IsNullOrWhiteSpace((string)str))
                return str;
            else
                throw new Exception(fieldNameException + " é obrigatório!");
        }
    }
}
=======
using System;

namespace app_agv_molis.Helpers
{
    public static class UtilsHelper
    {
        public static string isValidString(string str, string fieldNameException)
        {
            if (!String.IsNullOrEmpty((string)str) && !String.IsNullOrWhiteSpace((string)str))
                return str;
            else
                throw new Exception(fieldNameException + " é obrigatório!");
        }
    }
}
>>>>>>> ae0f7715e145ecb43f68dfcf2e4a9609b0cbc354
