Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Partial Class Form2
	Inherits Form
	Private m_PDFFileName As String = Nothing
	Private m_FolderPath As String = Nothing
	Public Sub New()
		InitializeComponent()
	End Sub

	Public Sub New(strFolderPath As String, strPDFName As String)
		InitializeComponent()
		Me.Text = "Set PDF File Name"
		m_PDFFileName = strPDFName
		tbxPDFName.Text = m_PDFFileName & ".pdf"
		m_FolderPath = strFolderPath
	End Sub
	Private Sub tbxSetFileName_Click(sender As Object, e As EventArgs)
		If tbxPDFName.Text IsNot Nothing Then
			Dim strNameText As String = Nothing
			strNameText = tbxPDFName.Text
			For Each text As Char In strNameText
				For Each temp As Char In System.IO.Path.GetInvalidFileNameChars()
					If text = temp Then
						MessageBox.Show("The name of  PDF file contains  illegal character!", "Error")
						Return

					End If
				Next
			Next
			Dim FilePath As String = m_FolderPath & "\" & strNameText
			If System.IO.File.Exists(FilePath) Then
				MessageBox.Show("The name of PDF file has exists!", "Warning")
				Return
			End If
			m_PDFFileName = tbxPDFName.Text
		Else
			MessageBox.Show(" The name of PDF file can not be null!", "Warning")
			Return
		End If
		Me.Close()
	End Sub
	Public Function GetPDfFileName() As String
		Return m_PDFFileName
	End Function
End Class
