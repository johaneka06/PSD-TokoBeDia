using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;

namespace TokoBeDia.View
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RegisterController.isUserLoggedIn())
            {
                userWarnLbl.Text = "You are logged in! Cannot register!";
                nameBox.Enabled = false;
                emailBox.Enabled = false;
                passwdBox.Enabled = false;
                confPasswdBox.Enabled = false;
                genderSelector.Enabled = false;
                registerBtn.Enabled = false;
            }
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            bool stat = true;
            String name = nameBox.Text;
            String email = emailBox.Text;
            String password = passwdBox.Text;
            String confPassword = confPasswdBox.Text;
            String gender = genderSelector.SelectedValue;
            if (!RegisterController.isBoxFilled(name))
            {
                nameValidator.Text = "Name must be filled";
                stat = false;
            }
            if (!RegisterController.isBoxFilled(email))
            {
                emailValidator.Text = "Email must be filled";
                stat = false;
            }
            if (!RegisterController.isBoxFilled(password))
            {
                passwordValidator.Text = "Password must be filled";
                stat = false;
            }
            if (!RegisterController.isBoxFilled(confPassword))
            {
                confPasswordValidator.Text = "Confirmation Password must be filled";
                stat = false;
            }
            if (!RegisterController.isBoxFilled(gender))
            {
                genderValidator.Text = "Gender must be chosen";
                stat = false;
            }
            if (!RegisterController.isPasswordSame(password, confPassword))
                warningLbl.Text = "Confirmation password must be same with password!";
            else if (RegisterController.isEmailAlreadyExist(email))
                warningLbl.Text = "Email already exist in database";
            else if (stat)
            {
                RegisterController.createUser(email, name, password, gender);
                Response.Redirect("./Login.aspx");
            }
                
        }
    }
}