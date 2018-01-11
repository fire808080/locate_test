namespace ssms.Pages
{
    partial class UpdateSettings
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
            this.buttonRemoveReader = new System.Windows.Forms.Button();
            this.bAddReader = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvReaders = new System.Windows.Forms.DataGridView();
            this.IPaddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numAntennas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonSubmitReader = new System.Windows.Forms.Button();
            this.buttonAddAntenna = new System.Windows.Forms.Button();
            this.buttonRemoveAntenna = new System.Windows.Forms.Button();
            this.flpAntennaConfig = new System.Windows.Forms.FlowLayoutPanel();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxStore = new System.Windows.Forms.ComboBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.comboBoxSettings = new System.Windows.Forms.ComboBox();
            this.tSettingsName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbReaderType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReaders)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRemoveReader
            // 
            this.buttonRemoveReader.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonRemoveReader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRemoveReader.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonRemoveReader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveReader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveReader.ForeColor = System.Drawing.Color.White;
            this.buttonRemoveReader.Location = new System.Drawing.Point(275, 317);
            this.buttonRemoveReader.Name = "buttonRemoveReader";
            this.buttonRemoveReader.Size = new System.Drawing.Size(135, 26);
            this.buttonRemoveReader.TabIndex = 298;
            this.buttonRemoveReader.Text = "Remove Reader";
            this.buttonRemoveReader.UseVisualStyleBackColor = false;
            this.buttonRemoveReader.Click += new System.EventHandler(this.updateSettings_rmReader_click);
            // 
            // bAddReader
            // 
            this.bAddReader.BackColor = System.Drawing.Color.MidnightBlue;
            this.bAddReader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bAddReader.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bAddReader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddReader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAddReader.ForeColor = System.Drawing.Color.White;
            this.bAddReader.Location = new System.Drawing.Point(134, 317);
            this.bAddReader.Name = "bAddReader";
            this.bAddReader.Size = new System.Drawing.Size(135, 26);
            this.bAddReader.TabIndex = 297;
            this.bAddReader.Text = "Add Reader";
            this.bAddReader.UseVisualStyleBackColor = false;
            this.bAddReader.Click += new System.EventHandler(this.updateSettings_addReader_click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(12, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 19);
            this.label4.TabIndex = 296;
            this.label4.Text = "Readers:";
            // 
            // dgvReaders
            // 
            this.dgvReaders.AllowUserToAddRows = false;
            this.dgvReaders.AllowUserToDeleteRows = false;
            this.dgvReaders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReaders.BackgroundColor = System.Drawing.Color.White;
            this.dgvReaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReaders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IPaddress,
            this.numAntennas});
            this.dgvReaders.GridColor = System.Drawing.Color.White;
            this.dgvReaders.Location = new System.Drawing.Point(16, 180);
            this.dgvReaders.MultiSelect = false;
            this.dgvReaders.Name = "dgvReaders";
            this.dgvReaders.ReadOnly = true;
            this.dgvReaders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReaders.Size = new System.Drawing.Size(394, 131);
            this.dgvReaders.TabIndex = 295;
            this.dgvReaders.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReaders_RowEnter);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 19);
            this.label3.TabIndex = 293;
            this.label3.Text = "Settings Name:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cbReaderType);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.buttonSubmitReader);
            this.panel1.Controls.Add(this.buttonAddAntenna);
            this.panel1.Controls.Add(this.buttonRemoveAntenna);
            this.panel1.Controls.Add(this.flpAntennaConfig);
            this.panel1.Controls.Add(this.txtIP);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(475, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 301);
            this.panel1.TabIndex = 292;
            this.panel1.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(483, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 18);
            this.label10.TabIndex = 288;
            this.label10.Text = "Cancel";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ssms.Properties.Resources.reply;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(486, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 38);
            this.button1.TabIndex = 287;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.updateSettings_antennaCancel_click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(429, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 18);
            this.label8.TabIndex = 286;
            this.label8.Text = "Submit";
            // 
            // buttonSubmitReader
            // 
            this.buttonSubmitReader.BackgroundImage = global::ssms.Properties.Resources.ok_appproval_acceptance__1_;
            this.buttonSubmitReader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSubmitReader.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSubmitReader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmitReader.Location = new System.Drawing.Point(432, 243);
            this.buttonSubmitReader.Name = "buttonSubmitReader";
            this.buttonSubmitReader.Size = new System.Drawing.Size(51, 38);
            this.buttonSubmitReader.TabIndex = 286;
            this.buttonSubmitReader.UseVisualStyleBackColor = true;
            this.buttonSubmitReader.Click += new System.EventHandler(this.updateSettings_antennaSubmit_click);
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
            this.buttonAddAntenna.Click += new System.EventHandler(this.updateSettings_addAntenna_Click);
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
            this.buttonRemoveAntenna.Click += new System.EventHandler(this.updateSettings_delAntenna_Click);
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
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(3, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 33);
            this.label6.TabIndex = 258;
            this.label6.Text = "Add Reader";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 19);
            this.label2.TabIndex = 291;
            this.label2.Text = "Machine Name:";
            // 
            // comboBoxStore
            // 
            this.comboBoxStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStore.FormattingEnabled = true;
            this.comboBoxStore.Location = new System.Drawing.Point(174, 52);
            this.comboBoxStore.Name = "comboBoxStore";
            this.comboBoxStore.Size = new System.Drawing.Size(245, 28);
            this.comboBoxStore.TabIndex = 290;
            this.comboBoxStore.SelectedIndexChanged += new System.EventHandler(this.comboBoxStore_selectedIdxChg);
            // 
            // buttonBack
            // 
            this.buttonBack.BackgroundImage = global::ssms.Properties.Resources.reply__1_;
            this.buttonBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.buttonBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonBack.Location = new System.Drawing.Point(939, 377);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(61, 104);
            this.buttonBack.TabIndex = 289;
            this.buttonBack.Text = "Back";
            this.buttonBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.updateSettings_back_click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(866, 455);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 25);
            this.label5.TabIndex = 288;
            this.label5.Text = "Update";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(12, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(221, 33);
            this.label9.TabIndex = 286;
            this.label9.Text = "Update Settings";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImage = global::ssms.Properties.Resources.ok_appproval_acceptance__1_;
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(853, 396);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 56);
            this.btnUpdate.TabIndex = 287;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.updateSettings_btnUpdate_Click);
            // 
            // comboBoxSettings
            // 
            this.comboBoxSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSettings.FormattingEnabled = true;
            this.comboBoxSettings.Location = new System.Drawing.Point(174, 86);
            this.comboBoxSettings.Name = "comboBoxSettings";
            this.comboBoxSettings.Size = new System.Drawing.Size(245, 28);
            this.comboBoxSettings.TabIndex = 299;
            this.comboBoxSettings.SelectedIndexChanged += new System.EventHandler(this.comboBoxSettings_selectIdxChg);
            // 
            // tSettingsName
            // 
            this.tSettingsName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSettingsName.Location = new System.Drawing.Point(174, 122);
            this.tSettingsName.Name = "tSettingsName";
            this.tSettingsName.Size = new System.Drawing.Size(245, 26);
            this.tSettingsName.TabIndex = 301;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(14, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 19);
            this.label1.TabIndex = 300;
            this.label1.Text = "New Settings Name:";
            // 
            // cbReaderType
            // 
            this.cbReaderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbReaderType.FormattingEnabled = true;
            this.cbReaderType.Location = new System.Drawing.Point(403, 38);
            this.cbReaderType.Name = "cbReaderType";
            this.cbReaderType.Size = new System.Drawing.Size(121, 28);
            this.cbReaderType.TabIndex = 302;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(292, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 19);
            this.label11.TabIndex = 303;
            this.label11.Text = "Reader Type";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // UpdateSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tSettingsName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSettings);
            this.Controls.Add(this.buttonRemoveReader);
            this.Controls.Add(this.bAddReader);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvReaders);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxStore);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnUpdate);
            this.Name = "UpdateSettings";
            this.Size = new System.Drawing.Size(1031, 491);
            this.Load += new System.EventHandler(this.updateSettings_load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReaders)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRemoveReader;
        private System.Windows.Forms.Button bAddReader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvReaders;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonSubmitReader;
        private System.Windows.Forms.Button buttonAddAntenna;
        private System.Windows.Forms.Button buttonRemoveAntenna;
        private System.Windows.Forms.FlowLayoutPanel flpAntennaConfig;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxStore;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tSettingsName;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBoxSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPaddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn numAntennas;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbReaderType;
        private System.Windows.Forms.Label label11;
    }
}
