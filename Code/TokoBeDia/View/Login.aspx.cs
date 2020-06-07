using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;
using TokoBeDia.Model;

namespace TokoBeDia.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserName"] == null && Session["UserID"] == null && Session["UserEmail"] == null && Request.Cookies["user_email"] != null)
            {
                User u = LoginController.findUser(Request.Cookies["user_email"].Value);
                Session["UserName"] = u.UName;
                Session["UserID"] = u.UserID;
                Session["UserEmail"] = u.UEmail;
                emailBox.Text = u.UEmail;
                passwordBox.Attributes.Add("value", u.UPassword);

            }
            else if(Session["UserName"] != null && Session["UserID"] != null && Session["UserEmail"] != null && Request.Cookies["user_email"] != null)
            {
                string email = Request.Cookies["user_email"].Value;
                emailBox.Text = email;
                passwordBox.Attributes.Add("value", LoginController.getUserPassword(email));
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            bool stat = true;
            String email = emailBox.Text;
            String password = passwordBox.Text;
            if (!LoginController.isBoxFilled(email))
            {
                emailValidator.Text = "Email must be filled!";
                stat = false;
            }
            if (!LoginController.isBoxFilled(password))
            {
                passwordValidator.Text = "Password must be filled!";
                stat = false;
            }
            else if (LoginController.loginDataCheck(email, password) && stat)
            {
                Double expired = 2.0;
                User loggedIn = LoginController.findUser(email);
                if (rememberMeChk.Checked) expired = 72.0;
                Session["UserName"] = loggedIn.UName;
                Session["UserID"] = loggedIn.UserID;
                Session["UserEmail"] = loggedIn.UEmail;
                HttpCookie userCookies = new HttpCookie("user_email", loggedIn.UEmail);
                userCookies.Expires = DateTime.Now.AddHours(expired);
                Response.Cookies.Add(userCookies);
                Response.Redirect("./Home.aspx");
            }
            else
            {
                if (LoginController.isUserBanned(email)) warningLbl.Text = "Your Account Is Currently Suspended. Contact Admin for Support";
                else warningLbl.Text = "No such account exist. Please try again";
            }
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Register.aspx");
        }
    }
}