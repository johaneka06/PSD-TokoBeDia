using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;

namespace TokoBeDia.View.VProduct
{
    public partial class InsertProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (InsertProductController.isUserLoggedIn())
            {
                if (InsertProductController.isUserAnAdmin(Request.Cookies["user_email"].Value))
                {
                    typeDD.DataSource = InsertProductController.getProductType();
                    typeDD.DataBind();
                }
                else
                {
                    userWarnLbl.Text = "403. You're not an admin.";
                    nameBox.Enabled = false;
                    priceBox.Enabled = false;
                    stockBox.Enabled = false;
                    insertBtn.Visible = false;
                }
            }
            else
            {
                userWarnLbl.Text = "403. You're not logged in";
                nameBox.Enabled = false;
                priceBox.Enabled = false;
                stockBox.Enabled = false;
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
            bool stat = true;
            string productName = nameBox.Text;
            int stock = Convert.ToInt32(stockBox.Text);
            int price = Convert.ToInt32(priceBox.Text);
            String type = typeDD.SelectedItem.Text.ToString();
            if (!InsertProductController.isBoxFilled(productName))
            {
                nameValidate.Text = "Name must be filled!";
                stat = false;
            }
            if (!InsertProductController.isBoxFilled(stockBox.Text))
            {
                stockValidate.Text = "Stock must be filled!";
                stat = false;
            }
            if (!InsertProductController.isBoxFilled(priceBox.Text))
            {
                priceValidate.Text = "Price must be filled!";
                stat = false;
            }

            if (!InsertProductController.checkStockReq(stock)) warningLbl.Text = "Stock must 1 or more!";
            else if (!InsertProductController.checkPriceReq(price)) warningLbl.Text = "Price must be 1000 or more and multiply of 1000!";
            else if(stat)
            {
                InsertProductController.insertNewProduct(productName, stock, price, type);
                Response.Redirect("./ViewProduct.aspx");
            }
        }
    }
}