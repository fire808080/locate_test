﻿namespace ssms.Pages.Items
{
    partial class AddCategorySmall
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.tCateDesc = new System.Windows.Forms.TextBox();
            this.tCateName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 25);
            this.label5.TabIndex = 228;
            this.label5.Text = "Add";
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::ssms.Properties.Resources.ok_appproval_acceptance__1_;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(15, 161);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 56);
            this.btnAdd.TabIndex = 227;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tCateDesc
            // 
            this.tCateDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCateDesc.Location = new System.Drawing.Point(15, 131);
            this.tCateDesc.Name = "tCateDesc";
            this.tCateDesc.Size = new System.Drawing.Size(245, 26);
            this.tCateDesc.TabIndex = 226;
            // 
            // tCateName
            // 
            this.tCateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCateName.Location = new System.Drawing.Point(15, 69);
            this.tCateName.Name = "tCateName";
            this.tCateName.Size = new System.Drawing.Size(245, 26);
            this.tCateName.TabIndex = 225;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(11, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 19);
            this.label7.TabIndex = 224;
            this.label7.Text = "Category Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(11, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 19);
            this.label6.TabIndex = 223;
            this.label6.Text = "Category Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 33);
            this.label1.TabIndex = 222;
            this.label1.Text = "Add Category";
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.buttonCancel.Image = global::ssms.Properties.Resources.cancel_music;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonCancel.Location = new System.Drawing.Point(200, 174);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 64);
            this.buttonCancel.TabIndex = 230;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AddCategorySmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tCateDesc);
            this.Controls.Add(this.tCateName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Name = "AddCategorySmall";
            this.Size = new System.Drawing.Size(283, 251);
            this.Load += new System.EventHandler(this.AddCategorySmall_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tCateDesc;
        private System.Windows.Forms.TextBox tCateName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
    }
}
