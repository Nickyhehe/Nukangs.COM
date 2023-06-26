using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nukangs.Model;

namespace Nukangs.Factory
{
    public class TransactionHeaderFactory
    {

        public static TransactionHeader createTransactionHeader(DateTime date, int customerID)
        {
            TransactionHeader th = new TransactionHeader();
            th.TransactionDate = date;
            th.CustomerID = customerID;

            return th;
        }
    }
}