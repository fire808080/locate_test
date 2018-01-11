namespace ssms.Pages.Items
{
    partial class Items
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioOutStock = new System.Windows.Forms.RadioButton();
            this.radioInStock = new System.Windows.Forms.RadioButton();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.bUpdateItem = new System.Windows.Forms.Button();
            this.bAddItem = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagEPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarcodeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.bViewItem = new System.Windows.Forms.Button();
            this.bScanItem = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // radioOutStock
            // 
            this.radioOutStock.AutoSize = true;
            this.radioOutStock.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioOutStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioOutStock.Location = new System.Drawing.Point(657, 32);
            this.radioOutStock.Name = "radioOutStock";
            this.radioOutStock.Size = new System.Drawing.Size(97, 20);
            this.radioOutStock.TabIndex = 86;
            this.radioOutStock.TabStop = true;
            this.radioOutStock.Text = "OutOfStock";
            this.radioOutStock.UseVisualStyleBackColor = true;
            this.radioOutStock.CheckedChanged += new System.EventHandler(this.item_radioOutStock_click);
            // 
            // radioInStock
            // 
            this.radioInStock.AutoSize = true;
            this.radioInStock.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioInStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioInStock.Location = new System.Drawing.Point(578, 32);
            this.radioInStock.Name = "radioInStock";
            this.radioInStock.Size = new System.Drawing.Size(73, 20);
            this.radioInStock.TabIndex = 85;
            this.radioInStock.TabStop = true;
            this.radioInStock.Text = "InStock";
            this.radioInStock.UseVisualStyleBackColor = true;
            this.radioInStock.CheckedChanged += new System.EventHandler(this.item_radioInStock_click);
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioAll.Location = new System.Drawing.Point(529, 32);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(43, 20);
            this.radioAll.TabIndex = 84;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "All";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.CheckedChanged += new System.EventHandler(this.item_radioAll_click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Silver;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(816, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(196, 43);
            this.button4.TabIndex = 83;
            this.button4.Text = "Export PDF";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.item_pdf_click);
            // 
            // bUpdateItem
            // 
            this.bUpdateItem.BackColor = System.Drawing.Color.RoyalBlue;
            this.bUpdateItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bUpdateItem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bUpdateItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bUpdateItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bUpdateItem.ForeColor = System.Drawing.Color.White;
            this.bUpdateItem.Location = new System.Drawing.Point(816, 143);
            this.bUpdateItem.Name = "bUpdateItem";
            this.bUpdateItem.Size = new System.Drawing.Size(196, 40);
            this.bUpdateItem.TabIndex = 82;
            this.bUpdateItem.Text = "Update Item";
            this.bUpdateItem.UseVisualStyleBackColor = false;
            this.bUpdateItem.Click += new System.EventHandler(this.item_updateItem_click);
            // 
            // bAddItem
            // 
            this.bAddItem.BackColor = System.Drawing.Color.RoyalBlue;
            this.bAddItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bAddItem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAddItem.ForeColor = System.Drawing.Color.White;
            this.bAddItem.Location = new System.Drawing.Point(816, 81);
            this.bAddItem.Name = "bAddItem";
            this.bAddItem.Size = new System.Drawing.Size(196, 40);
            this.bAddItem.TabIndex = 81;
            this.bAddItem.Text = "Add Item";
            this.bAddItem.UseVisualStyleBackColor = false;
            this.bAddItem.Click += new System.EventHandler(this.item_addItem_click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.TagEPC,
            this.ProductName,
            this.ProductDescription,
            this.BarcodeNumber,
            this.BrandName,
            this.CategoryName,
            this.ItemStatus,
            this.StoreName});
            this.dataGridView1.Location = new System.Drawing.Point(27, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(750, 395);
            this.dataGridView1.TabIndex = 80;
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "Item ID";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            // 
            // TagEPC
            // 
            this.TagEPC.HeaderText = "EPC";
            this.TagEPC.Name = "TagEPC";
            this.TagEPC.ReadOnly = true;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // ProductDescription
            // 
            this.ProductDescription.HeaderText = "Product Description";
            this.ProductDescription.Name = "ProductDescription";
            this.ProductDescription.ReadOnly = true;
            // 
            // BarcodeNumber
            // 
            this.BarcodeNumber.HeaderText = "Barcode Number";
            this.BarcodeNumber.Name = "BarcodeNumber";
            this.BarcodeNumber.ReadOnly = true;
            // 
            // BrandName
            // 
            this.BrandName.HeaderText = "Brand Name";
            this.BrandName.Name = "BrandName";
            this.BrandName.ReadOnly = true;
            // 
            // CategoryName
            // 
            this.CategoryName.HeaderText = "Category Name";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            // 
            // ItemStatus
            // 
            this.ItemStatus.HeaderText = "Item Status";
            this.ItemStatus.Name = "ItemStatus";
            this.ItemStatus.ReadOnly = true;
            // 
            // StoreName
            // 
            this.StoreName.HeaderText = "Machine Name";
            this.StoreName.Name = "StoreName";
            this.StoreName.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 33);
            this.label1.TabIndex = 79;
            this.label1.Text = "Items";
            // 
            // bViewItem
            // 
            this.bViewItem.BackColor = System.Drawing.Color.RoyalBlue;
            this.bViewItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bViewItem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bViewItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bViewItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bViewItem.ForeColor = System.Drawing.Color.White;
            this.bViewItem.Location = new System.Drawing.Point(816, 271);
            this.bViewItem.Name = "bViewItem";
            this.bViewItem.Size = new System.Drawing.Size(196, 40);
            this.bViewItem.TabIndex = 87;
            this.bViewItem.Text = "View Items per Machine";
            this.bViewItem.UseVisualStyleBackColor = false;
            this.bViewItem.Visible = false;
            this.bViewItem.Click += new System.EventHandler(this.item_viewItem_cick);
            // 
            // bScanItem
            // 
            this.bScanItem.BackColor = System.Drawing.Color.RoyalBlue;
            this.bScanItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bScanItem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bScanItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bScanItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bScanItem.ForeColor = System.Drawing.Color.White;
            this.bScanItem.Location = new System.Drawing.Point(816, 206);
            this.bScanItem.Name = "bScanItem";
            this.bScanItem.Size = new System.Drawing.Size(196, 40);
            this.bScanItem.TabIndex = 88;
            this.bScanItem.Text = "Scan Items in a Machine";
            this.bScanItem.UseVisualStyleBackColor = false;
            this.bScanItem.Click += new System.EventHandler(this.item_scanItem_click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.item_saveFileDialog1_FileOk);
            // 
            // Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bScanItem);
            this.Controls.Add(this.bViewItem);
            this.Controls.Add(this.radioOutStock);
            this.Controls.Add(this.radioInStock);
            this.Controls.Add(this.radioAll);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.bUpdateItem);
            this.Controls.Add(this.bAddItem);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Items";
            this.Size = new System.Drawing.Size(1031, 491);
            this.Load += new System.EventHandler(this.item_load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radioOutStock;
        private System.Windows.Forms.RadioButton radioInStock;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button bUpdateItem;
        private System.Windows.Forms.Button bAddItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bViewItem;
        private System.Windows.Forms.Button bScanItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagEPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarcodeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreName;
    }
}
