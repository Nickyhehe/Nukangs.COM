using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nukangs.Model;
using Nukangs.Factory;


namespace Nukangs.Repository
{
    public class UserRepository
    {
        public static NukangdbEntities db = new NukangdbEntities();


        public static Customer getUser(int id)
        {
            return (from x in db.Customers where x.CustomerID == id select x).FirstOrDefault();
        }
        public static string addUser(string name, string email, string gender, string address, string password)
        {
            Customer c = UserFactory.createUser(name, email, gender, address, password);
            db.Customers.Add(c);
            db.SaveChanges();

            return "Succesfully Added";
        }

        public static string addTukang(string name, string email, string gender, string address, string password)
        {
            Customer c = UserFactory.createTukang(name, email, gender, address, password);
            db.Customers.Add(c);
            db.SaveChanges();

            return "Succesfully Added";
        }

        public static string updateUser(int id, string name, string email, string gender, string address, string password)
        {
            Customer c = getUser(id);
            c.CustomerName = name;
            c.CustomerEmail = email;
            c.CustomerGender = gender;
            c.CustomerAddress = address;
            c.CustomerPassword = password;
            db.SaveChanges();

            return "Succesfully Updated";
        }
        public static Customer getCustomer(string email, string password)
        {
            return (from x in db.Customers where x.CustomerEmail.Equals(email) && x.CustomerPassword.Equals(password) select x).FirstOrDefault();
        }
        public static void removeTukang(int id)
        {
            Customer c = getUser(id);
            db.Customers.Remove(c);
            db.SaveChanges();

        }
        public static bool checkUniqueEmail(string email)
        {
            return (from x in db.Customers where x.CustomerEmail == email select x).FirstOrDefault() == null;
        }
        public static bool checkUniqueEmailSpecialCase(int id, string email)
        {
            return (from x in db.Customers where x.CustomerID != id && x.CustomerEmail == email select x).FirstOrDefault() == null;
        }

        public static bool correctUser(string email, string password)
        {
            return (from x in db.Customers where x.CustomerEmail.Equals(email) && x.CustomerPassword.Equals(password) select x).FirstOrDefault() != null;
        }

        public static Customer getTukangbyName(string name)
        {
            return (from x in db.Customers where x.CustomerName.Equals(name) select x).FirstOrDefault();
        }
        
        public static void UpdateTukanginCustomer(string email, string password, string name, string tempname)
        {
            Customer c = getTukangbyName(name);
            c.CustomerEmail = email;
            c.CustomerPassword = password;
            c.CustomerName = tempname;
            db.SaveChanges();

        }

        
    }
}