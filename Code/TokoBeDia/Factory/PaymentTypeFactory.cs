using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Factory
{
    public class PaymentTypeFactory
    {
        public static PaymentType createNewPaymentType(string name)
        {
            return new PaymentType()
            {
                PaymentTypeName = name
            };
        }
    }
}