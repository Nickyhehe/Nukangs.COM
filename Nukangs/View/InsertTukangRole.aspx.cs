using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nukangs.Controller;
using System.IO;

namespace Nukangs.View
{
    public partial class InsertTukangRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string msg = "";
            errName.Text = "";
            errArtistImage.Text = "";

            if (fuArtistImage.HasFile)
            {
                msg = TukangRoleController.addRole(name, fuArtistImage.FileName, (double)fuArtistImage.PostedFile.ContentLength);
            }
            else
            {
                errArtistImage.Text = "File must be choosen";
            }

            if (msg.Equals("Role name must be filled") || msg.Equals("Role name must be unique"))
            {
                errName.Text = msg;
            }

            if (msg.Equals("File must be .png or .jpeg or .jpg or .jfif") || msg.Equals("File must be lower than 2MB"))
            {
                errArtistImage.Text = msg;
            }

            if (msg.Equals("Succesfully Added Tukang Role"))
            {
                successUpload.Text = msg;
                Response.Redirect("../View/HomePage.aspx");
            }
        }

    }
}