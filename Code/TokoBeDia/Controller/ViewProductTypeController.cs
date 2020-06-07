using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Controller
{
    public class ViewProductTypeController
    {
        public static bool isUserLoggedIn()
        {
            if (HttpContext.Current.Session["userName"] != null) return true;
            return false;
        }

        public static List<ProductType> requestList()
        {
            return ProductTypeHandler.getPTToList();
        }

        public static bool requestDelete(int id)
        {
            return ProductTypeHandler.delete(id);
        }

        public static bool isUserAnAdmin(string email)
        {
            return UserHandler.IsUserAnAdmin(email);
        }
    }
}