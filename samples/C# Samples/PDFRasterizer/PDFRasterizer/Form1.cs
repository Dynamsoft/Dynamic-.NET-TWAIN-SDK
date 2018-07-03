using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.PDF;
using Dynamsoft.Core;
using Dynamsoft.Core.Enums;
using System.IO;
using System.Runtime.InteropServices;

namespace Rasterizer
{
    public partial class Form1 : Form,IConvertCallback,ISave
    {
        private Dynamsoft.PDF.PDFRasterizer m_PDFRasteizer = null;
        private PDFCreator m_PDFCreator = null;
        private string m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU=";
        private ImageCore m_ImageCore = null;
        public Form1()
        {
            InitializeComponent();
            Initialization();
            m_PDFRasteizer = new Dynamsoft.PDF.PDFRasterizer(m_StrProductKey);
            m_PDFCreator = new PDFCreator(m_StrProductKey);
            m_ImageCore = new ImageCore();
            dsViewer1.Bind(m_ImageCore);
            chbMultiPagePDF.Checked = false;
            chbMultiPagePDF.Enabled = false;
            chbMultiPageTIFF.Checked = false;
            chbMultiPageTIFF.Enabled = false;
            
        }


        protected void Initialization()
        {
            this.Icon = new Icon(typeof(Form), "wfc.ico");
            this.cmbPDFResolution.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPDFResolution.Items.Add("100");
            this.cmbPDFResolution.Items.Add("150");
            this.cmbPDFResolution.Items.Add("200");
            this.cmbPDFResolution.Items.Add("300");
            this.cmbPDFResolution.SelectedIndex = 0;

            this.rdbBMP.Checked = true;

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
                        m_PDFRasteizer.ConvertMode = Dynamsoft.PDF.Enums.EnumConvertMode.enumCM_RENDERALL;
                        m_PDFRasteizer.ConvertToImage(strfilename, "", int.Parse(cmbPDFResolution.Text), this as IConvertCallback);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0)
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
                            m_ImageCore.IO.SaveAsBMP(strFilename, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                        }

                        if (rdbJPEG.Checked == true)
                        {
                            m_ImageCore.IO.SaveAsJPEG(strFilename, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                        }

                        if (rdbPNG.Checked == true)
                        {
                            m_ImageCore.IO.SaveAsPNG(strFilename, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                        }

                        if (rdbTIFF.Checked == true)
                        {
                            List<short> tempListIndex = new List<short>();
                            if (chbMultiPageTIFF.Checked == true)
                            {
                                for (short sIndex = 0; sIndex < m_ImageCore.ImageBuffer.HowManyImagesInBuffer; sIndex++)
                                {
                                    tempListIndex.Add(sIndex);
                                }
                            }
                            else
                            {
                                tempListIndex.Add(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                            }
                            m_ImageCore.IO.SaveAsTIFF(strFilename,tempListIndex);
                        }

                        if (rdbPDF.Checked == true)
                        {
                            m_PDFCreator.Save(this as ISave,strFilename);
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

        #region IConvertCallback Members

        public void LoadConvertResult(ConvertResult result)
        {
            m_ImageCore.IO.LoadImage(result.Image);
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer,EnumMetaDataType.enumAnnotation,result.Annotations,true);
        }

        #endregion

        #region ISave Members

        public object GetAnnotations(int iPageNumber)
        {
            if (chbMultiPagePDF.Checked)
            {
                return m_ImageCore.ImageBuffer.GetMetaData((short)iPageNumber, EnumMetaDataType.enumAnnotation);
            }
            else
            {
                return m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer,EnumMetaDataType.enumAnnotation);
            }

        }

        public Bitmap GetImage(int iPageNumber)
        {
            if (chbMultiPagePDF.Checked)
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
            if (chbMultiPagePDF
                .Checked)
            {
                return m_ImageCore.ImageBuffer.HowManyImagesInBuffer;
            }
            else
            {
                return 1;
            }

        }

        #endregion
    }
}
