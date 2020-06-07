using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Handler
{
    public class ProductHandler
    {
        public static void createNewProduct(string name, int stock, int price, string type)
        {
            int typeId = ProductTypeRepository.findPT(type).ProductTypeId;
            ProductRepository.create(ProductFactory.create(name, stock, price, typeId));
        }

        public static vProduct findProductDetail(int id)
        {
            return ProductRepository.read().Where(x => x.ID == id).FirstOrDefault();
        }

        public static void updateProduct(int id, string name, int price, int stock, string type)
        {
            int typeId = ProductTypeRepository.findPT(type).ProductTypeId;
            ProductRepository.update(id, name, price, stock, typeId);
        }

        public static List<vProduct> getProductList()
        {
            return ProductRepository.read();
        }

        public static Product getProductObject(int id)
        {
            return ProductRepository.read(id);
        }

        public static bool deleteProduct(int id)
        {
            if (TransactionRepository.getItemExist(id) != null) return false;
            ProductRepository.delete(id);
            return true;
        }

        public static List<String> getProductType()
        {
            return ProductTypeRepository.getType();
        }

        public static List<vProduct> getProductRandom()
        {
            Random rand = new Random();
            return ProductRepository.read().OrderBy(x => rand.Next()).Take(5).ToList();
        }
    }
}