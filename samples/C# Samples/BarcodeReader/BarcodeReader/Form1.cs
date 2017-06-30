using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.Core;
using Dynamsoft.Barcode;
using Dynamsoft.PDF;
using Dynamsoft.Core.Enums;
using System.IO;
using System.Runtime.InteropServices;

namespace BarcodeReader
{
    public partial class Form1 : Form,Dynamsoft.PDF.IConvertCallback
    {
        private ImageCore m_ImageCore = null;
        private PDFRasterizer m_PDFRasterizer = null;
        private string m_StrProductKey = "t0068MgAAAENENwNWc7+efmkY+t7se6XaRPFZkvfB7QWiTjHiLykxngQdY09pzVtOvrefXBbVvYFbJSluECHlyxaOvHwUADk=";
        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            m_ImageCore = new ImageCore();
            dsViewer1.Bind(m_ImageCore);
            dsViewer1.OnImageAreaSelected += viewer1_OnImageAreaSelected;
            dsViewer1.OnImageAreaDeselected += viewer1_OnImageAreaDeselected;
            m_PDFRasterizer = new PDFRasterizer(m_StrProductKey);
        }


        protected void InitializeUI()
        {
            cbxFormat.Items.Add("All");
            cbxFormat.Items.Add("OneD");
            cbxFormat.Items.Add("Code 39");
            cbxFormat.Items.Add("Code 128");
            cbxFormat.Items.Add("Code 93");
            cbxFormat.Items.Add("Codabar");
            cbxFormat.Items.Add("Interleaved 2 of 5");
            cbxFormat.Items.Add("EAN-13");
            cbxFormat.Items.Add("EAN-8");
            cbxFormat.Items.Add("UPC-A");
            cbxFormat.Items.Add("UPC-E");
            cbxFormat.Items.Add("PDF417");
            cbxFormat.Items.Add("QRCode");
            cbxFormat.Items.Add("Datamatrix");
            cbxFormat.Items.Add("Industrial 2 of 5");
            cbxFormat.SelectedIndex = 0;
            tbxMaxNum.Text = "10";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedlg = new OpenFileDialog();
            filedlg.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF;*.GIF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF|GIF|*.GIF";
            filedlg.FilterIndex = 0;
            filedlg.Multiselect = true;
            // try to locate images folder
            string imagesFolder = Application.ExecutablePath;

            // we assume we are running under the DotImage install folder
            imagesFolder = imagesFolder.Replace("/", "\\");
            string strPDFDllFolder = imagesFolder;
            int pos = imagesFolder.LastIndexOf("\\Samples\\");
            if (pos != -1)
            {
                imagesFolder = imagesFolder.Substring(0, imagesFolder.IndexOf(@"\", pos)) + @"\Samples\Bin\Images\BarcodeImages\";
            }


            //use this folder as starting point			
            filedlg.InitialDirectory = imagesFolder;

            if (filedlg.ShowDialog() == DialogResult.OK)
            {
                foreach (string strfilename in filedlg.FileNames)
                {
                    pos = strfilename.LastIndexOf(".");
                    if (pos != -1)
                    {
                        string strSuffix = strfilename.Substring(pos, strfilename.Length - pos).ToLower();
                        if (strSuffix.CompareTo(".pdf") == 0)
                        {
                            m_PDFRasterizer.ConvertMode = Dynamsoft.PDF.Enums.EnumConvertMode.enumCM_RENDERALL;
                            m_PDFRasterizer.ConvertToImage(strfilename, "", 200, this as IConvertCallback);
                            continue;
                        }
                    }
                    this.m_ImageCore.IO.LoadImage(strfilename);
                }
                viewer1_OnImageAreaDeselected(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer < 0)
            {
                MessageBox.Show("Please load an image before reading barcode!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Dynamsoft.Barcode.BarcodeReader reader = new Dynamsoft.Barcode.BarcodeReader();
                reader.LicenseKeys = m_StrProductKey;
                reader.ReaderOptions.MaxBarcodesToReadPerPage = int.Parse(tbxMaxNum.Text);
                this.textBox1.Text = "";
                switch (cbxFormat.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.OneD;
                        break;
                    case 2:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_39;
                        break;
                    case 3:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_128;
                        break;
                    case 4:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_93;
                        break;
                    case 5:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODABAR;
                        break;
                    case 6:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.ITF;
                        break;
                    case 7:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_13;
                        break;
                    case 8:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_8;
                        break;
                    case 9:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_A;
                        break;
                    case 10:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_E;
                        break;
                    case 11:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.PDF417;
                        break;
                    case 12:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.QR_CODE;
                        break;
                    case 13:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.DATAMATRIX;
                        break;
                    case 14:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.INDUSTRIAL_25;
                        break;
                }
                this.textBox1.Text = "Recognizing...";
                BarcodeResult[] aryResult = null;
                Rectangle rect = dsViewer1.GetSelectionRect(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                if (rect == Rectangle.Empty)
                {
                    int iWidth = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width;
                    int iHeight = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height;
                    rect = new Rectangle(0, 0, iWidth, iHeight);
                }
                reader.AddRegion(rect.Left,rect.Top,rect.Right,rect.Bottom,false);
                aryResult = reader.DecodeBitmap((Bitmap)(m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)));

                StringBuilder strText = new StringBuilder();
                if (aryResult == null)
                {
                    this.textBox1.Text = "The barcode for selected format is not found.\r\n";
                }
                else
                {
                    strText.AppendFormat(aryResult.Length + " total barcode" + (aryResult.Length == 1 ? "" : "s") + " found.\r\n");
                    for (int i = 0; i < aryResult.Length; i++)
                    {
                        BarcodeResult objResult = aryResult[i];
                        strText.AppendFormat("      Result " + (i + 1) + "\r\n");
                        strText.AppendFormat("      BarcodeFormat: " + objResult.BarcodeFormat.ToString() + "\r\n");
                        strText.AppendFormat("      Text read:{0}\r\n", objResult.BarcodeText);

                    }
                    this.textBox1.Text = strText.ToString();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBox1.Text = "";
            }
        }


        private void dynamicDotNetTwain1_OnTopImageInTheViewChanged(short sImageIndex)
        {
            if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer >= 0)
            {
                Rectangle rect = dsViewer1.GetSelectionRect(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                if (rect == Rectangle.Empty)
                {
                    tbxLeft.Text = "0";
                    tbxTop.Text = "0";
                    tbxRight.Text = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width.ToString();
                    tbxBottom.Text = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height.ToString();
                }
                else
                {
                    tbxLeft.Text = rect.Left.ToString();
                    tbxTop.Text = rect.Top.ToString();
                    tbxRight.Text = rect.Right.ToString();
                    tbxBottom.Text = rect.Bottom.ToString();
                }
            }
        }

        private void viewer1_OnImageAreaSelected(short sImageIndex, int left, int top, int right, int bottom)
        {
            tbxLeft.Text = left.ToString();
            tbxTop.Text = top.ToString();
            tbxRight.Text = right.ToString();
            tbxBottom.Text = bottom.ToString();
        }

        private void viewer1_OnImageAreaDeselected(short sImageIndex)
        {
            tbxLeft.Text = "0";
            tbxTop.Text = "0";
            if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer >= 0)
            {
                tbxRight.Text = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width.ToString();
                tbxBottom.Text = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height.ToString();
            }
            else
            {
                tbxRight.Text = "0";
                tbxBottom.Text = "0";
            }
        }

        private void dynamicDotNetTwain1_OnPostAllTransfers()
        {
            if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer >= 0)
                viewer1_OnImageAreaDeselected(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
        }



        #region IConvertCallback Members

        public void LoadConvertResult(ConvertResult result)
        {
            m_ImageCore.IO.LoadImage(result.Image);

            if (result.Annotations != null)
            {
                m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation,result.Annotations,true);
            }
        }

        #endregion
    }
}
