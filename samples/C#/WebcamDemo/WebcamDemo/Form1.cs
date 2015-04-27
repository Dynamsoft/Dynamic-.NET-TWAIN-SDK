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

            dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_WEBCAM;

            this.chkContainer.Checked = true;

            this.Load += new EventHandler(Form1_Load);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                m_iDesignWidth = this.Width;
                this.chkContainer.CheckedChanged += new System.EventHandler(this.chkContainer_CheckedChanged);
                this.chkContainer.Checked = false;

                for (short i = 0; i < dynamicDotNetTwain1.SourceCount; i++)
                {
                    string strSourceName = dynamicDotNetTwain1.SourceNameItems(i);
                    if (strSourceName != null)
                        cbxSources.Items.Add(strSourceName);
                }

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
                    dynamicDotNetTwain1.IfShowUI = true;
                    if (chkContainer.Checked)
                    {
                        Dynamsoft.DotNet.TWAIN.WebCamera.CamResolution camResolution = dynamicDotNetTwain1.ResolutionForCam;
                        if (camResolution != null && camResolution.Width > 0 && camResolution.Height > 0)
                        {
                            pictureBox1.Height = pictureBox1.Width * camResolution.Height / camResolution.Width; 
                            int iContentHeight = panel1.Height - panel1.Margin.Top - panel1.Margin.Bottom - panel1.Padding.Top - panel1.Padding.Bottom;
                            if (pictureBox1.Height < iContentHeight)
                                pictureBox1.Location = new Point (pictureBox1.Location.X, (iContentHeight - pictureBox1.Height) / 2);
                            else
                                pictureBox1.Location =  new Point (pictureBox1.Location.X, 0);
                        }
                        dynamicDotNetTwain1.SetVideoContainer(this.pictureBox1);
                    }
                    else
                        dynamicDotNetTwain1.SetVideoContainer(null);
                    dynamicDotNetTwain1.EnableSource();
                }
                else
                {
                    MessageBox.Show("No webcam source detected!");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            
        }

        private void cbxSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex >= 0 && ((ComboBox)sender).SelectedIndex < dynamicDotNetTwain1.SourceCount)
            {
                dynamicDotNetTwain1.SelectSourceByIndex(cbxSources.SelectedIndex);
                dynamicDotNetTwain1.OpenSource();
            }
        }

        private void chkContainer_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkContainer.Checked)
            {
                lbContainer.Visible = false;
                panel1.Visible = false;
                this.Width = m_iDesignWidth - this.panel1.Width - 15;
            }
            else
            {
                lbContainer.Visible = true;
                panel1.Visible = true;
                this.Width = m_iDesignWidth;
            }
        }
    }
}
