using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;

namespace TokoBeDia.Controller
{
    public class UpdateProfileController
    {
        public static bool isUserLoggedIn()
        {
            return (HttpContext.Current.Session["userName"] != null) ? true : false; 
        }

        public static User getUserData()
        {
            string email = HttpContext.Current.Request.Cookies["user_email"].Value;
            return UserHandler.findUser(email);
        }

        public static bool findEmailExist(string email)
        {
            if (HttpContext.Current.Request.Cookies["user_email"].Value == email) return false;
            return UserHandler.findExistUser(email);
        }

        public static void requestUpdate(string name, string email, string gender)
        {
            int id = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
            UserHandler.updateCurrentUser(id, name, email, gender);
        }

        public static bool isBoxFilled(string content)
        {
            return (content.Length == 0) ? false : true;
        }
    }
}