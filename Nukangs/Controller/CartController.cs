using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nukangs.Handler;
using Nukangs.Model;
using Nukangs.Repository;

namespace Nukangs.Controller
{
    public class CartController
    {
        public static string addToCart(string hours, int customerID, int TukangID)
        {
            if (hours.ToString().Equals(""))
            {
                return "Quantity must be filled";
            }

            if (int.Parse(hours) == 0)
            {
                return "Quantity can not be zero";
            }

         
            return CartHandler.addToCart(customerID, TukangID, int.Parse(hours));
        }
        public static string validateHoursAndStatus(int qty, string status)
        {
            if (qty > 12)
            {
                return "Max 12 jam Kerja";
            }
            if (status.Equals("Booked")){
                return "Cannot Check Out Because Tukang Status is Booked";
            }
            return "Succesfull";
        }
    }
}