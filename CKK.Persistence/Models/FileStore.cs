using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using CKK.Persistence.Interfaces;

namespace CKK.Persistence.Models
{
    internal class FileStore : IStore, ISavable, ILoadable
    {
        public String FilePath {  get; private set; }
        private List<StoreItem> Items;
        private int IdCounter;
        public FileStore() 
        {
            Items = GetStoreItems();
            CreatePath();
        }

        public void DeleteStoreItem(int id) { }

        public List<StoreItem> GetStoreItems()
        {
            return Items;
        }

        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            try
            {
                var newItem = new StoreItem(prod, quantity);
                foreach (var item in Items)
                {
                    if (!Items.Contains(newItem))
                    {
                        Items.Add(newItem);
                    }
                    else item.Quantity += quantity;
                }
                return newItem;
            }
            catch
            {
                if (quantity <= 0)
                {
                    throw new InventoryItemStockTooLowException();
                }
                else throw;
            }
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            try
            {
                var foundItem = FindStoreItemById(id);
                if (foundItem != null)
                {
                    if (foundItem.Quantity > quantity)
                    {
                        foundItem.Quantity -= quantity;
                    }
                    else if (foundItem.Quantity < quantity) 
                    {
                        foundItem.Quantity = 0;
                    }
                }
                return foundItem;
            }
            catch
            {
                if (quantity <= 0)
                {
                    throw new InventoryItemStockTooLowException();
                }
                else throw;
            }
        }  

        public StoreItem FindStoreItemById(int id)
        {
            try
            {
                foreach (var item in Items)
                {
                    if (item.Product.Id == id)
                    {
                        return item;
                    }
                }
                return null;
            }
            catch
            {
                if (id <= 0)
                {
                    throw new IndexOutOfRangeException();
                }
                else throw;
            }
        }

        public void CreatePath()
        {
            var exists = false;
            try 
            {
                FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + Path.DirectorySeparatorChar + "Persistance" + Path.DirectorySeparatorChar + "StoreItems.dat";
                if (Path.Exists(FilePath))
                {
                    exists = true;
                }
            }
            catch when (!exists)
            {
                throw new IOException("Selected file destination does not exist or is invalid");
            }
        }

        public void Save()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream output = new FileStream("StoreSaveFile", FileMode.OpenOrCreate, FileAccess.Write);
                var content = GetStoreItems();
                bf.Serialize(output, content);
                output.Close();
            }
            catch
            {
                throw;
            }
        }

        public void Load()
        {
            try
            {
                FileStream input = new FileStream("StoreSaveFile", FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                Items = (List<StoreItem>) bf.Deserialize(input);
            }
            catch
            {
                throw;
            }
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
