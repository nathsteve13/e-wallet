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
    public partial class FormListProduk : Form
    {
        public FormListProduk()
        {
            InitializeComponent();
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

        private void FormListProduk_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.AutoGenerateColumns = false;

                DataGridViewTextBoxColumn productIdColumn = new DataGridViewTextBoxColumn();
                productIdColumn.HeaderText = "Product ID";
                productIdColumn.DataPropertyName = "Products_id";  
                dataGridView1.Columns.Add(productIdColumn);

                DataGridViewTextBoxColumn productNameColumn = new DataGridViewTextBoxColumn();
                productNameColumn.HeaderText = "Product Name";
                productNameColumn.DataPropertyName = "NamaProduk";
                dataGridView1.Columns.Add(productNameColumn);

                DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
                priceColumn.HeaderText = "Price";
                priceColumn.DataPropertyName = "Price";
                dataGridView1.Columns.Add(priceColumn);

                DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();
                descriptionColumn.HeaderText = "Description";
                descriptionColumn.DataPropertyName = "DescriptionText";
                dataGridView1.Columns.Add(descriptionColumn);

                DataGridViewTextBoxColumn stockColumn = new DataGridViewTextBoxColumn();
                stockColumn.HeaderText = "Stock";
                stockColumn.DataPropertyName = "Stock";
                dataGridView1.Columns.Add(stockColumn);

                dataGridView1.DataSource = Products.BacaData("", "");

                if (dataGridView1.ColumnCount == 2)
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
