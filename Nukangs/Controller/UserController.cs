using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nukangs.Repository;
using Nukangs.Handler;

namespace Nukangs.Controller
{
    public class UserController
    {
        public static string addUser(string name, string email, string gender, string address, string password)
        {
            if (name.Length < 5 || name.Length > 50)
            {
                return "Name must be filled between 5 - 50 Characters";
            }
            else if (email.Length == 0)
            {
                return "Email must be filled";
            }

            else if (!UserRepository.checkUniqueEmail(email))
            {
                return "Email has been registered";
            }
            else if (gender.Length == 0)
            {
                return "Gender must be filled";
            }
            else if (address.Length == 0)
            {
                return "Address must be filled";
            }

            else if (!address.StartsWith("Jl"))
            {
                return "Address must Start with Jl";
            }
            else if (password.Length == 0)
            {
                return "Password must be filled";
            }

            else if (!password.Any(char.IsDigit) || !password.Any(char.IsLetter))
            {
                return "Password must be alphanumeric";
            }

            return UserHandler.addUser(name, email, gender, address, password);
        }


        public static string addTukang(string name, string email, string gender, string address, string password)
        {
            if (name.Length < 5 || name.Length > 50)
            {
                return "Name must be filled between 5 - 50 Characters";
            }
            else if (email.Length == 0)
            {
                return "Email must be filled";
            }

            else if (!UserRepository.checkUniqueEmail(email))
            {
                return "Email has been registered";
            }
            else if (gender.Length == 0)
            {
                return "Gender must be filled";
            }
            else if (address.Length == 0)
            {
                return "Address must be filled";
            }

            else if (!address.StartsWith("Jl"))
            {
                return "Address must Start with Jl";
            }
            else if (password.Length == 0)
            {
                return "Password must be filled";
            }

            else if (!password.Any(char.IsDigit) || !password.Any(char.IsLetter))
            {
                return "Password must be alphanumeric";
            }

            return UserHandler.addTukang(name, email, gender, address, password);
        }

        public static string updateUser(int id, string name, string email, string gender, string address, string password)
        {
            if (name.Length < 5 || name.Length > 50)
            {
                return "Name must be filled between 5 - 50 Characters";
            }
            else if (email.Length == 0)
            {
                return "Email must be filled";
            }

            else if (!UserRepository.checkUniqueEmailSpecialCase(id, email))
            {
                return "Email has been registered";
            }
            else if (gender.Length == 0)
            {
                return "Gender must be filled";
            }
            else if (address.Length == 0)
            {
                return "Address must be filled";
            }

            else if (!address.EndsWith(" Street"))
            {
                return "Address must ends with Street";
            }
            else if (password.Length == 0)
            {
                return "Password must be filled";
            }

            else if (!password.Any(char.IsDigit) || !password.Any(char.IsLetter))
            {
                return "Password must be alphanumeric";
            }

            return UserHandler.updateUser(id, name, email, gender, address, password);
        }

        public static bool isUser(string role)
        {
            return role.Equals("User") ? true : false;
        }

        public static bool isAdmin(string role)
        {
            return role.Equals("Admin") ? true : false;
        }
        public static bool isGuest(string role)
        {
            return role.Equals("Guest") ? true : false;
        }

        public static bool isTukang(string role)
        {
            return role.Equals("Tukang") ? true : false;
        }

        public static string loginUser(string email, string password)
        {
            if (email.Length == 0 || password.Length == 0)
            {
                return "Email and Password must be filled";
            }
            if (!UserRepository.correctUser(email, password))
            {
                return "Email or Password must be incorrect";
            }
            return "Succesfully Login";

        }
    }
}