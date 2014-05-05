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
        }

        protected void InitializeUI()
        {
            cbxFormat.DataSource = Enum.GetValues(typeof(Dynamsoft.DotNet.TWAIN.Enums.Barcode.BarcodeFormat));
            tbxMaxNum.Text = "10";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedlg = new OpenFileDialog();
            filedlg.Multiselect = true;
            // try to locate images folder
            string imagesFolder = Application.ExecutablePath;

            // we assume we are running under the DotImage install folder
            imagesFolder = imagesFolder.Replace("/", "\\");
            int pos = imagesFolder.LastIndexOf("\\bin\\");
            if (pos != -1)
            {
                imagesFolder = imagesFolder.Substring(0, imagesFolder.IndexOf(@"\", pos)) + @"\Images\BarcodeImages\";
            }
            else
            {
                pos = imagesFolder.LastIndexOf("\\");
                imagesFolder = imagesFolder.Substring(0, imagesFolder.IndexOf(@"\", pos)) + @"\";
            }

            //use this folder as starting point			
            filedlg.InitialDirectory = imagesFolder;

            if (filedlg.ShowDialog() == DialogResult.OK)
            {
                foreach (string strfilename in filedlg.FileNames)
                {
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
                int.Parse(tbxRight.Text), int.Parse(tbxButtom.Text), (BarcodeFormat)cbxFormat.SelectedValue);   //int.Parse has not checked exception
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
                tbxButtom.Text = dynamicDotNetTwain1.GetImage(dynamicDotNetTwain1.CurrentImageIndexInBuffer).Height.ToString();
            }
            else
            {
                tbxLeft.Text = rect.Left.ToString();
                tbxTop.Text = rect.Top.ToString();
                tbxRight.Text = rect.Right.ToString();
                tbxButtom.Text = rect.Bottom.ToString();
            }
        }

        private void dynamicDotNetTwain1_OnImageAreaSelected(short sImageIndex, int left, int top, int right, int bottom)
        {
            tbxLeft.Text = left.ToString();
            tbxTop.Text = top.ToString();
            tbxRight.Text = right.ToString();
            tbxButtom.Text = bottom.ToString();
        }

        private void dynamicDotNetTwain1_OnImageAreaDeselected(short sImageIndex)
        {
            tbxLeft.Text = "0";
            tbxTop.Text = "0";
            tbxRight.Text = dynamicDotNetTwain1.GetImage(dynamicDotNetTwain1.CurrentImageIndexInBuffer).Width.ToString();
            tbxButtom.Text = dynamicDotNetTwain1.GetImage(dynamicDotNetTwain1.CurrentImageIndexInBuffer).Height.ToString();
        }

        private void dynamicDotNetTwain1_OnPostAllTransfers()
        {
            dynamicDotNetTwain1_OnImageAreaDeselected(dynamicDotNetTwain1.CurrentImageIndexInBuffer);
        }

    }
}
