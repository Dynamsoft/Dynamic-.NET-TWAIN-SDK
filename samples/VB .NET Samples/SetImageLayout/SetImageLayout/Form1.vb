Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim strFileName As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        dynamicDotNetTwain.ScanInNewProcess = True
        If dynamicDotNetTwain.SourceCount > 0 Then
            Dim i As Int16 : i = 0
            For i = 0 To dynamicDotNetTwain.SourceCount - 1 Step 1
                Dim strSourceName As String : strSourceName = dynamicDotNetTwain.SourceNameItems(i)
                If strSourceName IsNot Nothing Then
                    cbxSources.Items.Add(strSourceName)
                End If
            Next i
            cbxSources.SelectedIndex = 0
        Else
            MessageBox.Show(Me, "There is no scanner detected! " & Constants.vbCrLf & "Please ensure that at least one (virtual) scanner is installed.", "Information")
        End If
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents edtFrameRight As System.Windows.Forms.TextBox
    Friend WithEvents edtFrameTop As System.Windows.Forms.TextBox
    Friend WithEvents btnSetAndAcquire As System.Windows.Forms.Button
    Friend WithEvents edtFrameLeft As System.Windows.Forms.TextBox
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents dynamicDotNetTwain As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
    Private WithEvents cbxSources As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFrameTop As System.Windows.Forms.Label
    Friend WithEvents lblFrameRight As System.Windows.Forms.Label
    Friend WithEvents lblFrameLeft As System.Windows.Forms.Label
    Friend WithEvents lblFrameBottom As System.Windows.Forms.Label
    Friend WithEvents edtFrameBottom As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblFrameTop = New System.Windows.Forms.Label()
        Me.lblFrameRight = New System.Windows.Forms.Label()
        Me.lblFrameLeft = New System.Windows.Forms.Label()
        Me.cbxSources = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.edtFrameRight = New System.Windows.Forms.TextBox()
        Me.edtFrameTop = New System.Windows.Forms.TextBox()
        Me.btnSetAndAcquire = New System.Windows.Forms.Button()
        Me.edtFrameLeft = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.edtFrameBottom = New System.Windows.Forms.TextBox()
        Me.dynamicDotNetTwain = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain()
        Me.lblFrameBottom = New System.Windows.Forms.Label()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.lblFrameBottom)
        Me.groupBox1.Controls.Add(Me.lblFrameTop)
        Me.groupBox1.Controls.Add(Me.lblFrameRight)
        Me.groupBox1.Controls.Add(Me.lblFrameLeft)
        Me.groupBox1.Controls.Add(Me.cbxSources)
        Me.groupBox1.Controls.Add(Me.Label5)
        Me.groupBox1.Controls.Add(Me.edtFrameRight)
        Me.groupBox1.Controls.Add(Me.edtFrameTop)
        Me.groupBox1.Controls.Add(Me.btnSetAndAcquire)
        Me.groupBox1.Controls.Add(Me.edtFrameLeft)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.edtFrameBottom)
        Me.groupBox1.Location = New System.Drawing.Point(8, 9)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(496, 168)
        Me.groupBox1.TabIndex = 12
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Image Layout Information"
        '
        'lblFrameTop
        '
        Me.lblFrameTop.AutoSize = True
        Me.lblFrameTop.Location = New System.Drawing.Point(413, 67)
        Me.lblFrameTop.Name = "lblFrameTop"
        Me.lblFrameTop.Size = New System.Drawing.Size(0, 13)
        Me.lblFrameTop.TabIndex = 18
        '
        'lblFrameRight
        '
        Me.lblFrameRight.AutoSize = True
        Me.lblFrameRight.Location = New System.Drawing.Point(171, 106)
        Me.lblFrameRight.Name = "lblFrameRight"
        Me.lblFrameRight.Size = New System.Drawing.Size(0, 13)
        Me.lblFrameRight.TabIndex = 17
        '
        'lblFrameLeft
        '
        Me.lblFrameLeft.AutoSize = True
        Me.lblFrameLeft.Location = New System.Drawing.Point(171, 67)
        Me.lblFrameLeft.Name = "lblFrameLeft"
        Me.lblFrameLeft.Size = New System.Drawing.Size(0, 13)
        Me.lblFrameLeft.TabIndex = 16
        '
        'cbxSources
        '
        Me.cbxSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSources.FormattingEnabled = True
        Me.cbxSources.Location = New System.Drawing.Point(183, 28)
        Me.cbxSources.Name = "cbxSources"
        Me.cbxSources.Size = New System.Drawing.Size(131, 21)
        Me.cbxSources.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(48, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Select Scources:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'edtFrameRight
        '
        Me.edtFrameRight.Location = New System.Drawing.Point(96, 98)
        Me.edtFrameRight.Name = "edtFrameRight"
        Me.edtFrameRight.Size = New System.Drawing.Size(48, 20)
        Me.edtFrameRight.TabIndex = 6
        '
        'edtFrameTop
        '
        Me.edtFrameTop.Location = New System.Drawing.Point(341, 64)
        Me.edtFrameTop.Name = "edtFrameTop"
        Me.edtFrameTop.Size = New System.Drawing.Size(48, 20)
        Me.edtFrameTop.TabIndex = 5
        '
        'btnSetAndAcquire
        '
        Me.btnSetAndAcquire.Location = New System.Drawing.Point(24, 132)
        Me.btnSetAndAcquire.Name = "btnSetAndAcquire"
        Me.btnSetAndAcquire.Size = New System.Drawing.Size(96, 26)
        Me.btnSetAndAcquire.TabIndex = 8
        Me.btnSetAndAcquire.Text = "Set and Acquire"
        '
        'edtFrameLeft
        '
        Me.edtFrameLeft.Location = New System.Drawing.Point(96, 64)
        Me.edtFrameLeft.Name = "edtFrameLeft"
        Me.edtFrameLeft.Size = New System.Drawing.Size(48, 20)
        Me.edtFrameLeft.TabIndex = 0
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(235, 101)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(80, 18)
        Me.label4.TabIndex = 3
        Me.label4.Text = "Frame Bottom:"
        Me.label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(16, 98)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(72, 18)
        Me.label3.TabIndex = 2
        Me.label3.Text = "Frame Right:"
        Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(24, 64)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(64, 17)
        Me.label2.TabIndex = 10
        Me.label2.Text = "Frame Left:"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(251, 65)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(64, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Frame Top:"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'edtFrameBottom
        '
        Me.edtFrameBottom.Location = New System.Drawing.Point(341, 98)
        Me.edtFrameBottom.Name = "edtFrameBottom"
        Me.edtFrameBottom.Size = New System.Drawing.Size(48, 20)
        Me.edtFrameBottom.TabIndex = 7
        '
        'dynamicDotNetTwain
        '
        Me.dynamicDotNetTwain.AnnotationFillColor = System.Drawing.Color.White
        Me.dynamicDotNetTwain.AnnotationPen = Nothing
        Me.dynamicDotNetTwain.AnnotationTextColor = System.Drawing.Color.Black
        Me.dynamicDotNetTwain.AnnotationTextFont = Nothing
        'Me.dynamicDotNetTwain.IfShowCancelDialogWhenImageTransfer = False
        Me.dynamicDotNetTwain.IfShowPrintUI = False
        Me.dynamicDotNetTwain.IfThrowException = False
        Me.dynamicDotNetTwain.Location = New System.Drawing.Point(8, 183)
        Me.dynamicDotNetTwain.LogLevel = CType(0, Short)
        Me.dynamicDotNetTwain.Name = "dynamicDotNetTwain"
        Me.dynamicDotNetTwain.PDFMarginBottom = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFMarginLeft = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFMarginRight = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFMarginTop = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFXConformance = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dynamicDotNetTwain.Size = New System.Drawing.Size(496, 286)
        Me.dynamicDotNetTwain.TabIndex = 13
        '
        'lblFrameBottom
        '
        Me.lblFrameBottom.AutoSize = True
        Me.lblFrameBottom.Location = New System.Drawing.Point(413, 101)
        Me.lblFrameBottom.Name = "lblFrameBottom"
        Me.lblFrameBottom.Size = New System.Drawing.Size(0, 13)
        Me.lblFrameBottom.TabIndex = 19
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(516, 481)
        Me.Controls.Add(Me.dynamicDotNetTwain)
        Me.Controls.Add(Me.groupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Set Image Layout"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnSetAndAcquire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAndAcquire.Click
        Dim fTemp, fFrameLeft, fFrameTop, fFrameRight, fFrameBottom As Single

        Try
            fFrameLeft = edtFrameLeft.Text
            fFrameTop = edtFrameTop.Text
            fFrameRight = edtFrameRight.Text
            fFrameBottom = edtFrameBottom.Text
            If fFrameLeft > fFrameRight Then
                fTemp = fFrameLeft
                fFrameLeft = fFrameRight
                fFrameRight = fTemp
            End If
            If fFrameTop > fFrameBottom Then
                fTemp = fFrameTop
                fFrameTop = fFrameBottom
                fFrameBottom = fTemp
            End If
            If fFrameLeft = fFrameRight Or fFrameTop = fFrameBottom Then
                MessageBox.Show("Input Value Error: don't make left equal to right, or top equal to bottom.", "Error")
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Please input numerical values in the input boxes.", "Error")
            Exit Sub
        End Try

        dynamicDotNetTwain.LicenseKeys = "83C721A603BF5301ABCF850504F7B744;83C721A603BF5301AC7A3AA0DF1D92E6;83C721A603BF5301E22CBEC2DD20B511;83C721A603BF5301977D72EA5256A044;83C721A603BF53014332D52C75036F9E;83C721A603BF53010090AB799ED7E55E"
        'If dynamicDotNetTwain.SelectSource() Then
        '    dynamicDotNetTwain.OpenSource()   'make dynamicDotNetTwain ready for capability negotiation

        If fFrameLeft < fDefaultFrameLeft Or fFrameTop < fDefaultFrameTop Or fFrameRight > fDefaultFrameRight Or fFrameBottom > fDefaultFrameBottom Then
            Dim drImageLayout As DialogResult
            drImageLayout = MessageBox.Show("Input values are out of rangles, do you want to continue?", "Warning", MessageBoxButtons.YesNo)
            If drImageLayout = DialogResult.Yes Then
            Else
                Exit Sub
            End If
        End If
        If (dynamicDotNetTwain.SetImageLayout(fFrameLeft, fFrameTop, fFrameRight, fFrameBottom) = False) Then
            MessageBox.Show(dynamicDotNetTwain.ErrorString, "Error")
        End If

        dynamicDotNetTwain.IfShowUI = False
        dynamicDotNetTwain.IfDisableSourceAfterAcquire = True
        dynamicDotNetTwain.EnableSource()
        'End If

    End Sub
    Dim fDefaultFrameLeft, fDefaultFrameTop, fDefaultFrameRight, fDefaultFrameBottom As Single 

    Private Sub cbxSources_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxSources.SelectedIndexChanged
        If cbxSources.SelectedIndex >= 0 And cbxSources.SelectedIndex < dynamicDotNetTwain.SourceCount Then
            dynamicDotNetTwain.SelectSourceByIndex(cbxSources.SelectedIndex)
            dynamicDotNetTwain.OpenSource()

            dynamicDotNetTwain.GetImageLayout(fDefaultFrameLeft, fDefaultFrameTop, fDefaultFrameRight, fDefaultFrameBottom)
            fDefaultFrameLeft = Int(fDefaultFrameLeft * 10) / 10
            fDefaultFrameTop = Int(fDefaultFrameTop * 10) / 10
            fDefaultFrameRight = Int(fDefaultFrameRight * 10) / 10
            fDefaultFrameBottom = Int(fDefaultFrameBottom * 10) / 10

            edtFrameLeft.Text = (fDefaultFrameLeft).ToString()
            edtFrameTop.Text = FDefaultFrameTop.ToString()
            edtFrameRight.Text = fDefaultFrameRight.ToString()
            edtFrameBottom.Text = fDefaultFrameBottom.ToString()
            lblFrameLeft.Text = "(0 ~ " & fDefaultFrameRight.ToString() & ")"
            lblFrameTop.Text = "(0 ~ " & fDefaultFrameBottom.ToString() & ")"
            lblFrameRight.Text = "(0 ~ " & fDefaultFrameRight.ToString() & ")"
            lblFrameBottom.Text = "(0 ~ " & fDefaultFrameBottom.ToString() & ")"




        End If
    End Sub

End Class
