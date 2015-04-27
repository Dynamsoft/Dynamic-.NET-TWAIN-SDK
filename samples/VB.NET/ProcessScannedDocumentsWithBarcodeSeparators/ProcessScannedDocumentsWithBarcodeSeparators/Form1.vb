Imports Dynamsoft.DotNet.TWAIN
Imports Dynamsoft.DotNet.TWAIN.Enums.Barcode

Public Class Form1

    Dim m_barcodeformat As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = New Icon(GetType(Form), "wfc.ico")
        Me.dynamicDotNetTwain1.Visible = False
        Me.cmbBarcodeFormat.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cmbBarcodeFormat.DataSource = [Enum].GetValues(GetType(BarcodeFormat))
        Me.cmbBarcodeFormat.SelectedIndex = 0

        InitPicMode()

        Dim strDllPath As String
        Dim m_strCurrentDirectory As String
        m_strCurrentDirectory = Application.ExecutablePath
        Dim pos As Integer
        pos = m_strCurrentDirectory.LastIndexOf("\Samples\")
        If (pos <> -1) Then
            m_strCurrentDirectory = m_strCurrentDirectory.Substring(0, m_strCurrentDirectory.IndexOf("\", pos)) + "\"
            strDllPath = m_strCurrentDirectory + "Redistributable\BarcodeResources\"
        Else
            pos = m_strCurrentDirectory.LastIndexOf("\")
            m_strCurrentDirectory = m_strCurrentDirectory.Substring(0, m_strCurrentDirectory.IndexOf("\", pos)) + "\"
            strDllPath = m_strCurrentDirectory
        End If
        Me.dynamicDotNetTwain1.BarcodeDllPath = strDllPath

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
            Me.picMode1.Image = Global.PSDWBS.My.Resources.Resources.Mode2
            Me.picMode2.Image = Global.PSDWBS.My.Resources.Resources.Mode2_Selected
        End If
    End Sub

    Dim m_listBarcodeType As List(Of String)

    Private Sub SaveFileByBarcodeText()
        m_listBarcodeType = New List(Of String)
        Dim listImageIndex As New List(Of IndexList)
        Dim listIndex As New IndexList
        listImageIndex.Add(listIndex)  'use to save no barcode files

        Dim i As Integer

        For i = 0 To Me.dynamicDotNetTwain1.HowManyImagesInBuffer - 1
            Dim aryResult As Barcode.Result()
            Dim format As BarcodeFormat
            format = CType(System.Enum.Parse(GetType(BarcodeFormat), Val(cmbBarcodeFormat.SelectedValue)), BarcodeFormat)
            aryResult = Me.dynamicDotNetTwain1.ReadBarcode(Convert.ToInt16(i), format) 'Please update the barcode format to yours


            If (aryResult Is Nothing Or aryResult.Length = 0) Then
                'If no barcode found on the current image, add it to the image list for saving
                UpdateDateList(0, i, listImageIndex)
            Else 'If a barcode is found, restart the list
                Dim strBarcodeText As String
                strBarcodeText = aryResult(0).Text
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


    Private Sub SaveImages(ByVal listImageIndex As List(Of IndexList))
        Dim index As Integer
        index = 0
        Dim objFolderBrowserDialog As New FolderBrowserDialog

        If (objFolderBrowserDialog.ShowDialog() = DialogResult.OK) Then
            Dim list As IndexList
            For Each list In listImageIndex
                If (list.Count <> 0) Then
                    Me.dynamicDotNetTwain1.SaveAsMultiPagePDF(objFolderBrowserDialog.SelectedPath.Trim() + "\" + index.ToString() + ".pdf", list)
                End If
                index = index + 1
            Next
        End If

        MessageBox.Show(Me.dynamicDotNetTwain1.ErrorString)
    End Sub


    Private Sub SaveFileByBegainWithBarcode()
        Dim listImageIndex As New List(Of IndexList)
        Dim listIndex As IndexList
        Dim i As Integer
        For i = 0 To Me.dynamicDotNetTwain1.HowManyImagesInBuffer - 1
            If listIndex Is Nothing Then
                listIndex = New IndexList()
            End If

            Dim aryResult As Barcode.Result()
            Dim format As BarcodeFormat
            format = CType(System.Enum.Parse(GetType(BarcodeFormat), Val(cmbBarcodeFormat.SelectedValue)), BarcodeFormat)
            aryResult = Me.dynamicDotNetTwain1.ReadBarcode(Convert.ToInt16(i), format) 'Please update the barcode format to yours


            If (aryResult Is Nothing Or aryResult.Length = 0) Then
                listIndex.Add(i) 'If no barcode found on the current image, add it to the image list for saving
            Else
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
End Class
