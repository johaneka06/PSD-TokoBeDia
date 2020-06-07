using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using TokoBeDia.Controller;

namespace TokoBeDia.View
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string welcomeMessage = "Welcome, ";
            if (HomeController.checkUserLoggedIn()) //Check whether there's user logged in
            {
                welcomeMessage = welcomeMessage + HomeController.getUserName(); //Retrieve username from session and concat it to session.
                if (HomeController.IsUserAnAdmin(Request.Cookies["user_email"].Value)) //Check whether the user is admin or not
                {
                    viewUserBtn.Visible = true;
                    viewProductTypeBtn.Visible = true;
                    viewPaymentTypeBtn.Visible = true;
                    viewTransactionReportBtn.Visible = true;

                    viewCartBtn.Visible = false;
                    msg.Visible = false;
                }
                else
                {
                    viewCartBtn.Visible = true;

                    viewUserBtn.Visible = false;
                    viewProductTypeBtn.Visible = false;
                    viewPaymentTypeBtn.Visible = false;
                    viewTransactionReportBtn.Visible = false;
                    load_data_member();
                }
                viewTransactionHistBtn.Visible = true;
                profileBtn.Visible = true;
                logoutBtn.Visible = true;
                loginBtn.Visible = false;
            }
            else
            {
                welcomeMessage = welcomeMessage + "Guest";
                logoutBtn.Visible = false;
                viewTransactionHistBtn.Visible = false;
                profileBtn.Visible = false;
                viewCartBtn.Visible = false;
                viewUserBtn.Visible = false;
                viewProductTypeBtn.Visible = false;
                viewPaymentTypeBtn.Visible = false;
                viewTransactionReportBtn.Visible = false;
                load_data_guest();
            }
            welcomeLbl.Text = welcomeMessage;
        }

        private void load_data_member()
        {
            productRandomGridGuest.Visible = false;
            productRandomGridMember.DataSource = HomeController.getProduct();
            productRandomGridMember.DataBind();
        }

        private void load_data_guest()
        {
            productRandomGridMember.Visible = false;
            productRandomGridGuest.DataSource = HomeController.getProduct();
            productRandomGridGuest.DataBind();
        }

        protected void viewProductBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./VProduct/ViewProduct.aspx");
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Login.aspx");
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            HttpCookie currentUser = HttpContext.Current.Request.Cookies["user_email"];
            HttpContext.Current.Response.Cookies.Remove("user_email");
            currentUser.Expires = DateTime.Now.AddDays(-7.0);
            currentUser.Value = null;
            HttpContext.Current.Response.Cookies.Set(currentUser);
            Session.Abandon();
            Response.Redirect("./Home.aspx");
        }

        protected void profileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./profile/ViewProfile.aspx");
        }

        protected void viewCartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Transaction/VCart/ViewCart.aspx");
        }

        protected void viewTransactionHistBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Transaction/Data/TransactionHistory.aspx");
        }

        protected void viewUserBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./profile/ViewUser.aspx");
        }

        protected void viewProductTypeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./VProductType/ViewProductType.aspx");
        }

        protected void viewPaymentTypeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./VPaymentType/ViewPaymentType.aspx");
        }

        protected void viewTransactionReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Transaction/Data/TransactionReport.aspx");
        }

        protected void selectBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Response.Redirect("./Transaction/VCart/AddToCart.aspx?id=" + id);
        }
    }
}