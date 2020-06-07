using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;

namespace TokoBeDia.Controller
{
    public class UpdatePaymentTypeController
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

        public static void requestUpdatePayment(int id, string name)
        {
            PaymentTypeHandler.updatePayment(id, name);
        }

        public static PaymentType requestPaymentTypeObject(int id)
        {
            return PaymentTypeHandler.getPaymentTypeObject(id);
        }

        public static bool isBoxFilled(string content)
        {
            return (content.Length == 0) ? false : true;
        }
    }
}