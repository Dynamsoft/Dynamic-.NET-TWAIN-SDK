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
        public Form1()
        {
            InitializeComponent();

            this.chkIfShowUI.Checked = false;
            dynamicDotNetTwain1.IfShowUI = false;
            this.chkContainer.Checked = false;
            radioWebCam.Checked = true;
            dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_WEBCAM;

            chkContainer.Enabled = chkIfShowUI.Checked;
            chkIfShowUI.CheckedChanged += new EventHandler(chkIfShowUI_CheckedChanged);
        }       

        private void btnRemoveAllImages_Click(object sender, EventArgs e)
        {
            if (this.chkIfThrowException.Checked)
                dynamicDotNetTwain1.IfThrowException = true;
            else
                dynamicDotNetTwain1.IfThrowException = false;
            dynamicDotNetTwain1.RemoveAllImages();
        }

        private void radioTwain_CheckedChanged(object sender, EventArgs e)
        {
            if (radioTwain.Checked == true)
            {
                radioWebCam.Checked = false;
                radioAll.Checked = false;
            }
        }

        private void radioWebCam_CheckedChanged(object sender, EventArgs e)
        {
            if (radioWebCam.Checked == true)
            {
                radioTwain.Checked = false;
                radioAll.Checked = false;
            }
        }

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAll.Checked == true)
            {
                radioWebCam.Checked = false;
                radioTwain.Checked = false;
            }
        }

        private void btnSelectSource_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioTwain.Checked)
                    dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_TWAIN;
                else if (radioWebCam.Checked)
                    dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_WEBCAM;
                else if (radioAll.Checked)
                    dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_ALL;

                //short count = dynamicDotNetTwain1.SourceCount;
                //string name = dynamicDotNetTwain1.SourceNameItems(0);
                if (this.chkIfThrowException.Checked)
                    dynamicDotNetTwain1.IfThrowException = true;
                else
                    dynamicDotNetTwain1.IfThrowException = false;
                
                dynamicDotNetTwain1.SelectSource();
                EnumSupportedDeviceType en = dynamicDotNetTwain1.SupportedDeviceType;
                
                if (chkIfShowUI.Checked)
                {
                    dynamicDotNetTwain1.IfShowUI = true;
                }
                else
                {
                    dynamicDotNetTwain1.IfShowUI = false;
                }
                dynamicDotNetTwain1.OpenSource();
                
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnAcquireSource_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioTwain.Checked)
                    dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_TWAIN;
                else if (radioWebCam.Checked)
                    dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_WEBCAM;
                else if (radioAll.Checked)
                    dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_ALL;

                if (this.chkIfThrowException.Checked)
                    dynamicDotNetTwain1.IfThrowException = true;
                else
                    dynamicDotNetTwain1.IfThrowException = false;

                if (chkIfShowUI.Checked)
                {
                    dynamicDotNetTwain1.IfShowUI = true;
                    if (chkContainer.Checked)
                        dynamicDotNetTwain1.SetVideoContainer(this.pictureBox1);
                    else
                        dynamicDotNetTwain1.SetVideoContainer(null);
                }
                else
                {
                    dynamicDotNetTwain1.IfShowUI = false;
                    dynamicDotNetTwain1.SetVideoContainer(null);
                }
                dynamicDotNetTwain1.EnableSource();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            
        }

        void chkIfShowUI_CheckedChanged(object sender, EventArgs e)
        {
            chkContainer.Enabled = chkIfShowUI.Checked;
        }
    }
}
