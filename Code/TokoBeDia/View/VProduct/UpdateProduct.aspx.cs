using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;
using TokoBeDia.Model;

namespace TokoBeDia.View.VProduct
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UpdateProductController.isUserLoggedIn())
            {
                if (UpdateProductController.isUserAnAdmin(Request.Cookies["user_email"].Value))
                {
                    if (!IsPostBack)
                    {
                        int id = Convert.ToInt32(Request.QueryString["Id"]);
                        vProduct currentProduct = UpdateProductController.getProductObject(id);
                        typeDD.DataSource = UpdateProductController.getProductType();
                        typeDD.DataBind();
                        nameBox.Text = currentProduct.Name;
                        stockBox.Text = currentProduct.Stock.ToString();
                        priceBox.Text = currentProduct.Price.ToString();
                        typeDD.SelectedValue = currentProduct.Type;
                    }
                }
                else
                {
                    userWarnLbl.Text = "403. You're not an admin.";
                    nameBox.Enabled = false;
                    priceBox.Enabled = false;
                    stockBox.Enabled = false;
                    updateBtn.Visible = false;
                }
            }
            else
            {
                userWarnLbl.Text = "403. You're not logged in";
                nameBox.Enabled = false;
                priceBox.Enabled = false;
                stockBox.Enabled = false;
                updateBtn.Visible = false;
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

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            bool stat = true;
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            string name = nameBox.Text;
            int price = Convert.ToInt32(priceBox.Text);
            int stock = Convert.ToInt32(stockBox.Text);
            string productType = typeDD.SelectedValue;
            if (!UpdateProductController.isBoxFilled(name))
            {
                nameValidate.Text = "Name must be filled!";
                stat = false;
            }
            if (!UpdateProductController.isBoxFilled(priceBox.Text))
            {
                priceValidate.Text = "Price must be filled!";
                stat = false;
            }
            if (!UpdateProductController.isBoxFilled(stockBox.Text))
            {
                stockValidate.Text = "Stock must be filled!";
                stat = false;
            }
            if (!UpdateProductController.isBoxFilled(productType))
            {
                typeValidate.Text = "Type must be chosen!";
                stat = false;
            }

            if (stat)
            {
                if (!UpdateProductController.isValid(id, name, price, stock, productType))
                {
                    if (!UpdateProductController.PriceMeetRequirement(price))
                        warningLbl.Text = "Price is not valid.";
                    else if (!UpdateProductController.StockMeetRequirement(stock))
                        warningLbl.Text = "Stock is not valid.";
                }
                else Response.Redirect("./ViewProduct.aspx");
            }
            
        }
    }
}