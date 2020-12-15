namespace BarcodeGenerator.Tests
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class UPCA
	{
		[TestMethod]
		[DataRow(
			"012345633355",
			"0000000000 101 0001101 0011001 0010011 0111101 0100011 0110001 01010 1010000 1000010 1000010 1000010 1001110 1001110 101 0000000000")
		]
		public void Encode(string data, string expected)
		{
			Barcode barcode = new Barcode()
			{
				Data = data,
				Width = 300,
				Height = 150
			};

			var result = barcode.EncodeBarcode();

			Assert.AreEqual(result, expected);
		}

		[TestMethod]
		[DataRow(
			"0000000000 101 0001101 0011001 0010011 0111101 0100011 0110001 01010 1010000 1000010 1000010 1000010 1001110 1001110 101 0000000000", 
			"012345633355")
		]
		[DataRow(
			"0000000000 101 0001101 0011001 0010011 0111101 0100011 0110001 01010 1010000 1000100 1001000 1110100 1001110 1001110 101 0000000000",
			"012345678955")
		]
		[DataRow(
			"0000000000 101 0001011 0001011 0110111 0111011 0101111 0110001 01010 1011100 1000010 1101100 1100110 1110010 1110010 101 0000000000",
			"998765432100")
		]
		public void Decode(string data, string expected)
		{
			Barcode barcode = new Barcode()
			{
				Data = data,
				Width = 300,
				Height = 150
			};

			var result = barcode.DecodeBarcode();

			Assert.AreEqual(result, expected);
		}

		[TestMethod]
		[DataRow("0000000000 101 0001101 0011001 0010011 0111101 0100011 0110001 01010 1010000 1000010 1000010 1000010 1001110 1001110 101 0000000000 0000000000")]
		[DataRow("0000000000 101 0001101")]
		[DataRow("")]
		public void Decode_ThrowException(string data)
		{
			Barcode barcode = new Barcode()
			{
				Data = data
			};

			Assert.ThrowsException<Exception>(() => barcode.DecodeBarcode());
		}
	}
}
