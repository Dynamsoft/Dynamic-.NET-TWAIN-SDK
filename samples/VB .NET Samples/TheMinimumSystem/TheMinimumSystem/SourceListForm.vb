Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Partial Class SourceListForm
	Inherits Form
	Private m_ListSourceNames As List(Of String) = Nothing
	Private m_SelectedIndex As Integer = -1
	Public Sub New(listSourceNames As List(Of String))
		InitializeComponent()
		m_ListSourceNames = listSourceNames
		If m_ListSourceNames Is Nothing Then
			button1.Enabled = False
		End If

		For Each temp As String In m_ListSourceNames
			listBox1.Items.Add(temp)
		Next
		listBox1.SelectedIndex = m_ListSourceNames.Count - 1
	End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        m_SelectedIndex = listBox1.SelectedIndex
        Me.Close()
    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        Me.Close()

    End Sub

	Public Function GetSelectedIndex() As Integer
		Return m_SelectedIndex
	End Function
End Class
