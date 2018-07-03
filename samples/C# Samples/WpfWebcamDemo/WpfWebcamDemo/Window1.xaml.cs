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
using Dynamsoft.Core;
using Dynamsoft.UVC;
using System.Windows.Interop;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Dynamsoft.Common;

namespace WpfWebcamDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private int m_iRotate = 0;
        private string m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU=";
        private ImageCore m_ImageCore = null;
        private CameraManager m_CameraManager = null;
        private Camera m_Camera = null;
        public static Dictionary<String, ImageBrush> icons = new Dictionary<string, ImageBrush>();
        public static readonly string imageDirectory;
        public static readonly string strCurrentDirectory;
        private Window m_ControlWindow;
        private delegate void RefreshDelegate(System.Windows.Media.Imaging.BitmapImage temp);
        private RefreshDelegate m_Refresh;
        static Window1()
        {
            int index = System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf("Samples");
            if (index != -1)
            {
                strCurrentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location.Substring(0, index);
                imageDirectory = strCurrentDirectory + @"Samples\Bin\Images\WpfWebCamDemoImages\";

            }
            else
            {
                index = System.Reflection.Assembly.GetExecutingAssembly().Location.LastIndexOf("\\");
                if (index != -1)
                {
                    strCurrentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location.Substring(0, index + 1);
                }
                else
                {
                    strCurrentDirectory = Environment.CurrentDirectory + "\\";
                }
                imageDirectory = strCurrentDirectory + @"\Bin\Images\WpfWebCamDemoImages\";
            }
        }
        public Window1()
        {
            InitializeComponent();
            m_ImageCore = new ImageCore();
            dSViewer1.Bind(m_ImageCore);
            m_CameraManager = new CameraManager(m_StrProductKey);
            this.cbxSources.SelectionChanged += cbxSources_SelectionChanged;
            cbxSources.SelectedIndex = 0;

            this.Loaded += new RoutedEventHandler(Window1_Loaded);
            this.cbxSources.SelectionChanged += new SelectionChangedEventHandler(cbxSources_SelectionChanged);
            btnRotate90.Background = new ImageBrush(new BitmapImage(new Uri(imageDirectory + "90_normal.png", UriKind.RelativeOrAbsolute)));
            btnRotate180.Background = new ImageBrush(new BitmapImage(new Uri(imageDirectory + "180_normal.png", UriKind.RelativeOrAbsolute)));
            btnRotate270.Background = new ImageBrush(new BitmapImage(new Uri(imageDirectory + "270_normal.png", UriKind.RelativeOrAbsolute)));

            m_Refresh += new RefreshDelegate(RefreshImage);
            m_ControlWindow = Window.GetWindow(image1);
        }

        private void cbxSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (m_CameraManager.GetCameraNames() != null)
            {
                if (((ComboBox)sender).SelectedIndex >= 0 && ((ComboBox)sender).SelectedIndex < m_CameraManager.GetCameraNames().Count)
                {
                    m_Camera = m_CameraManager.SelectCamera((short)cbxSources.SelectedIndex);
                    m_Camera.Open();
                    m_Camera.OnFrameCaptrue += m_Camera_OnFrameCaptrue;
                    ResizePictureBox();
                }
            }
            if (m_Camera != null)
            {
                cbxResolution.Items.Clear();
                foreach(CamResolution camR in m_Camera.SupportedResolutions)
                {
                    cbxResolution.Items.Add(camR.ToString());
                }
                if (cbxResolution.Items.Count > 0)
                {
                    cbxResolution.SelectedIndex = 0;
                }
                ResizePictureBox();
            }

        }
        private void cbxResolution_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxResolution.SelectedValue != null)
            { 
                string[] strWXH = cbxResolution.SelectedValue.ToString().Split(new char[] { ' ' });
                if (strWXH.Length == 3)
                {
                    try
                    {
                        m_Camera.CurrentResolution = new CamResolution(int.Parse(strWXH[0]), int.Parse(strWXH[2]));
                    }
                    catch { }
                }
                m_Camera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_0);
                ResizePictureBox();
            }
        }
        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if(m_CameraManager.GetCameraNames()!=null)
                {
                    foreach (string temp in m_CameraManager.GetCameraNames())
                    {
                        this.cbxSources.Items.Add(temp);
                    }
                    if (cbxSources.Items.Count > 0)
                    {
                        cbxSources.SelectedIndex = 0;
                    }
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnCaptureImage_Click(object sender, RoutedEventArgs e)
        {
            if (m_Camera != null)
            {
                m_Camera.Open();
                Bitmap temp = m_Camera.GrabImage();
                m_ImageCore.IO.LoadImage(temp);
            }
        }

        private void btnRemoveAllImage_Click(object sender, RoutedEventArgs e)
        {
            m_ImageCore.ImageBuffer.RemoveAllImages();
        }
        private void ResizePictureBox()
        {
            if (m_Camera != null)
            {
                CamResolution camResolution = m_Camera.CurrentResolution;
                if (camResolution != null && camResolution.Width > 0 && camResolution.Height > 0)
                {
                    {
                        double iVideoWidth = border1.Width;
                        double iVideoHeight = border1.Width * camResolution.Height / camResolution.Width;
                        if (iVideoHeight < border1.Height)
                        {
                            image1.Margin = new Thickness(0, (border1.Height - iVideoHeight) / 2, 0, 0);
                            image1.Width = iVideoWidth;
                            image1.Height = iVideoHeight;
                        }
                        else
                        {
                            image1.Margin = new Thickness(0, 0, 0, 0);
                            image1.Width = iVideoWidth;
                            image1.Height = iVideoHeight;
                        }
                    }
                }
            }
        }
        private void RotatePictureBox()
        {
            if(m_Camera!= null)
            {
                CamResolution camResolution = m_Camera.CurrentResolution;
                if (camResolution != null && camResolution.Width > 0 && camResolution.Height > 0)
                {
                    if (camResolution.Width / camResolution.Height > border1.Width / border1.Height)
                    {
                        double iVideoHeight = border1.Height;
                        double iVideoWidth = border1.Height * camResolution.Height / camResolution.Width;
                        image1.Margin = new Thickness((border1.Width - iVideoWidth) / 2, 0, 0, 0);
                        image1.Width = iVideoWidth;
                        image1.Height = iVideoHeight;
                    }
                    else
                    {
                        double iVideoWidth = border1.Width;
                        double iVideoHeight = border1.Width * camResolution.Width / camResolution.Height;
                        image1.Margin = new Thickness(0, (border1.Height - iVideoHeight) / 2, 0, 0);
                        image1.Width = iVideoWidth;
                        image1.Height = iVideoHeight;
                    }
                }
            }
        }
        private void RefreshImage(System.Windows.Media.Imaging.BitmapImage temp)
        {
            try
            {
                image1.Source = temp;
            }
            catch
            { }
        }

        private void m_Camera_OnFrameCaptrue(Bitmap bitmap)
        {
            System.Windows.Media.Imaging.BitmapImage m_Frame = new System.Windows.Media.Imaging.BitmapImage();
            using (var stream = new System.IO.MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                m_Frame.BeginInit();
                m_Frame.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                m_Frame.StreamSource = stream;
                m_Frame.EndInit();
                stream.SetLength(0);
                stream.Capacity = 0;
                stream.Dispose();

            }
            m_Frame.Freeze();
            m_ControlWindow.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.SystemIdle, m_Refresh, m_Frame);
        }
        private void SetPicture(System.Drawing.Image img)
        {
            Bitmap temp = ((Bitmap)(img)).Clone(new System.Drawing.Rectangle(0, 0, img.Width, img.Height), img.PixelFormat);
            MemoryStream ms = new MemoryStream();
            temp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = ms.GetBuffer();
            ms.Close();
            BitmapImage bitImage = new BitmapImage();
            bitImage.BeginInit();
            bitImage.StreamSource = new MemoryStream(bytes);
            bitImage.EndInit();
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate ()
            {
                image1.Source = bitImage;
            }, null);
        }
        
        private void btnRotate90_Click(object sender, RoutedEventArgs e)
        {
            m_Camera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_90);
            RotatePictureBox();
        }
        private void btnRotate180_Click(object sender, RoutedEventArgs e)
        {
            m_Camera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_180);
            ResizePictureBox();
        }
        private void btnRotate270_Click(object sender, RoutedEventArgs e)
        {
            m_Camera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_270);
            RotatePictureBox();
        }
        private void btnRotate90_MouseEnter(object sender, MouseEventArgs e)
        {
            btnRotate90.Background = new ImageBrush(new BitmapImage(new Uri(imageDirectory + "90_hover.png", UriKind.RelativeOrAbsolute)));
        }
        private void btnRotate180_MouseEnter(object sender, MouseEventArgs e)
        {
            btnRotate180.Background = new ImageBrush(new BitmapImage(new Uri(imageDirectory + "180_hover.png", UriKind.RelativeOrAbsolute)));
        }
        private void btnRotate270_MouseEnter(object sender, MouseEventArgs e)
        {
            btnRotate270.Background = new ImageBrush(new BitmapImage(new Uri(imageDirectory + "270_hover.png", UriKind.RelativeOrAbsolute)));
        }

        private void btnRotate90_MouseLeave(object sender, MouseEventArgs e)
        {
            btnRotate90.Background = new ImageBrush(new BitmapImage(new Uri(imageDirectory + "90_normal.png", UriKind.RelativeOrAbsolute)));
        }

        private void btnRotate180_MouseLeave(object sender, MouseEventArgs e)
        {
            btnRotate180.Background = new ImageBrush(new BitmapImage(new Uri(imageDirectory + "180_normal.png", UriKind.RelativeOrAbsolute)));
        }

        private void btnRotate270_MouseLeave(object sender, MouseEventArgs e)
        {
            btnRotate270.Background = new ImageBrush(new BitmapImage(new Uri(imageDirectory + "270_normal.png", UriKind.RelativeOrAbsolute)));
        }

    }
}
