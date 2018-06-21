using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.Models;

namespace WOKtch.Views
{
    public partial class Transaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["user"] == null) Response.Redirect("Home.aspx");
            else {
                User u = (User)Session["user"];
                //var masterPage = Master as TemplatePage;
                //masterPage.setPageViewAfterLogin(u);
            }
        }
    }
}