using System;
using System.Collections.Generic;
using System.Text;

namespace app_agv_molis.Models
{
    public class ErrorResponse
    {
        private string message;
        private Dictionary<string, string> _errorsMessages = new Dictionary<string, string>()
        {
            {"Validation fails", "Erro interno. \nUm ou mais campos estão errados"},
            {"Senha incorreta", "Senha incorreta"}
        };

        public string GetErrorMessage(string msg)
        {
            if (this._errorsMessages.ContainsKey(msg))
            {
                return this._errorsMessages[msg];
            }
            return "Erro desconhecido";
        }

        public string Message { get => message; set => message = value; }
    }
}
