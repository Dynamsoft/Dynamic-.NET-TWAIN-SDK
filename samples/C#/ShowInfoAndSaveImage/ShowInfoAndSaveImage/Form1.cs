using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShowInfoAndSaveImage
{
    public partial class Form1 : Form
    {
        Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat sImageType;
        public Form1()
        {
            InitializeComponent();

            BMPradio.Checked = true;
            sImageType = 0;
            MultiTIFF.Enabled = false;
            MultiPDF.Enabled = false;

            dynamicDotNetTwain.ScanInNewProcess = true;
        }

        public string GetImageSize()
        {
            string ImageSize = "";
            if (dynamicDotNetTwain.HowManyImagesInBuffer != 0)
            {
                ImageSize = dynamicDotNetTwain.GetImageSizeWithSpecifiedType(dynamicDotNetTwain.CurrentImageIndexInBuffer, sImageType).ToString();
            }
            return ImageSize;
        }
  
        private void btnScan_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.IfDisableSourceAfterAcquire = true;
            if (dynamicDotNetTwain.SelectSource())
                dynamicDotNetTwain.AcquireImage();
        }

        private void TIFFradio_CheckedChanged(object sender, EventArgs e)
        {
            MultiTIFF.Enabled = true;
            MultiPDF.Enabled = false;
            sImageType = Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_TIF;
            txtFileSize.Text = GetImageSize();
        }

        private void PDFradio_CheckedChanged(object sender, EventArgs e)
        {
            MultiTIFF.Enabled = false;
            MultiPDF.Enabled = true;
            sImageType = Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_PDF;
            txtFileSize.Text = GetImageSize();
        }


        private void BMPradio_CheckedChanged(object sender, EventArgs e)
        {
            MultiTIFF.Enabled = false;
            MultiPDF.Enabled = false;
            sImageType = Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_BMP;
            txtFileSize.Text = GetImageSize();

        }

        private void JPEGradio_CheckedChanged(object sender, EventArgs e)
        {
            MultiTIFF.Enabled = false;
            MultiPDF.Enabled = false;
            sImageType =  Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_JPG;
            txtFileSize.Text = GetImageSize();
        }

        private void PNGradio_CheckedChanged(object sender, EventArgs e)
        {
            MultiTIFF.Enabled = false;
            MultiPDF.Enabled = false;
            sImageType =  Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_PNG;
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
            if (this.dynamicDotNetTwain.HowManyImagesInBuffer > 0)
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
                        dynamicDotNetTwain.SaveAsBMP(strFile, dynamicDotNetTwain.CurrentImageIndexInBuffer);
                    }
                    else if (JPEGradio.Checked == true)
                    {

                        dynamicDotNetTwain.SaveAsJPEG(strFile, dynamicDotNetTwain.CurrentImageIndexInBuffer);
                    }
                    else if (PNGradio.Checked == true)
                    {

                        dynamicDotNetTwain.SaveAsPNG(strFile, dynamicDotNetTwain.CurrentImageIndexInBuffer);
                    }
                    else if (TIFFradio.Checked == true)
                    {

                        if (MultiTIFF.Checked == true)
                        {
                            dynamicDotNetTwain.SaveAllAsMultiPageTIFF(strFile);
                        }
                        else
                        {
                            dynamicDotNetTwain.SaveAsTIFF(strFile, dynamicDotNetTwain.CurrentImageIndexInBuffer);
                        }
                    }
                    else if (PDFradio.Checked == true)
                    {
                        dynamicDotNetTwain.IfSaveAnnotations = true;
                        if (MultiPDF.Checked == true)
                        {
                            dynamicDotNetTwain.SaveAllAsPDF(strFile);
                        }
                        else
                        {
                            dynamicDotNetTwain.SaveAsPDF(strFile, dynamicDotNetTwain.CurrentImageIndexInBuffer);
                        }
                    }
                }
            }      
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.RemoveImage(dynamicDotNetTwain.CurrentImageIndexInBuffer);
            btnScan.Enabled = true;
        }


        private void dynamicDotNetTwain_OnMouseClick(short sImageIndex)
        {
            dynamicDotNetTwain.CurrentImageIndexInBuffer = sImageIndex;
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
            if (dynamicDotNetTwain.HowManyImagesInBuffer >= dynamicDotNetTwain.MaxImagesInBuffer)
            {
                btnScan.Enabled = false;
            }
        }


        private void ShowImageInfo()
        {
            edtXResolution.Text = dynamicDotNetTwain.ImageXResolution.ToString();
            edtYResolution.Text = dynamicDotNetTwain.ImageYResolution.ToString();
            edtWidth.Text = dynamicDotNetTwain.ImageWidth.ToString();
            edtLength.Text = dynamicDotNetTwain.ImageLength.ToString();
            edtBitsPerPixel.Text = dynamicDotNetTwain.ImageBitsPerPixel.ToString();
            edtPixelType.Text = dynamicDotNetTwain.ImagePixelType.ToString();

            edtFrameLeft.Text = dynamicDotNetTwain.ImageLayoutFrameLeft.ToString();
            edtFrameTop.Text = dynamicDotNetTwain.ImageLayoutFrameTop.ToString();
            edtFrameRight.Text = dynamicDotNetTwain.ImageLayoutFrameRight.ToString();
            edtFrameBottom.Text = dynamicDotNetTwain.ImageLayoutFrameBottom.ToString();
            edtDocNumber.Text = dynamicDotNetTwain.ImageLayoutDocumentNumber.ToString();
            edtPageNumber.Text = dynamicDotNetTwain.ImageLayoutPageNumber.ToString();
            edtFrameNumber.Text = dynamicDotNetTwain.ImageLayoutFrameNumber.ToString();

            txtFileSize.Text = GetImageSize();
        }

        private void dynamicDotNetTwain_OnPostAllTransfers()
        {
            ShowImageInfo();
        }

       
    }
}