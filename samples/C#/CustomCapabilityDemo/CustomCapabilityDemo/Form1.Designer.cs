namespace CustomCapabilityDemo
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
            this.btnSetCapability = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dynamicDotNetTwain1
            // 
            this.dynamicDotNetTwain1.AnnotationFillColor = System.Drawing.Color.White;
            this.dynamicDotNetTwain1.AnnotationPen = null;
            this.dynamicDotNetTwain1.AnnotationTextColor = System.Drawing.Color.Black;
            this.dynamicDotNetTwain1.AnnotationTextFont = null;
            this.dynamicDotNetTwain1.IfShowPrintUI = false;
            this.dynamicDotNetTwain1.Location = new System.Drawing.Point(12, 28);
            this.dynamicDotNetTwain1.LogLevel = ((short)(0));
            this.dynamicDotNetTwain1.Name = "dynamicDotNetTwain1";
            this.dynamicDotNetTwain1.PDFMarginBottom = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginLeft = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginRight = ((uint)(0u));
            this.dynamicDotNetTwain1.PDFMarginTop = ((uint)(0u));
            this.dynamicDotNetTwain1.Size = new System.Drawing.Size(327, 276);
            this.dynamicDotNetTwain1.TabIndex = 0;
            // 
            // btnSetCapability
            // 
            this.btnSetCapability.Location = new System.Drawing.Point(12, 325);
            this.btnSetCapability.Name = "btnSetCapability";
            this.btnSetCapability.Size = new System.Drawing.Size(159, 23);
            this.btnSetCapability.TabIndex = 1;
            this.btnSetCapability.Text = "Set Custom CAP 0x:8001";
            this.btnSetCapability.UseVisualStyleBackColor = true;
            this.btnSetCapability.Click += new System.EventHandler(this.btnSetCapability_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Set Custom CAP 0x:8002";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 354);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Scan";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 393);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSetCapability);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dynamicDotNetTwain1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Custom Capability Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain dynamicDotNetTwain1;
        private System.Windows.Forms.Button btnSetCapability;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

