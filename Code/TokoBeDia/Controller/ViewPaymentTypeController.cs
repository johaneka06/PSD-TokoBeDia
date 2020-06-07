using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;

namespace TokoBeDia.Controller
{
    public class ViewPaymentTypeController
    {
        public static bool checkIsUserPermittedToAccess()
        {
            if(HttpContext.Current.Session["userName"] != null)
            {
                string user_email = HttpContext.Current.Request.Cookies["user_email"].Value;
                return UserHandler.IsUserAnAdmin(user_email);
            }
            return false;
        }

        public static List<PaymentType> getPaymentTypeList()
        {
            return PaymentTypeHandler.getPaymentTypeList();
        }

        public static bool requestDelete(int id)
        {
           return PaymentTypeHandler.deletePaymentType(id);
        }
    }
}