using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Handler
{
    public class ProductTypeHandler
    {
        public static void createType(string name, string desc)
        {
            ProductTypeRepository.create(ProductTypeFactory.createProductType(name, desc));
        }

        public static bool isNameAlreadyExist(string name)
        {
            return (ProductTypeRepository.findPT(name) != null) ? true : false;
        }

        public static bool delete(int id)
        {
            if (ProductRepository.findPT(id) != null) return false;
            else
            {
                ProductTypeRepository.delete(id);
                return true;
            }
        }

        public static List<ProductType> getPTToList()
        {
            return ProductTypeRepository.read();
        }

        public static List<String> getPTName()
        {
            return ProductTypeRepository.getType();
        }

        public static bool findMatches(String name)
        {
            return (ProductTypeRepository.findPT(name) != null) ? true : false;
        }

        public static void update(int id, String name, String desc)
        {
            ProductTypeRepository.update(id, name, desc);
        }

        public static int findId(string type)
        {
            return ProductTypeRepository.findPT(type).ProductTypeId;
        }

        public static ProductType findPTById(int id)
        {
            return ProductTypeRepository.findPTById(id);
        }
    }
}