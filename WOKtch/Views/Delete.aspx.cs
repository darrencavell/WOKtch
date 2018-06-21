using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.Handlers;
using WOKtch.Models;

namespace WOKtch.Views
{
    public partial class Delete : System.Web.UI.Page
    {
        int ProductId, UserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("Login.aspx");
            else { 
                User u = (User)Session["user"];
                if(u.UserRole == 0) Response.Redirect("Home.aspx");
            }

            deleteValue();
        }
        // DELETE BY GETTING PARAMETER FROM URL
        private void deleteValue() {
            if (Request.QueryString["productId"] != null)
            {
                ProductId = Int32.Parse(Request.QueryString["productId"]);

                Product p = ProductHandler.GetById(ProductId);
                if (System.IO.File.Exists(Server.MapPath("~/") + p.ProductImage))
                { System.IO.File.Delete(Server.MapPath("~/") + p.ProductImage); }

                ReviewHandler.Delete(ProductId);
                ProductHandler.Delete(ProductId);

                Response.Redirect("Home.aspx");
            }else if (Request.QueryString["userId"] != null)
            {
                UserId = Int32.Parse(Request.QueryString["userId"]);

                User u = UserHandler.GetById(UserId);
                if (System.IO.File.Exists(Server.MapPath("~/") + u.UserProfilePicture))
                { System.IO.File.Delete(Server.MapPath("~/") + u.UserProfilePicture); }
                
                UserHandler.Delete(UserId);

                Response.Redirect("Member.aspx");
            }
        }
    }
}