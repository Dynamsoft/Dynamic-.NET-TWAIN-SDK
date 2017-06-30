Imports Dynamsoft.Core.Enums
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Partial Class ResampleForm
	Inherits Form
	Private width As Integer, height As Integer
	Private m_newWidth As Integer, m_newHeight As Integer
	Private flag As Boolean
	Private m_InterpolationMethod As EnumInterpolationMethod = EnumInterpolationMethod.BestQuality
	Public Sub New()
		InitializeComponent()
	End Sub

	Public Sub New(width As Integer, height As Integer)
		InitializeComponent()

		Me.width = width
		Me.height = height

		Me.flag = False
		Me.tbxWidth.Text = width.ToString()
		Me.tbxHeight.Text = height.ToString()
		Me.cbxWidthType.SelectedIndex = 0
		Me.cbxHeightType.SelectedIndex = 0
		Me.cbxConstrainProportion.Checked = True
		Me.cbxResampleType.SelectedIndex = 0
		flag = True
	End Sub

	Public ReadOnly Property NewHeight() As Integer
		Get
			If cbxWidthType.SelectedIndex = 0 Then
				Return Integer.Parse(tbxHeight.Text)
			Else
				Return Integer.Parse(tbxHeight.Text) * height \ 100
			End If
		End Get
	End Property

	Public ReadOnly Property NewWidth() As Integer
		Get
			If cbxHeightType.SelectedIndex = 0 Then
				Return Integer.Parse(tbxWidth.Text)
			Else
				Return Integer.Parse(tbxWidth.Text) * width \ 100
			End If
		End Get
	End Property

	Public ReadOnly Property Interpolation() As EnumInterpolationMethod
		Get
			Select Case Me.cbxResampleType.SelectedIndex
				Case 0
					m_InterpolationMethod = EnumInterpolationMethod.Bicubic
					Exit Select
				Case 1
					m_InterpolationMethod = EnumInterpolationMethod.Bilinear
					Exit Select
				Case 2
					m_InterpolationMethod = EnumInterpolationMethod.NearestNeighbour
					Exit Select
				Case 3
					m_InterpolationMethod = EnumInterpolationMethod.BestQuality
					Exit Select
			End Select
			Return m_InterpolationMethod
		End Get
	End Property
	Private Sub btnOk_Click(sender As Object, e As EventArgs)
		If Not Integer.TryParse(tbxWidth.Text, m_newWidth) Then
			tbxWidth.Focus()
			Return
		End If
		If Not Integer.TryParse(tbxHeight.Text, m_newHeight) Then
			tbxHeight.Focus()
			Return
		End If
		Me.DialogResult = DialogResult.OK
		Me.Close()
	End Sub

	Private Sub cbxWidthType_SelectedIndexChanged(sender As Object, e As EventArgs)
		If Me.cbxHeightType.SelectedIndex <> Me.cbxWidthType.SelectedIndex AndAlso flag Then
			If cbxWidthType.SelectedIndex = 0 Then
				If Integer.TryParse(tbxWidth.Text, m_newWidth) AndAlso Integer.TryParse(tbxHeight.Text, m_newHeight) Then
					m_newHeight = m_newHeight * height \ 100
					m_newWidth = m_newWidth * width \ 100
					tbxWidth.Text = m_newWidth.ToString()
					tbxHeight.Text = m_newHeight.ToString()
				End If
			Else
				If Integer.TryParse(tbxWidth.Text, m_newWidth) AndAlso Integer.TryParse(tbxHeight.Text, m_newHeight) Then
					m_newWidth = CInt(Math.Truncate(m_newWidth / CDbl(width) * 100))
					m_newHeight = CInt(Math.Truncate(m_newHeight / CDbl(height) * 100))
					tbxWidth.Text = m_newWidth.ToString()
					tbxHeight.Text = m_newHeight.ToString()
				End If
			End If

			Me.cbxHeightType.SelectedIndex = Me.cbxWidthType.SelectedIndex
		End If
	End Sub

	Private Sub cbxHeightType_SelectedIndexChanged(sender As Object, e As EventArgs)
		If Me.cbxWidthType.SelectedIndex <> Me.cbxHeightType.SelectedIndex AndAlso flag Then
			If cbxHeightType.SelectedIndex = 0 Then
				If Integer.TryParse(tbxHeight.Text, m_newHeight) AndAlso Integer.TryParse(tbxWidth.Text, m_newWidth) Then
					m_newWidth = m_newWidth * width \ 100
					m_newHeight = m_newHeight * height \ 100
					tbxWidth.Text = m_newWidth.ToString()
					tbxHeight.Text = m_newHeight.ToString()
				End If
			Else
				If Integer.TryParse(tbxHeight.Text, m_newHeight) Then
					m_newHeight = CInt(Math.Truncate(m_newHeight / CDbl(height) * 100))
					m_newWidth = CInt(Math.Truncate(m_newWidth / CDbl(width) * 100))
					tbxWidth.Text = m_newWidth.ToString()
					tbxHeight.Text = m_newHeight.ToString()
				End If
			End If
			Me.cbxWidthType.SelectedIndex = Me.cbxHeightType.SelectedIndex
		End If
	End Sub

	Private Sub tbxWidth_KeyUp(sender As Object, e As KeyEventArgs)
		If cbxConstrainProportion.Checked = True Then
			If Integer.TryParse(tbxWidth.Text, m_newWidth) = True Then
				Dim proportion As Double = width / CDbl(height)
				If cbxWidthType.SelectedIndex = 0 Then
					tbxHeight.Text = CInt(Math.Truncate(m_newWidth / proportion)).ToString()
				End If
				If cbxWidthType.SelectedIndex = 1 Then
					tbxHeight.Text = m_newWidth.ToString()
				End If
			End If
		End If
	End Sub

	Private Sub tbxHeight_KeyUp(sender As Object, e As KeyEventArgs)
		If cbxConstrainProportion.Checked = True Then
			If Integer.TryParse(tbxHeight.Text, m_newHeight) = True Then
				Dim proportion As Double = width / CDbl(height)
				If cbxWidthType.SelectedIndex = 0 Then
					tbxWidth.Text = CInt(Math.Truncate(m_newHeight * proportion)).ToString()
				End If
				If cbxWidthType.SelectedIndex = 1 Then
					tbxWidth.Text = m_newHeight.ToString()
				End If
			End If
		End If
	End Sub

	Private Sub btnCancel_Click(sender As Object, e As EventArgs)
		Me.DialogResult = DialogResult.Cancel
		Me.Close()
	End Sub
End Class
