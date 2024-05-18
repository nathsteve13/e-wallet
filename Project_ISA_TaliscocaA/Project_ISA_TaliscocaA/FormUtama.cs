using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISA_TaliscocaA;

namespace Project_ISA_TaliscocaA
{
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
        }
        public Users userLogin = new Users();
        public Balance userBalance = new Balance();

        private void FormUtama_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

            try
            {
                Koneksi koneksi = new Koneksi();

                FormLogin form = new FormLogin();
                form.Owner = this;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    SetHakAkses();
                    labelNama.Text = userLogin.Name;

                    if (userLogin.Role != "admin")
                    {
                        double balance = double.Parse(userBalance.GetBalances(userLogin.Id_user).Balances.ToString());
                        labelBalance.Text = balance.ToString();
                    }
                    else
                    {
                        labelBalance.Text = "";
                    }
                    
                } 
                else
                {
                    MessageBox.Show("Login gagal");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Koneksi.", ex.Message);
            }
        }

        void SetHakAkses()
        {
            if (userLogin.Role == "customer")
            {
                buttonTambahProduk.Visible = false;
                buttonProduk.Visible = false;
                buttonAllProduct.Visible = false;
                buttonAllTransaction.Visible = false;
                buttonAllUser.Visible = false;
            }
            else if (userLogin.Role == "partner")
            {
                buttonAllProduct.Visible = false;
                buttonAllTransaction.Visible = false;
                buttonAllUser.Visible = false;
            }
            else if (userLogin.Role == "admin")
            {
                labelBalance.Visible = false;
                label2.Visible = false;
                buttonMutasi.Visible = false;
                buttonProduk.Visible = false;
                buttonTambahProduk.Visible = false;
                buttonTransaction.Visible = false;
                buttonTopup.Visible = false;
                buttonTransfer.Visible = false;
            }
        }

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            FormProfil form = new FormProfil();
            form.Owner = this;
            form.Show();
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            FormTransfer form = new FormTransfer();
            form.Owner = this;
            form.Show();
        }

        private void buttonTopup_Click(object sender, EventArgs e)
        {
            FormTopUp form = new FormTopUp();
            form.Owner = this;
            form.Show();
        }

        private void buttonMutasi_Click(object sender, EventArgs e)
        {
            FormMutasi form = new FormMutasi();
            form.Owner = this;
            form.Show();
        }

        private void buttonTransaction_Click(object sender, EventArgs e)
        {
            FormTransaksi form = new FormTransaksi();
            form.Owner = this;
            form.Show();
        }

        private void buttonTambahProduk_Click(object sender, EventArgs e)
        {
            FormTambahProduk form = new FormTambahProduk();
            form.Owner = this;
            form.Show();
        }

        private void buttonProduk_Click(object sender, EventArgs e)
        {
            FormListProduk form = new FormListProduk();
            form.Owner = this;
            form.Show();
        }

        private void buttonAllTransaction_Click(object sender, EventArgs e)
        {
            FormSemuaTransaksi form = new FormSemuaTransaksi();
            form.Owner = this;
            form.Show();
        }

        private void buttonAllProduct_Click(object sender, EventArgs e)
        {
            FormSemuaProduk form = new FormSemuaProduk();
            form.Owner = this;
            form.Show();
        }

        private void buttonAllUser_Click(object sender, EventArgs e)
        {
            FormSemuaUser form = new FormSemuaUser();
            form.Owner = this;
            form.Show();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
