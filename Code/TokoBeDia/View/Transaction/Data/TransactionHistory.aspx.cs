using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;
using TokoBeDia.Model;

namespace TokoBeDia.View.Transaction.Data
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!TransactionHistoryController.isUserLoggedIn())
            {
                userWarnLbl.Text = "You're not logged in. Please login to see this page";
                loginBtn.Visible = true;
                logoutBtn.Visible = false;
            }
            else
            {
                if (!TransactionHistoryController.isUserAnAdmin())
                {
                    int userId = TransactionHistoryController.getUserID();
                    load_data(userId);
                }
                else
                {
                    load_data();
                    transactionReportBtn.Visible = true;
                }
            }
        }

        private void load_data(int userId)
        {
            List<vTransaction> transactionData = TransactionHistoryController.getTransactionData(userId);
            transactionGrid.DataSource = transactionData;
            transactionGrid.DataBind();
        }

        private void load_data()
        {
            List<vTransaction> transactionData = TransactionHistoryController.getTransactionData();
            transactionGrid.DataSource = transactionData;
            transactionGrid.DataBind();
        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx");
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            HttpCookie currentUser = HttpContext.Current.Request.Cookies["user_email"];
            HttpContext.Current.Response.Cookies.Remove("user_email");
            currentUser.Expires = DateTime.Now.AddDays(-7.0);
            currentUser.Value = null;
            HttpContext.Current.Response.Cookies.Set(currentUser);
            Session.Abandon();
            Response.Redirect("~/View/Home.aspx");
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Login.aspx");
        }

        protected void transactionReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./TransactionReport.aspx");
        }
    }
}