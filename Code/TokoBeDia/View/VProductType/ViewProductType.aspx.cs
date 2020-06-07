using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;
using TokoBeDia.Model;

namespace TokoBeDia.View.VProductType
{
    public partial class ViewProductType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewProductTypeController.isUserLoggedIn())
            {
                if (ViewProductTypeController.isUserAnAdmin(Request.Cookies["user_email"].Value))
                    loadData();
                else
                {
                    userWarnLbl.Text = "403 You're not an admin";
                    insertBtn.Visible = false;
                }
            }
            else
            {
                userWarnLbl.Text = "403 You're not logged in!";
                logoutBtn.Visible = false;
                insertBtn.Visible = false;
            }
        }

        private void loadData()
        {
            List<ProductType> vPT = ViewProductTypeController.requestList();
            ptGrid.DataSource = vPT;
            ptGrid.DataBind();
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
            Response.Redirect("./UpdateProductType.aspx?id=" + id);
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (!ViewProductTypeController.requestDelete(id)) warningLbl.Text = "Cannot Delete This Product Type.";
            else Response.Redirect("./ViewProductType.aspx");
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./InsertProductType.aspx");
        }
    }
}