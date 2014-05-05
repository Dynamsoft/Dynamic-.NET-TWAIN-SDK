using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace MultithreadDemo
{
    public partial class ScanForm : Form
    {
		private String _tranferedFileName;

		private bool _isScanning;
		public bool IsScanning
		{
			get { return _isScanning; }
			private set 
			{
				// TODO:  Shoud also fire an event to let the control system know the scanning has stopped.
				_isScanning = value; 
			}
		}

		private MainForm _viewer;
		public MainForm Viewer
		{
			get { return _viewer; }
		}

        public ScanForm(MainForm viewer/* = null*/)
        //public ScanForm()
        {
			// Store pointer to the main app 
			if (viewer != null)
			{
				_viewer = viewer;
			}

			// Don't want this window showing.
			this.Visible = false;

            InitializeComponent();
			dynamicDotNetTwain1.OnPostAllTransfers += new Dynamsoft.DotNet.TWAIN.Delegate.OnPostAllTransfersHandler(Twain_OnPostAllTransfers);
			dynamicDotNetTwain1.OnPreTransfer += new Dynamsoft.DotNet.TWAIN.Delegate.OnPreTransferHandler(Twain_OnPreTransfer);
			dynamicDotNetTwain1.OnPostTransfer += new Dynamsoft.DotNet.TWAIN.Delegate.OnPostTransferHandler(Twain_OnPostTransfer);
			dynamicDotNetTwain1.OnTransferCancelled += new Dynamsoft.DotNet.TWAIN.Delegate.OnTransferCancelledHandler(Twain_OnTransferCancelled);
			dynamicDotNetTwain1.OnTransferError += new Dynamsoft.DotNet.TWAIN.Delegate.OnTransferErrorHandler(Twain_OnTransferError);
        }

		void Twain_OnPostAllTransfers()
		{
			_isScanning = false;
		}

		private delegate void ScanDelegate();
		public void StartScan()
		{
			Trace.WriteLine(String.Format("thread id {0}: StartScan", Thread.CurrentThread.ManagedThreadId));
			_isScanning = true;
			if (this.InvokeRequired == true)
			{
				IAsyncResult iar = this.BeginInvoke(new ScanDelegate(this.Scan));
			}
			else
			{
				Scan();
			}
		}

		private void Scan()
		{
			Trace.WriteLine(String.Format("thread id {0}: Scan", Thread.CurrentThread.ManagedThreadId));
			dynamicDotNetTwain1.SetViewMode(1, 1);

			if (dynamicDotNetTwain1.SelectSource() == true)
			{
				dynamicDotNetTwain1.TransferMode = Dynamsoft.DotNet.TWAIN.Enums.TWICapSetupXFer.TWSX_FILE;

                dynamicDotNetTwain1.OpenSource();

                string scanPath = Path.GetFullPath(Path.Combine(Environment.GetFolderPath(
                     Environment.SpecialFolder.LocalApplicationData), "..\\Temp"));
                if (Directory.Exists(scanPath) == false)
                {
                    Directory.CreateDirectory(scanPath);
                }

                String scanPathTemp = scanPath;
                String fileName = Path.Combine(scanPathTemp, String.Format("{0}.bmp", DateTime.UtcNow.Ticks));
                if (dynamicDotNetTwain1.SetFileXFERInfo(fileName, Dynamsoft.DotNet.TWAIN.Enums.TWICapFileFormat.TWFF_BMP) == true)
                {
                    _tranferedFileName = fileName;
                }
                else
                {
                    _tranferedFileName = null;
                }

				dynamicDotNetTwain1.JPEGQuality = 60;
				dynamicDotNetTwain1.XferCount = -1;
				dynamicDotNetTwain1.IfAutoFeed = true;
				dynamicDotNetTwain1.IfAutoScan = true;
				dynamicDotNetTwain1.IfDuplexEnabled = true;
				//dynamicDotNetTwain1.IfFeederEnabled = true;
				dynamicDotNetTwain1.IfDisableSourceAfterAcquire = true;
				dynamicDotNetTwain1.IfShowIndicator = false;
				dynamicDotNetTwain1.IfShowCancelDialogWhenImageTransfer = false;
				dynamicDotNetTwain1.IfShowUI = true;

				if (dynamicDotNetTwain1.EnableSource() == false)
				{
					Trace.WriteLine(String.Format("Failed to start scanning: ({0}) {1}", dynamicDotNetTwain1.ErrorCode, dynamicDotNetTwain1.ErrorString));
					_isScanning = false;
				}
				else
				{
					_isScanning = true;
				}
			}
		}

		public void StopScan()
		{

		}

		void Twain_OnTransferError()
		{
			String msg = String.Format("Error Code ({0}): {1}", dynamicDotNetTwain1.ErrorCode, dynamicDotNetTwain1.ErrorString);
		}

		void Twain_OnTransferCancelled()
		{
			this.IsScanning = false;
		}

		void Twain_OnPostTransfer()
		{
			//if (String.IsNullOrWhiteSpace(_tranferedFileName) == false &&
            if (null != _tranferedFileName && _tranferedFileName.Length != 0 &&
				File.Exists(_tranferedFileName))
			{
				_viewer.LoadImage(_tranferedFileName);
			}
		}

		void Twain_OnPreTransfer()
		{

		}

        private void button1_Click(object sender, EventArgs e)
        {
			Scan();
        }
    }
}
