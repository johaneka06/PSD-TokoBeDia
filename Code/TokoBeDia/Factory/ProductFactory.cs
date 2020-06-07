using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Factory
{
    public class ProductFactory
    {
        public static Product create(string name, int stock, int price, int typeId)
        {
            return new Product()
            {
                ProductName = name,
                ProductPrice = price,
                ProductStock = stock,
                ProductTypeId = typeId
            };
        }
    }
}