using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Store : Entity, IStore
    {
        private List<StoreItem> Items = new();

        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            if (quantity <= 0)
            {
                throw new InventoryItemStockTooLowException();
            }
            var doesContain =
                from item in Items
                where item.Product.Equals(prod)
                select item;
            var tempItem = doesContain.FirstOrDefault();
            if (tempItem != null)
            {
                tempItem.Quantity += quantity;
                return tempItem;
            }
            var newItem = new StoreItem(prod, quantity);
            Items.Add(newItem);
            return newItem;
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            if (quantity < 0) { throw new ArgumentOutOfRangeException(); }
            var itemSelect =
                from item in Items
                where item.Product.Id == id
                select item;
            var changingItem = itemSelect.FirstOrDefault();
            if ( changingItem == null)
            {
                throw new ProductDoesNotExistException();
            }
            if (changingItem.Quantity - quantity == 0) 
            {
                changingItem.Quantity = 0;
                return changingItem;
            }
            changingItem.Quantity -= quantity;
            return changingItem;
        }

        public List<StoreItem> GetStoreItems()
        {
            return Items;
        }

        public StoreItem FindStoreItemById(int id)
        {
            if (id < 0) { throw new InvalidIdException(); }
            var itemFound =
                from item in Items
                where item.Product.Id.Equals(id)
                select item;
            return itemFound.FirstOrDefault();
        }
    }
}
