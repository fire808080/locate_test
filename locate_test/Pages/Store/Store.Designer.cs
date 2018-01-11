namespace ssms.Pages.Store
{
    partial class Store
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
            this.bSaveFile = new System.Windows.Forms.Button();
            this.bUpdateStore = new System.Windows.Forms.Button();
            this.bAddStore = new System.Windows.Forms.Button();
            this.dgvStore = new System.Windows.Forms.DataGridView();
            this.StoreID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).BeginInit();
            this.SuspendLayout();
            // 
            // bSaveFile
            // 
            this.bSaveFile.BackColor = System.Drawing.Color.Silver;
            this.bSaveFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bSaveFile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bSaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSaveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSaveFile.ForeColor = System.Drawing.Color.White;
            this.bSaveFile.Location = new System.Drawing.Point(867, 16);
            this.bSaveFile.Name = "bSaveFile";
            this.bSaveFile.Size = new System.Drawing.Size(145, 42);
            this.bSaveFile.TabIndex = 93;
            this.bSaveFile.Text = "Export PDF";
            this.bSaveFile.UseVisualStyleBackColor = false;
            this.bSaveFile.Click += new System.EventHandler(this.store_saveFile_click);
            // 
            // bUpdateStore
            // 
            this.bUpdateStore.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bUpdateStore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bUpdateStore.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bUpdateStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bUpdateStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bUpdateStore.ForeColor = System.Drawing.Color.White;
            this.bUpdateStore.Location = new System.Drawing.Point(867, 142);
            this.bUpdateStore.Name = "bUpdateStore";
            this.bUpdateStore.Size = new System.Drawing.Size(145, 40);
            this.bUpdateStore.TabIndex = 92;
            this.bUpdateStore.Text = "Update Machine";
            this.bUpdateStore.UseVisualStyleBackColor = false;
            this.bUpdateStore.Click += new System.EventHandler(this.store_updateStore_click);
            // 
            // bAddStore
            // 
            this.bAddStore.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bAddStore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bAddStore.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bAddStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAddStore.ForeColor = System.Drawing.Color.White;
            this.bAddStore.Location = new System.Drawing.Point(867, 80);
            this.bAddStore.Name = "bAddStore";
            this.bAddStore.Size = new System.Drawing.Size(145, 40);
            this.bAddStore.TabIndex = 91;
            this.bAddStore.Text = "Add Machine";
            this.bAddStore.UseVisualStyleBackColor = false;
            this.bAddStore.Click += new System.EventHandler(this.store_addStore_click);
            // 
            // dgvStore
            // 
            this.dgvStore.AllowUserToAddRows = false;
            this.dgvStore.AllowUserToDeleteRows = false;
            this.dgvStore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStore.BackgroundColor = System.Drawing.Color.White;
            this.dgvStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StoreID,
            this.StoreName,
            this.StoreLocation,
            this.AmountItems});
            this.dgvStore.Location = new System.Drawing.Point(27, 64);
            this.dgvStore.Name = "dgvStore";
            this.dgvStore.ReadOnly = true;
            this.dgvStore.RowHeadersVisible = false;
            this.dgvStore.Size = new System.Drawing.Size(750, 395);
            this.dgvStore.TabIndex = 90;
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
            // AmountItems
            // 
            this.AmountItems.HeaderText = "Amount of Items";
            this.AmountItems.Name = "AmountItems";
            this.AmountItems.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(30, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 33);
            this.label1.TabIndex = 89;
            this.label1.Text = "Machines";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.store_saveFileDialog_ok);
            // 
            // Store
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bSaveFile);
            this.Controls.Add(this.bUpdateStore);
            this.Controls.Add(this.bAddStore);
            this.Controls.Add(this.dgvStore);
            this.Controls.Add(this.label1);
            this.Name = "Store";
            this.Size = new System.Drawing.Size(1031, 491);
            this.Load += new System.EventHandler(this.store_load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSaveFile;
        private System.Windows.Forms.Button bUpdateStore;
        private System.Windows.Forms.Button bAddStore;
        private System.Windows.Forms.DataGridView dgvStore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountItems;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
