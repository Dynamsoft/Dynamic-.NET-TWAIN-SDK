namespace ScanAndUpload
{
    partial class SuccessInfo
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(21, 29);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(421, 20);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Location = new System.Drawing.Point(21, 52);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(55, 13);
            this.lblLink.TabIndex = 2;
            this.lblLink.TabStop = true;
            this.lblLink.Text = "linkLabel1";
            this.lblLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLink_LinkClicked);
            // 
            // SuccessInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 122);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuccessInfo";
            this.Text = "Success";
            this.Load += new System.EventHandler(this.SuccessInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel lblLink;
    }
}