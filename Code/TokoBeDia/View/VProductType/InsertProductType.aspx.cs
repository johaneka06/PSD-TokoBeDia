using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;

namespace TokoBeDia.View.VProductType
{
    public partial class InsertProductType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (InsertProductTypeController.isUserLoggedIn())
            {
                if (!InsertProductTypeController.isUserAnAdmin(Request.Cookies["user_email"].Value))
                {
                    userWarnLbl.Text = "403 Forbidden! Reason: You're not an admin!";
                    typeNameBox.Enabled = false;
                    descBox.Enabled = false;
                    submitBtn.Visible = false;
                }
            }
            else
            {
                userWarnLbl.Text = "403 Forbidden! Reason: You're not logged in as admin!";
                typeNameBox.Enabled = false;
                descBox.Enabled = false;
                submitBtn.Visible = false;
                logoutBtn.Visible = false;
            }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            bool stat = true;
            String name = typeNameBox.Text;
            String desc = descBox.Text;
            if (!InsertProductTypeController.isBoxFilled(name))
            {
                stat = false;
                nameValidate.Text = "Name must be filled!";
            }
            if (!InsertProductTypeController.isBoxFilled(desc))
            {
                stat = false;
                descValidate.Text = "Description must be filled!";
            }
            if (!InsertProductTypeController.checkLenght(name)) warningLbl.Text = "Name must be 5 chars or more";
            else
            {
                if (InsertProductTypeController.isTypeAlreadyExist(name)) warningLbl.Text = "Type already exist!";
                else if(stat)
                {
                    InsertProductTypeController.createType(name, desc);
                    Response.Redirect("../VProductType/ViewProductType.aspx");
                }
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
    }
}