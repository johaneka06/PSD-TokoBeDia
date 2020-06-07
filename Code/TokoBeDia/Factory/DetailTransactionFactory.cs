using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Factory
{
    public class DetailTransactionFactory
    {
        public static DetailTransaction createDetail(int HeaderId, int productId, int qty)
        {
            return new DetailTransaction()
            {
                TransactionID = HeaderId,
                ProductID = productId,
                Quantity = qty
            };
        }
    }
}