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
        Public Sub New()
            InitializeComponent()
            m_StrProductKey = "t0068MgAAAENENwNWc7+efmkY+t7se6XaRPFZkvfB7QWiTjHiLykxngQdY09pzVtOvrefXBbVvYFbJSluECHlyxaOvHwUADk="
            m_ImageCore = New ImageCore()
            dSViewer1.Bind(m_ImageCore)
            m_CameraManager = New CameraManager(m_StrProductKey)
            AddHandler Me.cbxSources.SelectionChanged, AddressOf cbxSources_SelectionChanged
            cbxSources.SelectedIndex = 0

            AddHandler Me.Loaded, New RoutedEventHandler(AddressOf Window1_Loaded)

            AddHandler Me.cbxSources.SelectionChanged, New SelectionChangedEventHandler(AddressOf cbxSources_SelectionChanged)
        End Sub



        Private Sub cbxSources_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
            If m_CameraManager.GetCameraNames() IsNot Nothing Then
                If DirectCast(sender, ComboBox).SelectedIndex >= 0 AndAlso DirectCast(sender, ComboBox).SelectedIndex < m_CameraManager.GetCameraNames().Count Then
                    m_Camera = m_CameraManager.SelectCamera(CShort(cbxSources.SelectedIndex))
                    Dim windowHandle As IntPtr = New WindowInteropHelper(Me).Handle
                    m_Camera.SetVideoContainer(windowHandle)
                    m_Camera.Open()
                    ResizeVideoWindow()
                End If
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
                Dim windowHandle As IntPtr = New WindowInteropHelper(Me).Handle
                m_Camera.SetVideoContainer(windowHandle)
                m_Camera.Open()
                ResizeVideoWindow()
                Dim temp As Bitmap = m_Camera.GrabImage()
                m_ImageCore.IO.LoadImage(temp)
            End If
        End Sub

        Private Sub btnRemoveAllImage_Click(sender As Object, e As RoutedEventArgs)
            m_ImageCore.ImageBuffer.RemoveAllImages()
        End Sub

        Private Sub button1_Click(sender As Object, e As RoutedEventArgs)
            If m_Camera IsNot Nothing Then
                Dim windowHandle As IntPtr = New WindowInteropHelper(Me).Handle
                m_Camera.SetVideoContainer(windowHandle)
                m_Camera.Open()
                ResizeVideoWindow()
            End If
        End Sub

        Private Sub button2_Click(sender As Object, e As RoutedEventArgs)
            If m_Camera IsNot Nothing Then
                m_Camera.Close()
            End If
        End Sub

        Private Sub ResizeVideoWindow()
            If m_Camera IsNot Nothing Then
                Dim tempCamResolution As CamResolution = m_Camera.CurrentResolution
                If tempCamResolution IsNot Nothing Then
                    Dim iVideoWidth As Double = border1.Width
                    Dim iVideoHeight As Double = border1.Width * tempCamResolution.Height / tempCamResolution.Width
                    m_Camera.ResizeVideoWindow(CInt(Math.Truncate(border1.Margin.Left + border1.BorderThickness.Left)), CInt(Math.Truncate(border1.Margin.Top + (border1.ActualHeight - iVideoHeight) / 2)), CInt(Math.Truncate(iVideoWidth - border1.BorderThickness.Left - border1.BorderThickness.Right)), CInt(Math.Truncate(iVideoHeight)))
                End If
            End If
        End Sub
    End Class
End Namespace

