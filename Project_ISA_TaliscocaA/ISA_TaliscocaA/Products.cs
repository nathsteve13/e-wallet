using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ISA_TaliscocaA
{
    public class Products
    {
        private int products_id;
        private Users partners_id;
        private string namaProduk;
        private float price;
        private string descriptionText;
        private int stock;

        public Products(int products_id, Users partners_id, string namaProduk, float price, string descriptionText, int stock)
        {
            Products_id = products_id;
            Partners_id = partners_id;
            NamaProduk = namaProduk;
            Price = price;
            DescriptionText = descriptionText;
            Stock = stock;
        }
        public Products()
        {
            Products_id = 0;
            Partners_id = new Users();
            NamaProduk = "";
            Price = 0;
            DescriptionText = "";
            Stock = 0;

        }

        public int Products_id { get => products_id; set => products_id = value; }
        public Users Partners_id { get => partners_id; set => partners_id = value; }
        public int PartnerId
        {
            get { return Partners_id.Id_user; }
        }
        public string NamaProduk { get => namaProduk; set => namaProduk = value; }
        public float Price { get => price; set => price = value; }
        public string DescriptionText { get => descriptionText; set => descriptionText = value; }
        public int Stock { get => stock; set => stock = value; }

        public static void TambahData(Products p)
        {
            string sql = "insert into products(product_id,partner_id,name,price,description,stock) " +
                "values ('" + p.Products_id + "','" + p.Partners_id.Id_user + "','" + p.NamaProduk + "','"
                + p.Price + "','" + p.DescriptionText + "','" + p.Stock + "')";
            Koneksi.JalankanPerintahDML(sql);
        }
        public static List<Products> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select p.product_id, u.user_id, p.name, p.price, p.description, p.stock from products as p left join users as u on p.partner_id = u.user_id;";
            }
            else
            {
                sql = "select p.product_id, " +
                       " p.name, u.user_id, p.price, p.description , p.stock" +
                       " from products as p" +
                       " left join users as u on p.partner_id = u.user_id " +
                       "where p." + kriteria + " like '%" + nilaiKriteria + "%'";
            }


            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Products> listProducts = new List<Products>();
            while (hasil.Read() == true)
            {
                listProducts.Add(new Products
                {
                    Products_id = int.Parse(hasil["product_id"].ToString()),
                    Partners_id = new Users { Id_user = int.Parse(hasil["user_id"].ToString()) },
                    NamaProduk = hasil["name"].ToString(),
                    Price = float.Parse(hasil["price"].ToString()),
                    DescriptionText = hasil["description"].ToString(),
                    Stock = int.Parse(hasil["stock"].ToString())
                });
            }
            hasil.Close();
            return listProducts;
        }
        public static List<Products> BacaDataAdmin(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select product_id, partner_id, name, price, description, stock from products";
            }
            else
            {
                sql = "select product_id, partner_id, name, price, description, stock " +
                      "from products " +
                       "where p." + kriteria + " like '%" + nilaiKriteria + "%'";
            }


            
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Products> listProducts = new List<Products>();
            while (hasil.Read() == true)
            {
                Users u = new Users { Id_user = int.Parse(hasil["partner_id"].ToString()) };
                //u.Id_user = int.Parse(hasil.GetValue(1).ToString());

                Products p = new Products(); 
                p.Products_id = int.Parse(hasil.GetValue(0).ToString());
                p.Partners_id= u;
                p.NamaProduk = hasil.GetValue(2).ToString();
                p.Price = float.Parse(hasil.GetValue(3).ToString());
                p.Stock = int.Parse(hasil.GetValue(5).ToString());
                p.DescriptionText = hasil.GetValue(4).ToString();  
                
                listProducts.Add(p);
            }
            hasil.Close();
            return listProducts;
        }
        public static void HapusData(string kodeHapus)
        {
            string sql = "delete from products where product_id = '" + kodeHapus + "';";
            Koneksi.JalankanPerintahDML(sql);
        }
        public static void UbahData(Products p)
        {
            string sql = "update products set name='" + p.NamaProduk.Replace("'", "\\") +
                "',price='" + float.Parse(p.price.ToString()) +
                "',description='" + p.DescriptionText +
                "',stock='" + int.Parse(p.Stock.ToString()) +
                "' where product_id=" + p.Products_id + "";
            Koneksi.JalankanPerintahDML(sql);
        }

        public static void CetakProduk()
        {
            string nama_file = "All Product";
            List<Products> listProducts = Products.BacaData("", "");
            StreamWriter fileCetak = new StreamWriter(nama_file);

            fileCetak.WriteLine("All Products");
            fileCetak.WriteLine();
            fileCetak.WriteLine("dicetak tanggal " + DateTime.Now.ToString("dd-MM-yyyy"));
            fileCetak.WriteLine();
            fileCetak.WriteLine("------------------------------------------------------------------");
            fileCetak.WriteLine("   product_id   partner_id   name   price   description   stock   ");
            fileCetak.WriteLine("------------------------------------------------------------------");
            for(int i= 0; i<listProducts.Count; i++)
            {
                fileCetak.WriteLine(listProducts[i].Products_id.ToString() + "   " +
                                    listProducts[i].PartnerId.ToString() + "   " +
                                    listProducts[i].NamaProduk.ToString() + "   " +
                                    listProducts[i].Price.ToString() + "   " +
                                    listProducts[i].DescriptionText.ToString() + "   " +
                                    listProducts[i].Stock.ToString());
            }
            fileCetak.WriteLine("------------------------------------------------------------------");
            fileCetak.Close();
            CustomPrint p = new CustomPrint(new System.Drawing.Font("Courier New", 12), nama_file, 100, 50, 50, 50);
            p.SendToPrinter();
        }
    }
}
