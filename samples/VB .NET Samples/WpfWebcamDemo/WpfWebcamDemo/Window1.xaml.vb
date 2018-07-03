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
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports Dynamsoft.Core
Imports Dynamsoft.UVC
Imports System.Windows.Interop
Imports System.Drawing
Imports System.IO
Imports System.Runtime.InteropServices
Imports Dynamsoft.Common

''' <summary>
''' Interaction logic for Window1.xaml
''' </summary>
Namespace WpfWebcamDemo
    Partial Public Class Window1
        Inherits Window
        Private m_iRotate As Integer = 0
        Private m_StrProductKey As String
        Private m_ImageCore As ImageCore = Nothing
        Private m_CameraManager As CameraManager = Nothing
        Private m_Camera As Camera = Nothing
        Public Shared ReadOnly imageDirectory As String
        Public Shared ReadOnly strCurrentDirectory As String
        Private m_Refresh As RefreshDelegate
        Private m_ControlWindow As Window
        Private Delegate Sub RefreshDelegate(temp As System.Windows.Media.Imaging.BitmapImage)
        Public Sub New()
            InitializeComponent()
            m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU="
            m_ImageCore = New ImageCore()
            dSViewer1.Bind(m_ImageCore)
            m_CameraManager = New CameraManager(m_StrProductKey)
            AddHandler Me.cbxSources.SelectionChanged, AddressOf cbxSources_SelectionChanged
            cbxSources.SelectedIndex = 0

            AddHandler Me.Loaded, New RoutedEventHandler(AddressOf Window1_Loaded)

            btnRotate90.Background = New ImageBrush(New BitmapImage(New Uri(imageDirectory & "90_normal.png", UriKind.RelativeOrAbsolute)))
            btnRotate180.Background = New ImageBrush(New BitmapImage(New Uri(imageDirectory & "180_normal.png", UriKind.RelativeOrAbsolute)))
            btnRotate270.Background = New ImageBrush(New BitmapImage(New Uri(imageDirectory & "270_normal.png", UriKind.RelativeOrAbsolute)))
            m_Refresh = New RefreshDelegate(AddressOf RefreshImage)
            m_ControlWindow = Window.GetWindow(image1)
            AddHandler Me.cbxSources.SelectionChanged, New SelectionChangedEventHandler(AddressOf cbxSources_SelectionChanged)
        End Sub
        Shared Sub New()
            Dim index As Integer = System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf("Samples")

            If index <> -1 Then
                strCurrentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location.Substring(0, index)
                imageDirectory = strCurrentDirectory & "Samples\Bin\Images\WpfWebCamDemoImages\"
            Else
                index = System.Reflection.Assembly.GetExecutingAssembly().Location.LastIndexOf("\")

                If index <> -1 Then
                    strCurrentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location.Substring(0, index + 1)
                Else
                    strCurrentDirectory = Environment.CurrentDirectory & "\"
                End If

                imageDirectory = strCurrentDirectory & "\Bin\Images\WpfWebCamDemoImages\"
            End If
        End Sub


        Private Sub cbxSources_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
            If m_CameraManager.GetCameraNames() IsNot Nothing Then

                If (CType(sender, ComboBox)).SelectedIndex >= 0 AndAlso (CType(sender, ComboBox)).SelectedIndex < m_CameraManager.GetCameraNames().Count Then
                    m_Camera = m_CameraManager.SelectCamera(CShort(cbxSources.SelectedIndex))
                    m_Camera.Open()
                    AddHandler Me.m_Camera.OnFrameCaptrue, New Dynamsoft.UVC.Delegate.OnFrameCaptureHandler(AddressOf m_Camera_OnFrameCaptrue)
                    ResizePictureBox()
                End If
            End If

            If m_Camera IsNot Nothing Then
                cbxResolution.Items.Clear()

                For Each camR As CamResolution In m_Camera.SupportedResolutions
                    cbxResolution.Items.Add(camR.ToString())
                Next

                If cbxResolution.Items.Count > 0 Then
                    cbxResolution.SelectedIndex = 0
                End If

                ResizePictureBox()
            End If

        End Sub
        Private Sub cbxResolution_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
            If cbxResolution.SelectedValue IsNot Nothing Then
                Dim strWXH As String() = cbxResolution.SelectedValue.ToString().Split(New Char() {" "c})

                If strWXH.Length = 3 Then

                    Try
                        m_Camera.CurrentResolution = New CamResolution(Integer.Parse(strWXH(0)), Integer.Parse(strWXH(2)))
                    Catch
                    End Try
                End If

                m_Camera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_0)
                ResizePictureBox()
            End If
        End Sub
        Private Sub Window1_Loaded(sender As Object, e As RoutedEventArgs)
            Try
                If m_CameraManager.GetCameraNames() IsNot Nothing Then
                    For Each temp As String In m_CameraManager.GetCameraNames()
                        Me.cbxSources.Items.Add(temp)
                    Next
                    If cbxSources.Items.Count > 0 Then
                        cbxSources.SelectedIndex = 0
                    End If

                End If
            Catch exp As Exception
                MessageBox.Show(exp.Message)
            End Try
        End Sub

        Private Sub btnCaptureImage_Click(sender As Object, e As RoutedEventArgs)
            If m_Camera IsNot Nothing Then
                Dim temp As Bitmap = m_Camera.GrabImage()
                m_ImageCore.IO.LoadImage(temp)
            End If
        End Sub

        Private Sub btnRemoveAllImage_Click(sender As Object, e As RoutedEventArgs)
            m_ImageCore.ImageBuffer.RemoveAllImages()
        End Sub
        Private Sub ResizePictureBox()
            If m_Camera IsNot Nothing Then
                Dim camResolution As CamResolution = m_Camera.CurrentResolution

                If camResolution IsNot Nothing AndAlso camResolution.Width > 0 AndAlso camResolution.Height > 0 Then

                    If True Then
                        Dim iVideoWidth As Double = border1.Width
                        Dim iVideoHeight As Double = border1.Width * camResolution.Height / camResolution.Width

                        If iVideoHeight < border1.Height Then
                            image1.Margin = New Thickness(0, (border1.Height - iVideoHeight) / 2, 0, 0)
                            image1.Width = iVideoWidth
                            image1.Height = iVideoHeight
                        Else
                            image1.Margin = New Thickness(0, 0, 0, 0)
                            image1.Width = iVideoWidth
                            image1.Height = iVideoHeight
                        End If
                    End If
                End If
            End If
        End Sub
        Private Sub RotatePictureBox()
            If m_Camera IsNot Nothing Then
                Dim camResolution As CamResolution = m_Camera.CurrentResolution

                If camResolution IsNot Nothing AndAlso camResolution.Width > 0 AndAlso camResolution.Height > 0 Then

                    If camResolution.Width / camResolution.Height > border1.Width / border1.Height Then
                        Dim iVideoHeight As Double = border1.Height
                        Dim iVideoWidth As Double = border1.Height * camResolution.Height / camResolution.Width
                        image1.Margin = New Thickness((border1.Width - iVideoWidth) / 2, 0, 0, 0)
                        image1.Width = iVideoWidth
                        image1.Height = iVideoHeight
                    Else
                        Dim iVideoWidth As Double = border1.Width
                        Dim iVideoHeight As Double = border1.Width * camResolution.Width / camResolution.Height
                        image1.Margin = New Thickness(0, (border1.Height - iVideoHeight) / 2, 0, 0)
                        image1.Width = iVideoWidth
                        image1.Height = iVideoHeight
                    End If
                End If
            End If
        End Sub
        Private Sub RefreshImage(temp As System.Windows.Media.Imaging.BitmapImage)
            Try
                image1.Source = temp
            Catch
            End Try
        End Sub
        Private Sub SetPicture(img As System.Drawing.Image)
            Dim temp As Bitmap = (CType((img), Bitmap)).Clone(New System.Drawing.Rectangle(0, 0, img.Width, img.Height), img.PixelFormat)
            Dim ms As MemoryStream = New MemoryStream()
            temp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp)
            Dim bytes As Byte() = ms.GetBuffer()
            ms.Close()
            Dim bitImage As BitmapImage = New BitmapImage()
            bitImage.BeginInit()
            bitImage.StreamSource = New MemoryStream(bytes)
            bitImage.EndInit()
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, m_Refresh, Nothing)
        End Sub
        Private Sub m_Camera_OnFrameCaptrue(bitmap As Bitmap)
            Dim m_Frame As System.Windows.Media.Imaging.BitmapImage = New System.Windows.Media.Imaging.BitmapImage()

            Using stream = New System.IO.MemoryStream()
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp)
                stream.Seek(0, System.IO.SeekOrigin.Begin)
                m_Frame.BeginInit()
                m_Frame.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad
                m_Frame.StreamSource = stream
                m_Frame.EndInit()
                stream.SetLength(0)
                stream.Capacity = 0
                stream.Dispose()
            End Using

            m_Frame.Freeze()
            m_ControlWindow.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.SystemIdle, m_Refresh, m_Frame)
        End Sub
        Private Sub btnRotate90_Click(sender As Object, e As RoutedEventArgs)
            m_Camera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_90)
            RotatePictureBox()
        End Sub

        Private Sub btnRotate180_Click(sender As Object, e As RoutedEventArgs)
            m_Camera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_180)
            ResizePictureBox()
        End Sub

        Private Sub btnRotate270_Click(sender As Object, e As RoutedEventArgs)
            m_Camera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_270)
            RotatePictureBox()
        End Sub

        Private Sub btnRotate90_MouseEnter(sender As Object, e As MouseEventArgs)
            btnRotate90.Background = New ImageBrush(New BitmapImage(New Uri(imageDirectory & "90_hover.png", UriKind.RelativeOrAbsolute)))
        End Sub

        Private Sub btnRotate180_MouseEnter(sender As Object, e As MouseEventArgs) Handles btnRotate180.MouseEnter
            btnRotate180.Background = New ImageBrush(New BitmapImage(New Uri(imageDirectory & "180_hover.png", UriKind.RelativeOrAbsolute)))
        End Sub

        Private Sub btnRotate270_MouseEnter(sender As Object, e As MouseEventArgs)
            btnRotate270.Background = New ImageBrush(New BitmapImage(New Uri(imageDirectory & "270_hover.png", UriKind.RelativeOrAbsolute)))
        End Sub

        Private Sub btnRotate90_MouseLeave(sender As Object, e As MouseEventArgs)
            btnRotate90.Background = New ImageBrush(New BitmapImage(New Uri(imageDirectory & "90_normal.png", UriKind.RelativeOrAbsolute)))
        End Sub

        Private Sub btnRotate180_MouseLeave(sender As Object, e As MouseEventArgs)
            btnRotate180.Background = New ImageBrush(New BitmapImage(New Uri(imageDirectory & "180_normal.png", UriKind.RelativeOrAbsolute)))
        End Sub

        Private Sub btnRotate270_MouseLeave(sender As Object, e As MouseEventArgs)
            btnRotate270.Background = New ImageBrush(New BitmapImage(New Uri(imageDirectory & "270_normal.png", UriKind.RelativeOrAbsolute)))
        End Sub
    End Class
End Namespace

