namespace ssms.Pages
{
    partial class UpdateStore
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
            this.dgvUpdateStore = new System.Windows.Forms.DataGridView();
            this.StoreID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStoreLocation = new System.Windows.Forms.TextBox();
            this.txtStoreName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bBack = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateStore)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUpdateStore
            // 
            this.dgvUpdateStore.AllowUserToAddRows = false;
            this.dgvUpdateStore.AllowUserToDeleteRows = false;
            this.dgvUpdateStore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUpdateStore.BackgroundColor = System.Drawing.Color.White;
            this.dgvUpdateStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpdateStore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StoreID,
            this.StoreName,
            this.StoreLocation});
            this.dgvUpdateStore.Location = new System.Drawing.Point(17, 64);
            this.dgvUpdateStore.Name = "dgvUpdateStore";
            this.dgvUpdateStore.ReadOnly = true;
            this.dgvUpdateStore.RowHeadersVisible = false;
            this.dgvUpdateStore.Size = new System.Drawing.Size(750, 150);
            this.dgvUpdateStore.TabIndex = 95;
            this.dgvUpdateStore.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUpdateStore_CellClick);
            // 
            // StoreID
            // 
            this.StoreID.HeaderText = "Machine ID";
            this.StoreID.Name = "StoreID";
            this.StoreID.ReadOnly = true;
            // 
            // StoreName
            // 
            this.StoreName.HeaderText = "Machine Name";
            this.StoreName.Name = "StoreName";
            this.StoreName.ReadOnly = true;
            // 
            // StoreLocation
            // 
            this.StoreLocation.HeaderText = "Machine Location";
            this.StoreLocation.Name = "StoreLocation";
            this.StoreLocation.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 33);
            this.label1.TabIndex = 94;
            this.label1.Text = "Update Machine";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(366, 378);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 25);
            this.label5.TabIndex = 197;
            this.label5.Text = "Update";
            // 
            // txtStoreLocation
            // 
            this.txtStoreLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoreLocation.Location = new System.Drawing.Point(202, 289);
            this.txtStoreLocation.Name = "txtStoreLocation";
            this.txtStoreLocation.Size = new System.Drawing.Size(245, 26);
            this.txtStoreLocation.TabIndex = 191;
            // 
            // txtStoreName
            // 
            this.txtStoreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoreName.Location = new System.Drawing.Point(202, 257);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.Size = new System.Drawing.Size(245, 26);
            this.txtStoreName.TabIndex = 190;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(21, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 19);
            this.label7.TabIndex = 189;
            this.label7.Text = "Machine Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(209, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 188;
            this.label2.Text = "machineID";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.Location = new System.Drawing.Point(21, 234);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 19);
            this.label16.TabIndex = 187;
            this.label16.Text = "Machine ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(21, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 19);
            this.label6.TabIndex = 182;
            this.label6.Text = "Machine Location:";
            // 
            // bBack
            // 
            this.bBack.BackgroundImage = global::ssms.Properties.Resources.reply__1_;
            this.bBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.bBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bBack.Location = new System.Drawing.Point(947, 378);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(61, 104);
            this.bBack.TabIndex = 198;
            this.bBack.Text = "Back";
            this.bBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bBack.UseVisualStyleBackColor = true;
            this.bBack.Click += new System.EventHandler(this.updateStore_back_click);
            // 
            // bUpdate
            // 
            this.bUpdate.BackgroundImage = global::ssms.Properties.Resources.ok_appproval_acceptance__1_;
            this.bUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bUpdate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bUpdate.Location = new System.Drawing.Point(367, 318);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(80, 56);
            this.bUpdate.TabIndex = 196;
            this.bUpdate.UseVisualStyleBackColor = true;
            this.bUpdate.Click += new System.EventHandler(this.updateStore_update_click);
            // 
            // UpdateStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.txtStoreLocation);
            this.Controls.Add(this.txtStoreName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvUpdateStore);
            this.Controls.Add(this.label1);
            this.Name = "UpdateStore";
            this.Size = new System.Drawing.Size(1031, 491);
            this.Load += new System.EventHandler(this.updateStore_load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateStore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvUpdateStore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.TextBox txtStoreLocation;
        private System.Windows.Forms.TextBox txtStoreName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreLocation;
    }
}
