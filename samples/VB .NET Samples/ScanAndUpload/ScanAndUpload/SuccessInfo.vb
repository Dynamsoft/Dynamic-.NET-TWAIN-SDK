Public Class SuccessInfo
    Dim m_strImageName As String

    Private Sub SuccessInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (m_strImageName = "") Then
            m_strImageName = "DNT_Image.jpg"
        End If
        SetSuccessInfo(m_strImageName)
    End Sub

    Public Sub SetSuccessInfo(ByVal strImageName As String)
        m_strImageName = strImageName
        If (m_strImageName.Length > 15) Then
            Me.lblInfo.Text = m_strImageName.Substring(0, 5) + "..." + m_strImageName.Substring(m_strImageName.Length - 7, 7) + " successfully uploaded to www.dynamsoft.com. It can be accessed at "
        Else
            Me.lblInfo.Text = m_strImageName + " successfully uploaded to www.dynamsoft.com. It can be accessed at "
        End If
        Me.lblLink.Text = "http://www.dynamsoft.com/demo/DNT/online_demo_list.aspx"
    End Sub

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        Me.Close()
    End Sub

    Private Sub lblLink_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblLink.LinkClicked
        System.Diagnostics.Process.Start("http://www.dynamsoft.com/demo/DNT/online_demo_list.aspx")
    End Sub
End Class