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
using Dynamsoft.DotNet.TWAIN.Wpf;
using Microsoft.Win32;

namespace WpfControlsDemo
{
    /// <summary>
    /// Interaction logic for ScanWindow.xaml
    /// </summary>
    public partial class ScanWindow : Window
    {
        public ScanWindow()
        {
            InitializeComponent();
            try
            {
                lbScan.Background = new ImageBrush(new BitmapImage(new Uri(Window1.imageDirectory + @"normal\scan_now.png", UriKind.RelativeOrAbsolute)));
            }
            catch{ }
            lbScan.IsEnabled = false;
        }

        private Dynamsoft.DotNet.TWAIN.Wpf.DynamicDotNetTwain twain = null;

        public DynamicDotNetTwain TWAIN
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
                twain.IfShowUI = ckbShowUI.IsChecked.Value;
                twain.IfFeederEnabled = ckbADF.IsChecked.Value;
                twain.IfDuplexEnabled = ckbDuplex.IsChecked.Value;
                if (rbBW.IsChecked.Value)
                {
                    twain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_BW;
                    twain.BitDepth = 1;
                }
                else if (rbGrey.IsChecked.Value)
                {
                    twain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_GRAY;
                    twain.BitDepth = 8;
                }
                else if (rbColorful.IsChecked.Value)
                {
                    twain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_RGB;
                    twain.BitDepth = 24;
                }
                twain.AcquireImage();
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
    }
}
