Imports Dynamsoft.DotNet.TWAIN.Wpf
Imports Microsoft.Win32

Namespace WpfControlsDemo
    Partial Public Class ScanWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
            m_twain = Nothing
            Try
                lbScan.Background = New ImageBrush(New BitmapImage(New Uri(Window1.imageDirectory + "normal\\scan_now.png", UriKind.RelativeOrAbsolute)))
            Catch ex As Exception
            End Try
            lbScan.IsEnabled = False
        End Sub

        Private Sub ScanWindow_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
            If m_twain IsNot Nothing Then
                If m_twain.DataSourceStatus = Dynamsoft.DotNet.TWAIN.Enums.TWDataSourceStatus.TWDSS_ACQUIRING Then
                    e.Cancel = True
                    MessageBox.Show("There are some uncompleted scanning tasks. Please wait until the tasks completes.", "WpfControlsDemo", MessageBoxButton.OK, MessageBoxImage.Warning)
                Else
                    m_twain.CloseSource()
                    m_twain.CloseSourceManager()
                End If
            End If
        End Sub

        Private m_twain As Dynamsoft.DotNet.TWAIN.Wpf.DynamicDotNetTwain

        Public WriteOnly Property TWAIN() As DynamicDotNetTwain
            Set(ByVal value As DynamicDotNetTwain)
                m_twain = value
                If (Not m_twain Is Nothing) Then
                    Dim i As Integer
                    For i = 0 To m_twain.SourceCount - 1
                        cbxSources.Items.Add(m_twain.SourceNameItems(CShort(i)))
                    Next
                End If
                If (m_twain.SourceCount > 0) Then
                    cbxSources.SelectedIndex = 0
                    lbScan.IsEnabled = True
                Else
                    MessageBox.Show("There is no scan source!", "Scan Warning", MessageBoxButton.OK, MessageBoxImage.Warning)
                    lbScan.IsEnabled = False
                End If
            End Set
        End Property

        Private Sub lbScan_MouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            Dim key As String : key = "active/" + "scan_now"
            If (Not Window1.icons.ContainsKey(key)) Then
                Try
                    Window1.icons.Add(key, New ImageBrush(New BitmapImage(New Uri(Window1.imageDirectory + key + ".png", UriKind.RelativeOrAbsolute))))
                Catch ex As Exception
                End Try
            End If
            Try
                lbScan.Background = Window1.icons(key)
            Catch ex As Exception
            End Try

            If (Not m_twain Is Nothing) Then
                If Not IsFrameworkSatisfied() Then
                    MessageBox.Show("WPF requires .NET Framework 3.5 SP1 or above. Please upgrade your .NET Framework.", "WpfControlsDemo", MessageBoxButton.OK, MessageBoxImage.Information)
                    Return
                End If
                m_twain.SelectSourceByIndex(cbxSources.SelectedIndex)
                m_twain.OpenSource()
                m_twain.IfDisableSourceAfterAcquire = True
                m_twain.IfShowUI = ckbShowUI.IsChecked.Value
                m_twain.IfFeederEnabled = ckbADF.IsChecked.Value
                m_twain.IfDuplexEnabled = ckbDuplex.IsChecked.Value
                If (rbBW.IsChecked.Value) Then
                    m_twain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_BW
                    m_twain.BitDepth = 1
                ElseIf (rbGrey.IsChecked.Value) Then
                    m_twain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_GRAY
                    m_twain.BitDepth = 8
                ElseIf (rbColorful.IsChecked.Value) Then
                    m_twain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_RGB
                    m_twain.BitDepth = 24
                End If
                m_twain.AcquireImage()
            End If
        End Sub

        Private Sub lbScan_MouseEnter(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim key As String : key = "hover/" + "scan_now"
            If (Not Window1.icons.ContainsKey(key)) Then
                Try
                    Window1.icons.Add(key, New ImageBrush(New BitmapImage(New Uri(Window1.imageDirectory + key + ".png", UriKind.RelativeOrAbsolute))))
                Catch ex As Exception
                End Try
            End If
            Try
                lbScan.Background = Window1.icons(key)
            Catch ex As Exception
            End Try
        End Sub

        Private Sub lbScan_MouseLeave(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim key As String : key = "normal/" + "scan_now"
            If (Not Window1.icons.ContainsKey(key)) Then
                Try
                    Window1.icons.Add(key, New ImageBrush(New BitmapImage(New Uri(Window1.imageDirectory + key + ".png", UriKind.RelativeOrAbsolute))))
                Catch ex As Exception
                End Try
            End If
            Try
                lbScan.Background = Window1.icons(key)
            Catch ex As Exception
            End Try
        End Sub

        Private Function IsFrameworkSatisfied() As Boolean
            Dim iMajorVersion As Integer : iMajorVersion = Environment.Version.Major
            If iMajorVersion = 2 Then
                Dim msKey As RegistryKey : msKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP")
                If msKey.Equals(Nothing) Then
                    Return False
                End If
                Dim netVersion As RegistryKey : netVersion = msKey.OpenSubKey("v3.5")
                If Not netVersion.GetValue("Install") = Nothing Then
                    If netVersion.GetValue("Install").ToString() = "1" Then
                        Dim objSp As Object : objSp = netVersion.GetValue("SP")
                        If (Not objSp = Nothing) And objSp.ToString().CompareTo("0") > 0 Then
                            Return True
                        End If
                    End If
                End If
                Return False
            End If

            Return True
        End Function
    End Class
End Namespace
