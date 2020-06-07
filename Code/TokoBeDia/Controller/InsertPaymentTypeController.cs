using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;

namespace TokoBeDia.Controller
{
    public class InsertPaymentTypeController
    {
        public static bool checkIsUserPermittedToAccess()
        {
            if (HttpContext.Current.Session["userName"] != null)
            {
                string user_email = HttpContext.Current.Request.Cookies["user_email"].Value;
                return (UserHandler.IsUserAnAdmin(user_email));
            }
            return false;
        }

        public static bool checkLenght(string name)
        {
            return (name.Length < 3) ? false : true;
        }

        public static bool checkDuplicateName(string name)
        {
            return (PaymentTypeHandler.checkNameExist(name));
        }

        public static void requestInsertName(string name)
        {
            PaymentTypeHandler.createPaymentType(name);
        }

        public static bool isBoxFilled(string content)
        {
            return (content.Length == 0) ? false : true;
        }
    }
}