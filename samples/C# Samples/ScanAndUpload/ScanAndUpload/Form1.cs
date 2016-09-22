using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScanAndUploadToDB
{
    public partial class Form1 : Form
    {
        string m_strServerName = "www.dynamsoft.com";
        string m_strPort = "80";
        string m_strActionPage = "/demo/DNT/SaveToDB.aspx";

        public Form1()
        {
            InitializeComponent();
            this.dynamicDotNetTwain1.LicenseKeys = "83C721A603BF5301ABCF850504F7B744;83C721A603BF5301AC7A3AA0DF1D92E6;83C721A603BF5301E22CBEC2DD20B511;83C721A603BF5301977D72EA5256A044;83C721A603BF53014332D52C75036F9E;83C721A603BF53010090AB799ED7E55E";
            this.txtboxServer.Text = m_strServerName;
            this.txtboxPort.Text = m_strPort;
            this.txtboxActionPage.Text = m_strActionPage;
            this.txtboxFileName.Text = "DNT_Image";
            this.rdbtnJPEG.Checked = true;
            this.chkboxMultiPage.Enabled = false;
            
            dynamicDotNetTwain1.ScanInNewProcess = true;
            dynamicDotNetTwain1.SupportedDeviceType = Dynamsoft.DotNet.TWAIN.Enums.EnumSupportedDeviceType.SDT_ALL; // enable capturing images from both scanners and webcams
            int lngNum;
            dynamicDotNetTwain1.OpenSourceManager();
            for (lngNum = 0; lngNum < dynamicDotNetTwain1.SourceCount; lngNum++)
            {
                cmbSource.Items.Add(dynamicDotNetTwain1.SourceNameItems(Convert.ToInt16(lngNum))); // display the available imaging devices
            }
            if (lngNum > 0)
                cmbSource.SelectedIndex = 0;   
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain1.IfAppendImage = true;
            AcquireImage(); // acquire images
        }

        private void AcquireImage()
        {
            try { 
                dynamicDotNetTwain1.SelectSourceByIndex(Convert.ToInt16(cmbSource.SelectedIndex));
                dynamicDotNetTwain1.IfShowUI = chkboxIfShowUI.Checked;
                dynamicDotNetTwain1.OpenSource();
                dynamicDotNetTwain1.IfDisableSourceAfterAcquire = true;
            
                dynamicDotNetTwain1.IfShowUI = chkboxIfShowUI.Checked;

                bool result = dynamicDotNetTwain1.AcquireImage();
                if (!result || dynamicDotNetTwain1.ErrorCode != 0)
                {
                    this.txtboxErrMessage.AppendText(dynamicDotNetTwain1.ErrorString);
                    this.txtboxErrMessage.AppendText("\r\n");
                }
            }
            catch (Exception exp)
            {
                this.txtboxErrMessage.AppendText(exp.Message);
                this.txtboxErrMessage.AppendText("\r\n");
            }

        }

        private void dynamicDotNetTwain1_OnMouseClick(short sImageIndex)
        {
            dynamicDotNetTwain1.CurrentImageIndexInBuffer = sImageIndex;       
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                dynamicDotNetTwain1.IfShowCancelDialogWhenImageTransfer = true;
                string strImageName = "";
                string strHTTPServer = this.txtboxServer.Text; // the name or the IP of your HTTP Server
                if (strHTTPServer == "")
                {
                    this.txtboxErrMessage.AppendText("The HTTP server cannot be empty.\r\n");
                    return;
                }
                if (txtboxPort.Text == "")
                {
                    this.txtboxErrMessage.AppendText("The HTTP port cannot be empty.\r\n");
                    return;
                }
                else
                {
                    try
                    {
                        dynamicDotNetTwain1.HTTPPort = int.Parse(txtboxPort.Text); //the port number of the HTTP Server
                    }
                    catch
                    {
                        this.txtboxErrMessage.AppendText("Invalid HTTP port.\r\n");
                        return;
                    }
                }
                string strActionPage = this.txtboxActionPage.Text; // receive the uploaded images on the server side
                if (strActionPage == "")
                {
                    this.txtboxErrMessage.AppendText("The action page cannot be empty.\r\n");
                    return;
                }
                string strFileName = this.txtboxFileName.Text;
                if (strFileName == "")
                {
                    this.txtboxErrMessage.AppendText("The file name cannot be empty.\r\n");
                    return;
                }

                dynamicDotNetTwain1.HTTPUserName = this.txtboxName.Text; //user name for logging into HTTP Server
                dynamicDotNetTwain1.HTTPPassword = this.txtboxPwd.Text;
                dynamicDotNetTwain1.SetHTTPFormField("ExtraTxt", this.txtboxExtraTxt.Text); // pass extra text parameters when uploading image

                if (rdbtnJPEG.Checked)
                {
                    strImageName = strFileName + ".jpg";
                    bool c = dynamicDotNetTwain1.HTTPUploadThroughPostEx(strHTTPServer, dynamicDotNetTwain1.CurrentImageIndexInBuffer, strActionPage, strImageName, Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_JPG);
                }
                if (rdbtnPNG.Checked)
                {
                    strImageName = strFileName + ".png";
                    dynamicDotNetTwain1.HTTPUploadThroughPostEx(strHTTPServer, dynamicDotNetTwain1.CurrentImageIndexInBuffer, strActionPage, strImageName, Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_PNG);
                }
                if (rdbtnPDF.Checked)
                {
                    strImageName = strFileName + ".pdf";
                    if (chkboxMultiPage.Checked)
                        dynamicDotNetTwain1.HTTPUploadAllThroughPostAsPDF(strHTTPServer, strActionPage, strImageName); // save the captured images as a multi-page PDF file
                    else
                        dynamicDotNetTwain1.HTTPUploadThroughPostEx(strHTTPServer, dynamicDotNetTwain1.CurrentImageIndexInBuffer, strActionPage, strImageName, Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_PDF);
                }
                if (rdbtnTIFF.Checked)
                {
                    strImageName = strFileName + ".tif";
                    if (chkboxMultiPage.Checked)
                        dynamicDotNetTwain1.HTTPUploadAllThroughPostAsMultiPageTIFF(strHTTPServer, strActionPage, strImageName);
                    else
                        dynamicDotNetTwain1.HTTPUploadThroughPostEx(strHTTPServer, dynamicDotNetTwain1.CurrentImageIndexInBuffer, strActionPage, strImageName, Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_TIF);
                }

                if (dynamicDotNetTwain1.ErrorCode != Dynamsoft.DotNet.TWAIN.Enums.ErrorCode.Succeed)
                {
                    this.txtboxErrMessage.Text += dynamicDotNetTwain1.ErrorString;
                    this.txtboxErrMessage.Text += "\r\n";
                }
                else
                {
                    if (dynamicDotNetTwain1.HTTPPostResponseString == "")
                    {
                        this.txtboxErrMessage.AppendText("Image uploaded to DB successfully. \r\n");
                        if (strHTTPServer.Trim().ToLower().CompareTo(m_strServerName.Trim().ToLower()) == 0 &&
                           txtboxPort.Text.Trim().ToLower().CompareTo(m_strPort.Trim().ToLower()) == 0 &&
                           strActionPage.Trim().ToLower().CompareTo(m_strActionPage.Trim().ToLower()) == 0)
                        {
                            SuccessInfo objSuccessInfo = new SuccessInfo(strImageName);
                            objSuccessInfo.ShowDialog();
                        }
                    }
                    else
                    {
                        this.txtboxErrMessage.AppendText("Image uploaded to DB unsuccessfully. You can check DynamicDotNetTwain.HTTPPostResponseString for more information. \r\n");
                    }
                }
            }
            catch (Exception exp)
            {
                this.txtboxErrMessage.AppendText(exp.Message);
                this.txtboxErrMessage.AppendText("\r\n");
            }
        }

        private void rdbtnPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnPDF.Checked)
            {
                this.chkboxMultiPage.Enabled = true;
                this.chkboxMultiPage.Checked = true;
            }
            else
            {
                this.chkboxMultiPage.Enabled = false;
                this.chkboxMultiPage.Checked = false;
            }
        }

        private void rdbtnTIFF_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnTIFF.Checked)
            {
                this.chkboxMultiPage.Enabled = true;
                this.chkboxMultiPage.Checked = true;
            }
            else
            {
                this.chkboxMultiPage.Enabled = false;
                this.chkboxMultiPage.Checked = false;
            }
        }

        private void dynamicDotNetTwain1_OnPostTransfer()
        {
            if (dynamicDotNetTwain1.ErrorCode == 0)
            {
                this.txtboxErrMessage.AppendText("Image acquired successfully. \r\n");
            }
        }

        private void txtboxServer_TextChanged(object sender, EventArgs e)
        {
            string strHTTPServer = this.txtboxServer.Text;
            if (strHTTPServer.Trim().ToLower().CompareTo(m_strServerName.Trim().ToLower()) == 0)
                lbNote.Visible = true;
            else
                lbNote.Visible = false;
        }

    }
}
