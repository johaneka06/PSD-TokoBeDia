using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;

namespace TokoBeDia.Controller
{
    public class RegisterController
    {
        public static bool isUserLoggedIn()
        {
            return (HttpContext.Current.Session["userName"] != null) ? true : false;
        }

        public static bool isPasswordSame(String password, String confirmation)
        {
            if (password == confirmation) return true;
            else return false;
        }

        public static bool isEmailAlreadyExist(String email)
        {
            return UserHandler.findExistUser(email);
        }

        public static void createUser(String email, String name, String password, String gender)
        {
            UserHandler.insertNewUser(name, email, password, gender);
        }

        public static bool isBoxFilled(string content)
        {
            return (content.Length == 0) ? false : true;
        }
    }
}