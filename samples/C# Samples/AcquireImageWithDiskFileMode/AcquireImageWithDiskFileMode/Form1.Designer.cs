namespace AcquireImageWithDiskFileMode
{
    partial class Form1
    {

        private System.Windows.Forms.Button btnSelectSource;
        private System.Windows.Forms.Button btnAcquire;
        private System.Windows.Forms.SaveFileDialog dlgFileSave;
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
            this.btnSelectSource = new System.Windows.Forms.Button();
            this.btnAcquire = new System.Windows.Forms.Button();
            this.dlgFileSave = new System.Windows.Forms.SaveFileDialog();
            this.dsViewer1 = new Dynamsoft.Forms.DSViewer();
            this.SuspendLayout();
             
             
            this.btnSelectSource.Location = new System.Drawing.Point(8, 342);
            this.btnSelectSource.Name = "btnSelectSource";
            this.btnSelectSource.Size = new System.Drawing.Size(94, 25);
            this.btnSelectSource.TabIndex = 1;
            this.btnSelectSource.Text = "Select Source";
            this.btnSelectSource.Click += new System.EventHandler(this.btnSelectSource_Click);
            // 
            // btnAcquire
            // 
            this.btnAcquire.Location = new System.Drawing.Point(119, 342);
            this.btnAcquire.Name = "btnAcquire";
            this.btnAcquire.Size = new System.Drawing.Size(86, 25);
            this.btnAcquire.TabIndex = 2;
            this.btnAcquire.Text = "Acquire";
            this.btnAcquire.Click += new System.EventHandler(this.btnAcquire_Click);
            // 
            // dlgFileSave
            // 
            this.dlgFileSave.DefaultExt = "bmp";
            this.dlgFileSave.FileName = "dynamicDotNetTwain";
            this.dlgFileSave.Filter = "Bitmap File(*.bmp)|*.bmp";
            // 
            // dsViewer1
            // 
            this.dsViewer1.Location = new System.Drawing.Point(12, 12);
            this.dsViewer1.Name = "dsViewer1";
            this.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dsViewer1.SelectionRectAspectRatio = 0D;
            this.dsViewer1.Size = new System.Drawing.Size(369, 324);
            this.dsViewer1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(393, 401);
            this.Controls.Add(this.dsViewer1);
            this.Controls.Add(this.btnAcquire);
            this.Controls.Add(this.btnSelectSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Acquire Image with DiskFile Mode";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private Dynamsoft.Forms.DSViewer dsViewer1;

    }
}

