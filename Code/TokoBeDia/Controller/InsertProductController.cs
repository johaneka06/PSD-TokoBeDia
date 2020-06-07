using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;

namespace TokoBeDia.Controller
{
    public class InsertProductController
    {
        public static bool isUserLoggedIn()
        {
            return (HttpContext.Current.Session["userName"] != null) ? true : false;
        }

        public static bool checkStockReq(int stock)
        {
            return (stock >= 1) ? true : false;
        }

        public static bool checkPriceReq(int price)
        {
            return (price > 1000 && price % 1000 == 0) ? true : false;
        }

        public static List<String> getProductType()
        {
            return ProductTypeHandler.getPTName();
        }

        public static void insertNewProduct(string name, int stock, int price, string type)
        {
            ProductHandler.createNewProduct(name, stock, price, type);
        }

        public static bool isUserAnAdmin(string email)
        {
            return UserHandler.IsUserAnAdmin(email);
        }

        public static bool isBoxFilled(string content)
        {
            return (content.Length == 0) ? false : true;
        }
    }
}