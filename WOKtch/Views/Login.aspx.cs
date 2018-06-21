using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.Handlers;
using WOKtch.Models;

namespace WOKtch.Views
{
    public partial class Login : System.Web.UI.Page
    {
        User u = null;
        // WHEN THE PAGE IS LOADED
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["user"] != null) { u = (User)Session["user"]; Response.Redirect("Home.aspx"); }     // IF SESSION NAMED "USER" EXIST, SET IT TO USER MODEL, REDIRECT TO "HOME.ASPX"
            var masterPage = Master as TemplatePage;                                                        // DEFINE THE "MASTERPAGE"
            masterPage.setPageViewAfterLogin(u);                                                            // SET THE LINK VIEW

            if (!IsPostBack && Request.Cookies["username"] != null) {                                       // IF COOKIE NAMED "USERNAME" EXIST, SET THE VALUE TO THE TEXTBOX
                inputUserEmail_textBox.Text = Request.Cookies["username"].Value.ToString();
            }
        }

        private void checkEmptiness()
        {
            // USERNAME TEXT BOX
            if (inputUserEmail_textBox.Text == "")
                { notificationSuccess_label.Text = ""; error_box.Visible = true; notificationError_label.Text += "Your username must be filled" + "<br>"; }
            // PASSWORD TEXT BOX
            if (inputUserPassword_textBox.Text == "")
                { notificationSuccess_label.Text = ""; error_box.Visible = true; notificationError_label.Text += "Your password must be filled" + "<br>"; }
        }

        // BUTTON EVENT FIRES
        protected void login_button_Click(object sender, EventArgs e)
        {
            notificationSuccess_label.Text = "";
            notificationError_label.Text = "";
            error_box.Visible = true;
            success_box.Visible = true;
            User u = UserHandler.Get(inputUserEmail_textBox.Text, inputUserPassword_textBox.Text);           // PASSING THE "DATA", COMPARING THE "DATA" TO THE DB, RETURNS IT
            if (u != null) {                                                                                // IF THE "DATA" EXIST
                Session["user"] = u;                                                                        // CREATE A SESSION NAMED "USER"
                if (rememberMe_checkBox.Checked) {                                                          // IF THE "REMEMBER ME" CHECKED
                    Response.Cookies["username"].Value = inputUserEmail_textBox.Text;                        // SET THE COOKIE NAMED "USERNAME", GIVE A VALUE TO IT
                    Response.Cookies["username"].Expires = DateTime.Now.AddHours(1);                        // SET THE COOKIE EXPIRED TIME
                }
                success_box.Visible = true;
                notificationSuccess_label.Text = "Loggin Success";
                Response.Redirect("Home.aspx");                                                             // REDIRECT TO "HOME.ASPX"
            }
            else {                                                                  
                Session["user"] = null;
                if (inputUserEmail_textBox.Text == "" || inputUserPassword_textBox.Text == "") checkEmptiness();
                else { notificationSuccess_label.Text = ""; notificationError_label.Text += "Please input the suitable credentials!" + "<br>"; }
            }
        }
    }
}