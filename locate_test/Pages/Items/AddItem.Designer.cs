namespace ssms.Pages.Items
{
    partial class AddStock
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
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbStore = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lBarcodeMsg = new System.Windows.Forms.Label();
            this.bAddStore = new System.Windows.Forms.Button();
            this.cbBarcode = new System.Windows.Forms.ComboBox();
            this.bRfid = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.lblConnect = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lStoreMsg = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lEpcMsg1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lEpcMsg2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(376, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 25);
            this.label5.TabIndex = 216;
            this.label5.Text = "Add";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 42);
            this.label1.TabIndex = 210;
            this.label1.Text = "Add Items";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(17, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 242;
            this.label3.Text = "Barcode:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(198, 145);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(245, 26);
            this.textBox2.TabIndex = 249;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(17, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 19);
            this.label9.TabIndex = 248;
            this.label9.Text = "RFID Tag EPC:";
            // 
            // cbStore
            // 
            this.cbStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStore.FormattingEnabled = true;
            this.cbStore.Location = new System.Drawing.Point(198, 70);
            this.cbStore.Name = "cbStore";
            this.cbStore.Size = new System.Drawing.Size(245, 28);
            this.cbStore.TabIndex = 240;
            this.cbStore.SelectedIndexChanged += new System.EventHandler(this.addItem_store_SelectedIdxChg);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(17, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 19);
            this.label2.TabIndex = 241;
            this.label2.Text = "Machine Name:";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(738, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 330);
            this.panel1.TabIndex = 253;
            // 
            // lBarcodeMsg
            // 
            this.lBarcodeMsg.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBarcodeMsg.ForeColor = System.Drawing.Color.Red;
            this.lBarcodeMsg.Location = new System.Drawing.Point(18, 262);
            this.lBarcodeMsg.Name = "lBarcodeMsg";
            this.lBarcodeMsg.Size = new System.Drawing.Size(431, 32);
            this.lBarcodeMsg.TabIndex = 351;
            this.lBarcodeMsg.Text = "this barcode has not band any product yet, please band one product first.";
            this.lBarcodeMsg.Visible = false;
            // 
            // bAddStore
            // 
            this.bAddStore.BackColor = System.Drawing.Color.DodgerBlue;
            this.bAddStore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bAddStore.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bAddStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAddStore.ForeColor = System.Drawing.Color.White;
            this.bAddStore.Location = new System.Drawing.Point(449, 70);
            this.bAddStore.Name = "bAddStore";
            this.bAddStore.Size = new System.Drawing.Size(144, 26);
            this.bAddStore.TabIndex = 256;
            this.bAddStore.Text = "Add Machine";
            this.bAddStore.UseVisualStyleBackColor = false;
            this.bAddStore.Click += new System.EventHandler(this.addItem_addStore_click);
            // 
            // cbBarcode
            // 
            this.cbBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBarcode.FormattingEnabled = true;
            this.cbBarcode.Location = new System.Drawing.Point(198, 105);
            this.cbBarcode.Name = "cbBarcode";
            this.cbBarcode.Size = new System.Drawing.Size(245, 28);
            this.cbBarcode.TabIndex = 257;
            this.cbBarcode.SelectedIndexChanged += new System.EventHandler(this.addItem_barcode_selectedIdxChg);
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
            this.bRfid.Location = new System.Drawing.Point(449, 140);
            this.bRfid.Name = "bRfid";
            this.bRfid.Size = new System.Drawing.Size(117, 32);
            this.bRfid.TabIndex = 250;
            this.bRfid.Text = "RFID";
            this.bRfid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bRfid.UseVisualStyleBackColor = false;
            this.bRfid.Click += new System.EventHandler(this.addItem_rfid_click);
            // 
            // bBack
            // 
            this.bBack.BackgroundImage = global::ssms.Properties.Resources.reply__1_;
            this.bBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.bBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bBack.Location = new System.Drawing.Point(942, 373);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(61, 104);
            this.bBack.TabIndex = 217;
            this.bBack.Text = "Back";
            this.bBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bBack.UseVisualStyleBackColor = true;
            this.bBack.Click += new System.EventHandler(this.addItem_back_click);
            // 
            // bAdd
            // 
            this.bAdd.BackgroundImage = global::ssms.Properties.Resources.ok_appproval_acceptance__1_;
            this.bAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAdd.Location = new System.Drawing.Point(363, 178);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(80, 56);
            this.bAdd.TabIndex = 215;
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.addItem_add_click);
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnect.ForeColor = System.Drawing.Color.Red;
            this.lblConnect.Location = new System.Drawing.Point(593, 154);
            this.lblConnect.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(0, 16);
            this.lblConnect.TabIndex = 340;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(17, 211);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(187, 16);
            this.label16.TabIndex = 317;
            this.label16.Text = "Please choose a valid barcode!";
            this.label16.Visible = false;
            // 
            // lStoreMsg
            // 
            this.lStoreMsg.AutoSize = true;
            this.lStoreMsg.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStoreMsg.ForeColor = System.Drawing.Color.Red;
            this.lStoreMsg.Location = new System.Drawing.Point(17, 188);
            this.lStoreMsg.Name = "lStoreMsg";
            this.lStoreMsg.Size = new System.Drawing.Size(170, 16);
            this.lStoreMsg.TabIndex = 341;
            this.lStoreMsg.Text = "Please choose a valid store!";
            this.lStoreMsg.Visible = false;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(592, 185);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(18, 20);
            this.lblTimer.TabIndex = 347;
            this.lblTimer.Text = "0";
            // 
            // lEpcMsg1
            // 
            this.lEpcMsg1.AutoSize = true;
            this.lEpcMsg1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEpcMsg1.ForeColor = System.Drawing.Color.Red;
            this.lEpcMsg1.Location = new System.Drawing.Point(17, 237);
            this.lEpcMsg1.Name = "lEpcMsg1";
            this.lEpcMsg1.Size = new System.Drawing.Size(163, 16);
            this.lEpcMsg1.TabIndex = 342;
            this.lEpcMsg1.Text = "Please enter the RFID Tag!";
            this.lEpcMsg1.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(459, 185);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 20);
            this.label12.TabIndex = 349;
            this.label12.Text = "RFID Timer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(15, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 33);
            this.label4.TabIndex = 350;
            this.label4.Text = "Add Item";
            // 
            // lEpcMsg2
            // 
            this.lEpcMsg2.AutoSize = true;
            this.lEpcMsg2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEpcMsg2.ForeColor = System.Drawing.Color.Red;
            this.lEpcMsg2.Location = new System.Drawing.Point(18, 294);
            this.lEpcMsg2.Name = "lEpcMsg2";
            this.lEpcMsg2.Size = new System.Drawing.Size(16, 16);
            this.lEpcMsg2.TabIndex = 352;
            this.lEpcMsg2.Text = ",,";
            this.lEpcMsg2.Visible = false;
            // 
            // AddStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lEpcMsg2);
            this.Controls.Add(this.lBarcodeMsg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lEpcMsg1);
            this.Controls.Add(this.lStoreMsg);
            this.Controls.Add(this.lblConnect);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cbBarcode);
            this.Controls.Add(this.bAddStore);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bRfid);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbStore);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bAdd);
            this.Name = "AddStock";
            this.Size = new System.Drawing.Size(1031, 491);
            this.Load += new System.EventHandler(this.addItem_load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button bRfid;
        private System.Windows.Forms.ComboBox cbStore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bAddStore;
        private System.Windows.Forms.ComboBox cbBarcode;

      
  
        private System.Windows.Forms.Label lblConnect;
      

      
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lStoreMsg;
        

        private System.Windows.Forms.Label lblTimer;

        private System.Windows.Forms.Label lEpcMsg1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lBarcodeMsg;
        private System.Windows.Forms.Label lEpcMsg2;
    }
}
