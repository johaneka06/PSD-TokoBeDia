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
    public partial class UpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UpdateProfileController.isUserLoggedIn())
            {
                if (!IsPostBack)
                {
                    User currentUser = UpdateProfileController.getUserData();
                    nameBox.Text = currentUser.UName;
                    emailBox.Text = currentUser.UEmail;
                    genderBtn.SelectedValue = currentUser.UGender;
                }
            }
            else
            {
                userWarnLbl.Text = "403 Forbidden. Please login first!";
                nameBox.Enabled = false;
                emailBox.Enabled = false;
                genderBtn.Enabled = false;
                logoutBtn.Visible = false;
                submitBtn.Visible = false;
            }
        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Home.aspx");
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            HttpCookie currentUser = HttpContext.Current.Request.Cookies["user_email"];
            HttpContext.Current.Response.Cookies.Remove("user_email");
            currentUser.Expires = DateTime.Now.AddDays(-7.0);
            currentUser.Value = null;
            HttpContext.Current.Response.Cookies.Set(currentUser);
            Session.Abandon();
            Response.Redirect("../Home.aspx");
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            bool stat = true;
            string name = nameBox.Text;
            string email = emailBox.Text;
            string gender = genderBtn.SelectedValue;
            if (!UpdateProfileController.isBoxFilled(name))
            {
                nameValidator.Text = "Name must be filled!";
                stat = false;
            }
            if (!UpdateProfileController.isBoxFilled(email))
            {
                emailValidator.Text = "Email must be fileld!";
                stat = false;
            }
            if (!UpdateProfileController.isBoxFilled(gender))
            {
                genderValidator.Text = "Gender must be choosen!";
                stat = false;
            }
            if (UpdateProfileController.findEmailExist(email)) warningLbl.Text = "Email already exist!";
            else if (stat)
            {
                UpdateProfileController.requestUpdate(name, email, gender);
                Response.Redirect("./ViewProfile.aspx");
            }
        }
    }
}