using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CKK.Logic
{
    public class ShoppingCartItem
    {
        private Product Product;
        private int Quantity;

        public ShoppingCartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public Product GetProduct()
        {
            return Product;
        }

        public void SetProduct(Product product)
        {
            Product = product;
        }

        public decimal GetTotal() 
        {
            return Quantity * Product.GetPrice();

        }
    }
}
