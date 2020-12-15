namespace WinForm_Test
{
    partial class frmBarcodeGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.btnClose = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.saveButton = new System.Windows.Forms.Button();
			this.encodeTitle = new System.Windows.Forms.Label();
			this.decodeResult = new System.Windows.Forms.Label();
			this.pbBarcode = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.decodeTitle = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnCreate = new System.Windows.Forms.Button();
			this.txtBarcode = new System.Windows.Forms.TextBox();
			this.lblHeader = new System.Windows.Forms.Label();
			this.title = new System.Windows.Forms.Label();
			this.encodeResulttext = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbBarcode)).BeginInit();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.ForeColor = System.Drawing.Color.White;
			this.btnClose.Location = new System.Drawing.Point(896, 0);
			this.btnClose.Margin = new System.Windows.Forms.Padding(0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(37, 36);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "X";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
			this.flowLayoutPanel1.Controls.Add(this.btnClose);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(933, 37);
			this.flowLayoutPanel1.TabIndex = 1;
			this.flowLayoutPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FlowLayoutPanel1_MouseDown);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.encodeResulttext);
			this.groupBox1.Controls.Add(this.saveButton);
			this.groupBox1.Controls.Add(this.encodeTitle);
			this.groupBox1.Controls.Add(this.decodeResult);
			this.groupBox1.Controls.Add(this.pbBarcode);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.decodeTitle);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.btnCreate);
			this.groupBox1.Controls.Add(this.txtBarcode);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(12, 92);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(922, 365);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// saveButton
			// 
			this.saveButton.Enabled = false;
			this.saveButton.Location = new System.Drawing.Point(325, 141);
			this.saveButton.Margin = new System.Windows.Forms.Padding(8);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(111, 28);
			this.saveButton.TabIndex = 29;
			this.saveButton.Text = "Save Barcode";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// encodeTitle
			// 
			this.encodeTitle.AutoSize = true;
			this.encodeTitle.Font = new System.Drawing.Font("Tahoma", 14F);
			this.encodeTitle.Location = new System.Drawing.Point(6, 0);
			this.encodeTitle.Name = "encodeTitle";
			this.encodeTitle.Size = new System.Drawing.Size(72, 23);
			this.encodeTitle.TabIndex = 28;
			this.encodeTitle.Text = "Encode";
			// 
			// decodeResult
			// 
			this.decodeResult.AutoSize = true;
			this.decodeResult.Font = new System.Drawing.Font("Tahoma", 14F);
			this.decodeResult.Location = new System.Drawing.Point(145, 287);
			this.decodeResult.Name = "decodeResult";
			this.decodeResult.Size = new System.Drawing.Size(125, 23);
			this.decodeResult.TabIndex = 27;
			this.decodeResult.Text = "Decode result";
			// 
			// pbBarcode
			// 
			this.pbBarcode.Location = new System.Drawing.Point(256, 0);
			this.pbBarcode.Name = "pbBarcode";
			this.pbBarcode.Size = new System.Drawing.Size(257, 130);
			this.pbBarcode.TabIndex = 6;
			this.pbBarcode.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(9, 282);
			this.button1.Margin = new System.Windows.Forms.Padding(8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(111, 28);
			this.button1.TabIndex = 26;
			this.button1.Text = "Decode";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// decodeTitle
			// 
			this.decodeTitle.AutoSize = true;
			this.decodeTitle.Font = new System.Drawing.Font("Tahoma", 14F);
			this.decodeTitle.Location = new System.Drawing.Point(6, 219);
			this.decodeTitle.Name = "decodeTitle";
			this.decodeTitle.Size = new System.Drawing.Size(73, 23);
			this.decodeTitle.TabIndex = 25;
			this.decodeTitle.Text = "Decode";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(13, 248);
			this.textBox1.Margin = new System.Windows.Forms.Padding(8);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(889, 22);
			this.textBox1.TabIndex = 24;
			this.textBox1.Text = "1011001001 101011001 101001011 101100101 110101001 101101001 1101101011 110100101 101011001 1001001011";
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(9, 73);
			this.btnCreate.Margin = new System.Windows.Forms.Padding(8);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(111, 28);
			this.btnCreate.TabIndex = 15;
			this.btnCreate.Text = "Create Barcode";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
			// 
			// txtBarcode
			// 
			this.txtBarcode.Location = new System.Drawing.Point(9, 31);
			this.txtBarcode.Margin = new System.Windows.Forms.Padding(8);
			this.txtBarcode.Multiline = true;
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.Size = new System.Drawing.Size(226, 26);
			this.txtBarcode.TabIndex = 13;
			this.txtBarcode.Text = "A12$54/9C";
			this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
			// 
			// lblHeader
			// 
			this.lblHeader.BackColor = System.Drawing.Color.Black;
			this.lblHeader.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHeader.ForeColor = System.Drawing.Color.White;
			this.lblHeader.Location = new System.Drawing.Point(0, 0);
			this.lblHeader.Name = "lblHeader";
			this.lblHeader.Padding = new System.Windows.Forms.Padding(8);
			this.lblHeader.Size = new System.Drawing.Size(170, 37);
			this.lblHeader.TabIndex = 26;
			this.lblHeader.Text = "Barcode Generator";
			this.lblHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblHeader_MouseDown);
			// 
			// title
			// 
			this.title.AutoSize = true;
			this.title.Font = new System.Drawing.Font("Tahoma", 24F);
			this.title.Location = new System.Drawing.Point(261, 40);
			this.title.Name = "title";
			this.title.Size = new System.Drawing.Size(231, 39);
			this.title.TabIndex = 28;
			this.title.Text = "Codabar Barcode";
			// 
			// encodeResulttext
			// 
			this.encodeResulttext.Location = new System.Drawing.Point(11, 189);
			this.encodeResulttext.Margin = new System.Windows.Forms.Padding(8);
			this.encodeResulttext.Multiline = true;
			this.encodeResulttext.Name = "encodeResulttext";
			this.encodeResulttext.Size = new System.Drawing.Size(889, 22);
			this.encodeResulttext.TabIndex = 31;
			this.encodeResulttext.Text = "Encode result";
			this.encodeResulttext.TextChanged += new System.EventHandler(this.encodeResultresult_TextChanged);
			// 
			// frmBarcodeGenerator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(933, 469);
			this.Controls.Add(this.title);
			this.Controls.Add(this.lblHeader);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmBarcodeGenerator";
			this.Text = "frmBarcodeGenerator";
			this.Load += new System.EventHandler(this.FrmBarcodeGenerator_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbBarcode)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.PictureBox pbBarcode;
        private System.Windows.Forms.Label lblHeader;
		private System.Windows.Forms.Label decodeTitle;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label decodeResult;
		private System.Windows.Forms.Label title;
		private System.Windows.Forms.Label encodeTitle;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.TextBox encodeResulttext;
	}
}