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
    public partial class FormSemuaProduk : Form
    {
        public FormSemuaProduk()
        {
            InitializeComponent();
        }

        private void FormSemuaProduk_Load(object sender, EventArgs e)
        {
            try
            {
                List<Products> listHasil = Products.BacaDataAdmin("", "");

                dataGridView1.DataSource = listHasil;

                if (dataGridView1.ColumnCount == 7)
                {
                    DataGridViewButtonColumn btnUbah = new DataGridViewButtonColumn();
                    btnUbah.HeaderText = "AKSI";
                    btnUbah.Text = "UBAH";
                    btnUbah.Name = "buttonUbahGrid";
                    btnUbah.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(btnUbah);

                    DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                    btnDelete.HeaderText = "AKSI";
                    btnDelete.Text = "HAPUS";
                    btnDelete.Name = "buttonHapusGrid";
                    btnDelete.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(btnDelete);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private DataGridViewTextBoxColumn CreatePartnerIDColumn()
        {
            return new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PartnerId",  // Gunakan properti baru yang mengembalikan Id_user
                HeaderText = "Partner ID",
                Name = "Partners_id"
            };
        }
        private DataGridViewTextBoxColumn CreateColumn(string dataPropertyName, string headerText)
        {
            return new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataPropertyName,
                HeaderText = headerText,
                Name = dataPropertyName
            };
        }

        private void AddActionButton(string buttonText)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Aksi";
            btn.Text = buttonText;
            btn.Name = "button" + buttonText + "Grid";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);
        }

        private void buttonCari_Click(object sender, EventArgs e)
        {
            try
            {
                string filter = comboBoxKriteria.SelectedItem.ToString();
                if (comboBoxKriteria.SelectedIndex == 0)
                {
                    filter = "product_id";
                }
                else
                {
                    filter = "name";
                }
                string nilai = textBoxKriteria.Text;
                List<Products> listHasil = Products.BacaData(filter, nilai);
                dataGridView1.DataSource = listHasil;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string kode = dataGridView1.CurrentRow.Cells["Products_id"].Value.ToString();
                if (e.ColumnIndex == dataGridView1.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
                {
                    Products.HapusData(kode);
                    FormSemuaProduk_Load(this, e);
                }
                else if (e.ColumnIndex == dataGridView1.Columns["buttonUbahGrid"].Index && e.RowIndex >= 0)
                {
                    FormUbahProduct form = new FormUbahProduct();
                    form.Owner = this;
                    form.kodeUbah = kode;
                    form.ShowDialog();
                    FormSemuaProduk_Load(this, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            Products.CetakProduk();

        }
    }
}
