using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_TaliscocaA
{
    public class CustomPrint
    {
        private Font tipeFont;
        private StreamReader fileCetak;
        private float marginAtas, marginBawah, marginKiri, marginKanan;

        public CustomPrint()
        {
            tipeFont = new Font("Courier New", 10);
            FileCetak = new StreamReader("");
            MarginAtas = 10;
            MarginBawah = 5;
            MarginKiri = 5;
            MarginKanan = 5;
        }
        public CustomPrint(Font fontType, string fileCetak, float marginAtas, float marginBawah, float marginKiri, float marginKanan)
        {
            TipeFont = fontType;
            FileCetak = new StreamReader(fileCetak);
            MarginAtas = marginAtas;
            MarginBawah = marginBawah;
            MarginKiri = marginKiri;
            MarginKanan = marginKanan;
        }

        public Font TipeFont { get => tipeFont; set => tipeFont = value; }
        public StreamReader FileCetak { get => fileCetak; set => fileCetak = value; }
        public float MarginAtas { get => marginAtas; set => marginAtas = value; }
        public float MarginBawah { get => marginBawah; set => marginBawah = value; }
        public float MarginKiri { get => marginKiri; set => marginKiri = value; }
        public float MarginKanan { get => marginKanan; set => marginKanan = value; }

        private void Cetak(object sender, PrintPageEventArgs e)
        {
            float tinggiFont = TipeFont.GetHeight(e.Graphics);
            float y;
            float x = MarginKiri;
            int jumBarisSaatIni = 0;
            int maxBarisDalamHalaman = (int)((e.MarginBounds.Height - MarginAtas - MarginBawah) / tinggiFont);
            string textCetak = FileCetak.ReadLine();
            while (jumBarisSaatIni < maxBarisDalamHalaman && textCetak != null)
            {
                y = MarginAtas + (jumBarisSaatIni * tinggiFont);
                e.Graphics.DrawString(textCetak, TipeFont, Brushes.DarkBlue, x, y);
                jumBarisSaatIni++;
                textCetak = FileCetak.ReadLine();
            }
            if (textCetak != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }
        public void SendToPrinter()
        {
            PrintDocument p = new PrintDocument();
            p.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            p.PrintPage += new PrintPageEventHandler(Cetak);
            p.Print();
            FileCetak.Close();
        }
    }
}
