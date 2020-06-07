using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;

namespace TokoBeDia.Controller
{
    public class TransactionHistoryController
    {
        public static bool isUserLoggedIn()
        {
            return (HttpContext.Current.Session["userName"] != null) ? true : false;
        }

        public static List<vTransaction> getTransactionData(int id)
        {
            return TransactionHandler.getMemberTransactionData(id);
        }

        public static List<vTransaction> getTransactionData()
        {
            return TransactionHandler.getAllTransactionData();
        }

        public static bool isUserAnAdmin()
        {
            string email = HttpContext.Current.Request.Cookies["user_email"].Value;
            return UserHandler.IsUserAnAdmin(email);
        }

        public static int getUserID()
        {
            return Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
        }
    }
}