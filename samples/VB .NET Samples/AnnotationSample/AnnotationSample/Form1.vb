Imports Dynamsoft.Core
Imports Dynamsoft.Core.Annotation
Imports Dynamsoft.Core.Enums
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Dynamsoft.PDF
Imports System.Drawing.Printing
Imports System.IO
Imports System.Runtime.InteropServices

Partial Public Class Form1
    Inherits Form
    Implements IConvertCallback
    Implements ISave
    Private m_ImageCore As ImageCore = Nothing
    Private m_Rasterizer As PDFRasterizer = Nothing
    Private m_Creator As PDFCreator = Nothing

    Private m_StrProductKey As String

    Private m_SeletedAnnotation As New List(Of AnnotationData)()
    Public Sub New()
        InitializeComponent()
        m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU="
        m_ImageCore = New ImageCore()
        dsViewer1.Bind(m_ImageCore)
        m_Rasterizer = New PDFRasterizer(m_StrProductKey)
        m_Creator = New PDFCreator(m_StrProductKey)
        toolStripCbxPen.SelectedIndex = 0
        toolStripCbxFont.SelectedIndex = 0

        dsViewer1.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumPointer
        dsViewer1.SetViewMode(1, 1)

        Dim imagePath As String = Application.ExecutablePath
        imagePath = imagePath.Replace("/", "\")
        Dim strDllFolder As String = imagePath
        Dim pos As Integer = imagePath.LastIndexOf("\Samples\")
        If pos <> -1 Then
            imagePath = imagePath.Substring(0, imagePath.IndexOf("\", pos)) & "\Samples\Bin\Images\AnnotationImage\Annotation Sample Image.png"
        Else
            imagePath = Application.StartupPath & "\Samples\Bin\Images\AnnotationImage\Annotation Sample Image.png"
        End If
        m_ImageCore.IO.LoadImage(imagePath)



        AddHandler dsViewer1.Annotation.OnAnnotationTextChanged, AddressOf Annotation_OnAnnotationTextChanged
        AddHandler dsViewer1.Annotation.OnAnnotationSelected, AddressOf Annotation_OnAnnotationSelected
        AddHandler dsViewer1.Annotation.OnAnnotationDeselected, AddressOf Annotation_OnAnnotationDeselected
    End Sub




    Private Sub UpdateSelectedAnnotation()
        Dim tempAllAnnotation As List(Of AnnotationData) = DirectCast(m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation), List(Of AnnotationData))
        If m_SeletedAnnotation IsNot Nothing AndAlso m_SeletedAnnotation.Count > 0 Then
            m_SeletedAnnotation.Clear()
        End If

        For Each temp As AnnotationData In tempAllAnnotation
            If temp.Selected = True Then
                If m_SeletedAnnotation Is Nothing Then
                    m_SeletedAnnotation = New List(Of AnnotationData)()
                End If
                m_SeletedAnnotation.Add(temp)
            End If
        Next
        If m_SeletedAnnotation IsNot Nothing Then
            If m_SeletedAnnotation.Count > 0 Then
                propertyGrid1.SelectedObject = m_SeletedAnnotation(0)
            End If
        End If
    End Sub

    Private Sub Annotation_OnAnnotationDeselected(annotationGuids As List(Of Guid))
        UpdateSelectedAnnotation()
        If m_SeletedAnnotation IsNot Nothing Then
            If m_SeletedAnnotation.Count = 0 Then
                propertyGrid1.SelectedObject = Nothing
            End If
        End If
    End Sub

    Private Sub Annotation_OnAnnotationSelected(annotationGuids As List(Of Guid))
        UpdateSelectedAnnotation()




    End Sub

    Private Sub Annotation_OnAnnotationTextChanged(annotationGuids As Guid)
        UpdateSelectedAnnotation()
    End Sub

    Private Sub delToolStripMenuItem_Click(sender As Object, e As EventArgs)
        DeleteAnnotation(m_SeletedAnnotation)
        m_SeletedAnnotation = Nothing
    End Sub

    Private Sub DeleteAnnotation(listAnnotation As List(Of AnnotationData))
        If listAnnotation IsNot Nothing Then
            If listAnnotation.Count > 0 Then
                Dim tempAllAnnotation As New List(Of AnnotationData)()
                tempAllAnnotation = DirectCast(m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation), List(Of AnnotationData))

                For Each temp1 As AnnotationData In listAnnotation
                    For sIndex As Short = 0 To tempAllAnnotation.Count - 1
                        If temp1.GUID = tempAllAnnotation(sIndex).GUID Then
                            tempAllAnnotation.RemoveAt(sIndex)
                        End If
                    Next
                Next
                m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, True)
            End If

            propertyGrid1.SelectedObject = Nothing
        End If


    End Sub

    Private Sub openToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles openToolStripMenuItem.Click
        Dim filedlg As New OpenFileDialog()
        filedlg.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF;*.GIF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF|GIF|*.GIF"
        filedlg.Multiselect = True
        If filedlg.ShowDialog() = DialogResult.OK Then
            For Each strfilename As String In filedlg.FileNames
                Dim pos As Integer = strfilename.LastIndexOf(".")
                If pos <> -1 Then
                    Dim strSuffix As String = strfilename.Substring(pos, strfilename.Length - pos).ToLower()
                    If strSuffix.CompareTo(".pdf") = 0 Then
                        m_Rasterizer.ConvertMode = Dynamsoft.PDF.Enums.EnumConvertMode.enumCM_RENDERALL
                        m_Rasterizer.ConvertToImage(strfilename, "", 200, TryCast(Me, IConvertCallback))
                        Continue For
                    End If
                End If
                m_ImageCore.IO.LoadImage(strfilename)
            Next
        End If
    End Sub

    Private Sub saveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles saveToolStripMenuItem.Click
        If m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0 Then
            Dim filedlg As New SaveFileDialog()
            filedlg.Filter = "PDF File(*.pdf)| *.pdf"
            If filedlg.ShowDialog() = DialogResult.OK Then
                m_Creator.Save(TryCast(Me, ISave), filedlg.FileName)
            End If
        End If
    End Sub

    Private Sub printToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles printToolStripMenuItem.Click
        dsViewer1.IfPrintAnnotations = True
        Dim temp As New PrinterSettings()
        temp.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
        Me.dsViewer1.Print()
    End Sub

    Private Sub closeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles closeToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub lineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles lineToolStripMenuItem.Click
        Dim tempLineAnnotation As New AnnotationData()
        tempLineAnnotation.AnnotationType = AnnotationType.enumLine
        tempLineAnnotation.StartPoint = New Point(200, 200)
        tempLineAnnotation.EndPoint = New Point(260, 280)
        tempLineAnnotation.PenColor = Color.Black.ToArgb()
        tempLineAnnotation.PenWidth = 5
        tempLineAnnotation.Description = "Create a line annotation."
        tempLineAnnotation.GUID = Guid.NewGuid()
        AddAnnotation(tempLineAnnotation)
    End Sub

    Private Sub AddAnnotation(anno As AnnotationData)
        Dim tempAllAnnotation As List(Of AnnotationData) = DirectCast(m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation), List(Of AnnotationData))
        tempAllAnnotation.Add(anno)
        m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, True)
    End Sub

    Private Sub ellipseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ellipseToolStripMenuItem.Click
        Dim tempEllipseAnnotation As New AnnotationData()
        tempEllipseAnnotation.AnnotationType = AnnotationType.enumEllipse
        tempEllipseAnnotation.StartPoint = New Point(300, 300)
        tempEllipseAnnotation.EndPoint = New Point(380, 440)
        tempEllipseAnnotation.FillColor = Color.Blue.ToArgb()
        tempEllipseAnnotation.PenColor = Color.Black.ToArgb()
        tempEllipseAnnotation.PenWidth = 2
        tempEllipseAnnotation.Description = "Create an ellipse annotation."
        tempEllipseAnnotation.GUID = Guid.NewGuid()
        AddAnnotation(tempEllipseAnnotation)
    End Sub

    Private Sub rectangleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles rectangleToolStripMenuItem.Click
        Dim tempRectAnnotation As New AnnotationData()
        tempRectAnnotation.AnnotationType = AnnotationType.enumRectangle
        tempRectAnnotation.StartPoint = New Point(400, 400)
        tempRectAnnotation.EndPoint = New Point(490, 520)
        tempRectAnnotation.FillColor = Color.Green.ToArgb()
        tempRectAnnotation.PenColor = Color.Black.ToArgb()
        tempRectAnnotation.PenWidth = 2
        tempRectAnnotation.Description = "Create a rectangle annotation."
        tempRectAnnotation.GUID = Guid.NewGuid()
        AddAnnotation(tempRectAnnotation)

    End Sub

    Private Sub textToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles textToolStripMenuItem.Click
        Dim tempTextAnnotation As New AnnotationData()
        tempTextAnnotation.AnnotationType = AnnotationType.enumText
        tempTextAnnotation.GUID = Guid.NewGuid()
        tempTextAnnotation.StartPoint = New Point(80, 80)
        tempTextAnnotation.EndPoint = New Point(280, 280)
        tempTextAnnotation.FontType = New AnnoTextFont()
        tempTextAnnotation.FontType.Name = "Microsoft Sans Serif"
        tempTextAnnotation.FontType.Size = 30
        tempTextAnnotation.FontType.TextColor = toolStripBtnFont.BackColor.ToArgb()
        tempTextAnnotation.TextContent = "Dynamsoft"
        tempTextAnnotation.Description = "Create a text annotation"
        tempTextAnnotation.GUID = Guid.NewGuid()
        AddAnnotation(tempTextAnnotation)

    End Sub

    Private Sub deleteAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles toolStripBtnDeleteAll.Click
        Dim temp As New List(Of AnnotationData)()
        m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, temp, True)
        propertyGrid1.SelectedObject = Nothing
    End Sub


    Private m_CopyAnnotation As New List(Of AnnotationData)()
    Private Sub copySelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles copySelectedToolStripMenuItem.Click
        If m_SeletedAnnotation IsNot Nothing Then
            If m_CopyAnnotation IsNot Nothing Then
                m_CopyAnnotation.Clear()
            End If
            For Each tempAnnotation As AnnotationData In m_SeletedAnnotation
                Dim tempCopyAnnotation As New AnnotationData()
                tempCopyAnnotation.GUID = Guid.NewGuid()
                tempCopyAnnotation.AnnotationType = tempAnnotation.AnnotationType
                tempCopyAnnotation.StartPoint = tempAnnotation.StartPoint
                tempCopyAnnotation.EndPoint = tempAnnotation.EndPoint
                tempCopyAnnotation.FillColor = tempAnnotation.FillColor
                tempCopyAnnotation.Description = tempAnnotation.Description
                If tempAnnotation.FontType IsNot Nothing Then
                    tempCopyAnnotation.FontType = New AnnoTextFont()
                    tempCopyAnnotation.FontType.Name = tempAnnotation.FontType.Name
                    tempCopyAnnotation.FontType.Size = tempAnnotation.FontType.Size
                    tempCopyAnnotation.FontType.TextColor = tempAnnotation.FontType.TextColor
                End If

                tempCopyAnnotation.Name = tempAnnotation.Name
                tempCopyAnnotation.PenColor = tempAnnotation.PenColor
                tempCopyAnnotation.PenWidth = tempAnnotation.PenWidth
                tempCopyAnnotation.Selected = False
                tempCopyAnnotation.TextContent = tempAnnotation.TextContent
                tempCopyAnnotation.TextRotateType = tempAnnotation.TextRotateType

                m_CopyAnnotation.Add(tempCopyAnnotation)
            Next
        End If


    End Sub

    Private Sub pasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles pasteToolStripMenuItem.Click
        If m_CopyAnnotation IsNot Nothing Then
            Dim tempAllAnnotation As List(Of AnnotationData) = DirectCast(m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation), List(Of AnnotationData))

            If m_CopyAnnotation.Count > 0 Then
                For Each temp As AnnotationData In m_CopyAnnotation
                    Dim tempCopyAnnotation As New AnnotationData()
                    tempCopyAnnotation.GUID = Guid.NewGuid()
                    tempCopyAnnotation.AnnotationType = temp.AnnotationType
                    tempCopyAnnotation.StartPoint = temp.StartPoint
                    tempCopyAnnotation.EndPoint = temp.EndPoint
                    tempCopyAnnotation.FillColor = temp.FillColor
                    tempCopyAnnotation.Description = temp.Description
                    If temp.FontType IsNot Nothing Then
                        tempCopyAnnotation.FontType = New AnnoTextFont()
                        tempCopyAnnotation.FontType.Name = temp.FontType.Name
                        tempCopyAnnotation.FontType.Size = temp.FontType.Size
                        tempCopyAnnotation.FontType.TextColor = temp.FontType.TextColor
                    End If

                    tempCopyAnnotation.Name = temp.Name
                    tempCopyAnnotation.PenColor = temp.PenColor
                    tempCopyAnnotation.PenWidth = temp.PenWidth
                    tempCopyAnnotation.Selected = False
                    tempCopyAnnotation.TextContent = temp.TextContent
                    tempCopyAnnotation.TextRotateType = temp.TextRotateType
                    tempAllAnnotation.Add(tempCopyAnnotation)
                Next
            End If
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, True)
        End If
    End Sub


    Private Sub bringToFrontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles toolStripBtnBringToFront.Click
        Dim tempAllAnnotation As List(Of AnnotationData) = DirectCast(m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation), List(Of AnnotationData))
        If tempAllAnnotation.Count >= 2 Then
            If m_SeletedAnnotation.Count = 1 Then
                For sIndex As Short = 0 To tempAllAnnotation.Count - 1
                    Dim tempAnnotation As AnnotationData = tempAllAnnotation(sIndex)
                    If tempAllAnnotation(sIndex).GUID = m_SeletedAnnotation(0).GUID Then
                            tempAllAnnotation.RemoveAt(sIndex)
                            tempAllAnnotation.Add(tempAnnotation)
                            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, True)
                    End If
                Next

            End If
        End If

    End Sub

    Private Sub sendToBackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles toolStripBtnBringToBack.Click
        Dim tempAllAnnotation As List(Of AnnotationData) = DirectCast(m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation), List(Of AnnotationData))
        If tempAllAnnotation.Count >= 2 Then
            If m_SeletedAnnotation.Count = 1 Then
                For sIndex As Short = 0 To tempAllAnnotation.Count - 1
                    Dim tempAnnotation As AnnotationData = tempAllAnnotation(sIndex)
                    If tempAllAnnotation(sIndex).GUID = m_SeletedAnnotation(0).GUID Then
                            tempAllAnnotation.RemoveAt(sIndex)
                            tempAllAnnotation.Insert(0, tempAnnotation)
                            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, True)

                    End If
                Next

            End If
        End If

    End Sub

    Private Sub toolStripBtnLannotation_Click(sender As Object, e As EventArgs) Handles toolStripBtnLannotation.Click
        dsViewer1.Annotation.Pen = New Pen(toolStripBtnPen.BackColor, Integer.Parse(toolStripCbxPen.Text))
        dsViewer1.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumLine

    End Sub

    Private Sub toolStripBtnEannotation_Click(sender As Object, e As EventArgs) Handles toolStripBtnEannotation.Click
        dsViewer1.Annotation.Pen = New Pen(toolStripBtnPen.BackColor, Integer.Parse(toolStripCbxPen.Text))
        dsViewer1.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumEllipse
        dsViewer1.Annotation.FillColor = toolStripBtnFill.BackColor
    End Sub

    Private Sub toolStripBtnRannotation_Click(sender As Object, e As EventArgs) Handles toolStripBtnRannotation.Click

        dsViewer1.Annotation.Pen = New Pen(toolStripBtnPen.BackColor, Integer.Parse(toolStripCbxPen.Text))
        dsViewer1.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumRectangle
        dsViewer1.Annotation.FillColor = toolStripBtnFill.BackColor
    End Sub

    Private Sub toolStripBtnTannotation_Click(sender As Object, e As EventArgs) Handles toolStripBtnTannotation.Click
        dsViewer1.Annotation.Pen = New Pen(toolStripBtnPen.BackColor, Integer.Parse(toolStripCbxPen.Text))
        dsViewer1.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumText
        dsViewer1.Annotation.TextColor = toolStripBtnFont.BackColor
        dsViewer1.Annotation.TextFont = New Font("", Integer.Parse(toolStripCbxFont.Text))
    End Sub


    Private Sub toolStripBtnFill_Click(sender As Object, e As EventArgs) Handles toolStripBtnFill.Click
        Dim color__1 As Color = SelectColor()
        If color__1 <> Color.Transparent Then
            toolStripBtnFill.BackColor = color__1

            Dim tempAllAnnotation As List(Of AnnotationData) = DirectCast(m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation), List(Of AnnotationData))
            If m_SeletedAnnotation Is Nothing Then
                Return
            End If
            For Each annotation As AnnotationData In m_SeletedAnnotation
                Dim type As AnnotationType = annotation.AnnotationType
                If type = AnnotationType.enumRectangle OrElse type = AnnotationType.enumEllipse Then
                    For Each temp As AnnotationData In tempAllAnnotation
                        If annotation.GUID = temp.GUID Then
                            annotation.FillColor = color__1.ToArgb()
                        End If
                    Next
                End If
            Next
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, True)
        End If
    End Sub

    Private Function SelectColor() As Color
        If dlgColor.ShowDialog() = DialogResult.OK Then
            Return dlgColor.Color
        End If
        Return Color.Transparent
    End Function

    Private Sub toolStripBtnPen_Click(sender As Object, e As EventArgs) Handles toolStripBtnPen.Click
        Dim color__1 As Color = SelectColor()
        If color__1 <> Color.Transparent Then
            toolStripBtnPen.BackColor = color__1

            Dim tempAllAnnotation As List(Of AnnotationData) = DirectCast(m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation), List(Of AnnotationData))
            If m_SeletedAnnotation Is Nothing Then
                Return
            End If
            For Each annotation As AnnotationData In m_SeletedAnnotation
                Dim type As AnnotationType = annotation.AnnotationType
                If type = AnnotationType.enumRectangle OrElse type = AnnotationType.enumEllipse OrElse type = AnnotationType.enumLine Then
                    For Each temp As AnnotationData In tempAllAnnotation
                        If annotation.GUID = temp.GUID Then
                            annotation.PenColor = color__1.ToArgb()
                        End If
                    Next
                End If
            Next
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, True)
        End If
    End Sub

    Private Sub toolStripBtnFont_Click(sender As Object, e As EventArgs) Handles toolStripBtnFont.Click
        Dim color__1 As Color = SelectColor()
        If color__1 <> Color.Transparent Then
            toolStripBtnFont.BackColor = color__1

            Dim tempAllAnnotation As List(Of AnnotationData) = DirectCast(m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation), List(Of AnnotationData))
            If m_SeletedAnnotation Is Nothing Then
                Return
            End If

            For Each annotation As AnnotationData In m_SeletedAnnotation
                Dim type As AnnotationType = annotation.AnnotationType
                If type = AnnotationType.enumText Then
                    For Each temp As AnnotationData In tempAllAnnotation
                        If annotation.GUID = temp.GUID Then
                            annotation.FontType.TextColor = color__1.ToArgb()
                        End If
                    Next
                End If
            Next
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, True)
        End If
    End Sub

    Private Sub toolStripCbxPen_TextChanged(sender As Object, e As EventArgs)

        Dim tempAllAnnotation As List(Of AnnotationData) = DirectCast(m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation), List(Of AnnotationData))

        For Each annotation As AnnotationData In m_SeletedAnnotation
            Dim type As AnnotationType = annotation.AnnotationType
            If True Then
                For Each temp As AnnotationData In tempAllAnnotation
                    If annotation.GUID = temp.GUID Then
                        annotation.PenWidth = Integer.Parse(toolStripCbxPen.Text)
                    End If
                Next
            End If
        Next
        m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, True)
    End Sub

    Private Sub toolStripCbxFont_TextChanged(sender As Object, e As EventArgs) Handles toolStripCbxFont.TextChanged

        If m_ImageCore IsNot Nothing AndAlso m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer <> -1 Then
            Dim tempAllAnnotation As List(Of AnnotationData) = DirectCast(m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation), List(Of AnnotationData))

            For Each annotation As AnnotationData In m_SeletedAnnotation
                Dim type As AnnotationType = annotation.AnnotationType
                If type = AnnotationType.enumText Then

                    For sIndex As Short = 0 To tempAllAnnotation.Count - 1
                        If tempAllAnnotation(sIndex).GUID = annotation.GUID Then
                            Dim temp As AnnotationData = tempAllAnnotation(sIndex)
                            Dim annoNew As New AnnotationData()
                            Dim tempCopyAnnotation As New AnnotationData()
                            annoNew.GUID = Guid.NewGuid()
                            annoNew.AnnotationType = temp.AnnotationType
                            Dim startPoint As Point = temp.StartPoint
                            Dim endPoint As Point = temp.EndPoint

                            If startPoint.X > endPoint.X Then
                                Dim x As Integer = startPoint.X
                                startPoint.X = endPoint.X
                                endPoint.X = x
                            End If

                            If startPoint.Y > endPoint.Y Then
                                Dim y As Integer = startPoint.Y
                                startPoint.Y = endPoint.Y
                                endPoint.Y = y
                            End If
                            annoNew.StartPoint = startPoint
                            annoNew.EndPoint = endPoint
                            annoNew.FillColor = temp.FillColor
                            annoNew.Description = temp.Description
                            If temp.FontType IsNot Nothing Then
                                annoNew.FontType = New AnnoTextFont()
                                annoNew.FontType.Name = temp.FontType.Name
                                annoNew.FontType.Size = Integer.Parse(toolStripCbxFont.Text)
                                annoNew.FontType.TextColor = temp.FontType.TextColor
                            End If

                            annoNew.Name = temp.Name
                            annoNew.PenColor = temp.PenColor
                            annoNew.PenWidth = temp.PenWidth
                            annoNew.Selected = temp.Selected
                            annoNew.TextContent = temp.TextContent
                            annoNew.TextRotateType = temp.TextRotateType
                            tempAllAnnotation.RemoveAt(sIndex)

                            tempAllAnnotation.Insert(sIndex, annoNew)
                        End If


                    Next
                End If
            Next

            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempAllAnnotation, True)
        End If
    End Sub

    Private Sub toolStripBtnDelete_Click(sender As Object, e As EventArgs) Handles toolStripBtnDelete.Click, delToolStripMenuItem.Click
        delToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub toolStripBtnDeleteAll_Click(sender As Object, e As EventArgs) Handles deleteAllToolStripMenuItem.Click
        deleteAllToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub toolStripBtnBringToBack_Click(sender As Object, e As EventArgs)
        sendToBackToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub toolStripBtnBringToFront_Click(sender As Object, e As EventArgs)
        bringToFrontToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub toolStripCbxPen_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim array As Byte() = System.Text.Encoding.[Default].GetBytes(e.KeyChar.ToString())
        If Not Char.IsDigit(e.KeyChar) OrElse array.LongLength = 2 Then
            e.Handled = True
        End If
        If e.KeyChar = ControlChars.Back Then
            e.Handled = False
        End If
    End Sub

    Private Sub toolStripCbxFont_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim array As Byte() = System.Text.Encoding.[Default].GetBytes(e.KeyChar.ToString())
        If Not Char.IsDigit(e.KeyChar) OrElse array.LongLength = 2 Then
            e.Handled = True
        End If
        If e.KeyChar = ControlChars.Back OrElse (Not toolStripCbxFont.Text.Contains(".") AndAlso e.KeyChar = "."c) Then
            e.Handled = False
        End If
    End Sub

    Private bIfSaveAll As Boolean = False
    Private Sub saveAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles saveAllToolStripMenuItem.Click

        If m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0 Then
            Dim filedlg As New SaveFileDialog()
            filedlg.Filter = "PDF File(*.pdf)| *.pdf"
            If filedlg.ShowDialog() = DialogResult.OK Then
                bIfSaveAll = True
                m_Creator.Save(TryCast(Me, ISave), filedlg.FileName)
                bIfSaveAll = False
            End If
        End If
    End Sub

    Public Function GetAnnotations(iPageNumber As Integer) As Object Implements ISave.GetAnnotations
        If Not bIfSaveAll Then
            Return m_ImageCore.ImageBuffer.GetMetaData(dsViewer1.CurrentSelectedImageIndicesInBuffer(iPageNumber), EnumMetaDataType.enumAnnotation)
        Else
            Return m_ImageCore.ImageBuffer.GetMetaData(CShort(iPageNumber), EnumMetaDataType.enumAnnotation)
        End If

    End Function

    Public Function GetImage(iPageNumber As Integer) As Bitmap Implements ISave.GetImage
        If Not bIfSaveAll Then
            Return m_ImageCore.ImageBuffer.GetBitmap(dsViewer1.CurrentSelectedImageIndicesInBuffer(iPageNumber))
        Else
            Return m_ImageCore.ImageBuffer.GetBitmap(CShort(iPageNumber))
        End If

    End Function

    Public Function GetPageCount() As Integer Implements ISave.GetPageCount
        If Not bIfSaveAll Then
            Return dsViewer1.CurrentSelectedImageIndicesInBuffer.Count
        Else
            Return m_ImageCore.ImageBuffer.HowManyImagesInBuffer
        End If

    End Function

    Public Sub LoadConvertResult(result As ConvertResult) Implements IConvertCallback.LoadConvertResult
        m_ImageCore.IO.LoadImage(result.Image)
        If result.Annotations IsNot Nothing Then
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, result.Annotations, True)
        End If
    End Sub


End Class
