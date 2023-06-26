using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nukangs.Factory;
using Nukangs.Model;

namespace Nukangs.Repository
{
    public class CartRepository
    {
        public static NukangdbEntities db = new NukangdbEntities();
        public static Cart getCartByTukangIDAndCustomerID(int customerID, int tukangID)
        {
            return (from x in db.Carts where x.TukangID == tukangID && x.CustomerID == customerID select x).FirstOrDefault();
        }

        public static string addToCart(int customerID, int albumID, int qty)
        {
            Cart c = getCartByTukangIDAndCustomerID(customerID, albumID);
            if (c == null)
            {
                Cart newCart = CartFactory.createCart(customerID, albumID, qty);
                db.Carts.Add(newCart);
            }
            else
            {
                c.hours += qty;
            }
            db.SaveChanges();
            return "Succesfully Addded to Cart";
        }

        public static List<Cart> getAllCartFromCustomerID(int id)
        {
            return (from x in db.Carts where x.CustomerID == id select x).ToList();
        }

        public static Cart getTukangFromCart(int id)
        {
            return (from x in db.Carts where x.TukangID == id select x).FirstOrDefault();
        }

        public static Tukang getTukangFromCartTukang(int id)
        {
            return (from x in db.Tukangs where x.TukangID == id select x).FirstOrDefault();
        }

        public static void removeAlbumFromCart(int id)
        {
            Cart c = getTukangFromCart(id);
            db.Carts.Remove(c);
            db.SaveChanges();
        }

        public static Cart getCart(int id)
        {
            return (from x in db.Carts where x.CustomerID == id select x).FirstOrDefault();
        }

        public static void removeAllFromCart(int id)
        {
            while (getCart(id) != null)
            {
                Cart rmvCart = getCart(id);
                Tukang t = TukangRepository.getTukang(rmvCart.TukangID);
                db.Carts.Remove(rmvCart);
                db.SaveChanges();
            }
        }

        public class cartTukang
        {
            public int TukangID { get; set; }
            public string TukangName { get; set; }
            public int price { get; set; }
            public int hours { get; set; }

        }

        public static List<cartTukang> GetCartTukangs(int customerID)
        {
            var cartdata = (from x in db.Carts
                            where x.CustomerID == customerID
                            join t in db.Tukangs on x.TukangID equals t.TukangID
                            select new
                            {
                                x.TukangID,
                                t.nama_tukang,
                                t.price,
                                x.hours
                            }).ToList();

            var cartTukangs = cartdata.Select(x => new cartTukang
            { 
                TukangID = x.TukangID,
                TukangName = x.nama_tukang,
                price = Convert.ToInt32(x.price),
                hours = Convert.ToInt32(x.hours)
            }).ToList();

            return cartTukangs;

        }


    }
}