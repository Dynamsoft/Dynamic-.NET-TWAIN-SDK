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
    Private iControlWidth As Integer = 275
    Private iControlHeight As Integer = 295
    Private m_CurrentCamera As Camera = Nothing


    Public Sub New()
        InitializeComponent()
        m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU="
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
            RemoveHandler Me.m_CurrentCamera.OnFrameCaptrue, New Dynamsoft.UVC.Delegate.OnFrameCaptureHandler(AddressOf m_CurrentCamera_OnFrameCaptrue)
            m_CurrentCamera.Close()
        End If

        If m_CameraManager IsNot Nothing Then
            m_CurrentCamera = m_CameraManager.SelectCamera(CShort(cbxSources.SelectedIndex))
            m_CurrentCamera.Open()
            AddHandler Me.m_CurrentCamera.OnFrameCaptrue, New Dynamsoft.UVC.Delegate.OnFrameCaptureHandler(AddressOf m_CurrentCamera_OnFrameCaptrue)
            ResizePictureBox()
        End If

        If m_CurrentCamera IsNot Nothing Then
            cbxResolution.Items.Clear()

            For Each camR As CamResolution In m_CurrentCamera.SupportedResolutions
                cbxResolution.Items.Add(camR.ToString())
            Next
            If cbxResolution.Items.Count > 0 Then cbxResolution.SelectedIndex = 0
            ResizePictureBox()
        End If
    End Sub
    Private Sub cbxResolution_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxResolution.SelectedIndexChanged
        If cbxResolution.Text IsNot Nothing Then
            Dim strWXH As String() = cbxResolution.Text.Split(New Char() {" "c})

            If strWXH.Length = 3 Then

                Try
                    m_CurrentCamera.CurrentResolution = New CamResolution(Integer.Parse(strWXH(0)), Integer.Parse(strWXH(2)))
                Catch
                End Try
            End If

            m_CurrentCamera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_0)
            ResizePictureBox()
        End If
    End Sub
    Private Sub RotatePictureBox()
        If m_CurrentCamera IsNot Nothing Then
            Dim camResolution As CamResolution = m_CurrentCamera.CurrentResolution

            If camResolution IsNot Nothing AndAlso camResolution.Width > 0 AndAlso camResolution.Height > 0 Then

                If camResolution.Width / camResolution.Height > iControlWidth / iControlHeight Then
                    Dim iVideoHeight As Integer = iControlHeight
                    Dim iVideoWidth As Integer = iControlHeight * camResolution.Height / camResolution.Width
                    Dim iContentWidth As Integer = panel1.Width - panel1.Margin.Left - panel1.Margin.Right - panel1.Padding.Left - panel1.Padding.Right
                    pictureBox1.Location = New Point((iContentWidth - iVideoWidth) / 2, 0)
                    pictureBox1.Size = New Size(iVideoWidth, iVideoHeight)
                Else
                    Dim iVideoWidth As Integer = iControlWidth
                    Dim iVideoHeight As Integer = iControlWidth * camResolution.Width / camResolution.Height
                    Dim iContentHeight As Integer = panel1.Height - panel1.Margin.Top - panel1.Margin.Bottom - panel1.Padding.Top - panel1.Padding.Bottom
                    pictureBox1.Location = New Point(0, (iContentHeight - iVideoHeight) / 2)
                    pictureBox1.Size = New Size(iVideoWidth, iVideoHeight)
                End If
            End If
        End If
    End Sub
    Private Sub ResizePictureBox()
        If m_CurrentCamera IsNot Nothing Then
            Dim camResolution As CamResolution = m_CurrentCamera.CurrentResolution

            If camResolution IsNot Nothing AndAlso camResolution.Width > 0 AndAlso camResolution.Height > 0 Then

                If True Then
                    Dim iVideoWidth As Integer = iControlWidth
                    Dim iVideoHeight As Integer = iControlWidth * camResolution.Height / camResolution.Width
                    Dim iContentHeight As Integer = panel1.Height - panel1.Margin.Top - panel1.Margin.Bottom - panel1.Padding.Top - panel1.Padding.Bottom

                    If iVideoHeight < iContentHeight Then
                        pictureBox1.Location = New Point(0, (iContentHeight - iVideoHeight) / 2)
                        pictureBox1.Size = New Size(iVideoWidth, iVideoHeight)
                    Else
                        pictureBox1.Location = New Point(0, 0)
                        pictureBox1.Size = New Size(pictureBox1.Width, pictureBox1.Height)
                    End If
                End If
            End If
        End If
    End Sub
    Delegate Function OnRefreshImageHandler(ByVal bit As Bitmap)
    Private Function OnRefreshImage(ByVal bit As Bitmap)
        pictureBox1.Image = bit
    End Function
    Dim mRefreshImage As New OnRefreshImageHandler(AddressOf OnRefreshImage)
    Private Sub SetPicture(img As Image)
        Dim temp As Bitmap = (CType((img), Bitmap)).Clone(New Rectangle(0, 0, img.Width, img.Height), img.PixelFormat)

        If pictureBox1.InvokeRequired Then
            pictureBox1.BeginInvoke(mRefreshImage, temp)
        Else
            pictureBox1.Image = temp
        End If
    End Sub
    Private Sub btnCaptureImage_Click(sender As Object, e As EventArgs) Handles btnCaptureImage.Click
        If m_CurrentCamera IsNot Nothing Then
            Dim tempBmp As Bitmap = m_CurrentCamera.GrabImage()
            m_ImageCore.IO.LoadImage(tempBmp)
        End If

    End Sub
    Private Sub m_CurrentCamera_OnFrameCaptrue(bitmap As Bitmap)
        SetPicture(bitmap)
    End Sub
    Private Sub picbox90_MouseHover(sender As Object, e As EventArgs) Handles picbox90.MouseHover
        picbox90.Image = Global.WebcamDemo.Resources._90_hover
    End Sub

    Private Sub picbox90_MouseLeave(sender As Object, e As EventArgs) Handles picbox90.MouseLeave
        picbox90.Image = Global.WebcamDemo.Resources._90_normal
    End Sub

    Private Sub picbox180_MouseHover(sender As Object, e As EventArgs) Handles picbox180.MouseHover
        picbox180.Image = Global.WebcamDemo.Resources._180_hover
    End Sub

    Private Sub picbox180_MouseLeave(sender As Object, e As EventArgs) Handles picbox180.MouseLeave
        picbox180.Image = Global.WebcamDemo.Resources._180_normal
    End Sub
    Private Sub picbox270_MouseHover(sender As Object, e As EventArgs) Handles picbox270.MouseHover
        picbox270.Image = Global.WebcamDemo.Resources._270_hover
    End Sub
    Private Sub picbox270_MouseLeave(sender As Object, e As EventArgs) Handles picbox270.MouseLeave
        picbox270.Image = Global.WebcamDemo.Resources._270_normal
    End Sub
    Private Sub picbox90_Click(sender As Object, e As EventArgs) Handles picbox90.Click
        m_CurrentCamera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_90)
        RotatePictureBox()
    End Sub

    Private Sub picbox180_Click(sender As Object, e As EventArgs) Handles picbox180.Click
        m_CurrentCamera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_180)
        ResizePictureBox()
    End Sub

    Private Sub picbox270_Click(sender As Object, e As EventArgs) Handles picbox270.Click
        m_CurrentCamera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_270)
        RotatePictureBox()
    End Sub
End Class
