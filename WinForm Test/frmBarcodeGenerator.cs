using System;
using System.Windows.Forms;
using BarcodeGenerator;

namespace WinForm_Test
{
    public partial class frmBarcodeGenerator : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public frmBarcodeGenerator()
        {
            InitializeComponent();
        }

        private void FrmBarcodeGenerator_Load(object sender, EventArgs e)
        {
            //cmbBarcodeType.DataSource = Enum.GetValues(typeof(SymbologyType));
        }

        private void FlowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Barcode barcode = new Barcode()
                {
                    Data = txtBarcode.Text.Trim()
                };
                barcode.Width = 300;
                barcode.Height = 150;
                pbBarcode.Image = barcode.DrawBarcode();
                encodeResulttext.Text = barcode.EncodeBarcode();

                saveButton.Enabled = pbBarcode != null && pbBarcode.Image != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "BarcodeGenerator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Barcode barcode = new Barcode()
                {
                    Data = textBox1.Text.Trim()
                };
                barcode.Width = 300;
                barcode.Height = 150;
                decodeResult.Text = barcode.DecodeBarcode();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "BarcodeGenerator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Barcode barcode = new Barcode()
                {
                    Data = textBox1.Text.Trim()
                };
                barcode.Width = 300;
                barcode.Height = 150;
                barcode.SaveBarcode(pbBarcode.Image, txtBarcode.Text);
                MessageBox.Show($"UPC-A Barcode saved: {txtBarcode.Text}", "EAN13", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "BarcodeGenerator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            btnCreate.Enabled = !string.IsNullOrEmpty(txtBarcode.Text);
            saveButton.Enabled = pbBarcode != null && pbBarcode.Image != null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void encodeResultresult_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
