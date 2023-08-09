namespace CKK.Logic
{
    public class StoreItem
    {
        
        private Product Product;
        private int Quantity;

        
        public StoreItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public int GetQuantity()

        { 
            return Quantity;
        }

        public void SetQuantity(int quantity) 
        {
            Quantity = quantity;
        }

        public Product GetProduct()
        {
            return Product;
        }

        public void SetProduct(Product product)
        {
            Product = product;
        }
    }
}

