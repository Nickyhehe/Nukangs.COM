using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nukangs.Repository;

namespace Nukangs.Handler
{
    public class TukangHandler
    {
        public static string addTukang(int TukangID, string name, string address, int umur, decimal rating, string telp, string status, int price, string image)
        {
            return TukangRepository.addTukang(TukangID, name, address,umur, rating, telp, status, image,price);
        }
        public static string updateTukang(int TukangID, string name, string address, int umur, decimal rating, string telp, string status, string image, int price)
        {
            return TukangRepository.updateTukang(TukangID, name, address, umur,rating , telp, status, image, price);
        }
    }
}