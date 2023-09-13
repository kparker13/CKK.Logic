using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private List<ShoppingCartItem> ShoppingCartItems;

        public ShoppingCart(Customer cust)
        {
            Customer = cust;
            ShoppingCartItems = new List<ShoppingCartItem>();
        }

        public Customer Customer { get; set; }

        public Product Products { get; set; }

        public int GetCustomerId()
        {
            return Customer.Id;
        }

        public ShoppingCartItem GetProductById(int id)
        {
            if (id >= 0)
            {
                var isThere =
                    from item in ShoppingCartItems
                    where item.Product.Id == id
                    select item;

                return isThere.FirstOrDefault();
            }
            throw new InvalidIdException();
        }
        public ShoppingCartItem AddProduct(Product prod)
        {
            return AddProduct(prod, 1);
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var isThere =
                from item in ShoppingCartItems
                where item.Product == prod
                select item;
            var product = isThere.FirstOrDefault();
                if (product != null)
                {
                    product.Quantity += quantity;
                    return product;
                }
                var newItem = new ShoppingCartItem(prod, quantity);
                ShoppingCartItems.Add(newItem); 
                return newItem;
            
        }

        
        public ShoppingCartItem RemoveProduct(int id, int quantity) 
        {
            if (quantity >= 0)
            {
                var isThere =
                    from item in ShoppingCartItems
                    where item.Product.Id == id
                    select item;
                var product = isThere.FirstOrDefault();
                if (product != null)
                {
                    if (product.Quantity > quantity)
                    {
                        product.Quantity -= quantity;
                        return product;
                    }
                    else if (product.Quantity <= quantity)
                    {
                        ShoppingCartItems.Remove(product);
                        product.Quantity = 0;
                        return product;
                    }
                }
                throw new ProductDoesNotExistException();
            }
            throw new ArgumentOutOfRangeException();
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
                total += item.Quantity * item.Product.Price;
            }
            return total;
        }
    }
}
