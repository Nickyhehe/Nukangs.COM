using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nukangs.Model;

namespace Nukangs.Factory
{
    public class CartFactory
    {
        public static Cart createCart(int customerID, int TukangID, int hours)
        {
            Cart c = new Cart();
            c.CustomerID = customerID;
            c.TukangID = TukangID;
            c.hours = hours;
            return c;

        }
    }
}