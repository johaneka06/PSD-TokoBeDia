using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class PaymentTypeRepository
    {
        private static TokoBeDiaDBEntities db = DBSingleton.GetInstance();

        public static void create(PaymentType newPaymentType)
        {
            db.PaymentTypes.Add(newPaymentType);
            db.SaveChanges();
        }

        public static List<PaymentType> read()
        {
            return db.PaymentTypes.ToList();
        }

        public static void delete(int id)
        {
            PaymentType selected = db.PaymentTypes.Where(x => id == x.PaymentTypeId).FirstOrDefault();
            db.PaymentTypes.Remove(selected);
            db.SaveChanges();
        }

        public static void update(int id, String name)
        {
            PaymentType selected = db.PaymentTypes.Where(x => id == x.PaymentTypeId).FirstOrDefault();
            selected.PaymentTypeName = name;
            db.SaveChanges();
        }

        public static PaymentType findPayment(string name)
        {
            return db.PaymentTypes.Where(x => x.PaymentTypeName == name).FirstOrDefault();
        }

        public static PaymentType findPayment(int id)
        {
            return db.PaymentTypes.Where(x => x.PaymentTypeId == id).FirstOrDefault();
        }
    }
}