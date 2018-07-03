using Dynamsoft.Core;
using Dynamsoft.Core.Annotation;
using Dynamsoft.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.PDF;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;

namespace Annotation_Samples
{
    public partial class Form1 : Form,IConvertCallback,ISave
    {
        private ImageCore m_ImageCore = null;
        private PDFRasterizer m_Rasterizer = null;
        private PDFCreator m_Creator = null;

        private string m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU=";
        private List<AnnotationData> m_SeletedAnnotation = new List<AnnotationData>();
        public Form1()
        {
            InitializeComponent();
            m_ImageCore = new ImageCore();
            dsViewer1.Bind(m_ImageCore);
            m_Rasterizer = new PDFRasterizer(m_StrProductKey);
            m_Creator = new PDFCreator(m_StrProductKey);
            toolStripCbxPen.SelectedIndex = 0;
            toolStripCbxFont.SelectedIndex = 0;

            dsViewer1.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumPointer;
            dsViewer1.SetViewMode(1,1);

            string imagePath = Application.ExecutablePath;
            imagePath = imagePath.Replace("/", "\\");
            string strDllFolder = imagePath;
            int pos = imagePath.LastIndexOf("\\Samples\\");
            if (pos != -1)
            {
                imagePath = imagePath.Substring(0, imagePath.IndexOf(@"\", pos)) + @"\Samples\Bin\Images\AnnotationImage\Annotation Sample Image.png";
            }
            else
            {
                imagePath = Application.StartupPath + @"\Bin\Images\AnnotationImage\Annotation Sample Image.png";
            }
            m_ImageCore.IO.LoadImage(imagePath);

            dsViewer1.Annotation.OnAnnotationTextChanged += Annotation_OnAnnotationTextChanged;
            dsViewer1.Annotation.OnAnnotationSelected += Annotation_OnAnnotationSelected;
            dsViewer1.Annotation.OnAnnotationDeselected += Annotation_OnAnnotationDeselected;
        }

        private void UpdateSelectedAnnotation()
        {
            List<AnnotationData> tempAllAnnotation = (List<AnnotationData>)m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation);
            if(m_SeletedAnnotation!=null&&m_SeletedAnnotation.Count>0)
            {
                m_SeletedAnnotation.Clear();
            }

            foreach (AnnotationData temp in tempAllAnnotation)
            {
                if (temp.Selected == true)
                {
                    if (m_SeletedAnnotation == null)
                        m_SeletedAnnotation = new List<AnnotationData>();
                    m_SeletedAnnotation.Add(temp);
                }
            }
            if (m_SeletedAnnotation != null)
            {
                if (m_SeletedAnnotation.Count > 0)
                {
                    propertyGrid1.SelectedObject = m_SeletedAnnotation[0];
                }
            }
        }

        void Annotation_OnAnnotationDeselected(List<Guid> annotationGuids)
        {
            UpdateSelectedAnnotation();
            if(m_SeletedAnnotation!=null)
                if (m_SeletedAnnotation.Count == 0)
                    propertyGrid1.SelectedObject = null;
        }

        void Annotation_OnAnnotationSelected(List<Guid> annotationGuids)
        {
            UpdateSelectedAnnotation();

        }

        void Annotation_OnAnnotationTextChanged(Guid annotationGuids)
        {
            UpdateSelectedAnnotation();
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteAnnotation(m_SeletedAnnotation);
            m_SeletedAnnotation = null;
        }

        private void DeleteAnnotation(List<AnnotationData> listAnnotation)
        {
            if (listAnnotation != null)
            {
                if (listAnnotation.Count > 0)
                {
                    List<AnnotationData> tempAllAnnotation = new List<AnnotationData>();
                    tempAllAnnotation = (List<AnnotationData>)m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation);

                    foreach (AnnotationData temp1 in listAnnotation)
                    {
                        for (short sIndex = 0; sIndex < tempAllAnnotation.Count; sIndex++)
                        {
                            if (temp1.GUID == tempAllAnnotation[sIndex].GUID)
                            {
                                tempAllAnnotation.RemoveAt(sIndex);
                            }
                        }
                    }
                    m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, true);
                }

                propertyGrid1.SelectedObject = null;
            }


        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedlg = new OpenFileDialog();
            filedlg.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF;*.GIF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF|GIF|*.GIF";
            filedlg.Multiselect = true;
            if (filedlg.ShowDialog() == DialogResult.OK)
            {
                foreach (string strfilename in filedlg.FileNames)
                {
                    int pos = strfilename.LastIndexOf(".");
                    if (pos != -1)
                    {
                        string strSuffix = strfilename.Substring(pos, strfilename.Length - pos).ToLower();
                        if (strSuffix.CompareTo(".pdf") == 0)
                        {
                            m_Rasterizer.ConvertMode = Dynamsoft.PDF.Enums.EnumConvertMode.enumCM_RENDERALL;
                            m_Rasterizer.ConvertToImage(strfilename,"",200,this as IConvertCallback);
                            continue;
                        }
                    }
                    m_ImageCore.IO.LoadImage(strfilename);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0)
            {
                SaveFileDialog filedlg = new SaveFileDialog();
                filedlg.Filter = "PDF File(*.pdf)| *.pdf";
                if (filedlg.ShowDialog() == DialogResult.OK)
                {
                    m_Creator.Save(this as ISave,filedlg.FileName);
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dsViewer1.IfPrintAnnotations = true;
            PrinterSettings temp = new PrinterSettings();
            temp.DefaultPageSettings.Margins = new Margins(0,0,0,0);
            this.dsViewer1.Print();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationData tempLineAnnotation = new AnnotationData();
            tempLineAnnotation.AnnotationType = AnnotationType.enumLine;
            tempLineAnnotation.StartPoint = new Point(200, 200);
            tempLineAnnotation.EndPoint = new Point(260, 280);
            tempLineAnnotation.PenColor = Color.Black.ToArgb();
            tempLineAnnotation.PenWidth = 5;
            tempLineAnnotation.Description = "Create a line annotation.";
            tempLineAnnotation.Selected = false;
            tempLineAnnotation.GUID = Guid.NewGuid();
            AddAnnotation(tempLineAnnotation);
        }

        private void AddAnnotation(AnnotationData anno)
        {
            List<AnnotationData> tempAllAnnotation = (List<AnnotationData>)m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation);
            tempAllAnnotation.Add(anno);
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer,EnumMetaDataType.enumAnnotation,tempAllAnnotation,true);
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationData tempEllipseAnnotation = new AnnotationData();
            tempEllipseAnnotation.AnnotationType = AnnotationType.enumEllipse;
            tempEllipseAnnotation.StartPoint= new Point(300, 300);
            tempEllipseAnnotation.EndPoint = new Point(380,440);
            tempEllipseAnnotation.FillColor = Color.Blue.ToArgb();
            tempEllipseAnnotation.PenColor = Color.Black.ToArgb();
            tempEllipseAnnotation.PenWidth = 2;
            tempEllipseAnnotation.Description = "Create an ellipse annotation.";
            tempEllipseAnnotation.Selected = false;
            tempEllipseAnnotation.GUID = Guid.NewGuid();
            AddAnnotation(tempEllipseAnnotation);
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationData tempRectAnnotation = new AnnotationData();
            tempRectAnnotation.AnnotationType = AnnotationType.enumRectangle;
            tempRectAnnotation.StartPoint = new Point(400, 400);
            tempRectAnnotation.EndPoint= new Point(490, 520);
            tempRectAnnotation.FillColor = Color.Green.ToArgb();
            tempRectAnnotation.PenColor = Color.Black.ToArgb();
            tempRectAnnotation.PenWidth = 2;
            tempRectAnnotation.Description = "Create a rectangle annotation.";
            tempRectAnnotation.Selected = false;
            tempRectAnnotation.GUID = Guid.NewGuid();
            AddAnnotation(tempRectAnnotation);

        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationData tempTextAnnotation = new AnnotationData();
            tempTextAnnotation.AnnotationType = AnnotationType.enumText;
            tempTextAnnotation.GUID = Guid.NewGuid();
            tempTextAnnotation.StartPoint= new Point(80, 80);
            tempTextAnnotation.EndPoint = new Point(280, 280);
            tempTextAnnotation.FontType = new AnnoTextFont();
            tempTextAnnotation.FontType.Name = "Microsoft Sans Serif";
            tempTextAnnotation.FontType.Size = 30;
            tempTextAnnotation.FontType.TextColor = Color.Black.ToArgb();
            tempTextAnnotation.TextContent = "Dynamsoft";
            tempTextAnnotation.Description = "Create a text annotation";
            tempTextAnnotation.Selected = false;
            tempTextAnnotation.GUID = Guid.NewGuid();
            AddAnnotation(tempTextAnnotation);

        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AnnotationData> temp = new List<AnnotationData>();
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, temp, true);
            propertyGrid1.SelectedObject = null;
        }


        private List<AnnotationData> m_CopyAnnotation = new List<AnnotationData>();
        private void copySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_SeletedAnnotation != null)
            {
                if (m_CopyAnnotation != null)
                    m_CopyAnnotation.Clear();
                foreach (AnnotationData tempAnnotation in m_SeletedAnnotation)
                {
                    AnnotationData tempCopyAnnotation = new AnnotationData();
                    tempCopyAnnotation.GUID = Guid.NewGuid();
                    tempCopyAnnotation.AnnotationType = tempAnnotation.AnnotationType;
                    tempCopyAnnotation.StartPoint = tempAnnotation.StartPoint;
                    tempCopyAnnotation.EndPoint = tempAnnotation.EndPoint;
                    tempCopyAnnotation.FillColor = tempAnnotation.FillColor;
                    tempCopyAnnotation.Description = tempAnnotation.Description;
                    if (tempAnnotation.FontType != null)
                    {
                        tempCopyAnnotation.FontType = new AnnoTextFont();
                        tempCopyAnnotation.FontType.Name = tempAnnotation.FontType.Name;
                        tempCopyAnnotation.FontType.Size = tempAnnotation.FontType.Size;
                        tempCopyAnnotation.FontType.TextColor = tempAnnotation.FontType.TextColor;
                    }

                    tempCopyAnnotation.Name = tempAnnotation.Name;
                    tempCopyAnnotation.PenColor = tempAnnotation.PenColor;
                    tempCopyAnnotation.PenWidth = tempAnnotation.PenWidth;
                    tempCopyAnnotation.Selected = false;
                    tempCopyAnnotation.TextContent = tempAnnotation.TextContent;
                    tempCopyAnnotation.TextRotateType = tempAnnotation.TextRotateType;

                    m_CopyAnnotation.Add(tempCopyAnnotation);
                }
            }


        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_CopyAnnotation != null)
            {
                List<AnnotationData> tempAllAnnotation = (List<AnnotationData>)m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation);

                if (m_CopyAnnotation.Count > 0)
                {
                    foreach (AnnotationData temp in m_CopyAnnotation)
                    {
                        AnnotationData tempCopyAnnotation = new AnnotationData();
                        tempCopyAnnotation.GUID = Guid.NewGuid();
                        tempCopyAnnotation.AnnotationType = temp.AnnotationType;
                        tempCopyAnnotation.StartPoint = temp.StartPoint;
                        tempCopyAnnotation.EndPoint = temp.EndPoint;
                        tempCopyAnnotation.FillColor = temp.FillColor;
                        tempCopyAnnotation.Description = temp.Description;
                        if (temp.FontType != null)
                        {
                            tempCopyAnnotation.FontType = new AnnoTextFont();
                            tempCopyAnnotation.FontType.Name = temp.FontType.Name;
                            tempCopyAnnotation.FontType.Size = temp.FontType.Size;
                            tempCopyAnnotation.FontType.TextColor = temp.FontType.TextColor;
                        }

                        tempCopyAnnotation.Name = temp.Name;
                        tempCopyAnnotation.PenColor = temp.PenColor;
                        tempCopyAnnotation.PenWidth = temp.PenWidth;
                        tempCopyAnnotation.Selected = false;
                        tempCopyAnnotation.TextContent = temp.TextContent;
                        tempCopyAnnotation.TextRotateType = temp.TextRotateType;
                        tempAllAnnotation.Add(tempCopyAnnotation);
                    }
                }
                m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, true);
            }
        }


        private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AnnotationData> tempAllAnnotation = (List<AnnotationData>)m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation);
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, true);
            if (tempAllAnnotation.Count >= 2)
            {
                if (m_SeletedAnnotation.Count == 1)
                {
                    for (short sIndex = 0; sIndex < tempAllAnnotation.Count; sIndex++)
                    {
                        AnnotationData tempAnnotation = tempAllAnnotation[sIndex];
                        if (tempAllAnnotation[sIndex].GUID == m_SeletedAnnotation[0].GUID)
                        {
                            {
                                tempAllAnnotation.RemoveAt(sIndex);
                                tempAllAnnotation.Add(tempAnnotation);
                            }
                            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, true);
                        }
                    }
                }
            }

        }

        private void sendToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AnnotationData> tempAllAnnotation = (List<AnnotationData>)m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation);
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, true);
            if (tempAllAnnotation.Count >= 2)
            {
                if (m_SeletedAnnotation.Count == 1)
                {
                    for (short sIndex = 0; sIndex < tempAllAnnotation.Count; sIndex++)
                    {
                        AnnotationData tempAnnotation = tempAllAnnotation[sIndex];
                        if (tempAllAnnotation[sIndex].GUID == m_SeletedAnnotation[0].GUID)
                        {
                            {
                                tempAllAnnotation.RemoveAt(sIndex);
                                tempAllAnnotation.Insert(0,tempAnnotation);
                            }
                            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, true);
                        }
                    }
                }
            }

        }

        private void toolStripBtnLannotation_Click(object sender, EventArgs e)
        {
            dsViewer1.Annotation.Pen = new Pen(toolStripBtnPen.BackColor, int.Parse(toolStripCbxPen.Text));
            dsViewer1.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumLine;

        }

        private void toolStripBtnEannotation_Click(object sender, EventArgs e)
        {
            dsViewer1.Annotation.Pen = new Pen(toolStripBtnPen.BackColor, int.Parse(toolStripCbxPen.Text));
            dsViewer1.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumEllipse;
            dsViewer1.Annotation.FillColor = toolStripBtnFill.BackColor;
        }

        private void toolStripBtnRannotation_Click(object sender, EventArgs e)
        {

            dsViewer1.Annotation.Pen = new Pen(toolStripBtnPen.BackColor, int.Parse(toolStripCbxPen.Text));
            dsViewer1.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumRectangle;
            dsViewer1.Annotation.FillColor = toolStripBtnFill.BackColor;
        }

        private void toolStripBtnTannotation_Click(object sender, EventArgs e)
        {
            dsViewer1.Annotation.Pen = new Pen(toolStripBtnPen.BackColor, int.Parse(toolStripCbxPen.Text));
            dsViewer1.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumText;
            dsViewer1.Annotation.TextColor = toolStripBtnFont.BackColor;
            dsViewer1.Annotation.TextFont = new Font("", int.Parse(toolStripCbxFont.Text));
        }



        private void toolStripBtnFill_Click(object sender, EventArgs e)
        {
            Color color = SelectColor();
            if (color != Color.Transparent)
            {
                toolStripBtnFill.BackColor = color;

                List<AnnotationData> tempAllAnnotation = (List<AnnotationData>)m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation);
                if (m_SeletedAnnotation == null)
                    return;
                foreach (AnnotationData annotation in m_SeletedAnnotation)
                {
                    AnnotationType type = annotation.AnnotationType;
                    if (type == AnnotationType.enumRectangle||type ==AnnotationType.enumEllipse)
                    {
                        foreach(AnnotationData temp in tempAllAnnotation)
                        {
                            if (annotation.GUID == temp.GUID)
                                annotation.FillColor = color.ToArgb();
                        }
                    }
                }
                m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer,EnumMetaDataType.enumAnnotation,tempAllAnnotation,true);
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

                List<AnnotationData> tempAllAnnotation = (List<AnnotationData>)m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation);
                if (m_SeletedAnnotation == null)
                    return;
                foreach (AnnotationData annotation in m_SeletedAnnotation)
                {
                    AnnotationType type = annotation.AnnotationType;
                    if (type == AnnotationType.enumRectangle || type == AnnotationType.enumEllipse || type == AnnotationType.enumLine)
                    {
                        foreach (AnnotationData temp in tempAllAnnotation)
                        {
                            if (annotation.GUID == temp.GUID)
                                annotation.PenColor = color.ToArgb();
                        }
                    }
                }
                m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, true);
            }
        }

        private void toolStripBtnFont_Click(object sender, EventArgs e)
        {
            Color color = SelectColor();
            if (color != Color.Transparent)
            {
                toolStripBtnFont.BackColor = color;

                List<AnnotationData> tempAllAnnotation = (List<AnnotationData>)m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation);
                if (m_SeletedAnnotation == null)
                    return;

                foreach (AnnotationData annotation in m_SeletedAnnotation)
                {
                    AnnotationType type = annotation.AnnotationType;
                    if (type == AnnotationType.enumText)
                    {
                        foreach (AnnotationData temp in tempAllAnnotation)
                        {
                            if (annotation.GUID == temp.GUID)
                                annotation.FontType.TextColor = color.ToArgb(); 
                        }
                    }
                }
                m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, true);
            }
        }

        private void toolStripCbxPen_TextChanged(object sender, EventArgs e)
        {

            List<AnnotationData> tempAllAnnotation = (List<AnnotationData>)m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation);

            foreach (AnnotationData annotation in m_SeletedAnnotation)
            {
                AnnotationType type = annotation.AnnotationType;
                {
                    foreach (AnnotationData temp in tempAllAnnotation)
                    {
                        if (annotation.GUID == temp.GUID)
                            annotation.PenWidth = int.Parse(toolStripCbxPen.Text);
                    }
                }
            }
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, true);
        }

        private void toolStripCbxFont_TextChanged(object sender, EventArgs e)
        {
            if (m_ImageCore != null && m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer != -1)
            {
                List<AnnotationData> tempAllAnnotation = (List<AnnotationData>)m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation);

                foreach (AnnotationData annotation in m_SeletedAnnotation)
                {
                    AnnotationType type = annotation.AnnotationType;
                    if (type == AnnotationType.enumText)
                    {

                        for (short sIndex = 0; sIndex < tempAllAnnotation.Count; sIndex++)
                        {

                            if(tempAllAnnotation[sIndex].GUID == annotation.GUID)
                            {
                                AnnotationData temp = tempAllAnnotation[sIndex];
                                AnnotationData annoNew = new AnnotationData();
                                AnnotationData tempCopyAnnotation = new AnnotationData();
                                annoNew.GUID = Guid.NewGuid();
                                annoNew.AnnotationType = temp.AnnotationType;
                                Point startPoint = temp.StartPoint;
                                Point endPoint = temp.EndPoint;

                                if (startPoint.X > endPoint.X)
                                {
                                    int x = startPoint.X;
                                    startPoint.X = endPoint.X;
                                    endPoint.X = x;
                                }

                                if (startPoint.Y > endPoint.Y)
                                {
                                    int y = startPoint.Y;
                                    startPoint.Y = endPoint.Y;
                                    endPoint.Y = y;
                                }
                                annoNew.StartPoint = startPoint;
                                annoNew.EndPoint = endPoint;
                                annoNew.FillColor = temp.FillColor;
                                annoNew.Description = temp.Description;
                                if (temp.FontType != null)
                                {
                                    annoNew.FontType = new AnnoTextFont();
                                    annoNew.FontType.Name = temp.FontType.Name;
                                    annoNew.FontType.Size = int.Parse(toolStripCbxFont.Text);
                                    annoNew.FontType.TextColor = temp.FontType.TextColor;
                                }

                                annoNew.Name = temp.Name;
                                annoNew.PenColor = temp.PenColor;
                                annoNew.PenWidth = temp.PenWidth;
                                annoNew.Selected = temp.Selected;
                                annoNew.TextContent = temp.TextContent;
                                annoNew.TextRotateType = temp.TextRotateType;
                                tempAllAnnotation.RemoveAt(sIndex);
                                tempAllAnnotation.Insert(sIndex, annoNew);
                            }


                        }
                    }
                }

                m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, true);
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

        private bool bIfSaveAll = false;
        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0)
            {
                SaveFileDialog filedlg = new SaveFileDialog();
                filedlg.Filter = "PDF File(*.pdf)| *.pdf";
                if (filedlg.ShowDialog() == DialogResult.OK)
                {
                    bIfSaveAll = true;
                    m_Creator.Save(this as ISave,filedlg.FileName);
                    bIfSaveAll = false;
                }
            }
        }

        public object GetAnnotations(int iPageNumber)
        {
            if (!bIfSaveAll)
            {
                return m_ImageCore.ImageBuffer.GetMetaData(dsViewer1.CurrentSelectedImageIndicesInBuffer[iPageNumber], EnumMetaDataType.enumAnnotation);
            }
            else
            {
                return m_ImageCore.ImageBuffer.GetMetaData((short)iPageNumber,EnumMetaDataType.enumAnnotation);
            }

        }

        public Bitmap GetImage(int iPageNumber)
        {
            if (!bIfSaveAll)
            {
                return m_ImageCore.ImageBuffer.GetBitmap(dsViewer1.CurrentSelectedImageIndicesInBuffer[iPageNumber]);
            }
            else
            {
                return m_ImageCore.ImageBuffer.GetBitmap((short)iPageNumber);
            }

        }

        public int GetPageCount()
        {
            if (!bIfSaveAll)
            {
                return dsViewer1.CurrentSelectedImageIndicesInBuffer.Count;
            }
            else
            {
                return m_ImageCore.ImageBuffer.HowManyImagesInBuffer;
            }

        }

        public void LoadConvertResult(ConvertResult result)
        {
            m_ImageCore.IO.LoadImage(result.Image);
            if(result.Annotations!=null)
                m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer,EnumMetaDataType.enumAnnotation,result.Annotations,true);
        }





 
    }
}
