using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISA_TaliscocaA;


namespace Project_ISA_TaliscocaA
{
    public partial class FormTransaksi : Form
    {
        public FormTransaksi()
        {
            InitializeComponent();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        List<Users> listPartnership = new List<Users>();
        List<Products> listProduct = new List<Products>();

        private void FormTransaksi_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                FormUtama formUtama = (FormUtama)this.Owner;

                double balance = double.Parse(formUtama.userBalance.GetBalances(formUtama.userLogin.Id_user).Balances.ToString());
                formUtama.labelBalance.Text = balance.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memperbarui balance pada form utama. Error : " + ex.Message);
            }
        }
        double total = 0;

        private void buttonPay_Click(object sender, EventArgs e)
        {
            try
            {
                FormUtama form = (FormUtama)this.Owner;
                int pin = int.Parse(textBoxPin.Text);
                int pinHash = Users.HashingPin(pin);

                if (pinHash == form.userLogin.Pin)
                {
                    Transaction t = new Transaction();
                    t.Id_user.Id_user = form.userLogin.Id_user;
                    t.Id_recipient = int.Parse(comboBoxToko.Text);
                    t.Amount = total;
                    t.Transaction_type = "purchase";
                    t.Timestamp = DateTime.Now;
                    t.Description = "Pembelian produk";

                    Transaction.TambahData(t);
                    Transaction.TransaksiBalance(form.userLogin.Id_user, total);
                    Transaction.TransaksiProduk(comboBoxProduk.Text, (int)numericUpDown1.Value);

                    MessageBox.Show("Transaksi berhasil!");
                    listBoxResult.Items.Add("Transaksi berhasil : \n " +
                                            "ID Partner : " + comboBoxToko.Text + "\n" +
                                            "Nama Produk  : " + comboBoxProduk.Text + "\n" +
                                            "Amount : " + total + "\n" +
                                            "Description : Pembelian produk" + "\n" +
                                            "Timestamp : " + DateTime.Now);

                }
                else
                {
                    MessageBox.Show("PIN salah, coba lagi!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormTransaksi_Load(object sender, EventArgs e)
        {
            listPartnership = Users.BacaData("", "");
            comboBoxToko.DataSource = listPartnership;
            comboBoxToko.DisplayMember = "Id_user";
        }

        private void comboBoxToko_SelectedIndexChanged(object sender, EventArgs e)
        {
            listProduct = Products.BacaData("", "");
            comboBoxProduk.DataSource = listProduct;
            comboBoxProduk.DisplayMember = "NamaProduk";
        }

        private void buttontotal_Click(object sender, EventArgs e)
        {
            double price = 0;
            string tampung = comboBoxProduk.Text;

            for (int i = 0; i < listProduct.Count; i++)
            {
                if (listProduct[i].NamaProduk == tampung)
                {
                    price = listProduct[i].Price;
                }
            }
            
            total = price * (int)numericUpDown1.Value;
            labelHarga.Text = total.ToString();
        }
    }
}
