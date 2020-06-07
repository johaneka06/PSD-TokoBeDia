using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Controller
{
    public class ViewUserController
    {
        public static bool isUserLoggedIn()
        {
            return (HttpContext.Current.Session["userName"] != null) ? true : false;
        }

        private static string GetUserEmailCookie()
        {
            return HttpContext.Current.Request.Cookies["user_email"].Value;
        }

        public static bool isUserPermittedAccess()
        {
            return (isUserLoggedIn() && UserHandler.IsUserAnAdmin(GetUserEmailCookie())) ? true : false;
        }

        public static List<vUser> getUserData()
        {
            return UserHandler.getUserData();
        }

        public static int getUserID()
        {
            return Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
        }

        public static bool isUserTryToChangeTheirAccount(int selectedID)
        {
            return (getUserID() == selectedID) ? true : false;
        }

        public static void updateSelectedUser(string email, string role, string status)
        {
            int roleId = 0;
            if (role == "Administrator") roleId = 1;
            else roleId = 100;
            UserHandler.changeUserStatus(email, roleId, status);
        }

        public static User getUserData(string email)
        {
            return UserHandler.findUser(email);
        }
    }
}