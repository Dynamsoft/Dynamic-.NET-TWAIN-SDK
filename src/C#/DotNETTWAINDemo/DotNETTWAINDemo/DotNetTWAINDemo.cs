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

        private Label lbLoadImageInfo;
        private PictureBox picboxLoadImage;

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

            // Draw the background for the main form
            DrawBackground();
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

            // For the load image label
            this.lbLoadImageInfo = new System.Windows.Forms.Label();
            this.lbLoadImageInfo.AutoSize = true;
            this.lbLoadImageInfo.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.lbLoadImageInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoadImageInfo.Location = new System.Drawing.Point(19, 50);
            this.lbLoadImageInfo.Name = "lbLoadImageInfo";
            this.lbLoadImageInfo.Size = new System.Drawing.Size(83, 15);
            this.lbLoadImageInfo.TabIndex = 84;
            this.lbLoadImageInfo.Text = "Load a local image";
            this.lbLoadImageInfo.Visible = false;

            // For the load image button
            picboxLoadImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(picboxLoadImage)).BeginInit();
            this.picboxLoadImage.Image =(Image)Properties.Resources.ResourceManager.GetObject("picboxLoadImage_Leave");
            this.picboxLoadImage.Location = new System.Drawing.Point(40, 82);
            this.picboxLoadImage.Name = "picboxLoadImage";
            this.picboxLoadImage.Size = new System.Drawing.Size(180, 38);
            this.picboxLoadImage.TabIndex = 59;
            this.picboxLoadImage.TabStop = false;
            this.picboxLoadImage.Tag = "Load a local image";
            this.picboxLoadImage.Visible = false;
            this.picboxLoadImage.MouseLeave += new System.EventHandler(this.picbox_MouseLeave);
            this.picboxLoadImage.Click += new System.EventHandler(this.picboxLoadImage_Click);
            this.picboxLoadImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseDown);
            //this.picboxLoadImage.MouseHover += new System.EventHandler(this.picbox_MouseHover);
            this.picboxLoadImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_MouseUp);
            this.picboxLoadImage.MouseEnter += new System.EventHandler(this.picbox_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.picboxScan)).EndInit();

            this.panelSource.Controls.Add(this.lbLoadImageInfo);
            this.panelSource.Controls.Add(this.picboxLoadImage);
        }

        /// <summary>
        /// Init the default value for TWAIN
        /// </summary>
        private void InitDefaultValueForTWAIN()
        {
            try
            {
               // dynamicDotNetTwain.IfThrowException = true;
                dynamicDotNetTwain.IfFitWindow = true;
                dynamicDotNetTwain.MouseShape = false;
                dynamicDotNetTwain.SetViewMode(-1, -1);
                this.cbxViewMode.SelectedIndex = 0;

                // Init the sources for TWAIN scanning, show in the cbxSources controls
                if (dynamicDotNetTwain.SourceCount > 0)
                {
                    

                    for (int i = 0; i < dynamicDotNetTwain.SourceCount; ++i)
                    {
                        cbxSource.Items.Add(dynamicDotNetTwain.SourceNameItems((short)i));
                    }

                    cbxSource.Enabled = true; 
                    chkShowUI.Enabled = true;
                    chkADF.Enabled = true;
                    chkDuplex.Enabled = true;
                    cbxResolution.Enabled = true;
                    EnableControls(this.picboxScan);
                    
                    cbxSource.SelectedIndex = 0;
                    rdbtnGray.Checked = true;
                    cbxResolution.SelectedIndex = 0;
                    dynamicDotNetTwain.SelectSourceByIndex((short)cbxSource.SelectedIndex);
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
            DisableControls(this.picboxRotate);

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
        }
        
        /// <summary>
        /// Enable all the function buttons in the left and bottom panel
        /// </summary>
        private void EnableAllFunctionButtons()
        {
            EnableControls(this.picboxHand);
            EnableControls(this.picboxPoint);
            EnableControls(this.picboxCrop);
            EnableControls(this.picboxRotate);

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
            if (this.cbxSource.SelectedIndex < 0)
            {
                MessageBox.Show(this, "There is no scaner detected!\n " +
                    "Please ensure that at least one (virtual) scanner is installed.", "Information");
            }
            else
            {
                this.AcquireImage();
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
                dynamicDotNetTwain.IfAutoFeed = chkADF.Checked;
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
                dynamicDotNetTwain.AcquireImage();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("An exception occurs: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            for (int i = 0; i < fileName.Length; i++)
            {
                if (!(char.IsLetterOrDigit(fileName[i]) || fileName[i] == '_' || fileName[i] == ' '))
                    return false;
            }
            return true;
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

        private void picboxRotate_Click(object sender, EventArgs e)
        {
            double angle;
            Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod interPolation = 
                Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod.Bilinear;
            bool keepSize;
            int r, g, b;
            Color fillColor;

            RotateForm rotateForm = new RotateForm();
            rotateForm.ShowDialog();

            if (rotateForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (rotateForm.cbxInterPolation.SelectedIndex == 0)
                {
                    interPolation = Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod.Bicubic;
                }
                if (rotateForm.cbxInterPolation.SelectedIndex == 1)
                {
                    interPolation = Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod.Bilinear;
                }
                if (rotateForm.cbxInterPolation.SelectedIndex == 2)
                {
                    interPolation = Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod.NearestNeighbour;
                }
                keepSize = rotateForm.cbxKeepSize.Checked;

                bool dAngle = double.TryParse(rotateForm.tbxAngle.Text, out angle);
                bool iR = int.TryParse(rotateForm.tbxR.Text, out r);
                bool iG = int.TryParse(rotateForm.tbxG.Text, out g);
                bool iB = int.TryParse(rotateForm.tbxB.Text, out b);

                if (dAngle && iR && iG && iB)
                {
                    if (r >= 0 && r <= 255 && g >= 0 && g <= 255 && b >= 0 && b <= 255)
                    {
                        fillColor = Color.FromArgb(r, g, b);
                        dynamicDotNetTwain.BackgroundFillColor = fillColor.ToArgb();
                    }
                    dynamicDotNetTwain.Rotate(dynamicDotNetTwain.CurrentImageIndexInBuffer,
                        angle, keepSize, interPolation);
                }
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
                return;
            }
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
            }
            else
            {
                DisableControls(picboxSave);
                DisableAllFunctionButtons();
                dynamicDotNetTwain.Visible = false;
                panelAnnotations.Visible = false;
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
        }

        private void cbxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            dynamicDotNetTwain.SelectSourceByIndex((short)((ComboBox)(sender)).SelectedIndex);
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
            openFileDialog.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF";
            openFileDialog.FilterIndex = 0;
            openFileDialog.Multiselect = false;

            dynamicDotNetTwain.IfAppendImage = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dynamicDotNetTwain.LoadImage(openFileDialog.FileName);
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

        private void lbLoadImageBar_Click(object sender, EventArgs e)
        {
            this.panelSource.Visible = false;
            this.panelSource.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Load_Image");
            this.panelSource.Size = new System.Drawing.Size(250, 130);

            this.cbxSource.Visible = false;
            this.cbxResolution.Visible = false;
            this.picboxScan.Visible = false;
            this.lbSelectSource.Visible = false;
            this.lbResolution.Visible = false;
            this.chkShowUI.Visible = false;
            this.chkDuplex.Visible = false;
            this.chkADF.Visible = false;

            this.lbLoadImageInfo.Visible = true;
            this.picboxLoadImage.Visible = true;

            this.panelSource.Visible = true;
        }

        private void lbTWAINSourceBar_Click(object sender, EventArgs e)
        {
            this.panelSource.Visible = false;
            this.panelSource.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("TWAIN_Source");
            this.panelSource.Size = new System.Drawing.Size(250, 265);

            this.lbLoadImageInfo.Visible = false;
            this.picboxLoadImage.Visible = false;

            this.cbxSource.Visible = true;
            this.cbxResolution.Visible = true;
            this.picboxScan.Visible = true;
            this.lbSelectSource.Visible = true;
            this.lbResolution.Visible = true;
            this.chkShowUI.Visible = true;
            this.chkDuplex.Visible = true;
            this.chkADF.Visible = true;

            this.panelSource.Visible = true;
        }
    }
}