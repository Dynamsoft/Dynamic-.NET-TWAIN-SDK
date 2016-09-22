Public Class Form2

    Dim m_PDFFileName As String
    Dim m_FolderPath As String
    Public Sub New(ByVal strFolderPath As String, ByVal strPDFName As String)

        ' This call is required by the designer.
        InitializeComponent()
        Me.Text = "Set PDF File Name"
        m_FolderPath = strFolderPath
        m_PDFFileName = strPDFName
        tbxPDFName.Text = m_PDFFileName + ".pdf"
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub tbxSetFileName_Click(sender As Object, e As EventArgs) Handles tbxSetFileName.Click
        If tbxPDFName.Text Is Nothing Then
            MessageBox.Show("The name of PDF file has exists,please reset the name!", "Error")
            Exit Sub
        Else
            Dim strNameText As String
            strNameText = tbxPDFName.Text
            For Each Text As Char In strNameText
                For Each temp As Char In System.IO.Path.GetInvalidFileNameChars()
                    If Text = temp Then
                        MessageBox.Show("The name of  PDF file contains  illegal character!", "Warning")
                        Exit Sub
                    End If
                Next
            Next
            Dim FilePath As String = String.Format(m_FolderPath & "\\" & strNameText)
            If (System.IO.File.Exists(FilePath)) Then
                MessageBox.Show("The name of PDF file has exists!", "Warning")
                Exit Sub
            End If
            m_PDFFileName = strNameText
        End If
        Me.Close()
    End Sub
    Public Function GetPDFFileName() As String
        Return (m_PDFFileName)
    End Function
End Class