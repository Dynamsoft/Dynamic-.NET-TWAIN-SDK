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
            this.btnSetCapability = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dsViewer1 = new Dynamsoft.Forms.DSViewer();
            this.SuspendLayout();
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
            // dsViewer1
            // 
            this.dsViewer1.Location = new System.Drawing.Point(12, 12);
            this.dsViewer1.Name = "dsViewer1";
            this.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dsViewer1.SelectionRectAspectRatio = 0D;
            this.dsViewer1.Size = new System.Drawing.Size(331, 307);
            this.dsViewer1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 393);
            this.Controls.Add(this.dsViewer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSetCapability);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Custom Capability Demo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Button btnSetCapability;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Dynamsoft.Forms.DSViewer dsViewer1;
    }
}

