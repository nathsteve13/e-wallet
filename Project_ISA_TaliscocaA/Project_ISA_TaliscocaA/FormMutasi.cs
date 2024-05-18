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
    public partial class FormMutasi : Form
    {
        public FormMutasi()
        {
            InitializeComponent();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMutasi_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = Transaction.BacaData("", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCari_Click(object sender, EventArgs e)
        {

        }
    }
}
