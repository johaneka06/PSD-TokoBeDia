using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Controller
{
    public class HomeController
    {
        public static bool checkUserLoggedIn()
        {
            if (HttpContext.Current.Session["UserName"] == null) return false; 
            return true;
        }

        public static String getUserName()
        {
            return HttpContext.Current.Session["UserName"].ToString();
        }

        public static bool IsUserAnAdmin(string email)
        {
            return UserHandler.IsUserAnAdmin(email);
        }

        public static List<vProduct> getProduct()
        {
            return ProductHandler.getProductRandom();
        }
    }
}