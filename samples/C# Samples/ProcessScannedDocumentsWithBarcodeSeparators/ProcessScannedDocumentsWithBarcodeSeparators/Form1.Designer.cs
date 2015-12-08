namespace AddBarcodeDemo
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
            this.cmbBarcodeFormat = new System.Windows.Forms.ComboBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radMode1 = new System.Windows.Forms.RadioButton();
            this.radMode2 = new System.Windows.Forms.RadioButton();
            this.picMode1 = new System.Windows.Forms.PictureBox();
            this.btnRemoveAllImage = new System.Windows.Forms.Button();
            this.picMode2 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRemoveSelectedImages = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.picFAQMode1 = new System.Windows.Forms.PictureBox();
            this.picFAQMode2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFAQMode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFAQMode2)).BeginInit();
            this.SuspendLayout();
            // 
            // dynamicDotNetTwain1
            // 
            this.dynamicDotNetTwain1.AnnotationFillColor = System.Drawing.Color.White;
            this.dynamicDotNetTwain1.AnnotationPen = null;
            this.dynamicDotNetTwain1.AnnotationTextColor = System.Drawing.Color.Black;
            this.dynamicDotNetTwain1.AnnotationTextFont = null;
            this.dynamicDotNetTwain1.IfShowCancelDialogWhenImageTransfer = false;
            this.dynamicDotNetTwain1.IfShowPrintUI = false;
            this.dynamicDotNetTwain1.IfThrowException = false;
            this.dynamicDotNetTwain1.Location = new System.Drawing.Point(8, 7);
            this.dynamicDotNetTwain1.LogLevel = ((short)(0));
            this.dynamicDotNetTwain1.Name = "dynamicDotNetTwain1";
            this.dynamicDotNetTwain1.PDFMarginBottom = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginLeft = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginRight = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginTop = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFXConformance = ((uint)(0u));
            this.dynamicDotNetTwain1.ProductFamily = "Dynamic .NET TWAIN Trial (.NET Fr";
            this.dynamicDotNetTwain1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dynamicDotNetTwain1.Size = new System.Drawing.Size(353, 364);
            this.dynamicDotNetTwain1.TabIndex = 0;
            this.dynamicDotNetTwain1.Visible = false;
            this.dynamicDotNetTwain1.OnPostAllTransfers += new Dynamsoft.DotNet.TWAIN.Delegate.OnPostAllTransfersHandler(this.dynamicDotNetTwain1_OnPostAllTransfers);
            // 
            // cmbBarcodeFormat
            // 
            this.cmbBarcodeFormat.FormattingEnabled = true;
            this.cmbBarcodeFormat.Location = new System.Drawing.Point(524, 92);
            this.cmbBarcodeFormat.Name = "cmbBarcodeFormat";
            this.cmbBarcodeFormat.Size = new System.Drawing.Size(125, 21);
            this.cmbBarcodeFormat.TabIndex = 10;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(569, 14);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(83, 23);
            this.btnScan.TabIndex = 5;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(379, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barcode Format:";
            // 
            // radMode1
            // 
            this.radMode1.AutoSize = true;
            this.radMode1.Checked = true;
            this.radMode1.Location = new System.Drawing.Point(382, 126);
            this.radMode1.Name = "radMode1";
            this.radMode1.Size = new System.Drawing.Size(58, 17);
            this.radMode1.TabIndex = 4;
            this.radMode1.TabStop = true;
            this.radMode1.Text = "Mode1";
            this.radMode1.UseVisualStyleBackColor = true;
            this.radMode1.CheckedChanged += new System.EventHandler(this.radMode1_CheckedChanged);
            // 
            // radMode2
            // 
            this.radMode2.AutoSize = true;
            this.radMode2.Location = new System.Drawing.Point(530, 126);
            this.radMode2.Name = "radMode2";
            this.radMode2.Size = new System.Drawing.Size(58, 17);
            this.radMode2.TabIndex = 5;
            this.radMode2.Text = "Mode2";
            this.radMode2.UseVisualStyleBackColor = true;
            this.radMode2.CheckedChanged += new System.EventHandler(this.radMode2_CheckedChanged);
            // 
            // picMode1
            // 
            this.picMode1.Image = global::PSDWBS.Properties.Resources.Mode1_Selected;
            this.picMode1.Location = new System.Drawing.Point(382, 149);
            this.picMode1.Name = "picMode1";
            this.picMode1.Size = new System.Drawing.Size(118, 179);
            this.picMode1.TabIndex = 12;
            this.picMode1.TabStop = false;
            // 
            // btnRemoveAllImage
            // 
            this.btnRemoveAllImage.Location = new System.Drawing.Point(12, 386);
            this.btnRemoveAllImage.Name = "btnRemoveAllImage";
            this.btnRemoveAllImage.Size = new System.Drawing.Size(131, 23);
            this.btnRemoveAllImage.TabIndex = 13;
            this.btnRemoveAllImage.Text = "Remove All Images";
            this.btnRemoveAllImage.UseVisualStyleBackColor = true;
            this.btnRemoveAllImage.Click += new System.EventHandler(this.btnRemoveAllImage_Click);
            // 
            // picMode2
            // 
            this.picMode2.Image = global::PSDWBS.Properties.Resources.Mode2;
            this.picMode2.Location = new System.Drawing.Point(531, 149);
            this.picMode2.Name = "picMode2";
            this.picMode2.Size = new System.Drawing.Size(118, 179);
            this.picMode2.TabIndex = 14;
            this.picMode2.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(569, 351);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRemoveSelectedImages
            // 
            this.btnRemoveSelectedImages.Location = new System.Drawing.Point(164, 386);
            this.btnRemoveSelectedImages.Name = "btnRemoveSelectedImages";
            this.btnRemoveSelectedImages.Size = new System.Drawing.Size(141, 23);
            this.btnRemoveSelectedImages.TabIndex = 14;
            this.btnRemoveSelectedImages.Text = "Remove Selected Images";
            this.btnRemoveSelectedImages.UseVisualStyleBackColor = true;
            this.btnRemoveSelectedImages.Click += new System.EventHandler(this.btnRemoveSelectedImages_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(431, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = " Scan Documents";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(431, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = " Separation Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(434, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Save to Local";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(377, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Step 1:  ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(377, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Step 2:  ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(377, 355);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Step 3:  ";
            // 
            // picFAQMode1
            // 
            this.picFAQMode1.Image = global::PSDWBS.Properties.Resources.faq;
            this.picFAQMode1.Location = new System.Drawing.Point(446, 126);
            this.picFAQMode1.Name = "picFAQMode1";
            this.picFAQMode1.Size = new System.Drawing.Size(30, 17);
            this.picFAQMode1.TabIndex = 22;
            this.picFAQMode1.TabStop = false;
            // 
            // picFAQMode2
            // 
            this.picFAQMode2.Image = global::PSDWBS.Properties.Resources.faq;
            this.picFAQMode2.Location = new System.Drawing.Point(595, 126);
            this.picFAQMode2.Name = "picFAQMode2";
            this.picFAQMode2.Size = new System.Drawing.Size(32, 17);
            this.picFAQMode2.TabIndex = 23;
            this.picFAQMode2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Location = new System.Drawing.Point(378, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 1);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox2.Location = new System.Drawing.Point(379, 343);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 1);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PSDWBS.Properties.Resources.main_bg;
            this.ClientSize = new System.Drawing.Size(678, 425);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picFAQMode2);
            this.Controls.Add(this.picFAQMode1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picMode2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBarcodeFormat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radMode1);
            this.Controls.Add(this.btnRemoveSelectedImages);
            this.Controls.Add(this.radMode2);
            this.Controls.Add(this.btnRemoveAllImage);
            this.Controls.Add(this.picMode1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.dynamicDotNetTwain1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Process scanned documents with barcode separators";
            ((System.ComponentModel.ISupportInitialize)(this.picMode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFAQMode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFAQMode2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain dynamicDotNetTwain1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ComboBox cmbBarcodeFormat;
        private System.Windows.Forms.RadioButton radMode1;
        private System.Windows.Forms.RadioButton radMode2;
        private System.Windows.Forms.PictureBox picMode1;
        private System.Windows.Forms.Button btnRemoveAllImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRemoveSelectedImages;
        private System.Windows.Forms.PictureBox picMode2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox picFAQMode1;
        private System.Windows.Forms.PictureBox picFAQMode2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

