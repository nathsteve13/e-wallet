﻿namespace Project_ISA_TaliscocaA
{
    partial class FormMutasi
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCari = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxKriteria = new System.Windows.Forms.TextBox();
            this.comboBoxKriteria = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCari
            // 
            this.buttonCari.BackColor = System.Drawing.Color.Indigo;
            this.buttonCari.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCari.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCari.ForeColor = System.Drawing.Color.White;
            this.buttonCari.Location = new System.Drawing.Point(1394, 107);
            this.buttonCari.Name = "buttonCari";
            this.buttonCari.Size = new System.Drawing.Size(122, 23);
            this.buttonCari.TabIndex = 24;
            this.buttonCari.Text = "Cari";
            this.buttonCari.UseVisualStyleBackColor = false;
            this.buttonCari.Click += new System.EventHandler(this.buttonCari_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.Indigo;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonHome.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHome.ForeColor = System.Drawing.Color.White;
            this.buttonHome.Location = new System.Drawing.Point(13, 11);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(144, 32);
            this.buttonHome.TabIndex = 23;
            this.buttonHome.Text = "Back To Home";
            this.buttonHome.UseVisualStyleBackColor = false;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(69, 163);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1447, 582);
            this.dataGridView1.TabIndex = 22;
            // 
            // textBoxKriteria
            // 
            this.textBoxKriteria.Location = new System.Drawing.Point(311, 107);
            this.textBoxKriteria.Name = "textBoxKriteria";
            this.textBoxKriteria.Size = new System.Drawing.Size(1077, 22);
            this.textBoxKriteria.TabIndex = 21;
            // 
            // comboBoxKriteria
            // 
            this.comboBoxKriteria.FormattingEnabled = true;
            this.comboBoxKriteria.Items.AddRange(new object[] {
            "Kode",
            "Nama"});
            this.comboBoxKriteria.Location = new System.Drawing.Point(69, 106);
            this.comboBoxKriteria.Name = "comboBoxKriteria";
            this.comboBoxKriteria.Size = new System.Drawing.Size(236, 24);
            this.comboBoxKriteria.TabIndex = 20;
            // 
            // FormMutasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Project_ISA_TaliscocaA.Properties.Resources.ISA__1_;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.buttonCari);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxKriteria);
            this.Controls.Add(this.comboBoxKriteria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMutasi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMutasi";
            this.Load += new System.EventHandler(this.FormMutasi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCari;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxKriteria;
        private System.Windows.Forms.ComboBox comboBoxKriteria;
    }
}