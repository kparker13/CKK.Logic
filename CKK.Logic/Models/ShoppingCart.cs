using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {

        public ShoppingCart(Customer cust)
        {
            Customer = cust;
        }
		public List<ShoppingCartItem> ShoppingCartItems { get; set; };
		public int ShoppingCartId { get; set; }
		public Customer Customer { get; set; }

		public Product Products { get; set; }

		public int CustomerId { get; set; }

    }
}
