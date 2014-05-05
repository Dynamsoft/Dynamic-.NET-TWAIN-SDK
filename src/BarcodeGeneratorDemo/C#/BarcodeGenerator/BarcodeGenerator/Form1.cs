using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AddBarcodeDemo
{
    public partial class Form1 : Form
    {
        Dynamsoft.DotNet.TWAIN.Enums.Barcode.BarcodeFormat barcodeformat;

        public Form1()
        {
            InitializeComponent();
            Initialization();
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

           
            
            string strDllFolder = Application.ExecutablePath;
            strDllFolder = strDllFolder.Replace("/", "\\");
            int pos = strDllFolder.LastIndexOf("\\bin\\");
            if (pos != -1)
            {
                strDllFolder = strDllFolder.Substring(0, strDllFolder.IndexOf(@"\", pos)) + @"\Redistributable\BarcodeResources\";
            }
            else
            {
                pos = strDllFolder.LastIndexOf("\\");
                strDllFolder = strDllFolder.Substring(0, strDllFolder.IndexOf(@"\", pos)) + @"\";
            }


            dynamicDotNetTwain1.BarcodeDllPath = strDllFolder;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfdlg = new OpenFileDialog();
                openfdlg.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF";
                openfdlg.FilterIndex = 0;
                openfdlg.Multiselect = true;

                if (openfdlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (string strfilename in openfdlg.FileNames)
                    {
                        this.dynamicDotNetTwain1.LoadImage(strfilename);
                    }
                }
            }
            catch
            {
                MessageBox.Show(this.dynamicDotNetTwain1.ErrorString);
            }
        }

        private void btnAddBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                if (dynamicDotNetTwain1.HowManyImagesInBuffer > 0)
                {
                    this.labMsg.Text = "";
                    this.labmsg2.Text = "";

                    if (txtBarcodeContent.Text != "" && txtBarcodeLocationX.Text != "" && txtBarocdeLocationY.Text != "" && txtBarcodeScale.Text != "")
                    {
                        dynamicDotNetTwain1.AddBarcode(dynamicDotNetTwain1.CurrentImageIndexInBuffer, barcodeformat, txtBarcodeContent.Text,
                            txtHumanReadableTxt.Text, int.Parse(txtBarcodeLocationX.Text), int.Parse(txtBarocdeLocationY.Text), float.Parse(txtBarcodeScale.Text));
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
                MessageBox.Show(this.dynamicDotNetTwain1.ErrorString);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dynamicDotNetTwain1.HowManyImagesInBuffer > 0)
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
                            if (chbMultiPagePDF.Checked == true)
                                dynamicDotNetTwain1.SaveAllAsPDF(strFilename);
                            else
                                dynamicDotNetTwain1.SaveAsPDF(strFilename, dynamicDotNetTwain1.CurrentImageIndexInBuffer);
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
            catch
            {
                MessageBox.Show(this.dynamicDotNetTwain1.ErrorString);
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
                    barcodeformat = Dynamsoft.DotNet.TWAIN.Enums.Barcode.BarcodeFormat.CODE_39;
                    break;
                case 1:
                    barcodeformat = Dynamsoft.DotNet.TWAIN.Enums.Barcode.BarcodeFormat.CODE_128;
                    break;
                case 2:
                    barcodeformat = Dynamsoft.DotNet.TWAIN.Enums.Barcode.BarcodeFormat.PDF417;
                    break;
                case 3:
                    barcodeformat = Dynamsoft.DotNet.TWAIN.Enums.Barcode.BarcodeFormat.QR_CODE;
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

    }
}
