using CKK.Logic;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using System.Collections.ObjectModel;

namespace CKK.UI
{
    public partial class InventoryManagementForm : Form
    {
        private IStore Store;
        public List<StoreItem> items { get; set; }
        public string? refreshArea { get; set; }
        public InventoryManagementForm()
        {
            Store = new Store();
            items = Store.GetStoreItems();
            InitializeComponent();
            foreach (StoreItem item in items)
            {
                itemsBox.Items.Add(item);
            }
        }

        private void refreshItems(string area)
        {
            items = Store.GetStoreItems();
            foreach (StoreItem item in items)
            {
                if (!itemsBox.Items.Contains(item.ToString()))
                {
                    itemsBox.Items.Add(item.ToString());
                }
            }
            if (area == "new")
            {
                itemNameBox.Text = string.Empty;
                itemIdBox.Text = string.Empty;
                itemPriceBox.Text = string.Empty;
                itemQuantityBox.Text = string.Empty;
            }
            if (area == "delete")
            {
                removeItemBox.Text = string.Empty;
            }
        }

        private void newItemButton_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product();
                product.Name = itemNameBox.Text;
                product.Price = Decimal.Parse(itemPriceBox.Text);
                product.Id = int.Parse(itemIdBox.Text);
                Store.AddStoreItem(product, int.Parse(itemQuantityBox.Text));
                refreshArea = "new";
                refreshItems(refreshArea);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                Store.DeleteStoreItem(int.Parse(removeItemBox.Text));
                refreshArea = "delete";
                refreshItems(refreshArea);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void quantSortButton_Click(object sender, EventArgs e)
        {
            var sorted = Store.GetProductsByQuantity();
            itemsBox.Items.Clear();
            foreach (var product in sorted)
            {
                itemsBox.Items.Add(product);
            }
        }

        private void costSortButton_Click(object sender, EventArgs e)
        {
            var sorted = Store.GetProductsByPrice();
            itemsBox.Items.Clear();
            foreach (var product in sorted)
            {
                itemsBox.Items.Add(product);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
        }
    }
}
