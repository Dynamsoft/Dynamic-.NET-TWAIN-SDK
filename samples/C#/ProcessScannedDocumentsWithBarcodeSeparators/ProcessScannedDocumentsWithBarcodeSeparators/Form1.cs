using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.DotNet.TWAIN;
using Dynamsoft.DotNet.TWAIN.Enums.Barcode;
using Dynamsoft.DotNet.TWAIN.Barcode;

namespace AddBarcodeDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Initialization();       
        }

        protected void Initialization()
        {
            this.Icon = new Icon(typeof(Form), "wfc.ico");
            this.dynamicDotNetTwain1.Visible = false;
            this.cmbBarcodeFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbBarcodeFormat.DataSource = Enum.GetValues(typeof(Dynamsoft.DotNet.TWAIN.Enums.Barcode.BarcodeFormat));
            this.cmbBarcodeFormat.SelectedIndex = 0;

            InitPicMode(); 
            
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

            dynamicDotNetTwain1.BarcodeDllPath = strDllFolder;

            dynamicDotNetTwain1.IfShowCancelDialogWhenBarcodeOrOCR = true;
            dynamicDotNetTwain1.MaxImagesInBuffer = 64;
            dynamicDotNetTwain1.ScanInNewProcess = true;

            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.picFAQMode1, "All pages in all source files are considered \r\nas one uninterrupted sequence of pages. \r\nDestination files are arranged so that \r\nthe first page always contains a barcode. ");
 
            ToolTip toolTip2 = new ToolTip();
            toolTip2.AutoPopDelay = 5000;
            toolTip2.InitialDelay = 1000;
            toolTip2.ReshowDelay = 500;
            toolTip2.ShowAlways = true;
            toolTip2.SetToolTip(this.picFAQMode2, "Each page contains a barcode and the pages \r\nwhere barcodes coincide are detected and \r\ngot merged to a PDF file.");
        }

        private void radMode1_CheckedChanged(object sender, EventArgs e)
        {
            InitPicMode();
        }

        private void radMode2_CheckedChanged(object sender, EventArgs e)
        {
            InitPicMode();
        }

        private void InitPicMode()
        {
            if (radMode1.Checked == true)
            {
                this.picMode1.Image = global::PSDWBS.Properties.Resources.Mode1_Selected;
                this.picMode2.Image = global::PSDWBS.Properties.Resources.Mode2;
            }
            else
            {
                this.picMode1.Image = global::PSDWBS.Properties.Resources.Mode1;
                this.picMode2.Image = global::PSDWBS.Properties.Resources.Mode2_Selected;
            }
        }

        List<string> m_listBarcodeType = null;
        private void SaveFileByBarcodeText()
        {
            m_listBarcodeType = new List<string>();
            List<IndexList> listImageIndex = new List<IndexList>();
            IndexList listIndex = new IndexList();
            listImageIndex.Add(listIndex); //use to save no barcode files

            for (int i = 0; i < this.dynamicDotNetTwain1.HowManyImagesInBuffer; i++)
            {

                Result[] aryResult = this.dynamicDotNetTwain1.ReadBarcode((short)i, (BarcodeFormat)cmbBarcodeFormat.SelectedValue);//Please update the barcode format to yours


                if (null == aryResult || aryResult.Length == 0)
                {
                    //If no barcode found on the current image, add it to the image list for saving
                    UpdateDateList(0, i, ref listImageIndex);
                }
                else //If a barcode is found, restart the list
                {
                    string strBarcodeText = aryResult[0].Text;
                    int iPosition = 0;
                    if (IfExistBarcodeText(strBarcodeText, out iPosition))
                    {
                        UpdateDateList(iPosition, i, ref listImageIndex);
                    }
                    else
                    {
                        m_listBarcodeType.Add(strBarcodeText);

                        AddDateList(i, ref listImageIndex);
                    }
                }
            }
            SaveImages(listImageIndex);
        }

        private void AddDateList(int index, ref List<IndexList> listImageIndex)
        {
            IndexList listIndex = new IndexList();
            listIndex.Add(index);
            listImageIndex.Add(listIndex);
        }

        private void UpdateDateList(int iPosition, int index, ref List<IndexList> listImageIndex)
        {
            IndexList listIndex = new IndexList();
            listIndex = listImageIndex[iPosition];
            listIndex.Add(index);
            listImageIndex[iPosition] = listIndex;
        }

        private bool IfExistBarcodeText(string strBarcodeText, out int iPosition)
        {
            iPosition = 0;
            bool bRet = false;
            string strTemp = "";
            int i = 0;
            for (i = 0; i < m_listBarcodeType.Count; i++)
            {
                strTemp = m_listBarcodeType[i];
                if (strBarcodeText.Trim().ToLower().CompareTo(strTemp.Trim().ToLower()) == 0)
                {
                    iPosition = i + 1;
                    bRet = true;
                    break;
                }
            }
            return bRet;
        }

        private void SaveImages(List<IndexList> listImageIndex)
        {
            int index = 0;
            FolderBrowserDialog objFolderBrowserDialog = new FolderBrowserDialog();
            if (objFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (IndexList list in listImageIndex)
                {
                    if (list.Count != 0)
                    {
                        this.dynamicDotNetTwain1.SaveAsMultiPagePDF(objFolderBrowserDialog.SelectedPath.Trim() + "\\" + index + ".pdf", list);
                    }
                    index++;
                }
            }

            MessageBox.Show(this.dynamicDotNetTwain1.ErrorString);
        }


        private void SaveFileByBegainWithBarcode()
        {
            List<IndexList> listImageIndex = new List<IndexList>();
            IndexList listIndex = null;

            for (int i = 0; i < this.dynamicDotNetTwain1.HowManyImagesInBuffer; i++)
            {
                if (null == listIndex)
                    listIndex = new IndexList();

                Result[] aryResult = this.dynamicDotNetTwain1.ReadBarcode((short)i, (BarcodeFormat)cmbBarcodeFormat.SelectedValue);//Please update the barcode format to yours


                if (null == aryResult || aryResult.Length == 0)
                {
                    listIndex.Add(i); //If no barcode found on the current image, add it to the image list for saving
                }
                else
                {
                    if (listIndex != null && listIndex.Count > 0)
                    {
                        listImageIndex.Add(listIndex);
                        listIndex = null;
                    }

                    //If a barcode is found, restart the list
                    if (null == listIndex)
                        listIndex = new IndexList();
                    listIndex.Add(i);
                }
            }

            if (listIndex != null)
            {
                listImageIndex.Add(listIndex);  //save a last set of data
                listIndex = null;
            }

            SaveImages(listImageIndex);
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            this.dynamicDotNetTwain1.SelectSource();
            this.dynamicDotNetTwain1.OpenSource();
            this.dynamicDotNetTwain1.IfAutoFeed = true;
            this.dynamicDotNetTwain1.IfFeederEnabled = true;
            this.dynamicDotNetTwain1.IfShowUI = false;    
            this.dynamicDotNetTwain1.AcquireImage();
        }

        private void btnRemoveAllImage_Click(object sender, EventArgs e)
        {
            this.dynamicDotNetTwain1.RemoveAllImages();
            this.dynamicDotNetTwain1.Visible = false;
        }

        private void btnRemoveSelectedImages_Click(object sender, EventArgs e)
        {
            this.dynamicDotNetTwain1.RemoveImages(this.dynamicDotNetTwain1.CurrentSelectedImageIndicesInBuffer);
            if(this.dynamicDotNetTwain1.HowManyImagesInBuffer == 0)
                this.dynamicDotNetTwain1.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dynamicDotNetTwain1.HowManyImagesInBuffer > 0)
            {
                if (this.radMode1.Checked == true)
                    SaveFileByBegainWithBarcode();
                else
                    SaveFileByBarcodeText();
            }
        }

        private void dynamicDotNetTwain1_OnPostAllTransfers()
        {
            if(this.dynamicDotNetTwain1.Visible == false)
                this.dynamicDotNetTwain1.Visible = true;
        }

    }
}
