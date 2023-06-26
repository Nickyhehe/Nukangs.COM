using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Nukangs.Handler;

namespace Nukangs.Controller
{
    public class TukangController
    {
        public static string addTukang(int TukangID, string name, string address, int umur, decimal rating, string telp, string status,int price, string fileName, double size)
        {
            string fileExtension = Path.GetExtension(fileName);
            double fileSize = (double)size / 1000000;
            //.png
            if (name.Length == 0)
            {
                return "Tukang name must be filled";
            }
            if (name.Length > 50)
            {
                return "Tukang name must be smaller than 50 Characters";
            }
            if (address.Length == 0)
            {
                return "Tukang Address must be filled";
            }
            if (rating.Equals(""))
            {
                return "Rating must be filled";
            }
            if(rating > 5)
            {
                return "Rating must be below 5";
            }

            if (status.Equals(""))
            {
                return "Status must be filled";
            }
            if (umur.Equals(""))
            {
                return "Umur must be filled";
            }
            if (telp.Equals(""))
            {
                return "Phone Number must be filled";
            }
            if(telp.Length < 12 && telp.Length > 15)
            {
                return "Phone number Length must be Between 12 - 15 Digit";
            }
            if (price.Equals(""))
            {
                return "Price must be filled";
            }
            if(price.ToString().Any(char.IsLetter))
            {
                return "Please dont input string";
            }
            if(price < 10000)
            {
                return "Price must Above Rp. 10.000";
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
            return TukangHandler.addTukang(TukangID, name, address, umur, rating, telp,status, price, "../Tukang/" + fileName);
        }

        public static string updateTukang(int TukangID, string name, string address, int umur, decimal rating, string telp, string status ,string fileName, double size, int price)
        {
            string fileExtension = Path.GetExtension(fileName);
            double fileSize = (double)size / 1000000;
            //.png
            if (name.Length == 0)
            {
                return "Tukang name must be filled";
            }
            if (name.Length > 50)
            {
                return "Tukang name must be smaller than 50 Characters";
            }
            if (address.Length == 0)
            {
                return "Tukang address must be filled";
            }
            if (address.Length > 250)
            {
                return "Tukang address must be smaller than 250 Characters";
            }
            if (umur.ToString().Equals(""))
            {
                return "Umur must be filled";
            }
            if (telp.Equals(""))
            {
                return "Phone number must be filled";
            }
            if (price.Equals(""))
            {
                return "Price must be filled";
            }
            if (price.ToString().Any(char.IsLetter))
            {
                return "Please dont input string";
            }
            if (price < 10000)
            {
                return "Price must Above Rp. 10.000";
            }

            if (rating.ToString().Equals(""))
            {
                return "Rating must be filled";
            }
            if (status.Equals(""))
            {
                return "Status must be filled";
            }

            if (fileName.Contains("Tukang"))
            {
                
                return TukangHandler.updateTukang(TukangID, name, address, umur, rating, telp, status, fileName, price);
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

            return TukangHandler.updateTukang(TukangID, name, address, umur, rating, telp, status, "../Tukang/" + fileName, price);
        }
    }
}