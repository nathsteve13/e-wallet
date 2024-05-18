using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ISA_TaliscocaA
{
    public class Transaction_history
    {
        private int id_history;
        private Transaction id_transaction;
        private Users id_user;
        private string description;
        private DateTime timestamp;

        #region constructor
        public Transaction_history(int id_history, Transaction id_transaction, Users id_user, string description, DateTime timestamp)
        {
            this.Id_history = id_history;
            this.Id_transaction = id_transaction;
            this.Id_user = id_user;
            this.Description = description;
            this.Timestamp = timestamp;
        }
        public Transaction_history()
        {
            this.Id_history = 0;
            this.Id_transaction = new Transaction();
            this.Id_user = new Users();
            this.Description = "";
            this.Timestamp = DateTime.Now;
        }
        #endregion

        #region properties
        public int Id_history { get => id_history; set => id_history = value; }
        public Transaction Id_transaction { get => id_transaction; set => id_transaction = value; }
        public Users Id_user { get => id_user; set => id_user = value; }
        public string Description { get => description; set => description = value; }
        public DateTime Timestamp { get => timestamp; set => timestamp = value; }
        #endregion

        #region method
        public static void TambahData(Transaction_history th)
        {
            string sql = "insert into transactionhistory(history_id, transaction_id, user_id, description, timestamp) " +
                "values ('" + th.Id_history + "','" + th.Id_transaction.Id_transaction + "','" + th.Id_user.Id_user + "','" + th.Description + "','" + 
                th.Timestamp.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            Koneksi.JalankanPerintahDML(sql);
        }

        public List<Transaction_history> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select th.history_id, t.transaction_id, u.user_id, th.description, th.timestamp" +
                    " from transactionhistory as th" +
                    " left join users as u on u.user_id = th.user_id" +
                    " left join transactions as t on t.transaction_id = th.transaction_id";
            }
            else
            {
                sql = "select th.history_id, t.transaction_id, u.user_id, th.description, th.timestamp" +
                    " from transactionhistory as th" +
                    " left join users as u on u.user_id = th.user_id" +
                    " left join transactions as t on t.transaction_id = th.transaction_id" +
                    " where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Transaction_history> listTransactionHistory = new List<Transaction_history>();
            while (hasil.Read() == true)
            {
                Users u = new Users();
                u.Id_user = int.Parse(hasil.GetValue(2).ToString());

                Transaction t = new Transaction();
                t.Id_transaction = int.Parse(hasil.GetValue(1).ToString());

                Transaction_history th = new Transaction_history();
                th.Id_history = int.Parse(hasil.GetValue(0).ToString());
                th.Id_transaction = t;
                th.Id_user = u;
                th.description = hasil.GetValue(3).ToString();
                th.Timestamp = DateTime.Parse(hasil.GetValue(4).ToString());

                listTransactionHistory.Add(th);
            }
            return listTransactionHistory;
        }
        #endregion
    }
}
