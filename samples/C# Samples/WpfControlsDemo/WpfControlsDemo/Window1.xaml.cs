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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Dynamsoft.Barcode;
using System.Runtime.InteropServices;
using System.IO;
using Dynamsoft.Core;
using Dynamsoft.WPF.Delegate;
using Dynamsoft.TWAIN;
using Dynamsoft.PDF;
using Dynamsoft.Core.Enums;
using Dynamsoft.OCR;
using System.Drawing;

namespace WpfControlsDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    
    public partial class Window1 : Window,IConvertCallback
    {
        static Window1()
        {
            
            int index = System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf("Samples");
            if (index != -1)
            {
                strCurrentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location.Substring(0, index);
                imageDirectory = strCurrentDirectory + @"Samples\Bin\Images\WpfDemoImages\";
                strTessdataDirectory = strCurrentDirectory + @"Samples\Bin";
             
            }
            else
            {
                index = System.Reflection.Assembly.GetExecutingAssembly().Location.LastIndexOf("\\");
                if (index != -1)
                {
                    strCurrentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location.Substring(0, index +1);
                }
                else
                    strCurrentDirectory = Environment.CurrentDirectory + "\\";
                imageDirectory = strCurrentDirectory + @"\Bin\Images\WpfDemoImages\";
                strTessdataDirectory = strCurrentDirectory + @"\Bin\";
            }
        }

        private ImageCore m_CoreForImageThum = null;
        private ImageCore m_CoreForImageViewer = null;
        private string m_StrProductKey = "t0068MgAAAENENwNWc7+efmkY+t7se6XaRPFZkvfB7QWiTjHiLykxngQdY09pzVtOvrefXBbVvYFbJSluECHlyxaOvHwUADk=";
        public Window1()
        {
            InitializeComponent();
            m_CoreForImageViewer = new ImageCore();
            m_CoreForImageThum = new ImageCore();
            m_TwainManager = new TwainManager(m_StrProductKey);
            dsViewer.Bind(m_CoreForImageViewer);
            dsViewerThum.Bind(m_CoreForImageThum);
            m_PDFRasterizer = new PDFRasterizer(m_StrProductKey);
            m_PDFCreator = new PDFCreator(m_StrProductKey);
            m_Tesseract = new Tesseract(m_StrProductKey);

            try
            {
                dpTitle.Background = new ImageBrush(new BitmapImage(new Uri(imageDirectory + "title.png", UriKind.RelativeOrAbsolute)));
                IconBitmapDecoder ibd = new IconBitmapDecoder(
                   new Uri(imageDirectory + "dnt_demo_icon.ico", UriKind.RelativeOrAbsolute),
                   BitmapCreateOptions.None,
                   BitmapCacheOption.Default);
                this.Icon = ibd.Frames[0];
            }
            catch { }
            dpTitle.MouseLeftButtonDown += new MouseButtonEventHandler(MoveWindow);

            dsViewerThum.MouseShape = true;
            dsViewerThum.SetViewMode(1, 4);
            dsViewerThum.AllowMultiSelect = true;
            dsViewerThum.OnMouseClick +=new OnMouseClickHandler(dsViewerThum_OnMouseClick);
            dsViewerThum.EnableKeyboardInteractive = false;
            dsViewerThum.OnViewerKeyDown += new KeyEventHandler(dsViewerThum_OnViewerKeyDown);
            string dynamicDotNetTwainDirectory = strCurrentDirectory;
            int index = System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf("Samples");

            dsViewer.MouseShape = false;
            dsViewer.SetViewMode(-1, -1);
            m_CoreForImageViewer.ImageBuffer.MaxImagesInBuffer = 1;
        }


        public static Dictionary<String, ImageBrush> icons = new Dictionary<string, ImageBrush>();
        public static readonly string imageDirectory;
        public static readonly string strCurrentDirectory;
        public static readonly string strTessdataDirectory;

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Name == "btnHand" && dsViewer.MouseShape)
            {
                return;
            }
            else if (btn.Name == "btnArrow" && !dsViewer.MouseShape)
            {
                return;
            }

            string key = "hover/" + btn.Tag;
            if (!icons.ContainsKey(key))
            {
                try
                {
                    icons.Add(key, new ImageBrush(new BitmapImage(new Uri(imageDirectory + key + ".png", UriKind.RelativeOrAbsolute))));
                }
                catch { }
            }
            try
            {
                btn.Background = icons[key];
            }
            catch { }
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Name == "btnHand" && dsViewer.MouseShape)
            {
                return;
            }
            else if (btn.Name == "btnArrow" && !dsViewer.MouseShape)
            {
                return;
            }

            string key = "normal/" + btn.Tag;
            if (!icons.ContainsKey(key))
            {
                try
                {
                    icons.Add(key, new ImageBrush(new BitmapImage(new Uri(imageDirectory + key + ".png", UriKind.RelativeOrAbsolute))));
                }
                catch { }
            }
            try
            {
                btn.Background = icons[key];
            }
            catch { }            
        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            Button_MouseLeave(sender, null);

            Button btn = (Button)sender;
            if (btn.Name == "btnHand" && dsViewer.MouseShape)
            {
                MouseButtonEventArgs args = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
                args.RoutedEvent = Button.PreviewMouseDownEvent;
                Button_PreviewMouseDown(sender, args);

                MouseEventArgs argsA = new MouseEventArgs(Mouse.PrimaryDevice, 0);
                argsA.RoutedEvent = Button.MouseLeaveEvent;
                Button_MouseLeave(btnArrow, argsA);
            }
            else if (btn.Name == "btnArrow" && !dsViewer.MouseShape)
            {
                MouseButtonEventArgs args = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
                args.RoutedEvent = Button.PreviewMouseDownEvent;
                Button_PreviewMouseDown(sender, args);

                MouseEventArgs argsA = new MouseEventArgs(Mouse.PrimaryDevice, 0);
                argsA.RoutedEvent = Button.MouseLeaveEvent;
                Button_MouseLeave(btnHand, argsA);
            }
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Button btn = (Button)sender;
                string key = "active/" + btn.Tag;
                if (!icons.ContainsKey(key))
                {
                    try
                    {
                        icons.Add(key, new ImageBrush(new BitmapImage(new Uri(imageDirectory + key + ".png", UriKind.RelativeOrAbsolute))));
                    }
                    catch { }
                }
                try
                {
                    btn.Background = icons[key];
                }
                catch { }
            }
        }

        private void Button_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Button_MouseLeave(sender, null);
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
            m_TwainManager.Dispose();
        }

        private void MaxWindow(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
        }

        private void MinWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void UpdateImageInfo()
        {
            if (m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer >= 0)
            {
                if (this.m_CoreForImageViewer.ImageBuffer.CurrentImageIndexInBuffer < 0)
                {
                    m_CoreForImageViewer.IO.LoadImage(m_CoreForImageThum.ImageBuffer.GetBitmap(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer));
                }
                else
                {
                    m_CoreForImageViewer.ImageBuffer.SetBitmap(this.m_CoreForImageViewer.ImageBuffer.CurrentImageIndexInBuffer, m_CoreForImageThum.ImageBuffer.GetBitmap(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer));
                }
             }

            tbCurrent.Text = (m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer + 1).ToString();
            tbAll.Text =  m_CoreForImageThum.ImageBuffer.HowManyImagesInBuffer.ToString();
        }

        void dsViewerThum_OnViewerKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.PageDown:
                case Key.PageUp:
                case Key.Home:
                case Key.End:
                case Key.Left:
                case Key.Right:
                case Key.Up:
                case Key.Down:
                    UpdateImageInfo();
                    break;
                default: break;
            }
        }

        private void dsViewerThum_OnMouseClick(object sender, OnMouseClickEventArgs e)
        {
            UpdateImageInfo();
        }

        private void dynamicDotNetTwainThum_OnPostAllTransfers(object sender, RoutedEventArgs e)
        {
            UpdateImageInfo();
        }

        private TwainManager m_TwainManager = null;
        private void Scan_Click(object sender, RoutedEventArgs e)
        {
            if (m_TwainManager.SourceCount > 0)
            {
                ScanWindow scanWnd = new ScanWindow();
                scanWnd.Owner = this;
                scanWnd.TWAIN = m_TwainManager;
                scanWnd.CoreForImageThum = m_CoreForImageThum;
                scanWnd.CoreForImageViewer = m_CoreForImageViewer;
                scanWnd.SetTotalImageTextBox(tbAll);
                scanWnd.SetCurrentImageTextBox(tbCurrent);
                scanWnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                scanWnd.ShowDialog();
            }
            else
            {
                MessageBox.Show("There is no scan source!", "Scan Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        
        private PDFRasterizer m_PDFRasterizer = null;
        private PDFCreator m_PDFCreator = null; 
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Supported Files(*.jpg;*.jpe;*.jpeg;*.jfif;*.bmp;*.png;*.tif;*.tiff;*.pdf;*.gif)|*.jpg;*.jpe;*.jpeg;*.jfif;*.bmp;*.png;*.tif;*.tiff;*.pdf;*.gif|JPEG(*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|BMP(*.bmp)|*.bmp|PNG(*.png)|*.png|TIFF(*.tif;*.tiff)|*.tif;*.tiff|PDF(*.pdf)|*.pdf|GIF(*.gif)|*.gif";
            dlg.Multiselect = true;
            if (dlg.ShowDialog().Value)
            {
                foreach (String strFileName in dlg.FileNames)
                {
                    int pos = strFileName.LastIndexOf(".");
                    if (pos != -1)
                    {
                        string strSuffix = strFileName.Substring(pos, strFileName.Length - pos).ToLower();
                        if (strSuffix.CompareTo(".pdf") == 0)
                        {
                            m_PDFRasterizer.ConvertMode = Dynamsoft.PDF.Enums.EnumConvertMode.enumCM_RENDERALL;
                            m_PDFRasterizer.ConvertToImage(strFileName,"",200,this as IConvertCallback);
                            continue;
                        }
                    }
                    m_CoreForImageThum.IO.LoadImage(strFileName);
                }
                UpdateImageInfo();
            }
        }

        private void Barcode_Click(object sender, RoutedEventArgs e)
        {
            if (m_CoreForImageThum.ImageBuffer.HowManyImagesInBuffer > 0)
            {
                System.Drawing.Bitmap bmp = null;
                try
                {
                    BarcodeReader reader = new BarcodeReader();
                    reader.LicenseKeys = m_StrProductKey;
                    BarcodeResult[] aryResult = reader.DecodeBitmap(m_CoreForImageThum.ImageBuffer.GetBitmap(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer));
                    if (aryResult == null)
                    {
                        string strResult = "The barcode for selected format is not found." + "\r\n";
                        MessageBox.Show(strResult, "Barcodes Results");
                    }
                    else
                    {
                        string strResult = aryResult.Length + " total barcode found." + "\r\n";
                        for (int i = 0; i < aryResult.Length; i++)
                        {
                            strResult += String.Format("Result {0}\r\n Barcode Format: {1}    Barcode Text: {2}\r\n", (i + 1), aryResult[i].BarcodeFormat, aryResult[i].BarcodeText);

                        }
                        MessageBox.Show(strResult, "Barcodes Results");
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "Decoding Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (bmp != null)
                        bmp.Dispose();
                }
            }
        }


        private Tesseract m_Tesseract = null; 
        private void OCR_Click(object sender, RoutedEventArgs e)
        {
            if (dsViewerThum.CurrentSelectedImageIndicesInBuffer.Count > 1 ||
            (dsViewerThum.CurrentSelectedImageIndicesInBuffer.Count == 1 &&
             dsViewerThum.CurrentSelectedImageIndicesInBuffer[0] >= 0))
            {
                m_Tesseract.ResultFormat = Dynamsoft.OCR.Enums.ResultFormat.Text;
                m_Tesseract.Language = "eng";
                m_Tesseract.TessDataPath = strTessdataDirectory;
                List<short> tempListIndex = dsViewerThum.CurrentSelectedImageIndicesInBuffer;
                List<Bitmap> tempListBitmap = null;
                if (tempListIndex != null)
                {
                    if (tempListBitmap == null)
                        tempListBitmap = new List<Bitmap>();
                    foreach (short sIndex in tempListIndex)
                    {
                        tempListBitmap.Add(m_CoreForImageThum.ImageBuffer.GetBitmap(sIndex));
                    }
                }
                byte[] bytes = m_Tesseract.Recognize(tempListBitmap);
                if (bytes != null)
                {
                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.Filter = "Text File(*.txt)|*.txt";
                    if (dlg.ShowDialog().Value)
                    {
                        System.IO.File.WriteAllBytes(dlg.FileName, bytes);
                    }
                }
            }
        }

        private void Hand_Click(object sender, RoutedEventArgs e)
        {
            dsViewer.MouseShape = true;
            MouseButtonEventArgs args = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
            args.RoutedEvent = Button.PreviewMouseDownEvent;
            Button_PreviewMouseDown(sender, args);

            MouseEventArgs argsA = new MouseEventArgs(Mouse.PrimaryDevice, 0);
            argsA.RoutedEvent = Button.MouseLeaveEvent;
            Button_MouseLeave(btnArrow, argsA);
        }

        private void Arrow_Click(object sender, RoutedEventArgs e)
        {
            dsViewer.MouseShape = false;
            MouseButtonEventArgs args = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
            args.RoutedEvent = Button.PreviewMouseDownEvent;
            Button_PreviewMouseDown(sender, args);

            MouseEventArgs argsA = new MouseEventArgs(Mouse.PrimaryDevice, 0);
            argsA.RoutedEvent = Button.MouseLeaveEvent;
            Button_MouseLeave(btnHand, argsA);
        }

        private void Zoom_Click(object sender, RoutedEventArgs e)
        {
            ZoomWindow zoomWnd = new ZoomWindow(dsViewer.Zoom);
            zoomWnd.Owner = this;
            if (zoomWnd.ShowDialog().Value)
            {
                dsViewer.Zoom = zoomWnd.ZoomRatio;
            }
        }

        private void Switch_Click(object sender, RoutedEventArgs e)
        {

            if (dsViewerThum.CurrentSelectedImageIndicesInBuffer.Count != 2)
            {
                MessageBox.Show("Please select two images before switching. You can select multiple images by pressing CTRL key and clicking mouse.", "switch warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                m_CoreForImageThum.ImageBuffer.SwitchImage((short)(dsViewerThum.CurrentSelectedImageIndicesInBuffer[0]), (short)(dsViewerThum.CurrentSelectedImageIndicesInBuffer[1]));

                UpdateImageInfo();
            }
        }

        private void RotateRight_Click(object sender, RoutedEventArgs e)
        {
            if (m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer >= 0)
            {
                m_CoreForImageThum.ImageProcesser.RotateRight(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer);
            }
            UpdateImageInfo();
        }

        private void RotateLeft_Click(object sender, RoutedEventArgs e)
        {
            if (m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer >= 0)
            {
                m_CoreForImageThum.ImageProcesser.RotateLeft(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer);
                UpdateImageInfo();
            }
        }

        private void Mirror_Click(object sender, RoutedEventArgs e)
        {
            if (m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer >= 0)
            {
                m_CoreForImageThum.ImageProcesser.Mirror(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer);
                UpdateImageInfo();
            }
        }

        private void Flip_Click(object sender, RoutedEventArgs e)
        {
            if (m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer>= 0)
            {
                m_CoreForImageThum.ImageProcesser.Flip(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer);
                UpdateImageInfo();
            }
        }

        private void FitWindow_Click(object sender, RoutedEventArgs e)
        {
            dsViewer.IfFitWindow = true;
        }

        private void OriginalSize_Click(object sender, RoutedEventArgs e)
        {
            dsViewer.Zoom = 1;
            dsViewer.IfFitWindow = false;
        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            short index = m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer;
            if (index >= 0)
            {
                Rect rect = dsViewer.GetSelectionRect(m_CoreForImageViewer.ImageBuffer.CurrentImageIndexInBuffer);
                if (rect!=null)
                {
                    if (rect.Height != 0 && rect.Width != 0)
                    {
                        m_CoreForImageThum.ImageProcesser.CutFrameToClipborad(index, (int)rect.Left, (int)rect.Top, (int)rect.Right, (int)rect.Bottom);
                        UpdateImageInfo();
                    }
                }
            }
        }


        private void Crop_Click(object sender, RoutedEventArgs e)
        {
            short index = m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer;
            if (index >= 0)
            {
                Rect rect = dsViewer.GetSelectionRect(m_CoreForImageViewer.ImageBuffer.CurrentImageIndexInBuffer);
                if(rect!=null)
                {
                    if(rect.Height!=0&&rect.Width!=0)
                    {
                        m_CoreForImageThum.ImageProcesser.Crop(index, (int)rect.Left, (int)rect.Top, (int)rect.Right, (int)rect.Bottom);
                        UpdateImageInfo();
                    }

                }

            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            short index = m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer;
            if (index >= 0)
            {
                m_CoreForImageThum.ImageBuffer.RemoveImage(index);
                m_CoreForImageViewer.ImageBuffer.RemoveAllImages();
                UpdateImageInfo();
            }
        }

        private void DeleteAll_Click(object sender, RoutedEventArgs e)
        {
            if (m_CoreForImageThum.ImageBuffer.HowManyImagesInBuffer > 0)
                m_CoreForImageThum.ImageBuffer.RemoveAllImages();
            if (m_CoreForImageViewer.ImageBuffer.HowManyImagesInBuffer > 0)
                m_CoreForImageViewer.ImageBuffer.RemoveAllImages();
            UpdateImageInfo();
        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            if (m_CoreForImageThum.ImageBuffer.HowManyImagesInBuffer > 0)
            {
                m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer = (short)0;
                UpdateImageInfo();
            }
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer > 0)
            {
                m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer = (short)(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer - 1);
                UpdateImageInfo();
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer < m_CoreForImageThum.ImageBuffer.HowManyImagesInBuffer - 1)
            {
                 m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer = (short)(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer + 1);
                UpdateImageInfo();
            }
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            if (m_CoreForImageThum.ImageBuffer.HowManyImagesInBuffer > 0)
            {
                m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer = (short)(m_CoreForImageThum.ImageBuffer.HowManyImagesInBuffer - 1);
                UpdateImageInfo();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveWindow saveWnd = new SaveWindow();
                saveWnd.Owner = this;
                saveWnd.Core = m_CoreForImageThum;
                saveWnd.PDFCreator = m_PDFCreator;
                saveWnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                saveWnd.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #region IConvertCallback Members

        public void LoadConvertResult(ConvertResult result)
        {
            m_CoreForImageThum.IO.LoadImage(result.Image);
        }

        #endregion

    }
}
