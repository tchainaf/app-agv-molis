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
