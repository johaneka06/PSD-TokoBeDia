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
    public partial class UpdateCartItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UpdateCartController.isUserAMember())
            {
                warningLbl.Text = "You are not logged in as a member.";
                submitBtn.Visible = false;
            }
            else if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                int userId = Convert.ToInt32(Session["UserID"].ToString());
                vCart currentItem = UpdateCartController.getCartItem(userId, id);
                nameBox.Text = currentItem.Product_Name;
                priceBox.Text = currentItem.Price.ToString();
                qtyBox.Text = currentItem.Quantity.ToString();
            }
        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx");
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(Request.QueryString["id"]);
            int userId = Convert.ToInt32(Session["UserID"].ToString());
            int qty = Convert.ToInt32(qtyBox.Text);
            if (UpdateCartController.checkQtyBelow(qty)) warningLbl.Text = "Qty must be above 0!";
            else
            {
                if (UpdateCartController.checkQty0(qty)) UpdateCartController.forceDeleteItem(userId, productId);
                else UpdateCartController.putUpdateItem(userId, productId, qty);
                Response.Redirect("./ViewCart.aspx");
            }
        }
    }
}