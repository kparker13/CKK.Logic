using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    [Serializable]
    public class InventoryItemStockTooLowException : Exception
    {
        public InventoryItemStockTooLowException() :base("Item quantitiy cannot be below zero") { }
        public InventoryItemStockTooLowException(string message) 
            : base (message){ }
        public InventoryItemStockTooLowException(string message, Exception inner) : base(message, inner) { }
    }
}
