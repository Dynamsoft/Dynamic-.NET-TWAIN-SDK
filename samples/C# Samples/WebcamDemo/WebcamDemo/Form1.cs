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
        private int iControlWidth = 275;
        private int iControlHeight = 295;
        private CameraManager m_CameraManager = null;
        private ImageCore m_ImageCore = null;
        private string m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU=";

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
                m_CurrentCamera.OnFrameCaptrue -= m_CurrentCamera_OnFrameCaptrue;
                m_CurrentCamera.Close();
            }
            if (m_CameraManager != null)
            {
                m_CurrentCamera = m_CameraManager.SelectCamera((short)cbxSources.SelectedIndex);
                m_CurrentCamera.Open();

                m_CurrentCamera.OnFrameCaptrue += m_CurrentCamera_OnFrameCaptrue;
                ResizePictureBox();
            }
            if (m_CurrentCamera != null)
            {
                cbxResolution.Items.Clear();
                foreach (CamResolution camR in m_CurrentCamera.SupportedResolutions)
                {
                    cbxResolution.Items.Add(camR.ToString());
                }
                cbxResolution.SelectedIndexChanged += cbxResolution_SelectedIndexChanged;
                if (cbxResolution.Items.Count > 0)
                    cbxResolution.SelectedIndex = 0;
                ResizePictureBox();
            }

        }
        private void cbxResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxResolution.Text != null)
            {
                string[] strWXH = cbxResolution.Text.Split(new char[] { ' ' });
                if (strWXH.Length == 3)
                {
                    try
                    {
                        m_CurrentCamera.CurrentResolution = new CamResolution(int.Parse(strWXH[0]), int.Parse(strWXH[2]));
                    }
                    catch { }
                }
                m_CurrentCamera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_0);
                ResizePictureBox();
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
        
        private void ResizePictureBox()
        {
            if (m_CurrentCamera != null)
            {
                CamResolution camResolution = m_CurrentCamera.CurrentResolution;
                if (camResolution != null && camResolution.Width > 0 && camResolution.Height > 0)
                {
                    {
                        int iVideoWidth = iControlWidth;
                        int iVideoHeight = iControlWidth * camResolution.Height / camResolution.Width;
                        int iContentHeight = panel1.Height - panel1.Margin.Top - panel1.Margin.Bottom - panel1.Padding.Top - panel1.Padding.Bottom;
                        if (iVideoHeight < iContentHeight)
                        {
                            pictureBox1.Location = new Point(0, (iContentHeight - iVideoHeight) / 2);
                            pictureBox1.Size = new Size(iVideoWidth, iVideoHeight);
                        }
                        else
                        {
                            pictureBox1.Location = new Point(0, 0);
                            pictureBox1.Size = new Size(pictureBox1.Width, pictureBox1.Height);
                        }
                    }
                }
            }
        }
        private void RotatePictureBox()
        {
            if (m_CurrentCamera != null)
            { 
                CamResolution camResolution = m_CurrentCamera.CurrentResolution;
                if (camResolution != null && camResolution.Width > 0 && camResolution.Height > 0)
                {
                    if (camResolution.Width / camResolution.Height > iControlWidth / iControlHeight)
                    {
                        int iVideoHeight = iControlHeight;
                        int iVideoWidth = iControlHeight * camResolution.Height / camResolution.Width;
                        int iContentWidth = panel1.Width - panel1.Margin.Left - panel1.Margin.Right - panel1.Padding.Left - panel1.Padding.Right;
                        pictureBox1.Location = new Point((iContentWidth - iVideoWidth) / 2, 0);
                        pictureBox1.Size = new Size(iVideoWidth, iVideoHeight);
                    }
                    else
                    {
                        int iVideoWidth = iControlWidth;
                        int iVideoHeight = iControlWidth * camResolution.Width / camResolution.Height;
                        int iContentHeight = panel1.Height - panel1.Margin.Top - panel1.Margin.Bottom - panel1.Padding.Top - panel1.Padding.Bottom;
                        pictureBox1.Location = new Point(0, (iContentHeight - iVideoHeight) / 2);
                        pictureBox1.Size = new Size(iVideoWidth, iVideoHeight);
                    }
                }
            }
        }
        private void SetPicture(Image img)
        {
            Bitmap temp = ((Bitmap)(img)).Clone(new Rectangle(0, 0, img.Width, img.Height), img.PixelFormat);
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.BeginInvoke(new MethodInvoker(
                delegate ()
                {
                    pictureBox1.Image = temp;
                }));
            }
            else
            {
                pictureBox1.Image = temp;
            }

        }
        private void picbox90_Click(object sender, EventArgs e)
        {
            m_CurrentCamera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_90);
            RotatePictureBox();
        }

        private void picbox180_Click(object sender, EventArgs e)
        {
            m_CurrentCamera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_180);
            ResizePictureBox();
        }

        private void picbox270_Click(object sender, EventArgs e)
        {
            m_CurrentCamera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_270);
            RotatePictureBox();
        }
        void m_CurrentCamera_OnFrameCaptrue(Bitmap bitmap)
        {
            SetPicture(bitmap);
        }
        private void picbox90_MouseHover(object sender, EventArgs e)
        {
            picbox90.Image = global::WebcamDemo.Properties.Resources._90_hover;
        }
        private void picbox90_MouseLeave(object sender, EventArgs e)
        {
            picbox90.Image = global::WebcamDemo.Properties.Resources._90_normal;
        }
        private void picbox180_MouseHover(object sender, EventArgs e)
        {
            picbox180.Image = global::WebcamDemo.Properties.Resources._180_hover;
        }
        private void picbox180_MouseLeave(object sender, EventArgs e)
        {
            picbox180.Image = global::WebcamDemo.Properties.Resources._180_normal;
        }
        private void picbox270_MouseHover(object sender, EventArgs e)
        {
            picbox270.Image = global::WebcamDemo.Properties.Resources._270_hover;
        }
        private void picbox270_MouseLeave(object sender, EventArgs e)
        {
            picbox270.Image = global::WebcamDemo.Properties.Resources._270_normal;
        }
        
    }
}
