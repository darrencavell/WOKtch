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
    public partial class ProductDetailPage : System.Web.UI.Page
    {
        int ProductId;
        User u = null;
        protected void Page_Load(object sender, EventArgs e){
            if (Request.QueryString["productId"] == null) Response.Redirect("Home.aspx");
            if (Session["user"] != null) { u = (User)Session["user"]; showSection(u); }                     // IF SESSION NAMED "USER" EXIST: SET IT TO USER MODEL, SHOW USERNAME ON THE NAMELABEL
            var masterPage = Master as TemplatePage;                                                        // DEFINE THE "MASTERPAGE"
            masterPage.setPageViewAfterLogin(u);                                                            // SET THE LINK VIEW
            setPreview();
        }
        private void setPreview(){
            if (Request.QueryString["productId"] != null) {
                ProductId = Int32.Parse(Request.QueryString["productId"]);
                Product p = ProductHandler.GetById(ProductId);

                productName.Text = p.ProductName;
                productPrice.Text = p.ProductPrice.ToString();
                productStock.Text = p.ProductStock.ToString();
                image.ImageUrl = string.Format("~/{0}", p.ProductImage);

                DataTable reviews = ReviewHandler.GetAllByProductId(ProductId);

                review.DataSource = reviews;
                review.DataBind();

            }
        }

        private void showSection(User u) {
            if(u != null) {
                reviewSection.Visible = true;
                addToCartSection.Visible = true;
            }
        }

        protected void add_button_Click(object sender, EventArgs e) {
            if(inputRating_textBox.Text != "" && inputReview_textBox.Text != "") {
                if(Int32.Parse(inputRating_textBox.Text) < 1 || Int32.Parse(inputRating_textBox.Text) > 5) {
                    notificationError_label.Text = "Please insert rating from 1-5!";
                }else if(inputReview_textBox.Text.Length > 255){
                    notificationError_label.Text = "Maximal length up to 255 characters!";
                }else {
                    ReviewHandler.Insert(Int32.Parse(inputRating_textBox.Text), inputReview_textBox.Text, ProductId, u.UserId);
                    notificationSuccess_label.Text = "Insert Review Success";
                    Response.Redirect("ProductShowCaseDetail.aspx?productId=" + ProductId);
                }
            }else {
                notificationError_label.Text = "Please fill all the fields!";
            }
        }

        // FUNCTION TO DETERMINE, WHETHER TO SHOW EDIT DELETE DIV
        protected void review_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            RepeaterItem ri = e.Item;
            if ((ri.ItemType == ListItemType.Item) || (ri.ItemType == ListItemType.AlternatingItem)) {
                if (u != null) {
                    HiddenField userId = ri.FindControl("userId") as HiddenField;
                    Panel editPanel = ri.FindControl("editorAdmin") as Panel;
                    if (u.UserRole == 1 || u.UserId == Int32.Parse(userId.Value)) {
                        editPanel.Visible = true;
                    }
                }
            }
        }
    }
}