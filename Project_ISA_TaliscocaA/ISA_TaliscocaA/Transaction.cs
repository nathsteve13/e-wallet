using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ISA_TaliscocaA
{
    public class Transaction
    {
        private int id_transaction;
        private Users id_user;
        private int id_recipient;
        private double amount;
        private string transaction_type;
        private DateTime timestamp;
        private string description;

        #region constructor
        public Transaction(int id_transaction, Users id_user, int id_recipient, double amount, string transaction_type, DateTime timestamp, string description)
        {
            this.Id_transaction = id_transaction;
            this.Id_user = id_user;
            this.Id_recipient = id_recipient;
            this.Amount = amount;
            this.Transaction_type = transaction_type;
            this.Timestamp = timestamp;
            this.Description = description;

        }
        public Transaction()
        {
            this.Id_transaction = 0;
            this.Id_user = new Users();
            this.Id_recipient = 0;
            this.Amount = 0f;
            this.Transaction_type = "";
            this.Timestamp = DateTime.Now;
            this.Description = "";
        }
        #endregion

        #region properties
        public int Id_transaction { get => id_transaction; set => id_transaction = value; }
        public Users Id_user { get => id_user; set => id_user = value; }
        public int IdUser
        {
            get { return Id_user.Id_user; }
        }
        public int Id_recipient { get => id_recipient; set => id_recipient = value; }
        public double Amount { get => amount; set => amount = value; }
        public string Transaction_type { get => transaction_type; set => transaction_type = value; }
        public DateTime Timestamp { get => timestamp; set => timestamp = value; }
        public string Description { get => description; set => description = value; }
        #endregion

        #region method
        public static void TambahData(Transaction t)
        {
            string sql = "insert into transactions(transaction_id, user_id, recipient_id, amount, transaction_type, timestamp, description) " +
                "values ('0', '" + t.Id_user.Id_user + "','" + t.Id_recipient + "','" + t.Amount + "','" + t.Transaction_type + "','" + t.Timestamp.ToString("yyyy-MM-dd HH:mm:ss") + "','" + t.Description + "')";
            Koneksi.JalankanPerintahDML(sql);
        }


        public static List<Transaction> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select t.transaction_id, u.user_id, t.recipient_id, t.amount, t.transaction_type, t.timestamp, t.description" +
                    " from transactions as t" +
                    " left join users as u on u.user_id = t.user_id";
            }
            else
            {
                sql = "select t.transaction_id, u.user_id, t.recipient_id, t.amount, t.transaction_type, t.timestamp, t.description" +
                    " from transactions as t" +
                    " left join users as u on u.user_id = t.user_id" +
                    " where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Transaction> listTransaction = new List<Transaction>();
            while (hasil.Read() == true)
            {
                Users u = new Users();
                u.Id_user = int.Parse(hasil.GetValue(1).ToString());

                Transaction t = new Transaction();
                t.Id_transaction = int.Parse(hasil.GetValue(0).ToString());
                t.Id_user = u;
                t.Id_recipient = int.Parse(hasil.GetValue(2).ToString());
                t.Amount = double.Parse(hasil.GetValue(3).ToString());
                t.Transaction_type = hasil.GetValue(4).ToString();   
                t.Timestamp = DateTime.Parse(hasil.GetValue(5).ToString());
                t.Description = hasil.GetValue(6).ToString();

                listTransaction.Add(t);
            }
            return listTransaction;
        }

        public static List<Transaction> BacaDataAdmin(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select * from transactions";
            }
            else
            {
                sql = "select * from transactions " +
                      "where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Transaction> listTransaction = new List<Transaction>();
            while (hasil.Read() == true)
            {
                Users u = new Users();
                u.Id_user = int.Parse(hasil.GetValue(1).ToString());

                Transaction t = new Transaction();
                t.Id_transaction = int.Parse(hasil.GetValue(0).ToString());
                t.Id_user = u;
                t.Id_recipient = int.Parse(hasil.GetValue(2).ToString());
                t.Amount = double.Parse(hasil.GetValue(3).ToString());
                t.Transaction_type = hasil.GetValue(4).ToString();
                t.Timestamp = DateTime.Parse(hasil.GetValue(5).ToString());
                t.Description = hasil.GetValue(6).ToString();

                listTransaction.Add(t);
            }
            return listTransaction;
        }

        public static void TransaksiBalance(int id_user, double total)
        {
            string sql = "UPDATE balances SET current_balance = current_balance - " + total +
                ", last_updated = '" + DateTime.Now +
                "' WHERE user_id = " + id_user; 
            Koneksi.JalankanPerintahDML(sql);
        }

        public static void TransaksiProduk(string nama, int quantity)
        {
            string sql = "UPDATE products SET stock = stock - " + quantity +
                " where name = '" + nama + "'";
            Koneksi.JalankanPerintahDML(sql);
        }

        public static void TransaksiPartnership(int id_partnership, double total) 
        {
            string sql = "UPDATE balances SET current_balance = current_balance + " + total +
                ", last_updated = '" + DateTime.Now +
                "' WHERE user_id = " + id_partnership;
            Koneksi.JalankanPerintahDML(sql);
        }

        public static void CetakProduk()
        {
            string nama_file = "All Transaction";
            List<Transaction> listTransaction = Transaction.BacaData("", "");
            StreamWriter fileCetak = new StreamWriter(nama_file);

            fileCetak.WriteLine("All Transaction");
            fileCetak.WriteLine();
            fileCetak.WriteLine("dicetak tanggal " + DateTime.Now.ToString("dd-MM-yyyy"));
            fileCetak.WriteLine();
            fileCetak.WriteLine("------------------------------------------------------------------");
            fileCetak.WriteLine("   transaction_id   user_id   recipient_id   amount   transaction_type   timestamp   description   ");
            fileCetak.WriteLine("------------------------------------------------------------------");
            for (int i = 0; i < listTransaction.Count; i++)
            {
                fileCetak.WriteLine(listTransaction[i].Id_transaction.ToString() + "   " +
                                    listTransaction[i].IdUser.ToString() + "   " +
                                    listTransaction[i].Id_recipient.ToString() + "   " +
                                    listTransaction[i].Amount.ToString() + "   " +
                                    listTransaction[i].Transaction_type.ToString() + "   " +
                                    listTransaction[i].Timestamp.ToString() + "   " +
                                    listTransaction [i].Description.ToString());
            }
            fileCetak.WriteLine("------------------------------------------------------------------");
            fileCetak.Close();
            CustomPrint p = new CustomPrint(new System.Drawing.Font("Courier New", 12), nama_file, 100, 50, 50, 50);
            p.SendToPrinter();
        }
        #endregion
    }
}
