using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace MultithreadDemo
{
	public partial class MainForm : Form
	{
		private ScanForm _scanControl;

		public MainForm()
		{
			InitializeComponent();

			dynamicDotNetTwain1.MaxImagesInBuffer = 100;
			dynamicDotNetTwain1.SetViewMode(2, 1);

			// Create the scanning thread
			ThreadPool.QueueUserWorkItem(new WaitCallback(acquireImageInThread), this);
		}

		private void ScanClick(object sender, EventArgs e)
		{
			Trace.WriteLine(String.Format("thread id {0}: ScanClick", Thread.CurrentThread.ManagedThreadId));


			if (_imagesToLoad == null)
			{
				_imagesToLoad = new List<string>();
			}
			else if (_imagesToLoad.Count != 0)
			{
				_imagesToLoad.Clear();
			}

 			
			if(_scanControl != null)
				_scanControl.StartScan();
		}

		private List<String> _imagesToLoad;
		private object _syncObject = new object();
        private void acquireImageInThread(object obj)
        {
			Trace.WriteLine(String.Format("thread id {0}: acquireImageInThread", Thread.CurrentThread.ManagedThreadId));
			MainForm fm1 = obj as MainForm;

			Thread.CurrentThread.Name = "Scanning";
			if (fm1 == null)
			{
				// TODO:  Display error
			}
			else
			{
				ScanForm fm2 = new ScanForm(fm1);

				fm1._scanControl = fm2;

				fm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
				fm2.ShowInTaskbar = false;
				fm2.Size = new Size(0,0);
				
				fm2.ShowDialog();
			}
        }

		private delegate void LoadImageDelegate1(String fileName);
		private delegate void LoadImageDelegate(String fileName, object reserved);
		private LoadImageDelegate loadImageDelegate;
		public void LoadImage(String fileName)
		{
			Trace.WriteLine(String.Format("thread id {0}: LoadImage", Thread.CurrentThread.ManagedThreadId));

			if (this.InvokeRequired == true)
			{
				IAsyncResult iar = this.BeginInvoke(new LoadImageDelegate(this.LoadImage2), fileName, null);
			}
			else
			{
				// should never reach this code.
				LoadImage2(fileName, null);
			}
		}

		private void LoadImage2(String fileName, object reserved)
		{
			Trace.WriteLine(String.Format("thread id {0}: LoadImage", Thread.CurrentThread.ManagedThreadId));

			dynamicDotNetTwain1.LoadImage(fileName);
		}

		private void LoadImageBtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF";
			DialogResult res =  dlg.ShowDialog();
			if (res == System.Windows.Forms.DialogResult.OK)
			{
				dynamicDotNetTwain1.LoadImage(dlg.FileName);
			}
		}
	}
}
