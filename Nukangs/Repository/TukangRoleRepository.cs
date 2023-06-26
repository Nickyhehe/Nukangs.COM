using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nukangs.Factory;
using Nukangs.Model;

namespace Nukangs.Repository
{
    public class TukangRoleRepository
    {
        public static NukangdbEntities db = new NukangdbEntities();
        public static List<Role> getAllRole()
        {
            return (from x in db.Roles select x).ToList();
        }

        public static string addRole(string name, string image)
        {
            Role a = TukangRoleFactory.createRole(name, image);
            db.Roles.Add(a);
            db.SaveChanges();

            return "Succesfully Added Artist";
        }

        public static bool checkUniqueRole(string name)
        {
            return (from x in db.Roles where x.nama_role.Equals(name) select x).FirstOrDefault() == null;
        }

        public static Role getRole(int id)
        {
            return (from x in db.Roles where x.role_id == id select x).FirstOrDefault();
        }
        public static void removeRole(int id)
        {
            Role a = getRole(id);
            db.Roles.Remove(a);
            db.SaveChanges();
        }
        public static string updateRole(int id, string name, string image)
        {
            Role a = getRole(id);
            a.nama_role = name;
            a.role_img = image;
            db.SaveChanges();

            return "Succesfully Updated";
        }
    }
}