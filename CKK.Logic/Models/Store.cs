using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;

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
            if (changingItem.Quantity - quantity <= 0) 
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

        public void DeleteStoreItem(int id)
        {
            try
            {
                Items.Remove(FindStoreItemById(id));
                
            }
            catch { throw new ProductDoesNotExistException(); }
        }

        public List<StoreItem> GetAllProductsByName(string name)
        {
            var searchList = GetStoreItems();
            List<StoreItem> toReturn = new List<StoreItem>();
            foreach (var item in searchList)
            {
                if (item.Product.Name.Equals(name))
                {
                    toReturn.Add(item);
                }
            }
            return toReturn;
        }

        public List<StoreItem> GetProductsByQuantity()
        {
            var searchList = GetStoreItems();
            for (var i = 0; i < searchList.Count - 1; i++)
            {
                var currentLargest = i;
                for (var j = i + 1; j < searchList.Count; j++)
                {
                    if (searchList[j].Quantity > searchList[currentLargest].Quantity)
                    {
                        currentLargest = j;
                    }
                }
                var temp = searchList[i];
                searchList[i] = searchList[currentLargest];
                searchList[currentLargest] = temp;
            }
            return searchList;
        }

        public List<StoreItem> GetProductsByPrice()
        {
            var searchList = GetStoreItems();
            for (var i = 0; i < searchList.Count - 1; i++)
            {
                var currentLargest = i;
                for (var j = i + 1; j < searchList.Count; j++)
                {
                    if (searchList[j].Product.Price > searchList[currentLargest].Product.Price)
                    {
                        currentLargest = j;
                    }
                }
                var temp = searchList[i];
                searchList[i] = searchList[currentLargest];
                searchList[currentLargest] = temp;
            }
            return searchList;
        }
    }
}
