using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nukangs.Handler;
using Nukangs.Model;
using Nukangs.Controller;
using Nukangs.Repository;
using static Nukangs.Repository.TransactionHeaderRepository;

namespace Nukangs.View
{
    public partial class TransactionPage : System.Web.UI.Page
    {
        public List<TransactionHistory> histories;
        public static Customer c;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Customer"] == null && Request.Cookies["user_cookie"] == null)
            {
                c = null;
            }
            else
            {
                NukangdbEntities db = new NukangdbEntities();
                if (Session["Customer"] == null)
                {
                    var id = int.Parse(Request.Cookies["user_cookie"].Value);
                    c = (from x in db.Customers where x.CustomerID == id select x).FirstOrDefault();
                    Session["Customer"] = c;
                }
                else
                {
                    c = (Customer)Session["Customer"];
                }
            }

            if (UserController.isUser(c.CustomerRole))
            {
                rptTransactionHistory.DataSource = TransactionHandler.updateHistories(c);
                rptTransactionHistory.DataBind();
            }
            if (UserController.isAdmin(c.CustomerRole))
            {
                rptTransactionHistory.DataSource = TransactionHandler.getAllTransaction();
                rptTransactionHistory.DataBind();
            }
            if (UserController.isTukang(c.CustomerRole))
            {
                Tukang t = TukangRepository.getTukangFromCusNames(c.CustomerName);
                rptTransactionHistory.DataSource = TransactionHandler.updateHistoriesTukang(t);
                rptTransactionHistory.DataBind();
            }
            

            
        }


     
    }
}