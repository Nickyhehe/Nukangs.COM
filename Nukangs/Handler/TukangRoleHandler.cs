using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nukangs.Repository;

namespace Nukangs.Handler
{
    public class TukangRoleHandler
    {
        public static string addRole(string name, string image)
        {
            return TukangRoleRepository.addRole(name, image);
        }

        public static string updateRole(int id, string name, string image)
        {
            return TukangRoleRepository.updateRole(id, name, image);
        }
    }
}