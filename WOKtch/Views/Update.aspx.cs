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
    public partial class Update : System.Web.UI.Page
    {
        int ProductId, UserId;
        User u = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("Home.aspx");
            else { u = (User)Session["user"]; if (u.UserRole == 0) Response.Redirect("Home.aspx"); var masterPage = Master as TemplatePage; masterPage.setPageViewAfterLogin(u); }

            changeValue();
        }
        private void changeValue()
        {
            if (Request.QueryString["productId"] != null)
            {
                ProductId = Int32.Parse(Request.QueryString["productId"]);
                Product p = ProductHandler.GetById(ProductId);

                //if (!IsPostBack)
                //{
                //    inputWatchName_textBox.Text = p.ProductName;
                //    inputUserWatchPrice_textBox.Text = p.ProductPrice.ToString();
                //    inputUserWatchQuantity_textBox.Text = p.ProductStock.ToString();
                //}

                image.ImageUrl = string.Format("~/{0}", p.ProductImage);
            }
            else if (Request.QueryString["userId"] != null)
            {
                UserId = Int32.Parse(Request.QueryString["userId"]);
                //UserHandler.Update(UserId);

                Response.Redirect("Member.aspx");
            }
        }


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
        { string fileName = Path.GetFileName(upload.PostedFile.FileName); string cntPath = System.AppDomain.CurrentDomain.BaseDirectory; String timeStamp = GetTimestamp(DateTime.Now); string fileLocation = "ImageStorage\\" + timeStamp + fileName; string exactFileLocation = fileLocation.Replace("\\", "/"); upload.SaveAs(cntPath + exactFileLocation); return exactFileLocation; }
        
        // INPUT TEXTBOX VALIDATION
        private void checkEmptiness()
        {
            // WATCH NAME TEXTBOX
            if (inputWatchName_textBox.Text == "")
                { notificationSuccess_label.Text = ""; notificationError_label.Text += "Watch name must be filled!" + "<br>"; }
            // WATCH PRICE TEXTBOX
            if (inputUserWatchPrice_textBox.Text == "")
                { notificationSuccess_label.Text = ""; notificationError_label.Text += "Watch price must be filled!" + "<br>"; }
            // WATCH QUANTITY TEXTBOX
            if (inputUserWatchQuantity_textBox.Text == "")
                { notificationSuccess_label.Text = ""; notificationError_label.Text += "Watch quantity must be filled!" + "<br>"; }
            else
                { if (Int32.Parse(inputUserWatchQuantity_textBox.Text) < 0) { notificationSuccess_label.Text = ""; notificationError_label.Text += "Watch quantity must be greater than 0!" + "<br>"; } }
            // IMAGE FORMAT
            if (!isImageUploaded())
                { notificationSuccess_label.Text = ""; notificationError_label.Text += "Image must be selected!" + "<br>"; }
            else
                if (isImageInCorrectFormat())
                    { notificationSuccess_label.Text = ""; notificationError_label.Text += "File extension must be .jpg or .png!" + "<br>"; }
        }

        // BUTTON EVENT FIRES
        protected void update_button_Click(object sender, EventArgs e)
        {
            notificationSuccess_label.Text = "";
            notificationError_label.Text = "";
            if (inputUserWatchQuantity_textBox.Text != "" && inputUserWatchPrice_textBox.Text != "" && inputWatchName_textBox.Text != "")
            {
                if (upload.HasFile)
                {
                    Product p = ProductHandler.GetById(ProductId);
                    if (System.IO.File.Exists(Server.MapPath("~/") + p.ProductImage)) { System.IO.File.Delete(Server.MapPath("~/") + p.ProductImage); }

                    string image = getImageUploaded();

                    ProductHandler.UpdateWithImage(ProductId, inputWatchName_textBox.Text, image, Convert.ToDecimal(inputUserWatchPrice_textBox.Text), Int32.Parse(inputUserWatchQuantity_textBox.Text)); }
                else { ProductHandler.UpdateWithoutImage(ProductId, inputWatchName_textBox.Text, Convert.ToDecimal(inputUserWatchPrice_textBox.Text), Int32.Parse(inputUserWatchQuantity_textBox.Text)); }

                notificationSuccess_label.Text = "Update Watch successfuly!";
                notificationError_label.Text += "";

                Response.Redirect("Home.aspx");
            }
            else checkEmptiness();
        }
    }
}