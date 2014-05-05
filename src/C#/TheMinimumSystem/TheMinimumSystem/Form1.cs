using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace TheMinimumSystem
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button btnAcquire;
        private Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain dynamicDotNetTwain;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            this.btnAcquire = new System.Windows.Forms.Button();
            this.dynamicDotNetTwain = new Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain();
            this.SuspendLayout();
            // 
            // btnAcquire
            // 
            this.btnAcquire.Location = new System.Drawing.Point(10, 336);
            this.btnAcquire.Name = "btnAcquire";
            this.btnAcquire.Size = new System.Drawing.Size(91, 28);
            this.btnAcquire.TabIndex = 1;
            this.btnAcquire.Text = "Acquire";
            this.btnAcquire.Click += new System.EventHandler(this.btnAcquire_Click);
            // 
            // dynamicDotNetTwain
            // 
            this.dynamicDotNetTwain.Location = new System.Drawing.Point(14, 13);
            this.dynamicDotNetTwain.Name = "dynamicDotNetTwain";
            this.dynamicDotNetTwain.Size = new System.Drawing.Size(408, 303);
            this.dynamicDotNetTwain.TabIndex = 2;
            this.dynamicDotNetTwain.OnPostTransfer += new Dynamsoft.DotNet.TWAIN.Delegate.OnPostTransferHandler(this.dynamicDotNetTwain_OnPostTransfer);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(432, 365);
            this.Controls.Add(this.dynamicDotNetTwain);
            this.Controls.Add(this.btnAcquire);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "The Minimum System";
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnAcquire_Click(object sender, System.EventArgs e)
		{
            dynamicDotNetTwain.IfDisableSourceAfterAcquire = true;
            if(dynamicDotNetTwain.SelectSource())
			    dynamicDotNetTwain.AcquireImage();
		}


        private void dynamicDotNetTwain_OnPostTransfer()
        {
            GC.Collect();	//make garbage collector work to release memory	
        }

	
	}
}
