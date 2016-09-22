Imports System.IO
Public Class Form1
    Dim languages As New Dictionary(Of String, String)
    Dim m_strCurrentDirectory As String
    Dim m_bSamplesExist As Boolean

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dynamicDotNetTwain1.LicenseKeys = "83C721A603BF5301ABCF850504F7B744;83C721A603BF5301AC7A3AA0DF1D92E6;83C721A603BF5301E22CBEC2DD20B511;83C721A603BF5301977D72EA5256A044;83C721A603BF53014332D52C75036F9E;83C721A603BF53010090AB799ED7E55E"
        Me.dynamicDotNetTwain1.IfShowCancelDialogWhenBarcodeOrOCR = True
        Me.dynamicDotNetTwain1.ScanInNewProcess = True
        cbxViewMode.SelectedIndex = 1
        Me.ddlResultFormat.Items.Add("Text")
        Me.ddlResultFormat.Items.Add("PDF Plain Text")
        Me.ddlResultFormat.Items.Add("PDF Image Over Text")
        Me.ddlResultFormat.SelectedIndex = 0

        languages.Add("English", "eng")
        'languages.Add("Arabic", "ara")
        'languages.Add("Bulgarian", "bul")
        'languages.Add("Catalan", "cat")
        'languages.Add("Czech", "ces")
        'languages.Add("Chinese (Simplified)", "chi_sim")
        'languages.Add("Chinese (Traditional)", "chi_tra")
        'languages.Add("Cherokee", "chr")
        'languages.Add("Danish (frak)", "dan-frak")
        'languages.Add("Danish", "dan")
        'languages.Add("Dutch", "nld")
        'languages.Add("German (frak)", "deu-frak")
        'languages.Add("German", "deu")
        'languages.Add("Greek", "ell")
        'languages.Add("Finnish", "fin")
        'languages.Add("French", "fra")
        'languages.Add("Hebrew (ras)", "heb-ras")
        'languages.Add("Hebrew (seg)", "heb-seg")
        'languages.Add("Hebrew", "heb")
        'languages.Add("Hindi", "hin")
        'languages.Add("Hungarian", "hun")
        'languages.Add("Indonesian", "ind")
        'languages.Add("Italian", "ita")
        'languages.Add("Japanese", "jpn")
        'languages.Add("Korean", "kor")
        'languages.Add("Latvian", "lav")
        'languages.Add("Lithuanian", "lit")
        'languages.Add("Norwegian", "nor")
        'languages.Add("Polish", "pol")
        'languages.Add("Portuguese", "por")
        'languages.Add("Romanian", "ron")
        'languages.Add("Russian", "rus")
        'languages.Add("Slovak (frak)", "slk-frak")
        'languages.Add("Slovak", "slk")
        'languages.Add("Slovenian", "slv")
        'languages.Add("Spanish", "spa")
        'languages.Add("Serbian", "srp")
        'languages.Add("Swedish (frak)", "swe-frak")
        'languages.Add("Swedish", "swe")
        'languages.Add("Thai", "tha")
        'languages.Add("Turkish", "tur")
        'languages.Add("Ukrainian", "ukr")
        'languages.Add("Vietnamese", "vie")
        Dim strlanguage As String
        For Each strlanguage In languages.Keys
            Me.cbxOCRLanguage.Items.Add(strlanguage)
        Next
        Me.cbxOCRLanguage.SelectedIndex = 0

        Me.dynamicDotNetTwain1.SetViewMode(2, 2)
        Me.dynamicDotNetTwain1.AllowMultiSelect = True

        Dim imageFolder As String
        imageFolder = Application.ExecutablePath
        Dim pos As Integer
        pos = imageFolder.LastIndexOf("\Samples\")
        If (pos <> -1) Then
            m_bSamplesExist = True
            m_strCurrentDirectory = imageFolder.Substring(0, imageFolder.IndexOf("\", pos)) + "\"
            imageFolder = m_strCurrentDirectory + "Samples\Bin\Images\OCRImages\"
        Else
            m_bSamplesExist = False
            pos = imageFolder.LastIndexOf("\")
            m_strCurrentDirectory = imageFolder.Substring(0, imageFolder.IndexOf("\", pos)) + "\"
            imageFolder = m_strCurrentDirectory
        End If

        Me.dynamicDotNetTwain1.LoadImage(imageFolder + "DNTImage1.tif")
        Me.dynamicDotNetTwain1.LoadImage(imageFolder + "DNTImage2.tif")
        Me.dynamicDotNetTwain1.LoadImage(imageFolder + "DNTImage3.tif")
        Me.dynamicDotNetTwain1.LoadImage(imageFolder + "DNTImage4.tif")
        Me.dynamicDotNetTwain1.LoadImage(imageFolder + "DNTImage5.tif")
        Me.dynamicDotNetTwain1.LoadImage(imageFolder + "DNTImage6.tif")
        Me.dynamicDotNetTwain1.LoadImage(imageFolder + "DNTImage7.tif")

        dynamicDotNetTwain1_OnImageAreaDeselected(dynamicDotNetTwain1.CurrentImageIndexInBuffer)
    End Sub

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Dim filedlg As New OpenFileDialog
        filedlg.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF;*.GIF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF|GIF|*.GIF"
        filedlg.Multiselect = True
        Dim imageFolder As String
        imageFolder = m_strCurrentDirectory
        Dim strPDFDllPath As String
        strPDFDllPath = imageFolder
        If (m_bSamplesExist) Then
            imageFolder = m_strCurrentDirectory + "Samples\Bin\Images\OCRImages\"
            strPDFDllPath = m_strCurrentDirectory + "Redistributable\Resources\PDF\"
        End If
        filedlg.InitialDirectory = imageFolder
        dynamicDotNetTwain1.PDFRasterizerDllPath = strPDFDllPath
        dynamicDotNetTwain1.IfShowCancelDialogWhenBarcodeOrOCR = True
        dynamicDotNetTwain1.MaxImagesInBuffer = 64

        Dim strFilename As String
        If (filedlg.ShowDialog() = DialogResult.OK) Then
            For Each strFilename In filedlg.FileNames
                Dim pos As Integer
                pos = strFilename.LastIndexOf(".")
                If (pos <> -1) Then
                    Dim strSuffix As String
                    strSuffix = strFilename.Substring(pos, strFilename.Length - pos).ToLower()
                    If (strSuffix.CompareTo(".pdf") = 0) Then
                        dynamicDotNetTwain1.PDFConvertMode = Dynamsoft.DotNet.TWAIN.Enums.EnumPDFConvertMode.enumCM_RENDERALL
                        dynamicDotNetTwain1.SetPDFResolution(200)
                        dynamicDotNetTwain1.LoadImage(strfilename)
                        'dynamicDotNetTwain1.ConvertPDFToImage(strFilename, 200)
                        Continue For
                    End If
                End If
                dynamicDotNetTwain1.LoadImage(strFilename)
            Next
            dynamicDotNetTwain1_OnImageAreaDeselected(dynamicDotNetTwain1.CurrentImageIndexInBuffer)
        End If
    End Sub

    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectedOCR.Click
        OCR(False)
    End Sub

    Private Sub OCR(ByVal isOcrOnRectangleArea As Boolean)
        Dim languageFolder As String
        languageFolder = m_strCurrentDirectory
        If (m_bSamplesExist) Then
            languageFolder = m_strCurrentDirectory + "Samples\Bin\"
        End If

        Me.dynamicDotNetTwain1.OCRTessDataPath = languageFolder
        Me.dynamicDotNetTwain1.OCRLanguage = languages(Me.cbxOCRLanguage.Text)


        Dim ocrResultFormat As Dynamsoft.DotNet.TWAIN.OCR.ResultFormat
        ocrResultFormat = CType(System.Enum.Parse(GetType(Dynamsoft.DotNet.TWAIN.OCR.ResultFormat), Val("&H" & Me.ddlResultFormat.SelectedIndex)), Dynamsoft.DotNet.TWAIN.OCR.ResultFormat)
        Me.dynamicDotNetTwain1.OCRResultFormat = ocrResultFormat

        Dim strDllPath As String
        strDllPath = m_strCurrentDirectory
        If (m_bSamplesExist) Then
            strDllPath = m_strCurrentDirectory + "Redistributable\Resources\OCR\"
        End If
        Me.dynamicDotNetTwain1.OCRDllPath = strDllPath

        If (Me.dynamicDotNetTwain1.CurrentImageIndexInBuffer < 0) Then
            MessageBox.Show("Please load an image before doing OCR!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim sbytes As Byte()
        If (isOcrOnRectangleArea = False) Then
            sbytes = Me.dynamicDotNetTwain1.OCR(Me.dynamicDotNetTwain1.CurrentSelectedImageIndicesInBuffer)
        Else
            sbytes = Me.dynamicDotNetTwain1.OCR(dynamicDotNetTwain1.CurrentImageIndexInBuffer, Integer.Parse(tbxLeft.Text), Integer.Parse(tbxTop.Text), Integer.Parse(tbxRight.Text), Integer.Parse(tbxBottom.Text))
        End If


        If (Not sbytes Is Nothing) Then
            Dim filedlg As New SaveFileDialog
            If Me.ddlResultFormat.SelectedIndex <> 0 Then
                filedlg.Filter = "PDF File(*.pdf)| *.pdf"
            Else
                filedlg.Filter = "Text File(*.txt)| *.txt"
            End If

            If filedlg.ShowDialog() = DialogResult.OK Then
                File.WriteAllBytes(filedlg.FileName, sbytes)
                'Dim fs As FileStream
                'fs = File.OpenWrite(filedlg.FileName)
                'fs.Write(sbytes, 0, sbytes.Length)
                'fs.Close()
            End If
        Else
            MessageBox.Show(Me.dynamicDotNetTwain1.ErrorString)
        End If
    End Sub

    Private Sub dynamicDotNetTwain1_OnImageAreaSelected(ByVal sImageIndex As System.Int16, ByVal left As System.Int32, ByVal top As System.Int32, ByVal right As System.Int32, ByVal bottom As System.Int32) Handles dynamicDotNetTwain1.OnImageAreaSelected
        tbxLeft.Text = left.ToString()
        tbxTop.Text = top.ToString()
        tbxRight.Text = right.ToString()
        tbxBottom.Text = bottom.ToString()
    End Sub

    Private Sub dynamicDotNetTwain1_OnImageAreaDeselected(ByVal sImageIndex As System.Int16) Handles dynamicDotNetTwain1.OnImageAreaDeselected
        tbxLeft.Text = "0"
        tbxTop.Text = "0"
        If dynamicDotNetTwain1.CurrentImageIndexInBuffer >= 0 Then
            tbxRight.Text = dynamicDotNetTwain1.GetImage(dynamicDotNetTwain1.CurrentImageIndexInBuffer).Width.ToString()
            tbxBottom.Text = dynamicDotNetTwain1.GetImage(dynamicDotNetTwain1.CurrentImageIndexInBuffer).Height.ToString()
        End If
    End Sub

    Private Sub cbxViewMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxViewMode.SelectedIndexChanged
        dynamicDotNetTwain1.SetViewMode((cbxViewMode.SelectedIndex + 1), (cbxViewMode.SelectedIndex + 1))
    End Sub

    Private Sub btnOCRArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOCRArea.Click
        OCR(True)
    End Sub
End Class
