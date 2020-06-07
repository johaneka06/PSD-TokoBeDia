using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;
using TokoBeDia.Model;

namespace TokoBeDia.View.Transaction.VCart
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AddToCartController.checkIsAMember())
            {
                userWarnLbl.Text = "You are not logged in as member.";
                addBtn.Visible = false;
                qtyBox.Enabled = false;
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                vProduct currentProduct = AddToCartController.findProductDetail(id);
                
                productNameLbl.Text = currentProduct.Name;
                productPriceLbl.Text = currentProduct.Price.ToString();
                productStockLbl.Text = currentProduct.Stock.ToString();
                productTypeLbl.Text = currentProduct.Type;
            }
        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx");
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            int qty = 0;
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            if (AddToCartController.checkIsNumeric(qtyBox.Text))
            {
                qty = Convert.ToInt32(qtyBox.Text);
                if (!AddToCartController.checkQty(qty)) warningLbl.Text = "Qty must be more than 0!";
                else if (!AddToCartController.checkStock(id, qty)) warningLbl.Text = "Qty must be less than or equal with stock!";
                else if (!AddToCartController.checkCurrentStock(id, qty)) warningLbl.Text = "Current Qty is exceeded current stock.";
                else
                {
                    int userId = Convert.ToInt32(Session["UserID"].ToString());
                    AddToCartController.requestAddToCart(userId, id, qty);
                    Response.Redirect("./ViewCart.aspx");
                }
            }
            else warningLbl.Text = "Inputted qty must be a number";
        }
    }
}