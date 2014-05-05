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

namespace WpfControlsDemo
{
    /// <summary>
    /// Interaction logic for SaveWindow.xaml
    /// </summary>
    public partial class SaveWindow : Window
    {
        public SaveWindow()
        {
            InitializeComponent();
             try
            {
                lbSave.Background = new ImageBrush(new BitmapImage(new Uri(Window1.imageDirectory + @"normal\save_now.png", UriKind.RelativeOrAbsolute)));
            }
            catch{ }
            lbSave.IsEnabled = true;
            this.txtFileName.Text = "DNTImage";
            this.rbJPG.IsChecked = true;
            this.chkMultiPage.IsEnabled = false;
        }

        private Dynamsoft.DotNet.TWAIN.Wpf.DynamicDotNetTwain twain = null;

        public Dynamsoft.DotNet.TWAIN.Wpf.DynamicDotNetTwain TWAIN
        {
            set { 
                twain = value;            
            }
        }

        private void lbSave_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string key = "active/" + "save_now";
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
                lbSave.Background = Window1.icons[key];
            }
            catch { }

            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            string fileName = txtFileName.Text.Trim();
            if (VerifyFileName(fileName))
            {
                saveFileDialog.FileName = this.txtFileName.Text;

                if ((bool)rbJPG.IsChecked.GetValueOrDefault() == true)
                {
                    saveFileDialog.Filter = "JPEG|*.JPG;*.JPEG;*.JPE;*.JFIF";
                    saveFileDialog.DefaultExt = "jpg";
                    if ((bool)saveFileDialog.ShowDialog().GetValueOrDefault() == true)
                    {
                        twain.SaveAsJPEG(saveFileDialog.FileName, twain.CurrentImageIndexInBuffer);
                    }
                }
                if ((bool)rbBMP.IsChecked.GetValueOrDefault() == true)
                {
                    saveFileDialog.Filter = "BMP|*.BMP";
                    saveFileDialog.DefaultExt = "bmp";
                    if ((bool)saveFileDialog.ShowDialog().GetValueOrDefault() == true)
                    {
                        twain.SaveAsBMP(saveFileDialog.FileName, twain.CurrentImageIndexInBuffer);
                    }
                }
                if ((bool)rbPNG.IsChecked.GetValueOrDefault() == true)
                {
                    saveFileDialog.Filter = "PNG|*.PNG";
                    saveFileDialog.DefaultExt = "png";
                    if ((bool)saveFileDialog.ShowDialog().GetValueOrDefault() == true)
                    {
                        twain.SaveAsPNG(saveFileDialog.FileName, twain.CurrentImageIndexInBuffer);
                    }
                }
                if ((bool)rbTIFF.IsChecked.GetValueOrDefault() == true)
                {
                    saveFileDialog.Filter = "TIFF|*.TIF;*.TIFF";
                    saveFileDialog.DefaultExt = "tiff";
                    if ((bool)saveFileDialog.ShowDialog().GetValueOrDefault() == true)
                    {
                        // Multi page TIFF
                        if (chkMultiPage.IsChecked == true)
                        {
                            twain.SaveAllAsMultiPageTIFF(saveFileDialog.FileName);
                        }
                        else
                        {
                            twain.SaveAsTIFF(saveFileDialog.FileName, twain.CurrentImageIndexInBuffer);
                        }
                    }
                }
                if ((bool)rbPDF.IsChecked.GetValueOrDefault() == true)
                {
                    saveFileDialog.Filter = "PDF|*.PDF";
                    saveFileDialog.DefaultExt = "pdf";
                    if ((bool)saveFileDialog.ShowDialog().GetValueOrDefault() == true)
                    {
                        // Multi page PDF
                        if (chkMultiPage.IsChecked == true)
                        {
                            twain.SaveAllAsPDF(saveFileDialog.FileName);
                        }
                        else
                        {
                            twain.SaveAsPDF(saveFileDialog.FileName, twain.CurrentImageIndexInBuffer);
                        }
                    }
                }
            }
            else
            {
                this.txtFileName.Focus();
            }
        }

        private void lbSave_MouseEnter(object sender, MouseEventArgs e)
        {
            string key = "hover/" + "save_now";
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
                lbSave.Background = Window1.icons[key];
            }
            catch { }
        }

        private void lbSave_MouseLeave(object sender, MouseEventArgs e)
        {
            string key = "normal/" + "save_now";
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
                lbSave.Background = Window1.icons[key];
            }
            catch { }
        }

        /// <summary>
        /// Verified the file name. If the file name is ok, return true, else return false.
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <returns></returns>
        private bool VerifyFileName(string fileName)
        {
            for (int i = 0; i < fileName.Length; i++)
            {
                if (!(char.IsLetterOrDigit(fileName[i]) || fileName[i] == '_' || fileName[i] == ' '))
                    return false;
            }
            return true;
        }

        private void rbJPG_Checked(object sender, RoutedEventArgs e)
        {
            SetMultiPage(false);
        }

        private void rbBMP_Checked(object sender, RoutedEventArgs e)
        {
            SetMultiPage(false);
        }

        private void rbPNG_Checked(object sender, RoutedEventArgs e)
        {
            SetMultiPage(false);
        }

        private void rbTIFF_Checked(object sender, RoutedEventArgs e)
        {
            SetMultiPage(true);
        }

        private void rbPDF_Checked(object sender, RoutedEventArgs e)
        {
            SetMultiPage(true);
        }

        private void SetMultiPage(bool bChecked)
        {
            this.chkMultiPage.IsChecked = bChecked;
            this.chkMultiPage.IsEnabled = bChecked;
        }
    }
}
