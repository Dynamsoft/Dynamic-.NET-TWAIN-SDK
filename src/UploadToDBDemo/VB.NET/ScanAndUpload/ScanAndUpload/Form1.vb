Public Class Form1
    Dim m_strServerName, m_strPort, m_strActionPage As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_strServerName = "www.dynamsoft.com"
        m_strPort = "80"
        m_strActionPage = "/demo/DNT/SaveToDB.aspx"
        Me.txtboxServer.Text = m_strServerName
        Me.txtboxPort.Text = m_strPort
        Me.txtboxActionPage.Text = m_strActionPage
        Me.txtboxFileName.Text = "DNT_Image"
        Me.rdbtnJPEG.Checked = True
        Me.chkboxMultiPage.Enabled = False

        dynamicDotNetTwain1.ScanInNewThread = False
        dynamicDotNetTwain1.SupportedDeviceType = Dynamsoft.DotNet.TWAIN.Enums.EnumSupportedDeviceType.SDT_ALL ' enable capturing images from both scanners and webcams
        Dim lngNum As Integer
        dynamicDotNetTwain1.OpenSourceManager()
        For lngNum = 0 To dynamicDotNetTwain1.SourceCount - 1
            cmbSource.Items.Add(dynamicDotNetTwain1.SourceNameItems(Convert.ToInt16(lngNum))) ' display the available imaging devices
        Next

        If (lngNum > 0) Then
            cmbSource.SelectedIndex = 0
        End If

    End Sub

    Private Sub btnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScan.Click
        dynamicDotNetTwain1.IfAppendImage = True
        AcquireImage() ' acquire images
    End Sub

    Private Sub AcquireImage()
        Try
            dynamicDotNetTwain1.SelectSourceByIndex(Convert.ToInt16(cmbSource.SelectedIndex))
            dynamicDotNetTwain1.IfShowUI = chkboxIfShowUI.Checked
            dynamicDotNetTwain1.OpenSource()
            dynamicDotNetTwain1.IfDisableSourceAfterAcquire = True

            dynamicDotNetTwain1.IfShowUI = chkboxIfShowUI.Checked

            Dim result As Boolean
            result = dynamicDotNetTwain1.AcquireImage()
            If (result And dynamicDotNetTwain1.ErrorCode = 0) Then
                Me.txtboxErrMessage.AppendText("Image acquired successfully. " & vbCrLf)
            Else
                Me.txtboxErrMessage.AppendText(dynamicDotNetTwain1.ErrorString & vbCrLf)
            End If
        Catch ex As Exception
            Me.txtboxErrMessage.AppendText(ex.Message & vbCrLf)
        End Try

    End Sub
       

    Private Sub dynamicDotNetTwain1_OnMouseClick(ByVal sImageIndex As System.Int16) Handles dynamicDotNetTwain1.OnMouseClick
        dynamicDotNetTwain1.CurrentImageIndexInBuffer = sImageIndex
    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Try
            Dim strImageName, strActionPage, strFileName, strHTTPServer As String
            strImageName = ""
            strHTTPServer = Me.txtboxServer.Text ' the name or the IP of your HTTP Server
            If strHTTPServer = "" Then
                Me.txtboxErrMessage.AppendText("The HTTP server cannot be empty." & vbCrLf)
                Return
            End If
            If txtboxPort.Text = "" Then
                Me.txtboxErrMessage.AppendText("The HTTP port cannot be empty." & vbCrLf)
                Return
            Else
                Try
                    dynamicDotNetTwain1.HTTPPort = Integer.Parse(txtboxPort.Text)  'the port number of the HTTP Server
                Catch ex As Exception
                    Me.txtboxErrMessage.AppendText("The HTTP port cannot be empty." & vbCrLf)
                    Return
                End Try
            End If
            strActionPage = Me.txtboxActionPage.Text  ' receive the uploaded images on the server side
            If strActionPage = "" Then
                Me.txtboxErrMessage.AppendText("The action page cannot be empty." & vbCrLf)
                Return
            End If
            strFileName = Me.txtboxFileName.Text
            If strFileName = "" Then
                Me.txtboxErrMessage.AppendText("The file name cannot be empty." & vbCrLf)
                Return
            End If
            dynamicDotNetTwain1.HTTPUserName = Me.txtboxName.Text 'user name for logging into HTTP Server
            dynamicDotNetTwain1.HTTPPassword = Me.txtboxPwd.Text
            dynamicDotNetTwain1.SetHTTPFormField("ExtraTxt", Me.txtboxExtraTxt.Text) ' pass extra text parameters when uploading image

            If (rdbtnJPEG.Checked) Then
                strImageName = strFileName + ".jpg"
                dynamicDotNetTwain1.HTTPUploadThroughPostEx(strHTTPServer, dynamicDotNetTwain1.CurrentImageIndexInBuffer, strActionPage, strImageName, Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_JPG)

            End If

            If (rdbtnPNG.Checked) Then
                strImageName = strFileName + ".png"
                dynamicDotNetTwain1.HTTPUploadThroughPostEx(strHTTPServer, dynamicDotNetTwain1.CurrentImageIndexInBuffer, strActionPage, strImageName, Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_PNG)
            End If

            If (rdbtnPDF.Checked) Then
                strImageName = strFileName + ".pdf"
                If (chkboxMultiPage.Checked) Then
                    dynamicDotNetTwain1.HTTPUploadAllThroughPostAsPDF(strHTTPServer, strActionPage, strImageName) ' save the captured images as a multi-page PDF file
                Else
                    dynamicDotNetTwain1.HTTPUploadThroughPostEx(strHTTPServer, dynamicDotNetTwain1.CurrentImageIndexInBuffer, strActionPage, strImageName, Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_PDF)
                End If
            End If

            If (rdbtnTIFF.Checked) Then
                strImageName = strFileName + ".tif"
                If (chkboxMultiPage.Checked) Then
                    dynamicDotNetTwain1.HTTPUploadAllThroughPostAsMultiPageTIFF(strHTTPServer, strActionPage, strImageName)
                Else
                    dynamicDotNetTwain1.HTTPUploadThroughPostEx(strHTTPServer, dynamicDotNetTwain1.CurrentImageIndexInBuffer, strActionPage, strImageName, Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_TIF)
                End If
            End If

            If (dynamicDotNetTwain1.ErrorCode <> Dynamsoft.DotNet.TWAIN.Enums.ErrorCode.Succeed) Then
                Me.txtboxErrMessage.Text += dynamicDotNetTwain1.ErrorString
                Me.txtboxErrMessage.Text += vbCrLf
            Else
                Me.txtboxErrMessage.AppendText("Image uploaded to DB successfully. " & vbCrLf)
                If (strHTTPServer.Trim().ToLower().CompareTo(m_strServerName.Trim().ToLower()) = 0 And _
                   txtboxPort.Text.Trim().ToLower().CompareTo(m_strPort.Trim().ToLower()) = 0 And _
                   strActionPage.Trim().ToLower().CompareTo(m_strActionPage.Trim().ToLower()) = 0) Then
                    Dim objSuccessInfo As New SuccessInfo()
                    objSuccessInfo.SetSuccessInfo(strImageName)
                    objSuccessInfo.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Me.txtboxErrMessage.AppendText(ex.Message & vbCrLf)
        End Try
    End Sub

    Private Sub rdbtnPDF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbtnPDF.CheckedChanged
        If (rdbtnPDF.Checked) Then
            Me.chkboxMultiPage.Enabled = True
            Me.chkboxMultiPage.Checked = True
        Else
            Me.chkboxMultiPage.Enabled = False
            Me.chkboxMultiPage.Checked = False
        End If
    End Sub

    Private Sub rdbtnTIFF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbtnTIFF.CheckedChanged
        If (rdbtnTIFF.Checked) Then
            Me.chkboxMultiPage.Enabled = True
            Me.chkboxMultiPage.Checked = True
        Else
            Me.chkboxMultiPage.Enabled = False
            Me.chkboxMultiPage.Checked = False
        End If
    End Sub
End Class
