Imports Dynamsoft.DotNet.TWAIN.Enums
Public Class Form1

    Private designWidth As Int32

    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_WEBCAM
        Me.chkContainer.Checked = True

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles Me.Load
        Try
            designWidth = Me.Width
            AddHandler chkContainer.CheckedChanged, AddressOf chkContainer_CheckedChanged
            chkContainer.Checked = False

            Dim i As Int16 : i = 0
            For i = 0 To dynamicDotNetTwain1.SourceCount - 1 Step 1
                Dim strSourceName As String : strSourceName = dynamicDotNetTwain1.SourceNameItems(i)
                If strSourceName IsNot Nothing Then
                    cbxSources.Items.Add(strSourceName)
                End If
            Next i

            If cbxSources.Items.Count > 0 Then
                cbxSources.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnRemoveAllImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllImages.Click
        dynamicDotNetTwain1.RemoveAllImages()
    End Sub

    Private Sub cbxSources_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbxSources.SelectedIndexChanged
        If (cbxSources.SelectedIndex >= 0 And cbxSources.SelectedIndex < dynamicDotNetTwain1.SourceCount) Then
            dynamicDotNetTwain1.SelectSourceByIndex(cbxSources.SelectedIndex)
            dynamicDotNetTwain1.OpenSource()
        End If
    End Sub

    Private Sub btnCaptureImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCaptureImage.Click
        Try

            If dynamicDotNetTwain1.SourceCount > 0 Then
                dynamicDotNetTwain1.IfShowUI = True
                If chkContainer.Checked Then
                    Dim camResolution As Dynamsoft.DotNet.TWAIN.WebCamera.CamResolution : camResolution = dynamicDotNetTwain1.ResolutionForCam
                    If camResolution IsNot Nothing And camResolution.Width > 0 And camResolution.Height > 0 Then
                        pictureBox1.Height = pictureBox1.Width * camResolution.Height / camResolution.Width
                        Dim iContentHeight As Integer : iContentHeight = Panel1.Height - Panel1.Margin.Top - Panel1.Margin.Bottom - Panel1.Padding.Top - Panel1.Padding.Bottom
                        If pictureBox1.Height < iContentHeight Then
                            pictureBox1.Location = New Point(pictureBox1.Location.X, (iContentHeight - pictureBox1.Height) / 2)
                        Else
                            pictureBox1.Location = New Point(pictureBox1.Location.X, 0)
                        End If
                    End If

                    dynamicDotNetTwain1.SetVideoContainer(Me.pictureBox1)
                Else
                    dynamicDotNetTwain1.SetVideoContainer(Nothing)
                End If

                dynamicDotNetTwain1.EnableSource()
            Else
                MessageBox.Show("No webcam source detected!")
            End If
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try
    End Sub

    'Private Sub chkIfShowUI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    chkContainer.Enabled = chkIfShowUI.Checked
    'End Sub

    Private Sub chkContainer_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not chkContainer.Checked Then
            lbContainer.Visible = False
            Panel1.Visible = False
            Me.Width = designWidth - Me.Panel1.Width - 15
        Else
            lbContainer.Visible = True
            Panel1.Visible = True
            Me.Width = designWidth 'Me.Width + Me.pictureBox1.Width + 20
        End If
    End Sub
End Class
