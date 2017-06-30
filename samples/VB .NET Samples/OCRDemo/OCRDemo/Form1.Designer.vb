Partial Class Form1
	''' <summary>
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary>
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(disposing As Boolean)
		If disposing AndAlso (components IsNot Nothing) Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

	#Region "Windows Form Designer generated code"

	''' <summary>
	''' Required method for Designer support - do not modify
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnSelectedOCR = New System.Windows.Forms.Button()
        Me.ddlResultFormat = New System.Windows.Forms.ComboBox()
        Me.lblFormat = New System.Windows.Forms.Label()
        Me.grpOCRResult = New System.Windows.Forms.GroupBox()
        Me.btnOCRArea = New System.Windows.Forms.Button()
        Me.cbxOCRLanguage = New System.Windows.Forms.ComboBox()
        Me.lblLanguage = New System.Windows.Forms.Label()
        Me.grpSelectedArea = New System.Windows.Forms.GroupBox()
        Me.tbxTop = New System.Windows.Forms.TextBox()
        Me.tbxBottom = New System.Windows.Forms.TextBox()
        Me.tbxRight = New System.Windows.Forms.TextBox()
        Me.tbxLeft = New System.Windows.Forms.TextBox()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.label58 = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.lblRight = New System.Windows.Forms.Label()
        Me.cbxViewMode = New System.Windows.Forms.ComboBox()
        Me.lblViewMode = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.dsViewer1 = New Dynamsoft.Forms.DSViewer()
        Me.grpOCRResult.SuspendLayout()
        Me.grpSelectedArea.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(538, 21)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(199, 23)
        Me.btnLoad.TabIndex = 1
        Me.btnLoad.Text = "Load Image"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnSelectedOCR
        '
        Me.btnSelectedOCR.Location = New System.Drawing.Point(9, 139)
        Me.btnSelectedOCR.Name = "btnSelectedOCR"
        Me.btnSelectedOCR.Size = New System.Drawing.Size(190, 23)
        Me.btnSelectedOCR.TabIndex = 2
        Me.btnSelectedOCR.Text = "OCR Selected Images"
        Me.btnSelectedOCR.UseVisualStyleBackColor = True
        '
        'ddlResultFormat
        '
        Me.ddlResultFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlResultFormat.FormattingEnabled = True
        Me.ddlResultFormat.Location = New System.Drawing.Point(9, 93)
        Me.ddlResultFormat.Name = "ddlResultFormat"
        Me.ddlResultFormat.Size = New System.Drawing.Size(192, 21)
        Me.ddlResultFormat.TabIndex = 7
        '
        'lblFormat
        '
        Me.lblFormat.AutoSize = True
        Me.lblFormat.Location = New System.Drawing.Point(6, 77)
        Me.lblFormat.Name = "lblFormat"
        Me.lblFormat.Size = New System.Drawing.Size(111, 13)
        Me.lblFormat.TabIndex = 6
        Me.lblFormat.Text = "Ocr Result File Format"
        '
        'grpOCRResult
        '
        Me.grpOCRResult.Controls.Add(Me.btnOCRArea)
        Me.grpOCRResult.Controls.Add(Me.cbxOCRLanguage)
        Me.grpOCRResult.Controls.Add(Me.lblLanguage)
        Me.grpOCRResult.Controls.Add(Me.lblFormat)
        Me.grpOCRResult.Controls.Add(Me.ddlResultFormat)
        Me.grpOCRResult.Controls.Add(Me.btnSelectedOCR)
        Me.grpOCRResult.Location = New System.Drawing.Point(538, 64)
        Me.grpOCRResult.Name = "grpOCRResult"
        Me.grpOCRResult.Size = New System.Drawing.Size(222, 309)
        Me.grpOCRResult.TabIndex = 8
        Me.grpOCRResult.TabStop = False
        Me.grpOCRResult.Text = "OCR Result"
        '
        'btnOCRArea
        '
        Me.btnOCRArea.Location = New System.Drawing.Point(6, 276)
        Me.btnOCRArea.Name = "btnOCRArea"
        Me.btnOCRArea.Size = New System.Drawing.Size(193, 23)
        Me.btnOCRArea.TabIndex = 12
        Me.btnOCRArea.Text = "OCR Selected Area"
        Me.btnOCRArea.UseVisualStyleBackColor = True
        '
        'cbxOCRLanguage
        '
        Me.cbxOCRLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxOCRLanguage.FormattingEnabled = True
        Me.cbxOCRLanguage.Location = New System.Drawing.Point(8, 40)
        Me.cbxOCRLanguage.Name = "cbxOCRLanguage"
        Me.cbxOCRLanguage.Size = New System.Drawing.Size(192, 21)
        Me.cbxOCRLanguage.TabIndex = 11
        '
        'lblLanguage
        '
        Me.lblLanguage.AutoSize = True
        Me.lblLanguage.Location = New System.Drawing.Point(6, 24)
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Size = New System.Drawing.Size(75, 13)
        Me.lblLanguage.TabIndex = 10
        Me.lblLanguage.Text = "Ocr Language"
        '
        'grpSelectedArea
        '
        Me.grpSelectedArea.Controls.Add(Me.tbxTop)
        Me.grpSelectedArea.Controls.Add(Me.tbxBottom)
        Me.grpSelectedArea.Controls.Add(Me.tbxRight)
        Me.grpSelectedArea.Controls.Add(Me.tbxLeft)
        Me.grpSelectedArea.Controls.Add(Me.lblTop)
        Me.grpSelectedArea.Controls.Add(Me.label58)
        Me.grpSelectedArea.Controls.Add(Me.lblLeft)
        Me.grpSelectedArea.Controls.Add(Me.lblRight)
        Me.grpSelectedArea.Location = New System.Drawing.Point(544, 242)
        Me.grpSelectedArea.Name = "grpSelectedArea"
        Me.grpSelectedArea.Size = New System.Drawing.Size(210, 79)
        Me.grpSelectedArea.TabIndex = 20
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
        'label58
        '
        Me.label58.AutoSize = True
        Me.label58.Location = New System.Drawing.Point(99, 53)
        Me.label58.Name = "label58"
        Me.label58.Size = New System.Drawing.Size(39, 13)
        Me.label58.TabIndex = 16
        Me.label58.Text = "bottom"
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
        'cbxViewMode
        '
        Me.cbxViewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxViewMode.FormattingEnabled = True
        Me.cbxViewMode.Items.AddRange(New Object() {"1 x 1", "2 x 2", "3 x 3", "4 x 4"})
        Me.cbxViewMode.Location = New System.Drawing.Point(81, 457)
        Me.cbxViewMode.Name = "cbxViewMode"
        Me.cbxViewMode.Size = New System.Drawing.Size(121, 21)
        Me.cbxViewMode.TabIndex = 21
        '
        'lblViewMode
        '
        Me.lblViewMode.AutoSize = True
        Me.lblViewMode.Location = New System.Drawing.Point(15, 460)
        Me.lblViewMode.Name = "lblViewMode"
        Me.lblViewMode.Size = New System.Drawing.Size(60, 13)
        Me.lblViewMode.TabIndex = 22
        Me.lblViewMode.Text = "View Mode"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(470, 465)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(293, 13)
        Me.label1.TabIndex = 23
        Me.label1.Text = "Note: PDF library is used when loading PDF files."
        '
        'dsViewer1
        '
        Me.dsViewer1.Location = New System.Drawing.Point(12, 12)
        Me.dsViewer1.Name = "dsViewer1"
        Me.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dsViewer1.SelectionRectAspectRatio = 0.0R
        Me.dsViewer1.Size = New System.Drawing.Size(520, 439)
        Me.dsViewer1.TabIndex = 24
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 482)
        Me.Controls.Add(Me.dsViewer1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.lblViewMode)
        Me.Controls.Add(Me.cbxViewMode)
        Me.Controls.Add(Me.grpSelectedArea)
        Me.Controls.Add(Me.grpOCRResult)
        Me.Controls.Add(Me.btnLoad)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "OCR Demo"
        Me.grpOCRResult.ResumeLayout(False)
        Me.grpOCRResult.PerformLayout()
        Me.grpSelectedArea.ResumeLayout(False)
        Me.grpSelectedArea.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

	#End Region

    Private WithEvents btnLoad As System.Windows.Forms.Button
    Private WithEvents btnSelectedOCR As System.Windows.Forms.Button
	Private ddlResultFormat As System.Windows.Forms.ComboBox
	Private lblFormat As System.Windows.Forms.Label
	Private grpOCRResult As System.Windows.Forms.GroupBox
	Private cbxOCRLanguage As System.Windows.Forms.ComboBox
	Private lblLanguage As System.Windows.Forms.Label
	Private grpSelectedArea As System.Windows.Forms.GroupBox
	Private tbxTop As System.Windows.Forms.TextBox
	Private tbxBottom As System.Windows.Forms.TextBox
	Private tbxRight As System.Windows.Forms.TextBox
	Private tbxLeft As System.Windows.Forms.TextBox
	Private lblTop As System.Windows.Forms.Label
	Private label58 As System.Windows.Forms.Label
	Private lblLeft As System.Windows.Forms.Label
	Private lblRight As System.Windows.Forms.Label
    Private WithEvents btnOCRArea As System.Windows.Forms.Button
	Private WithEvents cbxViewMode As System.Windows.Forms.ComboBox
	Private lblViewMode As System.Windows.Forms.Label
	Private label1 As System.Windows.Forms.Label
	Private dsViewer1 As Dynamsoft.Forms.DSViewer
End Class

