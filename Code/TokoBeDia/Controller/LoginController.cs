using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;

namespace TokoBeDia.Controller
{
    public class LoginController
    {
        public static User findUser(String email)
        {
            return UserHandler.findUser(email);
        }

        public static bool loginDataCheck(String username, String password) //function to check login data including email and password
        {
            if (UserHandler.isUserCredentialCorrent(username, password))
            {
                return (!UserHandler.isUserBlocked(username));
            }
            return false;

        }

        public static bool isUserBanned(string email)
        {
            return (UserHandler.isUserBlocked(email));
        }

        public static string getUserPassword(string email)
        {
            return UserHandler.getOldPassword(email);
        }

        public static bool isBoxFilled(string content)
        {
            return (content.Length == 0) ? false : true;
        }
    }
}