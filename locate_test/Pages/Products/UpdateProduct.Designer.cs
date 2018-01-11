namespace ssms.Pages.Products
{
    partial class UpdateProduct
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bAddBrand = new System.Windows.Forms.Button();
            this.bAddCategory = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxBrand = new System.Windows.Forms.ComboBox();
            this.tBarcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tProductDesc = new System.Windows.Forms.TextBox();
            this.tProductName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bAdd = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.tBarcodeSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bSearch = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarcodeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(727, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 251);
            this.panel1.TabIndex = 306;
            // 
            // bAddBrand
            // 
            this.bAddBrand.BackColor = System.Drawing.Color.MediumBlue;
            this.bAddBrand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bAddBrand.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bAddBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAddBrand.ForeColor = System.Drawing.Color.White;
            this.bAddBrand.Location = new System.Drawing.Point(454, 330);
            this.bAddBrand.Name = "bAddBrand";
            this.bAddBrand.Size = new System.Drawing.Size(144, 25);
            this.bAddBrand.TabIndex = 304;
            this.bAddBrand.Text = "Add Brand";
            this.bAddBrand.UseVisualStyleBackColor = false;
            this.bAddBrand.Click += new System.EventHandler(this.bAddBrand_Click);
            // 
            // bAddCategory
            // 
            this.bAddCategory.BackColor = System.Drawing.Color.MediumBlue;
            this.bAddCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bAddCategory.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAddCategory.ForeColor = System.Drawing.Color.White;
            this.bAddCategory.Location = new System.Drawing.Point(454, 360);
            this.bAddCategory.Name = "bAddCategory";
            this.bAddCategory.Size = new System.Drawing.Size(144, 27);
            this.bAddCategory.TabIndex = 303;
            this.bAddCategory.Text = "Add Category";
            this.bAddCategory.UseVisualStyleBackColor = false;
            this.bAddCategory.Click += new System.EventHandler(this.bAddCategory_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(202, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 18);
            this.label5.TabIndex = 301;
            this.label5.Text = "productID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(24, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 300;
            this.label2.Text = "Product ID:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(22, 364);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 19);
            this.label8.TabIndex = 295;
            this.label8.Text = "Category Name:";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(203, 360);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(245, 28);
            this.comboBoxCategory.TabIndex = 294;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(22, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 19);
            this.label4.TabIndex = 293;
            this.label4.Text = "Brand Name:";
            // 
            // comboBoxBrand
            // 
            this.comboBoxBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBrand.FormattingEnabled = true;
            this.comboBoxBrand.Location = new System.Drawing.Point(203, 329);
            this.comboBoxBrand.Name = "comboBoxBrand";
            this.comboBoxBrand.Size = new System.Drawing.Size(245, 28);
            this.comboBoxBrand.TabIndex = 292;
            // 
            // tBarcode
            // 
            this.tBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBarcode.Location = new System.Drawing.Point(203, 299);
            this.tBarcode.Name = "tBarcode";
            this.tBarcode.Size = new System.Drawing.Size(245, 26);
            this.tBarcode.TabIndex = 291;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(22, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 290;
            this.label3.Text = "Barcode:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(381, 448);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 25);
            this.label12.TabIndex = 287;
            this.label12.Text = "Add";
            // 
            // tProductDesc
            // 
            this.tProductDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tProductDesc.Location = new System.Drawing.Point(203, 267);
            this.tProductDesc.Name = "tProductDesc";
            this.tProductDesc.Size = new System.Drawing.Size(245, 26);
            this.tProductDesc.TabIndex = 285;
            // 
            // tProductName
            // 
            this.tProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tProductName.Location = new System.Drawing.Point(203, 237);
            this.tProductName.Name = "tProductName";
            this.tProductName.Size = new System.Drawing.Size(245, 26);
            this.tProductName.TabIndex = 284;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(22, 241);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 19);
            this.label13.TabIndex = 283;
            this.label13.Text = "Product Name:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(22, 270);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(168, 19);
            this.label14.TabIndex = 282;
            this.label14.Text = "Product Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 33);
            this.label1.TabIndex = 279;
            this.label1.Text = "Update Product";
            // 
            // bAdd
            // 
            this.bAdd.BackgroundImage = global::ssms.Properties.Resources.ok_appproval_acceptance__1_;
            this.bAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAdd.Location = new System.Drawing.Point(368, 391);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(80, 56);
            this.bAdd.TabIndex = 286;
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bBack
            // 
            this.bBack.BackgroundImage = global::ssms.Properties.Resources.reply__1_;
            this.bBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.bBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bBack.Location = new System.Drawing.Point(949, 367);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(61, 104);
            this.bBack.TabIndex = 281;
            this.bBack.Text = "Back";
            this.bBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bBack.UseVisualStyleBackColor = true;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // tBarcodeSearch
            // 
            this.tBarcodeSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBarcodeSearch.Location = new System.Drawing.Point(385, 16);
            this.tBarcodeSearch.Name = "tBarcodeSearch";
            this.tBarcodeSearch.Size = new System.Drawing.Size(245, 26);
            this.tBarcodeSearch.TabIndex = 308;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(323, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 307;
            this.label6.Text = "Barcode:";
            // 
            // bSearch
            // 
            this.bSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSearch.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bSearch.Image = global::ssms.Properties.Resources.search;
            this.bSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bSearch.Location = new System.Drawing.Point(636, 0);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(56, 52);
            this.bSearch.TabIndex = 309;
            this.bSearch.Text = "Search";
            this.bSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bSearch.UseVisualStyleBackColor = true;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.ProductName,
            this.ProductDescription,
            this.BarcodeNumber,
            this.BrandName,
            this.CategoryName});
            this.dgvProducts.Location = new System.Drawing.Point(26, 50);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.Size = new System.Drawing.Size(681, 162);
            this.dgvProducts.TabIndex = 310;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "Product ID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
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
            this.BarcodeNumber.HeaderText = "Bracode Number";
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
            // UpdateProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.tBarcodeSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bAddBrand);
            this.Controls.Add(this.bAddCategory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxBrand);
            this.Controls.Add(this.tBarcode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.tProductDesc);
            this.Controls.Add(this.tProductName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.label1);
            this.Name = "UpdateProduct";
            this.Size = new System.Drawing.Size(1031, 491);
            this.Load += new System.EventHandler(this.UpdateProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bAddBrand;
        private System.Windows.Forms.Button bAddCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxBrand;
        private System.Windows.Forms.TextBox tBarcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.TextBox tProductDesc;
        private System.Windows.Forms.TextBox tProductName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBarcodeSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarcodeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
    }
}
