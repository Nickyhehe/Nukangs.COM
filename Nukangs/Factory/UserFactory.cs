using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nukangs.Model;

namespace Nukangs.Factory
{
    public class UserFactory
    {

        public static Customer createUser(string name, string email, string gender, string address, string password)
        {
            Customer c = new Customer();
            c.CustomerName = name;
            c.CustomerEmail = email;
            c.CustomerGender = gender;
            c.CustomerAddress = address;
            c.CustomerPassword = password;
            c.CustomerRole = "User";
            return c;
        }

        public static Customer createTukang(string name, string email, string gender, string address, string password)
        {
            Customer c = new Customer();
            c.CustomerName = name;
            c.CustomerEmail = email;
            c.CustomerGender = gender;
            c.CustomerAddress = address;
            c.CustomerPassword = password;
            c.CustomerRole = "Tukang";
            return c;
        }
    }
}