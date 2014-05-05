namespace WebcamDemo
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.btnAcquireSource = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkIfShowUI = new System.Windows.Forms.CheckBox();
            this.btnRemoveAllImages = new System.Windows.Forms.Button();
            this.radioTwain = new System.Windows.Forms.RadioButton();
            this.radioWebCam = new System.Windows.Forms.RadioButton();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.btnSelectSource = new System.Windows.Forms.Button();
            this.chkContainer = new System.Windows.Forms.CheckBox();
            this.dynamicDotNetTwain1 = new Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain();
            this.chkIfThrowException = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAcquireSource
            // 
            this.btnAcquireSource.Location = new System.Drawing.Point(363, 45);
            this.btnAcquireSource.Name = "btnAcquireSource";
            this.btnAcquireSource.Size = new System.Drawing.Size(96, 23);
            this.btnAcquireSource.TabIndex = 1;
            this.btnAcquireSource.Text = "Acquire Source";
            this.btnAcquireSource.UseVisualStyleBackColor = true;
            this.btnAcquireSource.Click += new System.EventHandler(this.btnAcquireSource_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(492, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(242, 224);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // chkIfShowUI
            // 
            this.chkIfShowUI.AutoSize = true;
            this.chkIfShowUI.Location = new System.Drawing.Point(363, 238);
            this.chkIfShowUI.Name = "chkIfShowUI";
            this.chkIfShowUI.Size = new System.Drawing.Size(76, 17);
            this.chkIfShowUI.TabIndex = 3;
            this.chkIfShowUI.Text = "Show UI";
            this.chkIfShowUI.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAllImages
            // 
            this.btnRemoveAllImages.Location = new System.Drawing.Point(363, 198);
            this.btnRemoveAllImages.Name = "btnRemoveAllImages";
            this.btnRemoveAllImages.Size = new System.Drawing.Size(110, 23);
            this.btnRemoveAllImages.TabIndex = 4;
            this.btnRemoveAllImages.Text = "Remove All Images";
            this.btnRemoveAllImages.UseVisualStyleBackColor = true;
            this.btnRemoveAllImages.Click += new System.EventHandler(this.btnRemoveAllImages_Click);
            // 
            // radioTwain
            // 
            this.radioTwain.AutoSize = true;
            this.radioTwain.Location = new System.Drawing.Point(363, 85);
            this.radioTwain.Name = "radioTwain";
            this.radioTwain.Size = new System.Drawing.Size(91, 17);
            this.radioTwain.TabIndex = 5;
            this.radioTwain.TabStop = true;
            this.radioTwain.Text = "Twain Source";
            this.radioTwain.UseVisualStyleBackColor = true;
            this.radioTwain.CheckedChanged += new System.EventHandler(this.radioTwain_CheckedChanged);
            // 
            // radioWebCam
            // 
            this.radioWebCam.AutoSize = true;
            this.radioWebCam.Location = new System.Drawing.Point(363, 121);
            this.radioWebCam.Name = "radioWebCam";
            this.radioWebCam.Size = new System.Drawing.Size(106, 17);
            this.radioWebCam.TabIndex = 6;
            this.radioWebCam.TabStop = true;
            this.radioWebCam.Text = "WebCam Source";
            this.radioWebCam.UseVisualStyleBackColor = true;
            this.radioWebCam.CheckedChanged += new System.EventHandler(this.radioWebCam_CheckedChanged);
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Location = new System.Drawing.Point(363, 157);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(73, 17);
            this.radioAll.TabIndex = 7;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "All Source";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.CheckedChanged += new System.EventHandler(this.radioAll_CheckedChanged);
            // 
            // btnSelectSource
            // 
            this.btnSelectSource.Location = new System.Drawing.Point(363, 13);
            this.btnSelectSource.Name = "btnSelectSource";
            this.btnSelectSource.Size = new System.Drawing.Size(96, 23);
            this.btnSelectSource.TabIndex = 8;
            this.btnSelectSource.Text = "Select Source";
            this.btnSelectSource.UseVisualStyleBackColor = true;
            this.btnSelectSource.Click += new System.EventHandler(this.btnSelectSource_Click);
            // 
            // chkContainer
            // 
            this.chkContainer.AutoSize = true;
            this.chkContainer.Location = new System.Drawing.Point(363, 261);
            this.chkContainer.Name = "chkContainer";
            this.chkContainer.Size = new System.Drawing.Size(120, 17);
            this.chkContainer.TabIndex = 10;
            this.chkContainer.Text = "Set Video Container";
            this.chkContainer.UseVisualStyleBackColor = true;
            // 
            // dynamicDotNetTwain1
            // 
            this.dynamicDotNetTwain1.AnnotationFillColor = System.Drawing.Color.White;
            this.dynamicDotNetTwain1.AnnotationPen = null;
            this.dynamicDotNetTwain1.AnnotationTextColor = System.Drawing.Color.Black;
            this.dynamicDotNetTwain1.AnnotationTextFont = null;
            this.dynamicDotNetTwain1.IfShowPrintUI = false;
            this.dynamicDotNetTwain1.Location = new System.Drawing.Point(12, 12);
            this.dynamicDotNetTwain1.LogLevel = ((short)(1));
            this.dynamicDotNetTwain1.Name = "dynamicDotNetTwain1";
            this.dynamicDotNetTwain1.PDFMarginBottom = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginLeft = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginRight = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginTop = ((uint)(0u));
            this.dynamicDotNetTwain1.Size = new System.Drawing.Size(327, 292);
            this.dynamicDotNetTwain1.TabIndex = 0;
            // 
            // chkIfThrowException
            // 
            this.chkIfThrowException.AutoSize = true;
            this.chkIfThrowException.Location = new System.Drawing.Point(363, 285);
            this.chkIfThrowException.Name = "chkIfThrowException";
            this.chkIfThrowException.Size = new System.Drawing.Size(115, 17);
            this.chkIfThrowException.TabIndex = 11;
            this.chkIfThrowException.Text = "Throw Exception";
            this.chkIfThrowException.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 316);
            this.Controls.Add(this.chkIfThrowException);
            this.Controls.Add(this.chkContainer);
            this.Controls.Add(this.btnSelectSource);
            this.Controls.Add(this.radioAll);
            this.Controls.Add(this.radioWebCam);
            this.Controls.Add(this.radioTwain);
            this.Controls.Add(this.btnRemoveAllImages);
            this.Controls.Add(this.chkIfShowUI);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAcquireSource);
            this.Controls.Add(this.dynamicDotNetTwain1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Webcam Demo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain dynamicDotNetTwain1;
        private System.Windows.Forms.Button btnAcquireSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkIfShowUI;
        private System.Windows.Forms.Button btnRemoveAllImages;
        private System.Windows.Forms.RadioButton radioTwain;
        private System.Windows.Forms.RadioButton radioWebCam;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.Button btnSelectSource;
        private System.Windows.Forms.CheckBox chkContainer;
        private System.Windows.Forms.CheckBox chkIfThrowException;
    }
}

