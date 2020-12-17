namespace BarcodeGenerator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class Codabar
    {
        public string Data { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float FontSize { get; set; } = 17.0f;
        public float Scale { get; set; }

        private Hashtable Codabar_Code = new Hashtable()
        {
          {
            '0',
            "101010011"
          },
          {
            '1',
            "101011001"
          },
          {
            '2',
            "101001011"
          },
          {
            '3',
            "110010101"
          },
          {
            '4',
            "101101001"
          },
          {
            '5',
            "110101001"
          },
          {
            '6',
            "100101011"
          },
          {
            '7',
            "100101101"
          },
          {
            '8',
            "100110101"
          },
          {
            '9',
            "110100101"
          },
          {
            'A',
            "1011001001"
          },
          {
            'B',
            "1010010011"
          },
          {
            'C',
            "1001001011"
          },
          {
            'D',
            "1010011001"
          },
          {
            'a',
            "1011001001"
          },
          {
            'b',
            "1010010011"
          },
          {
            'c',
            "1001001011"
          },
          {
            'd',
            "1010011001"
          },
          {
            '-',
            "101001101"
          },
          {
            '$',
            "101100101"
          },
          {
            ':',
            "1101011011"
          },
          {
            '/',
            "1101101011"
          },
          {
            '.',
            "1101101101"
          },
          {
            '+',
            "101100110011"
          }
        };

        private Dictionary<string, int> CodabarDictionary = new Dictionary<string, int>()
        {
            {"0", 0 },
            {"1", 1 },
            {"2", 2 },
            {"3", 3 },
            {"4", 4 },
            {"5", 5 },
            {"6", 6 },
            {"7", 7 },
            {"8", 8 },
            {"9", 9 },
            {"-", 10 },
            {"$", 11 },
            {":", 12 },
            {"/", 13 },
            {".", 14 },
            {"+", 15 },
            {"A", 16 },
            {"B", 17 },
            {"C", 18 },
            {"D", 19 }
        };

        public Codabar(string data, float width, float height, float scale)
        {
            Data = data;
            Width = width;
            Height = height;
            Scale = scale;
        }

        #region Encode
        public string Encode()
        {
            if (Data.Length < 2)
                throw new Exception("Codabar format required min 2 char");
            if (!"ABCD".Contains(Data.ToUpper().Trim()[0]))
            {
                throw new Exception("Invalide start charecter, Codabar starts with any one of this charecter 'A','B','C','D'");
            }
            if (!"ABCD".Contains(Data.ToUpper().Trim()[Data.Length - 1]))
            {
                throw new Exception("Invalide start charecter, Codabar ends with any one of this charecter 'A','B','C','D'");
            }
            if (!new Regex("^[0-9\\-\\+\\$\\.\\:\\/]+$").IsMatch(Data.Substring(1, Data.Length - 2)))
            {
                throw new Exception("Codabar data contains invalid charecter");
            }
            var checkDigit = CalculateCheckDigit();
            Data = Data.Insert(Data.Length - 1, checkDigit.ToString());
            return GetEncodedData();
        }

        private string GetEncodedData()
        {
            var encodedData = "";
            for (int i = 0; i < Data.Length; i++)
                encodedData += Codabar_Code[Data[i]] + " ";
            return encodedData;
        }

        public Bitmap GenerateImage()
        {
            if (Data.Length < 2)
                throw new Exception("GENERATE_IMAGE-1: Codabar format required min 2 char.");
            if (!"ABCD".Contains<char>(Data.ToUpper().Trim()[0]))
                throw new Exception("GENERATE_IMAGE-2: Invalide start charecter, Codabar starts with any one of this charecter 'A','B','C','D'");
            if (!"ABCD".Contains<char>(Data.ToUpper().Trim()[Data.Length - 1]))
                throw new Exception("GENERATE_IMAGE-3: Invalide end charecter, Codabar ends with any one of this charecter 'A','B','C','D'");
            if (!new Regex("^[0-9\\-\\+\\$\\.\\:\\/]+$").IsMatch(Data.Substring(1, Data.Length - 2)))
                throw new Exception("GENERATE_IMAGE-4: Codabar data contains invalid charecter");
            Bitmap bitmap = new Bitmap((int)(float)((double)Width * Scale * 300.0), (int)(float)((double)Height * Scale * 100.0));
            Graphics g = Graphics.FromImage((Image)bitmap);
            DrawBarcode(g, new Point(0, 0));
            g.Dispose();
            return bitmap;
        }

        private void DrawBarcode(Graphics g, Point pt)
        {
            float num1 = Width * Scale;
            float num2 = Height * Scale;
            float width = num1 / 87f;
            GraphicsState gstate = g.Save();
            g.PageUnit = GraphicsUnit.Inch;
            g.PageScale = 1f;
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            float x1 = 0.0f;
            StringBuilder stringBuilder = new StringBuilder();
            float num3 = pt.X;
            float y = pt.Y;
            float num4 = 0.0f;
            Font font = new Font("Arial", FontSize * Scale);
            string str1 = string.Join("", Data.Select((x => Codabar_Code[x].ToString() + "0")));
            string str2 = str1.Substring(0, str1.Length - 1);
            string text = str2;
            float height = g.MeasureString(text, font).Height;
            for (int startIndex = 0; startIndex < str2.Length; ++startIndex)
            {
                if (text.Substring(startIndex, 1) == "1")
                {
                    if (num3 == pt.X)
                        num3 = x1;
                    g.FillRectangle((Brush)solidBrush, x1, y, width, num2 - height);
                }
                x1 += width;
                num4 = x1;
            }
            g.Restore(gstate);
        }

        private int CalculateCheckDigit()
        {
            int sum = 0;
            for (int i = 0; i < Data.Length; i++)
                sum += CodabarDictionary[Data[i].ToString().ToUpper()];
            int checkDigit = 16 - (sum % 16);
            return checkDigit;
        }
        #endregion

        #region Decode
        public string Decode(string str)
        {
            var decoded = "";
            var codeParts = str.Trim().Split(' ');
            foreach (var code in codeParts)
            {
                decoded += GetKeyFromHach(code);
            }
            return decoded;
        }

        public string GetKeyFromHach(string value)
        {
            foreach (char key in Codabar_Code.Keys)
                if ((string)Codabar_Code[key] == value)
                    return key.ToString().ToUpper();
            throw new Exception("Wrong code format.");
        }
        #endregion
	}
}
