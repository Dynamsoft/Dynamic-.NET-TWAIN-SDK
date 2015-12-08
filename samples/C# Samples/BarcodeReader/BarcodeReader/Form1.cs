using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.DotNet.TWAIN.Enums.Barcode;
using Dynamsoft.DotNet.TWAIN.Barcode;
using System.Collections;
using Dynamsoft.DotNet.TWAIN;
using Dynamsoft.Barcode;

namespace BarcodeDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            this.dynamicDotNetTwain1.ScanInNewProcess = true;
            this.dynamicDotNetTwain1.LicenseKeys = "BAF81AB5515958BF519F7AAE2A318B3B;BAF81AB5515958BF6DA4299CBA3CC11D;BAF81AB5515958BF9C195A4722534974;BAF81AB5515958BFE96B7433DD28E75B;BAF81AB5515958BF3DBAF9AB37059787;BAF81AB5515958BF5291EEE0B030BD82";
        }

        protected void InitializeUI()
        {
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
                strPDFDllFolder = strPDFDllFolder.Substring(0, strPDFDllFolder.IndexOf(@"\", pos)) + @"\Redistributable\PDFResources\";
            }
            else
            {
                pos = imagesFolder.LastIndexOf("\\");
                imagesFolder = imagesFolder.Substring(0, imagesFolder.IndexOf(@"\", pos)) + @"\";
                strPDFDllFolder = imagesFolder;
            }

            dynamicDotNetTwain1.PDFRasterizerDllPath = strPDFDllFolder;
            dynamicDotNetTwain1.IfShowCancelDialogWhenBarcodeOrOCR = true;
            dynamicDotNetTwain1.MaxImagesInBuffer = 64;

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
                            this.dynamicDotNetTwain1.ConvertPDFToImage(strfilename, 200);
                            continue;
                        }
                    }
                    this.dynamicDotNetTwain1.LoadImage(strfilename);
                }
                dynamicDotNetTwain1_OnImageAreaDeselected(dynamicDotNetTwain1.CurrentImageIndexInBuffer);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dynamicDotNetTwain1.CurrentImageIndexInBuffer < 0)
            {
                MessageBox.Show("Please load an image before reading barcode!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                BarcodeReader reader = new BarcodeReader();
                reader.LicenseKeys = "91392547848AAF2410B494747EADA719";
                reader.ReaderOptions.MaxBarcodesToReadPerPage = int.Parse(tbxMaxNum.Text);
                this.textBox1.Text = "";
                switch (cbxFormat.SelectedIndex)
                {
                    case 0:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.OneD;
                        break;
                    case 1:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_39;
                        break;
                    case 2:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_128;
                        break;
                    case 3:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_93;
                        break;
                    case 4:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODABAR;
                        break;
                    case 5:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.ITF;
                        break;
                    case 6:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_13;
                        break;
                    case 7:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_8;
                        break;
                    case 8:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_A;
                        break;
                    case 9:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_E;
                        break;
                    case 10:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.PDF417;
                        break;
                    case 11:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.QR_CODE;
                        break;
                    case 12:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.DATAMATRIX;
                        break;
                    case 13:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.INDUSTRIAL_25;
                        break;
                }
                this.textBox1.Text = "Recognizing...";
                BarcodeResult[] aryResult = null;
                Rectangle rect = dynamicDotNetTwain1.GetSelectionRect(dynamicDotNetTwain1.CurrentImageIndexInBuffer);
                if (rect == Rectangle.Empty)
                {
                    int iWidth = dynamicDotNetTwain1.GetImage(dynamicDotNetTwain1.CurrentImageIndexInBuffer).Width;
                    int iHeight = dynamicDotNetTwain1.GetImage(dynamicDotNetTwain1.CurrentImageIndexInBuffer).Height;
                    rect = new Rectangle(0, 0, iWidth, iHeight);
                }
                aryResult = reader.DecodeBitmapRect((Bitmap)(dynamicDotNetTwain1.GetImage(this.dynamicDotNetTwain1.CurrentImageIndexInBuffer)), rect);

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
                        strText.AppendFormat("      Text read: " + objResult.BarcodeText + "\r\n");

                    }
                    this.textBox1.Text = strText.ToString();
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBox1.Text = "";
            }
        }

        private void dynamicDotNetTwain1_OnTopImageInTheViewChanged(short sImageIndex)
        {
            if (dynamicDotNetTwain1.CurrentImageIndexInBuffer >= 0)
            {
                Rectangle rect = dynamicDotNetTwain1.GetSelectionRect(dynamicDotNetTwain1.CurrentImageIndexInBuffer);
                if (rect == Rectangle.Empty)
                {
                    tbxLeft.Text = "0";
                    tbxTop.Text = "0";
                    tbxRight.Text = dynamicDotNetTwain1.GetImage(dynamicDotNetTwain1.CurrentImageIndexInBuffer).Width.ToString();
                    tbxBottom.Text = dynamicDotNetTwain1.GetImage(dynamicDotNetTwain1.CurrentImageIndexInBuffer).Height.ToString();
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

        private void dynamicDotNetTwain1_OnImageAreaSelected(short sImageIndex, int left, int top, int right, int bottom)
        {
            tbxLeft.Text = left.ToString();
            tbxTop.Text = top.ToString();
            tbxRight.Text = right.ToString();
            tbxBottom.Text = bottom.ToString();
        }

        private void dynamicDotNetTwain1_OnImageAreaDeselected(short sImageIndex)
        {
            tbxLeft.Text = "0";
            tbxTop.Text = "0";
            if (dynamicDotNetTwain1.CurrentImageIndexInBuffer >= 0)
            {
                tbxRight.Text = dynamicDotNetTwain1.GetImage(dynamicDotNetTwain1.CurrentImageIndexInBuffer).Width.ToString();
                tbxBottom.Text = dynamicDotNetTwain1.GetImage(dynamicDotNetTwain1.CurrentImageIndexInBuffer).Height.ToString();
            }
            else
            {
                tbxRight.Text = "0";
                tbxBottom.Text = "0";
            }
        }

        private void dynamicDotNetTwain1_OnPostAllTransfers()
        {
            if(dynamicDotNetTwain1.CurrentImageIndexInBuffer >=0)
            dynamicDotNetTwain1_OnImageAreaDeselected(dynamicDotNetTwain1.CurrentImageIndexInBuffer);
        }

    }
}
