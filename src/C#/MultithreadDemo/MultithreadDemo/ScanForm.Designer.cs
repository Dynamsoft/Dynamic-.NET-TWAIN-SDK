namespace MultithreadDemo
{
    partial class ScanForm
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
			this.SuspendLayout();
			// 
			// dynamicDotNetTwain1
			// 
			this.dynamicDotNetTwain1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dynamicDotNetTwain1.HookMessage = true;
			this.dynamicDotNetTwain1.Location = new System.Drawing.Point(13, 13);
			this.dynamicDotNetTwain1.Margin = new System.Windows.Forms.Padding(4);
			this.dynamicDotNetTwain1.Name = "dynamicDotNetTwain1";
			this.dynamicDotNetTwain1.PDFMarginBottom = ((uint)(0u));
			this.dynamicDotNetTwain1.PDFMarginLeft = ((uint)(0u));
			this.dynamicDotNetTwain1.PDFMarginRight = ((uint)(0u));
			this.dynamicDotNetTwain1.PDFMarginTop = ((uint)(0u));
			this.dynamicDotNetTwain1.Size = new System.Drawing.Size(1006, 608);
			this.dynamicDotNetTwain1.TabIndex = 0;
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1032, 634);
			this.Controls.Add(this.dynamicDotNetTwain1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form2";
			this.Text = "Form2";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.ResumeLayout(false);

        }

        #endregion

		private Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain dynamicDotNetTwain1;
    }
}