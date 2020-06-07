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
    public partial class ViewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ViewProductController.isUserLoggedIn())
            {
                logOutBtn.Visible = false;
                insertBtn.Visible = false;
                deleteBtn.Visible = false;
                updateBtn.Visible = false;

                loginBtn.Visible = true;
            }
            else
            {
                if (!ViewProductController.isUserAnAdmin(Request.Cookies["user_email"].Value))
                {
                    insertBtn.Visible = false;
                    deleteBtn.Visible = false;
                    updateBtn.Visible = false;
                    addToCartBtn.Visible = false;
                }
            }
            load_data();
        }

        private void load_data()
        {
            List<vProduct> productList = ViewProductController.getProductList();
            productGrid.DataSource = productList;
            productGrid.DataBind();
        }

        protected void logOutBtn_Click(object sender, EventArgs e)
        {
            HttpCookie currentUser = HttpContext.Current.Request.Cookies["user_email"];
            HttpContext.Current.Response.Cookies.Remove("user_email");
            currentUser.Expires = DateTime.Now.AddDays(-7.0);
            currentUser.Value = null;
            HttpContext.Current.Response.Cookies.Set(currentUser);
            Session.Abandon();
            Response.Redirect("../Home.aspx");
        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Home.aspx");
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./InsertProduct.aspx");
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login.aspx");
        }

        protected void selectLinkBtn_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["user_email"] == null) { } //Do nothing
            else if (ViewProductController.isUserAnAdmin(Request.Cookies["user_email"].Value))
            {
                updateBtn.Visible = true;
                deleteBtn.Visible = true;
                addToCartBtn.Visible = false;
            }
            else addToCartBtn.Visible = true;
            int productId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Product selectedProduct = ViewProductController.getProductObject(productId);
            idLbl.Text = selectedProduct.ProductID.ToString();
            nameLbl.Text = selectedProduct.ProductName;
            priceLbl.Text = selectedProduct.ProductPrice.ToString();
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./UpdateProduct.aspx?Id=" + 
                Convert.ToInt32(idLbl.Text));
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idLbl.Text);
            if (ViewProductController.checkProductInCart(id))
                warningLbl.Text = "Cannot delete current product. Still referenced by cart";
            else
            {
                if (ViewProductController.requestDeleteProduct(id)) Response.Redirect("./ViewProduct.aspx");
                else warningLbl.Text = "Cannot delete current product. Still referenced by Transaction";
            }
        }

        protected void addToCartBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idLbl.Text);
            Response.Redirect("../Transaction/VCart/AddToCart.aspx?Id=" + id);
        }
    }
}