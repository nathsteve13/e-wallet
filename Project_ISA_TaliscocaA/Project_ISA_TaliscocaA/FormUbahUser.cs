using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISA_TaliscocaA;

namespace Project_ISA_TaliscocaA
{
    public partial class FormUbahUser : Form
    {
        public FormUbahUser()
        {
            InitializeComponent();
        }
        public string kodeUbah;
        private void buttonHome_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        int id = 0;
        private void buttonUbah_Click(object sender, EventArgs e)
        {

            try
            {
                FormSemuaUser form = (FormSemuaUser)this.Owner;
                Users u = new Users();
                u.Username = textBoxUserName.Text;
                u.Name = textBoxName.Text;
                u.Email = textBoxEmail.Text;
                u.Phone_number = textBoxPhoneNumber.Text;
                u.Password = textBoxPassword.Text;
                u.Role = comboBoxRole.Text;
                u.Gender = comboBoxGender.Text;
                u.Birth_date = dateTimePickerBirth.Value;
                u.Id_user = id;
                Users.UbahData(u);
                MessageBox.Show("Ubah data berhasil dilakukan.");

                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ubah data gagal. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void FormUbahUser_Load(object sender, EventArgs e)
        {

            List<Users> listhasil = Users.BacaData("user_id", kodeUbah);
            textBoxName.Text = listhasil[0].Name;
            id = listhasil[0].Id_user;
        }

        private void FormUbahUser_Load_1(object sender, EventArgs e)
        {
            List<Users> listhasil = Users.BacaData("user_id", kodeUbah);
            textBoxName.Text = listhasil[0].Name;
            id = listhasil[0].Id_user;
        }
    }
}
