using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Repository;
using TokoBeDia.Model;
using TokoBeDia.Factory;

namespace TokoBeDia.Handler
{
    public class TransactionHandler
    {
        public static void checkOut(int userId, string paymentType)
        {
            List<vCart> cartData = CartRepository.read(userId);
            int paymentId = PaymentTypeRepository.findPayment(paymentType).PaymentTypeId;
            int transactionId = TransactionRepository.insertHeaderTransaction
                (HeaderTransactionFactory.newHeader(userId, paymentId)).TransactionID;

            foreach (vCart item in cartData)
            {
                int productId = item.Product_Id;
                int qty = item.Quantity;
                TransactionRepository.insertDetailTransaction(DetailTransactionFactory.createDetail(transactionId, productId, qty));
                CartRepository.delete(userId, productId);
                int currentStock = ProductRepository.findProductDetail(productId).Stock - qty;
                ProductRepository.updateStock(productId, currentStock);
            }
        }

        public static List<vTransaction> getAllTransactionData() //For admin
        {
            return TransactionRepository.getTransactionData();
        }

        public static List<vTransaction> getMemberTransactionData(int userId) //For member
        {
            return TransactionRepository.getTransactionData(userId);
        }

        public static List<HeaderTransaction> getHeaderTransaction() //For generate report
        {
            return TransactionRepository.getHeaderTransaction();
        }

        public static List<DetailTransaction> getDetailTransaction(int id)
        {
            return TransactionRepository.getDetailTransaction(id);
        }
    }
}