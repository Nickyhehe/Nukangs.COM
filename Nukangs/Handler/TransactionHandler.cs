using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nukangs.Model;
using Nukangs.Repository;
using static Nukangs.Repository.TransactionHeaderRepository;

namespace Nukangs.Handler
{
    public class TransactionHandler
    {
        public static void addTransactionHeader(DateTime date, int customerID, List<CartRepository.cartTukang> cartTukang)
        {
            TransactionHeaderRepository.addTransactionHeader(date, customerID, cartTukang);
        }
        public static List<TransactionHistory> updateHistories(Customer c)
        {
            return TransactionHeaderRepository.updateHistories(c);
        }

        public static List<TransactionHistory> updateHistoriesTukang(Tukang t)
        {
            return TransactionHeaderRepository.updateHistoriesTukang(t);
        }

        public static List<TransactionHistory> getAllTransaction()
        {
            return TransactionHeaderRepository.updateHistoriesAdmin();
        }
    }
}