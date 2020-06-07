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
    public class InsertProductTypeController
    {
        public static void createType(String name, String desc)
        {
            ProductTypeHandler.createType(name, desc);
        }

        public static bool isTypeAlreadyExist(String name)
        {
            return ProductTypeHandler.isNameAlreadyExist(name);
        }

        public static bool checkLenght(String name)
        {
            if (name.Length >= 5) return true;
            return false;
        }

        public static bool isUserLoggedIn()
        {
            if (HttpContext.Current.Session["UserName"] != null) return true;
            return false;
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