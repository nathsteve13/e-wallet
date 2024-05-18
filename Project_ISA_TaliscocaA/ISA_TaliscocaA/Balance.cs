using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ISA_TaliscocaA
{
    public class Balance
    {
        private Users id_user;
        private double balances;
        private DateTime last_updated;

        #region constructor
        public Balance(Users id_user, double balances, DateTime last_updated)
        {
            this.Id_user = id_user;
            this.Balances = balances;
            this.Last_updated = last_updated;
        }
        public Balance()
        {
            this.Id_user = new Users();
            this.Balances = 0f;
            this.Last_updated = DateTime.Now;
        }
        #endregion

        #region properties
        public Users Id_user { get => id_user; set => id_user = value; }
        public double Balances { get => balances; set => balances = value; }
        public DateTime Last_updated { get => last_updated; set => last_updated = value; }
        #endregion

        #region method
        public static void TambahData(Balance b,int id)
        {
            string sql = "insert into balances(user_id,current_balance, last_updated) " +
                "values ('" + id+ "','" +  b.Balances + "','" + b.Last_updated + "')";
            Koneksi.JalankanPerintahDML(sql);
        }

        public static int IdTerakhir()
        {
            string sql = "select max(user_id) from users";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            int id_terkahir = 0;

            while (hasil.Read() == true)
            {
                id_terkahir = hasil.GetInt32(0);
            }

            return id_terkahir;
        }

        public List<Balance> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select u.user_id, b.current_balance, b.last_updated" +
                    " from balances as b" +
                    " left join users as u on u.user_id = b.user_id";
            }
            else
            {
                sql = "select u.user_id, b.current_balance, b.last_updated" +
                    " from balances as b" +
                    " left join users as u on u.user_id = b.user_id" +
                    " where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }


            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Balance> listBalance = new List<Balance>();
            while (hasil.Read() == true)
            {
                Users u = new Users();
                u.Id_user = int.Parse(hasil.GetValue(0).ToString());

                Balance b = new Balance();
                b.Id_user = u;
                b.Balances = double.Parse(hasil.GetValue(1).ToString());
                b.Last_updated = DateTime.Parse(hasil.GetValue(2).ToString());


                listBalance.Add(b);
            }
            return listBalance;
        }

        public static void HapusData(string kode)
        {
            string sql = "delete from balances where user_id ='" +
                          kode + "';";
            Koneksi.JalankanPerintahDML(sql);
        }

        public static void UbahData(Balance b)
        {
            string sql = "update balances set current_balance = '" + b.Balances +
                "', last_updated = '" + b.Last_updated.ToString("yyyy-MM-dd HH:mm:ss") + 
                "' where user_id = '" + b.Id_user + "'";
            Koneksi.JalankanPerintahDML(sql);
        }

        public Balance GetBalances(int id)
        {
            string sql = "select current_balance from balances where user_id = '" + id + "'";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                Balance b = new Balance();
                b.Balances = double.Parse(hasil.GetValue(0).ToString());

                return b;
            }
            return null;
        }

        public static void Transfer(int id_recepient, double amount)
        {
            string sql = "UPDATE balances SET current_balance = current_balance + " + amount +
                ", last_updated = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                "' WHERE user_id = '" + id_recepient + "'"; ;
            Koneksi.JalankanPerintahDML(sql);
        }
        public static void UpdateBalance(int id_user,double amount)
        {
            string sql = "UPDATE balances SET current_balance = current_balance - " + amount +
                ", last_updated = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                "' WHERE user_id = '" + id_user + "'"; ;
            Koneksi.JalankanPerintahDML(sql);
        }
        public static void Topup(int id_user, double amount)
        {
            string sql = "UPDATE balances SET current_balance = current_balance + " + amount +
                ", last_updated = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                "' WHERE user_id = '" + id_user + "'"; ;
            Koneksi.JalankanPerintahDML(sql);
        }
        #endregion
    }
}
