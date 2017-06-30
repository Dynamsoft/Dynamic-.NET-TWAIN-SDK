namespace TheMinimumSystem
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
            this.Acquire = new System.Windows.Forms.Button();
            this.dsViewer1 = new Dynamsoft.Forms.DSViewer();
            this.SuspendLayout();
            // 
            // Acquire
            // 
            this.Acquire.Location = new System.Drawing.Point(12, 426);
            this.Acquire.Name = "Acquire";
            this.Acquire.Size = new System.Drawing.Size(80, 23);
            this.Acquire.TabIndex = 1;
            this.Acquire.Text = "Acquire";
            this.Acquire.UseVisualStyleBackColor = true;
            this.Acquire.Click += new System.EventHandler(this.Acquire_Click);
            // 
            // dsViewer1
            // 
            this.dsViewer1.Location = new System.Drawing.Point(12, 12);
            this.dsViewer1.Name = "dsViewer1";
            this.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dsViewer1.SelectionRectAspectRatio = 0D;
            this.dsViewer1.Size = new System.Drawing.Size(504, 408);
            this.dsViewer1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 472);
            this.Controls.Add(this.dsViewer1);
            this.Controls.Add(this.Acquire);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Acquire";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Acquire;
        private Dynamsoft.Forms.DSViewer dsViewer1;
    }
}

