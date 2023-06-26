using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nukangs.Controller;
using Nukangs.Repository;
using Nukangs.Model;
using System.Web.UI.HtmlControls;

namespace Nukangs.View
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

  
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            bool isRemember = cbRemember.Checked;
            lblError.Text = "";

            string msg = UserController.loginUser(email, password);

            if (msg.Equals("Succesfully Login"))
            {
                Customer c = UserRepository.getCustomer(email, password);
                Session["Customer"] = c;
                if (isRemember)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = c.CustomerID.ToString();
                    cookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookie);
                }
                Response.Redirect("~/View/HomePage.aspx");

            }

            lblError.Text = msg;

        }
    }
}