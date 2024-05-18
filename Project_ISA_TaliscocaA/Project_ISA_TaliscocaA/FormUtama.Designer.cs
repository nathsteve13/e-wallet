namespace Project_ISA_TaliscocaA
{
    partial class FormUtama
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
            this.labelNama = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonProduk = new System.Windows.Forms.Button();
            this.buttonTambahProduk = new System.Windows.Forms.Button();
            this.buttonTransaction = new System.Windows.Forms.Button();
            this.buttonMutasi = new System.Windows.Forms.Button();
            this.buttonTopup = new System.Windows.Forms.Button();
            this.buttonTransfer = new System.Windows.Forms.Button();
            this.buttonProfile = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelBalance = new System.Windows.Forms.Label();
            this.buttonAllTransaction = new System.Windows.Forms.Button();
            this.buttonAllProduct = new System.Windows.Forms.Button();
            this.buttonAllUser = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNama
            // 
            this.labelNama.AutoSize = true;
            this.labelNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNama.Location = new System.Drawing.Point(1453, 16);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(64, 25);
            this.labelNama.TabIndex = 1;
            this.labelNama.Text = "Name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.labelNama);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1582, 56);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Indigo;
            this.panel2.Controls.Add(this.buttonClose);
            this.panel2.Controls.Add(this.buttonProduk);
            this.panel2.Controls.Add(this.buttonTambahProduk);
            this.panel2.Controls.Add(this.buttonTransaction);
            this.panel2.Controls.Add(this.buttonMutasi);
            this.panel2.Controls.Add(this.buttonTopup);
            this.panel2.Controls.Add(this.buttonTransfer);
            this.panel2.Controls.Add(this.buttonProfile);
            this.panel2.Controls.Add(this.buttonHome);
            this.panel2.Location = new System.Drawing.Point(0, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(276, 801);
            this.panel2.TabIndex = 3;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Indigo;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(0, 739);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(276, 57);
            this.buttonClose.TabIndex = 10;
            this.buttonClose.Text = "Close Program";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonProduk
            // 
            this.buttonProduk.BackColor = System.Drawing.Color.Indigo;
            this.buttonProduk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonProduk.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProduk.ForeColor = System.Drawing.Color.White;
            this.buttonProduk.Location = new System.Drawing.Point(0, 430);
            this.buttonProduk.Name = "buttonProduk";
            this.buttonProduk.Size = new System.Drawing.Size(276, 57);
            this.buttonProduk.TabIndex = 9;
            this.buttonProduk.Text = "List Produk";
            this.buttonProduk.UseVisualStyleBackColor = false;
            this.buttonProduk.Click += new System.EventHandler(this.buttonProduk_Click);
            // 
            // buttonTambahProduk
            // 
            this.buttonTambahProduk.BackColor = System.Drawing.Color.Indigo;
            this.buttonTambahProduk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTambahProduk.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTambahProduk.ForeColor = System.Drawing.Color.White;
            this.buttonTambahProduk.Location = new System.Drawing.Point(0, 367);
            this.buttonTambahProduk.Name = "buttonTambahProduk";
            this.buttonTambahProduk.Size = new System.Drawing.Size(276, 57);
            this.buttonTambahProduk.TabIndex = 6;
            this.buttonTambahProduk.Text = "Tambah Produk";
            this.buttonTambahProduk.UseVisualStyleBackColor = false;
            this.buttonTambahProduk.Click += new System.EventHandler(this.buttonTambahProduk_Click);
            // 
            // buttonTransaction
            // 
            this.buttonTransaction.BackColor = System.Drawing.Color.Indigo;
            this.buttonTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTransaction.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTransaction.ForeColor = System.Drawing.Color.White;
            this.buttonTransaction.Location = new System.Drawing.Point(0, 305);
            this.buttonTransaction.Name = "buttonTransaction";
            this.buttonTransaction.Size = new System.Drawing.Size(276, 57);
            this.buttonTransaction.TabIndex = 7;
            this.buttonTransaction.Text = "Transaksi";
            this.buttonTransaction.UseVisualStyleBackColor = false;
            this.buttonTransaction.Click += new System.EventHandler(this.buttonTransaction_Click);
            // 
            // buttonMutasi
            // 
            this.buttonMutasi.BackColor = System.Drawing.Color.Indigo;
            this.buttonMutasi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMutasi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMutasi.ForeColor = System.Drawing.Color.White;
            this.buttonMutasi.Location = new System.Drawing.Point(0, 244);
            this.buttonMutasi.Name = "buttonMutasi";
            this.buttonMutasi.Size = new System.Drawing.Size(276, 57);
            this.buttonMutasi.TabIndex = 8;
            this.buttonMutasi.Text = "Mutasi";
            this.buttonMutasi.UseVisualStyleBackColor = false;
            this.buttonMutasi.Click += new System.EventHandler(this.buttonMutasi_Click);
            // 
            // buttonTopup
            // 
            this.buttonTopup.BackColor = System.Drawing.Color.Indigo;
            this.buttonTopup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTopup.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTopup.ForeColor = System.Drawing.Color.White;
            this.buttonTopup.Location = new System.Drawing.Point(0, 183);
            this.buttonTopup.Name = "buttonTopup";
            this.buttonTopup.Size = new System.Drawing.Size(276, 57);
            this.buttonTopup.TabIndex = 5;
            this.buttonTopup.Text = "Top Up";
            this.buttonTopup.UseVisualStyleBackColor = false;
            this.buttonTopup.Click += new System.EventHandler(this.buttonTopup_Click);
            // 
            // buttonTransfer
            // 
            this.buttonTransfer.BackColor = System.Drawing.Color.Indigo;
            this.buttonTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTransfer.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTransfer.ForeColor = System.Drawing.Color.White;
            this.buttonTransfer.Location = new System.Drawing.Point(0, 121);
            this.buttonTransfer.Name = "buttonTransfer";
            this.buttonTransfer.Size = new System.Drawing.Size(276, 57);
            this.buttonTransfer.TabIndex = 5;
            this.buttonTransfer.Text = "Transfer";
            this.buttonTransfer.UseVisualStyleBackColor = false;
            this.buttonTransfer.Click += new System.EventHandler(this.buttonTransfer_Click);
            // 
            // buttonProfile
            // 
            this.buttonProfile.BackColor = System.Drawing.Color.Indigo;
            this.buttonProfile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonProfile.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProfile.ForeColor = System.Drawing.Color.White;
            this.buttonProfile.Location = new System.Drawing.Point(0, 60);
            this.buttonProfile.Name = "buttonProfile";
            this.buttonProfile.Size = new System.Drawing.Size(276, 57);
            this.buttonProfile.TabIndex = 5;
            this.buttonProfile.Text = "Profile";
            this.buttonProfile.UseVisualStyleBackColor = false;
            this.buttonProfile.Click += new System.EventHandler(this.buttonProfile_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.Indigo;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonHome.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHome.ForeColor = System.Drawing.Color.White;
            this.buttonHome.Location = new System.Drawing.Point(0, 0);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(276, 57);
            this.buttonHome.TabIndex = 4;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = false;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(301, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 50);
            this.label1.TabIndex = 4;
            this.label1.Text = "Welcome,";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(309, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Your balance";
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.BackColor = System.Drawing.Color.Transparent;
            this.labelBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBalance.ForeColor = System.Drawing.Color.Indigo;
            this.labelBalance.Location = new System.Drawing.Point(309, 218);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(212, 45);
            this.labelBalance.TabIndex = 6;
            this.labelBalance.Text = "Your balance";
            this.labelBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonAllTransaction
            // 
            this.buttonAllTransaction.BackColor = System.Drawing.Color.Indigo;
            this.buttonAllTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAllTransaction.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAllTransaction.ForeColor = System.Drawing.Color.White;
            this.buttonAllTransaction.Location = new System.Drawing.Point(310, 279);
            this.buttonAllTransaction.Name = "buttonAllTransaction";
            this.buttonAllTransaction.Size = new System.Drawing.Size(276, 57);
            this.buttonAllTransaction.TabIndex = 11;
            this.buttonAllTransaction.Text = "Semua Transaksi";
            this.buttonAllTransaction.UseVisualStyleBackColor = false;
            this.buttonAllTransaction.Click += new System.EventHandler(this.buttonAllTransaction_Click);
            // 
            // buttonAllProduct
            // 
            this.buttonAllProduct.BackColor = System.Drawing.Color.Indigo;
            this.buttonAllProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAllProduct.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAllProduct.ForeColor = System.Drawing.Color.White;
            this.buttonAllProduct.Location = new System.Drawing.Point(592, 279);
            this.buttonAllProduct.Name = "buttonAllProduct";
            this.buttonAllProduct.Size = new System.Drawing.Size(276, 57);
            this.buttonAllProduct.TabIndex = 12;
            this.buttonAllProduct.Text = "Semua Produk";
            this.buttonAllProduct.UseVisualStyleBackColor = false;
            this.buttonAllProduct.Click += new System.EventHandler(this.buttonAllProduct_Click);
            // 
            // buttonAllUser
            // 
            this.buttonAllUser.BackColor = System.Drawing.Color.Indigo;
            this.buttonAllUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAllUser.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAllUser.ForeColor = System.Drawing.Color.White;
            this.buttonAllUser.Location = new System.Drawing.Point(874, 279);
            this.buttonAllUser.Name = "buttonAllUser";
            this.buttonAllUser.Size = new System.Drawing.Size(276, 57);
            this.buttonAllUser.TabIndex = 13;
            this.buttonAllUser.Text = "Semua User";
            this.buttonAllUser.UseVisualStyleBackColor = false;
            this.buttonAllUser.Click += new System.EventHandler(this.buttonAllUser_Click);
            // 
            // FormUtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Project_ISA_TaliscocaA.Properties.Resources.ISA__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.buttonAllUser);
            this.Controls.Add(this.labelBalance);
            this.Controls.Add(this.buttonAllProduct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonAllTransaction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormUtama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormUtama_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelNama;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonTambahProduk;
        private System.Windows.Forms.Button buttonTransaction;
        private System.Windows.Forms.Button buttonMutasi;
        private System.Windows.Forms.Button buttonTopup;
        private System.Windows.Forms.Button buttonTransfer;
        private System.Windows.Forms.Button buttonProfile;
        private System.Windows.Forms.Button buttonProduk;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAllTransaction;
        private System.Windows.Forms.Button buttonAllUser;
        private System.Windows.Forms.Button buttonAllProduct;
        public System.Windows.Forms.Label labelBalance;
    }
}

