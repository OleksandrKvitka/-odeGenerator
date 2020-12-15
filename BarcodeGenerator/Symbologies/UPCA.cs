namespace BarcodeGenerator
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class UPCA
    {
        public string Data { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float FontSize { get; set; } = 17.0f;
        public float Scale { get; set; }

        private readonly string[] _leftCode = 
        { 
            "0001101",  //0
            "0011001",  //1
            "0010011",  //2
            "0111101",  //3
            "0100011",  //4
            "0110001",  //5
            "0101111",  //6
            "0111011",  //7
            "0110111",  //8
            "0001011"   //9
        };

        private readonly string[] _rightCode = 
        {
            "1110010",  //0
            "1100110",  //1
            "1101100",  //2
            "1000010",  //3               
            "1011100",  //4
            "1001110",  //5
            "1010000",  //6
            "1000100",  //7           
            "1001000",  //8
            "1110100"   //9
        };

        private readonly string _quiteZone = "0000000000";
        private readonly string _guardPatterns = "101";
        private readonly string _middleGuardPatterns = "01010";

        private string _numberSystem = "";
        private string _manufacturerCode = "";
        private string _productCode = "";
        private string _checkDigit = "";

        public UPCA(string data, float width, float height, float scale)
        {
            Data = data;
            Width = width;
            Height = height;
            Scale = scale;
        }

        #region Encode
        public string Encode(string digits)
        {
            if (!new Regex(@"^\d+$").IsMatch(digits))
            {
                throw new Exception("UPC-A allowed numeric values only");
            }
            if (digits.Length < 11)
            {
                throw new Exception("UPC-A format required min 11 char.");
            }
            if (digits.Length > 12)
            {
                throw new Exception("UPC-A format required max 12 char.");
            }

            var numberSystem = digits.Substring(0, 1);
            var manufacturerCode = digits.Substring(1, 5);
            var productCode = digits.Substring(6, 5);

            var checkDigit = CalculateCheckDigit();
            if (digits.Length == 12)
            {
                if ((digits[11] - '0') != checkDigit)
                    throw new Exception("Invalid check digit");
            }

            var encodedData = GetEncodedData(numberSystem, manufacturerCode, productCode, checkDigit.ToString());

            return encodedData;
        }

        private string GetEncodedData(
            string numberSystemPart,
            string manufacturerCodePart,
            string productCodePart,
            string checkDigitPart)
        {
            var numberSystem = EncodedDigitToPattern(numberSystemPart, _leftCode);
            var manufacturerCode = Regex.Replace(EncodedDigitToPattern(manufacturerCodePart, _leftCode), ".{7}", "$0 ");
            var productCode = Regex.Replace(EncodedDigitToPattern(productCodePart, _rightCode), ".{7}", "$0 ");
            var checkDigit = EncodedDigitToPattern(checkDigitPart, _rightCode);
            
            var encodedData =
                    $"{_quiteZone} {_guardPatterns} {numberSystem} {manufacturerCode}{_middleGuardPatterns} {productCode}{checkDigit} {_guardPatterns} {_quiteZone}";
          
            return encodedData;
        }

        private string EncodedDigitToPattern(string digits, string[] pattern)
        {
            return string.Join("", digits.Select(x => pattern[(x - '0')]));
        }

        public Bitmap GenerateImage()
        {
            if (!new Regex(@"^\d+$").IsMatch(Data))
            {
                throw new Exception("UPC-A allowed numeric values only");
            }
            if (Data.Length < 11)
            {
                throw new Exception("UPC-A format required min 11 char.");
            }
            if (Data.Length > 12)
            {
                throw new Exception("UPC-A format required max 12 char.");
            }

            _numberSystem = Data.Substring(0, 1);
            _manufacturerCode = Data.Substring(1, 5);
            _productCode = Data.Substring(6, 5);

            var checkDigit = CalculateCheckDigit();
            if (Data.Length == 12)
            {
                if ((Data[11] - '0') != checkDigit)
                    throw new Exception("Invalid check digit");
            }
            else
            {
                Data = string.Concat(Data, checkDigit);
            }

            _checkDigit = Data.Substring(11, 1);

            var tempWidth = (Width * Scale) * 100;
            var tempHeight = (Height * Scale) * 100;

            Bitmap bmp = new Bitmap((int)tempWidth, (int)tempHeight);

            Graphics g = Graphics.FromImage(bmp);
            DrawUpcaBarcode(g, new Point(0, 0));

            g.Dispose();
            return bmp;
        }

        private void DrawUpcaBarcode(Graphics g, Point pt)
        {
            var numberSystem = EncodedDigitToPattern(_numberSystem, _leftCode);
            var manufacturerCode = EncodedDigitToPattern(_manufacturerCode, _leftCode);
            var productCode = EncodedDigitToPattern(_productCode, _rightCode);
            var checkDigit = EncodedDigitToPattern(_checkDigit, _rightCode);

            var upcA =
                $"{_quiteZone}{_guardPatterns}{numberSystem}{manufacturerCode}{_middleGuardPatterns}{productCode}{checkDigit}{_guardPatterns}{_quiteZone}";

            var width = Width * Scale;
            var height = Height * Scale;

            var lineWidth = width / 113f;

            GraphicsState gs = g.Save();
            g.PageUnit = GraphicsUnit.Inch;
            g.PageScale = 1;

            float xPosition = 0;
            float xStart = pt.X;
            float yStart = pt.Y;

            SolidBrush brush = new SolidBrush(Color.Black);
            Font font = new Font("Arial", FontSize * Scale);

            float fTextHeight = g.MeasureString(upcA, font).Height;

            for (int i = 0; i < upcA.Length; i++)
            {
                if (upcA.Substring(i, 1) == "1")
                {
                    if (xStart == pt.X)
                        xStart = xPosition;

                    // Save room for the UPC number below the bar code.
                    if ((i > 19 && i < 56) || (i > 59 && i < 95))
                        // Draw space for the number
                        g.FillRectangle(brush, xPosition, yStart, lineWidth, height - fTextHeight);
                    else
                        // Draw a full line.
                        g.FillRectangle(brush, xPosition, yStart, lineWidth, height);
                }

                xPosition += lineWidth;
            }

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            // Draw the upc numbers below the line.
            xPosition = xStart - g.MeasureString(_numberSystem, font).Width;
            float yPosition = yStart + (height - fTextHeight);
            // Draw Product Type.
            g.DrawString(_numberSystem, font, brush, new PointF(xPosition, yPosition));

            xPosition += g.MeasureString(_numberSystem, font).Width + 45 * lineWidth -
                            g.MeasureString(_manufacturerCode, font).Width;

            // Draw MFG Number.
            g.DrawString(_manufacturerCode, font, brush, new PointF(xPosition, yPosition));

            // Add the width of the MFG Number and 5 modules for the separator.
            xPosition += g.MeasureString(_manufacturerCode, font).Width +
                         5 * lineWidth;

            // Draw Product ID.
            g.DrawString(_productCode, font, brush, new PointF(xPosition, yPosition));

            xPosition += 46 * lineWidth;

            g.DrawString(_checkDigit, font, brush, new PointF(xPosition, yPosition));

            g.Restore(gs);
        }

        

        private int CalculateCheckDigit()
        {
            var digits = Data.Take(11).Select(x => x - '0');
            var even = digits.Where((x, i) => i % 2 == 0).Sum() * 3;
            var odd = digits.Where((x, i) => i % 2 != 0).Sum();

            int checkDigit = 10 - ((even + odd) % 10);

            return checkDigit;
        }
        #endregion

        #region Decode
        public string Decode(string digits)
        {
            var digitsParts = digits.Trim().Split(' ');

            if (digitsParts.Count() != 12 + 5)
            {
                throw new Exception("Incorrect UPC-A format.");
            }

            var numberSystem = digitsParts[2];
            var manufacturerCode = digitsParts.SubArray(3, 5);
            var productCodePart = digitsParts.SubArray(9, 5);
            var checkDigitPart = digitsParts[14];

            var upcA_decoded = GetDecodedData(numberSystem, manufacturerCode, productCodePart, checkDigitPart);

            return upcA_decoded;
        }

        private string GetDecodedData(
            string numberSystemPart,
            string[] manufacturerCodePart,
            string[] productCodePart,
            string checkDigitPart)
        {
            var numberSystem = DecodeDigitToPattern(numberSystemPart, _leftCode);
            var manufacturerCode = string.Concat(manufacturerCodePart.Select(x => DecodeDigitToPattern(x, _leftCode)));
            var productCode = string.Concat(productCodePart.Select(x => DecodeDigitToPattern(x, _rightCode)));
            var checkDigit = DecodeDigitToPattern(checkDigitPart, _rightCode);

            var decodedData = $"{numberSystem}{manufacturerCode}{productCode}{checkDigit}";

            return decodedData;
        }

        private string DecodeDigitToPattern(string code, string[] pattern)
        {
            return string.Join(
                "",
                pattern
                    .Select((x, i) => new { i, x })
                    .Where(t => t.x == code)
                    .Select(t => t.i)
                );
        }
        #endregion
	}
}
