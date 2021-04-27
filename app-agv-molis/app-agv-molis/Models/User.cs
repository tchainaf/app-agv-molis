using app_agv_molis.Helpers;
using Newtonsoft.Json;
using System;

namespace app_agv_molis.Models
{
    public class User
    {
        private string id;
        private string name;
        private string department;
        private RoleEnum role;
        private string email;
        private string password;
        private string salt;

        public User()
        {
        }

        public User(string id, string name, string department, RoleEnum role, string email, string salt, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Department = department;
            this.Role = role;
            this.Email = email;
            this.Salt = salt;
            this.Password = password;
        }

        public User(string name, string department, RoleEnum role, string email, string password)
        {
            this.Name = name;
            this.Department = department;
            this.Role = role;
            this.Email = email;
            this.Password = password;
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
                name = UtilsHelper.isValidString(value, "Nome");
            }
        }

        [JsonProperty("department")]
        public string Department
        {
            get => department; 
            set
            {
                department = UtilsHelper.isValidString(value, "Departamento");
            }
        }

        [JsonProperty("role")]
        public RoleEnum Role
        {
            get => role;
            set
            {
                role = value;
            }
        }

        [JsonProperty("email")]
        public string Email
        {
            get => email; 
            set
            {
                email = UtilsHelper.isValidString(value, "Email");
            }
        }

        [JsonProperty("salt")]
        public string Salt
        {
            get => salt; 
            set
            {
                salt = UtilsHelper.isValidString(value, "Salt");
            }
        }

        [JsonProperty("password")]
        public string Password { get => password; set => password = value; }

        public RoleEnum GetRoleEnumBy(int roleNumber)
        {
            switch (roleNumber)
            {
                case 0:
                    return RoleEnum.ADMIN;
                case 1:
                    return RoleEnum.COMMON;
                default:
                    throw new Exception("Role inválido");
            }
        }

        public RoleEnum GetRoleEnumBy(string roleName)
        {
            switch (roleName)
            {
                case "ADMIN":
                    return RoleEnum.ADMIN;
                case "COMUM":
                    return RoleEnum.COMMON;
                default:
                    throw new Exception("Role inválido");
            }
        }
        public string GetRoleNameBy(RoleEnum role)
        {
            switch (role)
            {
                case RoleEnum.ADMIN:
                    return "ADMIN";
                case RoleEnum.COMMON:
                    return "COMUM";
                default:
                    throw new Exception("Role inválido");
            }
        }

        public enum RoleEnum
        {
            ADMIN,
            COMMON
        }
    }
}