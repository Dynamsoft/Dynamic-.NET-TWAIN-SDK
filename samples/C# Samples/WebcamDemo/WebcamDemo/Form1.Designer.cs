namespace WebcamDemo
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
            this.btnCaptureImage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRemoveAllImages = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSources = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbContainer = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dsViewer1 = new Dynamsoft.Forms.DSViewer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCaptureImage
            // 
            this.btnCaptureImage.Location = new System.Drawing.Point(15, 266);
            this.btnCaptureImage.Name = "btnCaptureImage";
            this.btnCaptureImage.Size = new System.Drawing.Size(130, 23);
            this.btnCaptureImage.TabIndex = 1;
            this.btnCaptureImage.Text = "Capture Image";
            this.btnCaptureImage.UseVisualStyleBackColor = true;
            this.btnCaptureImage.Click += new System.EventHandler(this.btnCaptureImage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(275, 295);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // btnRemoveAllImages
            // 
            this.btnRemoveAllImages.Location = new System.Drawing.Point(15, 309);
            this.btnRemoveAllImages.Name = "btnRemoveAllImages";
            this.btnRemoveAllImages.Size = new System.Drawing.Size(130, 23);
            this.btnRemoveAllImages.TabIndex = 4;
            this.btnRemoveAllImages.Text = "Remove All Images";
            this.btnRemoveAllImages.UseVisualStyleBackColor = true;
            this.btnRemoveAllImages.Click += new System.EventHandler(this.btnRemoveAllImages_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Webcam Source:";
            // 
            // cbxSources
            // 
            this.cbxSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSources.FormattingEnabled = true;
            this.cbxSources.Location = new System.Drawing.Point(15, 35);
            this.cbxSources.Name = "cbxSources";
            this.cbxSources.Size = new System.Drawing.Size(131, 21);
            this.cbxSources.TabIndex = 13;
            this.cbxSources.SelectedIndexChanged += new System.EventHandler(this.cbxSources_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(160, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "ImageContainer:";
            // 
            // lbContainer
            // 
            this.lbContainer.AutoSize = true;
            this.lbContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbContainer.Location = new System.Drawing.Point(455, 16);
            this.lbContainer.Name = "lbContainer";
            this.lbContainer.Size = new System.Drawing.Size(101, 13);
            this.lbContainer.TabIndex = 15;
            this.lbContainer.Text = "Video Container:";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(455, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 300);
            this.panel1.TabIndex = 17;
            // 
            // dsViewer1
            // 
            this.dsViewer1.Location = new System.Drawing.Point(163, 37);
            this.dsViewer1.Name = "dsViewer1";
            this.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dsViewer1.SelectionRectAspectRatio = 0D;
            this.dsViewer1.Size = new System.Drawing.Size(277, 295);
            this.dsViewer1.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(749, 347);
            this.Controls.Add(this.dsViewer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbContainer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxSources);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemoveAllImages);
            this.Controls.Add(this.btnCaptureImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Webcam Demo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCaptureImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRemoveAllImages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSources;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbContainer;
        private System.Windows.Forms.Panel panel1;
        private Dynamsoft.Forms.DSViewer dsViewer1;
    }
}

