using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;
using TokoBeDia.Model;

namespace TokoBeDia.View.VPaymentType
{
    public partial class ViewPaymentType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ViewPaymentTypeController.checkIsUserPermittedToAccess())
            {
                userWarnLbl.Text = "You are not authorized to access this page!";
                insertBtn.Visible = false;
            }
            else load_data();
        }

        private void load_data()
        {
            List<PaymentType> vPT = ViewPaymentTypeController.getPaymentTypeList();
            if (vPT.Count == 0) paymentWarning.Text = "No data in database.";
            else
            {
                paymentGrid.DataSource = vPT;
                paymentGrid.DataBind();
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

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Response.Redirect("./UpdatePaymentType.aspx?Id=" + id);
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (ViewPaymentTypeController.requestDelete(id)) Response.Redirect("./ViewPaymentType.aspx");
            else warningLbl.Text = "Cannot delete current payment. Still referenced on another table";
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./InsertPaymentType.aspx");
        }
    }
}