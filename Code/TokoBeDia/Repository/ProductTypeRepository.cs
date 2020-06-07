using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class ProductTypeRepository
    {
        private static TokoBeDiaDBEntities db = DBSingleton.GetInstance();

        public static void create(ProductType newType)
        {
            db.ProductTypes.Add(newType);
            db.SaveChanges();
        }

        public static List<ProductType> read()
        {
            return db.ProductTypes.ToList();
        }

        public static void update(int id, String name, String desc)
        {
            ProductType pt = db.ProductTypes.Where(x => x.ProductTypeId == id).FirstOrDefault();
            pt.ProductTypeName = name;
            pt.ProductTypeDesc = desc;
            db.SaveChanges();
        }

        public static void delete(int id)
        {
            ProductType pt = db.ProductTypes.Where(x => x.ProductTypeId == id).FirstOrDefault();
            db.ProductTypes.Remove(pt);
            db.SaveChanges();
        }

        public static ProductType findPTById(int id)
        {
            return db.ProductTypes.Where(x => id == x.ProductTypeId).FirstOrDefault();
        }

        public static ProductType findPT(string type)
        {
            return db.ProductTypes.Where(x => type == x.ProductTypeName).FirstOrDefault();
        }

        public static List<string> getType()
        {
            return db.ProductTypes.Select(x => x.ProductTypeName).ToList();
        }
    }
}