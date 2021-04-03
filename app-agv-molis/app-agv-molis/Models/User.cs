using app_agv_molis.Helpers;
using System;

namespace app_agv_molis.Models
{
    class User
    {
        private string id;
        private string name;
        private string department;
        private RoleEnum role;
        private string email;
        private string salt;

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

        RoleEnum GetRoleEnumBy(string roleName)
        {
            switch (roleName)
            {
                case "ADMIN":
                    return RoleEnum.ADMIN;
                case "COMMON":
                    return RoleEnum.COMMON;
                default:
                    throw new Exception("Role inválido");
            }
        }

        string GetRoleNameBy(RoleEnum role)
        {
            switch (role)
            {
                case RoleEnum.ADMIN:
                    return RoleEnum.ADMIN.GetType().Name;
                case RoleEnum.COMMON:
                    return RoleEnum.COMMON.GetType().Name;
                default:
                    throw new Exception("Role name inválido");
            }
        }

        public enum RoleEnum
        {
            ADMIN,
            COMMON
        }
    }
}
