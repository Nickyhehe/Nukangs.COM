using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nukangs.Factory;
using Nukangs.Model;

namespace Nukangs.Repository
{
    public class TransactionHeaderRepository
    {
        public static NukangdbEntities db = new NukangdbEntities();
    
        public static void addTransactionHeader(DateTime date, int customerID, List<CartRepository.cartTukang> cartTukangs)
        {
            TransactionHeader th = TransactionHeaderFactory.createTransactionHeader(date, customerID);
            db.TransactionHeaders.Add(th);
            db.SaveChanges();

            foreach (var x in cartTukangs)
            {
                var td = new TransactionDetail
                {
                    TransactionID = th.TransactionID,
                    TukangID = x.TukangID,
                    hours = x.hours
                };
                db.TransactionDetails.Add(td);
            }

            db.SaveChanges();
        }

        public class TransactionHistory
        {
            public int TransactionID { get; set; }
            public DateTime TransactionDate { get; set; }

            public int CustomerID { get; set; }
            public string CustomerName { get; set; }
            public string Courier { get; set; }
            public string TukangPicture { get; set; }

            public string TukangName { get; set; }

            public int TukangHours { get; set; }

            public int TukangPrice { get; set; }
            public int TotalPrice { get; set; }
        }

        public static List<TransactionHistory> updateHistories(Customer c)
        {
            return (
                from td in db.TransactionDetails
                join th in db.TransactionHeaders on td.TransactionID equals th.TransactionID
                join cu in db.Customers on th.CustomerID equals c.CustomerID
                join a in db.Tukangs on td.TukangID equals a.TukangID
                where cu.CustomerID == c.CustomerID  // Ganti customerID dengan nilai yang sesuai
                select new TransactionHistory
                {
                    TransactionID = td.TransactionID,
                    TransactionDate = (DateTime)th.TransactionDate,
                    CustomerID = (int)cu.CustomerID,
                    CustomerName = cu.CustomerName,
                    TukangName = a.nama_tukang,
                    TukangPicture = a.foto_wajah,
                    TukangHours = (int)td.hours,
                    TukangPrice = (int)a.price,
                    TotalPrice = (int)a.price * (int)td.hours
                }
            ).ToList();
        }

        public static List<TransactionHistory> updateHistoriesAdmin()
        {
            return (
                from td in db.TransactionDetails
                join th in db.TransactionHeaders on td.TransactionID equals th.TransactionID
                join c in db.Customers on th.CustomerID equals c.CustomerID
                join a in db.Tukangs on td.TukangID equals a.TukangID
                select new TransactionHistory
                {
                    TransactionID = td.TransactionID,
                    TransactionDate = (DateTime)th.TransactionDate,
                    CustomerID = (int)c.CustomerID,
                    CustomerName = c.CustomerName,
                    TukangName = a.nama_tukang,
                    TukangPicture = a.foto_wajah,
                    TukangHours = (int)td.hours,
                    TukangPrice = (int)a.price,
                    TotalPrice = (int)a.price * (int)td.hours
                }

            ).ToList();

        }

        public static List<TransactionHistory> updateHistoriesTukang(Tukang t )
        {
            return (
                from td in db.TransactionDetails
                join th in db.TransactionHeaders on td.TransactionID equals th.TransactionID
                join cu in db.Customers on th.CustomerID equals cu.CustomerID
                join a in db.Tukangs on td.TukangID equals a.TukangID
                where t.TukangID == td.TukangID// Ganti customerID dengan nilai yang sesuai
                select new TransactionHistory
                {
                    TransactionID = td.TransactionID,
                    TransactionDate = (DateTime)th.TransactionDate,
                    CustomerID = (int)cu.CustomerID,
                    CustomerName = cu.CustomerName,
                    TukangName = a.nama_tukang,
                    TukangPicture = a.foto_wajah,
                    TukangHours = (int)td.hours,
                    TukangPrice = (int)a.price,
                    TotalPrice = (int)a.price * (int)td.hours
                }
            ).ToList();
        }


    }
}