using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nukangs.Model;

namespace Nukangs.Factory
{
    public class TukangRoleFactory
    {
        public static Role createRole(string name, string image)
        {
            Role a = new Role();
            a.nama_role = name;
            a.role_img = image;
            return a;
        }
    }
}