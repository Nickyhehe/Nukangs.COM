using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nukangs.Model;
using Nukangs.Controller;


namespace Nukangs.View
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer c;
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
            if (c == null)
            {
                btnCart.Visible = false;
                btnUpdateProfile.Visible = false;
                btnLogout.Visible = false;
                btnTransaction.Visible = false;
                btnUpdateTukangProfile.Visible = false;
            }
            else if (UserController.isAdmin(c.CustomerRole))
            {
                btnLogin.Visible = false;
                btnCart.Visible = false;
                btnRegister.Visible = false;
                btnUpdateTukangProfile.Visible = false;
               
            }
            else if (UserController.isUser(c.CustomerRole))
            {
                btnLogin.Visible = false;
                btnRegister.Visible = false;
                btnUpdateTukangProfile.Visible = false;
            }
            else if (UserController.isTukang(c.CustomerRole))
            {
                btnLogin.Visible = false;
                btnRegister.Visible = false;
                btnCart.Visible = false;
                btnUpdateProfile.Visible = false;

            }


        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HomePage.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/LoginPage.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RegisterPage.aspx");
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/CartPage.aspx");
        }

        protected void btnTransaction_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/TransactionPage.aspx");
        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/UpdateProfilePage.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            string[] cookies = Request.Cookies.AllKeys;

            foreach (string c in cookies)
            {
                Response.Cookies[c].Expires = DateTime.Now.AddHours(-2);
            }
            Session.Remove("Customer");
            Response.Redirect("~/View/LoginPage.aspx");
        }

        protected void btnUpdateTukangProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/updatetukangaja.aspx");
        }
    }
}
