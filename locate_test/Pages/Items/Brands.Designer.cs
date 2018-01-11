namespace ssms.Pages.Items
{
    partial class Brands
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
            this.btnExportBrands = new System.Windows.Forms.Button();
            this.btnUpdateBrand = new System.Windows.Forms.Button();
            this.btnAddBrand = new System.Windows.Forms.Button();
            this.dgvBrands = new System.Windows.Forms.DataGridView();
            this.BrandID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrands)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportBrands
            // 
            this.btnExportBrands.BackColor = System.Drawing.Color.Silver;
            this.btnExportBrands.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExportBrands.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExportBrands.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportBrands.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportBrands.ForeColor = System.Drawing.Color.White;
            this.btnExportBrands.Location = new System.Drawing.Point(857, 16);
            this.btnExportBrands.Name = "btnExportBrands";
            this.btnExportBrands.Size = new System.Drawing.Size(145, 42);
            this.btnExportBrands.TabIndex = 93;
            this.btnExportBrands.Text = "Export PDF";
            this.btnExportBrands.UseVisualStyleBackColor = false;
            // 
            // btnUpdateBrand
            // 
            this.btnUpdateBrand.BackColor = System.Drawing.Color.MediumBlue;
            this.btnUpdateBrand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdateBrand.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUpdateBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateBrand.ForeColor = System.Drawing.Color.White;
            this.btnUpdateBrand.Location = new System.Drawing.Point(857, 142);
            this.btnUpdateBrand.Name = "btnUpdateBrand";
            this.btnUpdateBrand.Size = new System.Drawing.Size(145, 40);
            this.btnUpdateBrand.TabIndex = 92;
            this.btnUpdateBrand.Text = "Update Brand";
            this.btnUpdateBrand.UseVisualStyleBackColor = false;
            this.btnUpdateBrand.Click += new System.EventHandler(this.btnUpdateBrand_Click);
            // 
            // btnAddBrand
            // 
            this.btnAddBrand.BackColor = System.Drawing.Color.MediumBlue;
            this.btnAddBrand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddBrand.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBrand.ForeColor = System.Drawing.Color.White;
            this.btnAddBrand.Location = new System.Drawing.Point(857, 80);
            this.btnAddBrand.Name = "btnAddBrand";
            this.btnAddBrand.Size = new System.Drawing.Size(145, 40);
            this.btnAddBrand.TabIndex = 91;
            this.btnAddBrand.Text = "Add Brand";
            this.btnAddBrand.UseVisualStyleBackColor = false;
            this.btnAddBrand.Click += new System.EventHandler(this.btnAddBrand_Click);
            // 
            // dgvBrands
            // 
            this.dgvBrands.AllowUserToAddRows = false;
            this.dgvBrands.AllowUserToDeleteRows = false;
            this.dgvBrands.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBrands.BackgroundColor = System.Drawing.Color.White;
            this.dgvBrands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBrands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BrandID,
            this.BrandName,
            this.BrandDescription});
            this.dgvBrands.Location = new System.Drawing.Point(17, 64);
            this.dgvBrands.Name = "dgvBrands";
            this.dgvBrands.ReadOnly = true;
            this.dgvBrands.RowHeadersVisible = false;
            this.dgvBrands.Size = new System.Drawing.Size(750, 395);
            this.dgvBrands.TabIndex = 90;
            // 
            // BrandID
            // 
            this.BrandID.HeaderText = "Brand ID";
            this.BrandID.Name = "BrandID";
            this.BrandID.ReadOnly = true;
            // 
            // BrandName
            // 
            this.BrandName.HeaderText = "Brand Name";
            this.BrandName.Name = "BrandName";
            this.BrandName.ReadOnly = true;
            // 
            // BrandDescription
            // 
            this.BrandDescription.HeaderText = "Brand Description";
            this.BrandDescription.Name = "BrandDescription";
            this.BrandDescription.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 33);
            this.label1.TabIndex = 89;
            this.label1.Text = "Brands";
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = global::ssms.Properties.Resources.reply__1_;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBack.Location = new System.Drawing.Point(967, 384);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(61, 104);
            this.btnBack.TabIndex = 218;
            this.btnBack.Text = "Back";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.button2_Click);
            // 
            // Brands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnExportBrands);
            this.Controls.Add(this.btnUpdateBrand);
            this.Controls.Add(this.btnAddBrand);
            this.Controls.Add(this.dgvBrands);
            this.Controls.Add(this.label1);
            this.Name = "Brands";
            this.Size = new System.Drawing.Size(1031, 491);
			this.Load += new System.EventHandler(this.Brands_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrands)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportBrands;
        private System.Windows.Forms.Button btnUpdateBrand;
        private System.Windows.Forms.Button btnAddBrand;
        private System.Windows.Forms.DataGridView dgvBrands;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandDescription;
    }
}
