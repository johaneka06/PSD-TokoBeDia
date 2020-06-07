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
    public partial class ViewCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ViewCartController.checkUserIsMember())
            {
                userWarnLbl.Text = "You are not logged in as member to access this page";
                checkOutBtn.Visible = false;
                paymentDD.Visible = false;
            }
            else
            {
                List<vCart> cart = load_data();
                if (cart.Count == 0)
                {
                    cartEmptyLbl.Text = "Empty Cart";
                    checkOutBtn.Enabled = false;
                    paymentDD.Enabled = false;
                }
                load_payment();
                grandTotalLbl.Text = ViewCartController.getGrandTotal(Convert.ToInt32(Session["userID"]
                    .ToString())).ToString();
            }
        }

        private List<vCart> load_data()
        {
            int id = Convert.ToInt32(Session["userID"].ToString());
            List<vCart> cart = ViewCartController.getCartData(id);
            cartGrid.DataSource = cart;
            cartGrid.DataBind();
            return cart;
        }

        private void load_payment()
        {
            paymentDD.DataSource = ViewCartController.getPaymentData();
            paymentDD.DataBind();
        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View//Home.aspx");
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            int pId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Response.Redirect("./UpdateCartItem.aspx?id=" + pId);
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            int userId = Convert.ToInt32(Session["UserID"].ToString());
            ViewCartController.requestDeleteProduct(userId, id);
            Response.Redirect("./ViewCart.aspx");
        }

        protected void checkOutBtn_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"].ToString());
            string paymentType = paymentDD.SelectedValue.ToString();
            if (!ViewCartController.isCartCanBeCheckOut()) warningLbl.Text = "Your cart is empty.";
            else
            {
                ViewCartController.checkOut(userId, paymentType);
                Response.Redirect("~/View/Home.aspx");
            }
        }
    }
}