using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;

namespace TokoBeDia.View.VPaymentType
{
    public partial class InsertPaymentType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!InsertPaymentTypeController.checkIsUserPermittedToAccess())
            {
                userWarnLbl.Text = "You are not authorized to access this page!";
                insertBtn.Visible = false;
                logoutBtn.Visible = false;
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

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            if (!InsertPaymentTypeController.isBoxFilled(name)) nameValidate.Text = "Name must be filled!";
            else if (!InsertPaymentTypeController.checkLenght(name)) warningLbl.Text = "Lenght must be 3 chars or more";
            else if (InsertPaymentTypeController.checkDuplicateName(name)) warningLbl.Text = "Name already exists!";
            else
            {
                InsertPaymentTypeController.requestInsertName(name);
                Response.Redirect("./ViewPaymentType.aspx");
            }
        }
    }
}