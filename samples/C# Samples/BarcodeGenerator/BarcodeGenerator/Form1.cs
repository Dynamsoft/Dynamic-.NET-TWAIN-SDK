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


namespace BarcodeGenerator
{
    public partial class Form1 : Form,ISave,IConvertCallback
    {
        private string m_StrProductKey = "t0068MgAAAENENwNWc7+efmkY+t7se6XaRPFZkvfB7QWiTjHiLykxngQdY09pzVtOvrefXBbVvYFbJSluECHlyxaOvHwUADk=";
        private ImageCore m_ImageCore = null;
        Dynamsoft.Barcode.Enums.EnumBarcodeFormat barcodeformat;
        private Dynamsoft.Barcode.BarcodeGenerator m_Generator = null;
        private PDFCreator m_PDFCreator = null;
        private PDFRasterizer m_PDFRasterizer = null;
        public Form1()
        {
            InitializeComponent();
            m_ImageCore = new ImageCore();
            dsViewer1.Bind(m_ImageCore);
            
            Initialization();
            m_Generator = new Dynamsoft.Barcode.BarcodeGenerator(m_StrProductKey);
            m_PDFCreator = new PDFCreator(m_StrProductKey);
            m_PDFRasterizer = new PDFRasterizer(m_StrProductKey);
        }

        protected void Initialization()
        {
            this.Icon = new Icon(typeof(Form), "wfc.ico");
            this.cmbBarcodeFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbBarcodeFormat.Items.Add("CODE_39");
            this.cmbBarcodeFormat.Items.Add("CODE_128");
            this.cmbBarcodeFormat.Items.Add("PDF417");
            this.cmbBarcodeFormat.Items.Add("QR_CODE");
            this.cmbBarcodeFormat.SelectedIndex = 0;

            this.rdbBMP.Checked = true;

            this.txtBarcodeContent.Text = "Dynamsoft";
            this.txtBarcodeLocationX.Text = "0";
            this.txtBarocdeLocationY.Text = "0";
            this.txtHumanReadableTxt.Text = "Dynamsoft";
            this.txtBarcodeScale.Text = "1";

        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfdlg = new OpenFileDialog();
                openfdlg.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF;*.GIF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF|GIF|*.GIF";
                openfdlg.FilterIndex = 0;
                openfdlg.Multiselect = true;

                if (openfdlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (string strfilename in openfdlg.FileNames)
                    {
                        int pos = strfilename.LastIndexOf(".");
                        if (pos != -1)
                        {
                            string strSuffix = strfilename.Substring(pos, strfilename.Length - pos).ToLower();
                            if (strSuffix.CompareTo(".pdf") == 0)
                            {
                                m_PDFRasterizer.ConvertToImage(strfilename,"",200,this as IConvertCallback);
                            }
                        }
                        m_ImageCore.IO.LoadImage(strfilename);
                    }
                }
            }
            catch
            {
            }
        }

        private void btnAddBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0)
                {
                    this.labMsg.Text = "";
                    this.labmsg2.Text = "";

                    if (txtBarcodeContent.Text != "" && txtBarcodeLocationX.Text != "" && txtBarocdeLocationY.Text != "" && txtBarcodeScale.Text != "")
                    {
                        Bitmap temp = m_Generator.AddBarcode(m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer), barcodeformat, txtBarcodeContent.Text,
                            txtHumanReadableTxt.Text, int.Parse(txtBarcodeLocationX.Text), int.Parse(txtBarocdeLocationY.Text), float.Parse(txtBarcodeScale.Text));
                         m_ImageCore.ImageBuffer.SetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer,temp);
                    }
                    else
                    {
                        if (txtBarcodeContent.Text == "")
                        {
                            txtBarcodeContent.Focus();
                            this.labMsg.ForeColor = Color.Red;
                            this.labMsg.Text = "BarcodeContent can not be empty";
                            this.labMsg.Location = new Point(this.groupBox2.Size.Width / 2 - this.labMsg.Size.Width / 2, this.labMsg.Location.Y);
                        }
                        else if (txtBarcodeLocationX.Text == "")
                        {
                            txtBarcodeLocationX.Focus();
                            this.labMsg.ForeColor = Color.Red;
                            this.labMsg.Text = "BarcodeLocationX can not be empty";
                            this.labMsg.Location = new Point(this.groupBox2.Size.Width / 2 - this.labMsg.Size.Width / 2, this.labMsg.Location.Y);
                        }
                        else if (txtBarocdeLocationY.Text == "")
                        {
                            txtBarocdeLocationY.Focus();
                            this.labMsg.ForeColor = Color.Red;
                            this.labMsg.Text = "BarcodeLocationY can not be empty";
                            this.labMsg.Location = new Point(this.groupBox2.Size.Width / 2 - this.labMsg.Size.Width / 2, this.labMsg.Location.Y);
                        }
                        else if (txtBarcodeScale.Text == "")
                        {
                            txtBarcodeScale.Focus();
                            this.labMsg.ForeColor = Color.Red;
                            this.labMsg.Text = "BarcodeScale can not be empty";
                            this.labMsg.Location = new Point(this.groupBox2.Size.Width / 2 - this.labMsg.Size.Width / 2, this.labMsg.Location.Y);
                        }
                    }
                }
                else
                {
                    this.labMsg.ForeColor = Color.Red;
                    this.labMsg.Text = "Please load an image first";
                    this.labMsg.Location = new Point(this.groupBox2.Size.Width / 2 - this.labMsg.Size.Width / 2, this.labMsg.Location.Y);
                }
            }
            catch
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0)
                {
                    this.labMsg.Text = "";
                    this.labmsg2.Text = "";
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

                            m_ImageCore.IO.SaveAsTIFF(strFilename, tempListIndex);
                        }

                        if (rdbPDF.Checked == true)
                        {
                            m_PDFCreator.Save(this as ISave, strFilename);
                        }
                    }
                }
                else
                {
                    this.labmsg2.ForeColor = Color.Red;
                    this.labmsg2.Text = "Please load an image first";
                    this.labmsg2.Location = new Point(this.groupBox4.Size.Width / 2 - this.labmsg2.Size.Width / 2, this.labmsg2.Location.Y);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void cmbBarcodeFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbBarcodeFormat.SelectedIndex)
            {
                case 0:
                    barcodeformat = Dynamsoft.Barcode.Enums.EnumBarcodeFormat.CODE_39;
                    break;
                case 1:
                    barcodeformat = Dynamsoft.Barcode.Enums.EnumBarcodeFormat.CODE_128;
                    break;
                case 2:
                    barcodeformat = Dynamsoft.Barcode.Enums.EnumBarcodeFormat.PDF417;
                    break;
                case 3:
                    barcodeformat =  Dynamsoft.Barcode.Enums.EnumBarcodeFormat.QR_CODE;
                    break;
            }
        }

        private void txtBarcodeLocationX_KeyPress(object sender, KeyPressEventArgs e)
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(e.KeyChar.ToString());
            if (!char.IsDigit(e.KeyChar) || array.LongLength == 2) e.Handled = true;
            if (e.KeyChar == '\b') e.Handled = false;
        }

        private void txtBarocdeLocationY_KeyPress(object sender, KeyPressEventArgs e)
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(e.KeyChar.ToString());
            if (!char.IsDigit(e.KeyChar) || array.LongLength == 2) e.Handled = true;
            if (e.KeyChar == '\b') e.Handled = false;
        }

        private void txtBarcodeScale_KeyPress(object sender, KeyPressEventArgs e)
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(e.KeyChar.ToString());
            if (!char.IsDigit(e.KeyChar) || array.LongLength == 2) e.Handled = true;
            if (e.KeyChar == '\b' || e.KeyChar == '.') e.Handled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }


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
            if (chbMultiPagePDF.Checked)
            {
                return m_ImageCore.ImageBuffer.HowManyImagesInBuffer;
            }
            else
            {
                return 1;
            }
        }

        #endregion

        #region IConvertCallback Members

        public void LoadConvertResult(ConvertResult result)
        {
            m_ImageCore.IO.LoadImage(result.Image);
            if(result.Annotations!=null)
            {
                m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer,EnumMetaDataType.enumAnnotation,result.Annotations,true);
            }
        }
        #endregion
    }
}
