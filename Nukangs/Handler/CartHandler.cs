using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nukangs.Repository;

namespace Nukangs.Handler
{
    public class CartHandler
    {
        public static string addToCart(int customerID, int albumID, int qty)
        {
            return CartRepository.addToCart(customerID, albumID, qty);
        }
    }
}