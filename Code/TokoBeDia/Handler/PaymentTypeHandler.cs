using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Handler
{
    public class PaymentTypeHandler
    {
        public static void createPaymentType(string name)
        {
            PaymentTypeRepository.create(PaymentTypeFactory.createNewPaymentType(name));
        }

        public static bool checkNameExist(string name)
        {
            return (PaymentTypeRepository.findPayment(name) != null) ? true : false;
        }

        public static void updatePayment(int id, string name)
        {
            PaymentTypeRepository.update(id, name);
        }

        public static PaymentType getPaymentTypeObject(int id)
        {
            return PaymentTypeRepository.findPayment(id);
        }

        public static List<PaymentType> getPaymentTypeList()
        {
            return PaymentTypeRepository.read();
        }

        public static bool deletePaymentType(int id)
        {
            if (TransactionRepository.getPaymentHeader(id) != null) return false;
            PaymentTypeRepository.delete(id);
            return true;
        }
    }
}