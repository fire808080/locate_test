namespace ssms.Pages.Items
{
    partial class ScanItemsInStore
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbStore = new System.Windows.Forms.ComboBox();
            this.bExportPdf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bConnect = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbxMissing = new System.Windows.Forms.ListBox();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbReader = new System.Windows.Forms.ListBox();
            this.setName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lConnect = new System.Windows.Forms.Label();
            this.lStart = new System.Windows.Forms.Label();
            this.lStop = new System.Windows.Forms.Label();
            this.lSettingsMsg = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(429, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 19);
            this.label2.TabIndex = 323;
            this.label2.Text = "Machine Name:";
            // 
            // cbStore
            // 
            this.cbStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStore.FormattingEnabled = true;
            this.cbStore.Location = new System.Drawing.Point(562, 11);
            this.cbStore.Name = "cbStore";
            this.cbStore.Size = new System.Drawing.Size(245, 28);
            this.cbStore.TabIndex = 322;
            this.cbStore.SelectedIndexChanged += new System.EventHandler(this.scanItem_cbStore_selectIdxChg);
            // 
            // bExportPdf
            // 
            this.bExportPdf.BackColor = System.Drawing.Color.Silver;
            this.bExportPdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bExportPdf.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bExportPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bExportPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExportPdf.ForeColor = System.Drawing.Color.White;
            this.bExportPdf.Location = new System.Drawing.Point(813, 3);
            this.bExportPdf.Name = "bExportPdf";
            this.bExportPdf.Size = new System.Drawing.Size(196, 42);
            this.bExportPdf.TabIndex = 318;
            this.bExportPdf.Text = "Export PDF";
            this.bExportPdf.UseVisualStyleBackColor = false;
            this.bExportPdf.Click += new System.EventHandler(this.scanItem_exportPdf_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 33);
            this.label1.TabIndex = 316;
            this.label1.Text = "Scan Items in Machine";
            // 
            // bConnect
            // 
            this.bConnect.BackColor = System.Drawing.Color.White;
            this.bConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bConnect.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bConnect.ForeColor = System.Drawing.Color.DimGray;
            this.bConnect.Image = global::ssms.Properties.Resources.icons8_RFID_Signal_64;
            this.bConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bConnect.Location = new System.Drawing.Point(3, 80);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(150, 32);
            this.bConnect.TabIndex = 329;
            this.bConnect.Text = "Connect";
            this.bConnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bConnect.UseVisualStyleBackColor = false;
            this.bConnect.Click += new System.EventHandler(this.scanItem_connect_click);
            // 
            // bStart
            // 
            this.bStart.BackgroundImage = global::ssms.Properties.Resources.play_button__1_;
            this.bStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bStart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.bStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bStart.Location = new System.Drawing.Point(3, 119);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(67, 43);
            this.bStart.TabIndex = 327;
            this.bStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.scanItem_start_click);
            // 
            // bStop
            // 
            this.bStop.BackgroundImage = global::ssms.Properties.Resources.stop;
            this.bStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bStop.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.bStop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bStop.Location = new System.Drawing.Point(3, 168);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(67, 43);
            this.bStop.TabIndex = 326;
            this.bStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.button1_Click);
            // 
            // bBack
            // 
            this.bBack.BackgroundImage = global::ssms.Properties.Resources.reply__1_;
            this.bBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.bBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bBack.Location = new System.Drawing.Point(948, 377);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(61, 104);
            this.bBack.TabIndex = 325;
            this.bBack.Text = "Back";
            this.bBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bBack.UseVisualStyleBackColor = true;
            this.bBack.Click += new System.EventHandler(this.scanItem_back_click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(67, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 22);
            this.label6.TabIndex = 332;
            this.label6.Text = "Start";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F);
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(67, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 22);
            this.label7.TabIndex = 333;
            this.label7.Text = "Stop";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(587, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 23);
            this.label5.TabIndex = 337;
            this.label5.Text = "Missing Items";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(318, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 23);
            this.label4.TabIndex = 336;
            this.label4.Text = "Inventory";
            // 
            // lbxMissing
            // 
            this.lbxMissing.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxMissing.ForeColor = System.Drawing.Color.Red;
            this.lbxMissing.FormattingEnabled = true;
            this.lbxMissing.HorizontalScrollbar = true;
            this.lbxMissing.ItemHeight = 19;
            this.lbxMissing.Location = new System.Drawing.Point(514, 110);
            this.lbxMissing.Name = "lbxMissing";
            this.lbxMissing.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxMissing.Size = new System.Drawing.Size(261, 308);
            this.lbxMissing.TabIndex = 335;
            // 
            // lbItems
            // 
            this.lbItems.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItems.ForeColor = System.Drawing.Color.Black;
            this.lbItems.FormattingEnabled = true;
            this.lbItems.HorizontalScrollbar = true;
            this.lbItems.ItemHeight = 19;
            this.lbItems.Location = new System.Drawing.Point(235, 110);
            this.lbItems.Name = "lbItems";
            this.lbItems.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbItems.Size = new System.Drawing.Size(261, 308);
            this.lbItems.TabIndex = 334;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.scanItem_saveFile_ok);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbReader);
            this.panel1.Controls.Add(this.setName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(795, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 179);
            this.panel1.TabIndex = 338;
            this.panel1.Visible = false;
            // 
            // lbReader
            // 
            this.lbReader.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReader.FormattingEnabled = true;
            this.lbReader.ItemHeight = 16;
            this.lbReader.Location = new System.Drawing.Point(18, 41);
            this.lbReader.Name = "lbReader";
            this.lbReader.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbReader.Size = new System.Drawing.Size(183, 116);
            this.lbReader.TabIndex = 3;
            // 
            // setName
            // 
            this.setName.AutoSize = true;
            this.setName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setName.Location = new System.Drawing.Point(119, 18);
            this.setName.Name = "setName";
            this.setName.Size = new System.Drawing.Size(0, 14);
            this.setName.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 12);
            this.label8.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Settings Name:";
            // 
            // lConnect
            // 
            this.lConnect.AutoSize = true;
            this.lConnect.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lConnect.ForeColor = System.Drawing.Color.Red;
            this.lConnect.Location = new System.Drawing.Point(17, 247);
            this.lConnect.Name = "lConnect";
            this.lConnect.Size = new System.Drawing.Size(85, 16);
            this.lConnect.TabIndex = 339;
            this.lConnect.Text = "Connecting...";
            this.lConnect.Visible = false;
            // 
            // lStart
            // 
            this.lStart.AutoSize = true;
            this.lStart.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStart.ForeColor = System.Drawing.Color.Red;
            this.lStart.Location = new System.Drawing.Point(17, 285);
            this.lStart.Name = "lStart";
            this.lStart.Size = new System.Drawing.Size(65, 16);
            this.lStart.TabIndex = 340;
            this.lStart.Text = "Starting...";
            this.lStart.Visible = false;
            // 
            // lStop
            // 
            this.lStop.AutoSize = true;
            this.lStop.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStop.ForeColor = System.Drawing.Color.Red;
            this.lStop.Location = new System.Drawing.Point(17, 326);
            this.lStop.Name = "lStop";
            this.lStop.Size = new System.Drawing.Size(71, 16);
            this.lStop.TabIndex = 341;
            this.lStop.Text = "Stopping...";
            this.lStop.Visible = false;
            // 
            // lSettingsMsg
            // 
            this.lSettingsMsg.AutoSize = true;
            this.lSettingsMsg.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSettingsMsg.ForeColor = System.Drawing.Color.Red;
            this.lSettingsMsg.Location = new System.Drawing.Point(17, 361);
            this.lSettingsMsg.Name = "lSettingsMsg";
            this.lSettingsMsg.Size = new System.Drawing.Size(92, 16);
            this.lSettingsMsg.TabIndex = 342;
            this.lSettingsMsg.Text = "settings is null";
            this.lSettingsMsg.Visible = false;
            this.lSettingsMsg.Click += new System.EventHandler(this.label9_Click);
            // 
            // ScanItemsInStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lSettingsMsg);
            this.Controls.Add(this.lStop);
            this.Controls.Add(this.lStart);
            this.Controls.Add(this.lConnect);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbxMissing);
            this.Controls.Add(this.lbItems);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bConnect);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbStore);
            this.Controls.Add(this.bExportPdf);
            this.Controls.Add(this.label1);
            this.Name = "ScanItemsInStore";
            this.Size = new System.Drawing.Size(1031, 491);
            this.Load += new System.EventHandler(this.scanItem_load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbStore;
        private System.Windows.Forms.Button bExportPdf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bStart;
        public System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbxMissing;
        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label setName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbReader;
        private System.Windows.Forms.Label lConnect;
        private System.Windows.Forms.Label lStart;
        private System.Windows.Forms.Label lStop;
        private System.Windows.Forms.Label lSettingsMsg;
    }
}
