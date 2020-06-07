using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;

namespace TokoBeDia.Controller
{
    public class ViewProfileController
    {
        public static bool isUserLoggedIn()
        {
            if(HttpContext.Current.Session["userName"] != null) return true;
            return false;
        }

        public static User getUserData()
        {
            string email = HttpContext.Current.Request.Cookies["user_email"].Value;
            return UserHandler.findUser(email);
        }
    }
}