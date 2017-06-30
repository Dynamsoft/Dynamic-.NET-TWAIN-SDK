using Dynamsoft.Core;
using Dynamsoft.Core.Enums;
using Dynamsoft.TWAIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.TWAIN.Interface;
using Dynamsoft.PDF;
using System.IO;
using System.Runtime.InteropServices;

namespace ShowInfoAndSaveImage
{
    public partial class Form1 : Form,IAcquireCallback,ISave
    {
        EnumImageFileFormat sImageType;
        private TwainManager m_TwainManager = null;
        private ImageCore m_ImageCore = null;
        private Dynamsoft.PDF.PDFCreator m_PDFCreator = null;
        private String m_StrProductKey = "t0068MgAAAENENwNWc7+efmkY+t7se6XaRPFZkvfB7QWiTjHiLykxngQdY09pzVtOvrefXBbVvYFbJSluECHlyxaOvHwUADk=";
        public Form1()
        {
            InitializeComponent();
            m_TwainManager = new TwainManager(m_StrProductKey);
            m_ImageCore = new ImageCore();
            dsViewer1.Bind(m_ImageCore);
            dsViewer1.SetViewMode(1, 1);
            BMPradio.Checked = true;
            sImageType = 0;
            MultiTIFF.Enabled = false;
            MultiPDF.Enabled = false;
            m_PDFCreator = new PDFCreator(m_StrProductKey);
            m_RefreshInfo = new RefreshInfo(ShowImageInfo); 

        }


        private delegate void RefreshInfo(int strImageXResolution,int strImageYResolution,int strImageWidth,int strImageLength,string strImageBitsPerixel,string strImagePixelType,
                                        string strImageLayoutFrameLeft,string strImageLayoutFrameTop,string strImageLayoutFrameRight,string strImageLayoutFrameBottom,
                                        string strImageLayoutDocumentNumber,string strImageLayoutPageNumber,string strImageLayoutFrameNumber);


        private RefreshInfo m_RefreshInfo;

        public string GetImageSize()
        {
            string ImageSize = "";
            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer != 0)
            {
                ImageSize = m_ImageCore.IO.GetImageSizeWithSpecifiedType(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, sImageType).ToString();
            }
            return ImageSize;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {

            List<string> tempList = new List<string>();
            for (int i = 0; i < m_TwainManager.SourceCount; i++)
            {
                tempList.Add(m_TwainManager.SourceNameItems((short)i));
            }
            SourceListWrapper tempSourceListWrapper = new SourceListWrapper(tempList);

            int iSelectIndex = tempSourceListWrapper.SelectSource();
            if (iSelectIndex == -1)
            {
                return;
            }
            else
            {
                m_TwainManager.IfDisableSourceAfterAcquire = true;
                m_TwainManager.IfShowUI = true;
                m_TwainManager.SelectSourceByIndex((short)iSelectIndex);
                m_TwainManager.AcquireImage(this as IAcquireCallback);
            }
        }

        private void TIFFradio_CheckedChanged(object sender, EventArgs e)
        {
            MultiTIFF.Enabled = true;
            MultiPDF.Enabled = false;
            sImageType = EnumImageFileFormat.WEBTW_TIF;
            txtFileSize.Text = GetImageSize();
        }

        private byte[] m_PDFFileBytes = null;
        private void PDFradio_CheckedChanged(object sender, EventArgs e)
        {
            MultiTIFF.Enabled = false;
            MultiPDF.Enabled = true;
            m_PDFFileBytes = null;
            m_PDFFileBytes = m_PDFCreator.SaveAsBytes(this as ISave);
            txtFileSize.Text = "0";
            if (m_PDFFileBytes != null)
            {
                txtFileSize.Text = m_PDFFileBytes.Length.ToString();
            }

        }

        private void BMPradio_CheckedChanged(object sender, EventArgs e)
        {
            MultiTIFF.Enabled = false;
            MultiPDF.Enabled = false;
            sImageType = EnumImageFileFormat.WEBTW_BMP;
            txtFileSize.Text = GetImageSize();

        }

        private void JPEGradio_CheckedChanged(object sender, EventArgs e)
        {
            MultiTIFF.Enabled = false;
            MultiPDF.Enabled = false;
            sImageType = EnumImageFileFormat.WEBTW_JPG;
            txtFileSize.Text = GetImageSize();
        }

        private void PNGradio_CheckedChanged(object sender, EventArgs e)
        {
            MultiTIFF.Enabled = false;
            MultiPDF.Enabled = false;
            sImageType = EnumImageFileFormat.WEBTW_PNG;
            txtFileSize.Text = GetImageSize();
        }

        private void BMPradio_MouseClick(object sender, MouseEventArgs e)
        {
            MultiTIFF.Enabled = false;
            MultiPDF.Enabled = false;
            sImageType = 0;
            txtFileSize.Text = GetImageSize();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0)
                {
                    string strFile = "";
                    if (BMPradio.Checked == true)
                    {
                        dlgFileSave.Filter = "BMP File (*.bmp)|*.bmp";
                    }
                    else if (JPEGradio.Checked == true)
                    {
                        dlgFileSave.Filter = "JPEG File (*.jpg)|*.jpg";
                    }
                    else if (PNGradio.Checked == true)
                    {
                        dlgFileSave.Filter = "PNG File (*.png)|*.png";
                    }
                    else if (TIFFradio.Checked == true)
                    {
                        dlgFileSave.Filter = "TIFF File (*.tif)|*.tif";
                    }
                    else if (PDFradio.Checked == true)
                    {
                        dlgFileSave.Filter = "PDF File (*.pdf)|*.pdf";
                    }
                    dlgFileSave.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
                    dlgFileSave.FileName = "";
                    if (dlgFileSave.ShowDialog() == DialogResult.OK)
                    {
                        strFile = dlgFileSave.FileName;


                        if (BMPradio.Checked == true)
                        {
                            m_ImageCore.IO.SaveAsBMP(strFile, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                        }
                        else if (JPEGradio.Checked == true)
                        {

                            m_ImageCore.IO.SaveAsJPEG(strFile, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                        }
                        else if (PNGradio.Checked == true)
                        {

                            m_ImageCore.IO.SaveAsPNG(strFile, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                        }
                        else if (TIFFradio.Checked == true)
                        {
                            List<short> tempImageIndex = new List<short>();
                            if (MultiTIFF.Checked == true)
                            {
                                for (short sIndex = 0; sIndex < m_ImageCore.ImageBuffer.HowManyImagesInBuffer; sIndex++)
                                {
                                    tempImageIndex.Add(sIndex);
                                }
                            }
                            else
                            {
                                tempImageIndex.Add(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                            }

                            m_ImageCore.IO.SaveAsTIFF(strFile, tempImageIndex);
                        }
                        else if (PDFradio.Checked == true)
                        {
                            m_PDFCreator.Save(this as ISave, strFile);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer != -1)
            {
                m_ImageCore.ImageBuffer.RemoveImage(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                btnScan.Enabled = true;
            }
        }

        private void Clear()
        {
            m_ImageCore.ImageBuffer.RemoveAllImages();
            edtXResolution.Text = "";
            edtYResolution.Text = "";
            edtWidth.Text = "";
            edtLength.Text = "";
            edtBitsPerPixel.Text = "";
            edtPixelType.Text = "";

            edtFrameLeft.Text = "";
            edtFrameTop.Text = "";
            edtFrameRight.Text = "";
            edtFrameBottom.Text = "";
            edtDocNumber.Text = "";
            edtPageNumber.Text = "";
            edtFrameNumber.Text = "";

            txtFileSize.Text = GetImageSize();
        }

        private void dynamicDotNetTwain_OnPostTransfer()
        {
            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer >= m_ImageCore.ImageBuffer.MaxImagesInBuffer)
            {
                btnScan.Enabled = false;
            }
        }

        private void ShowImageInfo(int strImageXResolution, int strImageYResolution, int strImageWidth, int strImageLength, string strImageBitsPerixel, string strImagePixelType, string strImageLayoutFrameLeft, string strImageLayoutFrameTop, string strImageLayoutFrameRight, string strImageLayoutFrameBottom,string strDocumentNumber,string strPageNumber,string strFrameNumber)
        {
            edtXResolution.Text = strImageXResolution.ToString();
            edtYResolution.Text = strImageYResolution.ToString();
            edtWidth.Text = strImageWidth.ToString();
            edtLength.Text = strImageLength.ToString();
            edtBitsPerPixel.Text = strImageLength.ToString();
            edtPixelType.Text = strImagePixelType.ToString();
            edtFrameLeft.Text = strImageLayoutFrameLeft.ToString();
            edtFrameTop.Text = strImageLayoutFrameTop.ToString();
            edtFrameRight.Text = strImageLayoutFrameRight.ToString();
            edtFrameBottom.Text = strImageLayoutFrameBottom.ToString();


            edtDocNumber.Text = strDocumentNumber;
            edtPageNumber.Text = strPageNumber;
            edtFrameNumber.Text = strFrameNumber;
            edtPageNumber.Text = m_TwainManager.ImageLayoutPageNumber.ToString();
            edtFrameNumber.Text = m_TwainManager.ImageLayoutFrameNumber.ToString();

            txtFileSize.Text = GetImageSize();
        }

        private void dynamicDotNetTwain_OnPreAllTransfers()
        {
            Clear();
        }

        public void LoadConvertResult(ConvertResult result)
        {
        }

        public void OnPostAllTransfers()
        {
            this.BeginInvoke(m_RefreshInfo, (int)m_TwainManager.ImageXResolution,
                            (int)m_TwainManager.ImageYResolution,
                            (int)m_TwainManager.ImageWidth,
                            (int)m_TwainManager.ImageLength,
                            m_TwainManager.ImageBitsPerPixel.ToString(),
                            m_TwainManager.ImagePixelType.ToString(),
                            m_TwainManager.GetImageLayout().Left.ToString(),
                            m_TwainManager.GetImageLayout().Top.ToString(),
                            m_TwainManager.GetImageLayout().Right.ToString(),
                            m_TwainManager.GetImageLayout().Bottom.ToString(),
                            m_TwainManager.ImageLayoutDocumentNumber.ToString(),
                            m_TwainManager.ImageLayoutPageNumber.ToString(),
                            m_TwainManager.ImageLayoutFrameNumber.ToString()
                            );
            Console.WriteLine("OnPostAllTransfer");
        }

        public bool OnPostTransfer(Bitmap bit)
        {
            m_ImageCore.ImageBuffer.RemoveAllImages();
            m_ImageCore.IO.LoadImage(bit);
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
            if (MultiPDF.Checked)
            {
                return m_ImageCore.ImageBuffer.GetMetaData((short)iPageNumber,EnumMetaDataType.enumAnnotation);
            }
            else
            {
                return m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer,EnumMetaDataType.enumAnnotation);
            }
        }

        public Bitmap GetImage(int iPageNumber)
        {
            if (MultiPDF.Checked)
            {
                return m_ImageCore.ImageBuffer.GetBitmap((short)iPageNumber);
            }
            else
            {
                return m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
            }
        }

        public int GetPageCount()
        {
            if (MultiPDF.Checked)
            {
                return m_ImageCore.ImageBuffer.HowManyImagesInBuffer;
            }
            else
            {
                return 1;
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_TwainManager.Dispose();
        }
    }
}
