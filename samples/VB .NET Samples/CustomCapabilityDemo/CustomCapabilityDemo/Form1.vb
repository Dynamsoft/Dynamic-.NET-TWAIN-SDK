Imports Dynamsoft.DotNet.TWAIN.Enums

Public Class Form1

    Private Sub btnSetCapability_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetCapability.Click
        dynamicDotNetTwain1.LicenseKeys = "BAF81AB5515958BF519F7AAE2A318B3B;BAF81AB5515958BF6DA4299CBA3CC11D;BAF81AB5515958BF9C195A4722534974;BAF81AB5515958BFE96B7433DD28E75B;BAF81AB5515958BF3DBAF9AB37059787;BAF81AB5515958BF5291EEE0B030BD82"
        If dynamicDotNetTwain1.SelectSource() Then
            dynamicDotNetTwain1.OpenSource()
            Dim cap As Dynamsoft.DotNet.TWAIN.Enums.TWCapability
            'If you wish to make use of a scanner property not included in our SDK, 
            'you just need to specify its capability code. 
            'The default CAP code in this section is 0x:8001. 
            cap = CType(System.Enum.Parse(GetType(TWCapability), Val("&H" & 8001)), TWCapability)
            dynamicDotNetTwain1.Capability = cap  'Custom CAP 0x:8001
            dynamicDotNetTwain1.CapType = Dynamsoft.DotNet.TWAIN.Enums.TWCapType.TWON_ONEVALUE
            dynamicDotNetTwain1.CapValue = 0
            Dim bRet As Boolean
            bRet = dynamicDotNetTwain1.CapSet()
            Dim dblValue As Double
            dblValue = dynamicDotNetTwain1.CapValue
            If (bRet) Then
                MessageBox.Show("Successful.")
            Else
                MessageBox.Show("Failed.\r\n" + dynamicDotNetTwain1.ErrorString)
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If dynamicDotNetTwain1.SelectSource() Then
            dynamicDotNetTwain1.OpenSource()
            Dim cap As Dynamsoft.DotNet.TWAIN.Enums.TWCapability
            cap = CType(System.Enum.Parse(GetType(TWCapability), Val("&H" & 8002)), TWCapability)
            dynamicDotNetTwain1.Capability = cap   'Custom CAP0x:8002
            dynamicDotNetTwain1.CapType = Dynamsoft.DotNet.TWAIN.Enums.TWCapType.TWON_ONEVALUE
            dynamicDotNetTwain1.CapValue = 1
            Dim bRet As Boolean
            bRet = dynamicDotNetTwain1.CapSet()
            Dim dblValue As Double
            dblValue = dynamicDotNetTwain1.CapValue
            If (bRet) Then
                MessageBox.Show("Successful.")
            Else
                MessageBox.Show("Failed.\r\n" + dynamicDotNetTwain1.ErrorString)
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        dynamicDotNetTwain1.IfShowUI = True
        dynamicDotNetTwain1.AcquireImage()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dynamicDotNetTwain1.ScanInNewProcess = True
    End Sub
End Class
