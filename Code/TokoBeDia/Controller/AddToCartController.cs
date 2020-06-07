using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;
using TokoBeDia.Handler;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Controller
{
    public class AddToCartController
    {
        public static bool checkIsAMember()
        {
            if(HttpContext.Current.Session["userName"] != null)
            {
                string user_email = HttpContext.Current.Request.Cookies["user_email"].Value;
                if (!UserHandler.IsUserAnAdmin(user_email)) return true;
                return false;
            }
            return false;
        }

        public static ProductType getPTDetail(int typeId)
        {
            return CartHandler.findPTById(typeId);
        }

        public static vProduct findProductDetail(int id)
        {
            return CartHandler.findProductDetail(id);
        }

        public static bool checkIsNumeric(string input)
        {
            int _;
            return (int.TryParse(input, out _)) ? true : false;
        }

        public static bool checkQty(int qty)
        {
            return (qty > 0) ? true : false;
        }

        public static bool checkStock(int id, int qty)
        {
            return CartHandler.isProductInStock(id, qty);
        }

        public static bool checkCurrentStock(int id, int qty)
        {
            int totalItemInCart = CartHandler.getTotalItemQtyInCart(id) + qty;
            return CartHandler.isProductInStock(id, totalItemInCart);
        }

        public static void requestAddToCart(int userId, int productId, int qty)
        {
            if (CartHandler.isItemAlreadyExist(userId, productId)) //If there's item that wants to add
                CartHandler.updateQtyForExistingItem(userId, productId, qty);
            else
                CartHandler.createNewCart(userId, productId, qty);
        }
    }
}