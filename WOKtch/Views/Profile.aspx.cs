using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.Models;

namespace WOKtch.Views
{
    public partial class Profile : System.Web.UI.Page
    {
        User u = null;
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["user"] == null) Response.Redirect("Home.aspx");
            else u = (User)Session["user"];                                     
            var masterPage = Master as TemplatePage;
            masterPage.setPageViewAfterLogin(u);

            setProfileBiodata(u);
        }

        private void setProfileBiodata(User u) {
            name.Text = u.UserName;
            email.Text = u.UserEmail;
            gender.Text = u.UserGender;
            phoneNumber.Text = u.UserPhoneNumber;
            Image1.ImageUrl = string.Format("~/{0}", u.UserProfilePicture);
            address.Text = u.UserAddress;
            role.Text = u.UserRole.ToString();
        }
    }
}