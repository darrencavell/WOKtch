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
    public partial class ReviewUpdate : System.Web.UI.Page
    {
        int ReviewId;
        User u = null;
        protected void Page_Load(object sender, EventArgs e) {
            if (Request.QueryString["review"] == null) Response.Redirect("Home.aspx");
            if (Session["user"] == null) Response.Redirect("Home.aspx");
            else  {
                u = (User)Session["user"];
                var masterPage = Master as TemplatePage;
                masterPage.setPageViewAfterLogin(u);
            }
        }

        protected void update_button_Click(object sender, EventArgs e)
        {
            if (editRating_textBox.Text != "" && editReview_textBox.Text != "")
            {
                if (Int32.Parse(editRating_textBox.Text) < 1 || Int32.Parse(editRating_textBox.Text) > 5)
                {
                    notificationError_label.Text = "Please insert rating from 1-5!";
                }
                else if (editReview_textBox.Text.Length > 255)
                {
                    notificationError_label.Text = "Maximal length up to 255 characters!";
                }
                else
                {
                    ReviewId = Int32.Parse(Request.QueryString["review"]);
                    ReviewHandler.Update(ReviewId, Int32.Parse(editRating_textBox.Text), editReview_textBox.Text);
                    notificationSuccess_label.Text = "Update Review Success";
                    //Response.Redirect("ProductShowCaseDetail.aspx?productId=" + ProductId);
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                notificationError_label.Text = "Please fill all the fields!";
            }
        }
    }
}