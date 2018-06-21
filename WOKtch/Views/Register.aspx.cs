using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.Handlers;
using WOKtch.Models;

namespace WOKtch.Views
{
    public partial class Register : System.Web.UI.Page
    {
        User u;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null) { u = (User)Session["user"]; Response.Redirect("Home.aspx"); }     // IF SESSION NAMED "USER" EXIST, SET IT TO USER MODEL, REDIRECT TO "HOME.ASPX"
            var masterPage = Master as TemplatePage;                                                        // DEFINE THE "MASTERPAGE"
            masterPage.setPageViewAfterLogin(u);                                                            // SET THE LINK VIEW
        }
        // IMAGE FUNCTION TYPE OF THING
        private String GetTimestamp(DateTime value)
            { return value.ToString("yyyyMMddHHmmssffff"); }
        private HttpPostedFile getImage()
            { return upload.PostedFile; }
        private bool isImageUploaded()
            { if (upload.HasFile) return true;  return false; }
        private bool isImageInCorrectFormat()
            { HttpPostedFile postedFile = getImage(); string fileName = Path.GetFileName(postedFile.FileName); string fileExtension = Path.GetExtension(fileName); if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png") return false; return true; }
        private string getImageUploaded()
            { string fileName = Path.GetFileName(upload.PostedFile.FileName); string cntPath = System.AppDomain.CurrentDomain.BaseDirectory; String timeStamp = GetTimestamp(DateTime.Now); string fileLocation = "ImageStorage\\" + timeStamp + fileName; string exactFileLocation = fileLocation.Replace("\\", "/"); upload.SaveAs(cntPath + exactFileLocation); return exactFileLocation; }

        // CALENDAR FUNCTION TYPE OF THING
        private bool isDateUploaded(){ if(inputBirthDate_calendar.SelectedDate != null) return false; return true; }
        private DateTime getDateUploaded()
            { DateTime dob = inputBirthDate_calendar.SelectedDate; return dob; }

        // DROPDOWN FUNCTION TYPE OF THING
        private bool isGenderSelected()
            { if (inputGender_dropDown.SelectedValue != "Gender") return false; else return true; }

        private int checkEmptiness(int data)
        {
            int dataInvalid = data;
            // USERNAME TEXTBOX
            if (inputUserName_textBox.Text == "")
                { notificationSuccess_label.Text = ""; error_box.Visible = true; notificationError_label.Text += "Name must be filled!" + "<br>"; dataInvalid++; }
            // EMAIL TEXTBOX
            if (inputEmail_textBox.Text == "")
                { notificationSuccess_label.Text = ""; error_box.Visible = true; notificationError_label.Text += "Email must be filled!" + "<br>"; dataInvalid++; }
            // PASSWORD TEXTBOX
            if (inputUserPassword_textBox.Text == "")
                { notificationSuccess_label.Text = ""; error_box.Visible = true; notificationError_label.Text += "Password must be filled!" + "<br>"; dataInvalid++; }
            // CONFIRM PASSWORD TEXTBOX
            if (inputConfirmyUserPassword_textBox.Text == "")
                { notificationSuccess_label.Text = ""; error_box.Visible = true; notificationError_label.Text += "Confirm Password must be filled!" + "<br>"; dataInvalid++; }
            // CHECK IMAGE FILE UPLOAD
            if (!isImageUploaded())
                { notificationSuccess_label.Text = ""; error_box.Visible = true; notificationError_label.Text += "Image must be selected!" + "<br>"; dataInvalid++; }
            // PHONE NUMBER TEXTBOX
            if (inputPhoneNumber_textBox.Text == "")
                { notificationSuccess_label.Text = ""; error_box.Visible = true; notificationError_label.Text += "Phone Number must be filled!" + "<br>"; dataInvalid++; }
            // ADDRESS TEXTBOX
            if (inputAddress_textBox.Text == "")
                { notificationSuccess_label.Text = ""; error_box.Visible = true; notificationError_label.Text += "Address must be filled!" + "<br>"; dataInvalid++; }
            // CALENDAR
            if (isDateUploaded())
                { notificationSuccess_label.Text = ""; error_box.Visible = true; notificationError_label.Text += "Birthday must be selected!" + "<br>"; dataInvalid++; }
            // GENDER
            if (isGenderSelected())
                { notificationSuccess_label.Text = ""; error_box.Visible = true; notificationError_label.Text += "Gender must be selected!" + "<br>"; dataInvalid++; }
            return dataInvalid;
        }

        // BUTTON EVENT FIRES
        protected void register_button_Click(object sender, EventArgs e)
        {
            int dataInvalid = 0;
            notificationSuccess_label.Text = "";
            notificationError_label.Text = "";
            success_box.Visible = false;
            error_box.Visible = false;
            dataInvalid = checkEmptiness(dataInvalid);

            if(dataInvalid == 0)
            {
                dataInvalid = 0;
                User u = UserHandler.Get(inputEmail_textBox.Text);
                if (u == null)
                {
                    if (isImageInCorrectFormat())
                    {
                        notificationSuccess_label.Text = "";
                        notificationError_label.Text += "File extension must be .jpg or .png!" + "<br>";
                        dataInvalid++;
                    }
                    if (inputConfirmyUserPassword_textBox.Text != inputUserPassword_textBox.Text)
                    {
                        notificationSuccess_label.Text = "";
                        notificationError_label.Text += "Password does not match!";
                        dataInvalid++;
                    }
                    if (dataInvalid == 0)
                    {
                        DateTime dob = getDateUploaded();
                        string email = inputEmail_textBox.Text;
                        string phoneNumber = inputPhoneNumber_textBox.Text;
                        string address = inputAddress_textBox.Text;
                        string image = getImageUploaded();
                        string gender = inputGender_dropDown.SelectedValue;

                        notificationSuccess_label.Text = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, '{8}'", inputUserName_textBox.Text, inputEmail_textBox.Text, gender, dob, phoneNumber, inputUserPassword_textBox.Text, address, 0, image);
                        UserHandler.Insert(inputUserName_textBox.Text, inputUserPassword_textBox.Text, gender, dob, email, address, phoneNumber, image, 0);

                        success_box.Visible = true;
                        notificationSuccess_label.Text = "Registration Successful";
                        notificationError_label.Text = "";
                    }
                }
                else
                {
                    error_box.Visible = true;
                    notificationSuccess_label.Text = "";
                    notificationError_label.Text = "UserEmail has already taken";
                }
            }
        }
        

    }
}