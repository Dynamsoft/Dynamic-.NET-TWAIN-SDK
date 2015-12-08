Public Class RotateForm

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim angle As Double
        Dim r, g, b As Integer

        If (Double.TryParse(tbxAngle.Text, angle) = False) Then
            tbxAngle.Focus()
            Return
        End If
        If (Integer.TryParse(tbxR.Text, r) = False Or r < 0 Or r > 255) Then
            tbxR.Focus()
            Return
        End If

        If (Integer.TryParse(tbxG.Text, g) = False Or g < 0 Or g > 255) Then
            tbxG.Focus()
            Return
        End If

        If (Integer.TryParse(tbxB.Text, b) = False Or b < 0 Or b > 255) Then
            tbxB.Focus()
            Return
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub RotateForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.tbxAngle.Text = "45"
        Me.cbxInterPolation.SelectedIndex = 1
        Me.cbxKeepSize.Checked = False
        Me.tbxR.Text = "255"
        Me.tbxG.Text = "255"
        Me.tbxB.Text = "255"
    End Sub
End Class