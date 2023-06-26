using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nukangs.Controller;
using Nukangs.Handler;
using Nukangs.Model;
using Nukangs.Repository;

namespace Nukangs.View
{
    public partial class TukangDetail : System.Web.UI.Page
    {
        public static Tukang tukang;
        public static Customer c;
        public static int TukangID;
        public int i = 0;
        public static double rating;
        public static double remainingStars;
        public static string Tstatus;

        protected void Page_Load(object sender, EventArgs e)
        {
            TukangID = int.Parse(Request.QueryString["TukangID"]);
            tukang = TukangRepository.getTukang(TukangID);
            imgAlbum.Src = tukang.foto_wajah;
            lblName.Text = tukang.nama_tukang;
            lbladdress.Text = "Tukang Address : " + tukang.address;
            rating = Convert.ToDouble(tukang.rating);
            remainingStars = 5 - Math.Ceiling(rating);
            lblstatus2.Text =  tukang.status;
            lblstatus2.CssClass = "status " + tukang.status;
            lblumur.Text = "Tukang Umur : " + tukang.umur.ToString();
            Lbltelp.Text = "No Telefon : " + tukang.no_telp;
            lblstatus.Text = "Status : " + tukang.status;
            lblCost.Text = "Rp. " + Convert.ToInt32(tukang.price).ToString("N", new System.Globalization.CultureInfo("id-ID")) + "/ Hours";
            lblrating.Text = tukang.rating.ToString();


            if (Session["Customer"] == null && Request.Cookies["user_cookie"] == null)
            {
                c = null;
              
                divhours.Visible = false;

                
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
            if(c == null)
            {
                btnAddToCart.Visible = false;
            }

            else if (c != null && !UserController.isUser(c.CustomerRole) || UserController.isTukang(c.CustomerRole))
            {
                lblInpHours.Visible = false;
                divhours.Visible = false;
                btnAddToCart.Visible = false;
            }
            //lblError.Text = albumID.ToString();
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            string msg = CartController.addToCart(lblHours.Text, c.CustomerID, TukangID);
            errmsg.Text = msg;
        }

        protected void btnMinus_Click(object sender, EventArgs e)
        {
            if ((int.Parse(lblHours.Text) - 1) < 0)
            {
                lblHours.Text = "0";
            }
            else
            {
                lblHours.Text = (int.Parse(lblHours.Text) - 1).ToString();
            }

        }

        protected void btnPlus_Click(object sender, EventArgs e)
        {
            lblHours.Text = (int.Parse(lblHours.Text) + 1).ToString();
        }

        protected void btnContactNow_Click(object sender, EventArgs e)
        {
            string phoneNumber = tukang.no_telp.Substring(1); // Ganti dengan nomor telepon WhatsApp yang ingin Anda arahkan

            string url = "https://api.whatsapp.com/send?phone=" +"62"+ phoneNumber;
            string script = "window.location = '" + url + "';";
            ScriptManager.RegisterStartupScript(this, GetType(), "WhatsAppRedirect", script, true);
        }
    }
}