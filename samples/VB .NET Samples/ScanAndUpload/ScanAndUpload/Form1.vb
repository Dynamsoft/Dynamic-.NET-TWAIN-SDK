Imports Dynamsoft.TWAIN
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Dynamsoft.TWAIN.Interface
Imports Dynamsoft.Core
Imports Dynamsoft.PDF
Imports Dynamsoft.Core.Enums
Imports System.Runtime.InteropServices
Imports System.IO



Partial Public Class Form1
    Inherits Form
    Implements IAcquireCallback
    Implements ISave
    Private m_TwainManager As TwainManager = Nothing
    Private m_ImageCore As ImageCore = Nothing
    Private m_strServerName As String = "www.dynamsoft.com"
    Private m_strPort As String = "80"
    Private m_strActionPage As String = "/demo/DNT/SaveToDB.aspx"
    Private m_StrProductKey As String

    Public Sub New()
        InitializeComponent()
        m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU="
        m_TwainManager = New TwainManager(m_StrProductKey)
        m_ImageCore = New ImageCore()
        dsViewer1.Bind(m_ImageCore)
        Me.txtboxServer.Text = m_strServerName
        Me.txtboxPort.Text = m_strPort
        Me.txtboxActionPage.Text = m_strActionPage
        Me.txtboxFileName.Text = "DNT_Image"
        Me.rdbtnJPEG.Checked = True
        Me.chkboxMultiPage.Enabled = False

        Dim lngNum As Integer
        m_TwainManager.OpenSourceManager()
        For lngNum = 0 To m_TwainManager.SourceCount - 1
            ' display the available imaging devices
            cmbSource.Items.Add(m_TwainManager.SourceNameItems(Convert.ToInt16(lngNum)))
        Next
        If lngNum > 0 Then
            cmbSource.SelectedIndex = 0
        End If
    End Sub



    Private Sub btnScan_Click(sender As Object, e As EventArgs)
        m_ImageCore.ImageBuffer.IfAppendImage = True
        AcquireImage()
    End Sub

    Private Sub AcquireImage()
        Try
            m_TwainManager.SelectSourceByIndex(Convert.ToInt16(cmbSource.SelectedIndex))
            m_TwainManager.IfShowUI = chkboxIfShowUI.Checked
            m_TwainManager.OpenSource()
            m_TwainManager.IfDisableSourceAfterAcquire = True

            m_TwainManager.IfShowUI = chkboxIfShowUI.Checked

            m_TwainManager.AcquireImage(TryCast(Me, IAcquireCallback))
        Catch exp As Exception
            Me.txtboxErrMessage.AppendText(exp.Message)
            Me.txtboxErrMessage.AppendText(vbCr & vbLf)
        End Try

    End Sub

    Private Sub dynamicDotNetTwain1_OnMouseClick(sImageIndex As Short)
        m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer = sImageIndex
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs)
        Try
            Dim strImageName As String = ""
            Dim strHTTPServer As String = Me.txtboxServer.Text
            ' the name or the IP of your HTTP Server
            If strHTTPServer = "" Then
                Me.txtboxErrMessage.AppendText("The HTTP server cannot be empty." & vbCr & vbLf)
                Return
            End If
            If txtboxPort.Text = "" Then
                Me.txtboxErrMessage.AppendText("The HTTP port cannot be empty." & vbCr & vbLf)
                Return
            Else
                Try
                    'the port number of the HTTP Server
                    m_ImageCore.Net.HTTPPort = Integer.Parse(txtboxPort.Text)
                Catch
                    Me.txtboxErrMessage.AppendText("Invalid HTTP port." & vbCr & vbLf)
                    Return
                End Try
            End If
            Dim strActionPage As String = Me.txtboxActionPage.Text
            ' receive the uploaded images on the server side
            If strActionPage = "" Then
                Me.txtboxErrMessage.AppendText("The action page cannot be empty." & vbCr & vbLf)
                Return
            End If
            Dim strFileName As String = Me.txtboxFileName.Text
            If strFileName = "" Then
                Me.txtboxErrMessage.AppendText("The file name cannot be empty." & vbCr & vbLf)
                Return
            End If

            m_ImageCore.Net.HTTPUserName = Me.txtboxName.Text
            'user name for logging into HTTP Server
            m_ImageCore.Net.HTTPPassword = Me.txtboxPwd.Text
            m_ImageCore.Net.SetHTTPFormField("ExtraTxt", Me.txtboxExtraTxt.Text)
            ' pass extra text parameters when uploading image

            Dim tempImageIndexList As New List(Of Short)()
            tempImageIndexList.Add(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
            If rdbtnJPEG.Checked Then
                strImageName = strFileName & ".jpg"

                m_ImageCore.Net.HTTPUploadThroughPost(strHTTPServer, strActionPage, strImageName, tempImageIndexList, Dynamsoft.Core.Enums.EnumImageFileFormat.WEBTW_JPG)
            End If
            If rdbtnPNG.Checked Then
                strImageName = strFileName & ".png"
                m_ImageCore.Net.HTTPUploadThroughPost(strHTTPServer, strActionPage, strImageName, tempImageIndexList, Dynamsoft.Core.Enums.EnumImageFileFormat.WEBTW_PNG)
            End If
            If rdbtnPDF.Checked Then
                strImageName = strFileName & ".pdf"
                Dim tempCreator As New PDFCreator(m_StrProductKey)
                Dim tempPDFBytes As [Byte]() = tempCreator.SaveAsBytes(TryCast(Me, ISave))
                m_ImageCore.Net.HTTPUploadThroughPost(strHTTPServer, strActionPage, strImageName, tempPDFBytes)
            End If
            If rdbtnTIFF.Checked Then
                strImageName = strFileName & ".tif"
                If chkboxMultiPage.Checked Then
                    tempImageIndexList.Clear()
                    For i As Short = 0 To m_ImageCore.ImageBuffer.HowManyImagesInBuffer - 1
                        tempImageIndexList.Add(i)
                    Next
                    m_ImageCore.Net.HTTPUploadThroughPost(strHTTPServer, strActionPage, strImageName, tempImageIndexList, Dynamsoft.Core.Enums.EnumImageFileFormat.WEBTW_TIF)
                Else
                    m_ImageCore.Net.HTTPUploadThroughPost(strHTTPServer, strActionPage, strImageName, tempImageIndexList, Dynamsoft.Core.Enums.EnumImageFileFormat.WEBTW_TIF)
                End If
            End If
            If m_ImageCore.Net.HTTPPostResponseString = "" Then
                Me.txtboxErrMessage.AppendText("Image uploaded to DB successfully. " & vbCr & vbLf)
                If strHTTPServer.Trim().ToLower().CompareTo(m_strServerName.Trim().ToLower()) = 0 AndAlso txtboxPort.Text.Trim().ToLower().CompareTo(m_strPort.Trim().ToLower()) = 0 AndAlso strActionPage.Trim().ToLower().CompareTo(m_strActionPage.Trim().ToLower()) = 0 Then
                    Dim objSuccessInfo As New SuccessInfo(strImageName)
                    objSuccessInfo.ShowDialog()
                End If
            Else
                Me.txtboxErrMessage.AppendText("Image uploaded to DB unsuccessfully. You can check DynamicDotNetTwain.HTTPPostResponseString for more information. " & vbCr & vbLf)
            End If
        Catch exp As Exception
            Me.txtboxErrMessage.AppendText(exp.Message)
            Me.txtboxErrMessage.AppendText(vbCr & vbLf)
        End Try
    End Sub

    Private Sub rdbtnPDF_CheckedChanged(sender As Object, e As EventArgs)
        If rdbtnPDF.Checked Then
            Me.chkboxMultiPage.Enabled = True
            Me.chkboxMultiPage.Checked = True
        Else
            Me.chkboxMultiPage.Enabled = False
            Me.chkboxMultiPage.Checked = False
        End If
    End Sub

    Private Sub rdbtnTIFF_CheckedChanged(sender As Object, e As EventArgs)
        If rdbtnTIFF.Checked Then
            Me.chkboxMultiPage.Enabled = True
            Me.chkboxMultiPage.Checked = True
        Else
            Me.chkboxMultiPage.Enabled = False
            Me.chkboxMultiPage.Checked = False
        End If
    End Sub

    Private Sub txtboxServer_TextChanged(sender As Object, e As EventArgs)
        Dim strHTTPServer As String = Me.txtboxServer.Text
        If strHTTPServer.Trim().ToLower().CompareTo(m_strServerName.Trim().ToLower()) = 0 Then
            lbNote.Visible = True
        Else
            lbNote.Visible = False
        End If
    End Sub

    Public Sub OnPostAllTransfers() Implements IAcquireCallback.OnPostAllTransfers
    End Sub

    Public Function OnPostTransfer(bit As Bitmap) As Boolean Implements IAcquireCallback.OnPostTransfer
        m_ImageCore.IO.LoadImage(bit)
		TextBox.CheckForIllegalCrossThreadCalls = False
        Me.txtboxErrMessage.AppendText("Image acquired successfully. " & vbCr & vbLf)
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

    Public Function GetAnnotations(iPageNumber As Integer) As Object Implements ISave.GetAnnotations
        If chkboxMultiPage.Checked Then
            Return m_ImageCore.ImageBuffer.GetMetaData(CShort(iPageNumber), EnumMetaDataType.enumAnnotation)
        Else
            Return m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation)
        End If

    End Function

    Public Function GetImage(iPageNumber As Integer) As Bitmap Implements ISave.GetImage
        If chkboxMultiPage.Checked Then
            Return m_ImageCore.ImageBuffer.GetBitmap(CShort(iPageNumber))
        Else
            Return m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
        End If

    End Function

    Public Function GetPageCount() As Integer Implements ISave.GetPageCount
        If chkboxMultiPage.Checked Then
            Return m_ImageCore.ImageBuffer.HowManyImagesInBuffer
        Else
            Return 1
        End If
    End Function

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs)
        Me.m_TwainManager.Dispose()
    End Sub
End Class
