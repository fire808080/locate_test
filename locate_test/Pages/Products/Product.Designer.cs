namespace ssms.Pages.Products
{
    partial class Product
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
            this.bBrands = new System.Windows.Forms.Button();
            this.bCategories = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.bUpdateProduct = new System.Windows.Forms.Button();
            this.bAddProduct = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarcodeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // bBrands
            // 
            this.bBrands.BackColor = System.Drawing.Color.MediumBlue;
            this.bBrands.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bBrands.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bBrands.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBrands.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBrands.ForeColor = System.Drawing.Color.White;
            this.bBrands.Location = new System.Drawing.Point(865, 244);
            this.bBrands.Name = "bBrands";
            this.bBrands.Size = new System.Drawing.Size(123, 35);
            this.bBrands.TabIndex = 98;
            this.bBrands.Text = "Brands";
            this.bBrands.UseVisualStyleBackColor = false;
            this.bBrands.Click += new System.EventHandler(this.button5_Click);
            // 
            // bCategories
            // 
            this.bCategories.BackColor = System.Drawing.Color.MediumBlue;
            this.bCategories.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bCategories.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCategories.ForeColor = System.Drawing.Color.White;
            this.bCategories.Location = new System.Drawing.Point(865, 203);
            this.bCategories.Name = "bCategories";
            this.bCategories.Size = new System.Drawing.Size(123, 35);
            this.bCategories.TabIndex = 97;
            this.bCategories.Text = "Categories";
            this.bCategories.UseVisualStyleBackColor = false;
            this.bCategories.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Silver;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(849, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 42);
            this.button4.TabIndex = 93;
            this.button4.Text = "Export PDF";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // bUpdateProduct
            // 
            this.bUpdateProduct.BackColor = System.Drawing.Color.LightSkyBlue;
            this.bUpdateProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bUpdateProduct.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bUpdateProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bUpdateProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bUpdateProduct.ForeColor = System.Drawing.Color.White;
            this.bUpdateProduct.Location = new System.Drawing.Point(849, 142);
            this.bUpdateProduct.Name = "bUpdateProduct";
            this.bUpdateProduct.Size = new System.Drawing.Size(150, 40);
            this.bUpdateProduct.TabIndex = 92;
            this.bUpdateProduct.Text = "Update Product";
            this.bUpdateProduct.UseVisualStyleBackColor = false;
            this.bUpdateProduct.Click += new System.EventHandler(this.button3_Click);
            // 
            // bAddProduct
            // 
            this.bAddProduct.BackColor = System.Drawing.Color.LightSkyBlue;
            this.bAddProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bAddProduct.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAddProduct.ForeColor = System.Drawing.Color.White;
            this.bAddProduct.Location = new System.Drawing.Point(849, 80);
            this.bAddProduct.Name = "bAddProduct";
            this.bAddProduct.Size = new System.Drawing.Size(150, 40);
            this.bAddProduct.TabIndex = 91;
            this.bAddProduct.Text = "Add Product";
            this.bAddProduct.UseVisualStyleBackColor = false;
            this.bAddProduct.Click += new System.EventHandler(this.button1_Click);
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
            this.dgvProducts.Location = new System.Drawing.Point(14, 64);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.Size = new System.Drawing.Size(750, 395);
            this.dgvProducts.TabIndex = 90;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 33);
            this.label1.TabIndex = 89;
            this.label1.Text = "Products";
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bBrands);
            this.Controls.Add(this.bCategories);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.bUpdateProduct);
            this.Controls.Add(this.bAddProduct);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.label1);
            this.Name = "Product";
            this.Size = new System.Drawing.Size(1031, 491);
			this.Load += new System.EventHandler(this.Products_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bBrands;
        private System.Windows.Forms.Button bCategories;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button bUpdateProduct;
        private System.Windows.Forms.Button bAddProduct;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarcodeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
    }
}
