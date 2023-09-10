﻿using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    public interface IShoppingCart
    {
        int GetCustomerId();
        ShoppingCartItem AddProduct(Product prod, int quant);
        ShoppingCartItem RemoveProduct(int id, int quant);
        decimal GetTotal();
        ShoppingCartItem GetProductById(int id);
        List<ShoppingCartItem> GetProducts();

    }
}
