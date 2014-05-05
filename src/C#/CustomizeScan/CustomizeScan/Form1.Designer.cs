namespace CustomizeScan
{
    partial class frmCustomizeScan
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
            this.chkDuplex = new System.Windows.Forms.CheckBox();
            this.chkIfUseADF = new System.Windows.Forms.CheckBox();
            this.chkIfShowUI = new System.Windows.Forms.CheckBox();
            this.cmbResolution = new System.Windows.Forms.ComboBox();
            this.lblResolution = new System.Windows.Forms.Label();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.lblSelectSource = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.optRGB = new System.Windows.Forms.RadioButton();
            this.optGray = new System.Windows.Forms.RadioButton();
            this.optBW = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dynamicDotNetTwain = new Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtErrorString = new System.Windows.Forms.TextBox();
            this.cmdScan = new System.Windows.Forms.Button();
            this.cmdInsert = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDuplex);
            this.groupBox1.Controls.Add(this.chkIfUseADF);
            this.groupBox1.Controls.Add(this.chkIfShowUI);
            this.groupBox1.Controls.Add(this.cmbResolution);
            this.groupBox1.Controls.Add(this.lblResolution);
            this.groupBox1.Controls.Add(this.cmbSource);
            this.groupBox1.Controls.Add(this.lblSelectSource);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(304, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom Scan";
            // 
            // chkDuplex
            // 
            this.chkDuplex.AutoSize = true;
            this.chkDuplex.Location = new System.Drawing.Point(171, 176);
            this.chkDuplex.Name = "chkDuplex";
            this.chkDuplex.Size = new System.Drawing.Size(87, 17);
            this.chkDuplex.TabIndex = 10;
            this.chkDuplex.Text = "Duplex Scan";
            this.chkDuplex.UseVisualStyleBackColor = true;
            // 
            // chkIfUseADF
            // 
            this.chkIfUseADF.AutoSize = true;
            this.chkIfUseADF.Location = new System.Drawing.Point(96, 176);
            this.chkIfUseADF.Name = "chkIfUseADF";
            this.chkIfUseADF.Size = new System.Drawing.Size(69, 17);
            this.chkIfUseADF.TabIndex = 9;
            this.chkIfUseADF.Text = "Use ADF";
            this.chkIfUseADF.UseVisualStyleBackColor = true;
            // 
            // chkIfShowUI
            // 
            this.chkIfShowUI.AutoSize = true;
            this.chkIfShowUI.Location = new System.Drawing.Point(14, 176);
            this.chkIfShowUI.Name = "chkIfShowUI";
            this.chkIfShowUI.Size = new System.Drawing.Size(76, 17);
            this.chkIfShowUI.TabIndex = 8;
            this.chkIfShowUI.Text = "Show UI";
            this.chkIfShowUI.UseVisualStyleBackColor = true;
            // 
            // cmbResolution
            // 
            this.cmbResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResolution.FormattingEnabled = true;
            this.cmbResolution.Location = new System.Drawing.Point(101, 135);
            this.cmbResolution.Name = "cmbResolution";
            this.cmbResolution.Size = new System.Drawing.Size(143, 21);
            this.cmbResolution.TabIndex = 7;
            // 
            // lblResolution
            // 
            this.lblResolution.AutoSize = true;
            this.lblResolution.Location = new System.Drawing.Point(30, 138);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(57, 13);
            this.lblResolution.TabIndex = 6;
            this.lblResolution.Text = "Resolution";
            // 
            // cmbSource
            // 
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Location = new System.Drawing.Point(101, 17);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(143, 21);
            this.cmbSource.TabIndex = 5;
            this.cmbSource.SelectedIndexChanged += new System.EventHandler(this.cmbSource_SelectedIndexChanged);
            // 
            // lblSelectSource
            // 
            this.lblSelectSource.AutoSize = true;
            this.lblSelectSource.Location = new System.Drawing.Point(30, 20);
            this.lblSelectSource.Name = "lblSelectSource";
            this.lblSelectSource.Size = new System.Drawing.Size(37, 13);
            this.lblSelectSource.TabIndex = 4;
            this.lblSelectSource.Text = "Select";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.optRGB);
            this.groupBox4.Controls.Add(this.optGray);
            this.groupBox4.Controls.Add(this.optBW);
            this.groupBox4.Location = new System.Drawing.Point(14, 56);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(244, 65);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pixel Type && Bit Depth";
            // 
            // optRGB
            // 
            this.optRGB.AutoSize = true;
            this.optRGB.Location = new System.Drawing.Point(161, 30);
            this.optRGB.Name = "optRGB";
            this.optRGB.Size = new System.Drawing.Size(77, 17);
            this.optRGB.TabIndex = 2;
            this.optRGB.TabStop = true;
            this.optRGB.Text = "24-bit RGB";
            this.optRGB.UseVisualStyleBackColor = true;
            // 
            // optGray
            // 
            this.optGray.AutoSize = true;
            this.optGray.Location = new System.Drawing.Point(83, 30);
            this.optGray.Name = "optGray";
            this.optGray.Size = new System.Drawing.Size(70, 17);
            this.optGray.TabIndex = 1;
            this.optGray.TabStop = true;
            this.optGray.Text = "8-bit Gray";
            this.optGray.UseVisualStyleBackColor = true;
            // 
            // optBW
            // 
            this.optBW.AutoSize = true;
            this.optBW.Location = new System.Drawing.Point(7, 30);
            this.optBW.Name = "optBW";
            this.optBW.Size = new System.Drawing.Size(66, 17);
            this.optBW.TabIndex = 0;
            this.optBW.TabStop = true;
            this.optBW.Text = "1-bit BW";
            this.optBW.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dynamicDotNetTwain);
            this.groupBox2.Location = new System.Drawing.Point(12, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 385);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View";
            // 
            // dynamicDotNetTwain
            // 
            this.dynamicDotNetTwain.AnnotationFillColor = System.Drawing.Color.White;
            this.dynamicDotNetTwain.AnnotationPen = null;
            this.dynamicDotNetTwain.AnnotationTextColor = System.Drawing.Color.Black;
            this.dynamicDotNetTwain.AnnotationTextFont = null;
            this.dynamicDotNetTwain.IfShowPrintUI = false;
            this.dynamicDotNetTwain.IfThrowException = false;
            this.dynamicDotNetTwain.Location = new System.Drawing.Point(13, 17);
            this.dynamicDotNetTwain.LogLevel = ((short)(0));
            this.dynamicDotNetTwain.Name = "dynamicDotNetTwain";
            this.dynamicDotNetTwain.PDFMarginBottom = ((uint)(0u));
            this.dynamicDotNetTwain.PDFMarginLeft = ((uint)(0u));
            this.dynamicDotNetTwain.PDFMarginRight = ((uint)(0u));
            this.dynamicDotNetTwain.PDFMarginTop = ((uint)(0u));
            this.dynamicDotNetTwain.PDFXConformance = ((uint)(0u));
            this.dynamicDotNetTwain.Size = new System.Drawing.Size(264, 362);
            this.dynamicDotNetTwain.TabIndex = 0;
            this.dynamicDotNetTwain.OnPreAllTransfers += new Dynamsoft.DotNet.TWAIN.Delegate.OnPreAllTransfersHandler(this.dynamicDotNetTwain_OnPreAllTransfers);
            this.dynamicDotNetTwain.OnMouseClick += new Dynamsoft.DotNet.TWAIN.Delegate.OnMouseClickHandler(this.dynamicDotNetTwain_OnMouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtErrorString);
            this.groupBox3.Location = new System.Drawing.Point(304, 271);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 138);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Error String";
            // 
            // txtErrorString
            // 
            this.txtErrorString.Location = new System.Drawing.Point(14, 20);
            this.txtErrorString.Multiline = true;
            this.txtErrorString.Name = "txtErrorString";
            this.txtErrorString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrorString.Size = new System.Drawing.Size(260, 108);
            this.txtErrorString.TabIndex = 0;
            // 
            // cmdScan
            // 
            this.cmdScan.Location = new System.Drawing.Point(351, 242);
            this.cmdScan.Name = "cmdScan";
            this.cmdScan.Size = new System.Drawing.Size(75, 23);
            this.cmdScan.TabIndex = 3;
            this.cmdScan.Text = "Scan";
            this.cmdScan.UseVisualStyleBackColor = true;
            this.cmdScan.Click += new System.EventHandler(this.cmdScan_Click);
            // 
            // cmdInsert
            // 
            this.cmdInsert.Location = new System.Drawing.Point(473, 242);
            this.cmdInsert.Name = "cmdInsert";
            this.cmdInsert.Size = new System.Drawing.Size(75, 23);
            this.cmdInsert.TabIndex = 4;
            this.cmdInsert.Text = "Insert";
            this.cmdInsert.UseVisualStyleBackColor = true;
            this.cmdInsert.Click += new System.EventHandler(this.cmdInsert_Click);
            // 
            // frmCustomizeScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 433);
            this.Controls.Add(this.cmdInsert);
            this.Controls.Add(this.cmdScan);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCustomizeScan";
            this.Text = "Customize Scan";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblSelectSource;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.CheckBox chkDuplex;
        private System.Windows.Forms.CheckBox chkIfUseADF;
        private System.Windows.Forms.CheckBox chkIfShowUI;
        private System.Windows.Forms.ComboBox cmbResolution;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.RadioButton optRGB;
        private System.Windows.Forms.RadioButton optGray;
        private System.Windows.Forms.RadioButton optBW;
        private System.Windows.Forms.Button cmdScan;
        private System.Windows.Forms.Button cmdInsert;
        private System.Windows.Forms.TextBox txtErrorString;
        private Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain dynamicDotNetTwain;

    }
}

