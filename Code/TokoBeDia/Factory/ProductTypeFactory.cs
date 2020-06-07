using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Factory
{
    public class ProductTypeFactory
    {
        public static ProductType createProductType(String name, String desc)
        {
            return new ProductType()
            {
                ProductTypeName = name,
                ProductTypeDesc = desc
            };
        }
    }
}