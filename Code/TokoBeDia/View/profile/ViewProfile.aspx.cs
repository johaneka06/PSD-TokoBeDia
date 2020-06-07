using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;
using TokoBeDia.Model;

namespace TokoBeDia.View.profile
{
    public partial class ViewProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewProfileController.isUserLoggedIn())
            {
                User currentUser = ViewProfileController.getUserData();
                nameLbl.Text = currentUser.UName;
                emailLbl.Text = currentUser.UEmail;
                genderLbl.Text = currentUser.UGender;
            }
            else
            {
                userWarnLbl.Text = "403. You're not logged in!";
                logOutBtn.Visible = false;
                updateBtn.Visible = false;
                changePswdBtn.Visible = false;
            }
        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Home.aspx");
        }

        protected void logOutBtn_Click(object sender, EventArgs e)
        {
            HttpCookie currentUser = HttpContext.Current.Request.Cookies["user_email"];
            HttpContext.Current.Response.Cookies.Remove("user_email");
            currentUser.Expires = DateTime.Now.AddDays(-7.0);
            currentUser.Value = null;
            HttpContext.Current.Response.Cookies.Set(currentUser);
            Session.Abandon();
            Response.Redirect("../Home.aspx");
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./UpdateProfile.aspx");
        }

        protected void changePswdBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ChangePassword.aspx");
        }
    }
}