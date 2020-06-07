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
    public partial class UpdatePaymentType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UpdatePaymentTypeController.checkIsUserPermittedToAccess())
            {
                userWarnLbl.Text = "You cannot access this page!";
                logoutBtn.Visible = false;
                nameBox.Enabled = false;
                updateBtn.Enabled = false;
            }
            else if(!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                PaymentType current = UpdatePaymentTypeController.requestPaymentTypeObject(id);
                nameBox.Text = current.PaymentTypeName;
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
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            string name = nameBox.Text;
            if (!UpdatePaymentTypeController.isBoxFilled(name)) nameValidate.Text = "Name must be filled!";
            if (!UpdatePaymentTypeController.checkLenght(name)) warningLbl.Text = "Name must be 3 chars or more";
            else if (UpdatePaymentTypeController.checkDuplicateName(name)) warningLbl.Text = "Name already exist!";
            else
            {
                UpdatePaymentTypeController.requestUpdatePayment(id, name);
                Response.Redirect("./ViewPaymentType.aspx");
            }
        }
    }
}