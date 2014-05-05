namespace PDFReaderDemo
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
            this.dynamicDotNetTwain1 = new Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadPDF = new System.Windows.Forms.Button();
            this.cmbPDFResolution = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labMsg = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.chbMultiPagePDF = new System.Windows.Forms.CheckBox();
            this.chbMultiPageTIFF = new System.Windows.Forms.CheckBox();
            this.rdbPDF = new System.Windows.Forms.RadioButton();
            this.rdbTIFF = new System.Windows.Forms.RadioButton();
            this.rdbPNG = new System.Windows.Forms.RadioButton();
            this.rdbJPEG = new System.Windows.Forms.RadioButton();
            this.rdbBMP = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dynamicDotNetTwain1
            // 
            this.dynamicDotNetTwain1.AnnotationFillColor = System.Drawing.Color.White;
            this.dynamicDotNetTwain1.AnnotationPen = null;
            this.dynamicDotNetTwain1.AnnotationTextColor = System.Drawing.Color.Black;
            this.dynamicDotNetTwain1.AnnotationTextFont = null;
            this.dynamicDotNetTwain1.IfShowPrintUI = false;
            this.dynamicDotNetTwain1.IfThrowException = false;
            this.dynamicDotNetTwain1.Location = new System.Drawing.Point(-1, 1);
            this.dynamicDotNetTwain1.LogLevel = ((short)(0));
            this.dynamicDotNetTwain1.Name = "dynamicDotNetTwain1";
            this.dynamicDotNetTwain1.PDFMarginBottom = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginLeft = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginRight = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginTop = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFXConformance = ((uint)(0u));
            this.dynamicDotNetTwain1.Size = new System.Drawing.Size(258, 313);
            this.dynamicDotNetTwain1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnLoadPDF);
            this.groupBox1.Controls.Add(this.cmbPDFResolution);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(267, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 115);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load a local PDF file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "(dpi)";
            // 
            // btnLoadPDF
            // 
            this.btnLoadPDF.Location = new System.Drawing.Point(68, 64);
            this.btnLoadPDF.Name = "btnLoadPDF";
            this.btnLoadPDF.Size = new System.Drawing.Size(136, 33);
            this.btnLoadPDF.TabIndex = 2;
            this.btnLoadPDF.Text = "Load PDF";
            this.btnLoadPDF.UseVisualStyleBackColor = true;
            this.btnLoadPDF.Click += new System.EventHandler(this.btnLoadPDF_Click);
            // 
            // cmbPDFResolution
            // 
            this.cmbPDFResolution.FormattingEnabled = true;
            this.cmbPDFResolution.Location = new System.Drawing.Point(119, 26);
            this.cmbPDFResolution.Name = "cmbPDFResolution";
            this.cmbPDFResolution.Size = new System.Drawing.Size(101, 21);
            this.cmbPDFResolution.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Set PDF Resolution:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labMsg);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.chbMultiPagePDF);
            this.groupBox2.Controls.Add(this.chbMultiPageTIFF);
            this.groupBox2.Controls.Add(this.rdbPDF);
            this.groupBox2.Controls.Add(this.rdbTIFF);
            this.groupBox2.Controls.Add(this.rdbPNG);
            this.groupBox2.Controls.Add(this.rdbJPEG);
            this.groupBox2.Controls.Add(this.rdbBMP);
            this.groupBox2.Location = new System.Drawing.Point(267, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 179);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Save Images";
            // 
            // labMsg
            // 
            this.labMsg.AutoSize = true;
            this.labMsg.Location = new System.Drawing.Point(75, 157);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(0, 13);
            this.labMsg.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(68, 121);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(136, 33);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chbMultiPagePDF
            // 
            this.chbMultiPagePDF.AutoSize = true;
            this.chbMultiPagePDF.Location = new System.Drawing.Point(147, 76);
            this.chbMultiPagePDF.Name = "chbMultiPagePDF";
            this.chbMultiPagePDF.Size = new System.Drawing.Size(100, 17);
            this.chbMultiPagePDF.TabIndex = 6;
            this.chbMultiPagePDF.Text = "Multi-Page PDF";
            this.chbMultiPagePDF.UseVisualStyleBackColor = true;
            // 
            // chbMultiPageTIFF
            // 
            this.chbMultiPageTIFF.AutoSize = true;
            this.chbMultiPageTIFF.Location = new System.Drawing.Point(29, 76);
            this.chbMultiPageTIFF.Name = "chbMultiPageTIFF";
            this.chbMultiPageTIFF.Size = new System.Drawing.Size(101, 17);
            this.chbMultiPageTIFF.TabIndex = 5;
            this.chbMultiPageTIFF.Text = "Multi-Page TIFF";
            this.chbMultiPageTIFF.UseVisualStyleBackColor = true;
            // 
            // rdbPDF
            // 
            this.rdbPDF.AutoSize = true;
            this.rdbPDF.Location = new System.Drawing.Point(220, 39);
            this.rdbPDF.Name = "rdbPDF";
            this.rdbPDF.Size = new System.Drawing.Size(46, 17);
            this.rdbPDF.TabIndex = 4;
            this.rdbPDF.TabStop = true;
            this.rdbPDF.Text = "PDF";
            this.rdbPDF.UseVisualStyleBackColor = true;
            this.rdbPDF.CheckedChanged += new System.EventHandler(this.rdbPDF_CheckedChanged);
            // 
            // rdbTIFF
            // 
            this.rdbTIFF.AutoSize = true;
            this.rdbTIFF.Location = new System.Drawing.Point(166, 38);
            this.rdbTIFF.Name = "rdbTIFF";
            this.rdbTIFF.Size = new System.Drawing.Size(47, 17);
            this.rdbTIFF.TabIndex = 3;
            this.rdbTIFF.TabStop = true;
            this.rdbTIFF.Text = "TIFF";
            this.rdbTIFF.UseVisualStyleBackColor = true;
            this.rdbTIFF.CheckedChanged += new System.EventHandler(this.rdbTIFF_CheckedChanged);
            // 
            // rdbPNG
            // 
            this.rdbPNG.AutoSize = true;
            this.rdbPNG.Location = new System.Drawing.Point(115, 38);
            this.rdbPNG.Name = "rdbPNG";
            this.rdbPNG.Size = new System.Drawing.Size(48, 17);
            this.rdbPNG.TabIndex = 2;
            this.rdbPNG.TabStop = true;
            this.rdbPNG.Text = "PNG";
            this.rdbPNG.UseVisualStyleBackColor = true;
            this.rdbPNG.CheckedChanged += new System.EventHandler(this.rdbPNG_CheckedChanged);
            // 
            // rdbJPEG
            // 
            this.rdbJPEG.AutoSize = true;
            this.rdbJPEG.Location = new System.Drawing.Point(60, 38);
            this.rdbJPEG.Name = "rdbJPEG";
            this.rdbJPEG.Size = new System.Drawing.Size(52, 17);
            this.rdbJPEG.TabIndex = 1;
            this.rdbJPEG.TabStop = true;
            this.rdbJPEG.Text = "JPEG";
            this.rdbJPEG.UseVisualStyleBackColor = true;
            this.rdbJPEG.CheckedChanged += new System.EventHandler(this.rdbJPEG_CheckedChanged);
            // 
            // rdbBMP
            // 
            this.rdbBMP.AutoSize = true;
            this.rdbBMP.Location = new System.Drawing.Point(11, 38);
            this.rdbBMP.Name = "rdbBMP";
            this.rdbBMP.Size = new System.Drawing.Size(48, 17);
            this.rdbBMP.TabIndex = 0;
            this.rdbBMP.TabStop = true;
            this.rdbBMP.Text = "BMP";
            this.rdbBMP.UseVisualStyleBackColor = true;
            this.rdbBMP.CheckedChanged += new System.EventHandler(this.rdbBMP_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 316);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dynamicDotNetTwain1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "PDF Rasterizer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain dynamicDotNetTwain1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLoadPDF;
        private System.Windows.Forms.ComboBox cmbPDFResolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbTIFF;
        private System.Windows.Forms.RadioButton rdbPNG;
        private System.Windows.Forms.RadioButton rdbJPEG;
        private System.Windows.Forms.RadioButton rdbBMP;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chbMultiPagePDF;
        private System.Windows.Forms.CheckBox chbMultiPageTIFF;
        private System.Windows.Forms.RadioButton rdbPDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labMsg;
    }
}

