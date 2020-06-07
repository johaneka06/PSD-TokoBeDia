using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;

namespace TokoBeDia.Controller
{
    public class UpdateCartController
    {
        public static bool isUserAMember()
        {
            if(HttpContext.Current.Session["userName"] != null)
            {
                string email = HttpContext.Current.Request.Cookies["user_email"].Value;
                if (!UserHandler.IsUserAnAdmin(email)) return true;
                return false;
            }
            return false;
        }

        public static vCart getCartItem(int userId, int id)
        {
            return CartHandler.getCartItem(userId, id);
        }

        public static bool checkQtyBelow(int qty)
        {
            return (qty < 0) ? true : false;
        }

        public static bool checkQty0(int qty)
        {
            return (qty == 0) ? true : false;
        }

        public static void forceDeleteItem(int userId, int id)
        {
            CartHandler.forceDeleteItem(userId, id);
        }

        public static void putUpdateItem(int userId, int productId, int qty)
        {
            CartHandler.putUpdateItem(userId, productId, qty);
        }
    }
}