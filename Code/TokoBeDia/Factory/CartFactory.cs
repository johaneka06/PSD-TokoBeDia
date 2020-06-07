using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Factory
{
    public class CartFactory
    {
        public static Cart createNewCart(int userId, int productId, int qty)
        {
            return new Cart()
            {
                UserID = userId,
                ProductID = productId,
                Quantity = qty
            };
        }
    }
}