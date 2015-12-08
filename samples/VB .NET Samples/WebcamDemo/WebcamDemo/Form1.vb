Imports Dynamsoft.DotNet.TWAIN.Enums
Public Class Form1

    Private designWidth As Int32
    Private m_iRotate As Integer = 0

    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dynamicDotNetTwain1.LicenseKeys = "BAF81AB5515958BF519F7AAE2A318B3B;BAF81AB5515958BF6DA4299CBA3CC11D;BAF81AB5515958BF9C195A4722534974;BAF81AB5515958BFE96B7433DD28E75B;BAF81AB5515958BF3DBAF9AB37059787;BAF81AB5515958BF5291EEE0B030BD82"
        dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_WEBCAM
        Me.chkContainer.Checked = False
        Me.chkFocusArea.Checked = False


    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles Me.Load
        Try
            designWidth = Me.Width
            AddHandler chkContainer.CheckedChanged, AddressOf chkContainer_CheckedChanged
            chkContainer.Checked = True

            Dim i As Int16 : i = 0
            For i = 0 To dynamicDotNetTwain1.SourceCount - 1 Step 1
                Dim strSourceName As String : strSourceName = dynamicDotNetTwain1.SourceNameItems(i)
                If strSourceName IsNot Nothing Then
                    cbxSources.Items.Add(strSourceName)
                End If
            Next i

            For i = 0 To 3
                Dim sRotateType As String = (90 * i).ToString + "°"
                cbxRotateType.Items.Add(sRotateType)
            Next
            cbxRotateType.SelectedIndex = 0
            AddHandler cbxSources.SelectedIndexChanged, AddressOf cbxSources_SelectedIndexChanged
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

    Private Sub cbxSources_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        If (cbxSources.SelectedIndex >= 0 And cbxSources.SelectedIndex < dynamicDotNetTwain1.SourceCount) Then
            dynamicDotNetTwain1.SelectSourceByIndex(cbxSources.SelectedIndex)
            m_iRotate = 0
            cbxRotateType.SelectedIndex = 0
            If (cbxRotateType.SelectedIndex >= 0) Then
                m_iRotate = m_iRotate + cbxRotateType.SelectedIndex
                dynamicDotNetTwain1.RotateVideo(m_iRotate)
                dynamicDotNetTwain1.OpenSource()
                ResizeVideoWindow(m_iRotate)
            End If
        End If
    End Sub

    Private Sub btnCaptureImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCaptureImage.Click
        Try

            If dynamicDotNetTwain1.SourceCount > 0 Then
                dynamicDotNetTwain1.AcquireImage()
            Else
                MessageBox.Show("No webcam source detected!")
            End If
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try
    End Sub

    Private Sub chkContainer_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not chkContainer.Checked Then
            lbContainer.Visible = False
            Panel1.Visible = False
            Me.Width = designWidth - Me.Panel1.Width - 15
            dynamicDotNetTwain1.SetVideoContainer(Nothing)
        Else
            lbContainer.Visible = True
            Panel1.Visible = True
            Me.Width = designWidth 'Me.Width + Me.pictureBox1.Width + 20
            dynamicDotNetTwain1.SetVideoContainer(pictureBox1)
        End If
        ResizeVideoWindow(m_iRotate)
    End Sub

    Private Sub chkFocusArea_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFocusArea.CheckedChanged
        If (chkFocusArea.Checked) Then
            chkContainer.Checked = True
            chkContainer.Enabled = False
            AddHandler pictureBox1.MouseClick, AddressOf pictureBox1_MouseClick
        Else
            RemoveHandler pictureBox1.MouseClick, AddressOf pictureBox1_MouseClick
            chkContainer.Enabled = True
        End If
    End Sub

    Private Sub pictureBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim rectArea As Rectangle = New Rectangle(e.Location.X - 25, e.Location.Y - 25, 50, 50)
        dynamicDotNetTwain1.FocusOnArea(rectArea)
    End Sub

    Private Sub cbxRotateType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxRotateType.SelectedIndexChanged
        If (cbxRotateType.SelectedIndex >= 0) Then
            m_iRotate = m_iRotate + cbxRotateType.SelectedIndex
            dynamicDotNetTwain1.RotateVideo(CType(System.Enum.Parse(GetType(Dynamsoft.DotNet.TWAIN.Enums.EnumVideoRotateType), Val(cbxRotateType.SelectedIndex)), Dynamsoft.DotNet.TWAIN.Enums.EnumVideoRotateType))
            ResizeVideoWindow(m_iRotate)
        End If
    End Sub

    Private Sub ResizeVideoWindow(ByVal iRotate As Integer)
        If (chkContainer.Checked) Then
            Dim camResolution As Dynamsoft.DotNet.TWAIN.WebCamera.CamResolution = dynamicDotNetTwain1.ResolutionForCam
            If (Not camResolution Is Nothing) Then
                If (camResolution.Width > 0 And camResolution.Height > 0) Then
                    If (iRotate Mod 2 = 0) Then
                        Dim iVideoWidth = pictureBox1.Width
                        Dim iVideoHeight = pictureBox1.Width * camResolution.Height / camResolution.Width
                        Dim iContentHeight As Integer : iContentHeight = Panel1.Height - Panel1.Margin.Top - Panel1.Margin.Bottom - Panel1.Padding.Top - Panel1.Padding.Bottom
                        If (iVideoHeight < iContentHeight) Then
                            dynamicDotNetTwain1.ResizeVideoWindow(0, (iContentHeight - iVideoHeight) / 2, iVideoWidth, iVideoHeight)
                        Else
                            dynamicDotNetTwain1.ResizeVideoWindow(0, 0, pictureBox1.Width, pictureBox1.Height)
                        End If
                    Else
                        Dim iVideoHeight = pictureBox1.Height
                        Dim iVideoWidth = pictureBox1.Height * camResolution.Height / camResolution.Width
                        Dim iContentWidth As Integer : iContentWidth = Panel1.Height - Panel1.Margin.Right - Panel1.Margin.Left - Panel1.Padding.Right - Panel1.Padding.Left
                        If (iVideoWidth < iContentWidth) Then
                            dynamicDotNetTwain1.ResizeVideoWindow((iContentWidth - iVideoWidth) / 2, 0, iVideoWidth, iVideoHeight)
                        Else
                            dynamicDotNetTwain1.ResizeVideoWindow(0, 0, pictureBox1.Width, pictureBox1.Height)
                        End If
                    End If
                End If
            End If
        Else
            dynamicDotNetTwain1.ResizeVideoWindow(0, 0, -1, -1)
        End If
    End Sub
End Class
