using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Handler
{
    public class CartHandler
    {
        public static bool isProductInStock(int id, int qty)
        {
            int stock = ProductRepository.read(id).ProductStock;
            return ((stock - qty) >= 0) ? true : false;
        }

        public static vProduct findProductDetail(int id)
        {
            return ProductRepository.findProductDetail(id);
        }

        public static ProductType findPTById(int id)
        {
            return ProductTypeRepository.findPTById(id);
        }

        public static bool isItemAlreadyExist(int userId, int itemId)
        {
            return (CartRepository.findProduct(userId, itemId) != null) ? true : false;
        }

        public static void updateQtyForExistingItem(int userId, int itemId, int qty)
        {
            vCart currentCartItem = CartRepository.findProduct(userId, itemId);
            qty = currentCartItem.Quantity + qty;
            CartRepository.update(userId, itemId, qty);
        }

        public static void createNewCart(int userId, int productId, int qty)
        {
            CartRepository.create(CartFactory.createNewCart(userId, productId, qty));
        }

        public static int getTotalItemQtyInCart(int ProductId)
        {
            int sum = 0;
            List<vCart> cartList = CartRepository.findProductList(ProductId);
            foreach(vCart c in cartList)
            {
                sum += c.Quantity;
            }
            return sum;
        }

        public static vCart getCartItem(int userId, int id)
        {
            return CartRepository.findProduct(userId, id);
        }

        public static List<vCart> getCartItem(int userId)
        {
            return CartRepository.read(userId);
        }

        public static void forceDeleteItem(int userId, int id)
        {
            CartRepository.delete(userId, id);
        }

        public static void putUpdateItem(int userId, int productId, int qty)
        {
            CartRepository.update(userId, productId, qty);
        }

        public static void deleteCartItem(int userId, int ItemId)
        {
            CartRepository.delete(userId, ItemId);
        }

        public static List<string> getPaymentData()
        {
            List<PaymentType> vPayment = PaymentTypeRepository.read();
            List<string> payment = new List<string>();
            foreach (PaymentType pt in vPayment)
            {
                payment.Add(pt.PaymentTypeName);
            }
            return payment;
        }

        public static int countGrandTotal(int userId)
        {
            int grandTotal = 0;
            foreach (vCart data in CartRepository.read(userId))
            {
                grandTotal += Convert.ToInt32(data.Subtotal);
            }
            return grandTotal;
        }

        public static vCart findProduct(int productId)
        {
            return CartRepository.findProduct(productId);
        }
    }
}