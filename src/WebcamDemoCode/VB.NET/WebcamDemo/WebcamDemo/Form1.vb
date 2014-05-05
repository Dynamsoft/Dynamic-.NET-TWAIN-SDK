Imports Dynamsoft.DotNet.TWAIN.Enums
Public Class Form1

    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.chkIfShowUI.Checked = False
        dynamicDotNetTwain1.IfShowUI = False
        Me.chkContainer.Checked = False
        radioWebCam.Checked = True
        dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_WEBCAM

        chkContainer.Enabled = chkIfShowUI.Checked
    End Sub

    Private Sub btnRemoveAllImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllImages.Click
        If (Me.chkIfThrowException.Checked) Then
            dynamicDotNetTwain1.IfThrowException = True
        Else
            dynamicDotNetTwain1.IfThrowException = False
        End If

        dynamicDotNetTwain1.RemoveAllImages()
    End Sub

    Private Sub radioTwain_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioTwain.CheckedChanged
        If radioTwain.Checked = True Then
            radioWebCam.Checked = False
            radioAll.Checked = False
        End If
    End Sub

    Private Sub radioWebCam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioWebCam.CheckedChanged
        If radioWebCam.Checked = True Then
            radioTwain.Checked = False
            radioAll.Checked = False
        End If
    End Sub

    Private Sub radioAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioAll.CheckedChanged
        If radioAll.Checked = True Then
            radioWebCam.Checked = False
            radioTwain.Checked = False
        End If
    End Sub

    Private Sub btnSelectSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectSource.Click
        Try
            If radioTwain.Checked Then
                dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_TWAIN
            ElseIf radioWebCam.Checked Then
                dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_WEBCAM
            ElseIf radioAll.Checked Then
                dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_ALL
            End If
            'short count = dynamicDotNetTwain1.SourceCount;
            'string name = dynamicDotNetTwain1.SourceNameItems(0);
            If (Me.chkIfThrowException.Checked) Then
                dynamicDotNetTwain1.IfThrowException = True
            Else
                dynamicDotNetTwain1.IfThrowException = False
            End If

            dynamicDotNetTwain1.SelectSource()
            Dim en As EnumSupportedDeviceType
            en = dynamicDotNetTwain1.SupportedDeviceType

            If chkIfShowUI.Checked Then
                dynamicDotNetTwain1.IfShowUI = True
            Else
                dynamicDotNetTwain1.IfShowUI = False
            End If
            dynamicDotNetTwain1.OpenSource()
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try
    End Sub

    Private Sub btnAcquireSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcquireSource.Click
        Try
            If (Me.chkIfThrowException.Checked) Then
                dynamicDotNetTwain1.IfThrowException = True
            Else
                dynamicDotNetTwain1.IfThrowException = False
            End If

            If chkIfShowUI.Checked Then
                dynamicDotNetTwain1.IfShowUI = True
                If chkContainer.Checked Then
                    dynamicDotNetTwain1.SetVideoContainer(Me.pictureBox1)
                Else
                    dynamicDotNetTwain1.SetVideoContainer(Nothing)
                End If
            Else
                dynamicDotNetTwain1.IfShowUI = False
                dynamicDotNetTwain1.SetVideoContainer(Nothing)
            End If
            dynamicDotNetTwain1.EnableSource()
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try
    End Sub

    Private Sub chkIfShowUI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIfShowUI.CheckedChanged
        chkContainer.Enabled = chkIfShowUI.Checked
    End Sub
End Class
