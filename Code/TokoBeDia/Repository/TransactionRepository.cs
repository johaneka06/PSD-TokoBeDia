using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class TransactionRepository
    {
        private static TokoBeDiaDBEntities db = DBSingleton.GetInstance();

        public static HeaderTransaction insertHeaderTransaction(HeaderTransaction newHeader)
        {
            db.HeaderTransactions.Add(newHeader);
            db.SaveChanges();

            return newHeader;
        }

        public static void insertDetailTransaction(DetailTransaction newDetail)
        {
            db.DetailTransactions.Add(newDetail);
            db.SaveChanges();
        }

        public static List<vTransaction> getTransactionData()
        {
            return db.vTransactions.ToList();
        }

        public static List<vTransaction> getTransactionData(int id)
        {
            return db.vTransactions.Where(x => x.UserID == id).ToList();
        }

        public static List<HeaderTransaction> getHeaderTransaction()
        {
            return db.HeaderTransactions.ToList();
        }

        public static List<DetailTransaction> getDetailTransaction()
        {
            return db.DetailTransactions.ToList();
        }

        public static List<DetailTransaction> getDetailTransaction(int transactionID)
        {
            return db.DetailTransactions.Where(x => x.TransactionID == transactionID).ToList();
        }

        public static DetailTransaction getItemExist(int itemId)
        {
            return db.DetailTransactions.Where(x => x.ProductID == itemId).FirstOrDefault();
        }

        public static HeaderTransaction getPaymentHeader(int paymentId)
        {
            return db.HeaderTransactions.Where(x => paymentId == x.PaymentTypeID).FirstOrDefault();
        }
    }
}