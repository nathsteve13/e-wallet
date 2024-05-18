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
    public partial class FormSemuaUser : Form
    {
        public FormSemuaUser()
        {
            InitializeComponent();
        }

        private void FormSemuaUser_Load(object sender, EventArgs e)
        {
            
            try
            {
                List<Users> listHasil = Users.BacaDataAdmin("", "");

                dataGridView1.DataSource = listHasil;

                if (dataGridView1.ColumnCount == 12)
                {
                    DataGridViewButtonColumn btnUbah = new DataGridViewButtonColumn();
                    btnUbah.HeaderText = "AKSI";
                    btnUbah.Text = "UBAH";
                    btnUbah.Name = "buttonUbahGrid";
                    btnUbah.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(btnUbah);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    filter = "name";
                }
                string nilai = textBoxKriteria.Text;
                List<Users> listHasil = Users.BacaData(filter, nilai);
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
                string kode = dataGridView1.CurrentRow.Cells["Id_user"].Value.ToString();

                if (e.ColumnIndex == dataGridView1.Columns["buttonUbahGrid"].Index && e.RowIndex >= 0)
                {

                    FormUbahUser form = new FormUbahUser();
                    form.Owner = this;
                    form.kodeUbah = kode;         
                    form.ShowDialog();
                    FormSemuaUser_Load(this, e);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            Users.CetakProduk();
        }
    }
}
