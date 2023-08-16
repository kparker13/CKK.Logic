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

        public ShoppingCartItem AddProduct(Product prod, int quantity = 1)
        {
            if (quantity > 0)
            {
                if (_Product1 == null)
                {
                    _Product1 = new ShoppingCartItem(prod, quantity);
                    return _Product1;
                }
                else if (_Product2 == null)
                {
                    _Product2 = new ShoppingCartItem(prod, quantity);
                    return _Product2;
                }
                else if (_Product3 == null)
                {
                    _Product3 = new ShoppingCartItem(prod, quantity);
                    return _Product3;
                }

                else if (prod == _Product1.GetProduct())
                {
                    _Product1.SetQuantity(quantity + _Product1.GetQuantity());
                    return _Product1;
                }
                else if (prod == _Product2.GetProduct())
                {
                    _Product2.SetQuantity(quantity + _Product2.GetQuantity());
                    return _Product2;
                }
                else if (prod == _Product3.GetProduct())
                {
                    _Product3.SetQuantity(quantity + _Product3.GetQuantity());
                    return _Product3;
                }

            }
            return null;
            
        }

        
        public ShoppingCartItem RemoveProduct(Product prod, int quantity) 
        {
            if (prod == _Product1.GetProduct() && quantity <= _Product1.GetQuantity())
            {
                if (quantity == _Product1.GetQuantity())
                {
                    _Product1 = null;
                    return _Product1;
                }
                else
                {
                    _Product1.SetQuantity(_Product1.GetQuantity() - quantity);
                    return _Product1;
                }
            }

            else if (prod == _Product2.GetProduct() && quantity <= _Product2.GetQuantity())
            {
                if (quantity == _Product2.GetQuantity())
                {
                    _Product2 = null;
                    return _Product2;
                }
                else
                {
                    _Product2.SetQuantity(_Product2.GetQuantity() - quantity);
                    return _Product2;
                }
            }

            else if (prod == _Product3.GetProduct() && quantity <= _Product3.GetQuantity())
            {
                if (quantity == _Product3.GetQuantity())
                {
                    _Product3 = null;
                    return _Product3;
                }
                else
                {
                    _Product3.SetQuantity(_Product3.GetQuantity() - quantity);
                    return _Product3;
                }
            }

            return null;
        }

        public ShoppingCartItem GetProduct(int prodNum) 
        {
            if (_Product1.GetProduct().GetId() == prodNum)
            {
                return _Product1;
            }
            else if (_Product2.GetProduct().GetId() == prodNum)
            {
                return _Product2;
            }
            else if (_Product2.GetProduct().GetId() == prodNum)
            {
                return _Product2;
            }
            return null;
        }

        public decimal GetTotal() 
        {
            decimal price1 = (_Product1.GetQuantity() * _Product1.GetProduct().GetPrice());
            decimal price2 = (_Product2.GetQuantity() * _Product2.GetProduct().GetPrice());
            decimal price3 = (_Product3.GetQuantity() * _Product3.GetProduct().GetPrice());
          return price1 + price2 + price3;
        }
    }
}
