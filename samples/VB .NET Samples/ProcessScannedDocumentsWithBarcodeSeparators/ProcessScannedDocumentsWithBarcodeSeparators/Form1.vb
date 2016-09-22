Imports Dynamsoft.DotNet.TWAIN
'Imports Dynamsoft.DotNet.TWAIN.Enums.Barcode
Imports Dynamsoft.Barcode

Public Class Form1

    Dim m_barcodeformat As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = New Icon(GetType(Form), "wfc.ico")
        Me.picMode1.Image = Global.PSDWBS.My.Resources.Mode1_Selected
        Me.picMode2.Image = Global.PSDWBS.My.Resources.Mode2
        Me.picFAQMode1.Image = Global.PSDWBS.My.Resources.Resources.faq
        Me.picFAQMode2.Image = Global.PSDWBS.My.Resources.Resources.faq
        Me.BackgroundImage = Global.PSDWBS.My.Resources.Resources.main_bg
        Me.dynamicDotNetTwain1.LicenseKeys = "83C721A603BF5301ABCF850504F7B744;83C721A603BF5301AC7A3AA0DF1D92E6;83C721A603BF5301E22CBEC2DD20B511;83C721A603BF5301977D72EA5256A044;83C721A603BF53014332D52C75036F9E;83C721A603BF53010090AB799ED7E55E"
        Me.dynamicDotNetTwain1.Visible = False
        Me.cmbBarcodeFormat.DropDownStyle = ComboBoxStyle.DropDownList
        'Me.cmbBarcodeFormat.DataSource = [Enum].GetValues(GetType(BarcodeFormat))
        cmbBarcodeFormat.Items.Add("All")
        cmbBarcodeFormat.Items.Add("OneD")
        cmbBarcodeFormat.Items.Add("Code 39")
        cmbBarcodeFormat.Items.Add("Code 128")
        cmbBarcodeFormat.Items.Add("Code 93")
        cmbBarcodeFormat.Items.Add("Codabar")
        cmbBarcodeFormat.Items.Add("Interleaved 2 of 5")
        cmbBarcodeFormat.Items.Add("EAN-13")
        cmbBarcodeFormat.Items.Add("EAN-8")
        cmbBarcodeFormat.Items.Add("UPC-A")
        cmbBarcodeFormat.Items.Add("UPC-E")
        cmbBarcodeFormat.Items.Add("PDF417")
        cmbBarcodeFormat.Items.Add("QRCode")
        cmbBarcodeFormat.Items.Add("Datamatrix")
        cmbBarcodeFormat.Items.Add("Industrial 2 of 5")
        Me.cmbBarcodeFormat.SelectedIndex = 0

        InitPicMode()

        'Dim strDllPath As String
        'Dim m_strCurrentDirectory As String
        'm_strCurrentDirectory = Application.ExecutablePath
        'Dim pos As Integer
        'pos = m_strCurrentDirectory.LastIndexOf("\Samples\")
        'If (pos <> -1) Then
        '    m_strCurrentDirectory = m_strCurrentDirectory.Substring(0, m_strCurrentDirectory.IndexOf("\", pos)) + "\"
        '    strDllPath = m_strCurrentDirectory + "Redistributable\BarcodeResources\"
        'Else
        '    pos = m_strCurrentDirectory.LastIndexOf("\")
        '    m_strCurrentDirectory = m_strCurrentDirectory.Substring(0, m_strCurrentDirectory.IndexOf("\", pos)) + "\"
        '    strDllPath = m_strCurrentDirectory
        'End If
        'Me.dynamicDotNetTwain1.BarcodeDllPath = strDllPath

        dynamicDotNetTwain1.IfShowCancelDialogWhenBarcodeOrOCR = True
        dynamicDotNetTwain1.MaxImagesInBuffer = 64
        dynamicDotNetTwain1.ScanInNewProcess = True

        Dim toolTip1, toolTip2 As New ToolTip()
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 1000
        toolTip1.ReshowDelay = 500
        toolTip1.ShowAlways = True
        toolTip1.SetToolTip(Me.picFAQMode1, "All pages in all source files are considered " & vbCrLf & "as one uninterrupted sequence of pages. " & vbCrLf & "Destination files are arranged so that " & vbCrLf & "the first page always contains a barcode. ")

        toolTip2.AutoPopDelay = 5000
        toolTip2.InitialDelay = 1000
        toolTip2.ReshowDelay = 500
        toolTip2.ShowAlways = True
        toolTip2.SetToolTip(Me.picFAQMode2, "Each page contains a barcode and the pages " & vbCrLf & "where barcodes coincide are detected and " & vbCrLf & "got merged to a PDF file.")


    End Sub

    Private Sub radMode1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radMode1.CheckedChanged
        InitPicMode()
    End Sub

    Private Sub radMode2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radMode2.CheckedChanged
        InitPicMode()
    End Sub

    Private Sub InitPicMode()
        If (radMode1.Checked = True) Then
            Me.picMode1.Image = Global.PSDWBS.My.Resources.Resources.Mode1_Selected
            Me.picMode2.Image = Global.PSDWBS.My.Resources.Resources.Mode2
        Else
            Me.picMode1.Image = Global.PSDWBS.My.Resources.Resources.Mode1
            Me.picMode2.Image = Global.PSDWBS.My.Resources.Resources.Mode2_Selected
        End If
    End Sub

    Dim m_listBarcodeType As List(Of String)
    Dim strBarcodeFormat As String
    Private Sub SaveFileByBarcodeText()
        m_listBarcodeType = New List(Of String)
        Dim listImageIndex As New List(Of IndexList)
        Dim listIndex As New IndexList
        listImageIndex.Add(listIndex)  'use to save no barcode files
        Dim reader As BarcodeReader = New BarcodeReader
        reader.LicenseKeys = "91392547848AAF240620ADFEFDB2EDEB"
        Try
            Select Case cmbBarcodeFormat.SelectedIndex
                Case 0

                Case 1
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.OneD
                Case 2
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_39
                Case 3
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_128
                Case 4
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_93
                Case 5
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODABAR
                Case 6
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.ITF
                Case 7
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_13
                Case 8
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_8
                Case 9
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_A
                Case 10
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_E
                Case 11
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.PDF417
                Case 12
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.QR_CODE
                Case 13
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.DATAMATRIX
                Case 14
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.INDUSTRIAL_25
            End Select
            strBarcodeFormat = reader.ReaderOptions.BarcodeFormats.ToString()
            If cmbBarcodeFormat.SelectedIndex = 0 Then
                strBarcodeFormat = "All"
            End If
            Dim i As Integer
            For i = 0 To Me.dynamicDotNetTwain1.HowManyImagesInBuffer - 1
                'Dim aryResult As Barcode.Result()
                'Dim format As BarcodeFormat
                'format = CType(System.Enum.Parse(GetType(BarcodeFormat), Val(cmbBarcodeFormat.SelectedValue)), BarcodeFormat)
                Dim aryResult() As BarcodeResult
                aryResult = reader.DecodeBitmap(dynamicDotNetTwain1.GetImage(i)) 'Please update the barcode format to yours
                If (aryResult Is Nothing) Then
                    'If no barcode found on the current image, add it to the image list for saving
                    UpdateDateList(0, i, listImageIndex)
                ElseIf aryResult.Length = 0 Then
                    'If no barcode found on the current image, add it to the image list for saving
                    UpdateDateList(0, i, listImageIndex)
                Else 'If a barcode is found, restart the list
                    Dim strBarcodeText As String
                    strBarcodeText = aryResult(0).BarcodeText
                    Dim iPosition As Integer
                    iPosition = 0
                    If (IfExistBarcodeText(strBarcodeText, iPosition) = True) Then
                        UpdateDateList(iPosition, i, listImageIndex)
                    Else
                        m_listBarcodeType.Add(strBarcodeText)
                        AddDateList(i, listImageIndex)
                    End If
                End If
            Next
            SaveImages(listImageIndex)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub AddDateList(ByVal index As Integer, ByRef listImageIndex As List(Of IndexList))
        Dim listIndex As New IndexList
        listIndex.Add(index)
        listImageIndex.Add(listIndex)
    End Sub


    Private Sub UpdateDateList(ByVal iPosition As Integer, ByVal index As Integer, ByRef listImageIndex As List(Of IndexList))
        Dim listIndex As New IndexList
        listIndex = listImageIndex(iPosition)
        listIndex.Add(index)
        listImageIndex(iPosition) = listIndex
    End Sub


    Private Function IfExistBarcodeText(ByVal strBarcodeText As String, ByRef iPosition As Integer) As Boolean
        iPosition = 0
        Dim bRet As Boolean
        bRet = False
        Dim strTemp As String
        strTemp = ""
        Dim i As Integer

        For i = 0 To m_listBarcodeType.Count - 1
            strTemp = m_listBarcodeType(i)
            If (strBarcodeText.Trim().ToLower().CompareTo(strTemp.Trim().ToLower()) = 0) Then
                iPosition = i + 1
                bRet = True
                Exit For
            End If
        Next
        Return bRet
    End Function

    Dim bHasBarcodeOnFirstImage As Boolean = False
    Private Sub SaveImages(ByVal listImageIndex As List(Of IndexList))
        Dim index As Integer
        index = 0
        Dim objFolderBrowserDialog As New FolderBrowserDialog

        If (objFolderBrowserDialog.ShowDialog() = DialogResult.OK) Then
            Dim list As IndexList
            For Each list In listImageIndex
                If (list.Count <> 0) Then
                    Dim strTempPDFName As String
                    If radMode1.Checked = True Then
                        If index = 0 And bHasBarcodeOnFirstImage = False Then
                            strTempPDFName = String.Format(objFolderBrowserDialog.SelectedPath.Trim() & "\\" & strBarcodeFormat.ToString() & "-BeginWithNoBarcode.pdf")
                            Dim i As Integer = 2
                            While System.IO.File.Exists(strTempPDFName)
                                strTempPDFName = String.Format(objFolderBrowserDialog.SelectedPath.Trim() & "\\" & strBarcodeFormat.ToString() & "-BeginWithNoBarcode({0}).pdf", i)
                                i = i + 1
                            End While
                            Me.dynamicDotNetTwain1.SaveAsMultiPagePDF(strTempPDFName, list)
                        Else
                            If index = 0 And bHasBarcodeOnFirstImage = True Then
                                index = 1
                            End If
                            If Not m_listBarcodeType Is Nothing Then
                                strTempPDFName = m_listBarcodeType(index - 1)
                                strTempPDFName = Me.SetPDFFileName(objFolderBrowserDialog.SelectedPath.Trim(), strBarcodeFormat.ToString(), m_listBarcodeType(index - 1))
                                strTempPDFName = String.Format(objFolderBrowserDialog.SelectedPath.Trim() & "\\" & strTempPDFName)
                                Me.dynamicDotNetTwain1.SaveAsMultiPagePDF(strTempPDFName, list)
                            End If
                        End If
                    Else
                        If index = 0 Then
                            strTempPDFName = String.Format(objFolderBrowserDialog.SelectedPath.Trim() & "\\" & strBarcodeFormat.ToString() & "-None.pdf")
                            Dim i As Integer = 2
                            While System.IO.File.Exists(strTempPDFName)
                                strTempPDFName = String.Format(objFolderBrowserDialog.SelectedPath.Trim() & "\\" & strBarcodeFormat.ToString() & "-None({0}).pdf", i)
                                i = i + 1
                            End While
                            Me.dynamicDotNetTwain1.SaveAsMultiPagePDF(strTempPDFName, list)
                        Else
                            strTempPDFName = m_listBarcodeType(index - 1)
                            strTempPDFName = Me.SetPDFFileName(objFolderBrowserDialog.SelectedPath.Trim(), strBarcodeFormat.ToString(), m_listBarcodeType(index - 1))
                            strTempPDFName = String.Format(objFolderBrowserDialog.SelectedPath.Trim() & "\\" & strTempPDFName)
                            Me.dynamicDotNetTwain1.SaveAsMultiPagePDF(strTempPDFName, list)
                        End If
                    End If

                End If
                index = index + 1
            Next
            MessageBox.Show(Me.dynamicDotNetTwain1.ErrorString)
        End If
    End Sub


    Private Sub SaveFileByBegainWithBarcode()
        Dim listImageIndex As New List(Of IndexList)
        Dim listIndex As IndexList
        m_listBarcodeType = New List(Of String)
        bHasBarcodeOnFirstImage = False
        Dim reader As BarcodeReader = New BarcodeReader
        reader.LicenseKeys = "91392547848AAF240620ADFEFDB2EDEB"
        Try
            Select Case cmbBarcodeFormat.SelectedIndex
                Case 0

                Case 1
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.OneD
                Case 2
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_39
                Case 3
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_128
                Case 4
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_93
                Case 5
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODABAR
                Case 6
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.ITF
                Case 7
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_13
                Case 8
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_8
                Case 9
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_A
                Case 10
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_E
                Case 11
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.PDF417
                Case 12
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.QR_CODE
                Case 13
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.DATAMATRIX
                Case 14
                    reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.INDUSTRIAL_25
            End Select
            strBarcodeFormat = reader.ReaderOptions.BarcodeFormats.ToString()
            If cmbBarcodeFormat.SelectedIndex = 0 Then
                strBarcodeFormat = "All"
            End If
            Dim i As Integer
            For i = 0 To Me.dynamicDotNetTwain1.HowManyImagesInBuffer - 1
                If listIndex Is Nothing Then
                    listIndex = New IndexList()
                End If
                'Dim aryResult As Barcode.Result()
                'Dim format As BarcodeFormat
                'format = CType(System.Enum.Parse(GetType(BarcodeFormat), Val(cmbBarcodeFormat.SelectedValue)), BarcodeFormat)
                Dim aryResult() As BarcodeResult
                aryResult = reader.DecodeBitmap(dynamicDotNetTwain1.GetImage(i)) 'Please update the barcode format to yours
                If i = 0 Then
                    If Not aryResult Is Nothing Then
                        If Not aryResult.Length = 0 Then
                            bHasBarcodeOnFirstImage = True
                        End If
                    End If
                End If
                If aryResult Is Nothing Then
                    listIndex.Add(i) 'If no barcode found on the current image, add it to the image list for saving
                ElseIf aryResult.Length = 0 Then
                    listIndex.Add(i) 'If no barcode found on the current image, add it to the image list for saving
                Else
                    m_listBarcodeType.Add(aryResult(0).BarcodeText)
                    If (Not listIndex Is Nothing And listIndex.Count > 0) Then
                        listImageIndex.Add(listIndex)
                        listIndex = Nothing
                    End If

                    'If a barcode is found, restart the list
                    If listIndex Is Nothing Then
                        listIndex = New IndexList()
                    End If
                    listIndex.Add(i)
                End If

            Next

            If (Not listIndex Is Nothing) Then
                listImageIndex.Add(listIndex)  'save a last set of data
                listIndex = Nothing
            End If

            SaveImages(listImageIndex)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        
    End Sub


    Private Sub btnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScan.Click
        Me.dynamicDotNetTwain1.SelectSource()
        Me.dynamicDotNetTwain1.OpenSource()
        Me.dynamicDotNetTwain1.IfAutoFeed = True
        Me.dynamicDotNetTwain1.IfFeederEnabled = True
        Me.dynamicDotNetTwain1.IfShowUI = False
        Me.dynamicDotNetTwain1.AcquireImage()
    End Sub

    Private Sub btnRemoveAllImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllImage.Click
        Me.dynamicDotNetTwain1.RemoveAllImages()
        Me.dynamicDotNetTwain1.Visible = False
    End Sub

    Private Sub btnRemoveSelectedImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSelectedImages.Click
        Me.dynamicDotNetTwain1.RemoveImages(Me.dynamicDotNetTwain1.CurrentSelectedImageIndicesInBuffer)
        If Me.dynamicDotNetTwain1.HowManyImagesInBuffer = 0 Then
            Me.dynamicDotNetTwain1.Visible = False
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Me.dynamicDotNetTwain1.HowManyImagesInBuffer > 0) Then
            If (Me.radMode1.Checked = True) Then
                SaveFileByBegainWithBarcode()
            Else
                SaveFileByBarcodeText()
            End If
        End If
    End Sub

    Private Sub dynamicDotNetTwain1_OnPostAllTransfers() Handles dynamicDotNetTwain1.OnPostAllTransfers
        If (Me.dynamicDotNetTwain1.Visible = False) Then
            Me.dynamicDotNetTwain1.Visible = True
        End If
    End Sub

    Private Function SetPDFFileName(FileFolder As String, strBarcodeType As String, strText As String) As String
        Dim iCharindex As Integer = 0
        Dim strBarcodeText As String = strText
        Dim strFullPDFName As String
        Dim strPDFName As String
        Dim bHasillegalcharacter As Boolean = False
        Dim bIsRepeatName As Boolean = False
        For Each Text As Char In strBarcodeText
            Dim bIsillegalcharacter As Boolean = False
            For Each temp As Char In System.IO.Path.GetInvalidFileNameChars()
                If Text = temp Then
                    bHasillegalcharacter = True
                    bIsillegalcharacter = True
                End If
            Next
            If bIsillegalcharacter = True Then
                strBarcodeText = strBarcodeText.Remove(iCharindex, 1)
                iCharindex = iCharindex - 1
            End If
            iCharindex = iCharindex + 1
        Next
        strFullPDFName = String.Format(strBarcodeType & "-" & strBarcodeText)
        Dim i As Integer = 2
        Dim FilePath = String.Format(FileFolder & "\\" & strFullPDFName & ".pdf")
        While (System.IO.File.Exists(FilePath))
            bIsRepeatName = True
            strFullPDFName = String.Format(strBarcodeType & "-" & strBarcodeText & "({0})", i)
            FilePath = String.Format(FileFolder & "\\" & strFullPDFName & ".pdf")
            i = i + 1
        End While
        If bHasillegalcharacter Then
            Dim fSetFileNameForm As PSDWBS.Form2 = New Form2(FileFolder, strFullPDFName)
            fSetFileNameForm.ShowDialog()
            strPDFName = fSetFileNameForm.GetPDFFileName()
        Else
            strPDFName = strFullPDFName + ".pdf"
        End If
        Return strPDFName
    End Function

End Class
