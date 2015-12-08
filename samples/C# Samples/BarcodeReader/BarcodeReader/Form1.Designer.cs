namespace BarcodeDemo
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnRecognize = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.lblMaxNum = new System.Windows.Forms.Label();
            this.cbxFormat = new System.Windows.Forms.ComboBox();
            this.tbxMaxNum = new System.Windows.Forms.TextBox();
            this.gbSelectedArea = new System.Windows.Forms.GroupBox();
            this.tbxTop = new System.Windows.Forms.TextBox();
            this.tbxBottom = new System.Windows.Forms.TextBox();
            this.tbxRight = new System.Windows.Forms.TextBox();
            this.tbxLeft = new System.Windows.Forms.TextBox();
            this.lblTop = new System.Windows.Forms.Label();
            this.lblBottom = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbSelectedArea.SuspendLayout();
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
            this.dynamicDotNetTwain1.Location = new System.Drawing.Point(12, 12);
            this.dynamicDotNetTwain1.LogLevel = ((short)(0));
            this.dynamicDotNetTwain1.Name = "dynamicDotNetTwain1";
            this.dynamicDotNetTwain1.PDFMarginBottom = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginLeft = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginRight = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginTop = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFXConformance = ((uint)(0u));
            this.dynamicDotNetTwain1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dynamicDotNetTwain1.Size = new System.Drawing.Size(458, 303);
            this.dynamicDotNetTwain1.TabIndex = 0;
            this.dynamicDotNetTwain1.OnImageAreaDeselected += new Dynamsoft.DotNet.TWAIN.Delegate.OnImageAreaDeselectedHandler(this.dynamicDotNetTwain1_OnImageAreaDeselected);
            this.dynamicDotNetTwain1.OnImageAreaSelected += new Dynamsoft.DotNet.TWAIN.Delegate.OnImageAreaSelectedHandler(this.dynamicDotNetTwain1_OnImageAreaSelected);
            this.dynamicDotNetTwain1.OnPostAllTransfers += new Dynamsoft.DotNet.TWAIN.Delegate.OnPostAllTransfersHandler(this.dynamicDotNetTwain1_OnPostAllTransfers);
            this.dynamicDotNetTwain1.OnTopImageInTheViewChanged += new Dynamsoft.DotNet.TWAIN.Delegate.OnTopImageInTheViewChangedHandler(this.dynamicDotNetTwain1_OnTopImageInTheViewChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 320);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open Image";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRecognize
            // 
            this.btnRecognize.Location = new System.Drawing.Point(12, 446);
            this.btnRecognize.Name = "btnRecognize";
            this.btnRecognize.Size = new System.Drawing.Size(75, 23);
            this.btnRecognize.TabIndex = 2;
            this.btnRecognize.Text = "Recognize";
            this.btnRecognize.UseVisualStyleBackColor = true;
            this.btnRecognize.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(9, 475);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(458, 98);
            this.textBox1.TabIndex = 4;
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(12, 356);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(82, 13);
            this.lblFormat.TabIndex = 5;
            this.lblFormat.Text = "Barcode Format";
            // 
            // lblMaxNum
            // 
            this.lblMaxNum.AutoSize = true;
            this.lblMaxNum.Location = new System.Drawing.Point(253, 356);
            this.lblMaxNum.Name = "lblMaxNum";
            this.lblMaxNum.Size = new System.Drawing.Size(91, 13);
            this.lblMaxNum.TabIndex = 6;
            this.lblMaxNum.Text = "Maximum Number";
            // 
            // cbxFormat
            // 
            this.cbxFormat.FormattingEnabled = true;
            this.cbxFormat.Location = new System.Drawing.Point(100, 353);
            this.cbxFormat.Name = "cbxFormat";
            this.cbxFormat.Size = new System.Drawing.Size(121, 21);
            this.cbxFormat.TabIndex = 7;
            // 
            // tbxMaxNum
            // 
            this.tbxMaxNum.Location = new System.Drawing.Point(350, 353);
            this.tbxMaxNum.Name = "tbxMaxNum";
            this.tbxMaxNum.Size = new System.Drawing.Size(46, 20);
            this.tbxMaxNum.TabIndex = 8;
            // 
            // gbSelectedArea
            // 
            this.gbSelectedArea.Controls.Add(this.tbxTop);
            this.gbSelectedArea.Controls.Add(this.tbxBottom);
            this.gbSelectedArea.Controls.Add(this.tbxRight);
            this.gbSelectedArea.Controls.Add(this.tbxLeft);
            this.gbSelectedArea.Controls.Add(this.lblTop);
            this.gbSelectedArea.Controls.Add(this.lblBottom);
            this.gbSelectedArea.Controls.Add(this.lblLeft);
            this.gbSelectedArea.Controls.Add(this.lblRight);
            this.gbSelectedArea.Location = new System.Drawing.Point(15, 380);
            this.gbSelectedArea.Name = "gbSelectedArea";
            this.gbSelectedArea.Size = new System.Drawing.Size(455, 60);
            this.gbSelectedArea.TabIndex = 14;
            this.gbSelectedArea.TabStop = false;
            this.gbSelectedArea.Text = "Selected Rectangle Area Of the Image";
            // 
            // tbxTop
            // 
            this.tbxTop.Location = new System.Drawing.Point(267, 24);
            this.tbxTop.Name = "tbxTop";
            this.tbxTop.ReadOnly = true;
            this.tbxTop.Size = new System.Drawing.Size(52, 20);
            this.tbxTop.TabIndex = 21;
            this.tbxTop.Text = "0";
            // 
            // tbxBottom
            // 
            this.tbxBottom.Location = new System.Drawing.Point(388, 24);
            this.tbxBottom.Name = "tbxBottom";
            this.tbxBottom.ReadOnly = true;
            this.tbxBottom.Size = new System.Drawing.Size(52, 20);
            this.tbxBottom.TabIndex = 20;
            // 
            // tbxRight
            // 
            this.tbxRight.Location = new System.Drawing.Point(163, 24);
            this.tbxRight.Name = "tbxRight";
            this.tbxRight.ReadOnly = true;
            this.tbxRight.Size = new System.Drawing.Size(54, 20);
            this.tbxRight.TabIndex = 19;
            // 
            // tbxLeft
            // 
            this.tbxLeft.Location = new System.Drawing.Point(52, 24);
            this.tbxLeft.Name = "tbxLeft";
            this.tbxLeft.ReadOnly = true;
            this.tbxLeft.Size = new System.Drawing.Size(51, 20);
            this.tbxLeft.TabIndex = 18;
            this.tbxLeft.Text = "0";
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(238, 27);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(22, 13);
            this.lblTop.TabIndex = 17;
            this.lblTop.Text = "top";
            // 
            // lblBottom
            // 
            this.lblBottom.AutoSize = true;
            this.lblBottom.Location = new System.Drawing.Point(342, 27);
            this.lblBottom.Name = "lblBottom";
            this.lblBottom.Size = new System.Drawing.Size(39, 13);
            this.lblBottom.TabIndex = 16;
            this.lblBottom.Text = "bottom";
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Location = new System.Drawing.Point(15, 27);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(21, 13);
            this.lblLeft.TabIndex = 15;
            this.lblLeft.Text = "left";
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Location = new System.Drawing.Point(122, 27);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(27, 13);
            this.lblRight.TabIndex = 14;
            this.lblRight.Text = "right";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 578);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(458, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Note: PDF Rasterizer add-on is used when loading PDF files.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 600);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbSelectedArea);
            this.Controls.Add(this.tbxMaxNum);
            this.Controls.Add(this.cbxFormat);
            this.Controls.Add(this.lblMaxNum);
            this.Controls.Add(this.lblFormat);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnRecognize);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.dynamicDotNetTwain1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Barcode Reader";
            this.gbSelectedArea.ResumeLayout(false);
            this.gbSelectedArea.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain dynamicDotNetTwain1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnRecognize;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.Label lblMaxNum;
        private System.Windows.Forms.ComboBox cbxFormat;
        private System.Windows.Forms.TextBox tbxMaxNum;
        private System.Windows.Forms.GroupBox gbSelectedArea;
        private System.Windows.Forms.TextBox tbxTop;
        private System.Windows.Forms.TextBox tbxBottom;
        private System.Windows.Forms.TextBox tbxRight;
        private System.Windows.Forms.TextBox tbxLeft;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Label lblBottom;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label label1;
    }
}

