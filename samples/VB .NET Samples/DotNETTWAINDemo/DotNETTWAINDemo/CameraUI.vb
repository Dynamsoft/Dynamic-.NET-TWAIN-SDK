Imports Dynamsoft.Core
Imports Dynamsoft.UVC
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Partial Class CameraUI
	Inherits Form
	Public Sub New()
		InitializeComponent()
	End Sub

	Private m_Camera As Camera = Nothing
	Public Property Camera() As Camera
		Get
			Return m_Camera
		End Get
		Set
			m_Camera = value
			m_Camera.SetVideoContainer(Me.Handle)
		End Set
	End Property


	Private Sub CameraUI_FormClosed(sender As Object, e As FormClosedEventArgs)
		If m_Camera IsNot Nothing Then
			m_Camera.Close()
		End If
	End Sub

	Private Sub CameraUI_SizeChanged(sender As Object, e As EventArgs)
		If m_Camera IsNot Nothing Then
			m_Camera.ResizeVideoWindow(0, menuStrip1.Height, Me.ClientRectangle.Width, Me.ClientRectangle.Height)
		End If

	End Sub

	Private Sub optionsToolStripMenuItem_Click(sender As Object, e As EventArgs)
		m_Camera.DisplayPropertyPage()
	End Sub
End Class
