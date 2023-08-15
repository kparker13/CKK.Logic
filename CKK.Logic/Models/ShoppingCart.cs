using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        private Customer _Customer;
        private ShoppingCartItem _Product1;
        private ShoppingCartItem _Product2;
        private ShoppingCartItem _Product3;

        public ShoppingCart(Customer cust)
        {
            _Customer = cust;
        }

        public int GetCustomerId()
        {
            return _Customer.GetId();
        }

        public ShoppingCartItem GetProductById(int id)
        {

            if (id == _Product1.GetProduct().GetId())
            {
                return _Product1;
            }
            else if (id == _Product2.GetProduct().GetId())
            {
                return _Product2;
            }
            else if (id == _Product3.GetProduct().GetId())
            {
                return _Product3;
            }
            else
                return null;
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity >0) 
            {
                if (prod == _Product1.GetProduct() || _Product1 == null)
                {
                    _Product1.SetProduct(prod);
                    _Product1.SetQuantity(quantity += _Product1.GetQuantity());
                    return _Product1;
                }
                else if (prod == _Product2.GetProduct())
                {
                    _Product2.SetQuantity(quantity += _Product2.GetQuantity());
                    return _Product2;
                }
                else if (prod == _Product3.GetProduct())
                {
                    _Product3.SetQuantity(quantity += _Product3.GetQuantity());
                    return _Product3;
                }
                else return null;
            }
        }

        public ShoppingCartItem AddProduct(Product prod)
        {
            if (prod == _Product1.GetProduct() || _Product1 == null)
            {
                _Product1.SetProduct(prod);
                _Product1.SetQuantity(quantity += _Product1.GetQuantity());
                return _Product1;
            }
            else if (prod == _Product2.GetProduct())
            {
                _Product2.SetQuantity(quantity += _Product2.GetQuantity());
                return _Product2;
            }
            else if (prod == _Product3.GetProduct())
            {
                _Product3.SetQuantity(++_Product3.GetQuantity());
                return _Product3;
            }
            else return null;
        }

        public ShoppingCartItem RemoveProduct(Product prod, int quantity) 
        { 
            
        }

        public ShoppingCartItem GetProduct(int prodNum) 
        {
            
        }

        public decimal GetTotal() 
        {
            
        }
    }
}
