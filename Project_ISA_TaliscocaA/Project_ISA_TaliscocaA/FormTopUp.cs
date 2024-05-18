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
    public partial class FormTopUp : Form
    {
        public FormTopUp()
        {
            InitializeComponent();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTopUp_Click(object sender, EventArgs e)
        {
            FormUtama form = (FormUtama)this.Owner;
            int pin = int.Parse(textBoxPin.Text);
            int pinHash = Users.HashingPin(pin);

            if (pinHash == form.userLogin.Pin)
            {
                Transaction t = new Transaction();
                t.Id_user.Id_user = form.userLogin.Id_user;
                t.Amount = double.Parse(textBoxAmount.Text);
                t.Transaction_type = "topup";
                t.Timestamp = DateTime.Now;
                t.Description = "";
                t.Id_recipient = form.userLogin.Id_user;

                form.userBalance.GetBalances(form.userLogin.Id_user).Balances += double.Parse(textBoxAmount.Text);
                Balance.UbahData(form.userBalance);
                Balance.Topup(form.userLogin.Id_user, double.Parse(textBoxAmount.Text));
                Transaction.TambahData(t);
                MessageBox.Show("Topup berhasil!");
                listBoxResult.Items.Add("Top up telah berhasil : \n " +
                                        "Amount  : " + textBoxAmount.Text + "\n" +
                                        "Timestamp : " + DateTime.Now.ToString());
            }
            else
            {
                MessageBox.Show("PIN Salah, silahkan coba lagi!");
            }
            
        }

        private void FormTopUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                FormUtama formUtama = (FormUtama)this.Owner;

                double balance = double.Parse(formUtama.userBalance.GetBalances(formUtama.userLogin.Id_user).Balances.ToString());
                formUtama.labelBalance.Text = balance.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memperbarui balance pada form utama. Error : " + ex.Message);
            }
        }
    }
}
