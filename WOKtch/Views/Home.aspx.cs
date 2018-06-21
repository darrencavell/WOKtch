using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WOKtch.Handlers;
using WOKtch.Models;

namespace WOKtch.Views
{
    public partial class Home : System.Web.UI.Page
    {
        User u = null;
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["user"] != null) { u = (User)Session["user"]; setGreetings(u); }                    // IF SESSION NAMED "USER" EXIST: SET IT TO USER MODEL, SHOW USERNAME ON THE NAMELABEL
            else { setGreetings(); }                                                                        // ELSE: SHOW GUEST ON THE NAMELABEL
            var masterPage = Master as TemplatePage;                                                        // DEFINE THE "MASTERPAGE"
            masterPage.setPageViewAfterLogin(u);                                                            // SET THE LINK VIEW
            
            DataTable watches = ProductHandler.GetTop(6);                                                   // GET "THE DATA", HANDLER -> REPO -> DB                                

            catalog.DataSource = watches;
            catalog.DataBind();
        }
        // SET BIG JUMBOTRON MESSAGE
        private void setGreetings(User u)                                                                   // DISPLAY WHEN THE USER IS LOGGED IN
            { prolog.InnerText = "Please check out Products to have a best deal."; profile.Visible = true; name.Text = u.UserName; }                                       
        private void setGreetings()
            { prolog.InnerText = "If you haven't register, please register at the top side of your screen."; profile.Visible = false; name.Text = "Guest"; }         

        // FUNCTION TO DETERMINE, WHETHER TO SHOW EDIT DELETE DIV
        protected void catalog_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            RepeaterItem ri = e.Item;
            if ((ri.ItemType == ListItemType.Item) || (ri.ItemType == ListItemType.AlternatingItem)) {
                if (u != null) {
                    Panel editPanel = ri.FindControl("editorAdmin") as Panel;
                    if(u.UserRole == 1) {
                        editPanel.Visible = true;
                    }
                }
            }
        }
    }
}