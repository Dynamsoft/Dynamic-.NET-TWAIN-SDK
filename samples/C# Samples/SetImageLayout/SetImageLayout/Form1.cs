using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace SetImageLayout
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
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
        private Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain dynamicDotNetTwain;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            dynamicDotNetTwain.ScanInNewProcess = true;
            this.dynamicDotNetTwain.LicenseKeys = "BAF81AB5515958BF519F7AAE2A318B3B;BAF81AB5515958BF6DA4299CBA3CC11D;BAF81AB5515958BF9C195A4722534974;BAF81AB5515958BFE96B7433DD28E75B;BAF81AB5515958BF3DBAF9AB37059787;BAF81AB5515958BF5291EEE0B030BD82";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edtFrameRight = new System.Windows.Forms.TextBox();
            this.edtFrameTop = new System.Windows.Forms.TextBox();
            this.btnSetAndAcquire = new System.Windows.Forms.Button();
            this.edtFrameLeft = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.edtFrameBottom = new System.Windows.Forms.TextBox();
            this.dynamicDotNetTwain = new Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
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
            this.groupBox1.Size = new System.Drawing.Size(304, 129);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Layout Information";
            // 
            // edtFrameRight
            // 
            this.edtFrameRight.Location = new System.Drawing.Point(96, 60);
            this.edtFrameRight.Name = "edtFrameRight";
            this.edtFrameRight.Size = new System.Drawing.Size(48, 20);
            this.edtFrameRight.TabIndex = 6;
            // 
            // edtFrameTop
            // 
            this.edtFrameTop.Location = new System.Drawing.Point(240, 26);
            this.edtFrameTop.Name = "edtFrameTop";
            this.edtFrameTop.Size = new System.Drawing.Size(51, 20);
            this.edtFrameTop.TabIndex = 5;
            // 
            // btnSetAndAcquire
            // 
            this.btnSetAndAcquire.Location = new System.Drawing.Point(26, 94);
            this.btnSetAndAcquire.Name = "btnSetAndAcquire";
            this.btnSetAndAcquire.Size = new System.Drawing.Size(102, 25);
            this.btnSetAndAcquire.TabIndex = 8;
            this.btnSetAndAcquire.Text = "Set and Acquire";
            this.btnSetAndAcquire.Click += new System.EventHandler(this.btnSetAndAcquire_Click);
            // 
            // edtFrameLeft
            // 
            this.edtFrameLeft.Location = new System.Drawing.Point(96, 26);
            this.edtFrameLeft.Name = "edtFrameLeft";
            this.edtFrameLeft.Size = new System.Drawing.Size(48, 20);
            this.edtFrameLeft.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(160, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Frame Bottom:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Frame Right:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Frame Left:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(176, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Frame Top:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtFrameBottom
            // 
            this.edtFrameBottom.Location = new System.Drawing.Point(240, 60);
            this.edtFrameBottom.Name = "edtFrameBottom";
            this.edtFrameBottom.Size = new System.Drawing.Size(48, 20);
            this.edtFrameBottom.TabIndex = 7;
            // 
            // dynamicDotNetTwain
            // 
            this.dynamicDotNetTwain.AnnotationFillColor = System.Drawing.Color.White;
            this.dynamicDotNetTwain.AnnotationPen = null;
            this.dynamicDotNetTwain.AnnotationTextColor = System.Drawing.Color.Black;
            this.dynamicDotNetTwain.AnnotationTextFont = null;
            this.dynamicDotNetTwain.IfShowPrintUI = false;
            this.dynamicDotNetTwain.IfThrowException = false;
            this.dynamicDotNetTwain.Location = new System.Drawing.Point(8, 143);
            this.dynamicDotNetTwain.LogLevel = ((short)(0));
            this.dynamicDotNetTwain.Name = "dynamicDotNetTwain";
            this.dynamicDotNetTwain.PDFMarginBottom = ((uint)(0u));
            this.dynamicDotNetTwain.PDFMarginLeft = ((uint)(0u));
            this.dynamicDotNetTwain.PDFMarginRight = ((uint)(0u));
            this.dynamicDotNetTwain.PDFMarginTop = ((uint)(0u));
            this.dynamicDotNetTwain.PDFXConformance = ((uint)(0u));
            this.dynamicDotNetTwain.Size = new System.Drawing.Size(304, 286);
            this.dynamicDotNetTwain.TabIndex = 11;
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(322, 436);
            this.Controls.Add(this.dynamicDotNetTwain);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Set Image Layout";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		private void btnSetAndAcquire_Click(object sender, System.EventArgs e)
		{
            float fFrameLeft, fFrameTop, fFrameRight, fFrameBottom, frameTemp;

			try
			{
				fFrameLeft = Convert.ToSingle(edtFrameLeft.Text);
				fFrameTop = Convert.ToSingle(edtFrameTop.Text);
				fFrameRight = Convert.ToSingle(edtFrameRight.Text);
				fFrameBottom = Convert.ToSingle(edtFrameBottom.Text);

                if (fFrameLeft > fFrameRight)
                {
                    frameTemp = fFrameLeft;
                    fFrameLeft = fFrameRight;
                    fFrameRight = frameTemp;
                }

                if (fFrameTop > fFrameBottom)
                {
                    frameTemp = fFrameTop;
                    fFrameTop = fFrameBottom;
                    fFrameBottom = frameTemp;
                }
			}
			catch (Exception)
			{
				MessageBox.Show("Please input numerical values in the input boxes.", "Error");
				return;
			}

            if (fFrameLeft == fFrameRight || fFrameTop == fFrameBottom)
            {
                MessageBox.Show("Input Value Error: don't make left equal to right, or top equal to bottom.", "Error");
                return;
            }

            if (dynamicDotNetTwain.SelectSource())
            {
                dynamicDotNetTwain.OpenSource();			//make dynamicDotNetTwain ready for capability negotiation

                if (dynamicDotNetTwain.SetImageLayout(fFrameLeft, fFrameTop, fFrameRight, fFrameBottom) == false)
                    MessageBox.Show(dynamicDotNetTwain.ErrorString, "Error");
                else
                {
                    dynamicDotNetTwain.IfShowUI = false;
                    dynamicDotNetTwain.IfDisableSourceAfterAcquire = true;
                    dynamicDotNetTwain.EnableSource();
                }
            }
		}
		
	}
}

