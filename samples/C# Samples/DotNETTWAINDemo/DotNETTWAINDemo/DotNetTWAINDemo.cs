using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using Dynamsoft.Barcode;
using Dynamsoft.TWAIN;
using Dynamsoft.Core;
using Dynamsoft.UVC;
using Dynamsoft.OCR;
using Dynamsoft.PDF;
using Dynamsoft.Core.Annotation;
using Dynamsoft.TWAIN.Interface;
using Dynamsoft.Core.Enums;
using System.IO;
using Dynamsoft.Common;


namespace DotNet_TWAIN_Demo
{
    public partial class DotNetTWAINDemo : Form,IAcquireCallback,IConvertCallback,ISave
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
        private string m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU=";

        private TwainManager m_TwainManager = null;
        private ImageCore m_ImageCore = null;
        private CameraManager m_CameraManager = null;
        private PDFRasterizer m_PDFRasterizer = null;
        private PDFCreator m_PDFCreator = null;
        private Tesseract m_Tesseract = null;
        private readonly BarcodeReader m_BarcodeReader;
        private BarcodeGenerator m_BarcodeGenerator = null;

        private Camera m_Camera = null;
        private string[] mBarcodeType = { "All_DEFAULT", "OneD_DEFAULT", "QR_CODE_DEFAULT", "PDF417_DEFAULT", "DATAMATRIX_DEFAULT", "CODE_39_DEFAULT", "CODE_128_DEFAULT", "CODE_93_DEFAULT", "CODABAR_DEFAULT", "ITF_DEFAULT", "INDUSTRIAL_25_DEFAULT", "EAN_13_DEFAULT", "EAN_8_DEFAULT", "UPC_A_DEFAULT", "UPC_E_DEFAULT" };
        private string mBarcodeFormat = "All_DEFAULT";

        public DotNetTWAINDemo()
        {
            InitializeComponent();
            InitializeComponentForCustomControl();
            m_TwainManager = new TwainManager(m_StrProductKey);
            m_ImageCore = new ImageCore();
            m_CameraManager = new CameraManager(m_StrProductKey);
            m_PDFRasterizer = new PDFRasterizer(m_StrProductKey);
            m_PDFCreator = new PDFCreator(m_StrProductKey);
            m_Tesseract = new Tesseract(m_StrProductKey);
            m_BarcodeReader = new BarcodeReader(m_StrProductKey);
            m_BarcodeGenerator = new BarcodeGenerator(m_StrProductKey);

            dsViewer.Bind(m_ImageCore);

            // Draw the background for the main form
            DrawBackground();
            Initialization();
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
            string strOCRTessDataFolder = null;
            string mSettingsPath = null;
            string strTempFolder = Application.ExecutablePath;
            strTempFolder = strTempFolder.Replace("/", "\\");
            if (!strTempFolder.EndsWith(@"\", false, System.Globalization.CultureInfo.CurrentCulture))
                strTempFolder += @"\";
            int pos = strTempFolder.LastIndexOf("\\Samples\\");
            if (pos != -1)
            {
                strTempFolder = strTempFolder.Substring(0, strTempFolder.IndexOf(@"\", pos));
                strOCRTessDataFolder = strTempFolder + @"\Samples\Bin\tessdata\";
                mSettingsPath = strTempFolder + @"\Samples\Bin\Templates\";
                strTempFolder = strTempFolder+ @"\Redistributable\Resources\";
            }
            else
            {
                pos = strTempFolder.LastIndexOf("\\");
                strTempFolder = Application.StartupPath + "\\Bin";
                mSettingsPath = strTempFolder + @"\\Templates\\";
                strOCRTessDataFolder = strTempFolder + "\\tessdata";
             }
            m_Tesseract.TessDataPath = strOCRTessDataFolder;
            try
            {
                m_BarcodeReader.LoadSettingsFromFile(mSettingsPath + "template_aggregation.json");
            }
            catch
            {
                MessageBox.Show("Failed to load the settings file, please check the file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            //viewer1.Visible = false;
            dsViewer.Visible = false;
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

            cbxBarcodeFormat.Items.Add("All");
            cbxBarcodeFormat.Items.Add("OneD");
            cbxBarcodeFormat.Items.Add("QRCode");
            cbxBarcodeFormat.Items.Add("PDF417");
            cbxBarcodeFormat.Items.Add("Datamatrix");
            cbxBarcodeFormat.Items.Add("Code 39");
            cbxBarcodeFormat.Items.Add("Code 128");
            cbxBarcodeFormat.Items.Add("Code 93");
            cbxBarcodeFormat.Items.Add("Codabar");
            cbxBarcodeFormat.Items.Add("Interleaved 2 of 5");
            cbxBarcodeFormat.Items.Add("Industrial 2 of 5");
            cbxBarcodeFormat.Items.Add("EAN-13");
            cbxBarcodeFormat.Items.Add("EAN-8");
            cbxBarcodeFormat.Items.Add("UPC-A");
            cbxBarcodeFormat.Items.Add("UPC-E");
            cbxBarcodeFormat.SelectedIndex = 0;
           

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

                dsViewer.IfFitWindow = true;
                dsViewer.MouseShape = false;
                dsViewer.SetViewMode(-1,-1);
                this.cbxViewMode.SelectedIndex = 0;

                // Init the sources for TWAIN scanning and Webcam grab, show in the cbxSources controls
                if (m_TwainManager.SourceCount > 0)
                {
                    bool hasTwainSource = false;
                    cbxSource.Items.Clear();
                    for (int i = 0; i < m_TwainManager.SourceCount; ++i)
                    {
                        cbxSource.Items.Add(m_TwainManager.SourceNameItems((short)i));
                        hasTwainSource = true;
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

                }
                int iSourceCount = 0;
                if(m_CameraManager.GetCameraNames()!=null)
                {
                    iSourceCount = m_CameraManager.GetCameraNames().Count;
                }
                if(iSourceCount>0)
                {
                    bool hasWebcamSource = false;
                    for (int i = 0; i < iSourceCount; i++)
                    {
                        cbxSource.Items.Add(m_CameraManager.GetCameraNames()[i]);
                        hasWebcamSource = true;
                    }
                    if (hasWebcamSource)
                    {
                        chkShowUIForWebcam.Enabled = true;
                        cbxResolutionForWebcam.Enabled = true;
                        EnableControls(this.picboxGrab);
                    }
                 }

                if (cbxSource.Items.Count > 0)
                {
                    cbxSource.SelectedIndex = 0;
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

            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 1)
            {
                EnableControls(this.picboxFirst);
                EnableControls(this.picboxPrevious);
                EnableControls(this.picboxNext);
                EnableControls(this.picboxLast);

                if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer == 0)
                {
                    DisableControls(picboxPrevious);
                    DisableControls(picboxFirst);
                }
                if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer + 1 == m_ImageCore.ImageBuffer.HowManyImagesInBuffer)
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

        private CameraUI m_CameraUI = null;
        /// <summary>
        /// Acquire image from the selected source
        /// </summary>
        private void AcquireImage()
        {
            try
            {

                short sSourceIndex = 0;
                sSourceIndex = (short)cbxSource.SelectedIndex;
                short sTwainSourceCount = m_TwainManager.SourceCount;
                short sCameraSourceCount = 0;
                if (m_CameraManager.GetCameraNames()!=null)
                {
                    sCameraSourceCount = (short)m_CameraManager.GetCameraNames().Count;
                }

                if (sSourceIndex < sTwainSourceCount)
                {
                    m_TwainManager.SelectSourceByIndex(sSourceIndex);
                    m_TwainManager.OpenSource();
                    m_TwainManager.IfShowUI = chkShowUI.Checked;
                    m_TwainManager.IfFeederEnabled = chkADF.Checked;
                    m_TwainManager.IfDuplexEnabled = chkDuplex.Checked;
                    m_TwainManager.IfDisableSourceAfterAcquire = true;



                    if (rdbtnBW.Checked)
                    {
                        m_TwainManager.PixelType = Dynamsoft.TWAIN.Enums.TWICapPixelType.TWPT_BW;
                        m_TwainManager.BitDepth = 1;
                    }
                    else if (rdbtnGray.Checked)
                    {
                        m_TwainManager.PixelType = Dynamsoft.TWAIN.Enums.TWICapPixelType.TWPT_GRAY;
                        m_TwainManager.BitDepth = 8;
                    }
                    else
                    {
                        m_TwainManager.PixelType = Dynamsoft.TWAIN.Enums.TWICapPixelType.TWPT_RGB;
                        m_TwainManager.BitDepth = 24;
                    }
                    m_TwainManager.Resolution = int.Parse(cbxResolution.Text);
                    m_TwainManager.AcquireImage(this as IAcquireCallback);
                }
                else
                {
                    short sCameraIndex = (short)(sSourceIndex - sTwainSourceCount);
                    m_Camera = m_CameraManager.SelectCamera(sCameraIndex);
                    if (m_CameraUI.IsDisposed||m_CameraUI == null)
                    {
                        m_CameraUI = new CameraUI();
                    }
                    m_CameraUI.Camera = m_Camera;
                    m_Camera.Open();
                    m_CameraUI.ClientSize = new Size(m_Camera.CurrentResolution.Width, m_Camera.CurrentResolution.Height);
                    m_CameraUI.Show();
                }

            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                EnableControls(picboxScan);
                dsViewer.Visible = true;
                checkImageCount();
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
            try
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
                            m_ImageCore.IO.SaveAsJPEG(saveFileDialog.FileName, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                        }
                    }
                    if (rdbtnBMP.Checked)
                    {
                        saveFileDialog.Filter = "BMP|*.BMP";
                        saveFileDialog.DefaultExt = "bmp";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            m_ImageCore.IO.SaveAsBMP(saveFileDialog.FileName, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                        }
                    }
                    if (rdbtnPNG.Checked)
                    {
                        saveFileDialog.Filter = "PNG|*.PNG";
                        saveFileDialog.DefaultExt = "png";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            m_ImageCore.IO.SaveAsPNG(saveFileDialog.FileName, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                        }
                    }
                    if (rdbtnTIFF.Checked)
                    {
                        saveFileDialog.Filter = "TIFF|*.TIF;*.TIFF";
                        saveFileDialog.DefaultExt = "tiff";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Multi page TIFF
                            List<short> tempListIndex = new List<short>();
                            if (chkMultiPage.Checked == true)
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
                            m_ImageCore.IO.SaveAsTIFF(saveFileDialog.FileName, tempListIndex);
                        }
                    }
                    if (rdbtnPDF.Checked)
                    {
                        saveFileDialog.Filter = "PDF|*.PDF";
                        saveFileDialog.DefaultExt = "pdf";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Multi page PDF
                            m_PDFCreator.Save(this as ISave, saveFileDialog.FileName);

                        }
                    }
                }
                else
                {
                    this.tbxSaveFileName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picboxPoint_Click(object sender, EventArgs e)
        {

            dsViewer.MouseShape = false;
            dsViewer.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumNone;
        }

        // Change mouse shape to hand, for move image
        private void picboxHand_Click(object sender, EventArgs e)
        {
            dsViewer.MouseShape = true;
            dsViewer.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumNone;
        }

        private void picboxFit_Click(object sender, EventArgs e)
        {
            dsViewer.IfFitWindow = true;
            checkZoom();
        }

        private void picboxOriginalSize_Click(object sender, EventArgs e)
        {
            dsViewer.IfFitWindow = false;
            dsViewer.Zoom = 1;
            checkZoom();
        }

        private void picboxCut_Click(object sender, EventArgs e)
        {
            picboxPoint_Click(sender, null);
            Rectangle rc = dsViewer.GetSelectionRect(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
            if (rc.IsEmpty)
            {
                MessageBox.Show("Please select the rectangle area first!", "Warning Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                m_ImageCore.ImageProcesser.CutFrameToClipborad(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, rc.Left, rc.Top, rc.Right, rc.Bottom);
            }
        }

        private void picboxCrop_Click(object sender, EventArgs e)
        {
              picboxPoint_Click(sender, null);
            Rectangle rc = dsViewer.GetSelectionRect(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
            if (rc.IsEmpty)
            {
               MessageBox.Show("Please select the rectangle area first!", "Warning Info", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                cropPicture(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, rc);
            }
        }

        private void cropPicture(int imageIndex, Rectangle rc)
        {
            m_ImageCore.ImageProcesser.Crop((short)imageIndex, rc.X, rc.Y, rc.X + rc.Width, rc.Y + rc.Height);
        }

        private void picboxRotateLeft_Click(object sender, EventArgs e)
        {

            int iImageWidth = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width;
            int iImageHeight = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height;
            List<AnnotationData> tempListAnnotation = (List<AnnotationData>)m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer,EnumMetaDataType.enumAnnotation);		
            if (tempListAnnotation != null&&tempListAnnotation.Count!=0)			
            {			
                foreach(AnnotationData tempAnnotation in tempListAnnotation)
                {		
                    int	x = tempAnnotation.Location.Y;
                    int	y = iImageWidth - (tempAnnotation.EndPoint.X);
                    int	iWidth = (tempAnnotation.EndPoint.Y - tempAnnotation.StartPoint.Y);
                    int iHeight = (tempAnnotation.EndPoint.X - tempAnnotation.StartPoint.X);	
                    switch (tempAnnotation.AnnotationType)	
                    {	
                        case AnnotationType.enumEllipse:
                        case AnnotationType.enumRectangle:
                        case AnnotationType.enumText:
                        tempAnnotation.StartPoint = new Point(x, y);
                        tempAnnotation.EndPoint = new Point((tempAnnotation.StartPoint.X + iWidth), (tempAnnotation.StartPoint.Y + iHeight));
                        break;
                        case AnnotationType.enumLine:
                        Point startPoint = tempAnnotation.StartPoint;
                        x = startPoint.Y;
                        y = iImageWidth - startPoint.X;
                        tempAnnotation.StartPoint = new Point(x,y);
                        Point endPoint = tempAnnotation.EndPoint;
                        x = endPoint.Y;
                        y = iImageWidth - endPoint.X;
                        tempAnnotation.EndPoint = new Point(x,y);
                    break;
                    }
                 }
             }
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempListAnnotation, true);
            m_ImageCore.ImageProcesser.RotateLeft(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
        }

        private void picboxRotateRight_Click(object sender, EventArgs e)
        {
            int iImageWidth = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width;
            int iImageHeight = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height;
            List<AnnotationData> tempListAnnotation = (List<AnnotationData>)m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation);	
            foreach (AnnotationData tempAnnotation in tempListAnnotation)
            {
                int x = iImageHeight - (tempAnnotation.Location.Y + tempAnnotation.Size.Height);
                int y = tempAnnotation.Location.X;
                int iWidth = tempAnnotation.Size.Height;
                int iHeight = tempAnnotation.Size.Width;
                switch (tempAnnotation.AnnotationType)
                {
                    case AnnotationType.enumEllipse:
                    case AnnotationType.enumRectangle:
                    case AnnotationType.enumText:
                        tempAnnotation.StartPoint = new Point(x, y);
                        tempAnnotation.EndPoint = new Point((tempAnnotation.StartPoint.X + iWidth), (tempAnnotation.StartPoint.Y + iHeight));
                        break;
                    case AnnotationType.enumLine:
                        Point startPoint = tempAnnotation.StartPoint; 
                        x = iImageHeight - startPoint.Y; 
                        y = startPoint.X;
                        tempAnnotation.StartPoint = new Point(x, y); 
                        Point endPoint = tempAnnotation.EndPoint; 
                        x = iImageHeight - endPoint.Y; 
                        y = endPoint.X;
                        tempAnnotation.EndPoint = new Point(x, y); 
                        break;
                }
            }
            m_ImageCore.ImageProcesser.RotateRight(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
        }

        private void picboxFlip_Click(object sender, EventArgs e)
        {
            int iImageWidth = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width;
            int iImageHeight = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height;
            List<AnnotationData> tempListAnnotation = (List<AnnotationData>)m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation);		
            if (tempListAnnotation != null && tempListAnnotation.Count != 0)
            {
                foreach (AnnotationData tempAnnotation in tempListAnnotation)
                {
                    int y = 0;
                    switch (tempAnnotation.AnnotationType)
                    {
                        case AnnotationType.enumRectangle:
                        case AnnotationType.enumEllipse:
                        case AnnotationType.enumText:
                            y = iImageHeight - (tempAnnotation.StartPoint.Y + tempAnnotation.Size.Height);
                            tempAnnotation.StartPoint = new Point(tempAnnotation.StartPoint.X, y);
                            tempAnnotation.EndPoint = new Point((tempAnnotation.StartPoint.X + tempAnnotation.Size.Width),(tempAnnotation.StartPoint.Y + tempAnnotation.Size.Height));
                            break;
                        case AnnotationType.enumLine:
                            y = iImageHeight - tempAnnotation.Location.Y - tempAnnotation.Size.Height;

                            Point startPoint = tempAnnotation.StartPoint; 
                            y = iImageHeight - startPoint.Y;
                            tempAnnotation.StartPoint = new Point(startPoint.X, y);
                            Point endPoint = tempAnnotation.EndPoint;
                            y = iImageHeight - endPoint.Y;
                            tempAnnotation.EndPoint = new Point(endPoint.X, y); 
                            break;
                    }
                }
            }
            m_ImageCore.ImageProcesser.Flip(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
        }

        private void picboxMirror_Click(object sender, EventArgs e)
        {
            int iImageWidth = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width;
            int iImageHeight = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height;
            List<AnnotationData> tempListAnnotation = (List<AnnotationData>)m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation);
            foreach (AnnotationData tempAnnotation in tempListAnnotation)
            {
                int x = 0;
                Point startPoint, endPoint;
                switch (tempAnnotation.AnnotationType)
                {
                    case AnnotationType.enumRectangle:
                    case AnnotationType.enumEllipse:
                    case AnnotationType.enumText:
                        x = iImageWidth - tempAnnotation.Location.X - tempAnnotation.Size.Width;
                        startPoint = new Point(x,tempAnnotation.StartPoint.Y);
                        endPoint = new Point((startPoint.X +tempAnnotation.Size.Width),(startPoint.Y + tempAnnotation.Size.Height));
                        tempAnnotation.StartPoint = startPoint;
                        tempAnnotation.EndPoint = endPoint;
                        break;
                    case AnnotationType.enumLine:
                        x = iImageWidth - tempAnnotation.Location.X - tempAnnotation.Size.Width;
                        startPoint = tempAnnotation.StartPoint;
                        x = iImageWidth - startPoint.X;
                        tempAnnotation.StartPoint = new Point(x, startPoint.Y);
                        endPoint = tempAnnotation.EndPoint;
                        x = iImageWidth - endPoint.X;
                        tempAnnotation.EndPoint = new Point(x, endPoint.Y); break;
                }

            }

            m_ImageCore.ImageProcesser.Mirror(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
        }

        private void picboxLine_Click(object sender, EventArgs e)
        {
            dsViewer.MouseShape = false;
            dsViewer.Annotation.Pen = new Pen(Color.Blue,5);
            dsViewer.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumLine;
            if (panelAnnotations.Visible == false)
                panelAnnotations.Visible = true;
        }

        private void picboxEllipse_Click(object sender, EventArgs e)
        {
            dsViewer.MouseShape = false;
            dsViewer.Annotation.Pen = new Pen(Color.Black,2);
            dsViewer.Annotation.FillColor = Color.Blue;
            dsViewer.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumEllipse;
            if (panelAnnotations.Visible == false)
                panelAnnotations.Visible = true;
        }

        private void picboxRectangle_Click(object sender, EventArgs e)
        {
            dsViewer.MouseShape = false;
            dsViewer.Annotation.Pen = new Pen(Color.Black,2);
            dsViewer.Annotation.FillColor = Color.ForestGreen;
            dsViewer.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumRectangle;
            if (panelAnnotations.Visible == false)
                panelAnnotations.Visible = true;
        }

        private void picboxText_Click(object sender, EventArgs e)
        {
            dsViewer.MouseShape = false;
            dsViewer.Annotation.TextColor = Color.Black;
            dsViewer.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumText;
            if (panelAnnotations.Visible == false)
                panelAnnotations.Visible = true;
        }

        private void picboxZoom_Click(object sender, EventArgs e)
        {
            ZoomForm zoomForm = new ZoomForm(dsViewer.Zoom);
            zoomForm.ShowDialog();
            if (zoomForm.DialogResult == DialogResult.OK)
            {
                dsViewer.IfFitWindow = false;
                dsViewer.Zoom = zoomForm.ZoomRatio;
                checkZoom();
            }
        }

        private void picboxResample_Click(object sender, EventArgs e)
        {
            int width = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width;
            int height = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height;

            ResampleForm resampleForm = new ResampleForm(width, height);
            resampleForm.ShowDialog();
            if (resampleForm.DialogResult == DialogResult.OK)
            {
                m_ImageCore.ImageProcesser.ChangeImageSize(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer,resampleForm.NewWidth,resampleForm.NewHeight,
                    resampleForm.Interpolation);
                dsViewer.IfFitWindow = false;
            }
        }

        private void picboxZoomIn_Click(object sender, EventArgs e)
        {
            float zoom = dsViewer.Zoom + 0.1F;
            dsViewer.IfFitWindow = false;
            dsViewer.Zoom = zoom;
            checkZoom();
        }

        private void picboxZoomOut_Click(object sender, EventArgs e)
        {
            float zoom = dsViewer.Zoom - 0.1F;
            dsViewer.IfFitWindow = false;
            dsViewer.Zoom = zoom;
            checkZoom();
        }

        private void checkZoom()
        {
            if (cbxViewMode.SelectedIndex != 0 || m_ImageCore.ImageBuffer.HowManyImagesInBuffer == 0 )
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
           
            if(dsViewer.Zoom<=0.02F)
            {
                DisableControls(picboxZoomOut);
            }
            else
            {
                EnableControls(picboxZoomOut);
            }

            if (dsViewer.Zoom >= 65F)
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
            m_ImageCore.ImageBuffer.RemoveImage(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
            checkImageCount();
        }

        private void picboxDeleteAll_Click(object sender, EventArgs e)
        {
            m_ImageCore.ImageBuffer.RemoveAllImages();
            checkImageCount();
        }

        /// <summary>
        /// If the image count changed, some features should changed.
        /// </summary>
        private void checkImageCount()
        {
            currentImageIndex = m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer;
            int currentIndex = currentImageIndex + 1;
            int imageCount = m_ImageCore.ImageBuffer.HowManyImagesInBuffer;
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
                dsViewer.Visible = false;
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
            
        }

        private void cbxLayout_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(this.cbxViewMode.SelectedIndex)
            {
                case 0:
                    dsViewer.SetViewMode(-1,-1);
                    break;
                case 1:
                    dsViewer.SetViewMode(2, 2);
                    break;
                case 2:
                    dsViewer.SetViewMode(3, 3);
                    break;
                case 3:
                    dsViewer.SetViewMode(4, 4);
                    break;
                case 4:
                    dsViewer.SetViewMode(5, 5);
                    break;
                default:
                    dsViewer.SetViewMode(-1, -1);
                    break;
            }
            checkZoom();
        }     

        private void picboxFirst_Click(object sender, EventArgs e)
        {
            if(m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0)
                m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer = (short)0;
            checkImageCount();
        }

        private void picboxLast_Click(object sender, EventArgs e)
        {
            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0)
                m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer = (short)(m_ImageCore.ImageBuffer.HowManyImagesInBuffer - 1);
            checkImageCount();
        }

        private void picboxPrevious_Click(object sender, EventArgs e)
        {
            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0 && m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer > 0)
                --m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer;
            checkImageCount();
        }

        private void picboxNext_Click(object sender, EventArgs e)
        {
            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0 &&
                m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer < m_ImageCore.ImageBuffer.HowManyImagesInBuffer - 1)
                ++m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer;
            checkImageCount();
        }

        private void cbxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            short sIndex = (short)((ComboBox)(sender)).SelectedIndex;

            if (sIndex < m_TwainManager.SourceCount)
            {
                panelScan.Visible = true;
                panelGrab.Visible = false;
                lbUnknowSource.Visible = false;
                m_TwainManager.CloseSource();
                if (m_Camera != null)
                {
                    m_Camera.Close();
                }
            }
            else
            {
                m_Camera = m_CameraManager.SelectCamera((short)(sIndex - m_TwainManager.SourceCount));
                if (m_CameraUI == null||m_CameraUI.IsDisposed)
                {
                    m_CameraUI = new CameraUI();
                    if (m_CameraUI.Camera == m_Camera)
                        return;
                    else
                    {
                        if(m_Camera!=null)
                            m_Camera.Close();
                    }
                }
                m_CameraUI.Camera = m_Camera;
                m_Camera.Open();
                m_CameraUI.ClientSize = new Size(m_Camera.CurrentResolution.Width,m_Camera.CurrentResolution.Height);
                if (m_CameraUI != null)
                    m_CameraUI.Show();
                panelScan.Visible = false;
                panelGrab.Visible = true;
                lbUnknowSource.Visible = false;
                //Initial media type list and webcam resolution list
                //cbxMediaType.Items.Clear();
                cbxResolutionForWebcam.Items.Clear();
                List<CamResolution> lstWebcamResolutions =m_Camera.SupportedResolutions;
                if (lstWebcamResolutions != null)
                    foreach (CamResolution camResolution in lstWebcamResolutions)
                        cbxResolutionForWebcam.Items.Add(camResolution.Width + " X " + camResolution.Height);
                if (cbxResolutionForWebcam.Items.Count > 0)
                    cbxResolutionForWebcam.SelectedIndex = 0;
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
            List<AnnotationData> tempListAnnotationData = (List<AnnotationData>)m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer,EnumMetaDataType.enumAnnotation);
            if (tempListAnnotationData != null)
            {
                List<AnnotationData> tempSelectedAnnotationData = new List<AnnotationData>();
                tempSelectedAnnotationData = (List<AnnotationData>)m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer,EnumMetaDataType.enumAnnotation);
                for (int i = tempSelectedAnnotationData.Count -1; i >=0 ; i--)
                {
                    if (tempSelectedAnnotationData[i].Selected == true)
                        tempSelectedAnnotationData.RemoveAt(i);
                }
            }
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer,EnumMetaDataType.enumAnnotation,tempListAnnotationData,true);
        }

        private void picboxLoadImage_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*GIF;*.PDF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|GIF|*.GIF|PDF|*.PDF";
            openFileDialog.FilterIndex = 0;
            openFileDialog.Multiselect = true;

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
                            m_PDFRasterizer.ConvertMode = Dynamsoft.PDF.Enums.EnumConvertMode.enumCM_RENDERALL;
                            m_PDFRasterizer.ConvertToImage(strFileName,"",200,this as IConvertCallback);
                        }
                        else
                            m_ImageCore.IO.LoadImage(strFileName);
                    }
                    else
                        m_ImageCore.IO.LoadImage(strFileName);
                }
                //viewer1.Visible = true;
                dsViewer.Visible = true;
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
        private void cbxBarcodeFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbxBarcodeFormat.SelectedIndex;
            mBarcodeFormat = mBarcodeType[index];
        }
        private void picboxReadBarcode_Click(object sender, EventArgs e)
        {
            //ShowSelectedImageArea();

            if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer < 0)
            {
                MessageBox.Show("Please load an image before reading barcode!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                Bitmap bmp = (Bitmap)(m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer));
                DateTime beforeRead = DateTime.Now;

                string[] Templates = m_BarcodeReader.GetAllParameterTemplateNames();
                bool bifcontian = false;
                for (int i = 0; i < Templates.Length; i++)
                {
                    if (mBarcodeFormat == Templates[i])
                    {
                        bifcontian = true;
                    }
                }
                if (!bifcontian)
                {
                    MessageBox.Show(("Failed to find the template named " + mBarcodeFormat + "."), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TextResult[] aryResult = m_BarcodeReader.DecodeBitmap(bmp, mBarcodeFormat);

                DateTime afterRead = DateTime.Now;
                int timeElapsed = (int)(afterRead - beforeRead).TotalMilliseconds;
                m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, null, true);
                if (aryResult != null)
                {
                    List<AnnotationData> tempListAnnotation = new List<AnnotationData>();
                    for (var i = 0; i < aryResult.Length; i++)
                    {
                        //add rect annotation
                        var penColor = Color.Red;
                        //if (aryResult[i].IsUnrecognized)
                        //    penColor = Color.Blue;

                        var rectAnnotation = new AnnotationData();
                        rectAnnotation.AnnotationType = AnnotationType.enumRectangle;
                        Rectangle boundingrect = ConvertLocationPointToRect(aryResult[i].LocalizationResult.ResultPoints);
                        rectAnnotation.StartPoint = new Point(boundingrect.Left, boundingrect.Top);
                        rectAnnotation.EndPoint = new Point((boundingrect.Left + boundingrect.Size.Width), (boundingrect.Top + boundingrect.Size.Height));
                        rectAnnotation.FillColor = Color.Transparent.ToArgb();
                        rectAnnotation.PenColor = penColor.ToArgb();
                        rectAnnotation.PenWidth = 3;
                        rectAnnotation.GUID = Guid.NewGuid();

                        float fsize = bmp.Width / 48.0f;
                        if (fsize < 25)
                            fsize = 25;

                        Font textFont = new Font("Times New Roman", fsize, FontStyle.Bold);

                        string strNo = "[" + (i + 1) + "]";
                        SizeF textSize = Graphics.FromHwnd(IntPtr.Zero).MeasureString(strNo, textFont);

                        var textAnnotation = new AnnotationData();
                        textAnnotation.AnnotationType = AnnotationType.enumText;
                        textAnnotation.StartPoint = new Point(boundingrect.Left, (int)(boundingrect.Top - textSize.Height * 1.25f));
                        textAnnotation.EndPoint = new Point((textAnnotation.StartPoint.X + (int)textSize.Width * 2), (int)(textAnnotation.StartPoint.Y + textSize.Height * 1.25f));
                        if (textAnnotation.StartPoint.X < 0)
                        {
                            textAnnotation.EndPoint = new Point((textAnnotation.EndPoint.X + textAnnotation.StartPoint.X), textAnnotation.EndPoint.Y);
                            textAnnotation.StartPoint = new Point(0, textAnnotation.StartPoint.Y);
                        }
                        if (textAnnotation.StartPoint.Y < 0)
                        {
                            textAnnotation.EndPoint = new Point(textAnnotation.EndPoint.X, (textAnnotation.EndPoint.Y - textAnnotation.StartPoint.Y));
                            textAnnotation.StartPoint = new Point(textAnnotation.StartPoint.X, 0);
                        }

                        textAnnotation.TextContent = strNo;
                        AnnoTextFont tempFont = new AnnoTextFont();
                        tempFont.TextColor = Color.Blue.ToArgb();
                        tempFont.Size = (int)fsize;
                        tempFont.Name = "Times New Roman";
                        textAnnotation.FontType = tempFont;
                        textAnnotation.GUID = Guid.NewGuid();

                        tempListAnnotation.Add(rectAnnotation);
                        tempListAnnotation.Add(textAnnotation);
                    }
                    m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempListAnnotation, true);
                }

                this.ShowResult(aryResult, timeElapsed);

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowResult(TextResult[] aryResult, int timeElapsed)
        {
            string strResult;

            if (aryResult == null)
            {
                strResult = "No barcode found. Total time spent: " + timeElapsed + " ms\r\n";
            }
            else
            {
                strResult = "Total barcode(s) found: " + aryResult.Length + ". Total time spent: " + timeElapsed + " ms\r\n";


                for (var i = 0; i < aryResult.Length; i++)
                {
                    strResult += string.Format("  Barcode: {0}\r\n", (i + 1));
                    strResult += string.Format("    Type: {0}\r\n", aryResult[i].BarcodeFormat.ToString());
                    strResult = AddBarcodeText(strResult, aryResult[i].BarcodeText);
                    strResult += "\r\n";
                }
            }
            MessageBox.Show(strResult, "Barcodes Results");
        }
        private string AddBarcodeText(string result, string barcodetext)
        {
            string temp = "";
            string temp1 = barcodetext;
            for (int j = 0; j < temp1.Length; j++)
            {
                if (temp1[j] == '\0')
                {
                    temp += "\\";
                    temp += "0";
                }
                else
                {
                    temp += temp1[j].ToString();
                }
            }
            result += string.Format("    Value: {0}\r\n", temp);
            return result;
        }
        private Rectangle ConvertLocationPointToRect(Point[] points)
        {
            int left = points[0].X, top = points[0].Y, right = points[1].X, bottom = points[1].Y;
            for (int i = 0; i < points.Length; i++)
            {

                if (points[i].X < left)
                {
                    left = points[i].X;
                }

                if (points[i].X > right)
                {
                    right = points[i].X;
                }

                if (points[i].Y < top)
                {
                    top = points[i].Y;
                }

                if (points[i].Y > bottom)
                {
                    bottom = points[i].Y;
                }
            }
            Rectangle temp = new Rectangle(left, top, (right - left), (bottom - top));
            return temp;
        }

    #endregion Read Barcode

    #region Add Barcode

    private void picboxAddBarcode_Click(object sender, EventArgs e)
        {
            if (picboxAddBarcode.Enabled)
            {
                if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer >= 0)
                {
                    if (tbxBarcodeContent.Text != "" && tbxBarcodeLocationX.Text != "" && tbxBarcodeLocationY.Text != "" && tbxBarcodeScale.Text != "")
                    {
                        Dynamsoft.Barcode.Enums.EnumBarcodeFormat barcodeformat = Dynamsoft.Barcode.Enums.EnumBarcodeFormat.CODE_39;
                        switch (cbxGenBarcodeFormat.SelectedIndex)
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
                                barcodeformat = Dynamsoft.Barcode.Enums.EnumBarcodeFormat.QR_CODE;
                                break;
                        }
                        Bitmap bit =  m_BarcodeGenerator.AddBarcode(m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer), barcodeformat, tbxBarcodeContent.Text, tbxHumanReadableText.Text, int.Parse(tbxBarcodeLocationX.Text), int.Parse(tbxBarcodeLocationY.Text), float.Parse(tbxBarcodeScale.Text));
                        m_ImageCore.ImageBuffer.SetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer,bit);
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
                if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer >= 0)
                {
                    m_Tesseract.Language = languages[cbxSupportedLanguage.Text];
                    m_Tesseract.ResultFormat = (Dynamsoft.OCR.Enums.ResultFormat)cbxOCRResultFormat.SelectedIndex;
                    byte[] sbytes = null;
                    List<Bitmap> templistBitmap = new List<Bitmap>();
                    for (short sCount = 0; sCount < dsViewer.CurrentSelectedImageIndicesInBuffer.Count; sCount++)
                    {
                        templistBitmap.Add(m_ImageCore.ImageBuffer.GetBitmap(dsViewer.CurrentSelectedImageIndicesInBuffer[sCount]));
                    }
                        sbytes = m_Tesseract.Recognize(templistBitmap);

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
                }
                else
                    MessageBox.Show("Please load an image before doing OCR!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion Perform OCR

        private void picboxGrab_Click(object sender, EventArgs e)
        {
            dsViewer.Visible = true;
            if (cbxResolutionForWebcam.Text != null)
            {
                string[] strWXH = cbxResolutionForWebcam.Text.Split(new char[] { ' ' });
                if (strWXH.Length == 3)
                {
                    try
                    {
                        m_Camera.CurrentResolution = new CamResolution(
                            int.Parse(strWXH[0]), int.Parse(strWXH[2]));
                        if (m_CameraUI != null && (!m_CameraUI.IsDisposed))
                        {
                            m_CameraUI.ClientSize = new Size(int.Parse(strWXH[0]), int.Parse(strWXH[2]));
                        }
                    }
                    catch { }
                }
            }
            Bitmap tempbmp = m_Camera.GrabImage();
            m_ImageCore.IO.LoadImage(tempbmp);
            checkImageCount();
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
                        m_Camera.CurrentResolution = new CamResolution(int.Parse(strWXH[0]), int.Parse(strWXH[2]));
                        if (m_CameraUI != null && (!m_CameraUI.IsDisposed))
                        {
                            m_CameraUI.ClientSize = new Size(int.Parse(strWXH[0]), int.Parse(strWXH[2]));
                        }
                    }
                    catch { }
                }
            }
        }


        public void OnPostAllTransfers()
        {
            CrossThreadOperationControl crossDelegate = delegate()
            {
                dsViewer.Visible = true;
                checkImageCount();
                EnableControls(picboxScan);
            };
            this.Invoke(crossDelegate);
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
            EnableControls(picboxScan);
        }

        public void OnTransferCancelled()
        {
        }

        public void OnTransferError()
        {
        }

        private void picboxClose_Click(object sender, EventArgs e)
        {
            if (m_TwainManager != null)
            {
                m_TwainManager.Dispose();
            }
            if (m_Camera != null)
            {
                m_Camera.Close();
            }

        }

        public void LoadConvertResult(ConvertResult result)
        {
            m_ImageCore.IO.LoadImage(result.Image);
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer,EnumMetaDataType.enumAnnotation,result.Annotations,true);
        }

        public object GetAnnotations(int iPageNumber)
        {
            if (chkMultiPage.Checked == true)
            {
                return m_ImageCore.ImageBuffer.GetMetaData((short)iPageNumber,EnumMetaDataType.enumAnnotation);
            }
            else
            {
                return m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer,EnumMetaDataType.enumAnnotation);
            }
        }

        public Bitmap GetImage(int iPageNumber)
        {
            if(chkMultiPage.Checked == true)
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
            if (chkMultiPage.Checked == true)
            {
                return m_ImageCore.ImageBuffer.HowManyImagesInBuffer;
            }
            else
            {
                return 1;
            }
        }

        private void dsViewer_OnImageAreaDeselected(short sImageIndex)
        {
            if (isToCrop)
                isToCrop = false;
            EnableAllFunctionButtons();
        }

        private void dsViewer_OnImageAreaSelected(short sImageIndex, int left, int top, int right, int bottom)
        {
        }

        private void dsViewer_OnMouseClick(short sImageIndex)
        {
            if (m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer != currentImageIndex)
            {
                checkImageCount();
            }
        }

        private void dsViewer_OnMouseDoubleClick(short sImageIndex)
        {
            try
            {
                Rectangle rc = dsViewer.GetSelectionRect(sImageIndex);

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

        private void dsViewer_OnMouseRightClick(short sImageIndex)
        {
            if (isToCrop)
                isToCrop = false;
            dsViewer.ClearSelectionRect(sImageIndex);
            EnableAllFunctionButtons();
        }

    }

}
