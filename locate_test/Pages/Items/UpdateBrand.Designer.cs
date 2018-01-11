namespace ssms.Pages.Items
{
    partial class UpdateBrand
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
            this.bBack = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.bBrandUpdate = new System.Windows.Forms.Button();
            this.tBrandDesc = new System.Windows.Forms.TextBox();
            this.tBrandName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvUpdateBrand = new System.Windows.Forms.DataGridView();
            this.BrandID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateBrand)).BeginInit();
            this.SuspendLayout();
            // 
            // bBack
            // 
            this.bBack.BackgroundImage = global::ssms.Properties.Resources.reply__1_;
            this.bBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.bBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bBack.Location = new System.Drawing.Point(950, 373);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(61, 104);
            this.bBack.TabIndex = 209;
            this.bBack.Text = "Back";
            this.bBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bBack.UseVisualStyleBackColor = true;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(369, 373);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 25);
            this.label5.TabIndex = 208;
            this.label5.Text = "Update";
            // 
            // bBrandUpdate
            // 
            this.bBrandUpdate.BackgroundImage = global::ssms.Properties.Resources.ok_appproval_acceptance__1_;
            this.bBrandUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bBrandUpdate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bBrandUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBrandUpdate.Location = new System.Drawing.Point(370, 314);
            this.bBrandUpdate.Name = "bBrandUpdate";
            this.bBrandUpdate.Size = new System.Drawing.Size(80, 56);
            this.bBrandUpdate.TabIndex = 207;
            this.bBrandUpdate.UseVisualStyleBackColor = true;
            this.bBrandUpdate.Click += new System.EventHandler(this.bBrandUpdate_Click);
            // 
            // tBrandDesc
            // 
            this.tBrandDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBrandDesc.Location = new System.Drawing.Point(205, 284);
            this.tBrandDesc.Name = "tBrandDesc";
            this.tBrandDesc.Size = new System.Drawing.Size(245, 26);
            this.tBrandDesc.TabIndex = 206;
            // 
            // tBrandName
            // 
            this.tBrandName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBrandName.Location = new System.Drawing.Point(205, 252);
            this.tBrandName.Name = "tBrandName";
            this.tBrandName.Size = new System.Drawing.Size(245, 26);
            this.tBrandName.TabIndex = 205;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(24, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 19);
            this.label7.TabIndex = 204;
            this.label7.Text = "Brand Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(212, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 18);
            this.label2.TabIndex = 203;
            this.label2.Text = "brandID";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.Location = new System.Drawing.Point(24, 230);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 19);
            this.label16.TabIndex = 202;
            this.label16.Text = "Brand ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(24, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 19);
            this.label6.TabIndex = 201;
            this.label6.Text = "Brand Description:";
            // 
            // dgvUpdateBrand
            // 
            this.dgvUpdateBrand.AllowUserToAddRows = false;
            this.dgvUpdateBrand.AllowUserToDeleteRows = false;
            this.dgvUpdateBrand.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUpdateBrand.BackgroundColor = System.Drawing.Color.White;
            this.dgvUpdateBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpdateBrand.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BrandID,
            this.BrandName,
            this.BrandDescription});
            this.dgvUpdateBrand.Location = new System.Drawing.Point(20, 59);
            this.dgvUpdateBrand.Name = "dgvUpdateBrand";
            this.dgvUpdateBrand.ReadOnly = true;
            this.dgvUpdateBrand.RowHeadersVisible = false;
            this.dgvUpdateBrand.Size = new System.Drawing.Size(750, 150);
            this.dgvUpdateBrand.TabIndex = 200;
            this.dgvUpdateBrand.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUpdateBrand_CellClick);
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
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 33);
            this.label1.TabIndex = 199;
            this.label1.Text = "Update Brand";
            // 
            // UpdateBrand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bBrandUpdate);
            this.Controls.Add(this.tBrandDesc);
            this.Controls.Add(this.tBrandName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvUpdateBrand);
            this.Controls.Add(this.label1);
            this.Name = "UpdateBrand";
            this.Size = new System.Drawing.Size(1031, 491);
            this.Load += new System.EventHandler(this.UpdateBrand_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateBrand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bBrandUpdate;
        private System.Windows.Forms.TextBox tBrandDesc;
        private System.Windows.Forms.TextBox tBrandName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvUpdateBrand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandDescription;
    }
}
