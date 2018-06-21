using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.Models;

namespace WOKtch.Views
{
    public partial class TemplatePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e) {
            date_label.Text = DateTime.Now.ToString("hh:mm:ss");
        }
        protected void myTimer_Tick(object sender, EventArgs e)
            { date_label.Text = DateTime.Now.ToString("hh:mm:ss"); }

        public void setPageViewAfterLogin(User u) {
            bool isVisible = true;
            string current = DateTime.Now.ToString("HH:mm:ss");
            if (u != null) {
                if (u.UserRole == 1) {
                    add.Visible = isVisible;
                    logout.Visible = isVisible;
                    member.Visible = isVisible;
                    member_label.Text = "Welcome, Admin!";
                }
                else if(u.UserRole == 0) { 
                    logout.Visible = isVisible;
                    member_label.Text = "Welcome, " + u.UserName + "!";
                }
            } else {
                login.Visible = isVisible;
                register.Visible = isVisible;
                member_label.Text = "Welcome, Guest!";
            }
            date_label.Text = current;
            product.Visible = isVisible;
        }
    }
}