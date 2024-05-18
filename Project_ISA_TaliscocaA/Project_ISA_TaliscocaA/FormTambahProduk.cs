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
    public partial class FormTambahProduk : Form
    {
        public FormTambahProduk()
        {
            InitializeComponent();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FormTambahProduk_FormClosed(object sender, FormClosedEventArgs e)
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

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                FormUtama form = (FormUtama)this.Owner;
                int user_id = form.userLogin.Id_user;

                Products p = new Products();
                p.NamaProduk = textBoxName.Text;
                p.Partners_id.Id_user = user_id;
                p.Price = float.Parse(textBoxHarga.Text);  
                p.DescriptionText = textBoxDescription.Text;
                p.Stock = int.Parse(textBoxStock.Text);

                Products.TambahData(p);

                MessageBox.Show("Tambah produk berhasil!");
                listBoxResult.Items.Add("Tambah produk berhasil : \n " +
                                        "ID Partner : " + user_id + "\n" +
                                        "Nama Produk  : " + textBoxName.Text + "\n" +
                                        "Price : " + textBoxHarga.Text + "\n" +
                                        "Description : " + textBoxDescription.Text + "\n" +
                                        "Stock : " + textBoxStock.Text);
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormTambahProduk_Load(object sender, EventArgs e)
        {

        }
    }
}
