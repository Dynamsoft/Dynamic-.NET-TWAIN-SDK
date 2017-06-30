using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.UVC;
using Dynamsoft.Core;
using System.IO;
using System.Runtime.InteropServices;
using Dynamsoft.Common;

namespace WebcamDemo
{
    public partial class Form1 : Form
    {
        private int m_iDesignWidth = 755;
        private CameraManager m_CameraManager = null;
        private ImageCore m_ImageCore = null;
        private string m_StrProductKey = "t0068MgAAAENENwNWc7+efmkY+t7se6XaRPFZkvfB7QWiTjHiLykxngQdY09pzVtOvrefXBbVvYFbJSluECHlyxaOvHwUADk=";

        private Camera m_CurrentCamera = null;


        public Form1()
        {
            InitializeComponent();
            m_CameraManager = new CameraManager(m_StrProductKey);
            m_ImageCore = new ImageCore();
            dsViewer1.Bind(m_ImageCore);
            this.Load += new EventHandler(Form1_Load);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                m_iDesignWidth = this.Width;
                if (m_CameraManager.GetCameraNames()!=null)
                {
                    foreach (string temp in m_CameraManager.GetCameraNames())
                    {
                        cbxSources.Items.Add(temp);
                    }

                    cbxSources.SelectedIndexChanged += cbxSources_SelectedIndexChanged;
                    if (cbxSources.Items.Count > 0)
                        cbxSources.SelectedIndex = 0;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        private void btnRemoveAllImages_Click(object sender, EventArgs e)
        {
            m_ImageCore.ImageBuffer.RemoveAllImages();
        }

        private void btnCaptureImage_Click(object sender, EventArgs e)
        {
            if(m_CurrentCamera!=null)
            {
                Bitmap tempBmp = m_CurrentCamera.GrabImage();
                m_ImageCore.IO.LoadImage(tempBmp);
            }
        }

        private void cbxSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_CurrentCamera != null)
            {
                m_CurrentCamera.Close();
            }
            if (m_CameraManager != null)
            {
                m_CurrentCamera = m_CameraManager.SelectCamera((short)cbxSources.SelectedIndex);
                m_CurrentCamera.SetVideoContainer(pictureBox1.Handle);
                m_CurrentCamera.Open();
                ResizeVideoWindow();
            }      
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point tempPoint = new Point(e.X,e.Y);
            float tempWidth = pictureBox1.Width;
            float tempHeight = pictureBox1.Height;

            float imageWidth = m_CurrentCamera.CurrentResolution.Width;
            float imageHeight = m_CurrentCamera.CurrentResolution.Height;
            float zoomX = imageWidth / tempWidth;
            float zoomY = imageHeight / tempHeight;
            Point tempFocusPoint = new Point((int)(e.X * imageWidth),(int)(e.Y*imageHeight));
            Rectangle tempRect = new Rectangle(tempFocusPoint,new Size(50,50));
            m_CurrentCamera.FocusOnArea(tempRect);
        }

        private void ResizeVideoWindow()
        {
                CamResolution camResolution = m_CurrentCamera.CurrentResolution;
                if (camResolution != null && camResolution.Width > 0 && camResolution.Height > 0)
                {
                    {
                        int iVideoWidth = pictureBox1.Width;
                        int iVideoHeight = pictureBox1.Width * camResolution.Height / camResolution.Width;
                        int iContentHeight = panel1.Height - panel1.Margin.Top - panel1.Margin.Bottom - panel1.Padding.Top - panel1.Padding.Bottom;
                        if (iVideoHeight < iContentHeight)
                            m_CurrentCamera.ResizeVideoWindow(0, (iContentHeight - iVideoHeight) / 2, iVideoWidth, iVideoHeight);
                        else
                            m_CurrentCamera.ResizeVideoWindow(0, 0, pictureBox1.Width, pictureBox1.Height);
                    }
                }
        }
    }
}
