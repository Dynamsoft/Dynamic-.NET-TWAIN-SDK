Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Dynamsoft.Core
Imports Dynamsoft.Barcode
Imports Dynamsoft.PDF
Imports Dynamsoft.Core.Enums
Imports System.IO
Imports System.Runtime.InteropServices

Partial Public Class Form1
    Inherits Form
    Implements Dynamsoft.PDF.IConvertCallback
    Private m_ImageCore As ImageCore = Nothing
    Private m_PDFRasterizer As PDFRasterizer = Nothing
    Private m_StrProductKey As String
    Public Sub New()
        InitializeComponent()
        m_StrProductKey = "t0068MgAAAENENwNWc7+efmkY+t7se6XaRPFZkvfB7QWiTjHiLykxngQdY09pzVtOvrefXBbVvYFbJSluECHlyxaOvHwUADk="
        InitializeUI()
        m_ImageCore = New ImageCore()
        dsViewer1.Bind(m_ImageCore)
        AddHandler dsViewer1.OnImageAreaSelected, New Dynamsoft.Forms.Delegate.OnImageAreaSelectedHandler(AddressOf viewer1_OnImageAreaSelected)

        AddHandler dsViewer1.OnImageAreaDeselected, New Dynamsoft.Forms.Delegate.OnImageAreaDeselectedHandler(AddressOf viewer1_OnImageAreaDeselected)
        m_PDFRasterizer = New PDFRasterizer(m_StrProductKey)
    End Sub

    Protected Sub InitializeUI()
        cbxFormat.Items.Add("All")
        cbxFormat.Items.Add("OneD")
        cbxFormat.Items.Add("Code 39")
        cbxFormat.Items.Add("Code 128")
        cbxFormat.Items.Add("Code 93")
        cbxFormat.Items.Add("Codabar")
        cbxFormat.Items.Add("Interleaved 2 of 5")
        cbxFormat.Items.Add("EAN-13")
        cbxFormat.Items.Add("EAN-8")
        cbxFormat.Items.Add("UPC-A")
        cbxFormat.Items.Add("UPC-E")
        cbxFormat.Items.Add("PDF417")
        cbxFormat.Items.Add("QRCode")
        cbxFormat.Items.Add("Datamatrix")
        cbxFormat.Items.Add("Industrial 2 of 5")
        cbxFormat.SelectedIndex = 0
        tbxMaxNum.Text = "10"
    End Sub



    Private Sub button1_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Dim filedlg As New OpenFileDialog()
        filedlg.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF;*.GIF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF|GIF|*.GIF"
        filedlg.FilterIndex = 0
        filedlg.Multiselect = True
        ' try to locate images folder
        Dim imagesFolder As String = Application.ExecutablePath

        ' we assume we are running under the DotImage install folder
        imagesFolder = imagesFolder.Replace("/", "\")
        Dim strPDFDllFolder As String = imagesFolder
        Dim pos As Integer = imagesFolder.LastIndexOf("\Samples\")
        If pos <> -1 Then
            imagesFolder = imagesFolder.Substring(0, imagesFolder.IndexOf("\", pos)) & "\Samples\Bin\Images\BarcodeImages\"
        End If


        'use this folder as starting point			
        filedlg.InitialDirectory = imagesFolder

        If filedlg.ShowDialog() = DialogResult.OK Then
            For Each strfilename As String In filedlg.FileNames
                pos = strfilename.LastIndexOf(".")
                If pos <> -1 Then
                    Dim strSuffix As String = strfilename.Substring(pos, strfilename.Length - pos).ToLower()
                    If strSuffix.CompareTo(".pdf") = 0 Then
                        m_PDFRasterizer.ConvertMode = Dynamsoft.PDF.Enums.EnumConvertMode.enumCM_RENDERALL
                        m_PDFRasterizer.ConvertToImage(strfilename, "", 200, TryCast(Me, IConvertCallback))
                        Continue For
                    End If
                End If
                Me.m_ImageCore.IO.LoadImage(strfilename)
            Next
            viewer1_OnImageAreaDeselected(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
        End If
    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles btnRecognize.Click
        If m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer < 0 Then
            MessageBox.Show("Please load an image before reading barcode!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            Dim reader As New Dynamsoft.Barcode.BarcodeReader()
            reader.LicenseKeys = m_StrProductKey
            reader.ReaderOptions.MaxBarcodesToReadPerPage = Integer.Parse(tbxMaxNum.Text)
            Me.textBox1.Text = ""
            Select Case cbxFormat.SelectedIndex
                Case 0
                    Exit Select
                Case 1
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.OneD
                    Exit Select
                Case 2
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_39
                    Exit Select
                Case 3
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_128
                    Exit Select
                Case 4
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_93
                    Exit Select
                Case 5
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODABAR
                    Exit Select
                Case 6
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.ITF
                    Exit Select
                Case 7
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_13
                    Exit Select
                Case 8
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_8
                    Exit Select
                Case 9
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_A
                    Exit Select
                Case 10
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_E
                    Exit Select
                Case 11
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.PDF417
                    Exit Select
                Case 12
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.QR_CODE
                    Exit Select
                Case 13
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.DATAMATRIX
                    Exit Select
                Case 14
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.INDUSTRIAL_25
                    Exit Select
            End Select
            Me.textBox1.Text = "Recognizing..."
            Dim aryResult As BarcodeResult() = Nothing
            Dim rect As Rectangle = dsViewer1.GetSelectionRect(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
            If rect = Rectangle.Empty Then
                Dim iWidth As Integer = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width
                Dim iHeight As Integer = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height
                rect = New Rectangle(0, 0, iWidth, iHeight)
            End If
            reader.AddRegion(rect.Left, rect.Top, rect.Right, rect.Bottom, False)
            aryResult = reader.DecodeBitmap(DirectCast(m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer), Bitmap))

            Dim strText As New StringBuilder()
            If aryResult Is Nothing Then
                Me.textBox1.Text = "The barcode for selected format is not found." & vbCr & vbLf
            Else
                strText.AppendFormat(aryResult.Length & " total barcode" & (If(aryResult.Length = 1, "", "s")) & " found." & vbCr & vbLf)
                For i As Integer = 0 To aryResult.Length - 1
                    Dim objResult As BarcodeResult = aryResult(i)
                    strText.AppendFormat("      Result " & (i + 1) & vbCr & vbLf)
                    strText.AppendFormat("      BarcodeFormat: " & objResult.BarcodeFormat.ToString() & vbCr & vbLf)

                    strText.AppendFormat("      Text read:{0}" & vbCr & vbLf, objResult.BarcodeText)
                Next
                Me.textBox1.Text = strText.ToString()
            End If
        Catch exp As Exception
            MessageBox.Show(exp.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Me.textBox1.Text = ""
        End Try
    End Sub


    Private Sub dynamicDotNetTwain1_OnTopImageInTheViewChanged(sImageIndex As Short)
        If m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer >= 0 Then
            Dim rect As Rectangle = dsViewer1.GetSelectionRect(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
            If rect = Rectangle.Empty Then
                tbxLeft.Text = "0"
                tbxTop.Text = "0"
                tbxRight.Text = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width.ToString()
                tbxBottom.Text = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height.ToString()
            Else
                tbxLeft.Text = rect.Left.ToString()
                tbxTop.Text = rect.Top.ToString()
                tbxRight.Text = rect.Right.ToString()
                tbxBottom.Text = rect.Bottom.ToString()
            End If
        End If
    End Sub

    Private Sub viewer1_OnImageAreaSelected(sImageIndex As Short, left As Integer, top As Integer, right As Integer, bottom As Integer)
        tbxLeft.Text = left.ToString()
        tbxTop.Text = top.ToString()
        tbxRight.Text = right.ToString()
        tbxBottom.Text = bottom.ToString()
    End Sub

    Private Sub viewer1_OnImageAreaDeselected(sImageIndex As Short)
        tbxLeft.Text = "0"
        tbxTop.Text = "0"
        If m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer >= 0 Then
            tbxRight.Text = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width.ToString()
            tbxBottom.Text = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height.ToString()
        Else
            tbxRight.Text = "0"
            tbxBottom.Text = "0"
        End If
    End Sub

    Private Sub dynamicDotNetTwain1_OnPostAllTransfers()
        If m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer >= 0 Then
            viewer1_OnImageAreaDeselected(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
        End If
    End Sub



#Region "IConvertCallback Members"

    Public Sub LoadConvertResult(result As ConvertResult) Implements IConvertCallback.LoadConvertResult
        m_ImageCore.IO.LoadImage(result.Image)

        If result.Annotations IsNot Nothing Then
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, result.Annotations, True)
        End If
    End Sub

#End Region
End Class
