using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.DotNet.TWAIN.Annotation;
using Dynamsoft.DotNet.TWAIN.Enums;


namespace AnnotationSample
{
    public partial class Form1 : Form
    {

        private List<AnnotationData> aryAnnotation = new List<AnnotationData>();
        
        public Form1()
        {
            InitializeComponent();
            toolStripCbxPen.SelectedIndex = 0;
            toolStripCbxFont.SelectedIndex = 0;

            dynamicDotNetTwain1.AnnotationType = DWTAnnotationType.enumPointer;
            dynamicDotNetTwain1.MaxImagesInBuffer = 1000;
            dynamicDotNetTwain1.SetViewMode(1, 1);

            string imagePath = Application.ExecutablePath;
            imagePath = imagePath.Replace("/", "\\");
            string strDllFolder = imagePath;
            int pos = imagePath.LastIndexOf("\\Samples\\");
            if (pos != -1)
            {
                imagePath = imagePath.Substring(0, imagePath.IndexOf(@"\", pos)) + @"\Samples\Bin\Images\AnnotationImage\Annotation Sample Image.png";
                strDllFolder = strDllFolder.Substring(0, strDllFolder.IndexOf(@"\", pos)) + @"\Redistributable\PDFResources\";
            }
            else
            {
                pos = strDllFolder.LastIndexOf("\\");
                strDllFolder = strDllFolder.Substring(0, strDllFolder.IndexOf(@"\", pos)) + @"\";
            }
            dynamicDotNetTwain1.LoadImage(imagePath);

            dynamicDotNetTwain1.PDFRasterizerDllPath = strDllFolder;
            dynamicDotNetTwain1.IfShowCancelDialogWhenBarcodeOrOCR = true;
            dynamicDotNetTwain1.MaxImagesInBuffer = 64;
            dynamicDotNetTwain1.ScanInNewProcess = true;          
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AnnotationData> aryAnnotation = new List<AnnotationData>();
            dynamicDotNetTwain1.GetSelectedAnnotationList(dynamicDotNetTwain1.CurrentImageIndexInBuffer, out aryAnnotation);
            dynamicDotNetTwain1.DeleteAnnotations(dynamicDotNetTwain1.CurrentImageIndexInBuffer, aryAnnotation);
            UpdateAnnotationProperty();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedlg = new OpenFileDialog();
            filedlg.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF;*.GIF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF|GIF|*.GIF";
            filedlg.Multiselect = true;
            if (filedlg.ShowDialog() == DialogResult.OK )
            {
                foreach (string strfilename in filedlg.FileNames)
                {
                    int pos = strfilename.LastIndexOf(".");
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
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dynamicDotNetTwain1.HowManyImagesInBuffer > 0)
            {
                this.dynamicDotNetTwain1.IfSaveAnnotations = true;
                SaveFileDialog filedlg = new SaveFileDialog();
                filedlg.Filter = "PDF File(*.pdf)| *.pdf";
                if (filedlg.ShowDialog() == DialogResult.OK)
                {
                    this.dynamicDotNetTwain1.SaveAsMultiPagePDF(filedlg.FileName, dynamicDotNetTwain1.CurrentSelectedImageIndicesInBuffer);
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dynamicDotNetTwain1.IfShowPrintUI = true;
            this.dynamicDotNetTwain1.Print();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineAnnotationData LAnnotation = new LineAnnotationData ();
            LAnnotation.StartPoint = new Point(200, 200);
            LAnnotation.EndPoint = new Point(260, 280);
            LAnnotation.PenColor = Color.Black;
            LAnnotation.PenWidth = 5;
            LAnnotation.Description = "Create a line annotation.";
            this.dynamicDotNetTwain1.CreateAnnotation(this.dynamicDotNetTwain1.CurrentImageIndexInBuffer, LAnnotation);
            
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EllipseAnnotationData EAnnotation = new EllipseAnnotationData();
            EAnnotation.AnnotationLocation = new Point (300,300);
            EAnnotation.AnnotationSize = new Size(80, 140);
            EAnnotation.FillColor = Color.Blue;
            EAnnotation.PenColor = Color.Black;
            EAnnotation.PenWidth = 2;   
            EAnnotation.Description = "Create an ellipse annotation.";
            this.dynamicDotNetTwain1.CreateAnnotation(this.dynamicDotNetTwain1.CurrentImageIndexInBuffer, EAnnotation);
            
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RectangleAnnotationData RAnnotation = new RectangleAnnotationData ();
            RAnnotation.AnnotationLocation = new Point(400, 400);
            RAnnotation.AnnotationSize = new Size(90, 120);
            RAnnotation.FillColor = Color.Green;
            RAnnotation.PenColor = Color.Black;
            RAnnotation.PenWidth = 2;
            RAnnotation.Description = "Create a rectangle annotation.";
            this.dynamicDotNetTwain1.CreateAnnotation(this.dynamicDotNetTwain1.CurrentImageIndexInBuffer, RAnnotation);
            
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextAnnotationData TAnnotation = new TextAnnotationData();
            TAnnotation.AnnotationLocation = new Point(80, 80);
            TAnnotation.AnnotationSize = new Size(200, 200);
            TAnnotation.TextFont = new Font("", 20);
            TAnnotation.TextContent = "Dynamsoft";
            TAnnotation.TextColor = Color.Brown;
            TAnnotation.Description = "Create a text annotation";
            this.dynamicDotNetTwain1.CreateAnnotation(this.dynamicDotNetTwain1.CurrentImageIndexInBuffer, TAnnotation);
            
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AnnotationData> aryAnnotation = new List<AnnotationData>();
            dynamicDotNetTwain1.GetAllAnnotationDataList(dynamicDotNetTwain1.CurrentImageIndexInBuffer, out aryAnnotation);
            dynamicDotNetTwain1.DeleteAnnotations(dynamicDotNetTwain1.CurrentImageIndexInBuffer, aryAnnotation);
            UpdateAnnotationProperty();
        }

        private void copySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain1.GetSelectedAnnotationList(dynamicDotNetTwain1.CurrentImageIndexInBuffer, out aryAnnotation);
            
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain1.LoadAnnotationDataList(dynamicDotNetTwain1.CurrentImageIndexInBuffer, aryAnnotation);
        }

       
        private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AnnotationData> aryAnnotation = new List<AnnotationData>();
            AnnotationData objAnnotation = new AnnotationData();
            dynamicDotNetTwain1.GetSelectedAnnotationList(dynamicDotNetTwain1.CurrentImageIndexInBuffer, out aryAnnotation);
            if (aryAnnotation.Count > 0)
            {
                objAnnotation = aryAnnotation[0];
                dynamicDotNetTwain1.ChangeAnnotationPosition(dynamicDotNetTwain1.CurrentImageIndexInBuffer, objAnnotation, DWTAnnotationChangePosition.enumToFront);
            }

        }

        private void sendToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AnnotationData> aryAnnotation = new List<AnnotationData>();
            AnnotationData objAnnotation = new AnnotationData();
            dynamicDotNetTwain1.GetSelectedAnnotationList(dynamicDotNetTwain1.CurrentImageIndexInBuffer, out aryAnnotation);
            if (aryAnnotation.Count > 0)
            {
                objAnnotation = aryAnnotation[0];
                dynamicDotNetTwain1.ChangeAnnotationPosition(dynamicDotNetTwain1.CurrentImageIndexInBuffer, objAnnotation, DWTAnnotationChangePosition.enumMoveToBack);
            }

        }

        private void toolStripBtnLannotation_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain1.AnnotationPen = new Pen(toolStripBtnPen.BackColor, int.Parse(toolStripCbxPen.Text));
            dynamicDotNetTwain1.AnnotationType = DWTAnnotationType.enumLine;

        }

        private void toolStripBtnEannotation_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain1.AnnotationPen = new Pen(toolStripBtnPen.BackColor, int.Parse(toolStripCbxPen.Text));
            dynamicDotNetTwain1.AnnotationFillColor = toolStripBtnFill.BackColor; 
            dynamicDotNetTwain1.AnnotationType = DWTAnnotationType.enumEllipse;
        }

        private void toolStripBtnRannotation_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain1.AnnotationPen = new Pen(toolStripBtnPen.BackColor, int.Parse(toolStripCbxPen.Text));
            dynamicDotNetTwain1.AnnotationFillColor = toolStripBtnFill.BackColor;
            dynamicDotNetTwain1.AnnotationType = DWTAnnotationType.enumRectangle;
        }

        private void toolStripBtnTannotation_Click(object sender, EventArgs e)
        {
            dynamicDotNetTwain1.AnnotationTextColor = toolStripBtnFont.BackColor; 
            dynamicDotNetTwain1.AnnotationTextFont = new Font("", float.Parse(toolStripCbxFont.Text));   //new Font("", 20);
            dynamicDotNetTwain1.AnnotationType = DWTAnnotationType.enumText;
           
        }

        private void UpdateAnnotationProperty()
        {
            List<AnnotationData> aryAnnotation = new List<AnnotationData>();
            AnnotationData objAnnotation = new AnnotationData();
            dynamicDotNetTwain1.GetSelectedAnnotationList(this.dynamicDotNetTwain1.CurrentImageIndexInBuffer, out aryAnnotation);
            if (aryAnnotation.Count > 0)
            {
                objAnnotation = aryAnnotation[0];
                this.propertyGrid1.SelectedObject = objAnnotation;
            }
            else
                this.propertyGrid1.SelectedObject = null;

        }

        private void dynamicDotNetTwain1_OnAnnotationCreated()
        {
            UpdateAnnotationProperty();
        }

        private void dynamicDotNetTwain1_OnAnnotationMoved()
        {
            UpdateAnnotationProperty();
        }

        private void dynamicDotNetTwain1_OnAnnotationSelected()
        {
            UpdateAnnotationProperty();
        }

        private void dynamicDotNetTwain1_OnAnnotationDeselected()
        {
            this.propertyGrid1.SelectedObject = null;
        }

        private void dynamicDotNetTwain1_OnAnnotationResized()
        {
            UpdateAnnotationProperty();
        }

        private void dynamicDotNetTwain1_OnAnnotationTextChanged()
        {
            UpdateAnnotationProperty();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            List<AnnotationData> aryAnnotation = new List<AnnotationData>();
            AnnotationData oldAnnotation = new AnnotationData();
            AnnotationData newAnnotation = new AnnotationData();
            short sImageIndex = dynamicDotNetTwain1.CurrentImageIndexInBuffer;
            dynamicDotNetTwain1.GetSelectedAnnotationList(sImageIndex, out aryAnnotation);
            if (aryAnnotation.Count > 0)
            {
                oldAnnotation = aryAnnotation[0];
                newAnnotation = (AnnotationData)this.propertyGrid1.SelectedObject;
                dynamicDotNetTwain1.UpdateAnnotation(sImageIndex, oldAnnotation, newAnnotation);
            }
        }

        private void dynamicDotNetTwain1_OnTopImageInTheViewChanged(short sImageIndex)
        {
            dynamicDotNetTwain1.CurrentImageIndexInBuffer = sImageIndex;
            UpdateAnnotationProperty();
        }

        private void toolStripBtnFill_Click(object sender, EventArgs e)
        {
            Color color = SelectColor();
            if (color != Color.Transparent)
            {
                toolStripBtnFill.BackColor = color;

                List<AnnotationData> aryAnnotation = new List<AnnotationData>();
                dynamicDotNetTwain1.GetSelectedAnnotationList(dynamicDotNetTwain1.CurrentImageIndexInBuffer, out aryAnnotation);
                foreach (AnnotationData annotation in aryAnnotation)
                {
                   DWTAnnotationType type = annotation.GetAnnotationType();
                   if (type == DWTAnnotationType.enumRectangle)
                   {
                       RectangleAnnotationData oldAnnotation = ((RectangleAnnotationData)annotation);
                       RectangleAnnotationData newAnnotation = new RectangleAnnotationData(oldAnnotation.AnnotationLocation, oldAnnotation.AnnotationSize,
                          color, oldAnnotation.PenColor, oldAnnotation.PenWidth, oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description,
                          oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected);
                       dynamicDotNetTwain1.UpdateAnnotation(dynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation);
                   }
                   else if (type == DWTAnnotationType.enumEllipse)
                   {
                      EllipseAnnotationData oldAnnotation = ((EllipseAnnotationData)annotation);
                       EllipseAnnotationData newAnnotation = new EllipseAnnotationData(oldAnnotation.AnnotationLocation, oldAnnotation.AnnotationSize,
                          color, oldAnnotation.PenColor, oldAnnotation.PenWidth, oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description,
                          oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected);
                       dynamicDotNetTwain1.UpdateAnnotation(dynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation);
                   }
                }
            }
        }

        private Color SelectColor()
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                return dlgColor.Color;
            }
            return Color.Transparent;
        }

        private void toolStripBtnPen_Click(object sender, EventArgs e)
        {
            Color color = SelectColor();
            if (color != Color.Transparent)
            {
                toolStripBtnPen.BackColor = color;

                List<AnnotationData> aryAnnotation = new List<AnnotationData>();
                dynamicDotNetTwain1.GetSelectedAnnotationList(dynamicDotNetTwain1.CurrentImageIndexInBuffer, out aryAnnotation);
                foreach (AnnotationData annotation in aryAnnotation)
                {
                    DWTAnnotationType type = annotation.GetAnnotationType();
                    if (type == DWTAnnotationType.enumRectangle)
                    {
                        RectangleAnnotationData oldAnnotation = ((RectangleAnnotationData)annotation);
                        RectangleAnnotationData newAnnotation = new RectangleAnnotationData(oldAnnotation.AnnotationLocation, oldAnnotation.AnnotationSize,
                           oldAnnotation.FillColor, color, oldAnnotation.PenWidth, oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description,
                           oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected);
                        dynamicDotNetTwain1.UpdateAnnotation(dynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation);
                    }
                    else if (type == DWTAnnotationType.enumEllipse)
                    {
                        EllipseAnnotationData oldAnnotation = ((EllipseAnnotationData)annotation);
                        EllipseAnnotationData newAnnotation = new EllipseAnnotationData(oldAnnotation.AnnotationLocation, oldAnnotation.AnnotationSize,
                           oldAnnotation.FillColor, color, oldAnnotation.PenWidth, oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description,
                           oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected);
                        dynamicDotNetTwain1.UpdateAnnotation(dynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation);
                    }
                    else if (type == DWTAnnotationType.enumLine)
                    {
                        LineAnnotationData oldAnnotation = ((LineAnnotationData)annotation);
                        LineAnnotationData newAnnotation = new LineAnnotationData(oldAnnotation.StartPoint, oldAnnotation.EndPoint,
                           color, oldAnnotation.PenWidth, oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description,
                           oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected);
                        dynamicDotNetTwain1.UpdateAnnotation(dynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation);
                    }
                }
            }
        }

        private void toolStripBtnFont_Click(object sender, EventArgs e)
        {
            Color color = SelectColor();
            if (color != Color.Transparent)
            {
                toolStripBtnFont.BackColor = color;

                List<AnnotationData> aryAnnotation = new List<AnnotationData>();
                dynamicDotNetTwain1.GetSelectedAnnotationList(dynamicDotNetTwain1.CurrentImageIndexInBuffer, out aryAnnotation);
                foreach (AnnotationData annotation in aryAnnotation)
                {
                    DWTAnnotationType type = annotation.GetAnnotationType();
                    if (type == DWTAnnotationType.enumText)
                    {
                        TextAnnotationData oldAnnotation = ((TextAnnotationData)annotation);
                        TextAnnotationData newAnnotation = new TextAnnotationData(oldAnnotation.AnnotationLocation, oldAnnotation.AnnotationSize,
                           oldAnnotation.TextFont, color, oldAnnotation.TextContent, oldAnnotation.TextRotate, oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description,
                           oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected);
                        dynamicDotNetTwain1.UpdateAnnotation(dynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation);
                    }
                }
            }
        }

        private void toolStripCbxPen_TextChanged(object sender, EventArgs e)
        {
            List<AnnotationData> aryAnnotation = new List<AnnotationData>();
            dynamicDotNetTwain1.GetSelectedAnnotationList(dynamicDotNetTwain1.CurrentImageIndexInBuffer, out aryAnnotation);
            foreach (AnnotationData annotation in aryAnnotation)
            {
                DWTAnnotationType type = annotation.GetAnnotationType();
                if (type == DWTAnnotationType.enumRectangle)
                {
                    RectangleAnnotationData oldAnnotation = ((RectangleAnnotationData)annotation);
                    RectangleAnnotationData newAnnotation = new RectangleAnnotationData(oldAnnotation.AnnotationLocation, oldAnnotation.AnnotationSize,
                       oldAnnotation.FillColor, oldAnnotation.PenColor, int.Parse(toolStripCbxPen.Text), oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description,
                       oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected);
                    dynamicDotNetTwain1.UpdateAnnotation(dynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation);
                }
                else if (type == DWTAnnotationType.enumEllipse)
                {
                    EllipseAnnotationData oldAnnotation = ((EllipseAnnotationData)annotation);
                    EllipseAnnotationData newAnnotation = new EllipseAnnotationData(oldAnnotation.AnnotationLocation, oldAnnotation.AnnotationSize,
                       oldAnnotation.FillColor, oldAnnotation.PenColor, int.Parse(toolStripCbxPen.Text), oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description,
                       oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected);
                    dynamicDotNetTwain1.UpdateAnnotation(dynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation);
                }
                else if (type == DWTAnnotationType.enumLine)
                {
                    LineAnnotationData oldAnnotation = ((LineAnnotationData)annotation);
                    LineAnnotationData newAnnotation = new LineAnnotationData(oldAnnotation.StartPoint, oldAnnotation.EndPoint,
                       oldAnnotation.PenColor, int.Parse(toolStripCbxPen.Text), oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description,
                       oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected);
                    dynamicDotNetTwain1.UpdateAnnotation(dynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation);
                }
            }
        }

        private void toolStripCbxFont_TextChanged(object sender, EventArgs e)
        {
            List<AnnotationData> aryAnnotation = new List<AnnotationData>();
            dynamicDotNetTwain1.GetSelectedAnnotationList(dynamicDotNetTwain1.CurrentImageIndexInBuffer, out aryAnnotation);
            foreach (AnnotationData annotation in aryAnnotation)
            {
                DWTAnnotationType type = annotation.GetAnnotationType();
                if (type == DWTAnnotationType.enumText)
                {
                    TextAnnotationData oldAnnotation = ((TextAnnotationData)annotation);
                    TextAnnotationData newAnnotation = new TextAnnotationData(oldAnnotation.AnnotationLocation, oldAnnotation.AnnotationSize,
                       new Font("", float.Parse(toolStripCbxFont.Text)), oldAnnotation.TextColor, oldAnnotation.TextContent, oldAnnotation.TextRotate, oldAnnotation.Name, oldAnnotation.UserName, oldAnnotation.Description,
                       oldAnnotation.CreationTime, oldAnnotation.ModifiedTime, oldAnnotation.Selected);
                    dynamicDotNetTwain1.UpdateAnnotation(dynamicDotNetTwain1.CurrentImageIndexInBuffer, oldAnnotation, newAnnotation);
                }
            }
        }

        private void toolStripBtnDelete_Click(object sender, EventArgs e)
        {
            delToolStripMenuItem_Click(null, null);
        }

        private void toolStripBtnDeleteAll_Click(object sender, EventArgs e)
        {
            deleteAllToolStripMenuItem_Click(null, null);
        }

        private void toolStripBtnBringToBack_Click(object sender, EventArgs e)
        {
            sendToBackToolStripMenuItem_Click(null, null);
        }

        private void toolStripBtnBringToFront_Click(object sender, EventArgs e)
        {
            bringToFrontToolStripMenuItem_Click(null, null);
        }

        private void toolStripCbxPen_KeyPress(object sender, KeyPressEventArgs e)
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(e.KeyChar.ToString());
            if (!char.IsDigit(e.KeyChar) || array.LongLength == 2) e.Handled = true;
            if (e.KeyChar == '\b') e.Handled = false;
        }

        private void toolStripCbxFont_KeyPress(object sender, KeyPressEventArgs e)
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(e.KeyChar.ToString());
            if (!char.IsDigit(e.KeyChar) || array.LongLength == 2) e.Handled = true;
            if (e.KeyChar == '\b' || (!toolStripCbxFont.Text.Contains(".") && e.KeyChar == '.')) e.Handled = false;
        }
        
    }
}
