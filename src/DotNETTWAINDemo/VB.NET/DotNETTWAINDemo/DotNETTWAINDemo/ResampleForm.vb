Public Class ResampleForm
    Dim m_width, m_height As Integer
    Dim m_newWidth, m_newHeight As Integer
    Dim m_flag As Boolean
    Dim m_interpolation As Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod

    Public Sub InitResampleForm(ByVal iwidth As Integer, ByVal iheight As Integer)
        Me.m_width = iwidth
        Me.m_height = iheight

        Me.m_flag = False
        Me.tbxWidth.Text = iwidth.ToString()
        Me.tbxHeight.Text = iheight.ToString()
        Me.cbxWidthType.SelectedIndex = 0
        Me.cbxHeightType.SelectedIndex = 0
        Me.cbxConstrainProportion.Checked = True
        Me.cbxResampleType.SelectedIndex = 0
        Me.m_flag = True
    End Sub

    Public Function GetNewHeight() As Integer
        If (cbxWidthType.SelectedIndex = 0) Then
            GetNewHeight = Integer.Parse(tbxHeight.Text)
        Else
            GetNewHeight = Integer.Parse(tbxHeight.Text) * m_height / 100
        End If
    End Function

    Public Function GetNewWidth() As Integer
        If (cbxHeightType.SelectedIndex = 0) Then
            GetNewWidth = Integer.Parse(tbxWidth.Text)
        Else
            GetNewWidth = Integer.Parse(tbxWidth.Text) * m_width / 100
        End If
    End Function

    Public Function GetInterpolation() As Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod
        Select Me.cbxResampleType.SelectedIndex
            Case 0
                m_interpolation = Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod.Bicubic
            Case 1
                m_interpolation = Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod.Bilinear
            Case 2
                m_interpolation = Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod.NearestNeighbour
        End Select
        GetInterpolation = m_interpolation
    End Function

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If (Integer.TryParse(tbxWidth.Text, m_newWidth) = False) Then
            tbxWidth.Focus()
            Return
        End If

        If (Integer.TryParse(tbxHeight.Text, m_newHeight) = False) Then
            tbxHeight.Focus()
            Return
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cbxWidthType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxWidthType.SelectedIndexChanged
        If (Me.cbxHeightType.SelectedIndex <> Me.cbxWidthType.SelectedIndex And m_flag) Then
            If (cbxWidthType.SelectedIndex = 0) Then
                If (Integer.TryParse(tbxWidth.Text, m_newWidth) And Integer.TryParse(tbxHeight.Text, m_newHeight)) Then
                    m_newHeight = m_newHeight * m_height / 100
                    m_newWidth = m_newWidth * m_width / 100
                    tbxWidth.Text = m_newWidth.ToString()
                    tbxHeight.Text = m_newHeight.ToString()
                End If

            Else
                If (Integer.TryParse(tbxWidth.Text, m_newWidth) And Integer.TryParse(tbxHeight.Text, m_newHeight)) Then
                    m_newWidth = (m_newWidth / m_width * 100)
                    m_newHeight = (m_newHeight / m_height * 100)
                    tbxWidth.Text = m_newWidth.ToString()
                    tbxHeight.Text = m_newHeight.ToString()
                End If
            End If
            Me.cbxHeightType.SelectedIndex = Me.cbxWidthType.SelectedIndex
        End If
    End Sub

    Private Sub cbxHeightType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxHeightType.SelectedIndexChanged
        If (Me.cbxWidthType.SelectedIndex <> Me.cbxHeightType.SelectedIndex And m_flag) Then
            If (cbxHeightType.SelectedIndex = 0) Then
                If (Integer.TryParse(tbxHeight.Text, m_newHeight) And Integer.TryParse(tbxWidth.Text, m_newWidth)) Then
                    m_newWidth = m_newWidth * m_width / 100
                    m_newHeight = m_newHeight * m_height / 100
                    tbxWidth.Text = m_newWidth.ToString()
                    tbxHeight.Text = m_newHeight.ToString()
                End If

            Else
                If (Integer.TryParse(tbxHeight.Text, m_newHeight)) Then
                    m_newHeight = (m_newHeight / m_height * 100)
                    m_newWidth = (m_newWidth / m_width * 100)
                    tbxWidth.Text = m_newWidth.ToString()
                    tbxHeight.Text = m_newHeight.ToString()
                End If
            End If
            Me.cbxWidthType.SelectedIndex = Me.cbxHeightType.SelectedIndex
        End If
    End Sub

    Private Sub tbxWidth_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbxWidth.KeyUp
        If (cbxConstrainProportion.Checked = True) Then
            If (Integer.TryParse(tbxWidth.Text, m_newWidth) = True) Then
                Dim proportion As Double
                proportion = m_width / m_height

                If (cbxWidthType.SelectedIndex = 0) Then
                    tbxHeight.Text = ((m_newWidth / proportion)).ToString()
                End If

                If (cbxWidthType.SelectedIndex = 1) Then
                    tbxHeight.Text = m_newWidth.ToString()
                End If
            End If
        End If
    End Sub

    Private Sub tbxHeight_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbxHeight.KeyUp
        If (cbxConstrainProportion.Checked = True) Then
            If (Integer.TryParse(tbxHeight.Text, m_newHeight) = True) Then
                Dim proportion As Double
                proportion = m_width / m_height
                If (cbxWidthType.SelectedIndex = 0) Then
                    tbxWidth.Text = ((m_newHeight * proportion)).ToString()
                End If
  
                If (cbxWidthType.SelectedIndex = 1) Then
                    tbxWidth.Text = m_newHeight.ToString()
                End If
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class