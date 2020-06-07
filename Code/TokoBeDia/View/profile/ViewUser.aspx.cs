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
    public partial class ManageUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ViewUserController.isUserPermittedAccess())
            {
                userWarnLbl.Text = "You are not permitted to access this page.";
                submitBtn.Visible = false;
                if (!ViewUserController.isUserLoggedIn()) logoutBtn.Visible = false;
            }
            else
            {
                load_data();
            }
        }

        private void load_data()
        {
            List<vUser> UserList = ViewUserController.getUserData();
            userGrid.DataSource = UserList;
            userGrid.DataBind();
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

        protected void linkSelect_Click(object sender, EventArgs e)
        {
            string email = (sender as LinkButton).CommandArgument;
            User selectedUser = ViewUserController.getUserData(email);
            nameLbl.Text = selectedUser.UName;
            idLbl.Text = selectedUser.UserID.ToString();
            emailLbl.Text = selectedUser.UEmail;
            if (selectedUser.RoleID == 1) roleBtn.SelectedValue = "Administrator";
            else if (selectedUser.RoleID == 100) roleBtn.SelectedValue = "Member";
            statusBtn.SelectedValue = selectedUser.UStatus;
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            int selectedUserID = Convert.ToInt32(idLbl.Text);
            if (ViewUserController.isUserTryToChangeTheirAccount(selectedUserID))
                warningLbl.Text = "Cannot change your own role / status!";
            else
            {
                string email = emailLbl.Text;
                string role = roleBtn.SelectedValue;
                string status = statusBtn.SelectedValue;
                ViewUserController.updateSelectedUser(email, role, status);
                Response.Redirect("./ViewUser.aspx");
            }
        }
    }
}