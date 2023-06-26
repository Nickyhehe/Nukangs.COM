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
    public partial class TukangPage : System.Web.UI.Page
    {
        public static int RoleID;
        public static Role a;
        public static Customer c;

        public void updateRepeater()
        {

            rptAlbums.DataSource = TukangRepository.getAllTukangOfRole(RoleID);
            rptAlbums.DataBind();
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                RoleID = int.Parse(Request.QueryString["id"]);
                a = TukangRoleRepository.getRole(RoleID);
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
                foreach (RepeaterItem item in rptAlbums.Items)
                {
                    Button btnDelete = (Button)item.FindControl("btnDelete");
                    btnDelete.Visible = false;

                    Button btnUpdate = (Button)item.FindControl("btnUpdate");
                    btnUpdate.Visible = false;
                }
                btnInsert.Visible = false;
            }


        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertNewTukang.aspx?id=" + RoleID);
        }


        protected void rptAlbums_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btnUpdate_Command(object sender, CommandEventArgs e)
        {
            int TukangID = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("~/View/UpdateTukangPage.aspx?id=" + TukangID + "&RoleID=" + RoleID);
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            int TukangID = Convert.ToInt32(e.CommandArgument.ToString());
            Tukang t = TukangRepository.getTukang(TukangID);
            int TukangIDinCus = UserRepository.getTukangbyName(t.nama_tukang).CustomerID;
            UserRepository.removeTukang(TukangIDinCus);
            TukangRepository.removeTukang(TukangID);
            updateRepeater();
        }

        protected void btnView_Command(object sender, CommandEventArgs e)
        {
            int TukangID = Convert.ToInt32(e.CommandArgument.ToString());

            if (c == null)
            {
                Response.Redirect("~/View/TukangDetail.aspx?TukangID=" + TukangID + "&customerID=" + null);
            }
            else
            {
                Response.Redirect("~/View/TukangDetail.aspx?TukangID=" + TukangID + "&customerID=" + c.CustomerID);
            }

        }
    }
}