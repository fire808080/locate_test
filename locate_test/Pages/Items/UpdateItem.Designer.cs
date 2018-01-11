namespace ssms.Pages.Items
{
    partial class UpdateItem
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbEpc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbStore = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.addStore = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bSearch = new System.Windows.Forms.Button();
            this.bRfidSearch = new System.Windows.Forms.Button();
            this.bRfid = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.cbBarcode = new System.Windows.Forms.ComboBox();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagEPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarcodeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label16 = new System.Windows.Forms.Label();
            this.lblConnect = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lStoreMsg = new System.Windows.Forms.Label();
            this.lBarcodeMsg = new System.Windows.Forms.Label();
            this.lConnectMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 33);
            this.label1.TabIndex = 210;
            this.label1.Text = "Update Item";
            // 
            // tbEpc
            // 
            this.tbEpc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEpc.Location = new System.Drawing.Point(206, 322);
            this.tbEpc.Name = "tbEpc";
            this.tbEpc.Size = new System.Drawing.Size(245, 26);
            this.tbEpc.TabIndex = 268;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(25, 326);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 19);
            this.label9.TabIndex = 267;
            this.label9.Text = "RFID Tag EPC:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(25, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 261;
            this.label3.Text = "Barcode:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(24, 253);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 19);
            this.label11.TabIndex = 260;
            this.label11.Text = "Machine Name:";
            // 
            // cbStore
            // 
            this.cbStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStore.FormattingEnabled = true;
            this.cbStore.Location = new System.Drawing.Point(206, 245);
            this.cbStore.Name = "cbStore";
            this.cbStore.Size = new System.Drawing.Size(245, 28);
            this.cbStore.TabIndex = 259;
            this.cbStore.SelectedIndexChanged += new System.EventHandler(this.updateItem_store_SelectedIdxChg);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(497, 520);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 25);
            this.label12.TabIndex = 258;
            this.label12.Text = "Update";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(25, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 272;
            this.label2.Text = "Item ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(203, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 18);
            this.label5.TabIndex = 273;
            this.label5.Text = "itemID";
            // 
            // addStore
            // 
            this.addStore.BackColor = System.Drawing.Color.DodgerBlue;
            this.addStore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addStore.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.addStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStore.ForeColor = System.Drawing.Color.White;
            this.addStore.Location = new System.Drawing.Point(457, 245);
            this.addStore.Name = "addStore";
            this.addStore.Size = new System.Drawing.Size(144, 26);
            this.addStore.TabIndex = 277;
            this.addStore.Text = "Add Machine";
            this.addStore.UseVisualStyleBackColor = false;
            this.addStore.Click += new System.EventHandler(this.updateItem_addStore_click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(728, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 251);
            this.panel1.TabIndex = 278;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(377, 22);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(216, 26);
            this.textBox3.TabIndex = 311;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(285, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 16);
            this.label6.TabIndex = 310;
            this.label6.Text = "RFID Tag EPC:";
            // 
            // bSearch
            // 
            this.bSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSearch.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bSearch.Image = global::ssms.Properties.Resources.search;
            this.bSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bSearch.Location = new System.Drawing.Point(653, 3);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(56, 52);
            this.bSearch.TabIndex = 313;
            this.bSearch.Text = "Search";
            this.bSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.updateItem_search_click);
            // 
            // bRfidSearch
            // 
            this.bRfidSearch.BackColor = System.Drawing.Color.White;
            this.bRfidSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bRfidSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bRfidSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRfidSearch.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRfidSearch.ForeColor = System.Drawing.Color.DimGray;
            this.bRfidSearch.Image = global::ssms.Properties.Resources.icons8_RFID_Signal_64SMALL;
            this.bRfidSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bRfidSearch.Location = new System.Drawing.Point(599, 10);
            this.bRfidSearch.Name = "bRfidSearch";
            this.bRfidSearch.Size = new System.Drawing.Size(48, 44);
            this.bRfidSearch.TabIndex = 312;
            this.bRfidSearch.Text = "RFID";
            this.bRfidSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bRfidSearch.UseVisualStyleBackColor = false;
            this.bRfidSearch.Click += new System.EventHandler(this.updateItem_rfidSearch_click);
            // 
            // bRfid
            // 
            this.bRfid.BackColor = System.Drawing.Color.White;
            this.bRfid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bRfid.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bRfid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRfid.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRfid.ForeColor = System.Drawing.Color.DimGray;
            this.bRfid.Image = global::ssms.Properties.Resources.icons8_RFID_Signal_64;
            this.bRfid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bRfid.Location = new System.Drawing.Point(457, 318);
            this.bRfid.Name = "bRfid";
            this.bRfid.Size = new System.Drawing.Size(115, 32);
            this.bRfid.TabIndex = 274;
            this.bRfid.Text = "RFID";
            this.bRfid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bRfid.UseVisualStyleBackColor = false;
            this.bRfid.Click += new System.EventHandler(this.updateItem_rfid_click);
            // 
            // bUpdate
            // 
            this.bUpdate.BackgroundImage = global::ssms.Properties.Resources.ok_appproval_acceptance__1_;
            this.bUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bUpdate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bUpdate.Location = new System.Drawing.Point(371, 363);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(80, 56);
            this.bUpdate.TabIndex = 257;
            this.bUpdate.UseVisualStyleBackColor = true;
            this.bUpdate.Click += new System.EventHandler(this.updateItem_update_click);
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
            this.bBack.TabIndex = 220;
            this.bBack.Text = "Back";
            this.bBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bBack.UseVisualStyleBackColor = true;
            this.bBack.Click += new System.EventHandler(this.updateItem_back_click);
            // 
            // cbBarcode
            // 
            this.cbBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBarcode.FormattingEnabled = true;
            this.cbBarcode.Location = new System.Drawing.Point(206, 284);
            this.cbBarcode.Name = "cbBarcode";
            this.cbBarcode.Size = new System.Drawing.Size(245, 28);
            this.cbBarcode.TabIndex = 314;
            this.cbBarcode.SelectedIndexChanged += new System.EventHandler(this.updateItem_barcode_SelectedIdxChg);
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            this.dgvItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItem.BackgroundColor = System.Drawing.Color.White;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.TagEPC,
            this.ProductName,
            this.ProductDescription,
            this.BarcodeNumber,
            this.BrandName,
            this.CategoryName,
            this.ItemStatus});
            this.dgvItem.GridColor = System.Drawing.Color.White;
            this.dgvItem.Location = new System.Drawing.Point(29, 52);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.RowHeadersVisible = false;
            this.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItem.Size = new System.Drawing.Size(680, 165);
            this.dgvItem.TabIndex = 315;
            this.dgvItem.SelectionChanged += new System.EventHandler(this.updateItem_dgvItem_SelectionChanged);
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "Item ID";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            this.ItemID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TagEPC
            // 
            this.TagEPC.HeaderText = "EPC";
            this.TagEPC.Name = "TagEPC";
            this.TagEPC.ReadOnly = true;
            this.TagEPC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ProductDescription
            // 
            this.ProductDescription.HeaderText = "Product Description";
            this.ProductDescription.Name = "ProductDescription";
            this.ProductDescription.ReadOnly = true;
            this.ProductDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BarcodeNumber
            // 
            this.BarcodeNumber.HeaderText = "Barcode Number";
            this.BarcodeNumber.Name = "BarcodeNumber";
            this.BarcodeNumber.ReadOnly = true;
            this.BarcodeNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BrandName
            // 
            this.BrandName.HeaderText = "Brand Name";
            this.BrandName.Name = "BrandName";
            this.BrandName.ReadOnly = true;
            this.BrandName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CategoryName
            // 
            this.CategoryName.HeaderText = "Category Name";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            this.CategoryName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ItemStatus
            // 
            this.ItemStatus.HeaderText = "Item Status";
            this.ItemStatus.Name = "ItemStatus";
            this.ItemStatus.ReadOnly = true;
            this.ItemStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(25, 383);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(205, 16);
            this.label16.TabIndex = 316;
            this.label16.Text = "Please enter information correctly!";
            this.label16.Visible = false;
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnect.ForeColor = System.Drawing.Color.Red;
            this.lblConnect.Location = new System.Drawing.Point(470, 363);
            this.lblConnect.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(0, 16);
            this.lblConnect.TabIndex = 341;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(864, 450);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(24, 25);
            this.lblTimer.TabIndex = 349;
            this.lblTimer.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(26, 415);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(245, 16);
            this.label7.TabIndex = 344;
            this.label7.Text = "Please choose a valid store and barcode!";
            this.label7.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(26, 450);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 16);
            this.label4.TabIndex = 345;
            this.label4.Text = "Please enter the RFID Tag!";
            this.label4.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(372, 422);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 25);
            this.label8.TabIndex = 350;
            this.label8.Text = "Update";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(723, 450);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 25);
            this.label10.TabIndex = 351;
            this.label10.Text = "RFID Timer:";
            // 
            // lStoreMsg
            // 
            this.lStoreMsg.AutoSize = true;
            this.lStoreMsg.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStoreMsg.ForeColor = System.Drawing.Color.Red;
            this.lStoreMsg.Location = new System.Drawing.Point(470, 373);
            this.lStoreMsg.Name = "lStoreMsg";
            this.lStoreMsg.Size = new System.Drawing.Size(12, 16);
            this.lStoreMsg.TabIndex = 352;
            this.lStoreMsg.Text = ",";
            // 
            // lBarcodeMsg
            // 
            this.lBarcodeMsg.AutoSize = true;
            this.lBarcodeMsg.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBarcodeMsg.ForeColor = System.Drawing.Color.Red;
            this.lBarcodeMsg.Location = new System.Drawing.Point(470, 403);
            this.lBarcodeMsg.Name = "lBarcodeMsg";
            this.lBarcodeMsg.Size = new System.Drawing.Size(16, 16);
            this.lBarcodeMsg.TabIndex = 353;
            this.lBarcodeMsg.Text = ",,";
            // 
            // lConnectMsg
            // 
            this.lConnectMsg.AutoSize = true;
            this.lConnectMsg.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lConnectMsg.ForeColor = System.Drawing.Color.Red;
            this.lConnectMsg.Location = new System.Drawing.Point(470, 431);
            this.lConnectMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lConnectMsg.Name = "lConnectMsg";
            this.lConnectMsg.Size = new System.Drawing.Size(20, 16);
            this.lConnectMsg.TabIndex = 354;
            this.lConnectMsg.Text = ",,,";
            // 
            // UpdateItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lConnectMsg);
            this.Controls.Add(this.lBarcodeMsg);
            this.Controls.Add(this.lStoreMsg);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblConnect);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvItem);
            this.Controls.Add(this.cbBarcode);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.bRfidSearch);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.addStore);
            this.Controls.Add(this.bRfid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbEpc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbStore);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.label1);
            this.Name = "UpdateItem";
            this.Size = new System.Drawing.Size(1031, 491);
            this.Load += new System.EventHandler(this.updateItem_load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEpc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbStore;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button addStore;
        public System.Windows.Forms.Button bRfid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button bRfidSearch;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.ComboBox cbBarcode;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagEPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarcodeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemStatus;

        private System.Windows.Forms.Label lblConnect;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label label7;


       
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lStoreMsg;
        private System.Windows.Forms.Label lBarcodeMsg;
        private System.Windows.Forms.Label lConnectMsg;
    }
}
