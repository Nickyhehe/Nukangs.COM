using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nukangs.Controller;
using Nukangs.Repository;
namespace Nukangs.View
{
    public partial class InsertNewTukang : System.Web.UI.Page
    {
        public static int TukangID;
        protected void Page_Load(object sender, EventArgs e)
        {
            TukangID = int.Parse(Request.QueryString["id"]);
        }

        protected void btnAddAlbum_Click(object sender, EventArgs e)
        {
            //int TukangID, string name, string address, int umur, decimal rating, string telp,string status, string image
            string name = txtName.Text;
            string address = txtaddress.Text;
            int umur = int.Parse(Txtumur.Text);
            decimal rating = decimal.Parse(Txtrating.Text);
            string telp = Txttelp.Text;
            string status = Txtstatus.Text;
            int price = int.Parse(Txtprice.Text);
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            
            

            string msg = "";
            errName.Text = erraddress.Text = errName.Text = errImageTukang.Text = errrating.Text = errstatus.Text = errtelp.Text = errumur.Text = errprice.Text = "" ;
            if (fuImageAlbum.HasFile)
            {
                //(int TukangID, string name, string address, int umur, decimal rating, string telp, string status, string fileName, double size
                msg = TukangController.addTukang(TukangID,name, address, umur, rating,telp, status,price, fuImageAlbum.FileName, fuImageAlbum.PostedFile.ContentLength);
            }
            else
            {
                errImageTukang.Text = "File Upload Image Must be Choosen";
            }

            if (msg.Equals("Tukang name must be filled") || msg.Equals("Tukang name must be smaller than 50 Characters"))
            {
                errName.Text = msg;
            }
            if (msg.Equals("Tukang Address must be filled"))
            {
                erraddress.Text = msg;
            }
            if (msg.Equals("Rating must be filled"))
            {
                errrating.Text = msg;
            }
            if (msg.Equals("Status must be filled"))
            {
                errstatus.Text = msg;
            }
            if (msg.Equals("Umur must be filled"))
            {
                errumur.Text = msg;
            }
            if (msg.Equals("Phone Number must be filled"))
            {
                errtelp.Text = msg;
            }
            if(msg.Equals("Price must be filled") || msg.Equals("Please dont input string") || msg.Equals("Price must Above Rp. 10.000"))
            {
                errprice.Text = msg;
            }
            if (msg.Equals("File must be .png or .jpeg or .jpg or .jfif") || msg.Equals("File must be lower than 2MB"))
            {
                errImageTukang.Text = msg;
            }
            if(msg.Equals("Price must Above Rp. 10.000") || msg.Equals("lease dont input string") || msg.Equals("Price must be filled"))
            {
                errprice.Text = msg;
            }
            if (msg.Equals("Succesfully Added"))
            {
                string msg2 = UserController.addTukang(name, email, "Male", address, password);
                if (!msg2.Equals("Succesfully Added"))
                {
                    lblSuccessUpload.Text = msg2;

                }
                else
                {
                    Response.Redirect("~/View/TukangPage.aspx?id=" + TukangID);
                    lblSuccessUpload.Text = msg;
                }
              
            }
           
        }
    }
}