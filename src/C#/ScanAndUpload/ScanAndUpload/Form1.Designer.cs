namespace ScanAndUploadToDB
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
            this.txtboxErrMessage = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.chkboxIfShowUI = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtboxExtraTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.chkboxMultiPage = new System.Windows.Forms.CheckBox();
            this.rdbtnPDF = new System.Windows.Forms.RadioButton();
            this.rdbtnPNG = new System.Windows.Forms.RadioButton();
            this.rdbtnTIFF = new System.Windows.Forms.RadioButton();
            this.rdbtnJPEG = new System.Windows.Forms.RadioButton();
            this.txtboxFileName = new System.Windows.Forms.TextBox();
            this.txtboxActionPage = new System.Windows.Forms.TextBox();
            this.txtboxPwd = new System.Windows.Forms.TextBox();
            this.txtboxName = new System.Windows.Forms.TextBox();
            this.txtboxPort = new System.Windows.Forms.TextBox();
            this.txtboxServer = new System.Windows.Forms.TextBox();
            this.dynamicDotNetTwain1 = new Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtboxErrMessage);
            this.groupBox1.Location = new System.Drawing.Point(7, 400);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 108);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message";
            // 
            // txtboxErrMessage
            // 
            this.txtboxErrMessage.Location = new System.Drawing.Point(10, 19);
            this.txtboxErrMessage.Multiline = true;
            this.txtboxErrMessage.Name = "txtboxErrMessage";
            this.txtboxErrMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtboxErrMessage.Size = new System.Drawing.Size(264, 83);
            this.txtboxErrMessage.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnScan);
            this.groupBox2.Controls.Add(this.chkboxIfShowUI);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbSource);
            this.groupBox2.Location = new System.Drawing.Point(298, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 112);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Custom Scan";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(107, 64);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(150, 29);
            this.btnScan.TabIndex = 3;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // chkboxIfShowUI
            // 
            this.chkboxIfShowUI.AutoSize = true;
            this.chkboxIfShowUI.Location = new System.Drawing.Point(21, 71);
            this.chkboxIfShowUI.Name = "chkboxIfShowUI";
            this.chkboxIfShowUI.Size = new System.Drawing.Size(67, 17);
            this.chkboxIfShowUI.TabIndex = 2;
            this.chkboxIfShowUI.Text = "Show UI";
            this.chkboxIfShowUI.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Source:";
            // 
            // cmbSource
            // 
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Location = new System.Drawing.Point(86, 30);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(172, 21);
            this.cmbSource.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtboxExtraTxt);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnUpload);
            this.groupBox3.Controls.Add(this.chkboxMultiPage);
            this.groupBox3.Controls.Add(this.rdbtnPDF);
            this.groupBox3.Controls.Add(this.rdbtnPNG);
            this.groupBox3.Controls.Add(this.rdbtnTIFF);
            this.groupBox3.Controls.Add(this.rdbtnJPEG);
            this.groupBox3.Controls.Add(this.txtboxFileName);
            this.groupBox3.Controls.Add(this.txtboxActionPage);
            this.groupBox3.Controls.Add(this.txtboxPwd);
            this.groupBox3.Controls.Add(this.txtboxName);
            this.groupBox3.Controls.Add(this.txtboxPort);
            this.groupBox3.Controls.Add(this.txtboxServer);
            this.groupBox3.Location = new System.Drawing.Point(298, 141);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(268, 367);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Upload To DB";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Extra text:";
            // 
            // txtboxExtraTxt
            // 
            this.txtboxExtraTxt.Location = new System.Drawing.Point(86, 259);
            this.txtboxExtraTxt.Name = "txtboxExtraTxt";
            this.txtboxExtraTxt.Size = new System.Drawing.Size(164, 20);
            this.txtboxExtraTxt.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "File Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Action Page:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "HTTP Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "HTTP Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "HTTP Server:";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(107, 321);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(138, 30);
            this.btnUpload.TabIndex = 11;
            this.btnUpload.Text = "Upload To DB";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // chkboxMultiPage
            // 
            this.chkboxMultiPage.AutoSize = true;
            this.chkboxMultiPage.Location = new System.Drawing.Point(23, 329);
            this.chkboxMultiPage.Name = "chkboxMultiPage";
            this.chkboxMultiPage.Size = new System.Drawing.Size(76, 17);
            this.chkboxMultiPage.TabIndex = 10;
            this.chkboxMultiPage.Text = "Multi-Page";
            this.chkboxMultiPage.UseVisualStyleBackColor = true;
            // 
            // rdbtnPDF
            // 
            this.rdbtnPDF.AutoSize = true;
            this.rdbtnPDF.Location = new System.Drawing.Point(195, 299);
            this.rdbtnPDF.Name = "rdbtnPDF";
            this.rdbtnPDF.Size = new System.Drawing.Size(46, 17);
            this.rdbtnPDF.TabIndex = 9;
            this.rdbtnPDF.TabStop = true;
            this.rdbtnPDF.Text = "PDF";
            this.rdbtnPDF.UseVisualStyleBackColor = true;
            this.rdbtnPDF.CheckedChanged += new System.EventHandler(this.rdbtnPDF_CheckedChanged);
            // 
            // rdbtnPNG
            // 
            this.rdbtnPNG.AutoSize = true;
            this.rdbtnPNG.Location = new System.Drawing.Point(138, 299);
            this.rdbtnPNG.Name = "rdbtnPNG";
            this.rdbtnPNG.Size = new System.Drawing.Size(48, 17);
            this.rdbtnPNG.TabIndex = 8;
            this.rdbtnPNG.TabStop = true;
            this.rdbtnPNG.Text = "PNG";
            this.rdbtnPNG.UseVisualStyleBackColor = true;
            // 
            // rdbtnTIFF
            // 
            this.rdbtnTIFF.AutoSize = true;
            this.rdbtnTIFF.Location = new System.Drawing.Point(83, 299);
            this.rdbtnTIFF.Name = "rdbtnTIFF";
            this.rdbtnTIFF.Size = new System.Drawing.Size(47, 17);
            this.rdbtnTIFF.TabIndex = 7;
            this.rdbtnTIFF.TabStop = true;
            this.rdbtnTIFF.Text = "TIFF";
            this.rdbtnTIFF.UseVisualStyleBackColor = true;
            this.rdbtnTIFF.CheckedChanged += new System.EventHandler(this.rdbtnTIFF_CheckedChanged);
            // 
            // rdbtnJPEG
            // 
            this.rdbtnJPEG.AutoSize = true;
            this.rdbtnJPEG.Location = new System.Drawing.Point(23, 299);
            this.rdbtnJPEG.Name = "rdbtnJPEG";
            this.rdbtnJPEG.Size = new System.Drawing.Size(52, 17);
            this.rdbtnJPEG.TabIndex = 6;
            this.rdbtnJPEG.TabStop = true;
            this.rdbtnJPEG.Text = "JPEG";
            this.rdbtnJPEG.UseVisualStyleBackColor = true;
            // 
            // txtboxFileName
            // 
            this.txtboxFileName.Location = new System.Drawing.Point(87, 219);
            this.txtboxFileName.Name = "txtboxFileName";
            this.txtboxFileName.Size = new System.Drawing.Size(164, 20);
            this.txtboxFileName.TabIndex = 5;
            // 
            // txtboxActionPage
            // 
            this.txtboxActionPage.Location = new System.Drawing.Point(87, 182);
            this.txtboxActionPage.Name = "txtboxActionPage";
            this.txtboxActionPage.Size = new System.Drawing.Size(165, 20);
            this.txtboxActionPage.TabIndex = 4;
            // 
            // txtboxPwd
            // 
            this.txtboxPwd.Location = new System.Drawing.Point(87, 144);
            this.txtboxPwd.Name = "txtboxPwd";
            this.txtboxPwd.Size = new System.Drawing.Size(166, 20);
            this.txtboxPwd.TabIndex = 3;
            // 
            // txtboxName
            // 
            this.txtboxName.Location = new System.Drawing.Point(87, 109);
            this.txtboxName.Name = "txtboxName";
            this.txtboxName.Size = new System.Drawing.Size(167, 20);
            this.txtboxName.TabIndex = 2;
            // 
            // txtboxPort
            // 
            this.txtboxPort.Location = new System.Drawing.Point(87, 71);
            this.txtboxPort.Name = "txtboxPort";
            this.txtboxPort.Size = new System.Drawing.Size(168, 20);
            this.txtboxPort.TabIndex = 1;
            // 
            // txtboxServer
            // 
            this.txtboxServer.Location = new System.Drawing.Point(87, 32);
            this.txtboxServer.Name = "txtboxServer";
            this.txtboxServer.Size = new System.Drawing.Size(169, 20);
            this.txtboxServer.TabIndex = 0;
            // 
            // dynamicDotNetTwain1
            // 
            this.dynamicDotNetTwain1.AnnotationFillColor = System.Drawing.Color.White;
            this.dynamicDotNetTwain1.AnnotationPen = null;
            this.dynamicDotNetTwain1.AnnotationTextColor = System.Drawing.Color.Black;
            this.dynamicDotNetTwain1.AnnotationTextFont = null;
            this.dynamicDotNetTwain1.IfShowPrintUI = false;
            this.dynamicDotNetTwain1.IfThrowException = false;
            this.dynamicDotNetTwain1.Location = new System.Drawing.Point(8, 8);
            this.dynamicDotNetTwain1.LogLevel = ((short)(0));
            this.dynamicDotNetTwain1.Name = "dynamicDotNetTwain1";
            this.dynamicDotNetTwain1.PDFMarginBottom = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginLeft = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginRight = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginTop = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFXConformance = ((uint)(0u));
            this.dynamicDotNetTwain1.Size = new System.Drawing.Size(282, 386);
            this.dynamicDotNetTwain1.TabIndex = 4;
            this.dynamicDotNetTwain1.OnMouseClick += new Dynamsoft.DotNet.TWAIN.Delegate.OnMouseClickHandler(this.dynamicDotNetTwain1_OnMouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 516);
            this.Controls.Add(this.dynamicDotNetTwain1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Scan and Upload";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtboxErrMessage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.CheckBox chkboxIfShowUI;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbtnPNG;
        private System.Windows.Forms.RadioButton rdbtnTIFF;
        private System.Windows.Forms.RadioButton rdbtnJPEG;
        private System.Windows.Forms.TextBox txtboxFileName;
        private System.Windows.Forms.TextBox txtboxActionPage;
        private System.Windows.Forms.TextBox txtboxPwd;
        private System.Windows.Forms.TextBox txtboxName;
        private System.Windows.Forms.TextBox txtboxPort;
        private System.Windows.Forms.TextBox txtboxServer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.CheckBox chkboxMultiPage;
        private System.Windows.Forms.RadioButton rdbtnPDF;
        private Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain dynamicDotNetTwain1;
        private System.Windows.Forms.TextBox txtboxExtraTxt;
        private System.Windows.Forms.Label label8;
    }
}

