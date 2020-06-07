using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class ProductRepository
    {
        private static TokoBeDiaDBEntities db = DBSingleton.GetInstance();

        public static void create(Product newProduct)
        {
            db.Products.Add(newProduct);
            db.SaveChanges();
        }

        public static List<vProduct> read()
        {
            return db.vProducts.ToList();
        }

        public static void delete(int id)
        {
            Product p = db.Products.Where(x => id == x.ProductID).FirstOrDefault();
            db.Products.Remove(p);
            db.SaveChanges();
        }

        public static void update(int id, string name, int price, int stock, int typeId)
        {
            Product p = db.Products.Where(x => x.ProductID == id).FirstOrDefault();
            p.ProductName = name;
            p.ProductPrice = price;
            p.ProductStock = stock;
            p.ProductTypeId = typeId;
            db.SaveChanges();
        }

        public static Product findPT(int id)
        {
            return db.Products.Where(x => x.ProductTypeId == id).FirstOrDefault();
        }

        public static void updateStock(int id, int stock)
        {
            Product p = db.Products.Where(x => x.ProductID == id).FirstOrDefault();
            p.ProductStock = stock;
            db.SaveChanges();
        }

        public static Product read(int id)
        {
            return db.Products.Where(x => x.ProductID == id).FirstOrDefault();
        }

        public static vProduct findProductDetail(int id)
        {
            return db.vProducts.Where(x => x.ID == id).FirstOrDefault();
        }
    }
}