Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports Microsoft.Win32
Imports Dynamsoft.TWAIN
Imports Dynamsoft.TWAIN.Interface
Imports Dynamsoft.Core

''' <summary>
''' Interaction logic for ScanWindow.xaml
''' </summary>
Namespace WpfControlsDemo
    Partial Public Class ScanWindow
        Inherits Window
        Implements Dynamsoft.TWAIN.Interface.IAcquireCallback
        Public Sub New()
            InitializeComponent()
            Try
                lbScan.Background = New ImageBrush(New BitmapImage(New Uri(Window1.imageDirectory & "normal\scan_now.png", UriKind.RelativeOrAbsolute)))
            Catch
            End Try
            lbScan.IsEnabled = False
            AddHandler Me.Closing, New System.ComponentModel.CancelEventHandler(AddressOf ScanWindow_Closing)
            m_RefreshInfo = New RefreshImageBufferInfo(AddressOf RefreshImageInfo)
        End Sub

        Private m_TotalImageTextBox As TextBox = Nothing

        Public Sub SetTotalImageTextBox(tbx As TextBox)
            m_TotalImageTextBox = tbx
        End Sub

        Private m_CurrentImageTextBox As TextBox = Nothing

        Public Sub SetCurrentImageTextBox(tbx As TextBox)
            m_CurrentImageTextBox = tbx
        End Sub
        Private Sub ScanWindow_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs)
            If m_twain IsNot Nothing Then
                If m_twain.DataSourceStatus = Dynamsoft.TWAIN.Enums.TWDataSourceStatus.TWDSS_ACQUIRING Then
                    e.Cancel = True
                    MessageBox.Show("There are some uncompleted scanning tasks. Please wait until the tasks completes.", "WpfControlsDemo", MessageBoxButton.OK, MessageBoxImage.Warning)
                Else
                    m_twain.CloseSource()
                    m_twain.CloseSourceManager()
                End If
            End If
        End Sub

        Private m_twain As TwainManager = Nothing

        Public WriteOnly Property TWAIN() As Dynamsoft.TWAIN.TwainManager
            Set(value As Dynamsoft.TWAIN.TwainManager)
                m_twain = value
                If m_twain IsNot Nothing Then
                    For i As Integer = 0 To m_twain.SourceCount - 1
                        cbxSources.Items.Add(m_twain.SourceNameItems(CShort(i)))
                    Next
                    If m_twain.SourceCount > 0 Then
                        cbxSources.SelectedIndex = 0
                        lbScan.IsEnabled = True
                    Else
                        MessageBox.Show("There is no scan source!", "Scan Warning", MessageBoxButton.OK, MessageBoxImage.Warning)
                        lbScan.IsEnabled = False
                    End If
                End If
            End Set
        End Property

        Private m_CoreForImageThum As ImageCore = Nothing
        Public WriteOnly Property CoreForImageThum() As ImageCore
            Set(value As ImageCore)
                m_CoreForImageThum = value
            End Set
        End Property

        Private m_CoreForViewer As ImageCore = Nothing
        Public WriteOnly Property CoreForImageViewer() As ImageCore
            Set(value As ImageCore)
                m_CoreForViewer = value
            End Set
        End Property

        Private Sub lbScan_MouseDown(sender As Object, e As MouseButtonEventArgs)
            Dim key As String = "active/" & "scan_now"
            If Not Window1.icons.ContainsKey(key) Then
                Try
                    Window1.icons.Add(key, New ImageBrush(New BitmapImage(New Uri(Window1.imageDirectory & key & ".png", UriKind.RelativeOrAbsolute))))
                Catch
                End Try
            End If
            Try
                lbScan.Background = Window1.icons(key)
            Catch
            End Try

            If m_twain IsNot Nothing Then
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
                If rbBW.IsChecked.Value Then
                    m_twain.PixelType = Dynamsoft.TWAIN.Enums.TWICapPixelType.TWPT_BW
                    m_twain.BitDepth = 1
                ElseIf rbGrey.IsChecked.Value Then
                    m_twain.PixelType = Dynamsoft.TWAIN.Enums.TWICapPixelType.TWPT_GRAY
                    m_twain.BitDepth = 8
                ElseIf rbColorful.IsChecked.Value Then
                    m_twain.PixelType = Dynamsoft.TWAIN.Enums.TWICapPixelType.TWPT_RGB
                    m_twain.BitDepth = 24
                End If
                m_twain.AcquireImage(TryCast(Me, IAcquireCallback))
            End If
        End Sub

        Private Sub lbScan_MouseEnter(sender As Object, e As MouseEventArgs)
            Dim key As String = "hover/" & "scan_now"
            If Not Window1.icons.ContainsKey(key) Then
                Try
                    Window1.icons.Add(key, New ImageBrush(New BitmapImage(New Uri(Window1.imageDirectory & key & ".png", UriKind.RelativeOrAbsolute))))
                Catch
                End Try
            End If
            Try
                lbScan.Background = Window1.icons(key)
            Catch
            End Try
        End Sub

        Private Sub lbScan_MouseLeave(sender As Object, e As MouseEventArgs)
            Dim key As String = "normal/" & "scan_now"
            If Not Window1.icons.ContainsKey(key) Then
                Try
                    Window1.icons.Add(key, New ImageBrush(New BitmapImage(New Uri(Window1.imageDirectory & key & ".png", UriKind.RelativeOrAbsolute))))
                Catch
                End Try
            End If
            Try
                lbScan.Background = Window1.icons(key)
            Catch
            End Try
        End Sub

        Private Function IsFrameworkSatisfied() As Boolean
            Dim iMajorVersion As Integer = Environment.Version.Major
            If iMajorVersion = 2 Then
                Dim msKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP")
                If msKey Is Nothing Then
                    Return False
                End If
                Dim netVersion As RegistryKey = msKey.OpenSubKey("v3.5")
                If netVersion.GetValue("Install") IsNot Nothing Then
                    If netVersion.GetValue("Install").ToString() = "1" Then
                        Dim objSP As Object = netVersion.GetValue("SP")
                        If objSP IsNot Nothing AndAlso objSP.ToString().CompareTo("0") > 0 Then
                            Return True
                        End If
                    End If
                End If
                Return False
            End If

            Return True
        End Function

#Region "IAcquireCallback Members"

        Public Sub OnPostAllTransfers() Implements IAcquireCallback.OnPostAllTransfers
        End Sub

        Private Delegate Sub RefreshImageBufferInfo(iCurrentImageIndex As Integer, iTotalImageCount As Integer)
        Private m_RefreshInfo As RefreshImageBufferInfo

        Private Sub RefreshImageInfo(iCurrentIndex As Integer, iTotalImageCount As Integer)
            m_TotalImageTextBox.Text = iTotalImageCount.ToString()
            m_CurrentImageTextBox.Text = iCurrentIndex.ToString()
        End Sub

        Delegate Function OnRefreshImageHandler(iCurrentIndex As Integer, iTotalImageCount As Integer)
        Private Function OnRefreshImage(iCurrentIndex As Integer, iTotalImageCount As Integer)
            m_TotalImageTextBox.Text = iTotalImageCount.ToString()
            m_CurrentImageTextBox.Text = iCurrentIndex.ToString()
        End Function

        Public Function OnPostTransfer(bit As System.Drawing.Bitmap) As Boolean Implements IAcquireCallback.OnPostTransfer
            If m_CoreForImageThum IsNot Nothing Then
                m_CoreForImageThum.IO.LoadImage(bit)
                Dim mRefreshImage As New OnRefreshImageHandler(AddressOf OnRefreshImage)
                Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, mRefreshImage, (m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer + 1), m_CoreForImageThum.ImageBuffer.HowManyImagesInBuffer())
            End If

            If m_CoreForViewer IsNot Nothing Then
                If m_CoreForViewer.ImageBuffer.CurrentImageIndexInBuffer = -1 Then
                    m_CoreForViewer.IO.LoadImage(m_CoreForImageThum.ImageBuffer.GetBitmap(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer))
                Else
                    m_CoreForViewer.ImageBuffer.SetBitmap(m_CoreForViewer.ImageBuffer.CurrentImageIndexInBuffer, m_CoreForImageThum.ImageBuffer.GetBitmap(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer))
                End If
            End If
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
    End Class
End Namespace

