﻿using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Customer : Entity
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } 
        public int ShoppingCartId { get; set; } 
    }
}
