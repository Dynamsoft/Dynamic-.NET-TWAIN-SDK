namespace ShowInfoAndSaveImage
{
    partial class Form1
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edtFrameNumber = new System.Windows.Forms.TextBox();
            this.edtPageNumber = new System.Windows.Forms.TextBox();
            this.edtDocNumber = new System.Windows.Forms.TextBox();
            this.edtFrameBottom = new System.Windows.Forms.TextBox();
            this.edtFrameRight = new System.Windows.Forms.TextBox();
            this.edtFrameTop = new System.Windows.Forms.TextBox();
            this.edtFrameLeft = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edtBitsPerPixel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.edtPixelType = new System.Windows.Forms.TextBox();
            this.edtLength = new System.Windows.Forms.TextBox();
            this.edtWidth = new System.Windows.Forms.TextBox();
            this.edtYResolution = new System.Windows.Forms.TextBox();
            this.edtXResolution = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.BMPradio = new System.Windows.Forms.RadioButton();
            this.JPEGradio = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFileSize = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.MultiPDF = new System.Windows.Forms.CheckBox();
            this.MultiTIFF = new System.Windows.Forms.CheckBox();
            this.PDFradio = new System.Windows.Forms.RadioButton();
            this.TIFFradio = new System.Windows.Forms.RadioButton();
            this.PNGradio = new System.Windows.Forms.RadioButton();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dlgFileSave = new System.Windows.Forms.SaveFileDialog();
            this.dsViewer1 = new Dynamsoft.Forms.DSViewer();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.edtFrameNumber);
            this.groupBox2.Controls.Add(this.edtPageNumber);
            this.groupBox2.Controls.Add(this.edtDocNumber);
            this.groupBox2.Controls.Add(this.edtFrameBottom);
            this.groupBox2.Controls.Add(this.edtFrameRight);
            this.groupBox2.Controls.Add(this.edtFrameTop);
            this.groupBox2.Controls.Add(this.edtFrameLeft);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(267, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 163);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image Layout Info";
            // 
            // edtFrameNumber
            // 
            this.edtFrameNumber.Location = new System.Drawing.Point(128, 128);
            this.edtFrameNumber.Name = "edtFrameNumber";
            this.edtFrameNumber.ReadOnly = true;
            this.edtFrameNumber.Size = new System.Drawing.Size(43, 20);
            this.edtFrameNumber.TabIndex = 13;
            // 
            // edtPageNumber
            // 
            this.edtPageNumber.Location = new System.Drawing.Point(273, 94);
            this.edtPageNumber.Name = "edtPageNumber";
            this.edtPageNumber.ReadOnly = true;
            this.edtPageNumber.Size = new System.Drawing.Size(43, 20);
            this.edtPageNumber.TabIndex = 12;
            // 
            // edtDocNumber
            // 
            this.edtDocNumber.Location = new System.Drawing.Point(128, 94);
            this.edtDocNumber.Name = "edtDocNumber";
            this.edtDocNumber.ReadOnly = true;
            this.edtDocNumber.Size = new System.Drawing.Size(43, 20);
            this.edtDocNumber.TabIndex = 11;
            // 
            // edtFrameBottom
            // 
            this.edtFrameBottom.Location = new System.Drawing.Point(273, 60);
            this.edtFrameBottom.Name = "edtFrameBottom";
            this.edtFrameBottom.ReadOnly = true;
            this.edtFrameBottom.Size = new System.Drawing.Size(43, 20);
            this.edtFrameBottom.TabIndex = 10;
            // 
            // edtFrameRight
            // 
            this.edtFrameRight.Location = new System.Drawing.Point(128, 60);
            this.edtFrameRight.Name = "edtFrameRight";
            this.edtFrameRight.ReadOnly = true;
            this.edtFrameRight.Size = new System.Drawing.Size(43, 20);
            this.edtFrameRight.TabIndex = 9;
            // 
            // edtFrameTop
            // 
            this.edtFrameTop.Location = new System.Drawing.Point(273, 26);
            this.edtFrameTop.Name = "edtFrameTop";
            this.edtFrameTop.ReadOnly = true;
            this.edtFrameTop.Size = new System.Drawing.Size(43, 20);
            this.edtFrameTop.TabIndex = 8;
            // 
            // edtFrameLeft
            // 
            this.edtFrameLeft.Location = new System.Drawing.Point(128, 26);
            this.edtFrameLeft.Name = "edtFrameLeft";
            this.edtFrameLeft.ReadOnly = true;
            this.edtFrameLeft.Size = new System.Drawing.Size(43, 20);
            this.edtFrameLeft.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(34, 128);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label13.Size = new System.Drawing.Size(94, 18);
            this.label13.TabIndex = 6;
            this.label13.Text = "Frame Number:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(179, 94);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label12.Size = new System.Drawing.Size(85, 17);
            this.label12.TabIndex = 5;
            this.label12.Text = "Page Number:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(17, 94);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label11.Size = new System.Drawing.Size(111, 17);
            this.label11.TabIndex = 4;
            this.label11.Text = "Document Number:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(187, 60);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label10.Size = new System.Drawing.Size(86, 17);
            this.label10.TabIndex = 3;
            this.label10.Text = "Frame Bottom:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(51, 60);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label9.Size = new System.Drawing.Size(77, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Frame Right:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(197, 26);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Frame Top:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(60, 26);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Frame Left:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edtBitsPerPixel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.edtPixelType);
            this.groupBox1.Controls.Add(this.edtLength);
            this.groupBox1.Controls.Add(this.edtWidth);
            this.groupBox1.Controls.Add(this.edtYResolution);
            this.groupBox1.Controls.Add(this.edtXResolution);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(267, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 125);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Info";
            // 
            // edtBitsPerPixel
            // 
            this.edtBitsPerPixel.Location = new System.Drawing.Point(128, 94);
            this.edtBitsPerPixel.Name = "edtBitsPerPixel";
            this.edtBitsPerPixel.ReadOnly = true;
            this.edtBitsPerPixel.Size = new System.Drawing.Size(43, 20);
            this.edtBitsPerPixel.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(197, 94);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Pixel Type:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(42, 94);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Bits Per Pixel:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(213, 60);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Length:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(85, 60);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Width:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtPixelType
            // 
            this.edtPixelType.Location = new System.Drawing.Point(273, 94);
            this.edtPixelType.Name = "edtPixelType";
            this.edtPixelType.ReadOnly = true;
            this.edtPixelType.Size = new System.Drawing.Size(43, 20);
            this.edtPixelType.TabIndex = 7;
            // 
            // edtLength
            // 
            this.edtLength.Location = new System.Drawing.Point(273, 60);
            this.edtLength.Name = "edtLength";
            this.edtLength.ReadOnly = true;
            this.edtLength.Size = new System.Drawing.Size(43, 20);
            this.edtLength.TabIndex = 5;
            // 
            // edtWidth
            // 
            this.edtWidth.Location = new System.Drawing.Point(128, 60);
            this.edtWidth.Name = "edtWidth";
            this.edtWidth.ReadOnly = true;
            this.edtWidth.Size = new System.Drawing.Size(43, 20);
            this.edtWidth.TabIndex = 4;
            // 
            // edtYResolution
            // 
            this.edtYResolution.Location = new System.Drawing.Point(273, 26);
            this.edtYResolution.Name = "edtYResolution";
            this.edtYResolution.ReadOnly = true;
            this.edtYResolution.Size = new System.Drawing.Size(43, 20);
            this.edtYResolution.TabIndex = 3;
            // 
            // edtXResolution
            // 
            this.edtXResolution.Location = new System.Drawing.Point(128, 26);
            this.edtXResolution.Name = "edtXResolution";
            this.edtXResolution.ReadOnly = true;
            this.edtXResolution.Size = new System.Drawing.Size(43, 20);
            this.edtXResolution.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(187, 26);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y Resolution:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(51, 26);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "X Resolution:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(567, 321);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(65, 24);
            this.btnScan.TabIndex = 6;
            this.btnScan.Text = "Scan";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // BMPradio
            // 
            this.BMPradio.AutoSize = true;
            this.BMPradio.Location = new System.Drawing.Point(20, 29);
            this.BMPradio.Name = "BMPradio";
            this.BMPradio.Size = new System.Drawing.Size(48, 17);
            this.BMPradio.TabIndex = 0;
            this.BMPradio.TabStop = true;
            this.BMPradio.Text = "BMP";
            this.BMPradio.UseVisualStyleBackColor = true;
            this.BMPradio.CheckedChanged += new System.EventHandler(this.BMPradio_CheckedChanged);
            // 
            // JPEGradio
            // 
            this.JPEGradio.AutoSize = true;
            this.JPEGradio.Location = new System.Drawing.Point(74, 29);
            this.JPEGradio.Name = "JPEGradio";
            this.JPEGradio.Size = new System.Drawing.Size(52, 17);
            this.JPEGradio.TabIndex = 1;
            this.JPEGradio.TabStop = true;
            this.JPEGradio.Text = "JPEG";
            this.JPEGradio.UseVisualStyleBackColor = true;
            this.JPEGradio.CheckedChanged += new System.EventHandler(this.JPEGradio_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFileSize);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.MultiPDF);
            this.groupBox3.Controls.Add(this.MultiTIFF);
            this.groupBox3.Controls.Add(this.PDFradio);
            this.groupBox3.Controls.Add(this.TIFFradio);
            this.groupBox3.Controls.Add(this.PNGradio);
            this.groupBox3.Controls.Add(this.JPEGradio);
            this.groupBox3.Controls.Add(this.BMPradio);
            this.groupBox3.Location = new System.Drawing.Point(267, 311);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(294, 137);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Save Images";
            // 
            // txtFileSize
            // 
            this.txtFileSize.Location = new System.Drawing.Point(165, 103);
            this.txtFileSize.Name = "txtFileSize";
            this.txtFileSize.ReadOnly = true;
            this.txtFileSize.Size = new System.Drawing.Size(84, 20);
            this.txtFileSize.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(50, 103);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label14.Size = new System.Drawing.Size(110, 18);
            this.label14.TabIndex = 14;
            this.label14.Text = "Current Image Size:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MultiPDF
            // 
            this.MultiPDF.AutoSize = true;
            this.MultiPDF.Enabled = false;
            this.MultiPDF.Location = new System.Drawing.Point(149, 68);
            this.MultiPDF.Name = "MultiPDF";
            this.MultiPDF.Size = new System.Drawing.Size(100, 17);
            this.MultiPDF.TabIndex = 6;
            this.MultiPDF.Text = "Multi-Page PDF";
            this.MultiPDF.UseVisualStyleBackColor = true;
            // 
            // MultiTIFF
            // 
            this.MultiTIFF.AutoSize = true;
            this.MultiTIFF.Enabled = false;
            this.MultiTIFF.Location = new System.Drawing.Point(27, 68);
            this.MultiTIFF.Name = "MultiTIFF";
            this.MultiTIFF.Size = new System.Drawing.Size(101, 17);
            this.MultiTIFF.TabIndex = 5;
            this.MultiTIFF.Text = "Multi-Page TIFF";
            this.MultiTIFF.UseVisualStyleBackColor = true;
            // 
            // PDFradio
            // 
            this.PDFradio.AutoSize = true;
            this.PDFradio.Location = new System.Drawing.Point(235, 29);
            this.PDFradio.Name = "PDFradio";
            this.PDFradio.Size = new System.Drawing.Size(46, 17);
            this.PDFradio.TabIndex = 4;
            this.PDFradio.TabStop = true;
            this.PDFradio.Text = "PDF";
            this.PDFradio.UseVisualStyleBackColor = true;
            this.PDFradio.CheckedChanged += new System.EventHandler(this.PDFradio_CheckedChanged);
            // 
            // TIFFradio
            // 
            this.TIFFradio.AutoSize = true;
            this.TIFFradio.Location = new System.Drawing.Point(182, 29);
            this.TIFFradio.Name = "TIFFradio";
            this.TIFFradio.Size = new System.Drawing.Size(47, 17);
            this.TIFFradio.TabIndex = 3;
            this.TIFFradio.TabStop = true;
            this.TIFFradio.Text = "TIFF";
            this.TIFFradio.UseVisualStyleBackColor = true;
            this.TIFFradio.CheckedChanged += new System.EventHandler(this.TIFFradio_CheckedChanged);
            // 
            // PNGradio
            // 
            this.PNGradio.AutoSize = true;
            this.PNGradio.Location = new System.Drawing.Point(132, 29);
            this.PNGradio.Name = "PNGradio";
            this.PNGradio.Size = new System.Drawing.Size(48, 17);
            this.PNGradio.TabIndex = 2;
            this.PNGradio.TabStop = true;
            this.PNGradio.Text = "PNG";
            this.PNGradio.UseVisualStyleBackColor = true;
            this.PNGradio.CheckedChanged += new System.EventHandler(this.PNGradio_CheckedChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(567, 424);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(65, 24);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(567, 372);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 24);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dsViewer1
            // 
            this.dsViewer1.Location = new System.Drawing.Point(2, 2);
            this.dsViewer1.Name = "dsViewer1";
            this.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dsViewer1.SelectionRectAspectRatio = 0;
            this.dsViewer1.Size = new System.Drawing.Size(259, 446);
            this.dsViewer1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 502);
            this.Controls.Add(this.dsViewer1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Show Image Info and Save Scanned Images";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox edtFrameNumber;
        private System.Windows.Forms.TextBox edtPageNumber;
        private System.Windows.Forms.TextBox edtDocNumber;
        private System.Windows.Forms.TextBox edtFrameBottom;
        private System.Windows.Forms.TextBox edtFrameRight;
        private System.Windows.Forms.TextBox edtFrameTop;
        private System.Windows.Forms.TextBox edtFrameLeft;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox edtBitsPerPixel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edtPixelType;
        private System.Windows.Forms.TextBox edtLength;
        private System.Windows.Forms.TextBox edtWidth;
        private System.Windows.Forms.TextBox edtYResolution;
        private System.Windows.Forms.TextBox edtXResolution;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.RadioButton BMPradio;
        private System.Windows.Forms.RadioButton JPEGradio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton PDFradio;
        private System.Windows.Forms.RadioButton TIFFradio;
        private System.Windows.Forms.RadioButton PNGradio;
        private System.Windows.Forms.TextBox txtFileSize;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox MultiPDF;
        private System.Windows.Forms.CheckBox MultiTIFF;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog dlgFileSave;
        private Dynamsoft.Forms.DSViewer dsViewer1;
    }
}

