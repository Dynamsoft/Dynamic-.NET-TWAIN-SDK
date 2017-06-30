Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Dynamsoft.UVC
Imports Dynamsoft.Core
Imports System.IO
Imports System.Runtime.InteropServices
Imports Dynamsoft.Common

Partial Public Class Form1
    Inherits Form
    Private m_iDesignWidth As Integer = 755
    Private m_CameraManager As CameraManager = Nothing
    Private m_ImageCore As ImageCore = Nothing
    Private m_StrProductKey As String

    Private m_CurrentCamera As Camera = Nothing


    Public Sub New()
        InitializeComponent()
        m_StrProductKey = "t0068MgAAAENENwNWc7+efmkY+t7se6XaRPFZkvfB7QWiTjHiLykxngQdY09pzVtOvrefXBbVvYFbJSluECHlyxaOvHwUADk="
        m_CameraManager = New CameraManager(m_StrProductKey)
        m_ImageCore = New ImageCore()
        dsViewer1.Bind(m_ImageCore)
        AddHandler Me.Load, New EventHandler(AddressOf Form1_Load)
    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs)
        Try
            m_iDesignWidth = Me.Width
            If m_CameraManager.GetCameraNames() IsNot Nothing Then
                For Each temp As String In m_CameraManager.GetCameraNames()
                    cbxSources.Items.Add(temp)
                Next

                AddHandler cbxSources.SelectedIndexChanged, AddressOf cbxSources_SelectedIndexChanged
                If cbxSources.Items.Count > 0 Then
                    cbxSources.SelectedIndex = 0
                End If
            End If
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try

    End Sub

    Private Sub btnRemoveAllImages_Click(sender As Object, e As EventArgs) Handles btnRemoveAllImages.Click
        m_ImageCore.ImageBuffer.RemoveAllImages()
    End Sub


    Private Sub cbxSources_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxSources.SelectedIndexChanged
        If m_CurrentCamera IsNot Nothing Then
            m_CurrentCamera.Close()
        End If
        If m_CameraManager IsNot Nothing Then
            m_CurrentCamera = m_CameraManager.SelectCamera(CShort(cbxSources.SelectedIndex))
            m_CurrentCamera.SetVideoContainer(pictureBox1.Handle)
            m_CurrentCamera.Open()
            ResizeVideoWindow()
        End If

    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs)
        If m_CurrentCamera IsNot Nothing Then
            m_CurrentCamera.SetVideoContainer(pictureBox1.Handle)
            m_CurrentCamera.Open()
            ResizeVideoWindow()
        End If
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs)
        If m_CurrentCamera IsNot Nothing Then
            m_CurrentCamera.Close()
        End If
    End Sub

    Private Sub ResizeVideoWindow()
        Dim camResolution As CamResolution = m_CurrentCamera.CurrentResolution
        If camResolution IsNot Nothing AndAlso camResolution.Width > 0 AndAlso camResolution.Height > 0 Then
            If True Then
                Dim iVideoWidth As Integer = pictureBox1.Width
                Dim iVideoHeight As Integer = pictureBox1.Width * camResolution.Height \ camResolution.Width
                Dim iContentHeight As Integer = panel1.Height - panel1.Margin.Top - panel1.Margin.Bottom - panel1.Padding.Top - panel1.Padding.Bottom
                If iVideoHeight < iContentHeight Then
                    m_CurrentCamera.ResizeVideoWindow(0, (iContentHeight - iVideoHeight) \ 2, iVideoWidth, iVideoHeight)
                Else
                    m_CurrentCamera.ResizeVideoWindow(0, 0, pictureBox1.Width, pictureBox1.Height)
                End If
            End If
        End If
    End Sub

    Private Sub btnCaptureImage_Click(sender As Object, e As EventArgs) Handles btnCaptureImage.Click
        If m_CurrentCamera IsNot Nothing Then
            Dim tempBmp As Bitmap = m_CurrentCamera.GrabImage()
            m_ImageCore.IO.LoadImage(tempBmp)
        End If

    End Sub

End Class
