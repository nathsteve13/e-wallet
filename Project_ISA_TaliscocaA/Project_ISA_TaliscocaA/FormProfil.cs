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
    public partial class FormProfil : Form
    {
        public FormProfil()
        {
            InitializeComponent();
        }

        private void FormProfil_Load(object sender, EventArgs e)
        {
            FormUtama form = (FormUtama)this.Owner;

            List<Users> listHasil = Users.BacaDataUser(form.userLogin.Id_user);
            textBoxUserName.Text = listHasil[0].Username;
            textBoxName.Text = listHasil[0].Name;
            textBoxEmail.Text = listHasil[0].Email;
            textBoxPassword.Text = listHasil[0].Password;
            textBoxPhoneNumber.Text = listHasil[0].Phone_number;
            textBoxPin.Text = listHasil[0].Pin.ToString();
            comboBoxRole.Text = listHasil[0].Role;
            dateTimePickerBirth.Text = listHasil[0].Birth_date.ToString();
            comboBoxGender.Text = listHasil[0].Gender;
            pictureBoxPhoto.Image = Users.BacaGambar(form.userLogin.Foto_wajah);
            textBoxKartu.Text = listHasil[0].Kartu_identitas;
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
