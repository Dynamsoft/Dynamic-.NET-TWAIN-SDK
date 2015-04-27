Imports System.Windows.Forms
Imports Dynamsoft.DotNet.TWAIN.Barcode
Imports Dynamsoft.DotNet.TWAIN.Enums.Barcode
Imports System.Text


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
        Me.TextBox1.Text = ""
        Dim strDllFolder As String
        strDllFolder = Application.ExecutablePath
        Dim pos As Integer
        pos = strDllFolder.LastIndexOf("\Samples\")
        If (pos <> -1) Then
            strDllFolder = strDllFolder.Substring(0, strDllFolder.IndexOf("\", pos)) + "\Redistributable\BarcodeResources\"
        Else
            pos = strDllFolder.LastIndexOf("\")
            strDllFolder = strDllFolder.Substring(0, strDllFolder.IndexOf("\", pos)) + "\"
        End If
        Me.DynamicDotNetTwain1.BarcodeDllPath = strDllFolder

        Try
            DynamicDotNetTwain1.MaxBarcodesToRead = Integer.Parse(tbxMaxNum.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Maximum Number Input error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If (Me.DynamicDotNetTwain1.CurrentImageIndexInBuffer < 0) Then
            MessageBox.Show("Please load an image before recognizing!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Me.TextBox1.Text = "Recognizing..."

        Dim aryResult() As Result

        Dim format As BarcodeFormat
        format = CType(System.Enum.Parse(GetType(BarcodeFormat), Val(cbxFormat.SelectedValue)), BarcodeFormat)

        aryResult = Me.DynamicDotNetTwain1.ReadBarcode(Me.DynamicDotNetTwain1.CurrentImageIndexInBuffer, Integer.Parse(tbxLeft.Text), Integer.Parse(tbxTop.Text), Integer.Parse(tbxRight.Text), Integer.Parse(tbxBottom.Text), format)
        Dim strText As StringBuilder
        strText = New StringBuilder()

        If aryResult.Length = 1 Then
            strText.AppendFormat(aryResult.Length & " total barcode" & ("") & " found." & Constants.vbCrLf)
        Else
            strText.AppendFormat(aryResult.Length & " total barcode" & ("s") & " found." & Constants.vbCrLf)
        End If

        For i As Integer = 0 To aryResult.Length - 1
            Dim objResult As Result
            objResult = aryResult(i)
            strText.AppendFormat("      Result " & (i + 1) & Constants.vbCrLf)
            strText.AppendFormat("      BarcodeFormat: " & objResult.BarcodeFormat.ToString() & Constants.vbCrLf)
            strText.AppendFormat("      Text read: " & objResult.Text & Constants.vbCrLf)
        Next i

        Me.TextBox1.Text = strText.ToString()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitializeUI()
        Me.DynamicDotNetTwain1.ScanInNewProcess = True
    End Sub

    Protected Sub InitializeUI()
        cbxFormat.DataSource = [Enum].GetValues(GetType(BarcodeFormat))
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
