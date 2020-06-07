using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;

namespace TokoBeDia.Controller
{
    public class UpdateProductController
    {
        public static bool isUserAnAdmin(String email)
        {
            return UserHandler.IsUserAnAdmin(email);
        }
        public static bool isUserLoggedIn()
        {
            return (HttpContext.Current.Session["userName"] != null) ? true : false;
        }

        public static vProduct getProductObject(int id)
        {
            return ProductHandler.findProductDetail(id);
        }

        public static bool PriceMeetRequirement(int price)
        {
            return (price % 1000 == 0 && price > 1000) ? true : false;
        }

        public static bool StockMeetRequirement(int stock)
        {
            return (stock > 0) ? true : false;
        }

        public static bool isValid(int id, string name, int price, int stock, string type)
        {
            if(PriceMeetRequirement(price) && StockMeetRequirement(stock))
            {
                ProductHandler.updateProduct(id, name, price, stock, type);
                return true;
            }
            return false;
        }

        public static bool isBoxFilled(string content)
        {
            return (content.Length == 0) ? false : true;
        }

        public static List<String> getProductType()
        {
            return ProductHandler.getProductType();
        }
    }
}