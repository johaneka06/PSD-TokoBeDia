using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;

namespace TokoBeDia.Controller
{
    public class UpdateProductTypeController
    {
        public static bool isUserLoggedIn()
        {
            return (HttpContext.Current.Session["userName"] != null) ? true : false;
        }

        public static ProductType requestDetail(int id)
        {
            return ProductTypeHandler.findPTById(id);
        }

        public static bool checkLengthRequirement(string name)
        {
            if (name.Length < 5) return false;
            return true;
        }

        public static void update(int id, string name, string desc)
        {
            ProductTypeHandler.update(id, name, desc);
        }

        public static bool isUserAnAdmin(string email)
        {
            return UserHandler.IsUserAnAdmin(email);
        }

        public static bool findMatches(string name)
        {
            return ProductTypeHandler.findMatches(name);
        }

        public static bool isBoxFilled(string content)
        {
            return (content.Length == 0) ? false : true;
        }
    }
}