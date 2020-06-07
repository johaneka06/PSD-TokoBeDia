using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Factory
{
    public class HeaderTransactionFactory
    {
        public static HeaderTransaction newHeader(int userId, int paymentId)
        {
            DateTime date = DateTime.Today;
            return new HeaderTransaction()
            {
                UserID = userId,
                PaymentTypeID = paymentId,
                TransactionDate = date.Date
            };
        }

    }
}