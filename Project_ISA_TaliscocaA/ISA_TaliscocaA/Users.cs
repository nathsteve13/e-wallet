using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Transactions;
using static System.Net.WebRequestMethods;
using System.Configuration;
using System.Security.Cryptography;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ISA_TaliscocaA
{
    public class Users
    {
        private int id_user;
        private string name;
        private string password;
        private string email;
        private string phone_number;
        private string username;
        private string role;
        private string kartu_identitas;
        private string gender;
        private DateTime birth_date;
        private int pin;
        private string foto_wajah;

        #region constructor
        public Users(int id_user, string name, string password, string email, string phone_number, string username, string role, string kartu_identitas, string gender, DateTime birth_date, int pin, string foto_wajah)
        {
            this.Id_user = id_user;
            this.Name = name;
            this.Password = password;
            this.Email = email;
            this.Phone_number = phone_number;
            this.Username = username;
            this.Role = role;
            this.Kartu_identitas = kartu_identitas;
            this.Gender = gender;
            this.Birth_date = birth_date;
            this.Pin = pin;
            this.Foto_wajah = foto_wajah;
        }
        public Users()
        {
            this.Id_user = 0;
            this.Name = "";
            this.Password = "";
            this.Email = "";
            this.Phone_number = "";
            this.Username = "";
            this.Role = "";
            this.Kartu_identitas = "";
            this.Gender = "";
            this.Birth_date = DateTime.Now;
            this.Pin = 0;
            this.Foto_wajah = "";

        }
        #endregion

        #region properties
        public int Id_user { get => id_user; set => id_user = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }
        public string Username { get => username; set => username = value; }
        public string Role { get => role; set => role = value; }
        public string Kartu_identitas { get => kartu_identitas; set => kartu_identitas = value; }
        public string Gender { get => gender; set => gender = value; }
        public DateTime Birth_date { get => birth_date; set => birth_date = value; }
        public int Pin { get => pin; set => pin = value; }
        public string Foto_wajah { get => foto_wajah; set => foto_wajah = value; }
        #endregion

        #region method
        public string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = new byte[16];
                aes.IV = new byte[16];
                ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);
                byte[] encryptedBytes = transform.TransformFinalBlock(Encoding.UTF8.GetBytes(plainText), 0, Encoding.UTF8.GetBytes(plainText).Length);
                string txt = Convert.ToBase64String(encryptedBytes);
                return txt;
            }
        }
        public string Decrypt(string cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = new byte[16];
                aes.IV = new byte[16];
                ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] encryptedBytes = Convert.FromBase64String(cipherText);
                byte[] decryptedBytes = transform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                string txt = Encoding.UTF8.GetString(decryptedBytes);
                return txt;
            }
        }

        public static int HashingPin(int pin)
        {
            string sql = "select pin from users where pin = SHA2('" + pin + "',512)";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            int pin_user = 0;
            while (hasil.Read() == true)
            {
                pin_user = hasil.GetInt32(0);
            }
            return pin_user;
        }

        public static string ConvertTextToBinary(string text)
        {
            if (text.Length > 13)
                throw new ArgumentException("Text must be 13 characters or less.");

            string binaryString = string.Join("", text.Select(c => Convert.ToString(c, 2).PadLeft(8, '0')));
            return binaryString;
        }

        public static string SteganographyEncrypt(string text, Image image, string userId)
        {
            string binaryText = ConvertTextToBinary(text);
            Bitmap bitmap = new Bitmap(image);

            if (binaryText.Length > bitmap.Width * bitmap.Height * 3)
                throw new ArgumentException("The image is too small to hide the text");

            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            IntPtr ptr = bmpData.Scan0;
            int stride = bmpData.Stride;
            int bytes = stride * bitmap.Height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            int bitIndex = 0;
            for (int i = 0; i < rgbValues.Length; i++)
            {
                if (bitIndex >= binaryText.Length) break;
                int value = binaryText[bitIndex++] - '0';
                rgbValues[i] = (byte)((rgbValues[i] & ~1) | value);
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            bitmap.UnlockBits(bmpData);

            string filePath = Path.Combine("C:\\Users\\natha\\OneDrive\\Documents\\Nathanael Steven Soetrisno\\UBAYA\\Semester 4\\ISA\\Project_ISA_TaliscocaA\\stegano_image", $"encrypted_image_{userId}.png");

            bitmap.Save(filePath, ImageFormat.Png);
            string sqlFormattedPath = filePath.Replace("\\", "\\\\");
            return sqlFormattedPath;
        }



        public static void TambahData(Users u, Image foto)
        {
            using (TransactionScope transcope = new TransactionScope())
            {
                try
                {
                    Koneksi k = new Koneksi();
                    u.Foto_wajah = Users.SimpanGambar(u, foto);
                    string encrypted_Pass = u.Encrypt(u.Password.ToString());
                    string stegoPath = SteganographyEncrypt(u.Kartu_identitas, foto, u.Id_user.ToString());

                    string sql = "insert into users (user_id, username, name, email, phone_number, password, role, kartu_identitas, gender, birth_date, pin, foto_wajah) " +
                    "values ('0', '" + u.Username + "','" + u.Name.Replace(",", "\\'") + "','" + u.Email + "','" + u.Phone_number +
                    "','" + encrypted_Pass + "','" + u.role + "','" + stegoPath + "','" + u.Gender + "','" + u.Birth_date.ToString("yyyy-MM-dd") + "',SHA2('" + u.Pin + "',512), '" + u.Foto_wajah + "')";
                    Koneksi.JalankanPerintahDML(sql, k);
                    transcope.Complete();
                }
                catch (Exception ex)
                {
                    transcope.Dispose();
                    throw new Exception(ex.Message);
                }
            }
        }

        public static string SimpanGambar(Users u, Image image)
        {
            Configuration myConf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ConfigurationSectionGroup userSettings = myConf.SectionGroups["userSettings"];

            var settingSection = userSettings.Sections["Project_ISA_TaliscocaA.db"] as ClientSettingsSection;
            string path = settingSection.Settings.Get("photo_image").Value.ValueXml.InnerText;

            if (image != null)
            {
                image.Save(path + "\\photo_" + u.Id_user);
                return "photo_" + u.Id_user;

            }
            else
            {
                return "";
            }
        }

        public static Image BacaGambar(string cover_image)
        {
            Configuration myConf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ConfigurationSectionGroup userSettings = myConf.SectionGroups["userSettings"];

            var settingSection = userSettings.Sections["Project_ISA_TaliscocaA.db"] as ClientSettingsSection;
            string path = settingSection.Settings.Get("photo_image").Value.ValueXml.InnerText;
            try
            {
                Image coverImage = Image.FromFile(path + "\\" + cover_image);
                return coverImage;
            }
            catch
            {
                return null;
            }
        }

        public static List<Users> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select * from users";
            }
            else
            {
                sql = "select * from users where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Users> listUsers = new List<Users>();
            while (hasil.Read() == true)
            {
                Users u = new Users();
                u.Id_user = int.Parse(hasil.GetValue(0).ToString());
                u.Username = hasil.GetValue(1).ToString();
                u.Name = hasil.GetValue(2).ToString();
                u.Email = hasil.GetValue(3).ToString();
                u.Phone_number = hasil.GetValue(4).ToString();
                u.Password = hasil.GetValue(5).ToString();
                u.Role = hasil.GetValue(6).ToString();
                u.Kartu_identitas = hasil.GetValue(7).ToString();
                u.Gender = hasil.GetValue(8).ToString();
                u.Birth_date = DateTime.Parse(hasil.GetValue(9).ToString());
                u.Pin = int.Parse(hasil.GetValue(10).ToString());
                u.Foto_wajah = hasil.GetValue(11).ToString();


                listUsers.Add(u);
            }
            return listUsers;
        }

        public static List<Users> BacaDataUser(int id)
        {
            string sql = "select * from users where user_id = " + id;

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Users> listUsers = new List<Users>();
            while (hasil.Read())
            {
                Users u = new Users();
                u.Id_user = int.Parse(hasil.GetValue(0).ToString());
                u.Username = hasil.GetValue(1).ToString();
                u.Name = hasil.GetValue(2).ToString();
                u.Email = hasil.GetValue(3).ToString();
                u.Phone_number = hasil.GetValue(4).ToString();
                u.Password = hasil.GetValue(5).ToString();
                u.Role = hasil.GetValue(6).ToString();
                u.Kartu_identitas = SteganographyDecrypt(hasil.GetValue(7).ToString());
                u.Gender = hasil.GetValue(8).ToString();
                u.Birth_date = DateTime.Parse(hasil.GetValue(9).ToString());
                u.Pin = int.Parse(hasil.GetValue(10).ToString());
                u.Foto_wajah = hasil.GetValue(11).ToString();

                listUsers.Add(u);
            }
            return listUsers;
        }

        public static string SteganographyDecrypt(string imagePath)
        {
            using (Bitmap bitmap = new Bitmap(imagePath))
            {
                Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                IntPtr ptr = bmpData.Scan0;
                int bytes = Math.Abs(bmpData.Stride) * bitmap.Height;
                byte[] rgbValues = new byte[bytes];
                Marshal.Copy(ptr, rgbValues, 0, bytes);
                bitmap.UnlockBits(bmpData);

                StringBuilder extractedBinary = new StringBuilder();

                for (int i = 0; i < rgbValues.Length; i += 3)
                {
                    extractedBinary.Append((rgbValues[i] & 1));     // R
                    extractedBinary.Append((rgbValues[i + 1] & 1)); // G
                    extractedBinary.Append((rgbValues[i + 2] & 1)); // B
                }

                List<byte> byteList = new List<byte>();
                for (int i = 0; i < extractedBinary.Length; i += 8)
                {
                    if (i + 8 > extractedBinary.Length) break;
                    byteList.Add(Convert.ToByte(extractedBinary.ToString(i, 8), 2));
                }

                return Encoding.UTF8.GetString(byteList.ToArray());
            }
        }



        public static List<Users> BacaDataAdmin(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select * from users";
            }
            else
            {
                sql = "select * " +
                       "where u." + kriteria + " like '%" + nilaiKriteria + "%'";
            }



            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Users> listUsers = new List<Users>();
            while (hasil.Read() == true)
            {
                Users u = new Users();
                u.Id_user = int.Parse(hasil.GetValue(0).ToString());
                u.Username = hasil.GetValue(1).ToString();
                u.Name = hasil.GetValue(2).ToString();
                u.Email = hasil.GetValue(3).ToString();
                u.Phone_number = hasil.GetValue(4).ToString();
                u.Password = hasil.GetValue(5).ToString();
                u.Role = hasil.GetValue(6).ToString();
                u.Kartu_identitas = hasil.GetValue(7).ToString();
                u.Gender = hasil.GetValue(8).ToString();
                u.Birth_date = DateTime.Parse(hasil.GetValue(9).ToString());
                u.Pin = int.Parse(hasil.GetValue(10).ToString());
                u.Foto_wajah = hasil.GetValue(11).ToString();


                listUsers.Add(u);

            }
            hasil.Close();
            return listUsers;
        }

        public static void UbahData(Users u)
        {
            string sql = "update users set username ='" + u.Username +
                "',name='" + u.Name.Replace("'", "\\") + 
                "',email='" + u.Email + 
                "',phone_number='" + u.Phone_number +
                "',password="+ "SHA2('" + u.Password + "',512)" +
                ",role='" + u.Role + 
                "',gender='" + u.Gender +
                "',birth_date='" + u.Birth_date.ToString("yyyy-MM-dd") +
                "' where user_id='" + u.id_user + "'";
            Koneksi.JalankanPerintahDML(sql);
        }


        public static Users CekLogin(string username, string password)
        {
            string sql = "select * from users " + "where username = '" + username + "';";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                Users u = new Users(int.Parse(hasil.GetValue(0).ToString()), hasil.GetValue(1).ToString(),
                    hasil.GetValue(2).ToString(), hasil.GetValue(3).ToString(), hasil.GetValue(4).ToString(), hasil.GetValue(5).ToString(), 
                    hasil.GetValue(6).ToString(), hasil.GetValue(7).ToString(), hasil.GetValue(8).ToString(), DateTime.Parse(hasil.GetValue(9).ToString()), int.Parse(hasil.GetValue(10).ToString()), hasil.GetValue(11).ToString());
                string decrypted_pass = u.Decrypt(hasil.GetString(5));
                if (password == decrypted_pass) 
                {
                    return u;
                }
                
            }
            return null;
        }

        public static void CetakProduk()
        {
            string nama_file = "All Users";
            List<Users> listUsers = Users.BacaData("", "");
            StreamWriter fileCetak = new StreamWriter(nama_file);

            fileCetak.WriteLine("All Products");
            fileCetak.WriteLine();
            fileCetak.WriteLine("dicetak tanggal " + DateTime.Now.ToString("dd-MM-yyyy"));
            fileCetak.WriteLine();
            fileCetak.WriteLine("------------------------------------------------------------------");
            fileCetak.WriteLine("   user_id   username   name   email   phone_number   password   role   kartu_identitas   gender   birthdate   pin   foto_wajah");
            fileCetak.WriteLine("------------------------------------------------------------------");
            for (int i = 0; i < listUsers.Count; i++)
            {
                fileCetak.WriteLine(listUsers[i].Id_user.ToString() + "   " +
                                    listUsers[i].Username.ToString() + "   " +
                                    listUsers[i].Name.ToString() + "   " +
                                    listUsers[i].Email.ToString() + "   " +
                                    listUsers[i].Phone_number.ToString() + "   " +
                                    listUsers[i].Password.ToString() + "   " +
                                    listUsers[i].Role.ToString() + "   " +
                                    listUsers[i].Kartu_identitas.ToString() + "   " +
                                    listUsers[i].Gender.ToString() + "   " +
                                    listUsers[i].Birth_date.ToString() + "   " +
                                    listUsers[i].Pin.ToString() + "   " +
                                    listUsers[i].Foto_wajah.ToString());
            }
            fileCetak.WriteLine("------------------------------------------------------------------");
            fileCetak.Close();
            CustomPrint p = new CustomPrint(new System.Drawing.Font("Courier New", 12), nama_file, 100, 50, 50, 50);
            p.SendToPrinter();
        }

        #endregion
    }


}
