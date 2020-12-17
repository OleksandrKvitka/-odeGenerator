using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace BarcodeGenerator
{
    public class Barcode
    {
        private float _Height = 1.2f;
        private float _Width = 2.5f;
        private readonly float _Scale = 0.8f;
        private readonly string path = @"D:\Studing\University\!Магистратура\Бояринова\Lab\СodeGenerator\BarcodeGenerator\BD";

        public string Data { get; set; }

        public float Height
        {
            get { return _Height; }
            set { _Height = value / 100; }
        }

        public float Width
        {
            get { return _Width; }
            set
            {
                _Width = value / 100;
            }
        }

        public Image DrawBarcode()
        {
            if (string.IsNullOrEmpty(Data))
                throw new Exception("BarcodeGenerator: Input data can not be empty.");

            var ibarcode = new Codabar(Data, Width, Height, _Scale);
            Data = ibarcode.Data;

            return ibarcode.GenerateImage();
        }

        public string EncodeBarcode()
        {
            if (string.IsNullOrEmpty(Data))
                throw new Exception("BarcodeGenerator: Input data can not be empty.");

            var ibarcode = new Codabar(Data, Width, Height, _Scale);

            return ibarcode.Encode();
        }

        public string DecodeBarcode()
        {
            if (string.IsNullOrEmpty(Data))
                throw new Exception("BarcodeGenerator: Input data can not be empty.");

            var ibarcode = new Codabar(Data, Width, Height, _Scale);

            return ibarcode.Decode(Data);
        }

        public void SaveBarcode(Image barcode, string code)
        {
            if(barcode == null)
                throw new Exception("Barcode is null.");
            barcode.Save($"{path}\\barcode_{code}.png", ImageFormat.Png);
        }
    }
}
