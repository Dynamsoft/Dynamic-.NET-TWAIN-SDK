using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace OCRDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dynamicDotNetTwain1.IfShowCancelDialogWhenBarcodeOrOCR = true;
            this.dynamicDotNetTwain1.ScanInNewProcess = true;
            this.dynamicDotNetTwain1.LicenseKeys = "83C721A603BF5301ABCF850504F7B744;83C721A603BF5301AC7A3AA0DF1D92E6;83C721A603BF5301E22CBEC2DD20B511;83C721A603BF5301977D72EA5256A044;83C721A603BF53014332D52C75036F9E;83C721A603BF53010090AB799ED7E55E";
        }

        private string m_strCurrentDirectory;
        private bool m_bSamplesExist = false;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedlg = new OpenFileDialog();
            filedlg.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF;*.GIF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF|GIF|*.GIF";
            filedlg.Multiselect = true;
            string imageFolder = m_strCurrentDirectory;
            string strPDFDllFolder = imageFolder;
            if (m_bSamplesExist)
            {
                imageFolder = m_strCurrentDirectory + @"Samples\Bin\Images\OCRImages\";
                strPDFDllFolder = m_strCurrentDirectory + @"Redistributable\Resources\PDF\";
            }

            filedlg.InitialDirectory = imageFolder;

            dynamicDotNetTwain1.PDFRasterizerDllPath = strPDFDllFolder;
            dynamicDotNetTwain1.IfShowCancelDialogWhenBarcodeOrOCR = true;
            dynamicDotNetTwain1.MaxImagesInBuffer = 64;

            if (filedlg.ShowDialog() == DialogResult.OK)
            {
                foreach (string strfilename in filedlg.FileNames)
                {
                    int pos = strfilename.LastIndexOf(".");
                    if (pos != -1)
                    {
                        string strSuffix = strfilename.Substring(pos, strfilename.Length - pos).ToLower();
                        if (strSuffix.CompareTo(".pdf") == 0)
                        {
			                this.dynamicDotNetTwain1.PDFConvertMode = Dynamsoft.DotNet.TWAIN.Enums.EnumPDFConvertMode.enumCM_RENDERALL;
                            this.dynamicDotNetTwain1.SetPDFResolution(200);
			                this.dynamicDotNetTwain1.LoadImage(strfilename);
                            //this.dynamicDotNetTwain1.ConvertPDFToImage(strfilename, 200);
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
            OCR(false);
        }

        private void OCR(bool isOcrOnRectangleArea)
        {
            string languageFolder = m_strCurrentDirectory;
            if (m_bSamplesExist)
            {
                languageFolder = m_strCurrentDirectory + @"Samples\Bin\";
            }

            this.dynamicDotNetTwain1.OCRTessDataPath = languageFolder;
            this.dynamicDotNetTwain1.OCRLanguage = languages[this.cbxOCRLanguage.Text];
            this.dynamicDotNetTwain1.OCRResultFormat = (Dynamsoft.DotNet.TWAIN.OCR.ResultFormat)this.ddlResultFormat.SelectedIndex;

            string strDllPath = m_strCurrentDirectory;
            if (m_bSamplesExist)
            {
                strDllPath = m_strCurrentDirectory + @"Redistributable\Resources\OCR\";
            }

            this.dynamicDotNetTwain1.OCRDllPath = strDllPath;
            //this.dynamicDotNetTwain1.OCRPageSetMode = (Dynamsoft.DotNet.TWAIN.OCR.PageSetMode)cbxOCRPageSetMode.SelectedValue;

            if (this.dynamicDotNetTwain1.CurrentImageIndexInBuffer < 0)
            {
                MessageBox.Show("Please load an image before doing OCR!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] sbytes = null;
            if (!isOcrOnRectangleArea)
                sbytes = this.dynamicDotNetTwain1.OCR(this.dynamicDotNetTwain1.CurrentSelectedImageIndicesInBuffer);
            else
                sbytes = this.dynamicDotNetTwain1.OCR(dynamicDotNetTwain1.CurrentImageIndexInBuffer, int.Parse(tbxLeft.Text),
                    int.Parse(tbxTop.Text), int.Parse(tbxRight.Text), int.Parse(tbxBottom.Text));

            if (sbytes != null && sbytes.Length > 0)
            {
                SaveFileDialog filedlg = new SaveFileDialog();
                if (this.ddlResultFormat.SelectedIndex != 0)
                {
                    filedlg.Filter = "PDF File(*.pdf)| *.pdf";
                }
                else
                {
                    filedlg.Filter = "Text File(*.txt)| *.txt";
                }
                if (filedlg.ShowDialog() == DialogResult.OK)
                {                   
                    File.WriteAllBytes(filedlg.FileName, sbytes);    
                }
            }
            else
            {
                if(this.dynamicDotNetTwain1.ErrorCode != 0)
                    MessageBox.Show(this.dynamicDotNetTwain1.ErrorString);
            }
        }

        Dictionary<string, string> languages = new Dictionary<string, string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dynamicDotNetTwain1.SetViewMode(2,2);
            cbxViewMode.SelectedIndex = 1;
            this.dynamicDotNetTwain1.AllowMultiSelect = true;

            languages.Add("English", "eng");
            //languages.Add("Arabic", "ara");
            //languages.Add("Bulgarian", "bul");
            //languages.Add("Catalan", "cat");
            //languages.Add("Czech", "ces");
            //languages.Add("Chinese (Simplified)", "chi_sim");
            //languages.Add("Chinese (Traditional)", "chi_tra");
            //languages.Add("Cherokee", "chr");
            //languages.Add("Danish (frak)", "dan-frak");
            //languages.Add("Danish", "dan");
            //languages.Add("Dutch", "nld");
            //languages.Add("German (frak)", "deu-frak");
            //languages.Add("German", "deu");
            //languages.Add("Greek", "ell");
            //languages.Add("Finnish", "fin");
            //languages.Add("French", "fra");
            //languages.Add("Hebrew (ras)", "heb-ras");
            //languages.Add("Hebrew (seg)", "heb-seg");
            //languages.Add("Hebrew", "heb");
            //languages.Add("Hindi", "hin");
            //languages.Add("Hungarian", "hun");
            //languages.Add("Indonesian", "ind");
            //languages.Add("Italian", "ita");
            //languages.Add("Japanese", "jpn");
            //languages.Add("Korean", "kor");
            //languages.Add("Latvian", "lav");
            //languages.Add("Lithuanian", "lit");
            //languages.Add("Norwegian", "nor");
            //languages.Add("Polish", "pol");
            //languages.Add("Portuguese", "por");
            //languages.Add("Romanian", "ron");
            //languages.Add("Russian", "rus");
            //languages.Add("Slovak (frak)", "slk-frak");
            //languages.Add("Slovak", "slk");
            //languages.Add("Slovenian", "slv");
            //languages.Add("Spanish", "spa");
            //languages.Add("Serbian", "srp");
            //languages.Add("Swedish (frak)", "swe-frak");
            //languages.Add("Swedish", "swe");
            //languages.Add("Thai", "tha");
            //languages.Add("Turkish", "tur");
            //languages.Add("Ukrainian", "ukr");
            //languages.Add("Vietnamese", "vie");
            foreach (string str in languages.Keys)
            {
                this.cbxOCRLanguage.Items.Add(str);
            }
            this.cbxOCRLanguage.SelectedIndex = 0;

            this.ddlResultFormat.Items.Add("Text File");
            this.ddlResultFormat.Items.Add("Adobe PDF Plain Text File");
            this.ddlResultFormat.Items.Add("Adobe PDF Image Over Text File");
            this.ddlResultFormat.SelectedIndex = 0;

            string imageFolder = Application.ExecutablePath;
            imageFolder = imageFolder.Replace("/", "\\");
            int pos = imageFolder.LastIndexOf("\\Samples\\");
            if (pos != -1)
            {
                m_bSamplesExist = true;
                m_strCurrentDirectory = imageFolder.Substring(0, imageFolder.IndexOf(@"\", pos)) + @"\";
                imageFolder = m_strCurrentDirectory + @"Samples\Bin\Images\OCRImages\";
            }
            else
            {
                m_bSamplesExist = false;
                pos = imageFolder.LastIndexOf("\\");
                m_strCurrentDirectory = imageFolder.Substring(0, imageFolder.IndexOf(@"\", pos)) + @"\";
                imageFolder = m_strCurrentDirectory;
            }

            this.dynamicDotNetTwain1.LoadImage(imageFolder + @"\DNTImage1.tif");
            this.dynamicDotNetTwain1.LoadImage(imageFolder + @"\DNTImage2.tif");
            this.dynamicDotNetTwain1.LoadImage(imageFolder + @"\DNTImage3.tif");
            this.dynamicDotNetTwain1.LoadImage(imageFolder + @"\DNTImage4.tif");
            this.dynamicDotNetTwain1.LoadImage(imageFolder + @"\DNTImage5.tif");
            this.dynamicDotNetTwain1.LoadImage(imageFolder + @"\DNTImage6.tif");
            this.dynamicDotNetTwain1.LoadImage(imageFolder + @"\DNTImage7.tif");
            dynamicDotNetTwain1_OnImageAreaDeselected(dynamicDotNetTwain1.CurrentImageIndexInBuffer);
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
        }

        private void btnOCRArea_Click(object sender, EventArgs e)
        {
            OCR(true);
        }

        private void cbxViewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            dynamicDotNetTwain1.SetViewMode((short)(cbxViewMode.SelectedIndex + 1), (short)(cbxViewMode.SelectedIndex + 1));
        }

    }
}
