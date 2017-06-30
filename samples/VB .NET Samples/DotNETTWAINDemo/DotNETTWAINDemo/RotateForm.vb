Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Partial Class RotateForm
	Inherits Form
	Public Sub New()
		InitializeComponent()

		Me.tbxAngle.Text = "45"
		Me.cbxInterPolation.SelectedIndex = 1
		Me.cbxKeepSize.Checked = False
		Me.tbxR.Text = "255"
		Me.tbxG.Text = "255"
		Me.tbxB.Text = "255"

		Me.DialogResult = DialogResult.Cancel
	End Sub

	Private Sub btnCancel_Click(sender As Object, e As EventArgs)
		Me.Close()
	End Sub

	Private Sub btnOK_Click(sender As Object, e As EventArgs)
		Dim angle As Double
		Dim r As Integer, g As Integer, b As Integer

		If Not Double.TryParse(tbxAngle.Text, angle) Then
			tbxAngle.Focus()
			Return
		End If

		If Not Integer.TryParse(tbxR.Text, r) OrElse r < 0 OrElse r > 255 Then
			tbxR.Focus()
			Return
		End If

		If Not Integer.TryParse(tbxG.Text, g) OrElse g < 0 OrElse g > 255 Then
			tbxG.Focus()
			Return
		End If

		If Not Integer.TryParse(tbxB.Text, b) OrElse b < 0 OrElse b > 255 Then
			tbxB.Focus()
			Return
		End If

		Me.DialogResult = DialogResult.OK
		Me.Close()
	End Sub
End Class
