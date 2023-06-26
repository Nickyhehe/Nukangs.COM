using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nukangs.Controller;
using Nukangs.Model;
using Nukangs.Repository;

namespace Nukangs.View
{
    public partial class UpdateProfilePage : System.Web.UI.Page
    {
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

            if (!IsPostBack)
            {
                Customer user = UserRepository.getUser(c.CustomerID);
                txtName.Text = user.CustomerName;
                txtEmail.Text = user.CustomerEmail;
                rblGender.SelectedValue = user.CustomerGender;
                txtAddress.Text = user.CustomerAddress;
                txtPassword.Text = user.CustomerPassword;
                lblSuccess.Text = "";
            }


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {


            string name = txtName.Text;
            string email = txtEmail.Text;
            string gender = rblGender.SelectedValue;
            string address = txtAddress.Text;
            string password = txtPassword.Text;

            string msg = UserController.updateUser(c.CustomerID, name, email, gender, address, password);
            errName.Text = errEmail.Text = errGender.Text = errAddress.Text = errPassword.Text = "";

            if (msg.Equals("Name must be filled between 5 - 50 Characters"))
            {
                errName.Text = msg;
            }

            else if (msg.Equals("Email has been registered") || msg.Equals("Email must be filled"))
            {
                errEmail.Text = msg;
            }

            else if (msg.Equals("Gender must be filled"))
            {
                errGender.Text = msg;
            }
            else if (msg.Equals("Address must ends with Street") || msg.Equals("Address must be filled"))
            {
                errAddress.Text = msg;
            }
            else if (msg.Equals("Password must be alphanumeric") || msg.Equals("Password must be filled"))
            {
                errPassword.Text = msg;
            }

            else if (msg.Equals("Succesfully Updated"))
            {
                lblSuccess.Text = msg;
            }

        }
    }
}