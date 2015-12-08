<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DynamicDotNetTwain1 = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnRecognize = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.gbSelectedArea = New System.Windows.Forms.GroupBox()
        Me.tbxTop = New System.Windows.Forms.TextBox()
        Me.tbxBottom = New System.Windows.Forms.TextBox()
        Me.tbxRight = New System.Windows.Forms.TextBox()
        Me.tbxLeft = New System.Windows.Forms.TextBox()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.lblBottom = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.lblRight = New System.Windows.Forms.Label()
        Me.tbxMaxNum = New System.Windows.Forms.TextBox()
        Me.cbxFormat = New System.Windows.Forms.ComboBox()
        Me.lblMaxNum = New System.Windows.Forms.Label()
        Me.lblFormat = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.gbSelectedArea.SuspendLayout()
        Me.SuspendLayout()
        '
        'DynamicDotNetTwain1
        '
        Me.DynamicDotNetTwain1.AnnotationFillColor = System.Drawing.Color.White
        Me.DynamicDotNetTwain1.AnnotationPen = Nothing
        Me.DynamicDotNetTwain1.AnnotationTextColor = System.Drawing.Color.Black
        Me.DynamicDotNetTwain1.AnnotationTextFont = Nothing
        Me.DynamicDotNetTwain1.IfShowCancelDialogWhenImageTransfer = False
        Me.DynamicDotNetTwain1.IfShowPrintUI = False
        Me.DynamicDotNetTwain1.IfThrowException = False
        Me.DynamicDotNetTwain1.Location = New System.Drawing.Point(12, 12)
        Me.DynamicDotNetTwain1.LogLevel = CType(0, Short)
        Me.DynamicDotNetTwain1.Name = "DynamicDotNetTwain1"
        Me.DynamicDotNetTwain1.PDFMarginBottom = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.PDFMarginLeft = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.PDFMarginRight = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.PDFMarginTop = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.PDFXConformance = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DynamicDotNetTwain1.Size = New System.Drawing.Size(458, 303)
        Me.DynamicDotNetTwain1.TabIndex = 0
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(12, 321)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 1
        Me.btnOpen.Text = "Open Image"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnRecognize
        '
        Me.btnRecognize.Location = New System.Drawing.Point(18, 448)
        Me.btnRecognize.Name = "btnRecognize"
        Me.btnRecognize.Size = New System.Drawing.Size(75, 23)
        Me.btnRecognize.TabIndex = 2
        Me.btnRecognize.Text = "Recognize"
        Me.btnRecognize.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.Location = New System.Drawing.Point(12, 479)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(458, 98)
        Me.TextBox1.TabIndex = 3
        '
        'gbSelectedArea
        '
        Me.gbSelectedArea.Controls.Add(Me.tbxTop)
        Me.gbSelectedArea.Controls.Add(Me.tbxBottom)
        Me.gbSelectedArea.Controls.Add(Me.tbxRight)
        Me.gbSelectedArea.Controls.Add(Me.tbxLeft)
        Me.gbSelectedArea.Controls.Add(Me.lblTop)
        Me.gbSelectedArea.Controls.Add(Me.lblBottom)
        Me.gbSelectedArea.Controls.Add(Me.lblLeft)
        Me.gbSelectedArea.Controls.Add(Me.lblRight)
        Me.gbSelectedArea.Location = New System.Drawing.Point(18, 381)
        Me.gbSelectedArea.Name = "gbSelectedArea"
        Me.gbSelectedArea.Size = New System.Drawing.Size(455, 60)
        Me.gbSelectedArea.TabIndex = 19
        Me.gbSelectedArea.TabStop = False
        Me.gbSelectedArea.Text = "Selected Rectangle Area Of the Image"
        '
        'tbxTop
        '
        Me.tbxTop.Location = New System.Drawing.Point(267, 24)
        Me.tbxTop.Name = "tbxTop"
        Me.tbxTop.ReadOnly = True
        Me.tbxTop.Size = New System.Drawing.Size(52, 20)
        Me.tbxTop.TabIndex = 21
        Me.tbxTop.Text = "0"
        '
        'tbxBottom
        '
        Me.tbxBottom.Location = New System.Drawing.Point(388, 24)
        Me.tbxBottom.Name = "tbxBottom"
        Me.tbxBottom.ReadOnly = True
        Me.tbxBottom.Size = New System.Drawing.Size(52, 20)
        Me.tbxBottom.TabIndex = 20
        '
        'tbxRight
        '
        Me.tbxRight.Location = New System.Drawing.Point(163, 24)
        Me.tbxRight.Name = "tbxRight"
        Me.tbxRight.ReadOnly = True
        Me.tbxRight.Size = New System.Drawing.Size(54, 20)
        Me.tbxRight.TabIndex = 19
        '
        'tbxLeft
        '
        Me.tbxLeft.Location = New System.Drawing.Point(52, 24)
        Me.tbxLeft.Name = "tbxLeft"
        Me.tbxLeft.ReadOnly = True
        Me.tbxLeft.Size = New System.Drawing.Size(51, 20)
        Me.tbxLeft.TabIndex = 18
        Me.tbxLeft.Text = "0"
        '
        'lblTop
        '
        Me.lblTop.AutoSize = True
        Me.lblTop.Location = New System.Drawing.Point(238, 27)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(22, 13)
        Me.lblTop.TabIndex = 17
        Me.lblTop.Text = "top"
        '
        'lblBottom
        '
        Me.lblBottom.AutoSize = True
        Me.lblBottom.Location = New System.Drawing.Point(342, 27)
        Me.lblBottom.Name = "lblBottom"
        Me.lblBottom.Size = New System.Drawing.Size(39, 13)
        Me.lblBottom.TabIndex = 16
        Me.lblBottom.Text = "bottom"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = True
        Me.lblLeft.Location = New System.Drawing.Point(15, 27)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(21, 13)
        Me.lblLeft.TabIndex = 15
        Me.lblLeft.Text = "left"
        '
        'lblRight
        '
        Me.lblRight.AutoSize = True
        Me.lblRight.Location = New System.Drawing.Point(122, 27)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(27, 13)
        Me.lblRight.TabIndex = 14
        Me.lblRight.Text = "right"
        '
        'tbxMaxNum
        '
        Me.tbxMaxNum.Location = New System.Drawing.Point(353, 354)
        Me.tbxMaxNum.Name = "tbxMaxNum"
        Me.tbxMaxNum.Size = New System.Drawing.Size(46, 20)
        Me.tbxMaxNum.TabIndex = 18
        '
        'cbxFormat
        '
        Me.cbxFormat.FormattingEnabled = True
        Me.cbxFormat.Location = New System.Drawing.Point(103, 354)
        Me.cbxFormat.Name = "cbxFormat"
        Me.cbxFormat.Size = New System.Drawing.Size(121, 21)
        Me.cbxFormat.TabIndex = 17
        '
        'lblMaxNum
        '
        Me.lblMaxNum.AutoSize = True
        Me.lblMaxNum.Location = New System.Drawing.Point(256, 357)
        Me.lblMaxNum.Name = "lblMaxNum"
        Me.lblMaxNum.Size = New System.Drawing.Size(91, 13)
        Me.lblMaxNum.TabIndex = 16
        Me.lblMaxNum.Text = "Maximum Number"
        '
        'lblFormat
        '
        Me.lblFormat.AutoSize = True
        Me.lblFormat.Location = New System.Drawing.Point(15, 357)
        Me.lblFormat.Name = "lblFormat"
        Me.lblFormat.Size = New System.Drawing.Size(82, 13)
        Me.lblFormat.TabIndex = 15
        Me.lblFormat.Text = "Barcode Format"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(12, 580)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(458, 13)
        Me.label1.TabIndex = 20
        Me.label1.Text = "Note: PDF Rasterizer add-on is used when loading PDF files."
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 600)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.gbSelectedArea)
        Me.Controls.Add(Me.tbxMaxNum)
        Me.Controls.Add(Me.cbxFormat)
        Me.Controls.Add(Me.lblMaxNum)
        Me.Controls.Add(Me.lblFormat)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnRecognize)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.DynamicDotNetTwain1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Barcode Reader"
        Me.gbSelectedArea.ResumeLayout(False)
        Me.gbSelectedArea.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DynamicDotNetTwain1 As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnRecognize As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Private WithEvents gbSelectedArea As System.Windows.Forms.GroupBox
    Private WithEvents tbxTop As System.Windows.Forms.TextBox
    Private WithEvents tbxBottom As System.Windows.Forms.TextBox
    Private WithEvents tbxRight As System.Windows.Forms.TextBox
    Private WithEvents tbxLeft As System.Windows.Forms.TextBox
    Private WithEvents lblTop As System.Windows.Forms.Label
    Private WithEvents lblBottom As System.Windows.Forms.Label
    Private WithEvents lblLeft As System.Windows.Forms.Label
    Private WithEvents lblRight As System.Windows.Forms.Label
    Private WithEvents tbxMaxNum As System.Windows.Forms.TextBox
    Private WithEvents cbxFormat As System.Windows.Forms.ComboBox
    Private WithEvents lblMaxNum As System.Windows.Forms.Label
    Private WithEvents lblFormat As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label

End Class
