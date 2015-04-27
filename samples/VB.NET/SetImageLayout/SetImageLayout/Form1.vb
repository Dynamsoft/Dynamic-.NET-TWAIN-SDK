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
    Friend WithEvents edtFrameBottom As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.edtFrameRight = New System.Windows.Forms.TextBox
        Me.edtFrameTop = New System.Windows.Forms.TextBox
        Me.btnSetAndAcquire = New System.Windows.Forms.Button
        Me.edtFrameLeft = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.edtFrameBottom = New System.Windows.Forms.TextBox
        Me.dynamicDotNetTwain = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox1
        '
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
        Me.groupBox1.Size = New System.Drawing.Size(304, 129)
        Me.groupBox1.TabIndex = 12
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Image Layout Information"
        '
        'edtFrameRight
        '
        Me.edtFrameRight.Location = New System.Drawing.Point(96, 60)
        Me.edtFrameRight.Name = "edtFrameRight"
        Me.edtFrameRight.Size = New System.Drawing.Size(48, 20)
        Me.edtFrameRight.TabIndex = 6
        '
        'edtFrameTop
        '
        Me.edtFrameTop.Location = New System.Drawing.Point(240, 26)
        Me.edtFrameTop.Name = "edtFrameTop"
        Me.edtFrameTop.Size = New System.Drawing.Size(48, 20)
        Me.edtFrameTop.TabIndex = 5
        '
        'btnSetAndAcquire
        '
        Me.btnSetAndAcquire.Location = New System.Drawing.Point(24, 94)
        Me.btnSetAndAcquire.Name = "btnSetAndAcquire"
        Me.btnSetAndAcquire.Size = New System.Drawing.Size(96, 26)
        Me.btnSetAndAcquire.TabIndex = 8
        Me.btnSetAndAcquire.Text = "Set and Acquire"
        '
        'edtFrameLeft
        '
        Me.edtFrameLeft.Location = New System.Drawing.Point(96, 26)
        Me.edtFrameLeft.Name = "edtFrameLeft"
        Me.edtFrameLeft.Size = New System.Drawing.Size(48, 20)
        Me.edtFrameLeft.TabIndex = 0
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(160, 60)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(80, 18)
        Me.label4.TabIndex = 3
        Me.label4.Text = "Frame Bottom:"
        Me.label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(16, 60)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(72, 18)
        Me.label3.TabIndex = 2
        Me.label3.Text = "Frame Right:"
        Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(24, 26)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(64, 17)
        Me.label2.TabIndex = 10
        Me.label2.Text = "Frame Left:"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(176, 26)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(64, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Frame Top:"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'edtFrameBottom
        '
        Me.edtFrameBottom.Location = New System.Drawing.Point(240, 60)
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
        Me.dynamicDotNetTwain.IfShowPrintUI = False
        Me.dynamicDotNetTwain.IfThrowException = False
        Me.dynamicDotNetTwain.Location = New System.Drawing.Point(8, 144)
        Me.dynamicDotNetTwain.LogLevel = CType(0, Short)
        Me.dynamicDotNetTwain.Name = "dynamicDotNetTwain"
        Me.dynamicDotNetTwain.PDFMarginBottom = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFMarginLeft = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFMarginRight = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFMarginTop = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFXConformance = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.Size = New System.Drawing.Size(304, 286)
        Me.dynamicDotNetTwain.TabIndex = 13
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(322, 436)
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
        Dim fFrameLeft, fFrameTop, fFrameRight, fFrameBottom As Single

        Try
            fFrameLeft = edtFrameLeft.Text
            fFrameTop = edtFrameTop.Text
            fFrameRight = edtFrameRight.Text
            fFrameBottom = edtFrameBottom.Text
        Catch ex As Exception
            MessageBox.Show("Please input numerical values in the input boxes.", "Error")
            Exit Sub
        End Try


        If dynamicDotNetTwain.SelectSource() Then
            dynamicDotNetTwain.OpenSource()   'make dynamicDotNetTwain ready for capability negotiation

            If (dynamicDotNetTwain.SetImageLayout(fFrameLeft, fFrameTop, fFrameRight, fFrameBottom) = False) Then
                MessageBox.Show(dynamicDotNetTwain.ErrorString, "Error")
            End If

            dynamicDotNetTwain.IfShowUI = False
            dynamicDotNetTwain.IfDisableSourceAfterAcquire = True
            dynamicDotNetTwain.EnableSource()
        End If

    End Sub
End Class
