using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.Barcode;
using Dynamsoft.Core;
using Dynamsoft.TWAIN;
using Dynamsoft.TWAIN.Interface;
using Dynamsoft.PDF;
using System.IO;
using System.Runtime.InteropServices;

namespace SeparateDocumentByBarcode
{
    public partial class Form1 : Form,Dynamsoft.TWAIN.Interface.IAcquireCallback
    {
        public Form1()
        {
            InitializeComponent();
            Initialization();
            m_ImageCore = new ImageCore();
            dsViewer1.Bind(m_ImageCore);
            m_TwainManager = new TwainManager(m_StrProductKey);
            m_PDFCreator = new PDFCreator(m_StrProductKey);
        }
        private string m_StrProductKey = "t0068MgAAAENENwNWc7+efmkY+t7se6XaRPFZkvfB7QWiTjHiLykxngQdY09pzVtOvrefXBbVvYFbJSluECHlyxaOvHwUADk=";
        private ImageCore m_ImageCore = null;
        private TwainManager m_TwainManager = null;
        private PDFCreator m_PDFCreator = null;
        protected void Initialization()
        {
            this.Icon = new Icon(typeof(Form), "wfc.ico");
            this.dsViewer1.Visible = false;
            this.cmbBarcodeFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBarcodeFormat.Items.Add("All");
            cmbBarcodeFormat.Items.Add("OneD");
            cmbBarcodeFormat.Items.Add("Code 39");
            cmbBarcodeFormat.Items.Add("Code 128");
            cmbBarcodeFormat.Items.Add("Code 93");
            cmbBarcodeFormat.Items.Add("Codabar");
            cmbBarcodeFormat.Items.Add("Interleaved 2 of 5");
            cmbBarcodeFormat.Items.Add("EAN-13");
            cmbBarcodeFormat.Items.Add("EAN-8");
            cmbBarcodeFormat.Items.Add("UPC-A");
            cmbBarcodeFormat.Items.Add("UPC-E");
            cmbBarcodeFormat.Items.Add("PDF417");
            cmbBarcodeFormat.Items.Add("QRCode");
            cmbBarcodeFormat.Items.Add("Datamatrix");
            cmbBarcodeFormat.Items.Add("Industrial 2 of 5");
            cmbBarcodeFormat.SelectedIndex = 0;

            InitPicMode();


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
                this.picMode1.Image = global::SeparateDocumentByBarcode.Properties.Resources.Mode1_Selected;
                this.picMode2.Image = global::SeparateDocumentByBarcode.Properties.Resources.Mode2;
            }
            else
            {
                this.picMode1.Image = global::SeparateDocumentByBarcode.Properties.Resources.Mode1;
                this.picMode2.Image = global::SeparateDocumentByBarcode.Properties.Resources.Mode2_Selected;
            }
        }

        List<string> m_listBarcodeType = null;
        string strBarcodeFormat = null;
        private void SaveFileByBarcodeText()
        {
            m_listBarcodeType = new List<string>();
            List<List<short>> listImageIndex = new List<List<short>>();
            List<short> listIndex = new List<short>();
            listImageIndex.Add(listIndex); //use to save no barcode files
            BarcodeReader reader = new BarcodeReader();
            reader.LicenseKeys = m_StrProductKey;
            try
            {
                switch (cmbBarcodeFormat.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.OneD;
                        break;
                    case 2:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_39;
                        break;
                    case 3:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_128;
                        break;
                    case 4:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_93;
                        break;
                    case 5:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODABAR;
                        break;
                    case 6:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.ITF;
                        break;
                    case 7:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_13;
                        break;
                    case 8:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_8;
                        break;
                    case 9:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_A;
                        break;
                    case 10:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_E;
                        break;
                    case 11:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.PDF417;
                        break;
                    case 12:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.QR_CODE;
                        break;
                    case 13:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.DATAMATRIX;
                        break;
                    case 14:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.INDUSTRIAL_25;
                        break;
                }
                strBarcodeFormat = reader.ReaderOptions.BarcodeFormats.ToString();
                if (cmbBarcodeFormat.SelectedIndex == 0)
                {
                    strBarcodeFormat = "All";
                }
                for (int i = 0; i < m_ImageCore.ImageBuffer.HowManyImagesInBuffer; i++)
                {
                    BarcodeResult[] aryResult = null;
                    aryResult = reader.DecodeBitmap((Bitmap)m_ImageCore.ImageBuffer.GetBitmap((short)i));
                    if (null == aryResult || (aryResult != null && aryResult.Length == 0))
                    {
                        //If no barcode found on the current image, add it to the image list for saving
                        UpdateDateList(0, i, ref listImageIndex);
                    }
                    else //If a barcode is found, restart the list
                    {
                        string strBarcodeText = aryResult[0].BarcodeText;
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
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDateList(int index, ref List<List<short>> listImageIndex)
        {
            List<short> listIndex = new List<short>();
            listIndex.Add((short)index);
            listImageIndex.Add(listIndex);
        }

        private void UpdateDateList(int iPosition, int index, ref List<List<short>> listImageIndex)
        {
            List<short> listIndex = new List<short>();
            listIndex = listImageIndex[iPosition];
            listIndex.Add((short)index);
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

        bool bHasBarcodeOnFirstImage = false;
        private void SaveImages(List<List<short>> listImageIndex)
        {
            int index = 0;
            FolderBrowserDialog objFolderBrowserDialog = new FolderBrowserDialog();
            if (objFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (List<short> list in listImageIndex)
                {
                    if (list.Count != 0)
                    {
                        string strFirstPDFName = null;
                        if (radMode1.Checked == true)
                        {
                            if (index == 0 && bHasBarcodeOnFirstImage == false)
                            {

                                strFirstPDFName = objFolderBrowserDialog.SelectedPath.Trim() + "\\" + strBarcodeFormat.ToString() + "-BeginWithNoBarcode.pdf";
                                int i = 2;
                                while (System.IO.File.Exists(strFirstPDFName))
                                {
                                    strFirstPDFName = String.Format(objFolderBrowserDialog.SelectedPath.Trim() + "\\" + strBarcodeFormat.ToString() + "-BeginWithNoBarcode({0}).pdf", i);
                                    i++;
                                }
  
                                DyPDFCreator tempPDFCreator = new DyPDFCreator(m_ImageCore, list,m_PDFCreator);
                                tempPDFCreator.SaveAsPDF(strFirstPDFName);
                            }
                            else
                            {
                                if (index == 0 && bHasBarcodeOnFirstImage == true)
                                    index = 1;
                                if (m_listBarcodeType != null)
                                {
                                    string strTempPDFName = m_listBarcodeType[index - 1];
                                    strTempPDFName = this.SetPDFFileName(objFolderBrowserDialog.SelectedPath.Trim(), strBarcodeFormat.ToString(), m_listBarcodeType[index - 1]);
                                    DyPDFCreator tempPDFCreator = new DyPDFCreator(m_ImageCore,list,m_PDFCreator);
                                    tempPDFCreator.SaveAsPDF(strTempPDFName);
                                }

                            }
                        }
                        else
                        {
                            if (index == 0)
                            {
                                strFirstPDFName = objFolderBrowserDialog.SelectedPath.Trim() + "\\" + strBarcodeFormat.ToString() + "-None.pdf";
                                int i = 2;
                                while (System.IO.File.Exists(strFirstPDFName))
                                {
                                    strFirstPDFName = String.Format(objFolderBrowserDialog.SelectedPath.Trim() + "\\" + strBarcodeFormat.ToString() + "-None({0}).pdf", i);
                                    i++;
                                }
                                DyPDFCreator tempPDFCreator = new DyPDFCreator(m_ImageCore,list,m_PDFCreator);
                                tempPDFCreator.SaveAsPDF(strFirstPDFName);
                            }
                            else
                            {
                                string strTempPDFName = null;
                                strTempPDFName = this.SetPDFFileName(objFolderBrowserDialog.SelectedPath.Trim(), strBarcodeFormat.ToString(), m_listBarcodeType[index - 1]);

                                DyPDFCreator tempPDFCreator = new DyPDFCreator(m_ImageCore,list,m_PDFCreator);
                                tempPDFCreator.SaveAsPDF(strTempPDFName);
                            }

                        }
                    }
                    index++;
                }
            }
        }

        private void SaveFileByBegainWithBarcode()
        {
            m_listBarcodeType = new List<string>();
            List<List<short>> listImageIndex = new List<List<short>>();
            List<short> listIndex = null;
            BarcodeReader reader = new BarcodeReader();
            bHasBarcodeOnFirstImage = false;
            reader.LicenseKeys = m_StrProductKey;
            try
            {
                for (int i = 0; i < m_ImageCore.ImageBuffer.HowManyImagesInBuffer; i++)
                {
                    if (null == listIndex)
                        listIndex = new List<short>();
                    switch (cmbBarcodeFormat.SelectedIndex)
                    {
                        case 0:
                            break;
                        case 1:
                            reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.OneD;
                            break;
                        case 2:
                            reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_39;
                            break;
                        case 3:
                            reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_128;
                            break;
                        case 4:
                            reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_93;
                            break;
                        case 5:
                            reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODABAR;
                            break;
                        case 6:
                            reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.ITF;
                            break;
                        case 7:
                            reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_13;
                            break;
                        case 8:
                            reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_8;
                            break;
                        case 9:
                            reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_A;
                            break;
                        case 10:
                            reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_E;
                            break;
                        case 11:
                            reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.PDF417;
                            break;
                        case 12:
                            reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.QR_CODE;
                            break;
                        case 13:
                            reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.DATAMATRIX;
                            break;
                        case 14:
                            reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.INDUSTRIAL_25;
                            break;
                    }
                    strBarcodeFormat = reader.ReaderOptions.BarcodeFormats.ToString();
                    if (cmbBarcodeFormat.SelectedIndex == 0)
                    {
                        strBarcodeFormat = "All";
                    }
                    BarcodeResult[] aryResult = null;
                    aryResult = reader.DecodeBitmap(m_ImageCore.ImageBuffer.GetBitmap((short)i));
                    if (i == 0)
                    {
                        if (aryResult != null)
                            if (aryResult.Length != 0)
                                bHasBarcodeOnFirstImage = true;
                    }

                    if (null == aryResult || (aryResult != null && aryResult.Length == 0))
                    {
                        listIndex.Add((short)i); //If no barcode found on the current image, add it to the image list for saving
                    }
                    else
                    {
                        m_listBarcodeType.Add(aryResult[0].BarcodeText);
                        if (listIndex != null && listIndex.Count > 0)
                        {
                            listImageIndex.Add(listIndex);
                            listIndex = null;
                        }

                        //If a barcode is found, restart the list
                        if (null == listIndex)
                            listIndex = new List<short>();
                        listIndex.Add((short)i);
                    }
                }

                if (listIndex != null)
                {
                    listImageIndex.Add(listIndex);  //save a last set of data
                    listIndex = null;
                }

                SaveImages(listImageIndex);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnScan_Click(object sender, EventArgs e)
        {
             //m_TwainManager.SelectSource();
             //m_TwainManager.OpenSource();
             //m_TwainManager.IfAutoFeed = true;
             //m_TwainManager.IfFeederEnabled = true;
             //m_TwainManager.IfShowUI = false;
             //m_TwainManager.AcquireImage(this as IAcquireCallback);
             //dsViewer1.Visible = true;
            List<string> tempList = new List<string>();
            for (int i = 0; i < m_TwainManager.SourceCount; i++)
            {
                tempList.Add(m_TwainManager.SourceNameItems((short)i));
            }
            SourceListWrapper tempSourceListWrapper = new SourceListWrapper(tempList);

            int iSelectIndex = tempSourceListWrapper.SelectSource();
            if (iSelectIndex == -1)
            {
                return;
            }
            m_TwainManager.SelectSourceByIndex((short)iSelectIndex);
            m_TwainManager.OpenSource();
            m_TwainManager.IfAutoFeed = true;
            m_TwainManager.IfFeederEnabled = true;
            m_TwainManager.IfShowUI = false;
            m_TwainManager.AcquireImage(this as IAcquireCallback);
            dsViewer1.Visible = true;

        }

        private void btnRemoveAllImage_Click(object sender, EventArgs e)
        {
            m_ImageCore.ImageBuffer.RemoveAllImages();
            dsViewer1.Visible = false;
        }

        private void btnRemoveSelectedImages_Click(object sender, EventArgs e)
        {
            m_ImageCore.ImageBuffer.RemoveImages(dsViewer1.CurrentSelectedImageIndicesInBuffer);
            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer == 0)
                dsViewer1.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0)
            {
                if (this.radMode1.Checked == true)
                    SaveFileByBegainWithBarcode();
                else
                    SaveFileByBarcodeText();
            }
        }

        private string SetPDFFileName(string FileFolder, string strBarcodeType, string strText)
        {
            int iCharindex = 0;
            string strBarcodeText = strText;
            string strFullPDFName = null;
            string strPDFName = null;
            bool bHasillegalcharacter = false;
            foreach (char text in strBarcodeText)
            {
                bool bIsillegalcharacter = false;

                foreach (char temp in System.IO.Path.GetInvalidFileNameChars())
                {
                    if (text == temp)
                    {
                        bIsillegalcharacter = true;
                        bHasillegalcharacter = true;
                    }
                }
                if (bIsillegalcharacter)
                {
                    strBarcodeText = strBarcodeText.Remove(iCharindex, 1);
                    iCharindex--;
                }
                iCharindex++;
            }
            strFullPDFName = strBarcodeType + "-" + strBarcodeText;
            int i = 2;
            string FilePath = FileFolder + "\\" + strFullPDFName + ".pdf";
            while (System.IO.File.Exists(FilePath))
            {
                strFullPDFName = string.Format(strBarcodeType + "-" + strBarcodeText + "({0})", i);
                FilePath = FileFolder + "\\" + strFullPDFName + ".pdf";
                i++;
            }

            if (bHasillegalcharacter)
            {
                SeparateDocumentByBarcode.Form2 fSetFileNameForm = new SeparateDocumentByBarcode.Form2(FileFolder, strFullPDFName);
                fSetFileNameForm.ShowDialog();
                strPDFName = FileFolder + "\\" +  fSetFileNameForm.GetPDfFileName();
            }
            else
            {
                strPDFName =  FileFolder + "\\" + strFullPDFName + ".pdf";
            }


            return strPDFName;
        }

        #region IAcquireCallback Members

        public void OnPostAllTransfers()
        {
        }

        public bool OnPostTransfer(Bitmap bit)
        {
            m_ImageCore.IO.LoadImage(bit);
            return true;
        }

        public void OnPreAllTransfers()
        {
        }

        public bool OnPreTransfer()
        {
            return true;
        }

        public void OnSourceUIClose()
        {
        }

        public void OnTransferCancelled()
        {
        }

        public void OnTransferError()
        {
        }

        #endregion

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_TwainManager.Dispose();
        }
    }
}
