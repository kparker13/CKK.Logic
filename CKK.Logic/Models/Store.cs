using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Store
    {
        private int Id;
        private string Name;
        private List<StoreItem> Items;

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {

            Name = name;
        }

        public StoreItem AddStoreItem(Product prod, int quantity)
        {

            var doesContain =
                from item in Items
                where item.GetProduct().Equals(prod)
                select item;
            var tempProd = doesContain.FirstOrDefault();
            if (tempProd != null)
            {
                tempProd.SetQuantity(quantity += tempProd.GetQuantity());
                return tempProd;
            }
            return new StoreItem(prod, quantity);
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            var itemSelect =
                from item in Items
                where item.GetProduct().GetId() == id
                select item;
            var changingItem = itemSelect.First();
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

        public Product FindStoreItemById(int id)
        {
            var itemFound =
                from item in Items
                where item.GetProduct().GetId().Equals(id)
                select item;
            return itemFound.First().GetProduct();
        }
    }
}
