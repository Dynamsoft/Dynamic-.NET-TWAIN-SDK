using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace AcquireImageWithDiskFileMode
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnSelectSource;
		private System.Windows.Forms.Button btnAcquire;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private System.Windows.Forms.SaveFileDialog dlgFileSave;
        private Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain dynamicDotNetTwain;
		private string strFileName;

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
            this.btnSelectSource = new System.Windows.Forms.Button();
            this.btnAcquire = new System.Windows.Forms.Button();
            this.dlgFileSave = new System.Windows.Forms.SaveFileDialog();
            this.dynamicDotNetTwain = new Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain();
            this.SuspendLayout();
            // 
            // btnSelectSource
            // 
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
            // dynamicDotNetTwain
            // 
            this.dynamicDotNetTwain.Location = new System.Drawing.Point(8, 12);
            this.dynamicDotNetTwain.Name = "dynamicDotNetTwain";
            this.dynamicDotNetTwain.Size = new System.Drawing.Size(373, 324);
            this.dynamicDotNetTwain.TabIndex = 3;
            this.dynamicDotNetTwain.OnPostAllTransfers += new Dynamsoft.DotNet.TWAIN.Delegate.OnPostAllTransfersHandler(this.dynamicDotNetTwain_OnPostAllTransfers);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(393, 401);
            this.Controls.Add(this.dynamicDotNetTwain);
            this.Controls.Add(this.btnAcquire);
            this.Controls.Add(this.btnSelectSource);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
	    this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Acquire Image with DiskFile Mode";
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

		private void btnSelectSource_Click(object sender, System.EventArgs e)
		{
			dynamicDotNetTwain.SelectSource();
		}

		
		private void btnAcquire_Click(object sender, System.EventArgs e)
		{
			if (dlgFileSave.ShowDialog() == DialogResult.Cancel)
				return;
			
			strFileName = dlgFileSave.FileName;
			
			dynamicDotNetTwain.OpenSource();

			dynamicDotNetTwain.TransferMode = Dynamsoft.DotNet.TWAIN.Enums.TWICapSetupXFer.TWSX_FILE;
    
			//Since the TWSX_FILE mode is not required by TWAIN specification,
			//it is better to read the value back to see if the File transfer mode is supported by the Source
			if (dynamicDotNetTwain.TransferMode == Dynamsoft.DotNet.TWAIN.Enums.TWICapSetupXFer.TWSX_FILE)
			{        //the source supports the TWSX_FILE transfer mode.
				dynamicDotNetTwain.SetFileXFERInfo(strFileName,Dynamsoft.DotNet.TWAIN.Enums.TWICapFileFormat.TWFF_BMP);       //Sets file name and file format information.
				dynamicDotNetTwain.IfShowUI = false;
				dynamicDotNetTwain.IfDisableSourceAfterAcquire = true;
				dynamicDotNetTwain.EnableSource();     //Acquire the image.
			}
			else                       //the source doesn't support the TWSX_FILE transfer mode.
				MessageBox.Show("The source doesn't support the DiskFile transfer mode.");
		

		}



        private void dynamicDotNetTwain_OnPostAllTransfers()
        {
            dynamicDotNetTwain.LoadImage(strFileName);
        }

     		
	}
}
