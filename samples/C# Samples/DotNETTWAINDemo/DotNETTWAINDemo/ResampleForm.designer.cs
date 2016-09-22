namespace DotNet_TWAIN_Demo
{
    partial class ResampleForm
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.cbxConstrainProportion = new System.Windows.Forms.CheckBox();
            this.cbxHeightType = new System.Windows.Forms.ComboBox();
            this.cbxWidthType = new System.Windows.Forms.ComboBox();
            this.tbxHeight = new System.Windows.Forms.TextBox();
            this.tbxWidth = new System.Windows.Forms.TextBox();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbResampleImage = new System.Windows.Forms.Label();
            this.cbxResampleType = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.cbxConstrainProportion);
            this.groupBox.Controls.Add(this.cbxHeightType);
            this.groupBox.Controls.Add(this.cbxWidthType);
            this.groupBox.Controls.Add(this.tbxHeight);
            this.groupBox.Controls.Add(this.tbxWidth);
            this.groupBox.Controls.Add(this.lbHeight);
            this.groupBox.Controls.Add(this.lbWidth);
            this.groupBox.Location = new System.Drawing.Point(12, 23);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(260, 132);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Pixel Dimension";
            // 
            // cbxConstrainProportion
            // 
            this.cbxConstrainProportion.AutoSize = true;
            this.cbxConstrainProportion.Location = new System.Drawing.Point(20, 100);
            this.cbxConstrainProportion.Name = "cbxConstrainProportion";
            this.cbxConstrainProportion.Size = new System.Drawing.Size(121, 17);
            this.cbxConstrainProportion.TabIndex = 4;
            this.cbxConstrainProportion.Text = "Constrain Proportion";
            this.cbxConstrainProportion.UseVisualStyleBackColor = true;
            // 
            // cbxHeightType
            // 
            this.cbxHeightType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHeightType.FormattingEnabled = true;
            this.cbxHeightType.Items.AddRange(new object[] {
            "Pixels",
            "Percent"});
            this.cbxHeightType.Location = new System.Drawing.Point(164, 63);
            this.cbxHeightType.Name = "cbxHeightType";
            this.cbxHeightType.Size = new System.Drawing.Size(78, 21);
            this.cbxHeightType.TabIndex = 3;
            this.cbxHeightType.SelectedIndexChanged += new System.EventHandler(this.cbxHeightType_SelectedIndexChanged);
            // 
            // cbxWidthType
            // 
            this.cbxWidthType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWidthType.FormattingEnabled = true;
            this.cbxWidthType.Items.AddRange(new object[] {
            "Pixels",
            "Percent"});
            this.cbxWidthType.Location = new System.Drawing.Point(164, 27);
            this.cbxWidthType.Name = "cbxWidthType";
            this.cbxWidthType.Size = new System.Drawing.Size(78, 21);
            this.cbxWidthType.TabIndex = 1;
            this.cbxWidthType.SelectedIndexChanged += new System.EventHandler(this.cbxWidthType_SelectedIndexChanged);
            // 
            // tbxHeight
            // 
            this.tbxHeight.Location = new System.Drawing.Point(58, 64);
            this.tbxHeight.Name = "tbxHeight";
            this.tbxHeight.Size = new System.Drawing.Size(100, 20);
            this.tbxHeight.TabIndex = 2;
            this.tbxHeight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxHeight_KeyUp);
            // 
            // tbxWidth
            // 
            this.tbxWidth.Location = new System.Drawing.Point(58, 28);
            this.tbxWidth.Name = "tbxWidth";
            this.tbxWidth.Size = new System.Drawing.Size(100, 20);
            this.tbxWidth.TabIndex = 0;
            this.tbxWidth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxWidth_KeyUp);
            // 
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new System.Drawing.Point(17, 67);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(38, 13);
            this.lbHeight.TabIndex = 1;
            this.lbHeight.Text = "Height";
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(17, 31);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(35, 13);
            this.lbWidth.TabIndex = 0;
            this.lbWidth.Text = "Width";
            // 
            // lbResampleImage
            // 
            this.lbResampleImage.AutoSize = true;
            this.lbResampleImage.Location = new System.Drawing.Point(26, 183);
            this.lbResampleImage.Name = "lbResampleImage";
            this.lbResampleImage.Size = new System.Drawing.Size(86, 13);
            this.lbResampleImage.TabIndex = 1;
            this.lbResampleImage.Text = "Resample Image";
            // 
            // cbxResampleType
            // 
            this.cbxResampleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxResampleType.FormattingEnabled = true;
            this.cbxResampleType.Items.AddRange(new object[] {
            "Bicubic",
            "Bilinear",
            "Nearest Neighbour",
            "Best Quality"});
            this.cbxResampleType.Location = new System.Drawing.Point(118, 180);
            this.cbxResampleType.Name = "cbxResampleType";
            this.cbxResampleType.Size = new System.Drawing.Size(136, 21);
            this.cbxResampleType.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(46, 217);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(153, 217);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ResampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 254);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbxResampleType);
            this.Controls.Add(this.lbResampleImage);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ResampleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Size";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbResampleImage;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.ComboBox cbxHeightType;
        public System.Windows.Forms.ComboBox cbxWidthType;
        public System.Windows.Forms.TextBox tbxHeight;
        public System.Windows.Forms.TextBox tbxWidth;
        public System.Windows.Forms.CheckBox cbxConstrainProportion;
        public System.Windows.Forms.ComboBox cbxResampleType;
    }
}