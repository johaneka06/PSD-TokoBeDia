using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class CartRepository
    {
        private static TokoBeDiaDBEntities db = DBSingleton.GetInstance();

        public static void create(Cart newCart)
        {
            db.Carts.Add(newCart);
            db.SaveChanges();
        }

        public static List<vCart> read()
        {
            return db.vCarts.ToList();
        }

        public static void update(int userId, int productId, int qty)
        {
            Cart current = db.Carts.Where(x => userId == x.UserID && productId == x.ProductID).FirstOrDefault();
            current.Quantity = qty;
            db.SaveChanges();
        }

        public static void delete(int userId, int id) //delete cart item
        {
            Cart current = db.Carts.Where(x => id == x.ProductID && userId == x.UserID).FirstOrDefault();
            db.Carts.Remove(current);
            db.SaveChanges();
        }

        public static vCart findProduct(int userId, int productId)
        {
            return db.vCarts.Where(x => x.UserID == userId && x.Product_Id == productId).FirstOrDefault();
        }

        public static vCart findProduct(int productId)
        {
            return db.vCarts.Where(x => productId == x.Product_Id).FirstOrDefault();
        }

        public static List<vCart> findProductList(int productId)
        {
            return db.vCarts.Where(x => productId == x.Product_Id).ToList();
        }

        public static List<vCart> read(int userId)
        {
            return db.vCarts.Where(x => userId == x.UserID).ToList();
        }
    }
}