Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Dynamsoft.Barcode
Imports Dynamsoft.Core
Imports Dynamsoft.TWAIN
Imports Dynamsoft.TWAIN.Interface
Imports Dynamsoft.PDF
Imports System.IO
Imports System.Runtime.InteropServices

Partial Public Class Form1
    Inherits Form
    Implements Dynamsoft.TWAIN.Interface.IAcquireCallback
    Public Sub New()
        InitializeComponent()
        Initialization()
        m_ImageCore = New ImageCore()
        dsViewer1.Bind(m_ImageCore)
        m_TwainManager = New TwainManager(m_StrProductKey)
        m_PDFCreator = New PDFCreator(m_StrProductKey)
    End Sub
    Private m_StrProductKey As String
    Private m_ImageCore As ImageCore = Nothing
    Private m_TwainManager As TwainManager = Nothing
    Private m_PDFCreator As PDFCreator = Nothing
    Protected Sub Initialization()
        Me.Icon = New Icon(GetType(Form), "wfc.ico")
        Me.dsViewer1.Visible = False
        m_StrProductKey = "t0068MgAAAENENwNWc7+efmkY+t7se6XaRPFZkvfB7QWiTjHiLykxngQdY09pzVtOvrefXBbVvYFbJSluECHlyxaOvHwUADk="
        Me.cmbBarcodeFormat.DropDownStyle = ComboBoxStyle.DropDownList
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
        cmbBarcodeFormat.SelectedIndex = 0

        Me.picMode1.Image = My.Resources.Resources.Mode1_Selected
        Me.picMode2.Image = My.Resources.Resources.Mode2
        Me.picFAQMode1.Image = My.Resources.Resources.faq
        Me.picFAQMode2.Image = My.Resources.Resources.faq
        Me.BackgroundImage = My.Resources.Resources.main_bg

        InitPicMode()


        Dim toolTip1 As New ToolTip()
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 1000
        toolTip1.ReshowDelay = 500
        toolTip1.ShowAlways = True
        toolTip1.SetToolTip(Me.picFAQMode1, "All pages in all source files are considered " & vbCr & vbLf & "as one uninterrupted sequence of pages. " & vbCr & vbLf & "Destination files are arranged so that " & vbCr & vbLf & "the first page always contains a barcode. ")

        Dim toolTip2 As New ToolTip()
        toolTip2.AutoPopDelay = 5000
        toolTip2.InitialDelay = 1000
        toolTip2.ReshowDelay = 500
        toolTip2.ShowAlways = True
        toolTip2.SetToolTip(Me.picFAQMode2, "Each page contains a barcode and the pages " & vbCr & vbLf & "where barcodes coincide are detected and " & vbCr & vbLf & "got merged to a PDF file.")

    End Sub



    Private Sub radMode1_CheckedChanged(sender As Object, e As EventArgs) Handles radMode1.CheckedChanged
        InitPicMode()
    End Sub

    Private Sub radMode2_CheckedChanged(sender As Object, e As EventArgs) Handles radMode2.CheckedChanged
        InitPicMode()
    End Sub

    Private Sub InitPicMode()
        If radMode1.Checked = True Then
            Me.picMode1.Image = My.Resources.Resources.Mode1_Selected
            Me.picMode2.Image = My.Resources.Resources.Mode2
        Else
            Me.picMode1.Image = My.Resources.Resources.Mode1
            Me.picMode2.Image = My.Resources.Resources.Mode2_Selected
        End If
    End Sub

    Private m_listBarcodeType As List(Of String) = Nothing
    Private strBarcodeFormat As String = Nothing
    Private Sub SaveFileByBarcodeText()
        m_listBarcodeType = New List(Of String)()
        Dim listImageIndex As New List(Of List(Of Short))()
        Dim listIndex As New List(Of Short)()
        listImageIndex.Add(listIndex)
        'use to save no barcode files
        Dim reader As New BarcodeReader()
        reader.LicenseKeys = m_StrProductKey
        Try
            Select Case cmbBarcodeFormat.SelectedIndex
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
            strBarcodeFormat = reader.ReaderOptions.BarcodeFormats.ToString()
            If cmbBarcodeFormat.SelectedIndex = 0 Then
                strBarcodeFormat = "All"
            End If
            For i As Integer = 0 To m_ImageCore.ImageBuffer.HowManyImagesInBuffer - 1
                Dim aryResult As BarcodeResult() = Nothing
                aryResult = reader.DecodeBitmap(DirectCast(m_ImageCore.ImageBuffer.GetBitmap(CShort(i)), Bitmap))
                If aryResult Is Nothing OrElse (aryResult IsNot Nothing AndAlso aryResult.Length = 0) Then
                    'If no barcode found on the current image, add it to the image list for saving
                    UpdateDateList(0, i, listImageIndex)
                Else
                    'If a barcode is found, restart the list
                    Dim strBarcodeText As String = aryResult(0).BarcodeText
                    Dim iPosition As Integer = 0
                    If IfExistBarcodeText(strBarcodeText, iPosition) Then
                        UpdateDateList(iPosition, i, listImageIndex)
                    Else
                        m_listBarcodeType.Add(strBarcodeText)

                        AddDateList(i, listImageIndex)
                    End If
                End If
            Next
            SaveImages(listImageIndex)
        Catch exp As Exception
            MessageBox.Show(exp.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub AddDateList(index As Integer, ByRef listImageIndex As List(Of List(Of Short)))
        Dim listIndex As New List(Of Short)()
        listIndex.Add(CShort(index))
        listImageIndex.Add(listIndex)
    End Sub

    Private Sub UpdateDateList(iPosition As Integer, index As Integer, ByRef listImageIndex As List(Of List(Of Short)))
        Dim listIndex As New List(Of Short)()
        listIndex = listImageIndex(iPosition)
        listIndex.Add(CShort(index))
        listImageIndex(iPosition) = listIndex
    End Sub

    Private Function IfExistBarcodeText(strBarcodeText As String, ByRef iPosition As Integer) As Boolean
        iPosition = 0
        Dim bRet As Boolean = False
        Dim strTemp As String = ""
        Dim i As Integer = 0
        For i = 0 To m_listBarcodeType.Count - 1
            strTemp = m_listBarcodeType(i)
            If strBarcodeText.Trim().ToLower().CompareTo(strTemp.Trim().ToLower()) = 0 Then
                iPosition = i + 1
                bRet = True
                Exit For
            End If
        Next
        Return bRet
    End Function

    Private bHasBarcodeOnFirstImage As Boolean = False
    Private Sub SaveImages(listImageIndex As List(Of List(Of Short)))
        Dim index As Integer = 0
        Dim objFolderBrowserDialog As New FolderBrowserDialog()
        If objFolderBrowserDialog.ShowDialog() = DialogResult.OK Then
            For Each list As List(Of Short) In listImageIndex
                If list.Count <> 0 Then
                    Dim strFirstPDFName As String = Nothing
                    If radMode1.Checked = True Then
                        If index = 0 AndAlso bHasBarcodeOnFirstImage = False Then

                            strFirstPDFName = objFolderBrowserDialog.SelectedPath.Trim() & "\" & strBarcodeFormat.ToString() & "-BeginWithNoBarcode.pdf"
                            Dim i As Integer = 2
                            While System.IO.File.Exists(strFirstPDFName)
                                strFirstPDFName = [String].Format(objFolderBrowserDialog.SelectedPath.Trim() & "\" & strBarcodeFormat.ToString() & "-BeginWithNoBarcode({0}).pdf", i)
                                i += 1
                            End While

                            Dim tempPDFCreator As New DyPDFCreator(m_ImageCore, list, m_PDFCreator)
                            tempPDFCreator.SaveAsPDF(strFirstPDFName)
                        Else
                            If index = 0 AndAlso bHasBarcodeOnFirstImage = True Then
                                index = 1
                            End If
                            If m_listBarcodeType IsNot Nothing Then
                                Dim strTempPDFName As String = m_listBarcodeType(index - 1)
                                strTempPDFName = Me.SetPDFFileName(objFolderBrowserDialog.SelectedPath.Trim(), strBarcodeFormat.ToString(), m_listBarcodeType(index - 1))
                                Dim tempPDFCreator As New DyPDFCreator(m_ImageCore, list, m_PDFCreator)
                                tempPDFCreator.SaveAsPDF(strTempPDFName)

                            End If
                        End If
                    Else
                        If index = 0 Then
                            strFirstPDFName = objFolderBrowserDialog.SelectedPath.Trim() & "\" & strBarcodeFormat.ToString() & "-None.pdf"
                            Dim i As Integer = 2
                            While System.IO.File.Exists(strFirstPDFName)
                                strFirstPDFName = [String].Format(objFolderBrowserDialog.SelectedPath.Trim() & "\" & strBarcodeFormat.ToString() & "-None({0}).pdf", i)
                                i += 1
                            End While
                            Dim tempPDFCreator As New DyPDFCreator(m_ImageCore, list, m_PDFCreator)
                            tempPDFCreator.SaveAsPDF(strFirstPDFName)
                        Else
                            Dim strTempPDFName As String = Nothing
                            strTempPDFName = Me.SetPDFFileName(objFolderBrowserDialog.SelectedPath.Trim(), strBarcodeFormat.ToString(), m_listBarcodeType(index - 1))

                            Dim tempPDFCreator As New DyPDFCreator(m_ImageCore, list, m_PDFCreator)
                            tempPDFCreator.SaveAsPDF(strTempPDFName)

                        End If
                    End If
                End If
                index += 1
            Next
        End If
    End Sub

    Private Sub SaveFileByBegainWithBarcode()
        m_listBarcodeType = New List(Of String)()
        Dim listImageIndex As New List(Of List(Of Short))()
        Dim listIndex As List(Of Short) = Nothing
        Dim reader As New BarcodeReader()
        bHasBarcodeOnFirstImage = False
        reader.LicenseKeys = m_StrProductKey
        Try
            For i As Integer = 0 To m_ImageCore.ImageBuffer.HowManyImagesInBuffer - 1
                If listIndex Is Nothing Then
                    listIndex = New List(Of Short)()
                End If
                Select Case cmbBarcodeFormat.SelectedIndex
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
                strBarcodeFormat = reader.ReaderOptions.BarcodeFormats.ToString()
                If cmbBarcodeFormat.SelectedIndex = 0 Then
                    strBarcodeFormat = "All"
                End If
                Dim aryResult As BarcodeResult() = Nothing
                aryResult = reader.DecodeBitmap(m_ImageCore.ImageBuffer.GetBitmap(CShort(i)))
                If i = 0 Then
                    If aryResult IsNot Nothing Then
                        If aryResult.Length <> 0 Then
                            bHasBarcodeOnFirstImage = True
                        End If
                    End If
                End If

                If aryResult Is Nothing OrElse (aryResult IsNot Nothing AndAlso aryResult.Length = 0) Then
                    'If no barcode found on the current image, add it to the image list for saving
                    listIndex.Add(CShort(i))
                Else
                    m_listBarcodeType.Add(aryResult(0).BarcodeText)
                    If listIndex IsNot Nothing AndAlso listIndex.Count > 0 Then
                        listImageIndex.Add(listIndex)
                        listIndex = Nothing
                    End If

                    'If a barcode is found, restart the list
                    If listIndex Is Nothing Then
                        listIndex = New List(Of Short)()
                    End If
                    listIndex.Add(CShort(i))
                End If
            Next

            If listIndex IsNot Nothing Then
                listImageIndex.Add(listIndex)
                'save a last set of data
                listIndex = Nothing
            End If

            SaveImages(listImageIndex)
        Catch exp As Exception
            MessageBox.Show(exp.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    

    Private Sub btnRemoveAllImage_Click(sender As Object, e As EventArgs) Handles btnRemoveAllImage.Click
        m_ImageCore.ImageBuffer.RemoveAllImages()
        dsViewer1.Visible = False
    End Sub

    Private Sub btnRemoveSelectedImages_Click(sender As Object, e As EventArgs) Handles btnRemoveSelectedImages.Click
        m_ImageCore.ImageBuffer.RemoveImages(dsViewer1.CurrentSelectedImageIndicesInBuffer)
        If m_ImageCore.ImageBuffer.HowManyImagesInBuffer = 0 Then
            dsViewer1.Visible = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0 Then
            If Me.radMode1.Checked = True Then
                SaveFileByBegainWithBarcode()
            Else
                SaveFileByBarcodeText()
            End If
        End If
    End Sub

    Private Function SetPDFFileName(FileFolder As String, strBarcodeType As String, strText As String) As String
        Dim iCharindex As Integer = 0
        Dim strBarcodeText As String = strText
        Dim strFullPDFName As String = Nothing
        Dim strPDFName As String = Nothing
        Dim bHasillegalcharacter As Boolean = False
        For Each text As Char In strBarcodeText
            Dim bIsillegalcharacter As Boolean = False

            For Each temp As Char In System.IO.Path.GetInvalidFileNameChars()
                If text = temp Then
                    bIsillegalcharacter = True
                    bHasillegalcharacter = True
                End If
            Next
            If bIsillegalcharacter Then
                strBarcodeText = strBarcodeText.Remove(iCharindex, 1)
                iCharindex -= 1
            End If
            iCharindex += 1
        Next
        strFullPDFName = strBarcodeType & "-" & strBarcodeText
        Dim i As Integer = 2
        Dim FilePath As String = FileFolder & "\" & strFullPDFName & ".pdf"
        While System.IO.File.Exists(FilePath)
            strFullPDFName = String.Format(strBarcodeType & "-" & strBarcodeText & "({0})", i)
            FilePath = FileFolder & "\" & strFullPDFName & ".pdf"
            i += 1
        End While

        If bHasillegalcharacter Then
            Dim fSetFileNameForm As New SeparateDocumentByBarcode.Form2(FileFolder, strFullPDFName)
            fSetFileNameForm.ShowDialog()
            strPDFName = FileFolder & "\\" & fSetFileNameForm.GetPDfFileName()
        Else
            strPDFName = FileFolder & "\" & strFullPDFName & ".pdf"
        End If


        Return strPDFName
    End Function

#Region "IAcquireCallback Members"

    Public Sub OnPostAllTransfers() Implements IAcquireCallback.OnPostAllTransfers
    End Sub

    Public Function OnPostTransfer(bit As Bitmap) As Boolean Implements IAcquireCallback.OnPostTransfer
        m_ImageCore.IO.LoadImage(bit)
        Return True
    End Function

    Public Sub OnPreAllTransfers() Implements IAcquireCallback.OnPreAllTransfers
    End Sub

    Public Function OnPreTransfer() As Boolean Implements IAcquireCallback.OnPreTransfer
        Return True
    End Function

    Public Sub OnSourceUIClose() Implements IAcquireCallback.OnSourceUIClose
    End Sub

    Public Sub OnTransferCancelled() Implements IAcquireCallback.OnTransferCancelled
    End Sub

    Public Sub OnTransferError() Implements IAcquireCallback.OnTransferError
    End Sub

#End Region

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        m_TwainManager.Dispose()
    End Sub

    Private Sub btnScan_Click(sender As Object, e As EventArgs) Handles btnScan.Click
        Dim tempList As New List(Of String)()
        For i As Integer = 0 To m_TwainManager.SourceCount - 1
            tempList.Add(m_TwainManager.SourceNameItems(CShort(i)))
        Next
        Dim tempSourceListWrapper As New SourceListWrapper(tempList)

        Dim iSelectIndex As Integer = tempSourceListWrapper.SelectSource()
        If iSelectIndex = -1 Then
            Return
        End If
        m_TwainManager.SelectSourceByIndex(CShort(iSelectIndex))
        m_TwainManager.OpenSource()
        m_TwainManager.IfAutoFeed = True
        m_TwainManager.IfFeederEnabled = True
        m_TwainManager.IfShowUI = False
        m_TwainManager.AcquireImage(TryCast(Me, IAcquireCallback))
        dsViewer1.Visible = True
    End Sub
End Class
