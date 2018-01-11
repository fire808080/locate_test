namespace ssms.Pages.Settings
{
    partial class AddSettings
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
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.buttonAddAntenna = new System.Windows.Forms.Button();
            this.buttonRemoveAntenna = new System.Windows.Forms.Button();
            this.flpAntennaConfig = new System.Windows.Forms.FlowLayoutPanel();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxStore = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSettingsName = new System.Windows.Forms.TextBox();
            this.dataGridViewReaders = new System.Windows.Forms.DataGridView();
            this.IPaddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numAntennas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.btAddReader = new System.Windows.Forms.Button();
            this.buttonRemoveReader = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbReaderType = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReaders)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbReaderType);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.buttonAddAntenna);
            this.panel1.Controls.Add(this.buttonRemoveAntenna);
            this.panel1.Controls.Add(this.flpAntennaConfig);
            this.panel1.Controls.Add(this.txtIP);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(479, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 301);
            this.panel1.TabIndex = 278;
            this.panel1.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(476, 281);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 18);
            this.label9.TabIndex = 288;
            this.label9.Text = "Cancle";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ssms.Properties.Resources.reply;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(479, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 38);
            this.button1.TabIndex = 287;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addSettings_cancle_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(419, 281);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 18);
            this.label8.TabIndex = 286;
            this.label8.Text = "Submit";
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::ssms.Properties.Resources.ok_appproval_acceptance__1_;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(422, 241);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(51, 38);
            this.button6.TabIndex = 286;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.addSettings_antennaSubmit_Click);
            // 
            // buttonAddAntenna
            // 
            this.buttonAddAntenna.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonAddAntenna.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAddAntenna.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAddAntenna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddAntenna.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddAntenna.ForeColor = System.Drawing.Color.White;
            this.buttonAddAntenna.Location = new System.Drawing.Point(3, 268);
            this.buttonAddAntenna.Name = "buttonAddAntenna";
            this.buttonAddAntenna.Size = new System.Drawing.Size(150, 26);
            this.buttonAddAntenna.TabIndex = 285;
            this.buttonAddAntenna.Text = "Add Antenna";
            this.buttonAddAntenna.UseVisualStyleBackColor = false;
            this.buttonAddAntenna.Click += new System.EventHandler(this.addSettings_addAntenna_Click);
            // 
            // buttonRemoveAntenna
            // 
            this.buttonRemoveAntenna.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonRemoveAntenna.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRemoveAntenna.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonRemoveAntenna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveAntenna.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveAntenna.ForeColor = System.Drawing.Color.White;
            this.buttonRemoveAntenna.Location = new System.Drawing.Point(159, 268);
            this.buttonRemoveAntenna.Name = "buttonRemoveAntenna";
            this.buttonRemoveAntenna.Size = new System.Drawing.Size(150, 26);
            this.buttonRemoveAntenna.TabIndex = 286;
            this.buttonRemoveAntenna.Text = "Remove Antenna";
            this.buttonRemoveAntenna.UseVisualStyleBackColor = false;
            this.buttonRemoveAntenna.Click += new System.EventHandler(this.addSettings_delAntenna_Click);
            // 
            // flpAntennaConfig
            // 
            this.flpAntennaConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpAntennaConfig.AutoScroll = true;
            this.flpAntennaConfig.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAntennaConfig.Location = new System.Drawing.Point(6, 71);
            this.flpAntennaConfig.Name = "flpAntennaConfig";
            this.flpAntennaConfig.Size = new System.Drawing.Size(527, 166);
            this.flpAntennaConfig.TabIndex = 284;
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.Location = new System.Drawing.Point(99, 42);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(187, 26);
            this.txtIP.TabIndex = 283;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(5, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 19);
            this.label7.TabIndex = 282;
            this.label7.Text = "IP Address:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(3, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 25);
            this.label6.TabIndex = 258;
            this.label6.Text = "Add Reader";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(11, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 19);
            this.label2.TabIndex = 266;
            this.label2.Text = "Machine Name:";
            // 
            // comboBoxStore
            // 
            this.comboBoxStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStore.FormattingEnabled = true;
            this.comboBoxStore.Location = new System.Drawing.Point(147, 61);
            this.comboBoxStore.Name = "comboBoxStore";
            this.comboBoxStore.Size = new System.Drawing.Size(245, 28);
            this.comboBoxStore.TabIndex = 265;
            this.comboBoxStore.SelectedIndexChanged += new System.EventHandler(this.addSettings_storeIdxChg);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(866, 461);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 25);
            this.label5.TabIndex = 263;
            this.label5.Text = "Add";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 33);
            this.label1.TabIndex = 257;
            this.label1.Text = "Add Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(11, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 19);
            this.label3.TabIndex = 280;
            this.label3.Text = "Settings Name:";
            // 
            // txtSettingsName
            // 
            this.txtSettingsName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSettingsName.Location = new System.Drawing.Point(147, 95);
            this.txtSettingsName.Name = "txtSettingsName";
            this.txtSettingsName.Size = new System.Drawing.Size(245, 26);
            this.txtSettingsName.TabIndex = 281;
            // 
            // dataGridViewReaders
            // 
            this.dataGridViewReaders.AllowUserToAddRows = false;
            this.dataGridViewReaders.AllowUserToDeleteRows = false;
            this.dataGridViewReaders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReaders.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewReaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReaders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IPaddress,
            this.numAntennas});
            this.dataGridViewReaders.GridColor = System.Drawing.Color.White;
            this.dataGridViewReaders.Location = new System.Drawing.Point(17, 150);
            this.dataGridViewReaders.MultiSelect = false;
            this.dataGridViewReaders.Name = "dataGridViewReaders";
            this.dataGridViewReaders.ReadOnly = true;
            this.dataGridViewReaders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReaders.Size = new System.Drawing.Size(394, 131);
            this.dataGridViewReaders.TabIndex = 282;
            // 
            // IPaddress
            // 
            this.IPaddress.HeaderText = "IP Address";
            this.IPaddress.Name = "IPaddress";
            this.IPaddress.ReadOnly = true;
            // 
            // numAntennas
            // 
            this.numAntennas.HeaderText = "Number of Antennas";
            this.numAntennas.Name = "numAntennas";
            this.numAntennas.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(13, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 19);
            this.label4.TabIndex = 283;
            this.label4.Text = "Readers:";
            // 
            // btAddReader
            // 
            this.btAddReader.BackColor = System.Drawing.Color.MidnightBlue;
            this.btAddReader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btAddReader.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAddReader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddReader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddReader.ForeColor = System.Drawing.Color.White;
            this.btAddReader.Location = new System.Drawing.Point(135, 287);
            this.btAddReader.Name = "btAddReader";
            this.btAddReader.Size = new System.Drawing.Size(135, 26);
            this.btAddReader.TabIndex = 284;
            this.btAddReader.Text = "Add Reader";
            this.btAddReader.UseVisualStyleBackColor = false;
            this.btAddReader.Click += new System.EventHandler(this.addSettings_addReader_click);
            // 
            // buttonRemoveReader
            // 
            this.buttonRemoveReader.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonRemoveReader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRemoveReader.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonRemoveReader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveReader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveReader.ForeColor = System.Drawing.Color.White;
            this.buttonRemoveReader.Location = new System.Drawing.Point(276, 287);
            this.buttonRemoveReader.Name = "buttonRemoveReader";
            this.buttonRemoveReader.Size = new System.Drawing.Size(135, 26);
            this.buttonRemoveReader.TabIndex = 285;
            this.buttonRemoveReader.Text = "Remove Reader";
            this.buttonRemoveReader.UseVisualStyleBackColor = false;
            this.buttonRemoveReader.Click += new System.EventHandler(this.addSettings_delReader_click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackgroundImage = global::ssms.Properties.Resources.reply__1_;
            this.buttonBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.buttonBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonBack.Location = new System.Drawing.Point(938, 384);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(61, 107);
            this.buttonBack.TabIndex = 264;
            this.buttonBack.Text = "Back";
            this.buttonBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.addSettings_back_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::ssms.Properties.Resources.ok_appproval_acceptance__1_;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(852, 405);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 56);
            this.btnAdd.TabIndex = 262;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.addSettings_add_click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(306, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 19);
            this.label10.TabIndex = 289;
            this.label10.Text = "Reader Type:";
            // 
            // cbReaderType
            // 
            this.cbReaderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbReaderType.FormattingEnabled = true;
            this.cbReaderType.Location = new System.Drawing.Point(413, 40);
            this.cbReaderType.Name = "cbReaderType";
            this.cbReaderType.Size = new System.Drawing.Size(82, 28);
            this.cbReaderType.TabIndex = 286;
            // 
            // AddSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonRemoveReader);
            this.Controls.Add(this.btAddReader);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewReaders);
            this.Controls.Add(this.txtSettingsName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxStore);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Name = "AddSettings";
            this.Size = new System.Drawing.Size(1031, 491);
            this.Load += new System.EventHandler(this.addSettings_load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReaders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxStore;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSettingsName;
        private System.Windows.Forms.DataGridView dataGridViewReaders;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btAddReader;
        private System.Windows.Forms.Button buttonRemoveReader;
        private System.Windows.Forms.FlowLayoutPanel flpAntennaConfig;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAddAntenna;
        private System.Windows.Forms.Button buttonRemoveAntenna;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPaddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn numAntennas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbReaderType;
    }
}
