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
using Dynamsoft.DotNet.TWAIN;
using Dynamsoft.DotNet.TWAIN.Barcode;
using Dynamsoft.Barcode;
using System.Runtime.InteropServices;
using System.IO;

namespace WpfControlsDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    
    public partial class Window1 : Window
    {
        static Window1()
        {
            
            int index = System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf("Samples");
            if (index != -1)
            {
                strCurrentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location.Substring(0, index);
                imageDirectory = strCurrentDirectory + @"Samples\Bin\Images\WpfDemoImages\";             
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
                imageDirectory = strCurrentDirectory + @"Images\WpfDemoImages\";
            }
        }
        public Window1()
        {
            InitializeComponent();
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

            dynamicDotNetTwainThum.MouseShape = true;
            dynamicDotNetTwainThum.SetViewMode(1, 4);
            dynamicDotNetTwainThum.AllowMultiSelect = true;
            dynamicDotNetTwainThum.OnMouseClick += new Dynamsoft.DotNet.TWAIN.OnMouseClickHandler(dynamicDotNetTwainThum_OnMouseClick);
            dynamicDotNetTwainThum.EnableKeyboardInteractive = false;
            dynamicDotNetTwainThum.OnDNTKeyDown += new KeyEventHandler(dynamicDotNetTwainThum_OnDNTKeyDown);
            dynamicDotNetTwainThum.OnPostAllTransfers += new OnPostAllTransfersHandler(dynamicDotNetTwainThum_OnPostAllTransfers);

            string dynamicDotNetTwainDirectory = strCurrentDirectory;
            int index = System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf("Samples");
            if (index != -1)
            {
                //dynamicDotNetTwainThum.BarcodeDllPath = dynamicDotNetTwainDirectory + @"Redistributable\Resources\BarcodeResources\";
                dynamicDotNetTwainThum.OCRDllPath = dynamicDotNetTwainDirectory + @"Redistributable\Resources\OCR\";
                dynamicDotNetTwainThum.OCRTessDataPath = dynamicDotNetTwainDirectory + @"Samples\Bin\";
                dynamicDotNetTwainThum.PDFRasterizerDllPath = dynamicDotNetTwainDirectory + @"Redistributable\Resources\PDF\";      
            }
            else
            {
                //dynamicDotNetTwainThum.BarcodeDllPath = dynamicDotNetTwainDirectory + @"Redistributable\Resources\BarcodeResources\";
                dynamicDotNetTwainThum.OCRDllPath = dynamicDotNetTwainDirectory + @"Redistributable\Resources\OCR\";
                dynamicDotNetTwainThum.OCRTessDataPath = dynamicDotNetTwainDirectory + @"Redistributable\";
                dynamicDotNetTwainThum.PDFRasterizerDllPath = dynamicDotNetTwainDirectory + @"Redistributable\Resources\PDF\";
            }
            dynamicDotNetTwainThum.IfShowCancelDialogWhenBarcodeOrOCR = true;
            dynamicDotNetTwainThum.ScanInNewProcess = true;
            //dynamicDotNetTwainThum.MaxImagesInBuffer = 32;
            dynamicDotNetTwainThum.LicenseKeys = "83C721A603BF5301ABCF850504F7B744;83C721A603BF5301AC7A3AA0DF1D92E6;83C721A603BF5301E22CBEC2DD20B511;83C721A603BF5301977D72EA5256A044;83C721A603BF53014332D52C75036F9E;83C721A603BF53010090AB799ED7E55E";

            dynamicDotNetTwainView.MouseShape = false;
            dynamicDotNetTwainView.SetViewMode(-1, -1);
            dynamicDotNetTwainView.MaxImagesInBuffer = 1;
            dynamicDotNetTwainView.ScanInNewProcess = true;
            dynamicDotNetTwainView.LicenseKeys = "83C721A603BF5301ABCF850504F7B744;83C721A603BF5301AC7A3AA0DF1D92E6;83C721A603BF5301E22CBEC2DD20B511;83C721A603BF5301977D72EA5256A044;83C721A603BF53014332D52C75036F9E;83C721A603BF53010090AB799ED7E55E";
        }       

        public static Dictionary<String, ImageBrush> icons = new Dictionary<string, ImageBrush>();
        public static readonly string imageDirectory;
        public static readonly string strCurrentDirectory;

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Name == "btnHand" && dynamicDotNetTwainView.MouseShape)
            {
                return;
            }
            else if (btn.Name == "btnArrow" && !dynamicDotNetTwainView.MouseShape)
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

            if (btn.Name == "btnHand" && dynamicDotNetTwainView.MouseShape)
            {
                return;
            }
            else if (btn.Name == "btnArrow" && !dynamicDotNetTwainView.MouseShape)
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
            if (btn.Name == "btnHand" && dynamicDotNetTwainView.MouseShape)
            {
                MouseButtonEventArgs args = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
                args.RoutedEvent = Button.PreviewMouseDownEvent;
                Button_PreviewMouseDown(sender, args);

                MouseEventArgs argsA = new MouseEventArgs(Mouse.PrimaryDevice, 0);
                argsA.RoutedEvent = Button.MouseLeaveEvent;
                Button_MouseLeave(btnArrow, argsA);
            }
            else if (btn.Name == "btnArrow" && !dynamicDotNetTwainView.MouseShape)
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
            Clipboard.Clear();
            if (dynamicDotNetTwainThum.CurrentImageIndexInBuffer >= 0)
            {
            	dynamicDotNetTwainThum.CopyToClipboard(dynamicDotNetTwainThum.CurrentImageIndexInBuffer);
            	dynamicDotNetTwainView.RemoveAllImages();
            	dynamicDotNetTwainView.LoadDibFromClipboard();
            	Clipboard.Clear();
             }

            tbCurrent.Text = (dynamicDotNetTwainThum.CurrentImageIndexInBuffer + 1).ToString();
            tbAll.Text = dynamicDotNetTwainThum.HowManyImagesInBuffer.ToString();
        }

        void dynamicDotNetTwainThum_OnDNTKeyDown(object sender, KeyEventArgs e)
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

        private void dynamicDotNetTwainThum_OnMouseClick(object sender, OnMouseClickEventArgs e)
        {
            UpdateImageInfo();
        }

        private void dynamicDotNetTwainThum_OnPostAllTransfers(object sender, RoutedEventArgs e)
        {
            UpdateImageInfo();
        }

        private void Scan_Click(object sender, RoutedEventArgs e)
        {
            if (dynamicDotNetTwainThum.SourceCount > 0)
            {
                ScanWindow scanWnd = new ScanWindow();
                scanWnd.Owner = this;
                scanWnd.TWAIN = dynamicDotNetTwainThum;
                scanWnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                scanWnd.ShowDialog();
            }
            else
            {
                MessageBox.Show("There is no scan source!", "Scan Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

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
                            this.dynamicDotNetTwainThum.PDFConvertMode = Dynamsoft.DotNet.TWAIN.Enums.EnumPDFConvertMode.enumCM_RENDERALL;
                            this.dynamicDotNetTwainThum.SetPDFResolution(200);
                            this.dynamicDotNetTwainThum.LoadImage(strFileName);
                            //this.dynamicDotNetTwainThum.ConvertPDFToImage(strFileName, 200);
                            continue;
                        }
                    }
                    dynamicDotNetTwainThum.LoadImage(strFileName);
                }
                UpdateImageInfo();
            }
        }

        private void Barcode_Click(object sender, RoutedEventArgs e)
        {
            if (dynamicDotNetTwainThum.HowManyImagesInBuffer > 0)
            {
                System.Drawing.Bitmap bmp = null;
                try
                {
                    BarcodeReader reader = new BarcodeReader();
                    reader.LicenseKeys = "91392547848AAF240620ADFEFDB2EDEB";
                    BarcodeResult[] aryResult = reader.DecodeBitmap(this.dynamicDotNetTwainThum.GetBitmap(this.dynamicDotNetTwainThum.CurrentImageIndexInBuffer));
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

        private void OCR_Click(object sender, RoutedEventArgs e)
        {
            if (dynamicDotNetTwainThum.CurrentSelectedImageIndicesInBuffer.Count > 1 ||
            (dynamicDotNetTwainThum.CurrentSelectedImageIndicesInBuffer.Count == 1 &&
            dynamicDotNetTwainThum.CurrentSelectedImageIndicesInBuffer[0] >= 0))
            {
                dynamicDotNetTwainThum.IfShowCancelDialogWhenBarcodeOrOCR = true;
                dynamicDotNetTwainThum.OCRResultFormat = Dynamsoft.DotNet.TWAIN.OCR.ResultFormat.Text;
                dynamicDotNetTwainThum.OCRLanguage = "eng";
                byte[] bytes = dynamicDotNetTwainThum.OCR(dynamicDotNetTwainThum.CurrentSelectedImageIndicesInBuffer);
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
            dynamicDotNetTwainView.MouseShape = true;

            MouseButtonEventArgs args = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
            args.RoutedEvent = Button.PreviewMouseDownEvent;
            Button_PreviewMouseDown(sender, args);

            MouseEventArgs argsA = new MouseEventArgs(Mouse.PrimaryDevice, 0);
            argsA.RoutedEvent = Button.MouseLeaveEvent;
            Button_MouseLeave(btnArrow, argsA);
        }

        private void Arrow_Click(object sender, RoutedEventArgs e)
        {
            dynamicDotNetTwainView.MouseShape = false;

            MouseButtonEventArgs args = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
            args.RoutedEvent = Button.PreviewMouseDownEvent;
            Button_PreviewMouseDown(sender, args);

            MouseEventArgs argsA = new MouseEventArgs(Mouse.PrimaryDevice, 0);
            argsA.RoutedEvent = Button.MouseLeaveEvent;
            Button_MouseLeave(btnHand, argsA);
        }

        private void Zoom_Click(object sender, RoutedEventArgs e)
        {
            ZoomWindow zoomWnd = new ZoomWindow(dynamicDotNetTwainView.Zoom);
            zoomWnd.Owner = this;
            if (zoomWnd.ShowDialog().Value)
            {
                dynamicDotNetTwainView.Zoom = zoomWnd.ZoomRatio;
            }
        }

        private void Switch_Click(object sender, RoutedEventArgs e)
        {
            if (dynamicDotNetTwainThum.CurrentSelectedImageIndicesInBuffer.Count != 2)
                MessageBox.Show("Please select two images before switching. You can select multiple images by pressing CTRL key and clicking mouse.", "switch warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
                dynamicDotNetTwainThum.SwitchImage((short)dynamicDotNetTwainThum.CurrentSelectedImageIndicesInBuffer[0], (short)dynamicDotNetTwainThum.CurrentSelectedImageIndicesInBuffer[1]);
            UpdateImageInfo();
        }

        private void RotateRight_Click(object sender, RoutedEventArgs e)
        {
            if (dynamicDotNetTwainThum.CurrentImageIndexInBuffer >= 0)
            {
                dynamicDotNetTwainThum.RotateRight(dynamicDotNetTwainThum.CurrentImageIndexInBuffer);
                UpdateImageInfo();
            }
        }

        private void RotateLeft_Click(object sender, RoutedEventArgs e)
        {
            if (dynamicDotNetTwainThum.CurrentImageIndexInBuffer >= 0)
            {
                dynamicDotNetTwainThum.RotateLeft(dynamicDotNetTwainThum.CurrentImageIndexInBuffer);
                UpdateImageInfo();
            }
        }

        private void Mirror_Click(object sender, RoutedEventArgs e)
        {
            if (dynamicDotNetTwainThum.CurrentImageIndexInBuffer >= 0)
            {
                dynamicDotNetTwainThum.Mirror(dynamicDotNetTwainThum.CurrentImageIndexInBuffer);
                UpdateImageInfo();
            }
        }

        private void Flip_Click(object sender, RoutedEventArgs e)
        {
            if (dynamicDotNetTwainThum.CurrentImageIndexInBuffer >= 0)
            {
                dynamicDotNetTwainThum.Flip(dynamicDotNetTwainThum.CurrentImageIndexInBuffer);
                UpdateImageInfo();
            }
        }

        private void FitWindow_Click(object sender, RoutedEventArgs e)
        {
            dynamicDotNetTwainView.IfFitWindow = true;
        }

        private void OriginalSize_Click(object sender, RoutedEventArgs e)
        {
            dynamicDotNetTwainView.Zoom = 1;
            dynamicDotNetTwainView.IfFitWindow = false;
        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            short index = dynamicDotNetTwainThum.CurrentImageIndexInBuffer;
            if (index >= 0)
            {
                Rect rect = dynamicDotNetTwainView.GetSelectionRect(dynamicDotNetTwainView.CurrentImageIndexInBuffer);
                dynamicDotNetTwainThum.CutFrameToClipboard(index, (int)rect.Left, (int)rect.Top, (int)rect.Right, (int)rect.Bottom);
                UpdateImageInfo();
            }
        }


        private void Crop_Click(object sender, RoutedEventArgs e)
        {
            short index = dynamicDotNetTwainThum.CurrentImageIndexInBuffer;
            if (index >= 0)
            {
                Rect rect = dynamicDotNetTwainView.GetSelectionRect(dynamicDotNetTwainView.CurrentImageIndexInBuffer);
                dynamicDotNetTwainThum.Crop(index, (int)rect.Left, (int)rect.Top, (int)rect.Right, (int)rect.Bottom);
                UpdateImageInfo();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            short index = dynamicDotNetTwainThum.CurrentImageIndexInBuffer;
            if (index >= 0)
            {
                dynamicDotNetTwainThum.RemoveImage(index);
                dynamicDotNetTwainView.RemoveImage(dynamicDotNetTwainView.CurrentImageIndexInBuffer);
                UpdateImageInfo();
            }
        }

        private void DeleteAll_Click(object sender, RoutedEventArgs e)
        {
            if (dynamicDotNetTwainThum.HowManyImagesInBuffer > 0)
                dynamicDotNetTwainThum.RemoveAllImages();
            if (dynamicDotNetTwainView.HowManyImagesInBuffer > 0)
                dynamicDotNetTwainView.RemoveAllImages();
            UpdateImageInfo();
        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            if (dynamicDotNetTwainThum.HowManyImagesInBuffer >= 0)
            {
                dynamicDotNetTwainThum.CurrentImageIndexInBuffer = (short)0;
                UpdateImageInfo();
            }
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (dynamicDotNetTwainThum.CurrentImageIndexInBuffer > 0)
            {
                dynamicDotNetTwainThum.CurrentImageIndexInBuffer = (short)(dynamicDotNetTwainThum.CurrentImageIndexInBuffer - 1);
                UpdateImageInfo();
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (dynamicDotNetTwainThum.CurrentImageIndexInBuffer < dynamicDotNetTwainThum.HowManyImagesInBuffer-1)
            {
                dynamicDotNetTwainThum.CurrentImageIndexInBuffer = (short)(dynamicDotNetTwainThum.CurrentImageIndexInBuffer + 1);
                UpdateImageInfo();
            }
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            if (dynamicDotNetTwainThum.HowManyImagesInBuffer > 0)
            {
                dynamicDotNetTwainThum.CurrentImageIndexInBuffer = (short)(dynamicDotNetTwainThum.HowManyImagesInBuffer - 1);
                UpdateImageInfo();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveWindow saveWnd = new SaveWindow();
            saveWnd.Owner = this;
            saveWnd.TWAIN = dynamicDotNetTwainThum;
            saveWnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            saveWnd.ShowDialog();
        }
    }
}
