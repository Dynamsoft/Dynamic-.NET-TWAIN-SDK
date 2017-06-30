Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Partial Class ZoomForm
	Inherits Form
	Private m_zoomRatio As Integer

	Public Sub New()

		Me.New(1)
	End Sub

	Public Sub New(ratio As Single)
		InitializeComponent()
		ZoomRatio = ratio

		Me.DialogResult = DialogResult.Cancel
	End Sub

	Public Property ZoomRatio() As Single
		Get
			Return m_zoomRatio / 100F
		End Get
		Set
			m_zoomRatio = CInt(Math.Truncate(value * 100 + 0.1))
			Me.tbxZoomRatio.Text = m_zoomRatio.ToString()
		End Set
	End Property

	Private Sub btnCancel_Click(sender As Object, e As EventArgs)
		Me.Close()
	End Sub

	Private Sub btnOK_Click(sender As Object, e As EventArgs)
		Dim ratio As Integer = -1

		If Not Integer.TryParse(tbxZoomRatio.Text, ratio) OrElse ratio < 2 OrElse ratio > 6500 Then
			tbxZoomRatio.Focus()
			Return
		Else
			m_zoomRatio = ratio
		End If

		Me.DialogResult = DialogResult.OK
		Me.Close()
	End Sub

	Private Sub tbxZoomRatio_KeyPress(sender As Object, e As KeyPressEventArgs)
		If AscW(e.KeyChar) = 13 Then
			btnOK_Click(Me, Nothing)
		End If
	End Sub
End Class
