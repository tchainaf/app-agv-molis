using app_agv_molis.Helpers;
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
        private string salt;

        public User()
        {
        }

        public User(string id, string name, string department, RoleEnum role, string email, string salt)
        {
            this.Id = id;
            this.Name = name;
            this.Department = department;
            this.Role = role;
            this.Email = email;
            this.Salt = salt;
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
        public string Department
        {
            get => department; 
            set
            {
                department = UtilsHelper.isValidString(value, "Departamento");
            }
        }
        public RoleEnum Role
        {
            get => role;
            set
            {
                role = value;
            }
        }
        public string Email
        {
            get => email; 
            set
            {
                email = UtilsHelper.isValidString(value, "Email");
            }
        }
        public string Salt
        {
            get => salt; 
            set
            {
                salt = UtilsHelper.isValidString(value, "Salt");
            }
        }

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

        public enum RoleEnum
        {
            ADMIN,
            COMMON
        }
    }
}