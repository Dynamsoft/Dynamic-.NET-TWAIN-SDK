using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using Dynamsoft.TWAIN;
using Dynamsoft.TWAIN.Interface;
using Dynamsoft.Core;

namespace WpfControlsDemo
{
    /// <summary>
    /// Interaction logic for ScanWindow.xaml
    /// </summary>
    public partial class ScanWindow : Window,Dynamsoft.TWAIN.Interface.IAcquireCallback
    {
        private TextBox m_TotalImageTextBox = null;

        public void SetTotalImageTextBox(TextBox tbx)
        {
            m_TotalImageTextBox = tbx;
        }

        private TextBox m_CurrentImageTextBox = null;

        public void SetCurrentImageTextBox(TextBox tbx)
        {
            m_CurrentImageTextBox = tbx;
        }

        public ScanWindow()
        {
            InitializeComponent();
            try
            {
                lbScan.Background = new ImageBrush(new BitmapImage(new Uri(Window1.imageDirectory + @"normal\scan_now.png", UriKind.RelativeOrAbsolute)));
            }
            catch{ }
            lbScan.IsEnabled = false;
            this.Closing += new System.ComponentModel.CancelEventHandler(ScanWindow_Closing);
            m_RefreshInfo = new RefreshImageBufferInfo(RefreshInfo);
        }

        void ScanWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (twain != null)
            {
                //if (twain.DataSourceStatus == Dynamsoft.DotNet.TWAIN.Enums.TWDataSourceStatus.TWDSS_ACQUIRING)
                if(twain.DataSourceStatus == Dynamsoft.TWAIN.Enums.TWDataSourceStatus.TWDSS_ACQUIRING)
                {
                    e.Cancel = true;
                    MessageBox.Show("There are some uncompleted scanning tasks. Please wait until the tasks completes.", "WpfControlsDemo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    twain.CloseSource();
                    twain.CloseSourceManager();
                }
            }
        }

        private TwainManager twain = null;

        public Dynamsoft.TWAIN.TwainManager TWAIN
        {
            set { 
                twain = value; 
                if (twain != null)
                {
                    for (int i = 0; i < twain.SourceCount; i ++)
                    {
                        cbxSources.Items.Add(twain.SourceNameItems((short)i));
                    }
                    if (twain.SourceCount > 0)
                    {
                        cbxSources.SelectedIndex = 0;
                        lbScan.IsEnabled = true;
                    }
                    else
                    {
                        MessageBox.Show("There is no scan source!", "Scan Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        lbScan.IsEnabled = false;
                    }
                }
            }
        }

        private ImageCore m_CoreForImageThum = null;
        public ImageCore CoreForImageThum
        {
            set
            {
                m_CoreForImageThum = value;
            }
        }

        private ImageCore m_CoreForViewer = null;
        public ImageCore CoreForImageViewer
        { 
            set
            {
                m_CoreForViewer = value;
            }
        }

        private void lbScan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string key = "active/" + "scan_now";
            if (!Window1.icons.ContainsKey(key))
            {
                try
                {
                    Window1.icons.Add(key, new ImageBrush(new BitmapImage(new Uri(Window1.imageDirectory + key + ".png", UriKind.RelativeOrAbsolute))));
                }
                catch { }
            }
            try
            {
                lbScan.Background = Window1.icons[key];
            }
            catch { }

            if (twain != null)
            {
                if (!IsFrameworkSatisfied())
                {
                    MessageBox.Show("WPF requires .NET Framework 3.5 SP1 or above. Please upgrade your .NET Framework.", "WpfControlsDemo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }                
                twain.SelectSourceByIndex(cbxSources.SelectedIndex);
                twain.OpenSource();
                twain.IfDisableSourceAfterAcquire = true;
                twain.IfShowUI = ckbShowUI.IsChecked.Value;
                twain.IfFeederEnabled = ckbADF.IsChecked.Value;
                twain.IfDuplexEnabled = ckbDuplex.IsChecked.Value;
                if (rbBW.IsChecked.Value)
                {
                    twain.PixelType = Dynamsoft.TWAIN.Enums.TWICapPixelType.TWPT_BW;
                    twain.BitDepth = 1;
                }
                else if (rbGrey.IsChecked.Value)
                {
                    twain.PixelType = Dynamsoft.TWAIN.Enums.TWICapPixelType.TWPT_GRAY;
                    twain.BitDepth = 8;
                }
                else if (rbColorful.IsChecked.Value)
                {
                    twain.PixelType = Dynamsoft.TWAIN.Enums.TWICapPixelType.TWPT_RGB;
                    twain.BitDepth = 24;
                }
                twain.AcquireImage(this as IAcquireCallback);
            }
        }

        private void lbScan_MouseEnter(object sender, MouseEventArgs e)
        {
            string key = "hover/" + "scan_now";
            if (!Window1.icons.ContainsKey(key))
            {
                try
                {
                    Window1.icons.Add(key, new ImageBrush(new BitmapImage(new Uri(Window1.imageDirectory + key + ".png", UriKind.RelativeOrAbsolute))));
                }
                catch { }
            }
            try
            {
                lbScan.Background = Window1.icons[key];
            }
            catch { }
        }

        private void lbScan_MouseLeave(object sender, MouseEventArgs e)
        {
            string key = "normal/" + "scan_now";
            if (!Window1.icons.ContainsKey(key))
            {
                try
                {
                    Window1.icons.Add(key, new ImageBrush(new BitmapImage(new Uri(Window1.imageDirectory + key + ".png", UriKind.RelativeOrAbsolute))));
                }
                catch { }
            }
            try
            {
                lbScan.Background = Window1.icons[key];
            }
            catch { }
        }

        private bool IsFrameworkSatisfied()
        {
            int iMajorVersion = Environment.Version.Major;
            if (iMajorVersion == 2)
            {
                RegistryKey msKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
                if (msKey == null)
                    return false;
                RegistryKey netVersion = msKey.OpenSubKey("v3.5");
                if (netVersion.GetValue("Install") != null)
                {
                    if (netVersion.GetValue("Install").ToString() == "1")
                    {
                        object objSP = netVersion.GetValue("SP");
                        if (objSP != null && objSP.ToString().CompareTo("0") > 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            return true;
        }

        #region IAcquireCallback Members

        public void OnPostAllTransfers()
        {
        }

        public delegate void RefreshImageBufferInfo(int sCurrentIndex, int sTotalImageCount);
        private RefreshImageBufferInfo m_RefreshInfo;


        private void RefreshInfo(int sCurrentIndex, int sTotalImageCount)
        {
            m_TotalImageTextBox.Text = sTotalImageCount.ToString();
            m_CurrentImageTextBox.Text = sCurrentIndex.ToString();
        }

        public bool OnPostTransfer(System.Drawing.Bitmap bit)
        {
            if (m_CoreForImageThum != null)
            {
                m_CoreForImageThum.IO.LoadImage(bit);
                m_RefreshInfo((m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer + 1), m_CoreForImageThum.ImageBuffer.HowManyImagesInBuffer);
            }

            if (m_CoreForViewer != null)
            {
                if (m_CoreForViewer.ImageBuffer.CurrentImageIndexInBuffer == -1)
                    m_CoreForViewer.IO.LoadImage(m_CoreForImageThum.ImageBuffer.GetBitmap(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer));
                else
                {
                    m_CoreForViewer.ImageBuffer.SetBitmap(m_CoreForViewer.ImageBuffer.CurrentImageIndexInBuffer, m_CoreForImageThum.ImageBuffer.GetBitmap(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer));
                }

            }
            return true;
        }

        public void OnPreAllTransfers()
        {
        }

        public bool OnPreTransfer()
        {
            return true;
        }

        public void OnSourceUIClose()
        {
        }

        public void OnTransferCancelled()
        {
        }

        public void OnTransferError()
        {
        }

        #endregion
    }
}
