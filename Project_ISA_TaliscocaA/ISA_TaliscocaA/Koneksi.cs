﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace ISA_TaliscocaA
{
    public class Koneksi
    {
        public MySqlConnection koneksiDB;

        #region constructor 
        public Koneksi()
        {
            Configuration myConf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSectionGroup userSettings = myConf.SectionGroups["userSettings"];
            var settingsSection = userSettings.Sections["Project_ISA_TaliscocaA.db"] as ClientSettingsSection;

            string DbServer = settingsSection.Settings.Get("DbServer").Value.ValueXml.InnerText;
            string DbName = settingsSection.Settings.Get("DbName").Value.ValueXml.InnerText;
            string DbUsername = settingsSection.Settings.Get("DbUsername").Value.ValueXml.InnerText;
            string DbPassword = settingsSection.Settings.Get("DbPassword").Value.ValueXml.InnerText;

            string strCon = "server=" + DbServer + ";database=" + DbName + ";uid=" + DbUsername + ";password=" + DbPassword;
            KoneksiDB = new MySqlConnection();
            KoneksiDB.ConnectionString = strCon;
            Connect();
        }
        public Koneksi(string pServer, string pDatabase, string pUsername, string pPassword)
        {
            string strCon = "server=" + pServer + ";database=" + pDatabase + ";username=" + pUsername + ";password=" + pPassword;
            KoneksiDB = new MySqlConnection();
            KoneksiDB.ConnectionString = strCon;
            Connect();
        }
        #endregion

        #region properties
        public MySqlConnection KoneksiDB { get => koneksiDB; private set => koneksiDB = value; }
        #endregion

        #region method
        public void Connect()
        {
            if (KoneksiDB.State == System.Data.ConnectionState.Open)
            {
                KoneksiDB.Close();
            }
            KoneksiDB.Open();
        }

        public static MySqlDataReader JalankanPerintahQuery(string sql)
        {
            Koneksi k = new Koneksi();
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            MySqlDataReader hasil = c.ExecuteReader();

            return hasil;
        }

        public static bool JalankanPerintahDML(string sql)
        {
            Koneksi k = new Koneksi();
            MySqlCommand c = new MySqlCommand(sql, k.koneksiDB);
            int hasil = c.ExecuteNonQuery();
            if (hasil > 0)
            {
                return true;
            }
            else { return false; }
        }
        public static int JalankanPerintahDML(string sql, Koneksi k)
        {
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            return c.ExecuteNonQuery();
        }



        #endregion
    }
}
