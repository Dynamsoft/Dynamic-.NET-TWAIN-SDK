Imports Dynamsoft.DotNet.TWAIN
Imports Dynamsoft.DotNet.TWAIN.Enums
Imports System.Drawing
Imports System.Windows
Namespace WpfWebcamDemo
    Partial Public Class Window1
        Inherits Window
        Private m_iRotate As Integer

        Public Sub New()
            InitializeComponent()
            Me.dynamicDotNetTwain1.LicenseKeys = "BAF81AB5515958BF519F7AAE2A318B3B;BAF81AB5515958BF6DA4299CBA3CC11D;BAF81AB5515958BF9C195A4722534974;BAF81AB5515958BFE96B7433DD28E75B;BAF81AB5515958BF3DBAF9AB37059787;BAF81AB5515958BF5291EEE0B030BD82"
            Me.ResizeMode = System.Windows.ResizeMode.CanMinimize
            Me.dynamicDotNetTwain1.IfShowUI = True
            Me.chkContainer.IsChecked = False
            Me.dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_WEBCAM
            cbxSources.SelectedIndex = 0
        End Sub

        Private Sub btnCaptureImage_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Try

                If (cbxSources.Items.Count > 0) Then
                    dynamicDotNetTwain1.AcquireImage()
                Else
                MessageBox.Show("No webcam source detected!")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

        Private Sub btnRemoveAllImage_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            dynamicDotNetTwain1.RemoveAllImages()
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Try
                Me.chkContainer.IsChecked = True
                Dim i As Short
                For i = 0 To dynamicDotNetTwain1.SourceCount - 1
                    Dim SourceCountName = dynamicDotNetTwain1.SourceNameItems(i)
                    If (SourceCountName Is Nothing) Then
                    Else
                        cbxSources.Items.Add(SourceCountName)
                    End If
                Next
                If (cbxSources.Items.Count > 0) Then
                    cbxSources.SelectedIndex = 0
                End If
                For i = 0 To 3
                    Dim sRotateType As String = (90 * i).ToString + "°"
                    cbxRotateType.Items.Add(sRotateType)
                Next
                cbxRotateType.SelectedIndex = 0
            Catch exp As Exception
            End Try
        End Sub

        Private Sub cbxSources_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbxSources.SelectionChanged
            If (cbxSources.SelectedIndex >= 0& & cbxSources.SelectedIndex < dynamicDotNetTwain1.SourceCount) Then
                dynamicDotNetTwain1.SelectSourceByIndex(cbxSources.SelectedIndex)
                m_iRotate = 0
                dynamicDotNetTwain1.RotateVideo(EnumVideoRotateType.Rotate_0)
                dynamicDotNetTwain1.OpenSource()
                ResizeVideoWindow(m_iRotate)
            End If
        End Sub

        Private Sub chkContainer_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles chkContainer.Checked
            dynamicDotNetTwain1.SetVideoContainer(image1)
            ResizeVideoWindow(m_iRotate)
        End Sub

        Private Sub chkContainer_Unchecked(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles chkContainer.Unchecked
            dynamicDotNetTwain1.SetVideoContainer(Nothing)
        End Sub

        Private Sub ResizeVideoWindow(ByVal iRotate As Integer)
            If (chkContainer.IsChecked = True) Then
                Dim camResolution As Dynamsoft.DotNet.TWAIN.WebCamera.CamResolution = dynamicDotNetTwain1.ResolutionForCam
                If ((camResolution Is Nothing)) Then
                Else
                    If (camResolution.Width > 0 And camResolution.Height > 0) Then
                        If (iRotate Mod 2 = 0) Then
                            Dim iVideoWidth As Double = border1.Width
                            Dim iVideoHeight As Double = border1.Width * camResolution.Height / camResolution.Width
                            If (iVideoHeight < border1.ActualHeight) Then
                                image1.Width = border1.Width
                                image1.Height = iVideoHeight
                                image1.Margin = New Thickness(0, (border1.ActualHeight - iVideoHeight) / 2, 0, 0)
                            End If
                        Else
                            Dim iVideoHeight As Double = border1.Height
                            Dim iVideoWidth As Double = border1.Height * camResolution.Height / camResolution.Width
                            If (iVideoWidth < border1.Width) Then
                                image1.Height = border1.Height
                                image1.Width = iVideoWidth
                                image1.Margin = New Thickness((border1.ActualWidth - iVideoWidth) / 2, 0, 0, 0)
                            End If
                        End If
                    End If
                End If
            End If


        End Sub

        Private Sub image1_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs) Handles image1.MouseLeftButtonDown
            If (chkFocus.IsChecked) Then
                chkContainer.IsChecked = True
                chkContainer.IsEnabled = False
                Dim wpFocus As System.Windows.Point = e.GetPosition(e.Source)
                Dim rectRect As System.Windows.Rect = New System.Windows.Rect(wpFocus.X - 25, wpFocus.Y - 25, 50, 50)
                dynamicDotNetTwain1.FocusOnArea(rectRect)
            Else
                chkContainer.IsEnabled = True
            End If
        End Sub

        Private Sub chkFocus_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles chkFocus.Checked
            chkContainer.IsChecked = True
            chkContainer.IsEnabled = False
        End Sub

        Private Sub chkFocus_Unchecked(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles chkFocus.Unchecked
            chkContainer.IsEnabled = True
        End Sub

        Private Sub cbxRotateType_DropDownClosed(sender As Object, e As EventArgs) Handles cbxRotateType.DropDownClosed
            m_iRotate = m_iRotate + cbxRotateType.SelectedIndex
            dynamicDotNetTwain1.RotateVideo(CType(System.Enum.Parse(GetType(Dynamsoft.DotNet.TWAIN.Enums.EnumVideoRotateType), Val(cbxRotateType.SelectedIndex)), Dynamsoft.DotNet.TWAIN.Enums.EnumVideoRotateType))
            ResizeVideoWindow(m_iRotate)
        End Sub
    End Class
End Namespace
