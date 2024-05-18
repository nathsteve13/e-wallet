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
    public partial class FormTransfer : Form
    {
        public FormTransfer()
        {
            InitializeComponent();
        }

        private void FormTransfer_Load(object sender, EventArgs e)
        {
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                FormUtama form = (FormUtama)this.Owner;

                int pin = int.Parse(textBoxPin.Text);
                int pinHash = Users.HashingPin(pin);

                if (pinHash == form.userLogin.Pin)
                {
                    Transaction t = new Transaction();
                    t.Id_user.Id_user = form.userLogin.Id_user;
                    t.Id_recipient = int.Parse(textBoxIDTujuan.Text);
                    t.Amount = double.Parse(textBoxAmount.Text);
                    t.Transaction_type = "transfer";
                    t.Timestamp = DateTime.Now;
                    t.Description = textBoxBerita.Text;


                    if (double.Parse(form.userBalance.GetBalances(form.userLogin.Id_user).Balances.ToString()) >= double.Parse(textBoxAmount.Text))
                    {

                        form.userBalance.GetBalances(form.userLogin.Id_user).Balances -= double.Parse(textBoxAmount.Text);
                        Balance.UbahData(form.userBalance);
                        Balance.Transfer(int.Parse(textBoxIDTujuan.Text), double.Parse(textBoxAmount.Text));
                        Balance.UpdateBalance(form.userLogin.Id_user, double.Parse(textBoxAmount.Text));
                        Transaction.TambahData(t);
                        MessageBox.Show("Transfer berhasil!");
                        listBoxResult.Items.Add("Transfer telah berhasil : \n " +
                                                "ID Recepient : " + textBoxIDTujuan.Text + "\n" +
                                                "Amount  : " + textBoxAmount.Text + "\n" +
                                                "Timestamp : " + DateTime.Now.ToString() + "\n" +
                                                "Description : " + textBoxBerita.Text);
                    }
                    else
                    {
                        MessageBox.Show("Saldo tidak cukup!");
                    }
                }
                else
                {
                    MessageBox.Show("PIN Salah, silahkan coba lagi!");
                }

                
                
            } 
            catch(Exception ex)
            {
                MessageBox.Show("Transfer gagal, Error : " + ex.Message);
            }
        }

        private void FormTransfer_FormClosed(object sender, FormClosedEventArgs e)
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

        private void FormTransfer_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
    
}
