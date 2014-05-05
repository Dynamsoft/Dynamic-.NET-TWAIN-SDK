namespace DotNet_TWAIN_Demo
{
    partial class RotateForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.lnAngle = new System.Windows.Forms.Label();
            this.tbxAngle = new System.Windows.Forms.TextBox();
            this.lbInterPolation = new System.Windows.Forms.Label();
            this.cbxInterPolation = new System.Windows.Forms.ComboBox();
            this.cbxKeepSize = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxB = new System.Windows.Forms.TextBox();
            this.tbxG = new System.Windows.Forms.TextBox();
            this.tbxR = new System.Windows.Forms.TextBox();
            this.lbB = new System.Windows.Forms.Label();
            this.lbG = new System.Windows.Forms.Label();
            this.lbR = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(134, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lnAngle
            // 
            this.lnAngle.AutoSize = true;
            this.lnAngle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnAngle.Location = new System.Drawing.Point(23, 25);
            this.lnAngle.Name = "lnAngle";
            this.lnAngle.Size = new System.Drawing.Size(40, 15);
            this.lnAngle.TabIndex = 1;
            this.lnAngle.Text = "Angle:";
            // 
            // tbxAngle
            // 
            this.tbxAngle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAngle.Location = new System.Drawing.Point(109, 17);
            this.tbxAngle.Name = "tbxAngle";
            this.tbxAngle.Size = new System.Drawing.Size(122, 23);
            this.tbxAngle.TabIndex = 0;
            // 
            // lbInterPolation
            // 
            this.lbInterPolation.AutoSize = true;
            this.lbInterPolation.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInterPolation.Location = new System.Drawing.Point(23, 66);
            this.lbInterPolation.Name = "lbInterPolation";
            this.lbInterPolation.Size = new System.Drawing.Size(82, 15);
            this.lbInterPolation.TabIndex = 1;
            this.lbInterPolation.Text = "Interpolation:";
            // 
            // cbxInterPolation
            // 
            this.cbxInterPolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInterPolation.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxInterPolation.FormattingEnabled = true;
            this.cbxInterPolation.Items.AddRange(new object[] {
            "Bicubic",
            "Bilinear",
            "NearestNeighbour"});
            this.cbxInterPolation.Location = new System.Drawing.Point(109, 58);
            this.cbxInterPolation.Name = "cbxInterPolation";
            this.cbxInterPolation.Size = new System.Drawing.Size(121, 23);
            this.cbxInterPolation.TabIndex = 1;
            // 
            // cbxKeepSize
            // 
            this.cbxKeepSize.AutoSize = true;
            this.cbxKeepSize.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxKeepSize.Location = new System.Drawing.Point(109, 101);
            this.cbxKeepSize.Name = "cbxKeepSize";
            this.cbxKeepSize.Size = new System.Drawing.Size(76, 19);
            this.cbxKeepSize.TabIndex = 2;
            this.cbxKeepSize.Text = "Keep Size";
            this.cbxKeepSize.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxB);
            this.groupBox1.Controls.Add(this.tbxG);
            this.groupBox1.Controls.Add(this.tbxR);
            this.groupBox1.Controls.Add(this.lbB);
            this.groupBox1.Controls.Add(this.lbG);
            this.groupBox1.Controls.Add(this.lbR);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 66);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fill Color:";
            // 
            // tbxB
            // 
            this.tbxB.Location = new System.Drawing.Point(175, 27);
            this.tbxB.Name = "tbxB";
            this.tbxB.Size = new System.Drawing.Size(46, 23);
            this.tbxB.TabIndex = 5;
            // 
            // tbxG
            // 
            this.tbxG.Location = new System.Drawing.Point(101, 27);
            this.tbxG.Name = "tbxG";
            this.tbxG.Size = new System.Drawing.Size(46, 23);
            this.tbxG.TabIndex = 4;
            // 
            // tbxR
            // 
            this.tbxR.Location = new System.Drawing.Point(27, 27);
            this.tbxR.Name = "tbxR";
            this.tbxR.Size = new System.Drawing.Size(46, 23);
            this.tbxR.TabIndex = 3;
            // 
            // lbB
            // 
            this.lbB.AutoSize = true;
            this.lbB.Location = new System.Drawing.Point(153, 30);
            this.lbB.Name = "lbB";
            this.lbB.Size = new System.Drawing.Size(17, 15);
            this.lbB.TabIndex = 2;
            this.lbB.Text = "B:";
            // 
            // lbG
            // 
            this.lbG.AutoSize = true;
            this.lbG.Location = new System.Drawing.Point(80, 30);
            this.lbG.Name = "lbG";
            this.lbG.Size = new System.Drawing.Size(18, 15);
            this.lbG.TabIndex = 1;
            this.lbG.Text = "G:";
            // 
            // lbR
            // 
            this.lbR.AutoSize = true;
            this.lbR.Location = new System.Drawing.Point(7, 30);
            this.lbR.Name = "lbR";
            this.lbR.Size = new System.Drawing.Size(17, 15);
            this.lbR.TabIndex = 0;
            this.lbR.Text = "R:";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(40, 210);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // RotateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 256);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbxKeepSize);
            this.Controls.Add(this.cbxInterPolation);
            this.Controls.Add(this.tbxAngle);
            this.Controls.Add(this.lbInterPolation);
            this.Controls.Add(this.lnAngle);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RotateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rotate Image";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbxAngle;
        public System.Windows.Forms.ComboBox cbxInterPolation;
        public System.Windows.Forms.CheckBox cbxKeepSize;
        public System.Windows.Forms.TextBox tbxB;
        public System.Windows.Forms.TextBox tbxG;
        public System.Windows.Forms.TextBox tbxR;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label lnAngle;
        public System.Windows.Forms.Label lbInterPolation;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lbB;
        public System.Windows.Forms.Label lbG;
        public System.Windows.Forms.Label lbR;
    }
}