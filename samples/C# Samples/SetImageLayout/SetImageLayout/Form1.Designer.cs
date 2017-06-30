using System.Windows.Forms;
namespace SetImageLayout
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFrameBottom = new System.Windows.Forms.Label();
            this.lblFrameTop = new System.Windows.Forms.Label();
            this.lblFrameRight = new System.Windows.Forms.Label();
            this.lblFrameLeft = new System.Windows.Forms.Label();
            this.cbxSources = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edtFrameRight = new System.Windows.Forms.TextBox();
            this.edtFrameTop = new System.Windows.Forms.TextBox();
            this.btnSetAndAcquire = new System.Windows.Forms.Button();
            this.edtFrameLeft = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.edtFrameBottom = new System.Windows.Forms.TextBox();
            this.dsViewer1 = new Dynamsoft.Forms.DSViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFrameBottom);
            this.groupBox1.Controls.Add(this.lblFrameTop);
            this.groupBox1.Controls.Add(this.lblFrameRight);
            this.groupBox1.Controls.Add(this.lblFrameLeft);
            this.groupBox1.Controls.Add(this.cbxSources);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.edtFrameRight);
            this.groupBox1.Controls.Add(this.edtFrameTop);
            this.groupBox1.Controls.Add(this.btnSetAndAcquire);
            this.groupBox1.Controls.Add(this.edtFrameLeft);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.edtFrameBottom);
            this.groupBox1.Location = new System.Drawing.Point(8, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 168);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Layout Information";
            // 
            // lblFrameBottom
            // 
            this.lblFrameBottom.AutoSize = true;
            this.lblFrameBottom.Location = new System.Drawing.Point(382, 103);
            this.lblFrameBottom.Name = "lblFrameBottom";
            this.lblFrameBottom.Size = new System.Drawing.Size(0, 13);
            this.lblFrameBottom.TabIndex = 18;
            // 
            // lblFrameTop
            // 
            this.lblFrameTop.AutoSize = true;
            this.lblFrameTop.Location = new System.Drawing.Point(382, 68);
            this.lblFrameTop.Name = "lblFrameTop";
            this.lblFrameTop.Size = new System.Drawing.Size(0, 13);
            this.lblFrameTop.TabIndex = 17;
            // 
            // lblFrameRight
            // 
            this.lblFrameRight.AutoSize = true;
            this.lblFrameRight.Location = new System.Drawing.Point(155, 103);
            this.lblFrameRight.Name = "lblFrameRight";
            this.lblFrameRight.Size = new System.Drawing.Size(0, 13);
            this.lblFrameRight.TabIndex = 16;
            // 
            // lblFrameLeft
            // 
            this.lblFrameLeft.AutoSize = true;
            this.lblFrameLeft.Location = new System.Drawing.Point(155, 69);
            this.lblFrameLeft.Name = "lblFrameLeft";
            this.lblFrameLeft.Size = new System.Drawing.Size(0, 13);
            this.lblFrameLeft.TabIndex = 15;
            // 
            // cbxSources
            // 
            this.cbxSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSources.FormattingEnabled = true;
            this.cbxSources.Location = new System.Drawing.Point(167, 25);
            this.cbxSources.Name = "cbxSources";
            this.cbxSources.Size = new System.Drawing.Size(131, 21);
            this.cbxSources.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(49, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Select Scources:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtFrameRight
            // 
            this.edtFrameRight.Location = new System.Drawing.Point(91, 100);
            this.edtFrameRight.Name = "edtFrameRight";
            this.edtFrameRight.Size = new System.Drawing.Size(48, 20);
            this.edtFrameRight.TabIndex = 6;
            // 
            // edtFrameTop
            // 
            this.edtFrameTop.Location = new System.Drawing.Point(313, 66);
            this.edtFrameTop.Name = "edtFrameTop";
            this.edtFrameTop.Size = new System.Drawing.Size(51, 20);
            this.edtFrameTop.TabIndex = 5;
            // 
            // btnSetAndAcquire
            // 
            this.btnSetAndAcquire.Location = new System.Drawing.Point(21, 134);
            this.btnSetAndAcquire.Name = "btnSetAndAcquire";
            this.btnSetAndAcquire.Size = new System.Drawing.Size(102, 25);
            this.btnSetAndAcquire.TabIndex = 8;
            this.btnSetAndAcquire.Text = "Set And Acquire";
            this.btnSetAndAcquire.Click += new System.EventHandler(this.btnSetAndAcquire_Click);
            // 
            // edtFrameLeft
            // 
            this.edtFrameLeft.Location = new System.Drawing.Point(91, 66);
            this.edtFrameLeft.Name = "edtFrameLeft";
            this.edtFrameLeft.Size = new System.Drawing.Size(48, 20);
            this.edtFrameLeft.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(218, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Frame Bottom:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Frame Right:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Frame Left:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(234, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Frame Top:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtFrameBottom
            // 
            this.edtFrameBottom.Location = new System.Drawing.Point(313, 100);
            this.edtFrameBottom.Name = "edtFrameBottom";
            this.edtFrameBottom.Size = new System.Drawing.Size(51, 20);
            this.edtFrameBottom.TabIndex = 7;
            // 
            // dsViewer1
            // 
            this.dsViewer1.Location = new System.Drawing.Point(13, 183);
            this.dsViewer1.Name = "dsViewer1";
            this.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dsViewer1.SelectionRectAspectRatio = 0D;
            this.dsViewer1.Size = new System.Drawing.Size(443, 286);
            this.dsViewer1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(468, 481);
            this.Controls.Add(this.dsViewer1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Set Image Layout";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }


        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edtFrameLeft;
        private System.Windows.Forms.Button btnSetAndAcquire;
        private System.Windows.Forms.TextBox edtFrameTop;
        private System.Windows.Forms.TextBox edtFrameRight;
        private System.Windows.Forms.TextBox edtFrameBottom;
        private Label label5;
        private ComboBox cbxSources;
        private Label lblFrameBottom;
        private Label lblFrameTop;
        private Label lblFrameRight;
        private Label lblFrameLeft;
        #endregion
        private Dynamsoft.Forms.DSViewer dsViewer1;
    }
}

