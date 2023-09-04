using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CKK.Logic.Models
{
    public class Product : Entity
    {

        private decimal price;

        public decimal Price
        { 
            get { return price; } 
            set 
            {
                if (price > 0.0M)
                {
                    price = value;
                }
            }
        }
        
    }
}

