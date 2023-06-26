using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nukangs.Handler;
using System.IO;
using Nukangs.Repository;

namespace Nukangs.Controller
{
    public class TukangRoleController
    {
        public static string addRole(string name, string fileName, double size)
        {
            string fileExtension = Path.GetExtension(fileName);
            double fileSize = (double)size / 1000000;
            //.png
            if (fileExtension != ".png" && fileExtension != ".jpeg" && fileExtension != ".jpg" &&
                fileExtension != ".jfif")
            {
                return "File must be .png or .jpeg or .jpg or .jfif";
            }

            if (fileSize > 2)
            {
                return "File must be lower than 2MB";
            }

            if (name.Length == 0)
            {
                return "Role name must be filled";
            }

            if (!TukangRoleRepository.checkUniqueRole(name))
            {
                return "Role name must be unique";
            }

            return TukangRoleHandler.addRole(name, "../Roles/" + fileName);

        }

        public static string updateRole(int id, string name, string fileName, double size, string tempName)
        {
            string fileExtension = Path.GetExtension(fileName);
            double fileSize = (double)size / 1000000;
            //.png


            if (name.Equals(tempName) && fileName.Contains("Roles"))
            {
                return TukangRoleHandler.updateRole(id, name, fileName);
            }


            if (fileExtension != ".png" && fileExtension != ".jpeg" && fileExtension != ".jpg" &&
                fileExtension != ".jfif")
            {
                return "File must be .png or .jpeg or .jpg or .jfif";
            }

            if (fileSize > 2)
            {
                return "File must be lower than 2MB";
            }

            if (name.Length == 0)
            {
                return "Artist name must be filled";
            }


            if (name.Equals(tempName))
            {
                return TukangRoleHandler.updateRole(id, name, "../Roles/" + fileName);
            }

            if (!TukangRoleRepository.checkUniqueRole(name))
            {
                return "Artist name must be unique";
            }

            return TukangRoleHandler.updateRole(id, name, "../Roles/" + fileName);

        }
    }
}