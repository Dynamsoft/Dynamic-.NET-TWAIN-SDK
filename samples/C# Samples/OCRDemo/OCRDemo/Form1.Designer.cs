namespace OCRDemo
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSelectedOCR = new System.Windows.Forms.Button();
            this.ddlResultFormat = new System.Windows.Forms.ComboBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.grpOCRResult = new System.Windows.Forms.GroupBox();
            this.btnOCRArea = new System.Windows.Forms.Button();
            this.cbxOCRLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.grpSelectedArea = new System.Windows.Forms.GroupBox();
            this.tbxTop = new System.Windows.Forms.TextBox();
            this.tbxBottom = new System.Windows.Forms.TextBox();
            this.tbxRight = new System.Windows.Forms.TextBox();
            this.tbxLeft = new System.Windows.Forms.TextBox();
            this.lblTop = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.cbxViewMode = new System.Windows.Forms.ComboBox();
            this.lblViewMode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dsViewer1 = new Dynamsoft.Forms.DSViewer();
            this.grpOCRResult.SuspendLayout();
            this.grpSelectedArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(538, 21);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(199, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load Image";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSelectedOCR
            // 
            this.btnSelectedOCR.Location = new System.Drawing.Point(9, 139);
            this.btnSelectedOCR.Name = "btnSelectedOCR";
            this.btnSelectedOCR.Size = new System.Drawing.Size(190, 23);
            this.btnSelectedOCR.TabIndex = 2;
            this.btnSelectedOCR.Text = "OCR Selected Images";
            this.btnSelectedOCR.UseVisualStyleBackColor = true;
            this.btnSelectedOCR.Click += new System.EventHandler(this.button2_Click);
            // 
            // ddlResultFormat
            // 
            this.ddlResultFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlResultFormat.FormattingEnabled = true;
            this.ddlResultFormat.Location = new System.Drawing.Point(9, 93);
            this.ddlResultFormat.Name = "ddlResultFormat";
            this.ddlResultFormat.Size = new System.Drawing.Size(192, 21);
            this.ddlResultFormat.TabIndex = 7;
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(6, 77);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(111, 13);
            this.lblFormat.TabIndex = 6;
            this.lblFormat.Text = "Ocr Result File Format";
            // 
            // grpOCRResult
            // 
            this.grpOCRResult.Controls.Add(this.btnOCRArea);
            this.grpOCRResult.Controls.Add(this.cbxOCRLanguage);
            this.grpOCRResult.Controls.Add(this.lblLanguage);
            this.grpOCRResult.Controls.Add(this.lblFormat);
            this.grpOCRResult.Controls.Add(this.ddlResultFormat);
            this.grpOCRResult.Controls.Add(this.btnSelectedOCR);
            this.grpOCRResult.Location = new System.Drawing.Point(538, 64);
            this.grpOCRResult.Name = "grpOCRResult";
            this.grpOCRResult.Size = new System.Drawing.Size(222, 309);
            this.grpOCRResult.TabIndex = 8;
            this.grpOCRResult.TabStop = false;
            this.grpOCRResult.Text = "OCR Result";
            // 
            // btnOCRArea
            // 
            this.btnOCRArea.Location = new System.Drawing.Point(6, 276);
            this.btnOCRArea.Name = "btnOCRArea";
            this.btnOCRArea.Size = new System.Drawing.Size(193, 23);
            this.btnOCRArea.TabIndex = 12;
            this.btnOCRArea.Text = "OCR Selected Area";
            this.btnOCRArea.UseVisualStyleBackColor = true;
            this.btnOCRArea.Click += new System.EventHandler(this.btnOCRArea_Click);
            // 
            // cbxOCRLanguage
            // 
            this.cbxOCRLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOCRLanguage.FormattingEnabled = true;
            this.cbxOCRLanguage.Location = new System.Drawing.Point(8, 40);
            this.cbxOCRLanguage.Name = "cbxOCRLanguage";
            this.cbxOCRLanguage.Size = new System.Drawing.Size(192, 21);
            this.cbxOCRLanguage.TabIndex = 11;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(6, 24);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(75, 13);
            this.lblLanguage.TabIndex = 10;
            this.lblLanguage.Text = "Ocr Language";
            // 
            // grpSelectedArea
            // 
            this.grpSelectedArea.Controls.Add(this.tbxTop);
            this.grpSelectedArea.Controls.Add(this.tbxBottom);
            this.grpSelectedArea.Controls.Add(this.tbxRight);
            this.grpSelectedArea.Controls.Add(this.tbxLeft);
            this.grpSelectedArea.Controls.Add(this.lblTop);
            this.grpSelectedArea.Controls.Add(this.label58);
            this.grpSelectedArea.Controls.Add(this.lblLeft);
            this.grpSelectedArea.Controls.Add(this.lblRight);
            this.grpSelectedArea.Location = new System.Drawing.Point(544, 242);
            this.grpSelectedArea.Name = "grpSelectedArea";
            this.grpSelectedArea.Size = new System.Drawing.Size(210, 79);
            this.grpSelectedArea.TabIndex = 20;
            this.grpSelectedArea.TabStop = false;
            this.grpSelectedArea.Text = "Selected Rectangle Area Of the Image";
            // 
            // tbxTop
            // 
            this.tbxTop.Location = new System.Drawing.Point(144, 24);
            this.tbxTop.Name = "tbxTop";
            this.tbxTop.ReadOnly = true;
            this.tbxTop.Size = new System.Drawing.Size(49, 20);
            this.tbxTop.TabIndex = 21;
            this.tbxTop.Text = "0";
            // 
            // tbxBottom
            // 
            this.tbxBottom.Location = new System.Drawing.Point(144, 50);
            this.tbxBottom.Name = "tbxBottom";
            this.tbxBottom.ReadOnly = true;
            this.tbxBottom.Size = new System.Drawing.Size(49, 20);
            this.tbxBottom.TabIndex = 20;
            // 
            // tbxRight
            // 
            this.tbxRight.Location = new System.Drawing.Point(33, 50);
            this.tbxRight.Name = "tbxRight";
            this.tbxRight.ReadOnly = true;
            this.tbxRight.Size = new System.Drawing.Size(51, 20);
            this.tbxRight.TabIndex = 19;
            // 
            // tbxLeft
            // 
            this.tbxLeft.Location = new System.Drawing.Point(33, 24);
            this.tbxLeft.Name = "tbxLeft";
            this.tbxLeft.ReadOnly = true;
            this.tbxLeft.Size = new System.Drawing.Size(51, 20);
            this.tbxLeft.TabIndex = 18;
            this.tbxLeft.Text = "0";
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(99, 27);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(22, 13);
            this.lblTop.TabIndex = 17;
            this.lblTop.Text = "top";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(99, 53);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(39, 13);
            this.label58.TabIndex = 16;
            this.label58.Text = "bottom";
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Location = new System.Drawing.Point(6, 27);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(21, 13);
            this.lblLeft.TabIndex = 15;
            this.lblLeft.Text = "left";
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Location = new System.Drawing.Point(6, 53);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(27, 13);
            this.lblRight.TabIndex = 14;
            this.lblRight.Text = "right";
            // 
            // cbxViewMode
            // 
            this.cbxViewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxViewMode.FormattingEnabled = true;
            this.cbxViewMode.Items.AddRange(new object[] {
            "1 x 1",
            "2 x 2",
            "3 x 3",
            "4 x 4"});
            this.cbxViewMode.Location = new System.Drawing.Point(81, 457);
            this.cbxViewMode.Name = "cbxViewMode";
            this.cbxViewMode.Size = new System.Drawing.Size(121, 21);
            this.cbxViewMode.TabIndex = 21;
            this.cbxViewMode.SelectedIndexChanged += new System.EventHandler(this.cbxViewMode_SelectedIndexChanged);
            // 
            // lblViewMode
            // 
            this.lblViewMode.AutoSize = true;
            this.lblViewMode.Location = new System.Drawing.Point(15, 460);
            this.lblViewMode.Name = "lblViewMode";
            this.lblViewMode.Size = new System.Drawing.Size(60, 13);
            this.lblViewMode.TabIndex = 22;
            this.lblViewMode.Text = "View Mode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(470, 465);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Note: PDF library is used when loading PDF files.";
            // 
            // dsViewer1
            // 
            this.dsViewer1.Location = new System.Drawing.Point(12, 12);
            this.dsViewer1.Name = "dsViewer1";
            this.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dsViewer1.SelectionRectAspectRatio = 0D;
            this.dsViewer1.Size = new System.Drawing.Size(520, 439);
            this.dsViewer1.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 482);
            this.Controls.Add(this.dsViewer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblViewMode);
            this.Controls.Add(this.cbxViewMode);
            this.Controls.Add(this.grpSelectedArea);
            this.Controls.Add(this.grpOCRResult);
            this.Controls.Add(this.btnLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "OCR Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpOCRResult.ResumeLayout(false);
            this.grpOCRResult.PerformLayout();
            this.grpSelectedArea.ResumeLayout(false);
            this.grpSelectedArea.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSelectedOCR;
        private System.Windows.Forms.ComboBox ddlResultFormat;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.GroupBox grpOCRResult;
        private System.Windows.Forms.ComboBox cbxOCRLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.GroupBox grpSelectedArea;
        private System.Windows.Forms.TextBox tbxTop;
        private System.Windows.Forms.TextBox tbxBottom;
        private System.Windows.Forms.TextBox tbxRight;
        private System.Windows.Forms.TextBox tbxLeft;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Button btnOCRArea;
        private System.Windows.Forms.ComboBox cbxViewMode;
        private System.Windows.Forms.Label lblViewMode;
        private System.Windows.Forms.Label label1;
        private Dynamsoft.Forms.DSViewer dsViewer1;
    }
}

