Imports System.Collections.Generic
Imports System.Text

Public Class SourceListWrapper
	Private m_listSourceNames As List(Of String) = Nothing
	Public Sub New(listSourceNames As List(Of String))
		m_listSourceNames = listSourceNames
	End Sub

	Private m_SelectedIndex As Integer = 0
	Public Function SelectSource() As Integer
		Dim temp As New SourceListForm(m_listSourceNames)
		temp.ShowDialog()
		m_SelectedIndex = temp.GetSelectedIndex()
		Return m_SelectedIndex
	End Function

End Class
