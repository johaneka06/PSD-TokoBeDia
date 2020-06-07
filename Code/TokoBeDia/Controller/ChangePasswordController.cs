using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;

namespace TokoBeDia.Controller
{
    public class ChangePasswordController
    {
        public static bool oldPasswordMatch(string oldPass)
        {
            string userEmail = HttpContext.Current.Request.Cookies["user_email"].Value;
            return (UserHandler.getOldPassword(userEmail) == oldPass) ? true : false;
        }

        public static bool updatePassword(string newPass, string conf)
        {
            if (conf != newPass) return false;
            else
            {
                string userEmail = HttpContext.Current.Request.Cookies["user_email"].Value;
                UserHandler.changePassword(userEmail, newPass);
                return true;
            }
        }

        public static bool isBoxFilled(string content)
        {
            return (content.Length == 0) ? false : true;
        }
    }
}