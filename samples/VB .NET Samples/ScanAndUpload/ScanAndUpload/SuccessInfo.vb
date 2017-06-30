Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Partial Class SuccessInfo
	Inherits Form
	Private m_strImageName As String = "DNT_Image.jpg"
	Public Sub New(strImageName As String)
		If strImageName <> "" Then
			m_strImageName = strImageName
		End If
		InitializeComponent()
	End Sub

	Private Sub SuccessInfo_Load(sender As Object, e As EventArgs)
		If m_strImageName.Length > 15 Then
			Me.lblInfo.Text = m_strImageName.Substring(0, 5) & "..." & m_strImageName.Substring(m_strImageName.Length - 7, 7) & " successfully uploaded to www.dynamsoft.com. It can be accessed at "
		Else
			Me.lblInfo.Text = m_strImageName & " successfully uploaded to www.dynamsoft.com. It can be accessed at "
		End If
		Me.lblLink.Text = "http://www.dynamsoft.com/demo/DNT/online_demo_list.aspx"
	End Sub

	Private Sub button1_Click(sender As Object, e As EventArgs)
		Me.Close()
	End Sub

	Private Sub lblLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
		System.Diagnostics.Process.Start("http://www.dynamsoft.com/demo/DNT/online_demo_list.aspx")
	End Sub
End Class
