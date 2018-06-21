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
    public partial class Member : System.Web.UI.Page
    {
        public DataTable members;
        User u = null;

        int role, userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("Home.aspx");
            else { u = (User)Session["user"]; var masterPage = Master as TemplatePage; masterPage.setPageViewAfterLogin(u); }

            members = UserHandler.Get();
            member.DataSource = members;
            member.DataBind();
        }

        // INPUT TEXTBOX VALIDATION
        private void checkEmptiness()
        {
            if (textbox_userId.Text == "")
                { notificationSuccess_label.Text = ""; notificationError_label.Text += "The UserId must be filled" + "<br>"; }
            if (textbox_role.Text == "")
                { notificationSuccess_label.Text = ""; notificationError_label.Text += "The RoleId must be filled" + "<br>"; }
        }

        // EVENT BUTTON FIRES
        protected void changeRole_button_Click(object sender, EventArgs e)
        {
            notificationSuccess_label.Text = "";
            notificationError_label.Text = "";
            if (textbox_userId.Text != "" && textbox_role.Text != "")
            {
                userId = Int32.Parse(textbox_userId.Text);
                role = Int32.Parse(textbox_role.Text);
                if (role == 0 || role == 1)
                    { notificationSuccess_label.Text = "Change role success!"; notificationError_label.Text = ""; UserHandler.Update(role, userId); Response.Redirect("Member.aspx"); }
                else
                    { notificationSuccess_label.Text = ""; notificationError_label.Text = "The role must only be 1 and 0"; }
            }
            else checkEmptiness();
        }
    }
}