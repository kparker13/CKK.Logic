namespace CKK.UI
{
    partial class InventoryManagementForm : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            bannerLabel = new Label();
            itemsLabel = new Label();
            createItemLabel = new Label();
            itemNameBox = new TextBox();
            itemIdBox = new TextBox();
            itemPriceBox = new TextBox();
            itemQuantityBox = new TextBox();
            newItemButton = new Button();
            removeItemLabel = new Label();
            removeItemBox = new TextBox();
            removeButton = new Button();
            itemsBox = new ComboBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonShadow;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(bannerLabel);
            panel1.Location = new Point(-2, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(804, 76);
            panel1.TabIndex = 0;
            // 
            // bannerLabel
            // 
            bannerLabel.AutoSize = true;
            bannerLabel.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bannerLabel.Location = new Point(13, 10);
            bannerLabel.Name = "bannerLabel";
            bannerLabel.Size = new Size(458, 62);
            bannerLabel.TabIndex = 0;
            bannerLabel.Text = "Corey's Knick Knacks";
            // 
            // itemsLabel
            // 
            itemsLabel.AutoSize = true;
            itemsLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            itemsLabel.Location = new Point(598, 88);
            itemsLabel.Name = "itemsLabel";
            itemsLabel.Size = new Size(155, 31);
            itemsLabel.TabIndex = 2;
            itemsLabel.Text = "View all Items";
            // 
            // createItemLabel
            // 
            createItemLabel.AutoSize = true;
            createItemLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createItemLabel.Location = new Point(20, 88);
            createItemLabel.Name = "createItemLabel";
            createItemLabel.Size = new Size(161, 31);
            createItemLabel.TabIndex = 3;
            createItemLabel.Text = "Add New Item";
            // 
            // itemNameBox
            // 
            itemNameBox.Location = new Point(21, 131);
            itemNameBox.Name = "itemNameBox";
            itemNameBox.PlaceholderText = "Item Name";
            itemNameBox.Size = new Size(174, 27);
            itemNameBox.TabIndex = 4;
            // 
            // itemIdBox
            // 
            itemIdBox.Location = new Point(20, 182);
            itemIdBox.Name = "itemIdBox";
            itemIdBox.PlaceholderText = "Item ID";
            itemIdBox.Size = new Size(175, 27);
            itemIdBox.TabIndex = 5;
            // 
            // itemPriceBox
            // 
            itemPriceBox.Location = new Point(21, 233);
            itemPriceBox.Name = "itemPriceBox";
            itemPriceBox.PlaceholderText = "Item Price";
            itemPriceBox.Size = new Size(174, 27);
            itemPriceBox.TabIndex = 6;
            // 
            // itemQuantityBox
            // 
            itemQuantityBox.Location = new Point(21, 277);
            itemQuantityBox.Name = "itemQuantityBox";
            itemQuantityBox.PlaceholderText = "Item Quantity";
            itemQuantityBox.Size = new Size(174, 27);
            itemQuantityBox.TabIndex = 7;
            // 
            // newItemButton
            // 
            newItemButton.Location = new Point(58, 322);
            newItemButton.Name = "newItemButton";
            newItemButton.Size = new Size(94, 29);
            newItemButton.TabIndex = 8;
            newItemButton.Text = "Add Item";
            newItemButton.UseVisualStyleBackColor = true;
            newItemButton.Click += newItemButton_Click;
            // 
            // removeItemLabel
            // 
            removeItemLabel.AutoSize = true;
            removeItemLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            removeItemLabel.Location = new Point(606, 233);
            removeItemLabel.Name = "removeItemLabel";
            removeItemLabel.Size = new Size(147, 31);
            removeItemLabel.TabIndex = 9;
            removeItemLabel.Text = "Remove Item";
            // 
            // removeItemBox
            // 
            removeItemBox.Location = new Point(580, 277);
            removeItemBox.Name = "removeItemBox";
            removeItemBox.PlaceholderText = "Enter ID";
            removeItemBox.Size = new Size(194, 27);
            removeItemBox.TabIndex = 10;
            // 
            // removeButton
            // 
            removeButton.Location = new Point(622, 322);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(117, 29);
            removeButton.TabIndex = 11;
            removeButton.Text = "Remove Item";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // itemsBox
            // 
            itemsBox.FormattingEnabled = true;
            itemsBox.Location = new Point(580, 130);
            itemsBox.Name = "itemsBox";
            itemsBox.Size = new Size(194, 28);
            itemsBox.TabIndex = 12;
            // 
            // InventoryManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(itemsBox);
            Controls.Add(removeButton);
            Controls.Add(removeItemBox);
            Controls.Add(removeItemLabel);
            Controls.Add(newItemButton);
            Controls.Add(itemQuantityBox);
            Controls.Add(itemPriceBox);
            Controls.Add(itemIdBox);
            Controls.Add(itemNameBox);
            Controls.Add(createItemLabel);
            Controls.Add(itemsLabel);
            Controls.Add(panel1);
            Name = "InventoryManagementForm";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label bannerLabel;
        private Label itemsLabel;
        private Label createItemLabel;
        private TextBox itemNameBox;
        private TextBox itemIdBox;
        private TextBox itemPriceBox;
        private TextBox itemQuantityBox;
        private Button newItemButton;
        private Label removeItemLabel;
        private TextBox removeItemBox;
        private Button removeButton;
        private ComboBox itemsBox;
    }
}
