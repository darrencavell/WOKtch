using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.Handlers;
using WOKtch.Models;

namespace WOKtch.Views
{
    public partial class ProductPage : System.Web.UI.Page
    {
        User u = null;
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["user"] != null) { u = (User)Session["user"]; }
            var masterPage = Master as TemplatePage;                                                        // DEFINE THE "MASTERPAGE"
            masterPage.setPageViewAfterLogin(u);                                                            // SET THE LINK VIEW

            DataTable watches = ProductHandler.Get();                                                       // GET "THE DATA", HANDLER -> REPO -> DB                                

            catalog.DataSource = watches;
            catalog.DataBind();
        }

        // FUNCTION TO DETERMINE, WHETHER TO SHOW EDIT DELETE DIV
        protected void catalog_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            RepeaterItem ri = e.Item;
            if ((ri.ItemType == ListItemType.Item) || (ri.ItemType == ListItemType.AlternatingItem)) {
                if (u != null) {
                    if (u.UserRole == 1) {
                        Panel editPanel = ri.FindControl("editorAdmin") as Panel;
                        editPanel.Visible = true;
                    }
                }
            }
        }
    }
}