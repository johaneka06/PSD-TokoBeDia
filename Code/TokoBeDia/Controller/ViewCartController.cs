using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Controller
{
    public class ViewCartController
    {
        public static bool checkUserIsMember()
        {
            if(HttpContext.Current.Session["userName"] != null)
            {
                string email = HttpContext.Current.Request.Cookies["user_email"].Value;
                if (!UserHandler.IsUserAnAdmin(email)) return true;
                return false;
            }
            return false;
        }

        public static List<vCart> getCartData(int id)
        {
            return CartHandler.getCartItem(id);
        }

        public static void requestDeleteProduct(int userId, int ItemId)
        {
            CartHandler.deleteCartItem(userId, ItemId);
        }

        public static List<string> getPaymentData()
        {
            return CartHandler.getPaymentData();
        }

        public static int getGrandTotal(int userId)
        {
            return CartHandler.countGrandTotal(userId);
        }

        public static bool isCartCanBeCheckOut()
        {
            int id = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
            return (getCartData(id).Count == 0) ? false : true;
        }

        public static void checkOut(int userId, string paymentType)
        {
            TransactionHandler.checkOut(userId, paymentType);
        }
    }
}