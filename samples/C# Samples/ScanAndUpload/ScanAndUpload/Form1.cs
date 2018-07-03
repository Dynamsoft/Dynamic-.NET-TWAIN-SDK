using Dynamsoft.TWAIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.TWAIN.Interface;
using Dynamsoft.Core;
using Dynamsoft.PDF;
using Dynamsoft.Core.Enums;
using System.IO;
using System.Runtime.InteropServices;



namespace ScanAndUpload
{
    public partial class Form1 : Form,IAcquireCallback,ISave
    {
        private TwainManager m_TwainManager = null;
        private ImageCore m_ImageCore = null;
        string m_strServerName = "www.dynamsoft.com";
        string m_strPort = "80";
        string m_strActionPage = "/demo/DNT/SaveToDB.aspx";
        private string m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU=";

        public Form1()
        {
            InitializeComponent();
            m_TwainManager = new TwainManager(m_StrProductKey);
            m_ImageCore = new ImageCore();
            dsViewer1.Bind(m_ImageCore);
            this.txtboxServer.Text = m_strServerName;
            this.txtboxPort.Text = m_strPort;
            this.txtboxActionPage.Text = m_strActionPage;
            this.txtboxFileName.Text = "DNT_Image";
            this.rdbtnJPEG.Checked = true;
            this.chkboxMultiPage.Enabled = false;

            int lngNum;
            m_TwainManager.OpenSourceManager();
            for (lngNum = 0; lngNum < m_TwainManager.SourceCount; lngNum++)
            {
                cmbSource.Items.Add(m_TwainManager.SourceNameItems(Convert.ToInt16(lngNum))); // display the available imaging devices
            }
            if (lngNum > 0)
                cmbSource.SelectedIndex = 0;
        }


        private void btnScan_Click(object sender, EventArgs e)
        {
            m_ImageCore.ImageBuffer.IfAppendImage = true;
            AcquireImage();
        }

        private void AcquireImage()
        {
            try
            {
                m_TwainManager.SelectSourceByIndex(Convert.ToInt16(cmbSource.SelectedIndex));
                m_TwainManager.IfShowUI = chkboxIfShowUI.Checked;
                m_TwainManager.OpenSource();
                m_TwainManager.IfDisableSourceAfterAcquire = true;

                m_TwainManager.IfShowUI = chkboxIfShowUI.Checked;
                m_TwainManager.AcquireImage(this as IAcquireCallback);

            }
            catch (Exception exp)
            {
                this.txtboxErrMessage.AppendText(exp.Message);
                this.txtboxErrMessage.AppendText("\r\n");
            }

        }

        private void dynamicDotNetTwain1_OnMouseClick(short sImageIndex)
        {
            m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer = sImageIndex;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
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
                        m_ImageCore.Net.HTTPPort = int.Parse(txtboxPort.Text); //the port number of the HTTP Server
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

                m_ImageCore.Net.HTTPUserName = this.txtboxName.Text; //user name for logging into HTTP Server
                m_ImageCore.Net.HTTPPassword = this.txtboxPwd.Text;
                m_ImageCore.Net.SetHTTPFormField("ExtraTxt", this.txtboxExtraTxt.Text); // pass extra text parameters when uploading image


                List<short> tempImageIndexList = new List<short>();
                tempImageIndexList.Add(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                if (rdbtnJPEG.Checked)
                {
                    strImageName = strFileName + ".jpg";

                    m_ImageCore.Net.HTTPUploadThroughPost(strHTTPServer,strActionPage, strImageName,tempImageIndexList,Dynamsoft.Core.Enums.EnumImageFileFormat.WEBTW_JPG);
                }
                if (rdbtnPNG.Checked)
                {
                    strImageName = strFileName + ".png";
                    m_ImageCore.Net.HTTPUploadThroughPost(strHTTPServer, strActionPage, strImageName,tempImageIndexList, Dynamsoft.Core.Enums.EnumImageFileFormat.WEBTW_PNG);
                }
                if (rdbtnPDF.Checked)
                {
                    strImageName = strFileName + ".pdf";
                    PDFCreator tempCreator = new PDFCreator(m_StrProductKey);
                        Byte[] tempPDFBytes = tempCreator.SaveAsBytes(this as ISave);
                        m_ImageCore.Net.HTTPUploadThroughPost(strHTTPServer, strActionPage, strImageName,tempPDFBytes);
                }
                if (rdbtnTIFF.Checked)
                {
                    strImageName = strFileName + ".tif";
                    if (chkboxMultiPage.Checked)
                    {
                        tempImageIndexList.Clear();
                        for(short i = 0;i<m_ImageCore.ImageBuffer.HowManyImagesInBuffer;i++)
                        {
                            tempImageIndexList.Add(i);
                        }
                        m_ImageCore.Net.HTTPUploadThroughPost(strHTTPServer, strActionPage, strImageName,tempImageIndexList, Dynamsoft.Core.Enums.EnumImageFileFormat.WEBTW_TIF);
                    }
                    else
                    {
                        m_ImageCore.Net.HTTPUploadThroughPost(strHTTPServer, strActionPage, strImageName, tempImageIndexList, Dynamsoft.Core.Enums.EnumImageFileFormat.WEBTW_TIF);
                    }
                }
                if (m_ImageCore.Net.HTTPPostResponseString == "")
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

        private void txtboxServer_TextChanged(object sender, EventArgs e)
        {
            string strHTTPServer = this.txtboxServer.Text;
            if (strHTTPServer.Trim().ToLower().CompareTo(m_strServerName.Trim().ToLower()) == 0)
                lbNote.Visible = true;
            else
                lbNote.Visible = false;
        }

        public void OnPostAllTransfers()
        {
        }

        public bool OnPostTransfer(Bitmap bit)
        {
            m_ImageCore.IO.LoadImage(bit);
			TextBox.CheckForIllegalCrossThreadCalls = false;
            this.txtboxErrMessage.AppendText("Image acquired successfully. \r\n");
            return true;
        }

        public void OnPreAllTransfers()
        {
        }

        public bool OnPreTransfer()
        {
            return true;
        }

        public void OnSourceUIClose()
        {
        }

        public void OnTransferCancelled()
        {
        }

        public void OnTransferError()
        {
        }

        public object GetAnnotations(int iPageNumber)
        {
            if (chkboxMultiPage.Checked)
                return m_ImageCore.ImageBuffer.GetMetaData((short)iPageNumber, EnumMetaDataType.enumAnnotation);
            else
                return m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer,EnumMetaDataType.enumAnnotation);

        }

        public Bitmap GetImage(int iPageNumber)
        {
            if (chkboxMultiPage.Checked)
                return m_ImageCore.ImageBuffer.GetBitmap((short)iPageNumber);
            else
                return m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);

        }

        public int GetPageCount()
        {
            if (chkboxMultiPage.Checked)
                return m_ImageCore.ImageBuffer.HowManyImagesInBuffer;
            else
                return 1;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.m_TwainManager.Dispose();
        }
    }
}
