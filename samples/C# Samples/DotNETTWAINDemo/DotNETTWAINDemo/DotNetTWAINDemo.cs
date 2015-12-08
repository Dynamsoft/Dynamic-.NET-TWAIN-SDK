using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using Dynamsoft.DotNet.TWAIN;
using Dynamsoft.Barcode;

namespace DotNet_TWAIN_Demo
{
    public partial class DotNetTWAINDemo : Form
    {
        // For move the window
        private Point mouse_offset;
        // For move the annotation form
        private Point mouse_offset2;
        private int currentImageIndex = -1;
        private delegate void CrossThreadOperationControl();
        private bool isToCrop = false;
        private Label infoLabel;

        private RoundedRectanglePanel roundedRectanglePanelSaveImage;
        private RoundedRectanglePanel roundedRectanglePanelAcquireLoad;
        private RoundedRectanglePanel roundedRectanglePanelBarcode;
        private RoundedRectanglePanel roundedRectanglePanelOCR;
        private TabHead thSaveImage;
        private TabHead thOCR;
        private TabHead thAddBarcode;
        private TabHead thReadBarcode;
        private TabHead thLoadImage;
        private TabHead thAcquireImage;

        /// <summary>
        /// Click to minimize the form
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;  
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;   
                return cp;
            }
        }

        public DotNetTWAINDemo()
        {
            InitializeComponent();
            InitializeComponentForCustomControl();

            // Draw the background for the main form
            DrawBackground();

            Initialization();
            this.dynamicDotNetTwain.LicenseKeys = "BAF81AB5515958BF519F7AAE2A318B3B;BAF81AB5515958BF6DA4299CBA3CC11D;BAF81AB5515958BF9C195A4722534974;BAF81AB5515958BFE96B7433DD28E75B;BAF81AB5515958BF3DBAF9AB37059787;BAF81AB5515958BF5291EEE0B030BD82";
        }

        private void InitializeComponentForCustomControl()
        {
            this.roundedRectanglePanelSaveImage = new DotNet_TWAIN_Demo.RoundedRectanglePanel();
            this.roundedRectanglePanelAcquireLoad = new DotNet_TWAIN_Demo.RoundedRectanglePanel();
            this.roundedRectanglePanelBarcode = new DotNet_TWAIN_Demo.RoundedRectanglePanel();
            this.roundedRectanglePanelOCR = new DotNet_TWAIN_Demo.RoundedRectanglePanel();
            this.thSaveImage = new DotNet_TWAIN_Demo.TabHead();
            this.thOCR = new DotNet_TWAIN_Demo.TabHead();
            this.thAddBarcode = new DotNet_TWAIN_Demo.TabHead();
            this.thReadBarcode = new DotNet_TWAIN_Demo.TabHead();
            this.thLoadImage = new DotNet_TWAIN_Demo.TabHead();
            this.thAcquireImage = new DotNet_TWAIN_Demo.TabHead();

            this.roundedRectanglePanelSaveImage.SuspendLayout();
            this.roundedRectanglePanelAcquireLoad.SuspendLayout();
            this.roundedRectanglePanelBarcode.SuspendLayout();
            this.roundedRectanglePanelOCR.SuspendLayout();
            // 
            // roundedRectanglePanelSaveImage
            // 
            this.roundedRectanglePanelSaveImage.AutoSize = true;
            this.roundedRectanglePanelSaveImage.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.ResourceManager.GetObject("roundedRectanglePanelSaveImage.BackgroundImage")));
            this.roundedRectanglePanelSaveImage.Controls.Add(this.panelSaveImage);
            this.roundedRectanglePanelSaveImage.Controls.Add(this.thSaveImage);
            this.roundedRectanglePanelSaveImage.Location = new System.Drawing.Point(12, 904);
            this.roundedRectanglePanelSaveImage.Margin = new System.Windows.Forms.Padding(12, 12, 12, 0);
            this.roundedRectanglePanelSaveImage.Name = "roundedRectanglePanelSaveImage";
            this.roundedRectanglePanelSaveImage.Padding = new System.Windows.Forms.Padding(1);
            this.roundedRectanglePanelSaveImage.Size = new System.Drawing.Size(250, 252);
            // 
            // roundedRectanglePanelAcquireLoad
            // 
            this.roundedRectanglePanelAcquireLoad.AutoSize = true;
            this.roundedRectanglePanelAcquireLoad.BackColor = System.Drawing.SystemColors.Control;
            this.roundedRectanglePanelAcquireLoad.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.ResourceManager.GetObject("roundedRectanglePanelAcquireLoad.BackgroundImage")));
            this.roundedRectanglePanelAcquireLoad.Controls.Add(this.panelLoad);
            this.roundedRectanglePanelAcquireLoad.Controls.Add(this.panelAcquire);
            this.roundedRectanglePanelAcquireLoad.Controls.Add(this.thLoadImage);
            this.roundedRectanglePanelAcquireLoad.Controls.Add(this.thAcquireImage);
            this.roundedRectanglePanelAcquireLoad.Location = new System.Drawing.Point(12, 12);
            this.roundedRectanglePanelAcquireLoad.Margin = new System.Windows.Forms.Padding(12, 12, 12, 0);
            this.roundedRectanglePanelAcquireLoad.Name = "roundedRectanglePanelAcquireLoad";
            this.roundedRectanglePanelAcquireLoad.Padding = new System.Windows.Forms.Padding(1);
            this.roundedRectanglePanelAcquireLoad.Size = new System.Drawing.Size(250, 270);
            this.roundedRectanglePanelAcquireLoad.TabIndex = 0;
            // 
            // roundedRectanglePanelBarcode
            // 
            this.roundedRectanglePanelBarcode.AutoSize = true;
            this.roundedRectanglePanelBarcode.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.ResourceManager.GetObject("roundedRectanglePanelBarcode.BackgroundImage")));
            this.roundedRectanglePanelBarcode.Controls.Add(this.panelAddBarcode);
            this.roundedRectanglePanelBarcode.Controls.Add(this.panelReadBarcode);
            this.roundedRectanglePanelBarcode.Controls.Add(this.thAddBarcode);
            this.roundedRectanglePanelBarcode.Controls.Add(this.thReadBarcode);
            this.roundedRectanglePanelBarcode.Location = new System.Drawing.Point(12, 294);
            this.roundedRectanglePanelBarcode.Margin = new System.Windows.Forms.Padding(12, 12, 12, 0);
            this.roundedRectanglePanelBarcode.Name = "roundedRectanglePanelBarcode";
            this.roundedRectanglePanelBarcode.Padding = new System.Windows.Forms.Padding(1);
            this.roundedRectanglePanelBarcode.Size = new System.Drawing.Size(250, 362);
            this.roundedRectanglePanelBarcode.TabIndex = 1;
            // 
            // roundedRectanglePanelOCR
            // 
            this.roundedRectanglePanelOCR.AutoSize = true;
            this.roundedRectanglePanelOCR.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.ResourceManager.GetObject("roundedRectanglePanelOCR.BackgroundImage")));
            this.roundedRectanglePanelOCR.Controls.Add(this.panelOCR);
            this.roundedRectanglePanelOCR.Controls.Add(this.thOCR);
            this.roundedRectanglePanelOCR.Location = new System.Drawing.Point(12, 668);
            this.roundedRectanglePanelOCR.Margin = new System.Windows.Forms.Padding(12, 12, 12, 0);
            this.roundedRectanglePanelOCR.Name = "roundedRectanglePanelOCR";
            this.roundedRectanglePanelOCR.Padding = new System.Windows.Forms.Padding(1);
            this.roundedRectanglePanelOCR.Size = new System.Drawing.Size(250, 224);
            this.roundedRectanglePanelOCR.TabIndex = 2;
            // 
            // thSaveImage
            // 
            this.thSaveImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thSaveImage.Image = ((System.Drawing.Image)(Properties.Resources.ResourceManager.GetObject("thSaveImage.Image")));
            this.thSaveImage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.thSaveImage.Index = 5;
            this.thSaveImage.Location = new System.Drawing.Point(1, 1);
            this.thSaveImage.Margin = new System.Windows.Forms.Padding(0);
            this.thSaveImage.MultiTabHead = false;
            this.thSaveImage.Name = "thSaveImage";
            this.thSaveImage.Size = new System.Drawing.Size(248, 40);
            this.thSaveImage.State = DotNet_TWAIN_Demo.TabHead.TabHeadState.ALLFOLDED;
            this.thSaveImage.TabIndex = 73;
            this.thSaveImage.Text = "Save Image";
            this.thSaveImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thSaveImage.Click += new System.EventHandler(this.TabHead_Click);
            // 
            // thOCR
            // 
            this.thOCR.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thOCR.Image = ((System.Drawing.Image)(Properties.Resources.ResourceManager.GetObject("thOCR.Image")));
            this.thOCR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.thOCR.Index = 4;
            this.thOCR.Location = new System.Drawing.Point(1, 1);
            this.thOCR.Margin = new System.Windows.Forms.Padding(0);
            this.thOCR.MultiTabHead = false;
            this.thOCR.Name = "thOCR";
            this.thOCR.Size = new System.Drawing.Size(248, 40);
            this.thOCR.State = DotNet_TWAIN_Demo.TabHead.TabHeadState.ALLFOLDED;
            this.thOCR.TabIndex = 0;
            this.thOCR.Text = "OCR";
            this.thOCR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thOCR.Click += new System.EventHandler(this.TabHead_Click);
            // 
            // thAddBarcode
            // 
            this.thAddBarcode.BackColor = System.Drawing.Color.Transparent;
            this.thAddBarcode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thAddBarcode.Image = ((System.Drawing.Image)(Properties.Resources.ResourceManager.GetObject("thAddBarcode.Image")));
            this.thAddBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.thAddBarcode.Index = 3;
            this.thAddBarcode.Location = new System.Drawing.Point(125, 1);
            this.thAddBarcode.Margin = new System.Windows.Forms.Padding(0);
            this.thAddBarcode.MultiTabHead = true;
            this.thAddBarcode.Name = "thAddBarcode";
            this.thAddBarcode.Size = new System.Drawing.Size(124, 40);
            this.thAddBarcode.State = DotNet_TWAIN_Demo.TabHead.TabHeadState.ALLFOLDED;
            this.thAddBarcode.TabIndex = 1;
            this.thAddBarcode.Text = "Add Barcode";
            this.thAddBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thAddBarcode.Click += new System.EventHandler(this.TabHead_Click);
            // 
            // thReadBarcode
            // 
            this.thReadBarcode.BackColor = System.Drawing.Color.Transparent;
            this.thReadBarcode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thReadBarcode.Image = ((System.Drawing.Image)(Properties.Resources.ResourceManager.GetObject("thReadBarcode.Image")));
            this.thReadBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.thReadBarcode.Index = 2;
            this.thReadBarcode.Location = new System.Drawing.Point(1, 1);
            this.thReadBarcode.Margin = new System.Windows.Forms.Padding(0);
            this.thReadBarcode.MultiTabHead = true;
            this.thReadBarcode.Name = "thReadBarcode";
            this.thReadBarcode.Size = new System.Drawing.Size(124, 40);
            this.thReadBarcode.State = DotNet_TWAIN_Demo.TabHead.TabHeadState.ALLFOLDED;
            this.thReadBarcode.TabIndex = 0;
            this.thReadBarcode.Text = "Read Barcode";
            this.thReadBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thReadBarcode.Click += new System.EventHandler(this.TabHead_Click);
            // 
            // thLoadImage
            // 
            this.thLoadImage.BackColor = System.Drawing.Color.Transparent;
            this.thLoadImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thLoadImage.Image = ((System.Drawing.Image)(Properties.Resources.ResourceManager.GetObject("thLoadImage.Image")));
            this.thLoadImage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.thLoadImage.Index = 1;
            this.thLoadImage.Location = new System.Drawing.Point(125, 1);
            this.thLoadImage.Margin = new System.Windows.Forms.Padding(0);
            this.thLoadImage.MultiTabHead = true;
            this.thLoadImage.Name = "thLoadImage";
            this.thLoadImage.Size = new System.Drawing.Size(124, 40);
            this.thLoadImage.State = DotNet_TWAIN_Demo.TabHead.TabHeadState.FOLDED;
            this.thLoadImage.TabIndex = 1;
            this.thLoadImage.Text = "Load Files";
            this.thLoadImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thLoadImage.Click += new System.EventHandler(this.TabHead_Click);
            // 
            // thAcquireImage
            // 
            this.thAcquireImage.BackColor = System.Drawing.Color.Transparent;
            this.thAcquireImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thAcquireImage.Image = ((System.Drawing.Image)(Properties.Resources.ResourceManager.GetObject("thAcquireImage.Image")));
            this.thAcquireImage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.thAcquireImage.Index = 0;
            this.thAcquireImage.Location = new System.Drawing.Point(1, 1);
            this.thAcquireImage.Margin = new System.Windows.Forms.Padding(0);
            this.thAcquireImage.MultiTabHead = true;
            this.thAcquireImage.Name = "thAcquireImage";
            this.thAcquireImage.Size = new System.Drawing.Size(124, 40);
            this.thAcquireImage.State = DotNet_TWAIN_Demo.TabHead.TabHeadState.SELECTED;
            this.thAcquireImage.TabIndex = 0;
            this.thAcquireImage.Text = "Acquire Image";
            this.thAcquireImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thAcquireImage.Click += new System.EventHandler(this.TabHead_Click);

            this.roundedRectanglePanelAcquireLoad.ResumeLayout(false);
            this.roundedRectanglePanelSaveImage.ResumeLayout(false);
            this.roundedRectanglePanelBarcode.ResumeLayout(false);
            this.roundedRectanglePanelOCR.ResumeLayout(false);

            this.roundedRectanglePanelSaveImage.TabIndex = 3; 
            this.flowLayoutPanel2.Controls.Add(this.roundedRectanglePanelAcquireLoad);
            this.flowLayoutPanel2.Controls.Add(this.roundedRectanglePanelBarcode);
            this.flowLayoutPanel2.Controls.Add(this.roundedRectanglePanelOCR);
            this.flowLayoutPanel2.Controls.Add(this.roundedRectanglePanelSaveImage);
        }

        protected void Initialization()
        {
            string strPDFDllFolder = null;
            string strBarcodeDllFolder = null;
            string strOCRDllFolder = null;
            string strOCRTessDataFolder = null;
            string strAddOnDllFolder = Application.ExecutablePath;
            strAddOnDllFolder = strAddOnDllFolder.Replace("/", "\\");
            if (!strAddOnDllFolder.EndsWith(@"\", false, System.Globalization.CultureInfo.CurrentCulture))
                strAddOnDllFolder += @"\";
            int pos = strAddOnDllFolder.LastIndexOf("\\Samples\\");
            if (pos != -1)
            {
                strAddOnDllFolder = strAddOnDllFolder.Substring(0, strAddOnDllFolder.IndexOf(@"\", pos));
                strOCRTessDataFolder = strAddOnDllFolder + @"\Samples\Bin\";
                strAddOnDllFolder = strAddOnDllFolder+ @"\Redistributable\";
                strPDFDllFolder = strAddOnDllFolder + @"PDFResources\";
                strBarcodeDllFolder = strAddOnDllFolder + @"BarcodeResources\";
                strOCRDllFolder = strAddOnDllFolder + @"OCRResources\";
            }
            else
            {
                pos = strAddOnDllFolder.LastIndexOf("\\");
                strAddOnDllFolder = strAddOnDllFolder.Substring(0, strAddOnDllFolder.IndexOf(@"\", pos)) + @"\";
                strPDFDllFolder = strAddOnDllFolder;
                strBarcodeDllFolder = strAddOnDllFolder;
                strOCRDllFolder = strAddOnDllFolder;
                strOCRTessDataFolder = strAddOnDllFolder;
             }

            this.dynamicDotNetTwain.PDFRasterizerDllPath = strPDFDllFolder;
            this.dynamicDotNetTwain.BarcodeDllPath = strBarcodeDllFolder;
            this.dynamicDotNetTwain.OCRDllPath = strOCRDllFolder;
            this.dynamicDotNetTwain.OCRTessDataPath = strOCRTessDataFolder;
            this.dynamicDotNetTwain.IfShowCancelDialogWhenBarcodeOrOCR = true;
            this.dynamicDotNetTwain.MaxImagesInBuffer = 64;
        }
        private void DotNetTWAINDemo_Load(object sender, EventArgs e)
        {
            InitUI();
            InitDefaultValueForTWAIN();
        }

        /// <summary>
        /// Init the UI for the demo
        /// </summary>
        private void InitUI()
        {
            dynamicDotNetTwain.Visible = false;
            panelAnnotations.Visible = false;

            DisableAllFunctionButtons();

            // Init the View mode
            this.cbxViewMode.Items.Clear();
            this.cbxViewMode.Items.Insert(0, "1 x 1");
            this.cbxViewMode.Items.Insert(1, "2 x 2");
            this.cbxViewMode.Items.Insert(2, "3 x 3");
            this.cbxViewMode.Items.Insert(3, "4 x 4");
            this.cbxViewMode.Items.Insert(4, "5 x 5");
            
            // Init the cbxResolution
            this.cbxResolution.Items.Clear();
            this.cbxResolution.Items.Insert(0, "100");
            this.cbxResolution.Items.Insert(1, "150");
            this.cbxResolution.Items.Insert(2, "200");
            this.cbxResolution.Items.Insert(3, "300");
            
            // Init the Scan Button
            DisableControls(this.picboxScan);

            // Init the save image type
            this.rdbtnJPG.Checked = true;

            // Init the Save Image Button
            DisableControls(this.picboxSave);

            // For the popup tip label
            infoLabel = new Label();
            infoLabel.Text = "";
            infoLabel.Visible = false;
            infoLabel.AutoSize = true;
            infoLabel.Name = "Info";
            infoLabel.BackColor = System.Drawing.Color.White;
            infoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            infoLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            infoLabel.BringToFront();
            this.Controls.Add(infoLabel);

            // For the load image button
            this.picboxLoadImage.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxLoadImage.Click += new System.EventHandler(this.picboxLoadImage_Click);
            this.picboxLoadImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            //this.picboxLoadImage.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxLoadImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxLoadImage.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);

            //Tab Heads
            m_tabHeads[0] = thAcquireImage;
            m_tabHeads[1] = thLoadImage;
            m_tabHeads[2] = thReadBarcode;
            m_tabHeads[3] = thAddBarcode;
            m_tabHeads[4] = thOCR;
            m_tabHeads[5] = thSaveImage;
            m_panels[0] = panelAcquire;
            m_panels[1] = panelLoad;
            m_panels[2] = panelReadBarcode;
            m_panels[3] = panelAddBarcode;
            m_panels[4] = panelOCR;
            m_panels[5] = panelSaveImage;
            thAcquireImage.State = TabHead.TabHeadState.SELECTED;
            m_thSelectedTabHead = thAcquireImage;

            //OCR
            languages.Add("English", "eng");
            this.cbxSupportedLanguage.Items.Clear();
            foreach (string str in languages.Keys)
            {
                this.cbxSupportedLanguage.Items.Add(str);
            }
            this.cbxSupportedLanguage.SelectedIndex = 0;

            this.cbxOCRResultFormat.Items.Clear();
            this.cbxOCRResultFormat.Items.Add("Text File");
            this.cbxOCRResultFormat.Items.Add("Adobe PDF Plain Text File");
            this.cbxOCRResultFormat.Items.Add("Adobe PDF Image Over Text File");
            this.cbxOCRResultFormat.SelectedIndex = 0;

            DisableControls(picboxOCR);

            //Add Barcode
            this.cbxGenBarcodeFormat.Items.Clear();
            this.cbxGenBarcodeFormat.Items.Add("CODE_39");
            this.cbxGenBarcodeFormat.Items.Add("CODE_128");
            this.cbxGenBarcodeFormat.Items.Add("PDF417");
            this.cbxGenBarcodeFormat.Items.Add("QR_CODE");
            this.cbxGenBarcodeFormat.SelectedIndex = 0;

            this.tbxBarcodeContent.Text = "Dynamsoft";
            this.tbxBarcodeLocationX.Text = "0";
            this.tbxBarcodeLocationY.Text = "0";
            this.tbxHumanReadableText.Text = "Dynamsoft";
            this.tbxBarcodeScale.Text = "1";

            DisableControls(picboxAddBarcode);

            //Read Barcode
            //this.cbxBarcodeFormat.DataSource = Enum.GetValues(typeof(Dynamsoft.Barcode.BarcodeFormat));
            cbxBarcodeFormat.Items.Add("OneD");
            cbxBarcodeFormat.Items.Add("Code 39");
            cbxBarcodeFormat.Items.Add("Code 128");
            cbxBarcodeFormat.Items.Add("Code 93");
            cbxBarcodeFormat.Items.Add("Codabar");
            cbxBarcodeFormat.Items.Add("Interleaved 2 of 5");
            cbxBarcodeFormat.Items.Add("EAN-13");
            cbxBarcodeFormat.Items.Add("EAN-8");
            cbxBarcodeFormat.Items.Add("UPC-A");
            cbxBarcodeFormat.Items.Add("UPC-E");
            cbxBarcodeFormat.Items.Add("PDF417");
            cbxBarcodeFormat.Items.Add("QRCode");
            cbxBarcodeFormat.Items.Add("Datamatrix");
            cbxBarcodeFormat.Items.Add("Industrial 2 of 5");
            cbxBarcodeFormat.SelectedIndex = 0;
            this.tbxMaxBarcodeReads.Text = "10";
            this.tbxLeft.Text = "0";
            this.tbxRight.Text = "0";
            this.tbxTop.Text = "0";
            this.tbxBottom.Text = "0";

            DisableControls(picboxReadBarcode);

            //webcam
            DisableControls(picboxGrab);
            //always show ui for webcam
            chkShowUIForWebcam.Checked = true;
            chkShowUIForWebcam.Visible = false;
        }

        /// <summary>
        /// Init the default value for TWAIN
        /// </summary>
        private void InitDefaultValueForTWAIN()
        {
            try
            {
               // dynamicDotNetTwain.IfThrowException = true;
                dynamicDotNetTwain.SupportedDeviceType = Dynamsoft.DotNet.TWAIN.Enums.EnumSupportedDeviceType.SDT_ALL;
                dynamicDotNetTwain.ScanInNewProcess = true;
                dynamicDotNetTwain.IfFitWindow = true;
                dynamicDotNetTwain.MouseShape = false;
                dynamicDotNetTwain.SetViewMode(-1, -1);
                this.cbxViewMode.SelectedIndex = 0;

                // Init the sources for TWAIN scanning and Webcam grab, show in the cbxSources controls
                if (dynamicDotNetTwain.SourceCount > 0)
                {
                    bool hasTwainSource = false;
                    bool hasWebcamSource = false;
                    cbxSource.Items.Clear();
                    for (int i = 0; i < dynamicDotNetTwain.SourceCount; ++i)
                    {
                        cbxSource.Items.Add(dynamicDotNetTwain.SourceNameItems((short)i));
                        Dynamsoft.DotNet.TWAIN.Enums.EnumDeviceType enumDeviceType = dynamicDotNetTwain.GetSourceType((short)i);
                        if (enumDeviceType == Dynamsoft.DotNet.TWAIN.Enums.EnumDeviceType.SDT_TWAIN)
                            hasTwainSource = true;
                        else if (enumDeviceType == Dynamsoft.DotNet.TWAIN.Enums.EnumDeviceType.SDT_WEBCAM)
                            hasWebcamSource = true;
                    }

                    if (hasTwainSource)
                    {
                        cbxSource.Enabled = true;
                        chkShowUI.Enabled = true;
                        chkADF.Enabled = true;
                        chkDuplex.Enabled = true;
                        cbxResolution.Enabled = true;
                        rdbtnGray.Checked = true;
                        cbxResolution.SelectedIndex = 0;
                        EnableControls(this.picboxScan);
                    }

                    if (hasWebcamSource)
                    {
                        chkShowUIForWebcam.Enabled = true;
                        cbxMediaType.Enabled = true;
                        cbxResolutionForWebcam.Enabled = true;
                        EnableControls(this.picboxGrab);
                    }
                    
                    cbxSource.SelectedIndex = 0;
                    //dynamicDotNetTwain.SelectSourceByIndex((short)cbxSource.SelectedIndex);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DrawBackground()
        {
            // Create a bitmap
            Bitmap img = Properties.Resources.main_bg;
            // Set the form properties
            Size = new Size(img.Width, img.Height);
            BackgroundImage = new Bitmap(Width, Height);

            // Draw it
            Graphics g = Graphics.FromImage(BackgroundImage);
            g.DrawImage(img, 0, 0, img.Width, img.Height);      
        }

        /// <summary>
        /// Disable all the function buttons in the left and bottom panel
        /// </summary>
        private void DisableAllFunctionButtons()
        {
            DisableControls(this.picboxHand);
            DisableControls(this.picboxPoint);
            DisableControls(this.picboxCrop);
            DisableControls(this.picboxCut);

            DisableControls(this.picboxRotateRight);
            DisableControls(this.picboxRotateLeft);
            DisableControls(this.picboxMirror);
            DisableControls(this.picboxFlip);

            DisableControls(this.picboxLine);
            DisableControls(this.picboxEllipse);
            DisableControls(this.picboxRectangle);
            DisableControls(this.picboxText);

            DisableControls(this.picboxZoom);
            DisableControls(this.picboxResample);
            DisableControls(this.picboxZoomIn);
            DisableControls(this.picboxZoomOut);

            DisableControls(this.picboxDelete);
            DisableControls(this.picboxDeleteAll);

            DisableControls(this.picboxFirst);
            DisableControls(this.picboxPrevious);
            DisableControls(this.picboxNext);
            DisableControls(this.picboxLast);

            DisableControls(this.picboxFit);
            DisableControls(this.picboxOriginalSize);
        }
        
        /// <summary>
        /// Enable all the function buttons in the left and bottom panel
        /// </summary>
        private void EnableAllFunctionButtons()
        {
            EnableControls(this.picboxHand);
            EnableControls(this.picboxPoint);
            EnableControls(this.picboxCrop);
            EnableControls(this.picboxCut);

            EnableControls(this.picboxRotateRight);
            EnableControls(this.picboxRotateLeft);
            EnableControls(this.picboxMirror);
            EnableControls(this.picboxFlip);

            EnableControls(this.picboxLine);
            EnableControls(this.picboxEllipse);
            EnableControls(this.picboxRectangle);
            EnableControls(this.picboxText);

            EnableControls(this.picboxZoom);
            EnableControls(this.picboxResample);
            EnableControls(this.picboxZoomIn);
            EnableControls(this.picboxZoomOut);

            EnableControls(this.picboxDelete);
            EnableControls(this.picboxDeleteAll);

            EnableControls(this.picboxFit);
            EnableControls(this.picboxOriginalSize);

            if (dynamicDotNetTwain.HowManyImagesInBuffer > 1)
            {
                EnableControls(this.picboxFirst);
                EnableControls(this.picboxPrevious);
                EnableControls(this.picboxNext);
                EnableControls(this.picboxLast);

                if (dynamicDotNetTwain.CurrentImageIndexInBuffer == 0)
                {
                    DisableControls(picboxPrevious);
                    DisableControls(picboxFirst);
                }
                if (dynamicDotNetTwain.CurrentImageIndexInBuffer + 1 == dynamicDotNetTwain.HowManyImagesInBuffer)
                {
                    DisableControls(picboxNext);
                    DisableControls(picboxLast);
                }
            }

            checkZoom();
        }

        #region regist Event For All PictureBox Buttons
        private void picbox_MouseEnter(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                if ((sender as PictureBox).Enabled == true)
                {
                    (sender as PictureBox).Image =
                        (Image)Properties.Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Enter");
                }
            }
        }

        private void picbox_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox)
            {
                if ((sender as PictureBox).Enabled == true)
                {
                    (sender as PictureBox).Image =
                        (Image)Properties.Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Down");
                }
            }
        }

        private void picbox_MouseLeave(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                if ((sender as PictureBox).Enabled == true)
                {
                    (sender as PictureBox).Image =
                        (Image)Properties.Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Leave");
                    infoLabel.Text = "";
                    infoLabel.Visible = false;
                }
            }
        }

        private void picbox_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox)
            {
                if ((sender as PictureBox).Enabled == true)
                {
                    (sender as PictureBox).Image =
                        (Image)Properties.Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Enter");
                }
            }
           
        }

        private void picbox_MouseHover(object sender, EventArgs e)
        {
            infoLabel.Text = (sender as PictureBox).Tag.ToString();
            infoLabel.Location = new Point(this.PointToClient(MousePosition).X, this.PointToClient(MousePosition).Y + 20);
            infoLabel.Visible = true;
            infoLabel.BringToFront();
        }

        private void DisableControls(object sender)
        {
            if (sender is PictureBox)
            {
                (sender as PictureBox).Image =
                    (Image)Properties.Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Disabled");
                (sender as PictureBox).Enabled = false;
            }
            else
            {
                (sender as Control).Enabled = false;
            }
        }

        private void EnableControls(object sender)
        {
            if (sender is PictureBox)
            {
                (sender as PictureBox).Image =
                    (Image)Properties.Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Leave");
                (sender as PictureBox).Enabled = true;
            }
            else
            {
                (sender as Control).Enabled = true;
            }
        }

        #endregion

        # region functions for the form, ignore them please
        /// <summary>
        /// Mouse down when move the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbMoveBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
        }

        /// <summary>
        /// Mouse move when move the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbMoveBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                this.Location = mousePos;
            }
        }

        /// <summary>
        /// Close the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picboxClose_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Minimize the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picboxMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        private void picboxScan_Click(object sender, EventArgs e)
        {
            if (picboxScan.Enabled)
            {
                picboxScan.Focus();
                if (this.cbxSource.SelectedIndex < 0)
                {
                    MessageBox.Show(this, "There is no scanner detected!\n " +
                        "Please ensure that at least one (virtual) scanner is installed.", "Information");
                }
                else
                {
                    DisableControls(picboxScan);
                    this.AcquireImage();
                }
            }
        }

        /// <summary>
        /// Acquire image from the selected source
        /// </summary>
        private void AcquireImage()
        {
            try
            {
                // Select the source for TWAIN
                dynamicDotNetTwain.SelectSourceByIndex((short)cbxSource.SelectedIndex);
                dynamicDotNetTwain.OpenSource();
                // Set the image fit the size of window
                //dynamicDotNetTwain.IfFitWindow = true;
                //dynamicDotNetTwain.MouseShape = false;

                dynamicDotNetTwain.IfShowUI = chkShowUI.Checked;

                // if (chkADF.Enabled)
                // dynamicDotNetTwain.IfAutoFeed = dynamicDotNetTwain.IfFeederEnabled = chkADF.Checked;
                dynamicDotNetTwain.IfFeederEnabled = chkADF.Checked;
                //dynamicDotNetTwain.IfAutoFeed = chkADF.Checked;
                // if (chkDuplex.Enabled)
                dynamicDotNetTwain.IfDuplexEnabled = chkDuplex.Checked;

                // Need to open source first
                // dynamicDotNetTwain.OpenSource();
                dynamicDotNetTwain.IfDisableSourceAfterAcquire = true;

                if (rdbtnBW.Checked)
                {
                    dynamicDotNetTwain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_BW;
                    dynamicDotNetTwain.BitDepth = 1;
                }
                else if (rdbtnGray.Checked)
                {
                    dynamicDotNetTwain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_GRAY;
                    dynamicDotNetTwain.BitDepth = 8;
                }
                else
                {
                    dynamicDotNetTwain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_RGB;
                    dynamicDotNetTwain.BitDepth = 24;
                }


                dynamicDotNetTwain.Resolution = int.Parse(cbxResolution.Text);
                // Acquire image from the source
                if (!dynamicDotNetTwain.AcquireImage())
                    MessageBox.Show(dynamicDotNetTwain.ErrorString, "Scan error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("An exception occurs: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (dynamicDotNetTwain.ErrorCode != Dynamsoft.DotNet.TWAIN.Enums.ErrorCode.Succeed)
                    EnableControls(picboxScan);
            }
        }

        /// <summary>
        /// multi-page are allowed for tiff and pdf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbtnMultiPage_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked == true)
            {
                this.chkMultiPage.Enabled = true;
                this.chkMultiPage.Checked = true;
            }
        }

        /// <summary>
        /// When other image formats are selected, multi-page are not allowed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbtnSinglePage_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked == true)
            {
                this.chkMultiPage.Enabled = false;
                this.chkMultiPage.Checked = false;
            }
        }

        /// <summary>
        /// Verified the file name. If the file name is ok, return true, else return false.
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <returns></returns>
        private bool VerifyFileName(string fileName)
        {
            try
            {
                if (fileName.LastIndexOfAny(System.IO.Path.GetInvalidFileNameChars()) == -1)
                    return true;
            }
            catch (Exception e)
            {
            }
            MessageBox.Show("The file name contains invalid chars!", "Save Image To File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        /// <summary>
        /// Save the image as the selected format and name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picboxSave_Click(object sender, EventArgs e)
        {
            string fileName = tbxSaveFileName.Text.Trim();
            if (VerifyFileName(fileName))
            {
                saveFileDialog.FileName = this.tbxSaveFileName.Text;

                if (rdbtnJPG.Checked)
                {
                    saveFileDialog.Filter = "JPEG|*.JPG;*.JPEG;*.JPE;*.JFIF";
                    saveFileDialog.DefaultExt = "jpg";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        dynamicDotNetTwain.SaveAsJPEG(saveFileDialog.FileName, dynamicDotNetTwain.CurrentImageIndexInBuffer);
                    }
                }
                if (rdbtnBMP.Checked)
                {
                    saveFileDialog.Filter = "BMP|*.BMP";
                    saveFileDialog.DefaultExt = "bmp";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        dynamicDotNetTwain.SaveAsBMP(saveFileDialog.FileName, dynamicDotNetTwain.CurrentImageIndexInBuffer);
                    }
                }
                if (rdbtnPNG.Checked)
                {
                    saveFileDialog.Filter = "PNG|*.PNG";
                    saveFileDialog.DefaultExt = "png";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        dynamicDotNetTwain.SaveAsPNG(saveFileDialog.FileName, dynamicDotNetTwain.CurrentImageIndexInBuffer);
                    }
                }
                if (rdbtnTIFF.Checked)
                {
                    saveFileDialog.Filter = "TIFF|*.TIF;*.TIFF";
                    saveFileDialog.DefaultExt = "tiff";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Multi page TIFF
                        if (chkMultiPage.Checked == true)
                        {
                            dynamicDotNetTwain.SaveAllAsMultiPageTIFF(saveFileDialog.FileName);
                        }
                        else
                        {
                            dynamicDotNetTwain.SaveAsTIFF(saveFileDialog.FileName, dynamicDotNetTwain.CurrentImageIndexInBuffer);
                        }
                    }
                }
                if (rdbtnPDF.Checked)
                {
                    saveFileDialog.Filter = "PDF|*.PDF";
                    saveFileDialog.DefaultExt = "pdf";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Multi page PDF
                        dynamicDotNetTwain.IfSaveAnnotations = true;
                        if (chkMultiPage.Checked == true)
                        {
                            dynamicDotNetTwain.SaveAllAsPDF(saveFileDialog.FileName);
                        }
                        else
                        {
                            dynamicDotNetTwain.SaveAsPDF(saveFileDialog.FileName, dynamicDotNetTwain.CurrentImageIndexInBuffer);
                        }
                    }
                }
            }
            else
            {
                this.tbxSaveFileName.Focus();
            }
        }

        private void picboxPoint_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.MouseShape = false;
            dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumNone;
        }

        // Change mouse shape to hand, for move image
        private void picboxHand_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.MouseShape = true;
            dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumNone;
        }

        private void picboxFit_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.IfFitWindow = true;
            checkZoom();
        }

        private void picboxOriginalSize_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.IfFitWindow = false;
            checkZoom();
        }

        private void picboxCut_Click(object sender, EventArgs e)
        {
            picboxPoint_Click(sender, null);
            Rectangle rc = dynamicDotNetTwain.GetSelectionRect(dynamicDotNetTwain.CurrentImageIndexInBuffer);
            if (rc.IsEmpty)
            {
                MessageBox.Show("Please select the rectangle area first!", "Warning Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dynamicDotNetTwain.CutFrameToClipboard(dynamicDotNetTwain.CurrentImageIndexInBuffer, rc.Left, rc.Top, rc.Right, rc.Bottom);
            }
        }

        private void picboxCrop_Click(object sender, EventArgs e)
        {
            //if (dynamicDotNetTwain.AnnotationType != Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumNone)
            //{
              picboxPoint_Click(sender, null);
            //}    //what does this mean?
            Rectangle rc = dynamicDotNetTwain.GetSelectionRect(dynamicDotNetTwain.CurrentImageIndexInBuffer);
            if (rc.IsEmpty)
            {
                //isToCrop = true;
                //dynamicDotNetTwain.MouseShape = false;
                //DisableAllFunctionButtons();//why this?
               MessageBox.Show("Please select the rectangle area first!", "Warning Info", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                cropPicture(dynamicDotNetTwain.CurrentImageIndexInBuffer, rc);
            }
        }

        private void cropPicture(int imageIndex, Rectangle rc)
        {
            dynamicDotNetTwain.Crop((short)imageIndex, rc.X, rc.Y, rc.X + rc.Width, rc.Y + rc.Height);
        }

        private void picboxRotateLeft_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.RotateLeft(dynamicDotNetTwain.CurrentImageIndexInBuffer);
        }

        private void picboxRotateRight_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.RotateRight(dynamicDotNetTwain.CurrentImageIndexInBuffer);
        }

        private void picboxFlip_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.Flip(dynamicDotNetTwain.CurrentImageIndexInBuffer);
        }

        private void picboxMirror_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.Mirror(dynamicDotNetTwain.CurrentImageIndexInBuffer);
        }

        private void picboxLine_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.MouseShape = false;
            dynamicDotNetTwain.AnnotationPen = new Pen(Color.Blue, 5);
            dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumLine;
            if (panelAnnotations.Visible == false)
                panelAnnotations.Visible = true;
        }

        private void picboxEllipse_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.MouseShape = false;
            dynamicDotNetTwain.AnnotationPen = new Pen(Color.Black, 2);
            dynamicDotNetTwain.AnnotationFillColor = Color.Blue;
            dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumEllipse;
            if (panelAnnotations.Visible == false)
                panelAnnotations.Visible = true;
        }

        private void picboxRectangle_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.MouseShape = false;
            dynamicDotNetTwain.AnnotationPen = new Pen(Color.Black, 2);
            dynamicDotNetTwain.AnnotationFillColor = Color.ForestGreen;
            dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumRectangle;
            if (panelAnnotations.Visible == false)
                panelAnnotations.Visible = true;
        }

        private void picboxText_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.MouseShape = false;
            dynamicDotNetTwain.AnnotationTextColor = Color.Black;
            dynamicDotNetTwain.AnnotationTextFont = new Font("", 32);
            dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumText;
            if (panelAnnotations.Visible == false)
                panelAnnotations.Visible = true;
        }

        private void picboxZoom_Click(object sender, EventArgs e)
        {
            ZoomForm zoomForm = new ZoomForm(dynamicDotNetTwain.Zoom);
            zoomForm.ShowDialog();
            if (zoomForm.DialogResult == DialogResult.OK)
            {
                dynamicDotNetTwain.IfFitWindow = false;
                dynamicDotNetTwain.Zoom = zoomForm.ZoomRatio;
                checkZoom();
            }
        }

        private void picboxResample_Click(object sender, EventArgs e)
        {
            int width = dynamicDotNetTwain.GetImage(dynamicDotNetTwain.CurrentImageIndexInBuffer).Width;
            int height = dynamicDotNetTwain.GetImage(dynamicDotNetTwain.CurrentImageIndexInBuffer).Height;

            ResampleForm resampleForm = new ResampleForm(width, height);
            resampleForm.ShowDialog();
            if (resampleForm.DialogResult == DialogResult.OK)
            {
                dynamicDotNetTwain.ChangeImageSize(dynamicDotNetTwain.CurrentImageIndexInBuffer,resampleForm.NewWidth,resampleForm.NewHeight,
                    resampleForm.Interpolation);
                dynamicDotNetTwain.IfFitWindow = false;
            }
        }

        private void picboxZoomIn_Click(object sender, EventArgs e)
        {
            float zoom = dynamicDotNetTwain.Zoom + 0.1F;
            dynamicDotNetTwain.IfFitWindow = false;
            dynamicDotNetTwain.Zoom = zoom;
            checkZoom();
        }

        private void picboxZoomOut_Click(object sender, EventArgs e)
        {
            float zoom = dynamicDotNetTwain.Zoom - 0.1F;
            dynamicDotNetTwain.IfFitWindow = false;
            dynamicDotNetTwain.Zoom = zoom;
            checkZoom();
        }

        private void checkZoom()
        {
            if (cbxViewMode.SelectedIndex != 0 || dynamicDotNetTwain.HowManyImagesInBuffer == 0 )
               // || cbxViewMode.SelectedIndex != 0)
            {
                DisableControls(picboxZoomIn);
                DisableControls(picboxZoomOut);
                DisableControls(picboxZoom);
                DisableControls(picboxFit);
                DisableControls(picboxOriginalSize);
                return;
            }
            if (picboxFit.Enabled == false)
                EnableControls(picboxFit);
            if (picboxOriginalSize.Enabled == false)
                EnableControls(picboxOriginalSize);
            if (picboxZoom.Enabled == false)
                EnableControls(picboxZoom);

            //  the valid range of zoom is between 0.02 to 65.0,
           
            if (dynamicDotNetTwain.Zoom <= 0.02F)
            {
                DisableControls(picboxZoomOut);
            }
            else
            {
                EnableControls(picboxZoomOut);
            }

            if (dynamicDotNetTwain.Zoom >= 65F)         
            {
                DisableControls(picboxZoomIn);
            }
            else
            {
                EnableControls(picboxZoomIn);
            }
        }

        private void picboxDelete_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.RemoveImage(dynamicDotNetTwain.CurrentImageIndexInBuffer);
            checkImageCount();
        }

        private void picboxDeleteAll_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.RemoveAllImages();
            checkImageCount();
        }

        /// <summary>
        /// If the image count changed, some features should changed.
        /// </summary>
        private void checkImageCount()
        {
            currentImageIndex = dynamicDotNetTwain.CurrentImageIndexInBuffer;
            int currentIndex = currentImageIndex + 1;
            int imageCount = dynamicDotNetTwain.HowManyImagesInBuffer;
            if (imageCount == 0)
                currentIndex = 0;

            tbxCurrentImageIndex.Text = currentIndex.ToString();
            tbxTotalImageNum.Text = imageCount.ToString();

            if (imageCount > 0)
            {
                EnableControls(picboxSave);
                EnableAllFunctionButtons();
                EnableControls(picboxReadBarcode);
                EnableControls(picboxAddBarcode);
                EnableControls(picboxOCR);
            }
            else
            {
                DisableControls(picboxSave);
                DisableAllFunctionButtons();
                dynamicDotNetTwain.Visible = false;
                panelAnnotations.Visible = false;
                DisableControls(picboxReadBarcode);
                DisableControls(picboxAddBarcode);
                DisableControls(picboxOCR);
            }

            if (imageCount > 1)
            {
                EnableControls(picboxFirst);
                EnableControls(picboxLast);
                EnableControls(picboxPrevious);
                EnableControls(picboxNext);

                if (currentIndex == 1)
                {
                    DisableControls(picboxPrevious);
                    DisableControls(picboxFirst);
                }
                if (currentIndex == imageCount)
                {
                    DisableControls(picboxNext);
                    DisableControls(picboxLast);
                }
            }
            else
            {
                DisableControls(picboxFirst);
                DisableControls(picboxLast);
                DisableControls(picboxPrevious);
                DisableControls(picboxNext);
            }

            ShowSelectedImageArea();
        }

        private void cbxLayout_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(this.cbxViewMode.SelectedIndex)
            {
                case 0:
                    dynamicDotNetTwain.SetViewMode(-1,-1);
                    break;
                case 1:
                    dynamicDotNetTwain.SetViewMode(2, 2);
                    break;
                case 2: 
                    dynamicDotNetTwain.SetViewMode(3, 3);
                    break;
                case 3:
                    dynamicDotNetTwain.SetViewMode(4, 4);
                    break;
                case 4:
                    dynamicDotNetTwain.SetViewMode(5, 5);
                    break;
                default:
                    dynamicDotNetTwain.SetViewMode(-1, -1);
                    break;
            }
            checkZoom();
        }     

        private void picboxFirst_Click(object sender, EventArgs e)
        {
            if(dynamicDotNetTwain.HowManyImagesInBuffer > 0)
                dynamicDotNetTwain.CurrentImageIndexInBuffer = (short)0;
            checkImageCount();
        }

        private void picboxLast_Click(object sender, EventArgs e)
        {
            if (dynamicDotNetTwain.HowManyImagesInBuffer > 0)
                dynamicDotNetTwain.CurrentImageIndexInBuffer = (short)(dynamicDotNetTwain.HowManyImagesInBuffer - 1);
            checkImageCount();
        }

        private void picboxPrevious_Click(object sender, EventArgs e)
        {
            if (dynamicDotNetTwain.HowManyImagesInBuffer > 0 && dynamicDotNetTwain.CurrentImageIndexInBuffer > 0)
                --dynamicDotNetTwain.CurrentImageIndexInBuffer;
            checkImageCount();
        }

        private void picboxNext_Click(object sender, EventArgs e)
        {
            if (dynamicDotNetTwain.HowManyImagesInBuffer > 0 &&
                dynamicDotNetTwain.CurrentImageIndexInBuffer < dynamicDotNetTwain.HowManyImagesInBuffer - 1)
                ++dynamicDotNetTwain.CurrentImageIndexInBuffer;
            checkImageCount();
        }

        private void dynamicDotNetTwain_OnMouseClick(short sImageIndex)
        {
            if (dynamicDotNetTwain.CurrentImageIndexInBuffer != currentImageIndex)
                checkImageCount();
        }

        /// <summary>
        /// 
        /// </summary>
        private void dynamicDotNetTwain_OnPostAllTransfers()
        {
            CrossThreadOperationControl crossDelegate = delegate()
                {
                    dynamicDotNetTwain.Visible = true;
                    checkImageCount();
                    EnableControls(picboxScan);
                };
            this.Invoke(crossDelegate);
        }

        private void dynamicDotNetTwain_OnMouseDoubleClick(short sImageIndex)
        {
            try
            {
                Rectangle rc = dynamicDotNetTwain.GetSelectionRect(sImageIndex);

                if (isToCrop && !rc.IsEmpty)
                {
                    cropPicture(sImageIndex, rc);
                }
                isToCrop = false;
            }
            catch
            {
            }
            EnableAllFunctionButtons();
        }

        private void dynamicDotNetTwain_OnMouseRightClick(short sImageIndex)
        {
            if (isToCrop)
                isToCrop = false;
            dynamicDotNetTwain.ClearSelectionRect(sImageIndex);
            EnableAllFunctionButtons();
        }

        private void dynamicDotNetTwain_OnImageAreaDeselected(short sImageIndex)
        {
            if (isToCrop)
                isToCrop = false;
            EnableAllFunctionButtons();
            ShowSelectedImageArea();
        }

        private void cbxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            short sIndex = (short)((ComboBox)(sender)).SelectedIndex;          
            switch (dynamicDotNetTwain.GetSourceType(sIndex))
            {
                case Dynamsoft.DotNet.TWAIN.Enums.EnumDeviceType.SDT_TWAIN:
                    panelScan.Visible = true;
                    panelGrab.Visible = false;
                    lbUnknowSource.Visible = false;
                    dynamicDotNetTwain.CloseSource();//when switching from webcam source to twain source, need to close webcam source.
                    break;
                case Dynamsoft.DotNet.TWAIN.Enums.EnumDeviceType.SDT_WEBCAM:
                    panelScan.Visible = false;
                    panelGrab.Visible = true;
                    lbUnknowSource.Visible = false;
                    //Initial media type list and webcam resolution list
                    cbxMediaType.Items.Clear();
                    cbxResolutionForWebcam.Items.Clear();
                    dynamicDotNetTwain.IfDisableSourceAfterAcquire = false;//don't close video after grabbing an image.
                    dynamicDotNetTwain.SelectSourceByIndex(sIndex);
                    dynamicDotNetTwain.OpenSource();    //Open webcam source before getting the value of MediaTypeList and ResolutionForCamList
                    List<string> lstMediaTypes = dynamicDotNetTwain.MediaTypeList;
                    List<Dynamsoft.DotNet.TWAIN.WebCamera.CamResolution> lstWebcamResolutions = dynamicDotNetTwain.ResolutionForCamList;
                    if (lstMediaTypes != null)
                        foreach (string strMediaType in lstMediaTypes)
                            cbxMediaType.Items.Add(strMediaType);
                    if (lstWebcamResolutions != null)
                        foreach (Dynamsoft.DotNet.TWAIN.WebCamera.CamResolution camResolution in lstWebcamResolutions)
                            cbxResolutionForWebcam.Items.Add(camResolution.Width + " X " + camResolution.Height);
                    if (cbxMediaType.Items.Count > 0)
                        cbxMediaType.SelectedIndex = 0;
                    if (cbxResolutionForWebcam.Items.Count > 0)
                        cbxResolutionForWebcam.SelectedIndex = 0;
                    //show error information
                    if (dynamicDotNetTwain.ErrorCode != Dynamsoft.DotNet.TWAIN.Enums.ErrorCode.Succeed)
                        MessageBox.Show(dynamicDotNetTwain.ErrorString, "Webcam error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    panelScan.Visible = false;
                    panelGrab.Visible = false;
                    lbUnknowSource.Visible = true;
                    break;
            }
        }

        private void picboxTitle_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset2 = new Point(-e.X, -e.Y);
        }

        private void picboxTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset2.X, mouse_offset2.Y);
                if (IsInForm(panelAnnotations.Parent.PointToClient(mousePos)))
                    panelAnnotations.Location = panelAnnotations.Parent.PointToClient(mousePos);
            }
        }

        private bool IsInForm(Point point)
        {
            if (point.X > 0 && point.X < 693 && point.Y > 35 && point.Y < 635)
                return true;
            return false;
        }

        private void picboxDeleteAnnotationA_Click(object sender, EventArgs e)
        {
            List<Dynamsoft.DotNet.TWAIN.Annotation.AnnotationData> aryAnnotation;
            if(dynamicDotNetTwain.GetSelectedAnnotationList(dynamicDotNetTwain.CurrentImageIndexInBuffer,out aryAnnotation))
                dynamicDotNetTwain.DeleteAnnotations(dynamicDotNetTwain.CurrentImageIndexInBuffer,aryAnnotation);
        }

        private void picboxLoadImage_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*GIF;*.PDF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|GIF|*.GIF|PDF|*.PDF";
            openFileDialog.FilterIndex = 0;
            openFileDialog.Multiselect = true;

            dynamicDotNetTwain.IfAppendImage = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string strFileName in openFileDialog.FileNames)
                {
                    
                    int pos = strFileName.LastIndexOf(".");
                    if (pos != -1)
                    {
                        string strSuffix = strFileName.Substring(pos, strFileName.Length - pos).ToLower();
                        if (strSuffix.CompareTo(".pdf") == 0)
                        {
                            this.dynamicDotNetTwain.ConvertPDFToImage(strFileName, 200);
                            if (dynamicDotNetTwain.ErrorCode != Dynamsoft.DotNet.TWAIN.Enums.ErrorCode.Succeed)
                            {
                                MessageBox.Show(dynamicDotNetTwain.ErrorString, "Loading image error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            dynamicDotNetTwain.LoadImage(strFileName);
                    }
                    else
                        dynamicDotNetTwain.LoadImage(strFileName);
                }
                dynamicDotNetTwain.Visible = true;
            }
            checkImageCount();
        }

        private void ChangeSource_MouseHover(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                (sender as Label).ForeColor = System.Drawing.Color.Purple;
            }
        }

        private void ChangeSource_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                (sender as Label).ForeColor = System.Drawing.Color.Black;
            }
        }

        private void lbCloseAnnotations_MouseHover(object sender, EventArgs e)
        {
            this.lbCloseAnnotations.ForeColor = System.Drawing.Color.Red;
        }

        private void lbCloseAnnotations_MouseLeave(object sender, EventArgs e)
        {
            this.lbCloseAnnotations.ForeColor = System.Drawing.Color.Black;
        }

        private void lbCloseAnnotations_Click(object sender, EventArgs e)
        {
            this.panelAnnotations.Visible = false;
        }
        
        private TabHead m_thSelectedTabHead = null;
        private TabHead[] m_tabHeads = new TabHead[6];
        private Panel[] m_panels = new Panel[6];
        Dictionary<string, string> languages = new Dictionary<string, string>();

        private void TabHead_Click(object sender, EventArgs e)
        {
            TabHead thHead = (TabHead)sender;
            int iNeighborIndex = GetNeighborIndex(thHead);
            if (m_thSelectedTabHead != null && m_thSelectedTabHead.Index != iNeighborIndex && m_thSelectedTabHead.Index != thHead.Index)
            {
                m_thSelectedTabHead.State = TabHead.TabHeadState.ALLFOLDED;
                m_panels[m_thSelectedTabHead.Index].Visible = false;
                int iSelectHeadNeighborIndex = GetNeighborIndex(m_thSelectedTabHead);
                if (iSelectHeadNeighborIndex >= 0)
                    m_tabHeads[iSelectHeadNeighborIndex].State = TabHead.TabHeadState.ALLFOLDED;

            }

            if (thHead.State == TabHead.TabHeadState.SELECTED)
            {
                thHead.State = TabHead.TabHeadState.ALLFOLDED;
                m_panels[thHead.Index].Visible = false;
                if (iNeighborIndex >= 0)
                {
                    m_tabHeads[iNeighborIndex].State = TabHead.TabHeadState.ALLFOLDED;
                    m_panels[iNeighborIndex].Visible = false;
                }
                m_thSelectedTabHead = null;
            }
            else
            {
                thHead.State = TabHead.TabHeadState.SELECTED;
                m_panels[thHead.Index].Visible = true;
                if (iNeighborIndex >= 0)
                {
                    m_tabHeads[iNeighborIndex].State = TabHead.TabHeadState.FOLDED;
                    m_panels[iNeighborIndex].Visible = false;
                }
                m_thSelectedTabHead = thHead;
            }
        }

        private int GetNeighborIndex(TabHead thHead)
        {
            if (thHead != null && thHead.MultiTabHead)
                if (thHead.Index % 2 == 0)
                    return thHead.Index + 1;
                else
                    return thHead.Index -1;
            else
                return -1;
        }

        #region Read Barcode

        private void picboxReadBarcode_Click(object sender, EventArgs e)
        {
            ShowSelectedImageArea();
            int iMaxBarcodesToRead = 0;
            try
            {
                iMaxBarcodesToRead = int.Parse(tbxMaxBarcodeReads.Text);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Invalid input of MaxBarcodeReads", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbxMaxBarcodeReads.Focus();
            }

            if (dynamicDotNetTwain.CurrentImageIndexInBuffer < 0)
            {
                MessageBox.Show("Please load an image before reading barcode!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                BarcodeReader reader = new BarcodeReader();
                reader.LicenseKeys = "91392547848AAF2410B494747EADA719";
                reader.ReaderOptions.MaxBarcodesToReadPerPage = iMaxBarcodesToRead;
                switch (cbxBarcodeFormat.SelectedIndex)
                {
                    case 0:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.OneD;
                        break;
                    case 1:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_39;
                        break;
                    case 2:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_128;
                        break;
                    case 3:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_93;
                        break;
                    case 4:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODABAR;
                        break;
                    case 5:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.ITF;
                        break;
                    case 6:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_13;
                        break;
                    case 7:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_8;
                        break;
                    case 8:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_A;
                        break;
                    case 9:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_E;
                        break;
                    case 10:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.PDF417;
                        break;
                    case 11:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.QR_CODE;
                        break;
                    case 12:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.DATAMATRIX;
                        break;
                    case 13:
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.INDUSTRIAL_25;
                        break;
                }
                BarcodeResult[] aryResult = null;
                Rectangle rect = dynamicDotNetTwain.GetSelectionRect(dynamicDotNetTwain.CurrentImageIndexInBuffer);
                if (rect == Rectangle.Empty)
                {
                    int iWidth = dynamicDotNetTwain.GetImage(dynamicDotNetTwain.CurrentImageIndexInBuffer).Width;
                    int iHeight = dynamicDotNetTwain.GetImage(dynamicDotNetTwain.CurrentImageIndexInBuffer).Height;
                    rect = new Rectangle(0, 0, iWidth, iHeight);
                }
                    aryResult = reader.DecodeBitmapRect((Bitmap)(dynamicDotNetTwain.GetImage(this.dynamicDotNetTwain.CurrentImageIndexInBuffer)),rect);
                if (aryResult == null)
                {
                    string strResult = "The barcode for selected format is not found." + "\r\n";
                    MessageBox.Show(strResult, "Barcodes Results");
                }
                else
                {
                    string strResult = aryResult.Length + " total barcode found." + "\r\n";
                    for (int i = 0; i < aryResult.Length; i++)
                    {
                        strResult += "Result " + (i + 1) + "\r\n  " + "Barcode Format: " + aryResult[i].BarcodeFormat + "    Barcode Text: " + aryResult[i].BarcodeText + "\r\n";
                    }

                    MessageBox.Show(strResult, "Barcodes Results");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowSelectedImageArea()
        {
            if (dynamicDotNetTwain.CurrentImageIndexInBuffer >= 0)
            {
                Rectangle recSelArea = dynamicDotNetTwain.GetSelectionRect(dynamicDotNetTwain.CurrentImageIndexInBuffer);
                Image imgCurrent = dynamicDotNetTwain.GetImage(dynamicDotNetTwain.CurrentImageIndexInBuffer);
                if (recSelArea.IsEmpty)
                {
                    tbxLeft.Text = "0";
                    tbxRight.Text = imgCurrent.Width.ToString();
                    tbxTop.Text = "0";
                    tbxBottom.Text = imgCurrent.Height.ToString();
                }
                else
                {
                    tbxLeft.Text = recSelArea.Left < 0 ? "0" : (recSelArea.Left > imgCurrent.Width ? imgCurrent.Width.ToString() : recSelArea.Left.ToString());
                    tbxRight.Text = recSelArea.Right < 0 ? "0" : (recSelArea.Right > imgCurrent.Width ? imgCurrent.Width.ToString() : recSelArea.Right.ToString());
                    tbxTop.Text = recSelArea.Top < 0 ? "0" : (recSelArea.Top > imgCurrent.Height ? imgCurrent.Height.ToString() : recSelArea.Top.ToString());
                    tbxBottom.Text = recSelArea.Bottom < 0 ? "0" : (recSelArea.Bottom > imgCurrent.Height ? imgCurrent.Height.ToString() : recSelArea.Bottom.ToString());
                }
            }
            else
            {
                tbxLeft.Text = "0";
                tbxRight.Text = "0";
                tbxTop.Text = "0";
                tbxBottom.Text = "0";
            }
        }

        #endregion Read Barcode

        #region Add Barcode

        private void picboxAddBarcode_Click(object sender, EventArgs e)
        {
            if (picboxAddBarcode.Enabled)
            {
                if (dynamicDotNetTwain.CurrentImageIndexInBuffer >= 0)
                {
                    if (tbxBarcodeContent.Text != "" && tbxBarcodeLocationX.Text != "" && tbxBarcodeLocationY.Text != "" && tbxBarcodeScale.Text != "")
                    {
                        Dynamsoft.DotNet.TWAIN.Enums.Barcode.BarcodeFormat barcodeformat = Dynamsoft.DotNet.TWAIN.Enums.Barcode.BarcodeFormat.CODE_39;
                        switch (cbxGenBarcodeFormat.SelectedIndex)
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
                        if (!dynamicDotNetTwain.AddBarcode(dynamicDotNetTwain.CurrentImageIndexInBuffer, barcodeformat, tbxBarcodeContent.Text,
                            tbxHumanReadableText.Text, int.Parse(tbxBarcodeLocationX.Text), int.Parse(tbxBarcodeLocationY.Text), float.Parse(tbxBarcodeScale.Text)))
                            MessageBox.Show(dynamicDotNetTwain.ErrorString, "Adding barcode error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (tbxBarcodeContent.Text == "")
                        {
                            MessageBox.Show("The content of the barcode can not be empty", "Empty Object", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tbxBarcodeContent.Focus();
                        }
                        else if (tbxBarcodeLocationX.Text == "")
                        {
                            MessageBox.Show("The location of the barcode can not be empty", "Empty Object", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tbxBarcodeLocationX.Focus();
                        }
                        else if (tbxBarcodeLocationY.Text == "")
                        {
                            MessageBox.Show("The location of the barcode can not be empty", "Empty Object", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tbxBarcodeLocationY.Focus();
                        }
                        else if (tbxBarcodeScale.Text == "")
                        {
                            MessageBox.Show("The scale of the barcode can not be empty", "Empty Object", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tbxBarcodeScale.Focus();
                        }
                    }
                }
                else
                    MessageBox.Show("Please load an image before adding barcodes!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbxBarcodeLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(e.KeyChar.ToString());
            if (!char.IsDigit(e.KeyChar) || array.LongLength == 2) e.Handled = true;
            if (e.KeyChar == '\b') e.Handled = false;
        }

        private void tbxBarcodeScale_KeyPress(object sender, KeyPressEventArgs e)
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(e.KeyChar.ToString());
            if (!char.IsDigit(e.KeyChar) || array.LongLength == 2) e.Handled = true;
            if (e.KeyChar == '\b' || (!tbxBarcodeScale.Text.Contains(".") && e.KeyChar == '.')) e.Handled = false;
        }
        
        #endregion Add Barcode

        #region Perform OCR

        private void picboxOCR_Click(object sender, EventArgs e)
        {
            if (picboxOCR.Enabled)
            {
                if (dynamicDotNetTwain.CurrentImageIndexInBuffer >= 0)
                {
                    dynamicDotNetTwain.OCRLanguage = languages[cbxSupportedLanguage.Text];
                    dynamicDotNetTwain.OCRResultFormat = (Dynamsoft.DotNet.TWAIN.OCR.ResultFormat)cbxOCRResultFormat.SelectedIndex;
                    byte[] sbytes = null;
                    sbytes = dynamicDotNetTwain.OCR(dynamicDotNetTwain.CurrentSelectedImageIndicesInBuffer);

                    if (sbytes != null && sbytes.Length > 0)
                    {
                        SaveFileDialog filedlg = new SaveFileDialog();
                        if (cbxOCRResultFormat.SelectedIndex != 0)
                        {
                            filedlg.Filter = "PDF File(*.pdf)| *.pdf";
                        }
                        else
                        {
                            filedlg.Filter = "Text File(*.txt)| *.txt";
                        }
                        if (filedlg.ShowDialog() == DialogResult.OK)
                        {
                            System.IO.File.WriteAllBytes(filedlg.FileName, sbytes);
                        }
                    }
                    else
                    {
                        if (dynamicDotNetTwain.ErrorCode != 0)
                            MessageBox.Show(dynamicDotNetTwain.ErrorString, "Performing OCR error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Please load an image before doing OCR!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion Perform OCR

        private void dynamicDotNetTwain_OnImageAreaSelected(short sImageIndex, int left, int top, int right, int bottom)
        {
            ShowSelectedImageArea();
        }

        private void picboxGrab_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain.MediaType = cbxMediaType.Text;
            if (cbxResolutionForWebcam.Text != null)
            {
                string[] strWXH = cbxResolutionForWebcam.Text.Split(new char[]{' '});
                if (strWXH.Length == 3)
                {
                    try
                    {
                        dynamicDotNetTwain.ResolutionForCam = new Dynamsoft.DotNet.TWAIN.WebCamera.CamResolution(
                            int.Parse(strWXH[0]), int.Parse(strWXH[2]));
                    }
                    catch { }
                }
            }

            if (!dynamicDotNetTwain.AcquireImage())
                MessageBox.Show(dynamicDotNetTwain.ErrorString, "Grab error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dynamicDotNetTwain_OnSourceUIClose()
        {
            EnableControls(picboxScan);
        }

        private void cbxMediaType_SelectedIndexChanged(object sender,EventArgs e)
        {
            if (cbxMediaType.SelectedIndex >= 0)
            {
                try
                {
                    dynamicDotNetTwain.MediaType = cbxMediaType.Text;
                }
                catch { }
            }
        }

        private void cbxResolutionForWebcam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxResolutionForWebcam.Text != null)
            {
                string[] strWXH = cbxResolutionForWebcam.Text.Split(new char[] { ' ' });
                if (strWXH.Length == 3)
                {
                    try
                    {
                        dynamicDotNetTwain.ResolutionForCam = new Dynamsoft.DotNet.TWAIN.WebCamera.CamResolution(
                            int.Parse(strWXH[0]), int.Parse(strWXH[2]));
                    }
                    catch { }
                }
            }
        }

    }
}
