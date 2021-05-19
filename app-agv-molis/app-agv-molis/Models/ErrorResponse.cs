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
            {"Senha incorreta", "Senha incorreta"},
            {"Email já existe", "Email já existe"},
            {"Email é obrigatório!", "Email é um campo obrigatório!"},
            {"Senha é obrigatório!", "Senha é um campo obrigatório!"},
            {"Departamento é obrigatório!", "Departamento é um campo obrigatório!"},
            {"Nome é obrigatório!", "Nome é um campo obrigatório!"},
            {"Rfid com esse id já existe", "Rfid com esse Helix id já existe"},
            {"JWT expirou", "Necessário logar novamente"},
            {"Usuário com esse email não encontrado", "Usuário com esse email não encontrado" },
            {"Agv com esse id do helix já existe", "Agv com esse id já foi existe" }

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
