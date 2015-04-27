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
        Me.dynamicDotNetTwain1 = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
        Me.grpOCRResult = New System.Windows.Forms.GroupBox
        Me.btnOCRArea = New System.Windows.Forms.Button
        Me.grpSelectedArea = New System.Windows.Forms.GroupBox
        Me.tbxTop = New System.Windows.Forms.TextBox
        Me.tbxBottom = New System.Windows.Forms.TextBox
        Me.tbxRight = New System.Windows.Forms.TextBox
        Me.tbxLeft = New System.Windows.Forms.TextBox
        Me.lblTop = New System.Windows.Forms.Label
        Me.lblBottom = New System.Windows.Forms.Label
        Me.lblLeft = New System.Windows.Forms.Label
        Me.lblRight = New System.Windows.Forms.Label
        Me.cbxOCRLanguage = New System.Windows.Forms.ComboBox
        Me.lblLanguage = New System.Windows.Forms.Label
        Me.lblFormat = New System.Windows.Forms.Label
        Me.ddlResultFormat = New System.Windows.Forms.ComboBox
        Me.btnSelectedOCR = New System.Windows.Forms.Button
        Me.btnLoad = New System.Windows.Forms.Button
        Me.lblViewMode = New System.Windows.Forms.Label
        Me.cbxViewMode = New System.Windows.Forms.ComboBox
        Me.label1 = New System.Windows.Forms.Label
        Me.grpOCRResult.SuspendLayout()
        Me.grpSelectedArea.SuspendLayout()
        Me.SuspendLayout()
        '
        'dynamicDotNetTwain1
        '
        Me.dynamicDotNetTwain1.AnnotationFillColor = System.Drawing.Color.White
        Me.dynamicDotNetTwain1.AnnotationPen = Nothing
        Me.dynamicDotNetTwain1.AnnotationTextColor = System.Drawing.Color.Black
        Me.dynamicDotNetTwain1.AnnotationTextFont = Nothing
        Me.dynamicDotNetTwain1.IfShowCancelDialogWhenImageTransfer = False
        Me.dynamicDotNetTwain1.IfShowPrintUI = False
        Me.dynamicDotNetTwain1.IfThrowException = False
        Me.dynamicDotNetTwain1.Location = New System.Drawing.Point(18, 21)
        Me.dynamicDotNetTwain1.LogLevel = CType(0, Short)
        Me.dynamicDotNetTwain1.Name = "dynamicDotNetTwain1"
        Me.dynamicDotNetTwain1.PDFMarginBottom = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginLeft = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginRight = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginTop = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFXConformance = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dynamicDotNetTwain1.Size = New System.Drawing.Size(514, 434)
        Me.dynamicDotNetTwain1.TabIndex = 11
        '
        'grpOCRResult
        '
        Me.grpOCRResult.Controls.Add(Me.btnOCRArea)
        Me.grpOCRResult.Controls.Add(Me.grpSelectedArea)
        Me.grpOCRResult.Controls.Add(Me.cbxOCRLanguage)
        Me.grpOCRResult.Controls.Add(Me.lblLanguage)
        Me.grpOCRResult.Controls.Add(Me.lblFormat)
        Me.grpOCRResult.Controls.Add(Me.ddlResultFormat)
        Me.grpOCRResult.Controls.Add(Me.btnSelectedOCR)
        Me.grpOCRResult.Location = New System.Drawing.Point(541, 67)
        Me.grpOCRResult.Name = "grpOCRResult"
        Me.grpOCRResult.Size = New System.Drawing.Size(210, 314)
        Me.grpOCRResult.TabIndex = 13
        Me.grpOCRResult.TabStop = False
        Me.grpOCRResult.Text = "OCR Result"
        '
        'btnOCRArea
        '
        Me.btnOCRArea.Location = New System.Drawing.Point(7, 270)
        Me.btnOCRArea.Name = "btnOCRArea"
        Me.btnOCRArea.Size = New System.Drawing.Size(193, 23)
        Me.btnOCRArea.TabIndex = 21
        Me.btnOCRArea.Text = "OCR Selected Area"
        Me.btnOCRArea.UseVisualStyleBackColor = True
        '
        'grpSelectedArea
        '
        Me.grpSelectedArea.Controls.Add(Me.tbxTop)
        Me.grpSelectedArea.Controls.Add(Me.tbxBottom)
        Me.grpSelectedArea.Controls.Add(Me.tbxRight)
        Me.grpSelectedArea.Controls.Add(Me.tbxLeft)
        Me.grpSelectedArea.Controls.Add(Me.lblTop)
        Me.grpSelectedArea.Controls.Add(Me.lblBottom)
        Me.grpSelectedArea.Controls.Add(Me.lblLeft)
        Me.grpSelectedArea.Controls.Add(Me.lblRight)
        Me.grpSelectedArea.Location = New System.Drawing.Point(0, 171)
        Me.grpSelectedArea.Name = "grpSelectedArea"
        Me.grpSelectedArea.Size = New System.Drawing.Size(210, 79)
        Me.grpSelectedArea.TabIndex = 22
        Me.grpSelectedArea.TabStop = False
        Me.grpSelectedArea.Text = "Selected Rectangle Area Of the Image"
        '
        'tbxTop
        '
        Me.tbxTop.Location = New System.Drawing.Point(144, 24)
        Me.tbxTop.Name = "tbxTop"
        Me.tbxTop.ReadOnly = True
        Me.tbxTop.Size = New System.Drawing.Size(49, 20)
        Me.tbxTop.TabIndex = 21
        Me.tbxTop.Text = "0"
        '
        'tbxBottom
        '
        Me.tbxBottom.Location = New System.Drawing.Point(144, 50)
        Me.tbxBottom.Name = "tbxBottom"
        Me.tbxBottom.ReadOnly = True
        Me.tbxBottom.Size = New System.Drawing.Size(49, 20)
        Me.tbxBottom.TabIndex = 20
        '
        'tbxRight
        '
        Me.tbxRight.Location = New System.Drawing.Point(33, 50)
        Me.tbxRight.Name = "tbxRight"
        Me.tbxRight.ReadOnly = True
        Me.tbxRight.Size = New System.Drawing.Size(51, 20)
        Me.tbxRight.TabIndex = 19
        '
        'tbxLeft
        '
        Me.tbxLeft.Location = New System.Drawing.Point(33, 24)
        Me.tbxLeft.Name = "tbxLeft"
        Me.tbxLeft.ReadOnly = True
        Me.tbxLeft.Size = New System.Drawing.Size(51, 20)
        Me.tbxLeft.TabIndex = 18
        Me.tbxLeft.Text = "0"
        '
        'lblTop
        '
        Me.lblTop.AutoSize = True
        Me.lblTop.Location = New System.Drawing.Point(99, 27)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(22, 13)
        Me.lblTop.TabIndex = 17
        Me.lblTop.Text = "top"
        '
        'lblBottom
        '
        Me.lblBottom.AutoSize = True
        Me.lblBottom.Location = New System.Drawing.Point(99, 53)
        Me.lblBottom.Name = "lblBottom"
        Me.lblBottom.Size = New System.Drawing.Size(39, 13)
        Me.lblBottom.TabIndex = 16
        Me.lblBottom.Text = "bottom"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = True
        Me.lblLeft.Location = New System.Drawing.Point(6, 27)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(21, 13)
        Me.lblLeft.TabIndex = 15
        Me.lblLeft.Text = "left"
        '
        'lblRight
        '
        Me.lblRight.AutoSize = True
        Me.lblRight.Location = New System.Drawing.Point(6, 53)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(27, 13)
        Me.lblRight.TabIndex = 14
        Me.lblRight.Text = "right"
        '
        'cbxOCRLanguage
        '
        Me.cbxOCRLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxOCRLanguage.FormattingEnabled = True
        Me.cbxOCRLanguage.Location = New System.Drawing.Point(10, 43)
        Me.cbxOCRLanguage.Name = "cbxOCRLanguage"
        Me.cbxOCRLanguage.Size = New System.Drawing.Size(192, 21)
        Me.cbxOCRLanguage.TabIndex = 13
        '
        'lblLanguage
        '
        Me.lblLanguage.AutoSize = True
        Me.lblLanguage.Location = New System.Drawing.Point(8, 27)
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Size = New System.Drawing.Size(75, 13)
        Me.lblLanguage.TabIndex = 12
        Me.lblLanguage.Text = "Ocr Language"
        '
        'lblFormat
        '
        Me.lblFormat.AutoSize = True
        Me.lblFormat.Location = New System.Drawing.Point(6, 74)
        Me.lblFormat.Name = "lblFormat"
        Me.lblFormat.Size = New System.Drawing.Size(111, 13)
        Me.lblFormat.TabIndex = 6
        Me.lblFormat.Text = "Ocr Result File Format"
        '
        'ddlResultFormat
        '
        Me.ddlResultFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlResultFormat.FormattingEnabled = True
        Me.ddlResultFormat.Location = New System.Drawing.Point(9, 90)
        Me.ddlResultFormat.Name = "ddlResultFormat"
        Me.ddlResultFormat.Size = New System.Drawing.Size(192, 21)
        Me.ddlResultFormat.TabIndex = 7
        '
        'btnSelectedOCR
        '
        Me.btnSelectedOCR.Location = New System.Drawing.Point(9, 129)
        Me.btnSelectedOCR.Name = "btnSelectedOCR"
        Me.btnSelectedOCR.Size = New System.Drawing.Size(192, 23)
        Me.btnSelectedOCR.TabIndex = 2
        Me.btnSelectedOCR.Text = "OCR Selected Image"
        Me.btnSelectedOCR.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(541, 24)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(188, 23)
        Me.btnLoad.TabIndex = 12
        Me.btnLoad.Text = "Load Image"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'lblViewMode
        '
        Me.lblViewMode.AutoSize = True
        Me.lblViewMode.Location = New System.Drawing.Point(16, 462)
        Me.lblViewMode.Name = "lblViewMode"
        Me.lblViewMode.Size = New System.Drawing.Size(60, 13)
        Me.lblViewMode.TabIndex = 24
        Me.lblViewMode.Text = "View Mode"
        '
        'cbxViewMode
        '
        Me.cbxViewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxViewMode.FormattingEnabled = True
        Me.cbxViewMode.Items.AddRange(New Object() {"1 x 1", "2 x 2", "3 x 3", "4 x 4"})
        Me.cbxViewMode.Location = New System.Drawing.Point(82, 459)
        Me.cbxViewMode.Name = "cbxViewMode"
        Me.cbxViewMode.Size = New System.Drawing.Size(121, 21)
        Me.cbxViewMode.TabIndex = 23
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(470, 465)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(293, 13)
        Me.label1.TabIndex = 25
        Me.label1.Text = "Note: PDF Rasterizer add-on is used when loading PDF files."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 482)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.lblViewMode)
        Me.Controls.Add(Me.cbxViewMode)
        Me.Controls.Add(Me.grpOCRResult)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.dynamicDotNetTwain1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.ShowInTaskbar = False
        Me.Text = "OCR Demo"
        Me.grpOCRResult.ResumeLayout(False)
        Me.grpOCRResult.PerformLayout()
        Me.grpSelectedArea.ResumeLayout(False)
        Me.grpSelectedArea.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents dynamicDotNetTwain1 As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
    Private WithEvents grpOCRResult As System.Windows.Forms.GroupBox
    Private WithEvents lblFormat As System.Windows.Forms.Label
    Private WithEvents ddlResultFormat As System.Windows.Forms.ComboBox
    Private WithEvents btnSelectedOCR As System.Windows.Forms.Button
    Private WithEvents btnLoad As System.Windows.Forms.Button
    Private WithEvents btnOCRArea As System.Windows.Forms.Button
    Private WithEvents grpSelectedArea As System.Windows.Forms.GroupBox
    Private WithEvents tbxTop As System.Windows.Forms.TextBox
    Private WithEvents tbxBottom As System.Windows.Forms.TextBox
    Private WithEvents tbxRight As System.Windows.Forms.TextBox
    Private WithEvents tbxLeft As System.Windows.Forms.TextBox
    Private WithEvents lblTop As System.Windows.Forms.Label
    Private WithEvents lblBottom As System.Windows.Forms.Label
    Private WithEvents lblLeft As System.Windows.Forms.Label
    Private WithEvents lblRight As System.Windows.Forms.Label
    Private WithEvents cbxOCRLanguage As System.Windows.Forms.ComboBox
    Private WithEvents lblLanguage As System.Windows.Forms.Label
    Private WithEvents lblViewMode As System.Windows.Forms.Label
    Private WithEvents cbxViewMode As System.Windows.Forms.ComboBox
    Private WithEvents label1 As System.Windows.Forms.Label

End Class
