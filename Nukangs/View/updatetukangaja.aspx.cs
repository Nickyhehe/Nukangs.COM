﻿using System;
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
    public partial class updatetukangaja : System.Web.UI.Page
    {
        public static Tukang a;
        public static int TukangID;
        public static int RoleID;
        public static NukangdbEntities db = new NukangdbEntities();
        public static Customer c;
        public static int tempid;
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
            tempid = c.CustomerID;
            TukangID = TukangRepository.getTukangFromCusName(c.CustomerName);

            
            //lblSuccessUpload.Text = RoleID.ToString();
            if (!IsPostBack)
            {
                a = TukangRepository.getTukang(TukangID);
                
                txtName.Text = a.nama_tukang;
                txtaddress.Text = a.address;
                Txtrating.Text = a.rating.ToString();
                Txtstatus.Text = a.status;
                Txttelp.Text = a.no_telp;
                Txtumur.Text = a.umur.ToString();
                Txtprice.Text = a.price.ToString();
                txtEmail.Text = UserRepository.getTukangbyName(a.nama_tukang).CustomerEmail;
                txtPassword.Text = UserRepository.getTukangbyName(a.nama_tukang).CustomerPassword;

            }
        }
        public static string getAlbumimg()
        {
            return (from x in db.Tukangs where x.TukangID == TukangID select x.foto_wajah).FirstOrDefault();
        }
        protected void btnUpdateTukang_Click(object sender, EventArgs e)
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
            errName.Text = erraddress.Text = errName.Text = errImageTukang.Text = errrating.Text = errstatus.Text = errtelp.Text = errumur.Text = "";
            if (fuImageAlbum.HasFile)
            {
                UserRepository.UpdateTukanginCustomer(email, password, a.nama_tukang, name);
                //(int TukangID, string name, string address, int umur, decimal rating, string telp, string status, string fileName, double size
                msg = TukangController.updateTukang(TukangID, name, address, umur, rating, telp, status, fuImageAlbum.FileName, fuImageAlbum.PostedFile.ContentLength, price);

            }
            else
            {
                UserRepository.UpdateTukanginCustomer(email, password, a.nama_tukang, name);
                msg = TukangController.updateTukang(TukangID, name, address, umur, rating, telp, status, getAlbumimg(), 0, price);

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

            if (msg.Equals("File must be .png or .jpeg or .jpg or .jfif") || msg.Equals("File must be lower than 2MB"))
            {
                errImageTukang.Text = msg;
            }
            if (msg.Equals("Price must Above Rp. 10.000") || msg.Equals("Please dont input string") || msg.Equals("Price must be filled"))
            {
                errprice.Text = msg;
            }
            if (msg.Equals("Succesfully Updated"))
            {
               
                lblSuccessUpload.Text = msg;
                Response.Redirect("../View/HomePage.aspx");
            }

        }
    }
}