namespace SeparateDocumentByBarcode
{
    partial class Form2
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
            this.tbxPDFName = new System.Windows.Forms.TextBox();
            this.tbxSetFileName = new System.Windows.Forms.Button();
            this.lblPDFName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxPDFName
            // 
            this.tbxPDFName.Location = new System.Drawing.Point(15, 154);
            this.tbxPDFName.Name = "tbxPDFName";
            this.tbxPDFName.Size = new System.Drawing.Size(239, 20);
            this.tbxPDFName.TabIndex = 0;
            // 
            // tbxSetFileName
            // 
            this.tbxSetFileName.Location = new System.Drawing.Point(87, 198);
            this.tbxSetFileName.Name = "tbxSetFileName";
            this.tbxSetFileName.Size = new System.Drawing.Size(89, 23);
            this.tbxSetFileName.TabIndex = 1;
            this.tbxSetFileName.Text = "Set File Name";
            this.tbxSetFileName.UseVisualStyleBackColor = true;
            this.tbxSetFileName.Click += new System.EventHandler(this.tbxSetFileName_Click);
            // 
            // lblPDFName
            // 
            this.lblPDFName.AutoSize = true;
            this.lblPDFName.Location = new System.Drawing.Point(12, 127);
            this.lblPDFName.Name = "lblPDFName";
            this.lblPDFName.Size = new System.Drawing.Size(81, 13);
            this.lblPDFName.TabIndex = 2;
            this.lblPDFName.Text = "PDF File Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "The name of  PDF file contains  illegal character";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Note:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Please reset the name.";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 262);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblPDFName);
            this.Controls.Add(this.tbxSetFileName);
            this.Controls.Add(this.tbxPDFName);
            this.Name = "Form2";
            this.Text = "Set PDF File Name";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxPDFName;
        private System.Windows.Forms.Button tbxSetFileName;
        private System.Windows.Forms.Label lblPDFName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
    }
}