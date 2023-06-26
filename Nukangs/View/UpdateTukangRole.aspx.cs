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
    public partial class UpdateTukangRole : System.Web.UI.Page
    {
        public string tempName = "";
        public static Role a;
        public static int RoleID;
        public static NukangdbEntities db = new NukangdbEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RoleID = int.Parse(Request.QueryString["id"]);

                a = TukangRoleRepository.getRole(RoleID);
                tempName = a.nama_role;
                txtName.Text = a.nama_role;
               
                
            }
            RoleID = int.Parse(Request.QueryString["id"]);
            a = TukangRoleRepository.getRole(RoleID);
            tempName = a.nama_role;
        }

        public static string getAlbumimg()
        {
            return (from x in db.Roles where x.role_id == RoleID select x.role_img).FirstOrDefault();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string msg = "";
            errName.Text = "";
            errArtistImage.Text = "";


            if (fuArtistImage.HasFile)
            {
                msg = TukangRoleController.updateRole(a.role_id, txtName.Text, fuArtistImage.FileName,
                (double)fuArtistImage.PostedFile.ContentLength, tempName);
             
            }
            else

            {
              
                msg = TukangRoleController.updateRole(a.role_id, txtName.Text, "../Roles/" + a.role_img, 0, tempName);
            }


            if (msg.Equals("Role name must be filled") || msg.Equals("Role name must be unique"))
            {
                errName.Text = msg;
            }

            if (msg.Equals("File must be .png or .jpeg or .jpg or .jfif") || msg.Equals("File must be lower than 2MB"))
            {
                errArtistImage.Text = msg;
            }

            if (msg.Equals("Succesfully Updated"))
            {
                successUpload.Text = msg;
                Response.Redirect("~/View/HomePage.aspx");
            }
        }
    }

}