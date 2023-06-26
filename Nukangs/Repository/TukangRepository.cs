using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nukangs.Factory;
using Nukangs.Model;

namespace Nukangs.Repository
{
    public class TukangRepository
    {
        public static NukangdbEntities db = new NukangdbEntities();
        public static Tukang getTukang(int id)
        {
            return (from x in db.Tukangs where x.TukangID == id select x).FirstOrDefault();
        }


        public static string addTukang(int TukangID, string name, string address, int umur, decimal rating, string telp, string status, string image, int price)
        {
            Tukang a = TukangFactory.createTukang(TukangID, name,address, umur, rating, telp, status, image, price);
            db.Tukangs.Add(a);
            db.SaveChanges();

            return "Succesfully Added";
        }
        public static void removeTukang(int id)
        {
            Tukang a = getTukang(id);
            db.Tukangs.Remove(a);
            db.SaveChanges();
        }
        public static string updateTukang(int tukangID, string name, string address, int umur, decimal rating, string telp, string status, string image, int price)
        {
            Tukang a = getTukang(tukangID);
            a.nama_tukang = name;
            a.address = address;
            a.umur = umur;
            a.rating = rating;
            a.no_telp = telp;
            a.status = status;
            a.foto_wajah = image;
            a.price = price;
            db.SaveChanges();
            return "Succesfully Updated";
        }
        public static List<Tukang> getAllTukangOfRole(int id)
        {
            return (from x in db.Tukangs where x.role_id == id select x).ToList();
        }
        public static Tukang getRoleFromTukangID(int id)
        {
            return (from x in db.Tukangs where x.TukangID == id select x).FirstOrDefault();
        }

        public static int getTukangFromCusName(string name)
        {
            return (from x in db.Tukangs where x.nama_tukang.Equals(name) select x.TukangID).FirstOrDefault();        
        }

        public static Tukang getTukangFromCusNames(string name)
        {
            return (from x in db.Tukangs where x.nama_tukang.Equals(name) select x).FirstOrDefault();
        }
    }


}