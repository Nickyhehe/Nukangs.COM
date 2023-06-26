using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nukangs.Controller;

namespace Nukangs.View
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string gender = rblGender.SelectedValue;
            string address = txtAddress.Text;
            string password = txtPassword.Text;

            string msg = UserController.addUser(name, email, gender, address, password);
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
            else if (msg.Equals("Address must Start with Jl") || msg.Equals("Address must be filled"))
            {
                errAddress.Text = msg;
            }
            else if (msg.Equals("Password must be alphanumeric") || msg.Equals("Password must be filled"))
            {
                errPassword.Text = msg;
            }

            else if (msg.Equals("Succesfully Added"))
            {
                lblSuccess.Text = msg;
            }

        }
    }
}