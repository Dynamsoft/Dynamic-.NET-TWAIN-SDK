Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Dynamsoft.Core
Imports Dynamsoft.OCR
Imports System.IO
Imports Dynamsoft.Forms
Imports Dynamsoft.PDF
Imports Dynamsoft.Core.Enums
Imports System.Runtime.InteropServices

Partial Public Class Form1
    Inherits Form
    Implements IConvertCallback
    Private m_StrProductKey As String
    Private m_ImageCore As ImageCore = Nothing
    Private m_Tesseract As Tesseract = Nothing
    Private m_PDFRasterizer As PDFRasterizer = Nothing

    Public Sub New()
        InitializeComponent()
        m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU="
        m_Tesseract = New Tesseract(m_StrProductKey)
        m_ImageCore = New ImageCore()
        dsViewer1.Bind(m_ImageCore)
        m_PDFRasterizer = New PDFRasterizer(m_StrProductKey)
        AddHandler dsViewer1.OnImageAreaSelected, New Dynamsoft.Forms.Delegate.OnImageAreaSelectedHandler(AddressOf dsViewer1_OnImageAreaSelected)

        AddHandler dsViewer1.OnImageAreaDeselected, New Dynamsoft.Forms.Delegate.OnImageAreaDeselectedHandler(AddressOf dynamicDotNetTwain1_OnImageAreaDeselected)

        AddHandler dsViewer1.OnMouseClick, New Dynamsoft.Forms.Delegate.OnMouseClickHandler(AddressOf dsViewer1_OnMouseClick)

    End Sub


    Private Sub dsViewer1_OnMouseClick(sImageIndex As Short)
        tbxLeft.Text = "0"
        tbxTop.Text = "0"
        If m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer >= 0 Then
            tbxRight.Text = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width.ToString()
            tbxBottom.Text = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height.ToString()
        End If
    End Sub


    Private Sub dsViewer1_OnImageAreaSelected(sImageIndex As Short, left As Integer, top As Integer, right As Integer, bottom As Integer)
        tbxLeft.Text = left.ToString()
        tbxTop.Text = top.ToString()
        tbxRight.Text = right.ToString()
        tbxBottom.Text = bottom.ToString()
    End Sub


    Private m_strCurrentDirectory As String
    Private m_bSamplesExist As Boolean = False

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim filedlg As New OpenFileDialog()
        filedlg.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF;*.GIF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF|GIF|*.GIF"
        filedlg.Multiselect = True
        Dim imageFolder As String = m_strCurrentDirectory
        Dim strPDFDllFolder As String = imageFolder
        If m_bSamplesExist Then
            imageFolder = m_strCurrentDirectory & "Samples\Bin\Images\OCRImages\"
        End If

        filedlg.InitialDirectory = imageFolder

        If filedlg.ShowDialog() = DialogResult.OK Then
            For Each strfilename As String In filedlg.FileNames
                Dim pos As Integer = strfilename.LastIndexOf(".")
                If pos <> -1 Then
                    Dim strSuffix As String = strfilename.Substring(pos, strfilename.Length - pos).ToLower()
                    If strSuffix.CompareTo(".pdf") = 0 Then
                        m_PDFRasterizer.ConvertMode = Dynamsoft.PDF.Enums.EnumConvertMode.enumCM_RENDERALL
                        m_PDFRasterizer.ConvertToImage(strfilename, "", 200, TryCast(Me, IConvertCallback))
                        Continue For
                    End If
                End If
                m_ImageCore.IO.LoadImage(strfilename)
            Next
            dynamicDotNetTwain1_OnImageAreaDeselected(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
        End If
    End Sub

    Private Sub OCR(isOcrOnRectangleArea As Boolean)
        Dim languageFolder As String = m_strCurrentDirectory
        If m_bSamplesExist Then
            languageFolder = m_strCurrentDirectory & "Samples\Bin\tessdata"
        End If

        m_Tesseract.TessDataPath = languageFolder
        m_Tesseract.Language = languages(Me.cbxOCRLanguage.Text)
        m_Tesseract.ResultFormat = CType(Me.ddlResultFormat.SelectedIndex, Dynamsoft.OCR.Enums.ResultFormat)

        Dim strDllPath As String = m_strCurrentDirectory

        If m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer < 0 Then
            MessageBox.Show("Please load an image before doing OCR!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim sbytes As Byte() = Nothing
        Dim tempListSelectedIndex As List(Of Short) = dsViewer1.CurrentSelectedImageIndicesInBuffer
        Dim tempListSelectedBitmap As List(Of Bitmap) = Nothing
        For Each index As Short In tempListSelectedIndex
            If index >= 0 AndAlso index < m_ImageCore.ImageBuffer.HowManyImagesInBuffer Then
                If tempListSelectedBitmap Is Nothing Then
                    tempListSelectedBitmap = New List(Of Bitmap)()
                End If
                Dim temp As Bitmap = m_ImageCore.ImageBuffer.GetBitmap(index)
                tempListSelectedBitmap.Add(temp)
            End If
        Next
        If Not isOcrOnRectangleArea Then
            If tempListSelectedBitmap IsNot Nothing Then
                sbytes = m_Tesseract.Recognize(tempListSelectedBitmap)
            End If
        Else
            If Integer.Parse(tbxRight.Text) = 0 OrElse Integer.Parse(tbxBottom.Text) = 0 Then
                MessageBox.Show("The width or height of the select rectangle can not be 0.")
                Return
            End If

            sbytes = m_Tesseract.Recognize(m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer), Integer.Parse(tbxLeft.Text), Integer.Parse(tbxTop.Text), Integer.Parse(tbxRight.Text), Integer.Parse(tbxBottom.Text))
        End If

        If sbytes IsNot Nothing AndAlso sbytes.Length > 0 Then
            Dim filedlg As New SaveFileDialog()
            If Me.ddlResultFormat.SelectedIndex <> 0 Then
                filedlg.Filter = "PDF File(*.pdf)| *.pdf"
            Else
                filedlg.Filter = "Text File(*.txt)| *.txt"
            End If
            If filedlg.ShowDialog() = DialogResult.OK Then
                File.WriteAllBytes(filedlg.FileName, sbytes)
            End If
        Else
        End If
    End Sub

    Private languages As New Dictionary(Of String, String)()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dsViewer1.SetViewMode(2, 2)
        cbxViewMode.SelectedIndex = 1
        dsViewer1.AllowMultiSelect = True

        languages.Add("English", "eng")
        For Each str As String In languages.Keys
            Me.cbxOCRLanguage.Items.Add(str)
        Next
        Me.cbxOCRLanguage.SelectedIndex = 0

        Me.ddlResultFormat.Items.Add("Text File")
        Me.ddlResultFormat.Items.Add("Adobe PDF Plain Text File")
        Me.ddlResultFormat.Items.Add("Adobe PDF Image Over Text File")
        Me.ddlResultFormat.SelectedIndex = 0

        Dim imageFolder As String = Application.ExecutablePath
        imageFolder = imageFolder.Replace("/", "\")
        Dim pos As Integer = imageFolder.LastIndexOf("\Samples\")
        If pos <> -1 Then
            m_bSamplesExist = True
            m_strCurrentDirectory = imageFolder.Substring(0, imageFolder.IndexOf("\", pos)) & "\"
            imageFolder = m_strCurrentDirectory & "Samples\Bin\Images\OCRImages\"
        Else
            m_bSamplesExist = False
            pos = imageFolder.LastIndexOf("\")
            m_strCurrentDirectory = imageFolder.Substring(0, imageFolder.IndexOf("\", pos)) & "\"
            imageFolder = m_strCurrentDirectory
        End If

        m_ImageCore.IO.LoadImage(imageFolder & "\DNTImage1.tif")
        m_ImageCore.IO.LoadImage(imageFolder & "\DNTImage2.tif")
        m_ImageCore.IO.LoadImage(imageFolder & "\DNTImage3.tif")
        m_ImageCore.IO.LoadImage(imageFolder & "\DNTImage4.tif")
        m_ImageCore.IO.LoadImage(imageFolder & "\DNTImage5.tif")
        m_ImageCore.IO.LoadImage(imageFolder & "\DNTImage6.tif")
        m_ImageCore.IO.LoadImage(imageFolder & "\DNTImage7.tif")
        dynamicDotNetTwain1_OnImageAreaDeselected(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
    End Sub


    Private Sub dynamicDotNetTwain1_OnImageAreaSelected(sImageIndex As Short, left As Integer, top As Integer, right As Integer, bottom As Integer)
        tbxLeft.Text = left.ToString()
        tbxTop.Text = top.ToString()
        tbxRight.Text = right.ToString()
        tbxBottom.Text = bottom.ToString()
    End Sub

    Private Sub dynamicDotNetTwain1_OnImageAreaDeselected(sImageIndex As Short)
        tbxLeft.Text = "0"
        tbxTop.Text = "0"
        If m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer >= 0 Then
            tbxRight.Text = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width.ToString()
            tbxBottom.Text = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height.ToString()
        End If
    End Sub

    Private Sub btnOCRArea_Click(sender As Object, e As EventArgs) Handles btnOCRArea.Click
        OCR(True)
    End Sub

    Private Sub cbxViewMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxViewMode.SelectedIndexChanged
        dsViewer1.SetViewMode(CShort(cbxViewMode.SelectedIndex + 1), CShort(cbxViewMode.SelectedIndex + 1))
    End Sub

    Public Sub LoadConvertResult(result As ConvertResult) Implements IConvertCallback.LoadConvertResult
        m_ImageCore.IO.LoadImage(result.Image)
        m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, result.Annotations, True)
    End Sub

    Private Sub btnSelectedOCR_Click(sender As Object, e As EventArgs) Handles btnSelectedOCR.Click
        OCR(False)
    End Sub

    Private Sub btnRemoveAll_Click(sender As Object, e As EventArgs) Handles btnRemoveAll.Click
        m_ImageCore.ImageBuffer.RemoveAllImages()
    End Sub

    Private Sub btnRemoveSelected_Click(sender As Object, e As EventArgs) Handles btnRemoveSelected.Click
        m_ImageCore.ImageBuffer.RemoveImages(dsViewer1.CurrentSelectedImageIndicesInBuffer)
    End Sub
End Class
