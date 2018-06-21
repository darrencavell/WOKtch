using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.Factories;
using WOKtch.Handlers;
using WOKtch.Models;
using WOKtch.Utilities;

namespace WOKtch.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        User u = null;
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["user"] == null) Response.Redirect("Home.aspx");
            else { u = (User)Session["user"]; if (u.UserRole == 0) Response.Redirect("Home.aspx"); }

            var masterPage = Master as TemplatePage;
            masterPage.setPageViewAfterLogin(u);
        }

        // INPUT TEXTBOX CLEAR FUNCTION
        private void clearAllInput()
            { inputWatchName_textBox.Text = ""; inputUserWatchPrice_textBox.Text = ""; inputUserWatchQuantity_textBox.Text = ""; }

        // IMAGE FUNCTION TYPE OF THING
        private String GetTimestamp(DateTime value)
            { return value.ToString("yyyyMMddHHmmssffff"); }
        private HttpPostedFile getImage()
            { return upload.PostedFile; }
        private bool isImageUploaded()
            { if (upload.HasFile) return true; return false; }
        private bool isImageInCorrectFormat()
            { HttpPostedFile postedFile = getImage(); string fileName = Path.GetFileName(postedFile.FileName); string fileExtension = Path.GetExtension(fileName); if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png") return false; else return true; }
        private string getImageUploaded()
            { string fileName = Path.GetFileName(upload.PostedFile.FileName);  string cntPath = System.AppDomain.CurrentDomain.BaseDirectory; String timeStamp = GetTimestamp(DateTime.Now); string fileLocation = "ImageStorage\\" + timeStamp + fileName; string exactFileLocation = fileLocation.Replace("\\", "/"); upload.SaveAs(cntPath + exactFileLocation); return exactFileLocation; }

        // INPUT TEXTBOX VALIDATION
        private void checkEmptiness()
        {
            // WATCH NAME TEXTBOX
            if (inputWatchName_textBox.Text == "")
                { notificationSuccess_label.Text = ""; error_box.Visible = true; notificationError_label.Text += "Watch name must be filled!" + "<br>"; }
            // WATCH PRICE TEXTBOX
            if (inputUserWatchPrice_textBox.Text == "")
                { notificationSuccess_label.Text = ""; error_box.Visible = true; notificationError_label.Text += "Watch price must be filled!" + "<br>"; }
            // WATCH QUANTITY TEXTBOX
            if (inputUserWatchQuantity_textBox.Text == "")
                { notificationSuccess_label.Text = ""; error_box.Visible = true; notificationError_label.Text += "Watch quantity must be filled!" + "<br>"; }
            else
                if (Int32.Parse(inputUserWatchQuantity_textBox.Text) < 0)
                    { notificationSuccess_label.Text = ""; error_box.Visible = true; notificationError_label.Text += "Watch quantity must be greater than 0!" + "<br>"; }
            // IMAGE FORMAT
            if (!isImageUploaded())
                { notificationSuccess_label.Text = ""; error_box.Visible = true; notificationError_label.Text += "Image must be selected!" + "<br>"; }
            else
                if (isImageInCorrectFormat())
                    { notificationSuccess_label.Text = ""; error_box.Visible = true; notificationError_label.Text += "File extension must be .jpg or .png!" + "<br>"; }
        }

        // BUTTON EVENT FIRES
        protected void add_button_Click(object sender, EventArgs e)
        {
            notificationSuccess_label.Text = "";
            notificationError_label.Text = "";
            success_box.Visible = false;
            error_box.Visible = false;
            if (inputWatchName_textBox.Text != "" && !isImageInCorrectFormat() && inputUserWatchPrice_textBox.Text != "" && Int32.Parse(inputUserWatchQuantity_textBox.Text) > 0) {
                int quantity = Int32.Parse(inputUserWatchQuantity_textBox.Text);
                string image = getImageUploaded();

                ProductHandler.Add(inputWatchName_textBox.Text, image, Convert.ToDecimal(inputUserWatchPrice_textBox.Text), quantity);
                success_box.Visible = true;
                notificationSuccess_label.Text = "Add Watch Successful";
                notificationError_label.Text = "";

                //clearAllInput();
            }
            else {
                checkEmptiness();
            }
        }

        
    }
}