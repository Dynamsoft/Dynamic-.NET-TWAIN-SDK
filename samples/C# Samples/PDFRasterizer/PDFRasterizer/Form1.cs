using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDFReaderDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Initialization();
            this.dynamicDotNetTwain1.LicenseKeys = "83C721A603BF5301ABCF850504F7B744;83C721A603BF5301AC7A3AA0DF1D92E6;83C721A603BF5301E22CBEC2DD20B511;83C721A603BF5301977D72EA5256A044;83C721A603BF53014332D52C75036F9E;83C721A603BF53010090AB799ED7E55E";
        }

        protected void Initialization()
        {
            this.Icon = new Icon(typeof(Form), "wfc.ico");
            dynamicDotNetTwain1.IfThrowException = false;
            this.cmbPDFResolution.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPDFResolution.Items.Add("100");
            this.cmbPDFResolution.Items.Add("150");
            this.cmbPDFResolution.Items.Add("200");
            this.cmbPDFResolution.Items.Add("300");
            this.cmbPDFResolution.SelectedIndex = 0;

            this.rdbBMP.Checked = true;
            
            string strDllFolder = Application.ExecutablePath;
            strDllFolder = strDllFolder.Replace("/", "\\");
            int pos = strDllFolder.LastIndexOf("\\Samples\\");
            if (pos != -1)
            {
                strDllFolder = strDllFolder.Substring(0, strDllFolder.IndexOf(@"\", pos)) + @"\Redistributable\Resources\PDF\";
            }
            else
            {
                pos = strDllFolder.LastIndexOf("\\");
                strDllFolder = strDllFolder.Substring(0, strDllFolder.IndexOf(@"\", pos)) + @"\";
            }

            dynamicDotNetTwain1.PDFRasterizerDllPath = strDllFolder;
            dynamicDotNetTwain1.IfShowCancelDialogWhenBarcodeOrOCR = true;
        }

        private void btnLoadPDF_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfiledlg = new OpenFileDialog();
                openfiledlg.Filter = "PDF|*.PDF";
                openfiledlg.FilterIndex = 0;
                openfiledlg.Multiselect = true;

                if (openfiledlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (string strfilename in openfiledlg.FileNames)
                    {
			            this.dynamicDotNetTwain1.PDFConvertMode = Dynamsoft.DotNet.TWAIN.Enums.EnumPDFConvertMode.enumCM_RENDERALL;
                        this.dynamicDotNetTwain1.SetPDFResolution(uint.Parse(cmbPDFResolution.SelectedItem.ToString()));
			            this.dynamicDotNetTwain1.LoadImage(strfilename);
                        //this.dynamicDotNetTwain1.ConvertPDFToImage(strfilename, float.Parse(cmbPDFResolution.SelectedItem.ToString()));
                        if (this.dynamicDotNetTwain1.ErrorCode != Dynamsoft.DotNet.TWAIN.Enums.ErrorCode.Succeed)
                            MessageBox.Show(this.dynamicDotNetTwain1.ErrorString, "PDF Rasterizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dynamicDotNetTwain1.HowManyImagesInBuffer > 0)
                {
                    this.labMsg.Text = "";
                    SaveFileDialog savefdlg = new SaveFileDialog();
                    savefdlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
                    savefdlg.FileName = "";

                    if (rdbBMP.Checked == true)
                    {
                        savefdlg.Filter = "BMP File(*.bmp)| *.bmp";

                    }

                    if (rdbJPEG.Checked == true)
                    {
                        savefdlg.Filter = "JPEG File(*.jpeg)| *.jpeg";

                    }

                    if (rdbPNG.Checked == true)
                    {
                        savefdlg.Filter = "PNG File(*.png) | *.png";

                    }

                    if (rdbTIFF.Checked == true)
                    {
                        savefdlg.Filter = "TIFF File(*.tiff)| *.tiff";

                    }

                    if (rdbPDF.Checked == true)
                    {
                        savefdlg.Filter = "PDF File(*.pdf)| *.pdf";

                    }

                    if (savefdlg.ShowDialog() == DialogResult.OK)
                    {

                        string strFilename = savefdlg.FileName;

                        if (rdbBMP.Checked == true)
                        {
                            this.dynamicDotNetTwain1.SaveAsBMP(strFilename, this.dynamicDotNetTwain1.CurrentImageIndexInBuffer);
                        }

                        if (rdbJPEG.Checked == true)
                        {
                            this.dynamicDotNetTwain1.SaveAsJPEG(strFilename, this.dynamicDotNetTwain1.CurrentImageIndexInBuffer);
                        }

                        if (rdbPNG.Checked == true)
                        {
                            this.dynamicDotNetTwain1.SaveAsPNG(strFilename, this.dynamicDotNetTwain1.CurrentImageIndexInBuffer);
                        }

                        if (rdbTIFF.Checked == true)
                        {
                            if (chbMultiPageTIFF.Checked == true)
                            {
                                this.dynamicDotNetTwain1.SaveAllAsMultiPageTIFF(strFilename);
                            }
                            else
                                this.dynamicDotNetTwain1.SaveAsTIFF(strFilename, dynamicDotNetTwain1.CurrentImageIndexInBuffer);
                        }

                        if (rdbPDF.Checked == true)
                        {
                            dynamicDotNetTwain1.IfSaveAnnotations = true;
                            if (chbMultiPagePDF.Checked == true)
                                dynamicDotNetTwain1.SaveAllAsPDF(strFilename);
                            else
                                dynamicDotNetTwain1.SaveAsPDF(strFilename, dynamicDotNetTwain1.CurrentImageIndexInBuffer);
                        }
                    }
                }
                else
                {
                    this.labMsg.ForeColor = Color.Red;
                    this.labMsg.Text = "Please load a PDF file first";
                    this.labMsg.Location = new Point(this.groupBox2.Size.Width / 2 - this.labMsg.Size.Width / 2, this.labMsg.Location.Y);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void rdbBMP_CheckedChanged(object sender, EventArgs e)
        {
            chbMultiPagePDF.Checked = false;
            chbMultiPagePDF.Enabled = false;
            chbMultiPageTIFF.Checked = false;
            chbMultiPageTIFF.Enabled = false;
        }

        private void rdbJPEG_CheckedChanged(object sender, EventArgs e)
        {
            chbMultiPagePDF.Checked = false;
            chbMultiPagePDF.Enabled = false;
            chbMultiPageTIFF.Checked = false;
            chbMultiPageTIFF.Enabled = false;
        }

        private void rdbPNG_CheckedChanged(object sender, EventArgs e)
        {
            chbMultiPagePDF.Checked = false;
            chbMultiPagePDF.Enabled = false;
            chbMultiPageTIFF.Checked = false;
            chbMultiPageTIFF.Enabled = false;
        }

        private void rdbTIFF_CheckedChanged(object sender, EventArgs e)
        {
            chbMultiPagePDF.Checked = false;
            chbMultiPagePDF.Enabled = false;
            chbMultiPageTIFF.Checked = true;
            chbMultiPageTIFF.Enabled = true;
        }

        private void rdbPDF_CheckedChanged(object sender, EventArgs e)
        {
            chbMultiPagePDF.Checked = true;
            chbMultiPagePDF.Enabled = true;
            chbMultiPageTIFF.Checked = false;
            chbMultiPageTIFF.Enabled = false;
        }

    }
}
