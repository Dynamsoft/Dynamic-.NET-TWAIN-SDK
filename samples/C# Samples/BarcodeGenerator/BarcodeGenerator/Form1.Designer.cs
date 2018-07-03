namespace BarcodeGenerator
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCreateBarcode = new System.Windows.Forms.Button();
            this.labMsg = new System.Windows.Forms.Label();
            this.cmbBarcodeFormat = new System.Windows.Forms.ComboBox();
            this.btnAddBarcode = new System.Windows.Forms.Button();
            this.txtBarcodeScale = new System.Windows.Forms.TextBox();
            this.txtHumanReadableTxt = new System.Windows.Forms.TextBox();
            this.txtBarcodeContent = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBarocdeLocationY = new System.Windows.Forms.TextBox();
            this.txtBarcodeLocationX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labmsg2 = new System.Windows.Forms.Label();
            this.chbMultiPagePDF = new System.Windows.Forms.CheckBox();
            this.chbMultiPageTIFF = new System.Windows.Forms.CheckBox();
            this.rdbPDF = new System.Windows.Forms.RadioButton();
            this.rdbTIFF = new System.Windows.Forms.RadioButton();
            this.rdbPNG = new System.Windows.Forms.RadioButton();
            this.rdbJPEG = new System.Windows.Forms.RadioButton();
            this.rdbBMP = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.dsViewer1 = new Dynamsoft.Forms.DSViewer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoadImage);
            this.groupBox1.Location = new System.Drawing.Point(345, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 65);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Open Image";
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(83, 24);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(103, 25);
            this.btnLoadImage.TabIndex = 0;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCreateBarcode);
            this.groupBox2.Controls.Add(this.labMsg);
            this.groupBox2.Controls.Add(this.cmbBarcodeFormat);
            this.groupBox2.Controls.Add(this.btnAddBarcode);
            this.groupBox2.Controls.Add(this.txtBarcodeScale);
            this.groupBox2.Controls.Add(this.txtHumanReadableTxt);
            this.groupBox2.Controls.Add(this.txtBarcodeContent);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(345, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 240);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Barcode";
            // 
            // btnCreateBarcode
            // 
            this.btnCreateBarcode.Location = new System.Drawing.Point(147, 193);
            this.btnCreateBarcode.Name = "btnCreateBarcode";
            this.btnCreateBarcode.Size = new System.Drawing.Size(103, 25);
            this.btnCreateBarcode.TabIndex = 12;
            this.btnCreateBarcode.Text = "Create Barcode";
            this.btnCreateBarcode.UseVisualStyleBackColor = true;
            this.btnCreateBarcode.Click += new System.EventHandler(this.btnCreateBarcode_Click);
            // 
            // labMsg
            // 
            this.labMsg.AutoSize = true;
            this.labMsg.Location = new System.Drawing.Point(62, 221);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(0, 13);
            this.labMsg.TabIndex = 11;
            // 
            // cmbBarcodeFormat
            // 
            this.cmbBarcodeFormat.FormattingEnabled = true;
            this.cmbBarcodeFormat.Location = new System.Drawing.Point(98, 23);
            this.cmbBarcodeFormat.Name = "cmbBarcodeFormat";
            this.cmbBarcodeFormat.Size = new System.Drawing.Size(162, 21);
            this.cmbBarcodeFormat.TabIndex = 10;
            this.cmbBarcodeFormat.SelectedIndexChanged += new System.EventHandler(this.cmbBarcodeFormat_SelectedIndexChanged);
            // 
            // btnAddBarcode
            // 
            this.btnAddBarcode.Location = new System.Drawing.Point(21, 193);
            this.btnAddBarcode.Name = "btnAddBarcode";
            this.btnAddBarcode.Size = new System.Drawing.Size(103, 25);
            this.btnAddBarcode.TabIndex = 5;
            this.btnAddBarcode.Text = "Add Barcode";
            this.btnAddBarcode.UseVisualStyleBackColor = true;
            this.btnAddBarcode.Click += new System.EventHandler(this.btnAddBarcode_Click);
            // 
            // txtBarcodeScale
            // 
            this.txtBarcodeScale.Location = new System.Drawing.Point(127, 164);
            this.txtBarcodeScale.Name = "txtBarcodeScale";
            this.txtBarcodeScale.Size = new System.Drawing.Size(133, 20);
            this.txtBarcodeScale.TabIndex = 9;
            // 
            // txtHumanReadableTxt
            // 
            this.txtHumanReadableTxt.Location = new System.Drawing.Point(127, 138);
            this.txtHumanReadableTxt.Name = "txtHumanReadableTxt";
            this.txtHumanReadableTxt.Size = new System.Drawing.Size(133, 20);
            this.txtHumanReadableTxt.TabIndex = 8;
            // 
            // txtBarcodeContent
            // 
            this.txtBarcodeContent.Location = new System.Drawing.Point(98, 52);
            this.txtBarcodeContent.Name = "txtBarcodeContent";
            this.txtBarcodeContent.Size = new System.Drawing.Size(162, 20);
            this.txtBarcodeContent.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Barcode Scale:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Human Readable Text:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBarocdeLocationY);
            this.groupBox3.Controls.Add(this.txtBarcodeLocationX);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(6, 78);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(254, 51);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Barcode Location";
            // 
            // txtBarocdeLocationY
            // 
            this.txtBarocdeLocationY.Location = new System.Drawing.Point(153, 20);
            this.txtBarocdeLocationY.Name = "txtBarocdeLocationY";
            this.txtBarocdeLocationY.Size = new System.Drawing.Size(73, 20);
            this.txtBarocdeLocationY.TabIndex = 3;
            // 
            // txtBarcodeLocationX
            // 
            this.txtBarcodeLocationX.Location = new System.Drawing.Point(32, 20);
            this.txtBarcodeLocationX.Name = "txtBarcodeLocationX";
            this.txtBarcodeLocationX.Size = new System.Drawing.Size(73, 20);
            this.txtBarcodeLocationX.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Barcode Content:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barcode Format:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(83, 81);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 25);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labmsg2);
            this.groupBox4.Controls.Add(this.btnSave);
            this.groupBox4.Controls.Add(this.chbMultiPagePDF);
            this.groupBox4.Controls.Add(this.chbMultiPageTIFF);
            this.groupBox4.Controls.Add(this.rdbPDF);
            this.groupBox4.Controls.Add(this.rdbTIFF);
            this.groupBox4.Controls.Add(this.rdbPNG);
            this.groupBox4.Controls.Add(this.rdbJPEG);
            this.groupBox4.Controls.Add(this.rdbBMP);
            this.groupBox4.Location = new System.Drawing.Point(345, 319);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 136);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Save Images";
            // 
            // labmsg2
            // 
            this.labmsg2.AutoSize = true;
            this.labmsg2.Location = new System.Drawing.Point(65, 108);
            this.labmsg2.Name = "labmsg2";
            this.labmsg2.Size = new System.Drawing.Size(0, 13);
            this.labmsg2.TabIndex = 8;
            // 
            // chbMultiPagePDF
            // 
            this.chbMultiPagePDF.AutoSize = true;
            this.chbMultiPagePDF.Location = new System.Drawing.Point(147, 49);
            this.chbMultiPagePDF.Name = "chbMultiPagePDF";
            this.chbMultiPagePDF.Size = new System.Drawing.Size(100, 17);
            this.chbMultiPagePDF.TabIndex = 6;
            this.chbMultiPagePDF.Text = "Multi-Page PDF";
            this.chbMultiPagePDF.UseVisualStyleBackColor = true;
            // 
            // chbMultiPageTIFF
            // 
            this.chbMultiPageTIFF.AutoSize = true;
            this.chbMultiPageTIFF.Location = new System.Drawing.Point(29, 49);
            this.chbMultiPageTIFF.Name = "chbMultiPageTIFF";
            this.chbMultiPageTIFF.Size = new System.Drawing.Size(101, 17);
            this.chbMultiPageTIFF.TabIndex = 5;
            this.chbMultiPageTIFF.Text = "Multi-Page TIFF";
            this.chbMultiPageTIFF.UseVisualStyleBackColor = true;
            // 
            // rdbPDF
            // 
            this.rdbPDF.AutoSize = true;
            this.rdbPDF.Location = new System.Drawing.Point(220, 23);
            this.rdbPDF.Name = "rdbPDF";
            this.rdbPDF.Size = new System.Drawing.Size(46, 17);
            this.rdbPDF.TabIndex = 4;
            this.rdbPDF.TabStop = true;
            this.rdbPDF.Text = "PDF";
            this.rdbPDF.UseVisualStyleBackColor = true;
            this.rdbPDF.Click += new System.EventHandler(this.rdbPDF_CheckedChanged);
            // 
            // rdbTIFF
            // 
            this.rdbTIFF.AutoSize = true;
            this.rdbTIFF.Location = new System.Drawing.Point(168, 22);
            this.rdbTIFF.Name = "rdbTIFF";
            this.rdbTIFF.Size = new System.Drawing.Size(47, 17);
            this.rdbTIFF.TabIndex = 3;
            this.rdbTIFF.TabStop = true;
            this.rdbTIFF.Text = "TIFF";
            this.rdbTIFF.UseVisualStyleBackColor = true;
            this.rdbTIFF.Click += new System.EventHandler(this.rdbTIFF_CheckedChanged);
            // 
            // rdbPNG
            // 
            this.rdbPNG.AutoSize = true;
            this.rdbPNG.Location = new System.Drawing.Point(115, 22);
            this.rdbPNG.Name = "rdbPNG";
            this.rdbPNG.Size = new System.Drawing.Size(48, 17);
            this.rdbPNG.TabIndex = 2;
            this.rdbPNG.TabStop = true;
            this.rdbPNG.Text = "PNG";
            this.rdbPNG.UseVisualStyleBackColor = true;
            this.rdbPNG.Click += new System.EventHandler(this.rdbPNG_CheckedChanged);
            // 
            // rdbJPEG
            // 
            this.rdbJPEG.AutoSize = true;
            this.rdbJPEG.Location = new System.Drawing.Point(60, 22);
            this.rdbJPEG.Name = "rdbJPEG";
            this.rdbJPEG.Size = new System.Drawing.Size(52, 17);
            this.rdbJPEG.TabIndex = 1;
            this.rdbJPEG.TabStop = true;
            this.rdbJPEG.Text = "JPEG";
            this.rdbJPEG.UseVisualStyleBackColor = true;
            this.rdbJPEG.Click += new System.EventHandler(this.rdbJPEG_CheckedChanged);
            // 
            // rdbBMP
            // 
            this.rdbBMP.AutoSize = true;
            this.rdbBMP.Location = new System.Drawing.Point(11, 22);
            this.rdbBMP.Name = "rdbBMP";
            this.rdbBMP.Size = new System.Drawing.Size(48, 17);
            this.rdbBMP.TabIndex = 0;
            this.rdbBMP.TabStop = true;
            this.rdbBMP.Text = "BMP";
            this.rdbBMP.UseVisualStyleBackColor = true;
            this.rdbBMP.Click += new System.EventHandler(this.rdbBMP_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(330, 459);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(237, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Note: PDF library is used when loading PDF files.";
            // 
            // dsViewer1
            // 
            this.dsViewer1.Location = new System.Drawing.Point(12, 12);
            this.dsViewer1.Name = "dsViewer1";
            this.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dsViewer1.SelectionRectAspectRatio = 0D;
            this.dsViewer1.Size = new System.Drawing.Size(327, 443);
            this.dsViewer1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 474);
            this.Controls.Add(this.dsViewer1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Barcode Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarcodeScale;
        private System.Windows.Forms.TextBox txtHumanReadableTxt;
        private System.Windows.Forms.TextBox txtBarcodeContent;
        private System.Windows.Forms.Button btnAddBarcode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBarocdeLocationY;
        private System.Windows.Forms.TextBox txtBarcodeLocationX;
        private System.Windows.Forms.ComboBox cmbBarcodeFormat;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chbMultiPagePDF;
        private System.Windows.Forms.CheckBox chbMultiPageTIFF;
        private System.Windows.Forms.RadioButton rdbPDF;
        private System.Windows.Forms.RadioButton rdbTIFF;
        private System.Windows.Forms.RadioButton rdbPNG;
        private System.Windows.Forms.RadioButton rdbJPEG;
        private System.Windows.Forms.RadioButton rdbBMP;
        private System.Windows.Forms.Label labMsg;
        private System.Windows.Forms.Label labmsg2;
        private System.Windows.Forms.Label label7;
        private Dynamsoft.Forms.DSViewer dsViewer1;
        private System.Windows.Forms.Button btnCreateBarcode;
    }
}

