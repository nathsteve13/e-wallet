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
    public partial class FormSemuaTransaksi : Form
    {
        public FormSemuaTransaksi()
        {
            InitializeComponent();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSemuaTransaksi_Load(object sender, EventArgs e)
        {
            try
            {

                
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Add(CreateColumn("Id_transaction", "Transaction ID"));
                dataGridView1.Columns.Add(CreatePartnerIDColumn());
                dataGridView1.Columns.Add(CreateColumn("Id_recipient", "Recipient ID"));
                dataGridView1.Columns.Add(CreateColumn("Amount", "Amount"));
                dataGridView1.Columns.Add(CreateColumn("Transaction_type", "Transaction Type"));
                dataGridView1.Columns.Add(CreateColumn("Timestamp", "Timestamp"));

                dataGridView1.DataSource = Transaction.BacaDataAdmin("", "");

                
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
                DataPropertyName = "IdUser",  // Gunakan properti baru yang mengembalikan Id_user
                HeaderText = "ID User",
                Name = "Id_user"
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
        
        private void buttonCari_Click(object sender, EventArgs e)
        {
            try
            {
                string filter = comboBoxKriteria.SelectedItem.ToString();
                if (comboBoxKriteria.SelectedIndex == 0)
                {
                    filter = "user_id";
                }
                else
                {
                    filter = "transaction_type";
                }
                string nilai = textBoxKriteria.Text;
                List<Transaction> listHasil = Transaction.BacaData(filter, nilai);
                dataGridView1.DataSource = listHasil;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            Transaction.CetakProduk();
        }
    }
}
