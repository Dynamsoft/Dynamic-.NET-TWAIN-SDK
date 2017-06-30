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
        private string m_StrProductKey = "t0068MgAAAENENwNWc7+efmkY+t7se6XaRPFZkvfB7QWiTjHiLykxngQdY09pzVtOvrefXBbVvYFbJSluECHlyxaOvHwUADk=";
        private ImageCore m_ImageCore = null;
        private CameraManager m_CameraManager = null;
        private Camera m_Camera = null;
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
            
        }

        void cbxSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (m_CameraManager.GetCameraNames() != null)
            {
                if (((ComboBox)sender).SelectedIndex >= 0 && ((ComboBox)sender).SelectedIndex < m_CameraManager.GetCameraNames().Count)
                {
                    m_Camera = m_CameraManager.SelectCamera((short)cbxSources.SelectedIndex);
                    IntPtr windowHandle = new WindowInteropHelper(this).Handle;
                    m_Camera.SetVideoContainer(windowHandle);
                    m_Camera.Open();
                    ResizeVideoWindow();
                }
            }

        }

        void Window1_Loaded(object sender, RoutedEventArgs e)
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
                IntPtr windowHandle = new WindowInteropHelper(this).Handle;
                m_Camera.SetVideoContainer(windowHandle);
                m_Camera.Open();
                ResizeVideoWindow();
                Bitmap temp = m_Camera.GrabImage();
                m_ImageCore.IO.LoadImage(temp);
            }
        }

        private void btnRemoveAllImage_Click(object sender, RoutedEventArgs e)
        {
            m_ImageCore.ImageBuffer.RemoveAllImages();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (m_Camera != null)
            {
                IntPtr windowHandle = new WindowInteropHelper(this).Handle;
                m_Camera.SetVideoContainer(windowHandle);
                m_Camera.Open();
                ResizeVideoWindow();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (m_Camera != null)
            {
                m_Camera.Close();
            }
        }

        private void ResizeVideoWindow()
        {
            if (m_Camera != null)
            {
                CamResolution tempCamResolution = m_Camera.CurrentResolution;
                if(tempCamResolution!=null)
                {
                    double iVideoWidth = border1.Width;
                    double iVideoHeight = border1.Width * tempCamResolution.Height / tempCamResolution.Width;
                    m_Camera.ResizeVideoWindow((int)(border1.Margin.Left + border1.BorderThickness.Left), (int)(border1.Margin.Top + (border1.ActualHeight - iVideoHeight) / 2), (int)(iVideoWidth - border1.BorderThickness.Left - border1.BorderThickness.Right), (int)iVideoHeight);
                }
            }
        }
    }
}
