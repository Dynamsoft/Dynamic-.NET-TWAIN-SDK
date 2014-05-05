Public Class ZoomForm
    Dim zoomRatio As Integer

    Public Sub SetZoomRatio(ByVal value As Decimal)
        zoomRatio = Convert.ToInt32(value * 100 + 0.1)
        Me.tbxZoomRatio.Text = zoomRatio.ToString()
    End Sub

    Public Function GetZoomRatio() As Decimal
        GetZoomRatio = zoomRatio / 100.0F
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim ratio As Integer
        ratio = -1

        If (Integer.TryParse(tbxZoomRatio.Text, ratio) = False Or ratio < 2 Or ratio > 6500) Then
            tbxZoomRatio.Focus()
            Return
        Else
            zoomRatio = ratio
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub tbxZoomRatio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbxZoomRatio.KeyDown
        If (e.KeyCode.ToString() = "Return") Then
            btnOK_Click(Me, Nothing)
        End If
    End Sub
End Class