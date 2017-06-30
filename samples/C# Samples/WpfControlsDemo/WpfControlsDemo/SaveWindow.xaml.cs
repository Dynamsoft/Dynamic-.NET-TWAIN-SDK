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
using Dynamsoft.Core;
using Dynamsoft.PDF;
using Dynamsoft.Core.Enums;


namespace WpfControlsDemo
{
    /// <summary>
    /// Interaction logic for SaveWindow.xaml
    /// </summary>
    public partial class SaveWindow : Window,ISave
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

        private ImageCore m_ImageCore = null; 
        public ImageCore Core
        {
            set 
            {
                m_ImageCore = value;
            }
        }

        private PDFCreator m_PDFCreator = null;
        public PDFCreator PDFCreator
        {
            set
            {
                m_PDFCreator = value;
            }
        }

        private void lbSave_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer == 0)
            {
                MessageBox.Show("There is no images in the buffer.");
                return;
            }
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
                        try
                        {
                            m_ImageCore.IO.SaveAsJPEG(saveFileDialog.FileName, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                if ((bool)rbBMP.IsChecked.GetValueOrDefault() == true)
                {
                    saveFileDialog.Filter = "BMP|*.BMP";
                    saveFileDialog.DefaultExt = "bmp";
                    if ((bool)saveFileDialog.ShowDialog().GetValueOrDefault() == true)
                    {
                        m_ImageCore.IO.SaveAsBMP(saveFileDialog.FileName,m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                    }
                }
                if ((bool)rbPNG.IsChecked.GetValueOrDefault() == true)
                {
                    saveFileDialog.Filter = "PNG|*.PNG";
                    saveFileDialog.DefaultExt = "png";
                    if ((bool)saveFileDialog.ShowDialog().GetValueOrDefault() == true)
                    {
                        m_ImageCore.IO.SaveAsPNG(saveFileDialog.FileName,m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                    }
                }
                if ((bool)rbTIFF.IsChecked.GetValueOrDefault() == true)
                {
                    saveFileDialog.Filter = "TIFF|*.TIF;*.TIFF";
                    saveFileDialog.DefaultExt = "tiff";
                    if ((bool)saveFileDialog.ShowDialog().GetValueOrDefault() == true)
                    {
                        // Multi page TIFF
                        List<short> tempListIndex = new List<short>();
                        if (chkMultiPage.IsChecked == true)
                        {
                            for (short sIndex = 0; sIndex < m_ImageCore.ImageBuffer.HowManyImagesInBuffer; sIndex++)
                            {
                                tempListIndex.Add(sIndex);
                            }
                        }
                        else
                        {
                            tempListIndex.Add(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                        }
                        m_ImageCore.IO.SaveAsTIFF(saveFileDialog.FileName, tempListIndex);
                    }
                }
                if ((bool)rbPDF.IsChecked.GetValueOrDefault() == true)
                {
                    saveFileDialog.Filter = "PDF|*.PDF";
                    saveFileDialog.DefaultExt = "pdf";
                    if ((bool)saveFileDialog.ShowDialog().GetValueOrDefault() == true)
                    {
                        m_PDFCreator.Save(this as ISave,saveFileDialog.FileName);
                        
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
            try
            {
                if (fileName.LastIndexOfAny(System.IO.Path.GetInvalidFileNameChars()) == -1)
                    return true;
            }
            catch (Exception e)
            {
            }
            MessageBox.Show("The file name contains invalid chars!", "Save Image To File", MessageBoxButton.OK, MessageBoxImage.Information);
            return false;
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

        #region ISave Members

        public object GetAnnotations(int iPageNumber)
        {
            return null;
        }

        public System.Drawing.Bitmap GetImage(int iPageNumber)
        {
            if (chkMultiPage.IsChecked == true)
            {
                return m_ImageCore.ImageBuffer.GetBitmap((short)iPageNumber);
            }
            else
            {
                return m_ImageCore.ImageBuffer.GetBitmap((short)m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
            }
        }

        public int GetPageCount()
        {
            if(chkMultiPage.IsChecked == true)
            {
                return m_ImageCore.ImageBuffer.HowManyImagesInBuffer;
            }
            else
            {
                return 1;
            }
        }

        #endregion
    }
}
