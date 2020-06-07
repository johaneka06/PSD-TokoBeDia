using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;

namespace TokoBeDia.Controller
{
    public class TransactionReportController
    {
        public static bool isUserPermittedToAccess()
        {
            if(HttpContext.Current.Session["userName"] != null)
            {
                string userEmail = HttpContext.Current.Request.Cookies["user_email"].Value;
                return (UserHandler.IsUserAnAdmin(userEmail));
            }
            return false;
        }

        public static List<HeaderTransaction> getTransactionData()
        {
            return TransactionHandler.getHeaderTransaction();
        }

        public static List<DetailTransaction> getDetailTransaction(int id)
        {
            return TransactionHandler.getDetailTransaction(id);
        }
    }
}