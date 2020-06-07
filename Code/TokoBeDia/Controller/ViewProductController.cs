using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Controller
{
    public class ViewProductController
    {
        public static bool isUserLoggedIn()
        {
            return (HttpContext.Current.Session["userName"] != null) ? true : false;
        }

        public static List<vProduct> getProductList()
        {
            return ProductHandler.getProductList();
        }

        public static Product getProductObject(int id)
        {
            return ProductHandler.getProductObject(id);
        }

        public static bool checkProductInCart(int id)
        {
            return (CartHandler.findProduct(id) != null) ? true : false;
        }

        public static bool requestDeleteProduct(int id)
        {
            return ProductHandler.deleteProduct(id);
        }

        public static bool isUserAnAdmin(string email)
        {
            return UserHandler.IsUserAnAdmin(email);
        }
    }
}