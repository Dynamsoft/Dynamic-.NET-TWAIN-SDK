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

namespace BarcodeDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            this.dynamicDotNetTwain1.ScanInNewProcess = true;
        }

        protected void InitializeUI()
        {
            cbxFormat.DataSource = Enum.GetValues(typeof(Dynamsoft.DotNet.TWAIN.Enums.Barcode.BarcodeFormat));
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
            this.textBox1.Text = "";
            string strDllFolder = Application.ExecutablePath;
            strDllFolder = strDllFolder.Replace("/", "\\");
            int pos = strDllFolder.LastIndexOf("\\Samples\\");
            if (pos != -1)
            {
                strDllFolder = strDllFolder.Substring(0, strDllFolder.IndexOf(@"\", pos)) + @"\Redistributable\BarcodeResources\";
            }
            else
            {
                pos = strDllFolder.LastIndexOf("\\");
                strDllFolder = strDllFolder.Substring(0, strDllFolder.IndexOf(@"\", pos)) + @"\";
            }


            this.dynamicDotNetTwain1.BarcodeDllPath = strDllFolder;
            try
            {
                dynamicDotNetTwain1.MaxBarcodesToRead = int.Parse(tbxMaxNum.Text);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Maximum Number Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (this.dynamicDotNetTwain1.CurrentImageIndexInBuffer < 0)
            {
                MessageBox.Show("Please load an image before recognizing!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.textBox1.Text = "Recognizing...";

            Result[] aryResult = this.dynamicDotNetTwain1.ReadBarcode(this.dynamicDotNetTwain1.CurrentImageIndexInBuffer, int.Parse(tbxLeft.Text), int.Parse(tbxTop.Text), 
                int.Parse(tbxRight.Text), int.Parse(tbxBottom.Text), (BarcodeFormat)cbxFormat.SelectedValue);   //int.Parse has not checked exception
            StringBuilder strText = new StringBuilder();
            strText.AppendFormat(aryResult.Length + " total barcode" + (aryResult.Length == 1 ? "" : "s") + " found.\r\n");
            for (int i = 0; i < aryResult.Length; i++)
            {
                Result objResult = aryResult[i];
                strText.AppendFormat("      Result " + (i + 1) + "\r\n");
                strText.AppendFormat("      BarcodeFormat: " + objResult.BarcodeFormat.ToString() + "\r\n");
                strText.AppendFormat("      Text read: " + objResult.Text + "\r\n");

            }
            this.textBox1.Text = strText.ToString();
        }

        private void dynamicDotNetTwain1_OnTopImageInTheViewChanged(short sImageIndex)
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
            dynamicDotNetTwain1_OnImageAreaDeselected(dynamicDotNetTwain1.CurrentImageIndexInBuffer);
        }

    }
}
