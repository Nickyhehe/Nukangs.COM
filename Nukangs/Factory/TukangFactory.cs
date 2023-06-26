using System;
using System.Collections.Generic;
using System.Linq;
using Nukangs.Model;
using System.Web;

namespace Nukangs.Factory
{
    public class TukangFactory
    {
        public static Tukang createTukang(int TukangID ,string name, string address, int umur, decimal rating, string telp,string status, string image, int price)
        {
            Tukang a = new Tukang();
            a.role_id = TukangID;
            a.nama_tukang = name;
            a.address = address;
            a.umur = umur;
            a.rating = rating;
            a.no_telp = telp;
            a.status = status;
            a.foto_wajah = image;
            a.price = price;

            return a;
        }
    }
}