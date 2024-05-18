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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Users u = Users.CekLogin(textBoxUsername.Text, textBoxPassword.Text);

                if (u != null)
                {
                    FormUtama formMenu = (FormUtama)this.Owner;
                    formMenu.userLogin = u;

                    MessageBox.Show("Koneksi berhasil. Selamat menggunakan aplikasi.", "Informasi");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Username tidak ditemukan atau password salah");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login gagal. Pesan kesalahan : " + ex.Message, "Kesalahan");

            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FormRegister form = new FormRegister();
            form.Owner = this;

            form.ShowDialog();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
