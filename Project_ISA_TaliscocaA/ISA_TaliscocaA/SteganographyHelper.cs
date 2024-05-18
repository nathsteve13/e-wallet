using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_TaliscocaA
{
    public static class SteganographyHelper
    {
        public static Bitmap EmbedText(string text, Bitmap bmp)
        {
            int pixelIndex = 0;
            int charIndex = 0;
            int charValue = 0;
            int zeros = 0;
            bool isMessageFinished = false;

            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color pixel = bmp.GetPixel(j, i);

                    for (int n = 0; n < 3; n++)
                    {
                        if (pixelIndex % 8 == 0)
                        {
                            if (charIndex >= text.Length)
                            {
                                isMessageFinished = true;
                            }
                            else
                            {
                                charValue = text[charIndex++];
                            }
                        }

                        byte newColor = pixel.R;

                        if (n == 0) newColor = pixel.R;
                        else if (n == 1) newColor = pixel.G;
                        else if (n == 2) newColor = pixel.B;

                        newColor = (byte)((newColor & ~1) | (charValue & 1));
                        charValue >>= 1;

                        if (n == 0) pixel = Color.FromArgb(pixel.A, newColor, pixel.G, pixel.B);
                        if (n == 1) pixel = Color.FromArgb(pixel.A, pixel.R, newColor, pixel.B);
                        if (n == 2) pixel = Color.FromArgb(pixel.A, pixel.R, pixel.G, newColor);

                        bmp.SetPixel(j, i, pixel);

                        pixelIndex++;

                        if (isMessageFinished && zeros++ >= 8)
                        {
                            return bmp;
                        }
                    }
                }
            }

            return bmp;

        }
        public static string ExtractText(Bitmap bmp)
        {
            int colorUnitIndex = 0;
            int charValue = 0;
            string extractedText = String.Empty;

            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color pixel = bmp.GetPixel(j, i);

                    for (int n = 0; n < 3; n++)
                    {
                        byte color = pixel.R;
                        if (n == 1) color = pixel.G;
                        else if (n == 2) color = pixel.B;

                        charValue = (charValue << 1) | (color & 1);

                        colorUnitIndex++;

                        if (colorUnitIndex % 8 == 0)
                        {
                            charValue = reverseBits(charValue);
                            if (charValue == 0)
                            {
                                return extractedText;
                            }
                            char c = (char)charValue;
                            extractedText += c.ToString();
                        }
                    }
                }
            }

            return extractedText;
        }
        private static int reverseBits(int n)
        {
            int result = 0;
            for (int i = 0; i < 8; i++)
            {
                result = (result << 1) | (n & 1);
                n >>= 1;
            }
            return result;
        }

    }
}
