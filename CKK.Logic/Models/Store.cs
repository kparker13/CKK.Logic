using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Store : Entity
    {
        private List<StoreItem> Items = new();

        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            if (quantity < 0)
            {
                return null;
            }
            var doesContain =
                from item in Items
                where item.GetProduct().Equals(prod)
                select item;
            var tempItem = doesContain.FirstOrDefault();
            if (tempItem != null)
            {
                tempItem.SetQuantity(quantity += tempItem.GetQuantity());
                return tempItem;
            }
            var newItem = new StoreItem(prod, quantity);
            Items.Add(newItem);
            return newItem;
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            var itemSelect =
                from item in Items
                where item.GetProduct().GetId() == id
                select item;
            var changingItem = itemSelect.FirstOrDefault();
            if (changingItem.GetQuantity() - quantity <= 0) 
            {
                changingItem.SetQuantity(0);
                return changingItem;
            }
            changingItem.SetQuantity(changingItem.GetQuantity() - quantity);
            return changingItem;
        }

        public List<StoreItem> GetStoreItems()
        {
            return Items;
        }

        public StoreItem FindStoreItemById(int id)
        {
            var itemFound =
                from item in Items
                where item.GetProduct().GetId().Equals(id)
                select item;
            return itemFound.FirstOrDefault();
        }
    }
}
