Imports Dynamsoft.DotNet.TWAIN.Enums

Public Class Form1

    Private Sub btnSetCapability_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetCapability.Click
        dynamicDotNetTwain1.LicenseKeys = "83C721A603BF5301ABCF850504F7B744;83C721A603BF5301AC7A3AA0DF1D92E6;83C721A603BF5301E22CBEC2DD20B511;83C721A603BF5301977D72EA5256A044;83C721A603BF53014332D52C75036F9E;83C721A603BF53010090AB799ED7E55E"
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
        dynamicDotNetTwain1.IfDisableSourceAfterAcquire = True
        dynamicDotNetTwain1.AcquireImage()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dynamicDotNetTwain1.ScanInNewProcess = True
    End Sub
End Class
