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
    public partial class UpdateProductType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UpdateProductTypeController.isUserLoggedIn())
            {
                if (UpdateProductTypeController.isUserAnAdmin(Request.Cookies["user_email"].Value))
                {
                    if (!IsPostBack)
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        ProductType thisPT = UpdateProductTypeController.requestDetail(id);
                        typeIdBox.Text = id.ToString();
                        typeNameBox.Text = thisPT.ProductTypeName;
                        typeDescBox.Text = thisPT.ProductTypeDesc;
                    }
                }
                else
                {
                    userWarnLbl.Text = "403. You are not an admin!";
                    typeNameBox.Enabled = false;
                    typeDescBox.Enabled = false;
                    submitBtn.Visible = false;
                }
            }
            else
            {
                userWarnLbl.Text = "403. You are not logged in as admin!";
                typeNameBox.Enabled = false;
                typeDescBox.Enabled = false;
                submitBtn.Visible = false;
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

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            bool stat = true;
            int id = Convert.ToInt32(typeIdBox.Text);
            string name = typeNameBox.Text;
            string desc = typeDescBox.Text;
            if (!UpdateProductTypeController.isBoxFilled(name))
            {
                nameValidate.Text = "Name must be filled!";
            }
            if (!UpdateProductTypeController.isBoxFilled(desc))
            {
                descValidate.Text = "Description must be filled!";
            }

            if (!UpdateProductTypeController.checkLengthRequirement(name)) warningLbl.Text = "Name must be 5 chars or more!";
            else if (UpdateProductTypeController.findMatches(name)) warningLbl.Text = "Name cannot be same with any data in database!";
            else if(stat)
            {
                UpdateProductTypeController.update(id, name, desc);
                Response.Redirect("./ViewProductType.aspx");
            }
        }
    }
}