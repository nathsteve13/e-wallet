using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISA_TaliscocaA;

namespace Project_ISA_TaliscocaA
{
    public partial class FormUbahProduct : Form
    {
        public FormUbahProduct()
        {
            InitializeComponent();
        }
        public string kodeUbah;
        int id = 0;
        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                FormSemuaProduk form = (FormSemuaProduk)this.Owner;
                Products p = new Products();
                p.NamaProduk = textBoxName.Text;
                p.Price = float.Parse(textBoxPrice.Text);
                p.Stock = int.Parse(textBoxStock.Text);
                p.DescriptionText = textBoxDescription.Text;

                Products.UbahData(p);
                MessageBox.Show("Ubah data berhasil dilakukan.");

                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ubah data gagal. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }

        }

        private void FormUbahProduct_Load(object sender, EventArgs e)
        {
            List<Products> listhasil = Products.BacaData("product_id", kodeUbah);
            textBoxName.Text = listhasil[0].NamaProduk;
            id = listhasil[0].Products_id;
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
