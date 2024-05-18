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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }


        private void buttonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi koneksi = new Koneksi();
                int id_terakhir = Balance.IdTerakhir() + 1;
                FormLogin form = (FormLogin)this.Owner;
                Users u = new Users();
                u.Id_user = id_terakhir;
                u.Username = textBoxUserName.Text;
                u.Name = textBoxName.Text;
                u.Email = textBoxEmail.Text;
                u.Phone_number = textBoxPhoneNumber.Text;
                u.Password = textBoxPassword.Text;
                u.Role = comboBoxRole.Text;
                u.Kartu_identitas = textBoxKartu.Text;
                u.Gender = comboBoxGender.Text;
                u.Birth_date = dateTimePickerBirth.Value;
                u.Pin = int.Parse(textBoxPin.Text);

                

                Balance b = new Balance();
                b.Balances = 0;
                b.Last_updated = DateTime.Now;

                Users.TambahData(u, pictureBoxPhoto.Image);
                Balance.TambahData(b,id_terakhir);

                MessageBox.Show("Register berhasil dilakukan. Silahkan login menggunakan username dan password yang sudah terdaftar");

                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Register gagal. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void buttonUpload_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            pictureBoxPhoto.ImageLocation = openFileDialog1.FileName;
        }
    }
}
