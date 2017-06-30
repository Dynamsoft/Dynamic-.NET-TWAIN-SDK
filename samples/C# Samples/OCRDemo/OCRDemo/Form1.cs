using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.Core;
using Dynamsoft.OCR;
using System.IO;
using Dynamsoft.Forms;
using Dynamsoft.PDF;
using Dynamsoft.Core.Enums;
using System.Runtime.InteropServices;

namespace OCRDemo
{
    public partial class Form1 : Form,IConvertCallback
    {
        private string m_StrProductKey = "t0068MgAAAENENwNWc7+efmkY+t7se6XaRPFZkvfB7QWiTjHiLykxngQdY09pzVtOvrefXBbVvYFbJSluECHlyxaOvHwUADk=";
        private ImageCore m_ImageCore = null;
        private Tesseract m_Tesseract = null;
        private PDFRasterizer m_PDFRasterizer = null;

        public Form1()
        {
            InitializeComponent();
            m_Tesseract = new Tesseract(m_StrProductKey);
            m_ImageCore = new ImageCore();
            dsViewer1.Bind(m_ImageCore);
            m_PDFRasterizer = new PDFRasterizer(m_StrProductKey);
            dsViewer1.OnImageAreaSelected += new Dynamsoft.Forms.Delegate.OnImageAreaSelectedHandler(dsViewer1_OnImageAreaSelected);
            dsViewer1.OnImageAreaDeselected += dynamicDotNetTwain1_OnImageAreaDeselected;
            dsViewer1.OnMouseClick += dynamicDotNetTwain1_OnImageAreaDeselected;
        }

        void dsViewer1_OnImageAreaSelected(short sImageIndex, int left, int top, int right, int bottom)
        {
            tbxLeft.Text = left.ToString();
            tbxTop.Text = top.ToString();
            tbxRight.Text = right.ToString();
            tbxBottom.Text = bottom.ToString();
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
            }

            filedlg.InitialDirectory = imageFolder;


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
                            m_PDFRasterizer.ConvertMode = Dynamsoft.PDF.Enums.EnumConvertMode.enumCM_RENDERALL;
                            m_PDFRasterizer.ConvertToImage(strfilename,"",200,this as IConvertCallback);
                            continue;
                        }
                    }
                    m_ImageCore.IO.LoadImage(strfilename);
                }
                dynamicDotNetTwain1_OnImageAreaDeselected(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
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
            else
            {
                languageFolder = Application.StartupPath + "\\Bin";
            }

            m_Tesseract.TessDataPath = languageFolder;
            m_Tesseract.Language = languages[this.cbxOCRLanguage.Text];
            m_Tesseract.ResultFormat = (Dynamsoft.OCR.Enums.ResultFormat)this.ddlResultFormat.SelectedIndex;

            string strDllPath = m_strCurrentDirectory;

            if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer < 0)
            {
                MessageBox.Show("Please load an image before doing OCR!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            byte[] sbytes = null;

            List<short> tempListSelectedIndex = dsViewer1.CurrentSelectedImageIndicesInBuffer;
            List<Bitmap> tempListSelectedBitmap = null;
            foreach(short index in tempListSelectedIndex)
            {
                if (index >= 0 && index < m_ImageCore.ImageBuffer.HowManyImagesInBuffer)
                {
                    if (tempListSelectedBitmap == null)
                    {
                        tempListSelectedBitmap = new List<Bitmap>();
                    }
                    Bitmap temp = m_ImageCore.ImageBuffer.GetBitmap(index);
                    tempListSelectedBitmap.Add(temp);
                }
            }
            if (!isOcrOnRectangleArea)
            {
                if(tempListSelectedBitmap !=null)
                    sbytes = m_Tesseract.Recognize(tempListSelectedBitmap);
            }
            else
            {
                Rectangle tempRect = Rectangle.Empty;
                try
                {
                    if (int.Parse(tbxRight.Text) == 0 || int.Parse(tbxBottom.Text) == 0)
                    {
                        MessageBox.Show("The width or height of the selected rectangle can not be 0.");
                        return;
                    }
                    sbytes = m_Tesseract.Recognize(m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer), int.Parse(tbxLeft.Text),
int.Parse(tbxTop.Text), int.Parse(tbxRight.Text), int.Parse(tbxBottom.Text));

                }
                catch(Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

            }


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
        }

        Dictionary<string, string> languages = new Dictionary<string, string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            dsViewer1.SetViewMode(2, 2);
            cbxViewMode.SelectedIndex = 1;
            dsViewer1.AllowMultiSelect = true;

            languages.Add("English", "eng");
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
                imageFolder = m_strCurrentDirectory+@"Bin\Images\OCRImages\";
            }

            m_ImageCore.IO.LoadImage(imageFolder + @"\DNTImage1.tif");
            m_ImageCore.IO.LoadImage(imageFolder + @"\DNTImage2.tif");
            m_ImageCore.IO.LoadImage(imageFolder + @"\DNTImage3.tif");
            m_ImageCore.IO.LoadImage(imageFolder + @"\DNTImage4.tif");
            m_ImageCore.IO.LoadImage(imageFolder + @"\DNTImage5.tif");
            m_ImageCore.IO.LoadImage(imageFolder + @"\DNTImage6.tif");
            m_ImageCore.IO.LoadImage(imageFolder + @"\DNTImage7.tif");
            dynamicDotNetTwain1_OnImageAreaDeselected(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
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
            if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer >= 0)
            {
                tbxRight.Text = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width.ToString();
                tbxBottom.Text = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height.ToString();
            }
        }

        private void btnOCRArea_Click(object sender, EventArgs e)
        {
            OCR(true);
        }

        private void cbxViewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            dsViewer1.SetViewMode((short)(cbxViewMode.SelectedIndex + 1), (short)(cbxViewMode.SelectedIndex + 1));
        }


        public void LoadConvertResult(ConvertResult result)
        {
            m_ImageCore.IO.LoadImage(result.Image);
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation,result.Annotations,true);
        }
    }
}
