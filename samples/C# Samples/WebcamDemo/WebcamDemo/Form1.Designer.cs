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
            this.picbox90 = new System.Windows.Forms.PictureBox();
            this.picbox180 = new System.Windows.Forms.PictureBox();
            this.picbox270 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxResolution = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox90)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox180)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox270)).BeginInit();
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
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
            // picbox90
            // 
            this.picbox90.Image = global::WebcamDemo.Properties.Resources._90_normal;
            this.picbox90.Location = new System.Drawing.Point(15, 174);
            this.picbox90.Name = "picbox90";
            this.picbox90.Size = new System.Drawing.Size(24, 21);
            this.picbox90.TabIndex = 24;
            this.picbox90.TabStop = false;
            this.picbox90.Click += new System.EventHandler(this.picbox90_Click);
            this.picbox90.MouseLeave += new System.EventHandler(this.picbox90_MouseLeave);
            this.picbox90.MouseHover += new System.EventHandler(this.picbox90_MouseHover);
            // 
            // picbox180
            // 
            this.picbox180.Image = global::WebcamDemo.Properties.Resources._180_normal;
            this.picbox180.Location = new System.Drawing.Point(55, 174);
            this.picbox180.Name = "picbox180";
            this.picbox180.Size = new System.Drawing.Size(24, 21);
            this.picbox180.TabIndex = 25;
            this.picbox180.TabStop = false;
            this.picbox180.Click += new System.EventHandler(this.picbox180_Click);
            this.picbox180.MouseLeave += new System.EventHandler(this.picbox180_MouseLeave);
            this.picbox180.MouseHover += new System.EventHandler(this.picbox180_MouseHover);
            // 
            // picbox270
            // 
            this.picbox270.Image = global::WebcamDemo.Properties.Resources._270_normal;
            this.picbox270.Location = new System.Drawing.Point(95, 174);
            this.picbox270.Name = "picbox270";
            this.picbox270.Size = new System.Drawing.Size(24, 21);
            this.picbox270.TabIndex = 26;
            this.picbox270.TabStop = false;
            this.picbox270.Click += new System.EventHandler(this.picbox270_Click);
            this.picbox270.MouseLeave += new System.EventHandler(this.picbox270_MouseLeave);
            this.picbox270.MouseHover += new System.EventHandler(this.picbox270_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(15, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Resolution:";
            // 
            // cbxResolution
            // 
            this.cbxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxResolution.FormattingEnabled = true;
            this.cbxResolution.Location = new System.Drawing.Point(15, 101);
            this.cbxResolution.Name = "cbxResolution";
            this.cbxResolution.Size = new System.Drawing.Size(131, 21);
            this.cbxResolution.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(18, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Rotate:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(749, 347);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxResolution);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picbox270);
            this.Controls.Add(this.picbox180);
            this.Controls.Add(this.picbox90);
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
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox90)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox180)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox270)).EndInit();
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
        private System.Windows.Forms.PictureBox picbox90;
        private System.Windows.Forms.PictureBox picbox180;
        private System.Windows.Forms.PictureBox picbox270;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxResolution;
        private System.Windows.Forms.Label label4;
    }
}

