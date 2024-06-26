using CKK.DB.Interfaces;
using CKK.DB.UOW;
using CKK.Logic;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using System.Collections.ObjectModel;
using System.Data;
namespace CKK.UI
{
    public partial class InventoryManagementForm : Form
    {
        public DatabaseConnectionFactory ConnectionFactory { get; set; }
        public UnitOfWork workingUnit { get; set; }
        public string? refreshArea { get; set; }
        public InventoryManagementForm()
        {
            ConnectionFactory = new DatabaseConnectionFactory();
            workingUnit = new UnitOfWork(ConnectionFactory);
            InitializeComponent();
            workingUnit.Products.GetAll().ForEach(product => { itemsBox.Items.Add(product); });
        }
         
        private void refreshItems(string area)
        {
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
                workingUnit.Products.Add(product);
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
                //Store.DeleteStoreItem(int.Parse(removeItemBox.Text));
                workingUnit.Products.Delete(workingUnit.Products.GetById(int.Parse(removeItemBox.Text)));
                refreshArea = "delete";
                refreshItems(refreshArea);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
