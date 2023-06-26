using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nukangs.Controller;
using Nukangs.Repository;
using Nukangs.Model;
using static Nukangs.Repository.CartRepository;

namespace Nukangs.View
{
    public partial class CartPage : System.Web.UI.Page
    {
        public static List<Tukang> tukangs = null;
        public static Customer c;
        public static List<Cart> carts;


        public void updateRepeater()
        {
            rptCarts.DataSource = carts;
            rptCarts.DataBind();
        }
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

            carts = CartRepository.getAllCartFromCustomerID(c.CustomerID);
       
            lblttlall.Text = "Total : " + GrandTotalValue().ToString("N", new System.Globalization.CultureInfo("id-ID"));
            updateRepeater();
        }

        public static int GrandTotalValue()
        {
            var GTV = (from td in db.Carts
                       join a in db.Tukangs on td.TukangID equals a.TukangID
                       where td.CustomerID == c.CustomerID
                       select td.hours * a.price).Sum();

            return Convert.ToInt32(GTV);
        }
        public static string calculatesubtotal(int price, int hours)
        {
            return (price * hours).ToString("N", new System.Globalization.CultureInfo("id-ID"));
        }

        public static string getTukangImageFromID(int id)
        {
            return (TukangRepository.getTukang(id)).foto_wajah.ToString();
        }

        public static string getTukangNameFromID(int id)
        {
            return (TukangRepository.getTukang(id)).nama_tukang.ToString();
        }

        public static string getTukangPriceFromID(int id)
        {
            return (TukangRepository.getTukang(id)).price.ToString();
        }

        //terakhir gw sampe sini udh kemaleman si charles anjing wehh, pokonya note : gw lagi pengen dapetin status tukangnya pas mau checkout, terus status tukang diubah jadi Booked kalo dipesan thx
        public static string getStatusFromID(int id)
        {
            return (TukangRepository.getTukang(id)).status.ToString();
        }


        protected void rptCarts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }


        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            string msg = "";
            
            lblError.Text = "";
            
            foreach (Cart c in carts)
            {
                msg = CartController.validateHoursAndStatus(Convert.ToInt32(c.hours), getStatusFromID(c.TukangID));
                if (msg.Equals("Max 12 jam Kerja"))
                {
                    lblError.Text = getTukangNameFromID(c.TukangID) + " is cannot be check out because max Work hours is 12 ";
                    return;
                }
                if(msg.Equals("Cannot Check Out Because Tukang Status is Booked"))
                {
                    lblError.Text = getTukangNameFromID(c.TukangID) + " Cannot be check Out Becaus Tukang Status is Booked Now";
                    return;
                }
                if (getStatusFromID(c.TukangID).Equals("Ready"))
                {
                    Tukang t = getTukangFromCartTukang(c.TukangID);
                    t.status = "Booked";
                   
                    db.SaveChanges();
                }
                
            }
            List<cartTukang> cartAlbums = GetCartTukangs(c.CustomerID);
            TransactionHeaderRepository.addTransactionHeader(DateTime.Now, c.CustomerID, cartAlbums);
            
            CartRepository.removeAllFromCart(c.CustomerID);
            carts = CartRepository.getAllCartFromCustomerID(c.CustomerID);
            updateRepeater();



            Response.Redirect("~/View/HomePage.aspx");
        }

        protected void btnRemove_Command(object sender, CommandEventArgs e)
        {
            int albumID = Convert.ToInt32(e.CommandArgument.ToString());
            CartRepository.removeAlbumFromCart(albumID);

            carts = CartRepository.getAllCartFromCustomerID(c.CustomerID);
            lblttlall.Text = "Total : " + GrandTotalValue().ToString("N", new System.Globalization.CultureInfo("id-ID"));
            updateRepeater();
        }

        protected void rptCarts_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HomePage.aspx");
        }
    }
}