using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;

namespace TokoBeDia.View.profile
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UpdateProfileController.isUserLoggedIn())
            {
                userWarnLbl.Text = "403 Forbidden. You must log in first!";
                oldPswdBox.Enabled = false;
                newPswdBox.Enabled = false;
                confPswdBox.Enabled = false;
                changeBtn.Visible = false;
                logOutBtn.Visible = false;
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

        protected void changeBtn_Click(object sender, EventArgs e)
        {
            bool stat = true;
            string oldPass = oldPswdBox.Text;
            string newPass = newPswdBox.Text;
            string confPass = confPswdBox.Text;
            if (!ChangePasswordController.isBoxFilled(oldPass))
            {
                oldPswdValidator.Text = "Old password must be filled!";
                stat = false;
            }
            if (!ChangePasswordController.isBoxFilled(newPass))
            {
                newPswdBoxValidator.Text = "New Password must be filled!";
                stat = false;
            }
            if (!ChangePasswordController.isBoxFilled(confPass))
            {
                confPswdBoxValidator.Text = "Confirmation password must be filled!";
                stat = false;
            }
            if (ChangePasswordController.oldPasswordMatch(oldPass) && stat)
            {
                if (!ChangePasswordController.updatePassword(newPass, confPass))
                    warningLbl.Text = "Confirmation password is not same with new password!";
                else Response.Redirect("./ViewProfile.aspx");
            }
        }
    }
}