using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nukangs.Repository;

namespace Nukangs.Handler
{
    public class UserHandler
    {
        public static string addUser(string name, string email, string gender, string address, string password)
        {
            return UserRepository.addUser(name, email, gender, address, password);
        }

        public static string addTukang(string name, string email, string gender, string address, string password)
        {
            return UserRepository.addTukang(name, email, gender, address, password);
        }

        public static string updateUser(int id, string name, string email, string gender, string address, string password)
        {
            return UserRepository.updateUser(id, name, email, gender, address, password);
        }
    }
}