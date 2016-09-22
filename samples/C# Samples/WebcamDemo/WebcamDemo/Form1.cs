using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.DotNet.TWAIN.Enums;

namespace WebcamDemo
{
    public partial class Form1 : Form
    {
        private int m_iDesignWidth = 755;
        public Form1()
        {
            InitializeComponent();
            this.dynamicDotNetTwain1.LicenseKeys = "83C721A603BF5301ABCF850504F7B744;83C721A603BF5301AC7A3AA0DF1D92E6;83C721A603BF5301E22CBEC2DD20B511;83C721A603BF5301977D72EA5256A044;83C721A603BF53014332D52C75036F9E;83C721A603BF53010090AB799ED7E55E";
            dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_WEBCAM;
            //set IfShowUI true if you want to show video
            dynamicDotNetTwain1.IfShowUI = true;

            this.chkContainer.Checked = false;
            this.chkFocusArea.Checked = false;
            this.Load += new EventHandler(Form1_Load);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                m_iDesignWidth = this.Width;
                this.chkContainer.CheckedChanged += new System.EventHandler(this.chkContainer_CheckedChanged);
                this.chkContainer.Checked = true;
                for (short i = 0; i < dynamicDotNetTwain1.SourceCount; i++)
                {
                    string strSourceName = dynamicDotNetTwain1.SourceNameItems(i);
                    if (strSourceName != null)
                        cbxSources.Items.Add(strSourceName);
                }
                for (int i = 0; i < 4; i++)
                {
                    int irotateType = 90 * i;
                    string sRotateType = irotateType.ToString() + "°";
                    cbxRotateType.Items.Add(sRotateType);
                }
                cbxSources.SelectedIndexChanged += cbxSources_SelectedIndexChanged;
                //cbxRotateType.SelectedIndex = 0;
                if (cbxSources.Items.Count > 0)
                    cbxSources.SelectedIndex = 0;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }       

        private void btnRemoveAllImages_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain1.RemoveAllImages();
        }

        private void btnCaptureImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxSources.Items.Count > 0)
                {
                    dynamicDotNetTwain1.AcquireImage();     
                }
                else
                {
                    MessageBox.Show("No webCam source detected!");
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void cbxSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex >= 0 && ((ComboBox)sender).SelectedIndex < dynamicDotNetTwain1.SourceCount)
            {
                dynamicDotNetTwain1.SelectSourceByIndex(cbxSources.SelectedIndex);
                cbxRotateType.SelectedIndex = 0;
                ResizeVideoWindow(cbxRotateType.SelectedIndex % 4);
                dynamicDotNetTwain1.OpenSource();
            }
        }

        private void chkContainer_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkContainer.Checked)
            {
                dynamicDotNetTwain1.ResizeVideoWindow(0, 0, -1, -1); 
                lbContainer.Visible = false;
                panel1.Visible = false;
                chkFocusArea.Checked = false;
                chkFocusArea.Enabled = false;
                this.Width = m_iDesignWidth - this.panel1.Width - 15;
                dynamicDotNetTwain1.SetVideoContainer(null);
            }
            else
            {
                
                lbContainer.Visible = true;
                panel1.Visible = true;
                chkFocusArea.Enabled = true;
                this.Width = m_iDesignWidth;
                dynamicDotNetTwain1.SetVideoContainer(pictureBox1);
                cbxRotateType_SelectedIndexChanged(cbxRotateType, null);
            }
        }

        private void chkFocusArea_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFocusArea.Checked)
            {
                //this.chkContainer.Checked = true;
                //this.chkContainer.Enabled = false;
                pictureBox1.MouseClick += new MouseEventHandler(pictureBox1_MouseClick);
            }
            else
            {
                //this.chkContainer.Enabled = true;
                pictureBox1.MouseClick -= new MouseEventHandler(pictureBox1_MouseClick);
            }
        }

        void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Rectangle rectArea = new Rectangle(e.Location.X-25,e.Location.Y-25,50,50);
            dynamicDotNetTwain1.FocusOnArea(rectArea);
        }

        private void cbxRotateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(((ComboBox)sender).SelectedIndex>=0)
            {
                dynamicDotNetTwain1.RotateVideo((EnumVideoRotateType)(((ComboBox)sender).SelectedIndex));
                ResizeVideoWindow(((ComboBox)sender).SelectedIndex % 4);
            }

        }

        private void ResizeVideoWindow(int iRotate)
        {
            if (chkContainer.Checked)
            {
                Dynamsoft.DotNet.TWAIN.WebCamera.CamResolution camResolution = dynamicDotNetTwain1.ResolutionForCam;
                if (camResolution != null && camResolution.Width > 0 && camResolution.Height > 0)
                {
                    if (iRotate % 2 == 0)
                    {
                        int iVideoWidth = pictureBox1.Width;
                        int iVideoHeight = pictureBox1.Width * camResolution.Height / camResolution.Width;
                        int iContentHeight = panel1.Height - panel1.Margin.Top - panel1.Margin.Bottom - panel1.Padding.Top - panel1.Padding.Bottom;
                        if (iVideoHeight < iContentHeight)
                            dynamicDotNetTwain1.ResizeVideoWindow(0, (iContentHeight - iVideoHeight) / 2, iVideoWidth, iVideoHeight);
                        else
                            dynamicDotNetTwain1.ResizeVideoWindow(0, 0, pictureBox1.Width, pictureBox1.Height);
                    }
                    else
                    {
                        int iVideoHeight = pictureBox1.Height;
                        int iVideoWidth = pictureBox1.Height * camResolution.Height / camResolution.Width;
                        int iContentWidth = panel1.Width - panel1.Margin.Right - panel1.Margin.Left - panel1.Padding.Right - panel1.Padding.Left;
                        if (iVideoWidth < iContentWidth)
                            dynamicDotNetTwain1.ResizeVideoWindow((iContentWidth - iVideoWidth) / 2, 0, iVideoWidth, iVideoHeight);
                        else
                            dynamicDotNetTwain1.ResizeVideoWindow(0, 0, pictureBox1.Width, pictureBox1.Height);
                    }
                }
            }
            else
            {
                dynamicDotNetTwain1.ResizeVideoWindow(0, 0, -1, -1);
            }
        }
    }
}
