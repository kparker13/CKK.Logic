using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        private Customer Customer;
        private List<ShoppingCartItem> ShoppingCartItems;

        public ShoppingCart(Customer cust)
        {
            Customer = cust;
            ShoppingCartItems = new List<ShoppingCartItem>();
        }

        public int GetCustomerId()
        {
            return Customer.GetId();
        }

        public ShoppingCartItem GetProductById(int id)
        {
            var isThere =
                from item in ShoppingCartItems
                where item.GetProduct().GetId() == id
                select item;
            return isThere.FirstOrDefault();
        }
        public ShoppingCartItem AddProduct(Product prod)
        {
            return AddProduct(prod, 1);
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            var isThere =
                from item in ShoppingCartItems
                where item.GetProduct() == prod
                select item;
            var product = isThere.FirstOrDefault();
            if (product != null)
            {
                product.SetQuantity(quantity += product.GetQuantity());
                return product;
            }
            return new ShoppingCartItem(prod, quantity);
        }

        
        public ShoppingCartItem RemoveProduct(Product prod, int quantity) 
        {
            var isThere =
                from item in ShoppingCartItems
                where item.GetProduct() == prod
                select item;
            var product = isThere.FirstOrDefault();
            if (product != null) 
            { 
                if (product.GetQuantity() > quantity)
                {
                    product.SetQuantity(product.GetQuantity() - quantity);
                    return product;
                }
                else if (product.GetQuantity() <= quantity) 
                {
                    ShoppingCartItems.Remove(product);
                    product.SetQuantity(0);
                    return product;
                }
            }
            return null;
        }

        public List<ShoppingCartItem> GetProducts() 
        {
            return ShoppingCartItems;
        }

        public decimal GetTotal() 
        {
            var total = 0.0M;
            foreach (var item in ShoppingCartItems)
            {
                total += item.GetQuantity() * item.GetQuantity();
            }
            return total;
        }
    }
}
