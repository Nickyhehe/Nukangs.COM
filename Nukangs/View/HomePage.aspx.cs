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
    public partial class HomePage : System.Web.UI.Page
    {
        public static List<Role> Roles;

        public void updateRepeater()
        {

            rptArtists.DataSource = TukangRoleRepository.getAllRole();
            rptArtists.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            Customer c;

            if (!IsPostBack)
            {
                updateRepeater();
            }


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

            if (c == null || UserController.isUser(c.CustomerRole) || UserController.isTukang(c.CustomerRole))
            {
                foreach (RepeaterItem item in rptArtists.Items)
                {
                    Button btnDelete = (Button)item.FindControl("btnDelete");
                    btnDelete.Visible = false;

                    Button btnUpdate = (Button)item.FindControl("btnUpdate");
                    btnUpdate.Visible = false;
                }
                btnInsert.Visible = false;
            }

            Roles = TukangRoleRepository.getAllRole();

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertTukangRole.aspx");
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            int ArtistID = Convert.ToInt32(e.CommandArgument.ToString());
            //Label1.Text = ArtistID.ToString();
            TukangRoleRepository.removeRole(ArtistID);
            updateRepeater();
        }

        protected void rptArtists_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btnUpdate_Command(object sender, CommandEventArgs e)
        {
            int RoleID = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("~/View/UpdateTukangRole.aspx?id=" + RoleID);
        }

        protected void btnView_Command(object sender, CommandEventArgs e)
        {
            int RoleID = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("~/View/TukangPage.aspx?id=" + RoleID);
        }
    }
}