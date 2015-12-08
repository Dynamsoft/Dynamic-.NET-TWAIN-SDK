Imports System.Windows.Forms
Imports Dynamsoft.DotNet.TWAIN.Barcode
Imports Dynamsoft.DotNet.TWAIN.Enums.Barcode
Imports System.Text
Imports Dynamsoft.Barcode


Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Dim filedlg As OpenFileDialog
        filedlg = New OpenFileDialog()
        filedlg.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF;*.GIF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF|GIF|*.GIF"
        filedlg.FilterIndex = 0
        filedlg.Multiselect = True
        ' try to locate images folder
        Dim imagesFolder As String = Application.ExecutablePath
        Dim strPDFDllPath As String
        strPDFDllPath = imagesFolder
        Dim pos As Integer = imagesFolder.LastIndexOf("\Samples\")
        If (pos <> -1) Then
            imagesFolder = imagesFolder.Substring(0, imagesFolder.IndexOf(System.IO.Path.DirectorySeparatorChar, pos)) + "\Samples\Bin\Images\BarcodeImages\"
            strPDFDllPath = strPDFDllPath.Substring(0, strPDFDllPath.IndexOf(System.IO.Path.DirectorySeparatorChar, pos)) + "\Redistributable\PDFResources\"
        Else
            pos = imagesFolder.LastIndexOf("\")
            imagesFolder = imagesFolder.Substring(0, imagesFolder.IndexOf("\", pos)) + "\"
            strPDFDllPath = imagesFolder
        End If

        'use this folder as a starting point
        filedlg.InitialDirectory = imagesFolder
        DynamicDotNetTwain1.LicenseKeys = "BAF81AB5515958BF519F7AAE2A318B3B;BAF81AB5515958BF6DA4299CBA3CC11D;BAF81AB5515958BF9C195A4722534974;BAF81AB5515958BFE96B7433DD28E75B;BAF81AB5515958BF3DBAF9AB37059787;BAF81AB5515958BF5291EEE0B030BD82"
        DynamicDotNetTwain1.PDFRasterizerDllPath = strPDFDllPath
        DynamicDotNetTwain1.IfShowCancelDialogWhenBarcodeOrOCR = True
        DynamicDotNetTwain1.MaxImagesInBuffer = 64

        Dim strFilename As String
        If (filedlg.ShowDialog() = DialogResult.OK) Then
            For Each strFilename In filedlg.FileNames
                pos = strFilename.LastIndexOf(".")
                If (pos <> -1) Then
                    Dim strSuffix As String
                    strSuffix = strFilename.Substring(pos, strFilename.Length - pos).ToLower()
                    If (strSuffix.CompareTo(".pdf") = 0) Then
                        DynamicDotNetTwain1.ConvertPDFToImage(strFilename, 200)
                        Continue For
                    End If
                End If
                DynamicDotNetTwain1.LoadImage(strFilename)

            Next
            dynamicDotNetTwain1_OnImageAreaDeselected(DynamicDotNetTwain1.CurrentImageIndexInBuffer)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecognize.Click
        If DynamicDotNetTwain1.CurrentImageIndexInBuffer < 0 Then
            MessageBox.Show("Please load an image before reading barcode!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            Dim reader As New Dynamsoft.Barcode.BarcodeReader
            reader.LicenseKeys = "91392547848AAF2410B494747EADA719"
            reader.ReaderOptions.MaxBarcodesToReadPerPage = Integer.Parse(tbxMaxNum.Text)
            Me.TextBox1.Text = ""
            Select Case cbxFormat.SelectedIndex
                Case 0
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.OneD
                Case 1
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_39
                Case 2
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_128
                Case 3
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_93
                Case 4
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODABAR
                Case 5
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.ITF
                Case 6
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_13
                Case 7
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_8
                Case 8
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_A
                Case 9
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_E
                Case 10
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.PDF417
                Case 11
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.QR_CODE
                Case 12
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.DATAMATRIX
                Case 13
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.INDUSTRIAL_25
            End Select

            Me.TextBox1.Text = "Recognizing..."

            Dim aryResult() As BarcodeResult
            Dim rect As Rectangle = DynamicDotNetTwain1.GetSelectionRect(DynamicDotNetTwain1.CurrentImageIndexInBuffer)
            If rect = Rectangle.Empty Then
                Dim iWidth As Integer = DynamicDotNetTwain1.GetImage(DynamicDotNetTwain1.CurrentImageIndexInBuffer).Width
                Dim iHeight As Integer = DynamicDotNetTwain1.GetImage(DynamicDotNetTwain1.CurrentImageIndexInBuffer).Height
                rect = New Rectangle(0, 0, iWidth, iHeight)
            End If
            aryResult = reader.DecodeBitmapRect(DynamicDotNetTwain1.GetImage(Me.DynamicDotNetTwain1.CurrentImageIndexInBuffer), rect)
            Dim strText As StringBuilder
            strText = New StringBuilder()
            If aryResult Is Nothing Then
                Me.TextBox1.Text = "The barcode for selected format is not found."
            Else
                strText.AppendFormat(aryResult.Length & " total barcode" & ("") & " found." & Constants.vbCrLf)
                For i As Integer = 0 To aryResult.Length - 1
                    Dim objResult As BarcodeResult
                    objResult = aryResult(i)
                    strText.AppendFormat("      Result " & (i + 1) & Constants.vbCrLf)
                    strText.AppendFormat("      BarcodeFormat: " & objResult.BarcodeFormat.ToString() & Constants.vbCrLf)
                    strText.AppendFormat("      Text read: " & objResult.BarcodeText & Constants.vbCrLf)
                Next i
                Me.TextBox1.Text = strText.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Text = ""
        End Try



    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitializeUI()
        Me.DynamicDotNetTwain1.ScanInNewProcess = True
    End Sub

    Protected Sub InitializeUI()
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

    Private Sub DynamicDotNetTwain1_OnImageAreaDeselected(ByVal sImageIndex As System.Int16) Handles DynamicDotNetTwain1.OnImageAreaDeselected
        tbxLeft.Text = "0"
        tbxTop.Text = "0"
        If DynamicDotNetTwain1.CurrentImageIndexInBuffer >= 0 Then
            tbxRight.Text = DynamicDotNetTwain1.GetImage(DynamicDotNetTwain1.CurrentImageIndexInBuffer).Width.ToString()
            tbxBottom.Text = DynamicDotNetTwain1.GetImage(DynamicDotNetTwain1.CurrentImageIndexInBuffer).Height.ToString()
        Else
            tbxRight.Text = "0"
            tbxBottom.Text = "0"
        End If
    End Sub

    Private Sub DynamicDotNetTwain1_OnTopImageInTheViewChanged(ByVal sImageIndex As System.Int16) Handles DynamicDotNetTwain1.OnTopImageInTheViewChanged
        If DynamicDotNetTwain1.CurrentImageIndexInBuffer >= 0 Then
            Dim rect As Rectangle
            rect = DynamicDotNetTwain1.GetSelectionRect(DynamicDotNetTwain1.CurrentImageIndexInBuffer)
            If rect = Rectangle.Empty Then
                tbxLeft.Text = "0"
                tbxTop.Text = "0"
                tbxRight.Text = DynamicDotNetTwain1.GetImage(DynamicDotNetTwain1.CurrentImageIndexInBuffer).Width.ToString()
                tbxBottom.Text = DynamicDotNetTwain1.GetImage(DynamicDotNetTwain1.CurrentImageIndexInBuffer).Height.ToString()
            Else
                tbxLeft.Text = rect.Left.ToString()
                tbxTop.Text = rect.Top.ToString()
                tbxRight.Text = rect.Right.ToString()
                tbxBottom.Text = rect.Bottom.ToString()
            End If
        End If
    End Sub

    Private Sub DynamicDotNetTwain1_OnImageAreaSelected(ByVal sImageIndex As System.Int16, ByVal left As System.Int32, ByVal top As System.Int32, ByVal right As System.Int32, ByVal bottom As System.Int32) Handles DynamicDotNetTwain1.OnImageAreaSelected
        tbxLeft.Text = left.ToString()
        tbxTop.Text = top.ToString()
        tbxRight.Text = right.ToString()
        tbxBottom.Text = bottom.ToString()
    End Sub

    Private Sub DynamicDotNetTwain1_OnPostTransfer() Handles DynamicDotNetTwain1.OnPostTransfer
        DynamicDotNetTwain1_OnImageAreaDeselected(DynamicDotNetTwain1.CurrentImageIndexInBuffer)
    End Sub
End Class
