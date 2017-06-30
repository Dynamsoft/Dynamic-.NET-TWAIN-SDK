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
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnRecognize = New System.Windows.Forms.Button()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.lblFormat = New System.Windows.Forms.Label()
        Me.lblMaxNum = New System.Windows.Forms.Label()
        Me.cbxFormat = New System.Windows.Forms.ComboBox()
        Me.tbxMaxNum = New System.Windows.Forms.TextBox()
        Me.gbSelectedArea = New System.Windows.Forms.GroupBox()
        Me.tbxTop = New System.Windows.Forms.TextBox()
        Me.tbxBottom = New System.Windows.Forms.TextBox()
        Me.tbxRight = New System.Windows.Forms.TextBox()
        Me.tbxLeft = New System.Windows.Forms.TextBox()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.lblBottom = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.lblRight = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.dsViewer1 = New Dynamsoft.Forms.DSViewer()
        Me.gbSelectedArea.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(12, 328)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 1
        Me.btnOpen.Text = "Open Image"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnRecognize
        '
        Me.btnRecognize.Location = New System.Drawing.Point(12, 446)
        Me.btnRecognize.Name = "btnRecognize"
        Me.btnRecognize.Size = New System.Drawing.Size(75, 23)
        Me.btnRecognize.TabIndex = 2
        Me.btnRecognize.Text = "Recognize"
        Me.btnRecognize.UseVisualStyleBackColor = True
        '
        'textBox1
        '
        Me.textBox1.BackColor = System.Drawing.SystemColors.Control
        Me.textBox1.Location = New System.Drawing.Point(9, 475)
        Me.textBox1.Multiline = True
        Me.textBox1.Name = "textBox1"
        Me.textBox1.ReadOnly = True
        Me.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textBox1.Size = New System.Drawing.Size(458, 98)
        Me.textBox1.TabIndex = 4
        '
        'lblFormat
        '
        Me.lblFormat.AutoSize = True
        Me.lblFormat.Location = New System.Drawing.Point(12, 356)
        Me.lblFormat.Name = "lblFormat"
        Me.lblFormat.Size = New System.Drawing.Size(82, 13)
        Me.lblFormat.TabIndex = 5
        Me.lblFormat.Text = "Barcode Format"
        '
        'lblMaxNum
        '
        Me.lblMaxNum.AutoSize = True
        Me.lblMaxNum.Location = New System.Drawing.Point(253, 356)
        Me.lblMaxNum.Name = "lblMaxNum"
        Me.lblMaxNum.Size = New System.Drawing.Size(91, 13)
        Me.lblMaxNum.TabIndex = 6
        Me.lblMaxNum.Text = "Maximum Number"
        '
        'cbxFormat
        '
        Me.cbxFormat.FormattingEnabled = True
        Me.cbxFormat.Location = New System.Drawing.Point(100, 353)
        Me.cbxFormat.Name = "cbxFormat"
        Me.cbxFormat.Size = New System.Drawing.Size(121, 21)
        Me.cbxFormat.TabIndex = 7
        '
        'tbxMaxNum
        '
        Me.tbxMaxNum.Location = New System.Drawing.Point(350, 353)
        Me.tbxMaxNum.Name = "tbxMaxNum"
        Me.tbxMaxNum.Size = New System.Drawing.Size(46, 20)
        Me.tbxMaxNum.TabIndex = 8
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
        Me.gbSelectedArea.Location = New System.Drawing.Point(15, 380)
        Me.gbSelectedArea.Name = "gbSelectedArea"
        Me.gbSelectedArea.Size = New System.Drawing.Size(455, 60)
        Me.gbSelectedArea.TabIndex = 14
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
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(9, 578)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(458, 13)
        Me.label1.TabIndex = 15
        Me.label1.Text = "Note: PDF library is used when loading PDF files."
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsViewer1
        '
        Me.dsViewer1.Location = New System.Drawing.Point(0, 0)
        Me.dsViewer1.Name = "dsViewer1"
        Me.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dsViewer1.SelectionRectAspectRatio = 0.0R
        Me.dsViewer1.Size = New System.Drawing.Size(487, 322)
        Me.dsViewer1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 600)
        Me.Controls.Add(Me.dsViewer1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.gbSelectedArea)
        Me.Controls.Add(Me.tbxMaxNum)
        Me.Controls.Add(Me.cbxFormat)
        Me.Controls.Add(Me.lblMaxNum)
        Me.Controls.Add(Me.lblFormat)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.btnRecognize)
        Me.Controls.Add(Me.btnOpen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Barcode Reader"
        Me.gbSelectedArea.ResumeLayout(False)
        Me.gbSelectedArea.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

	#End Region



    Private WithEvents btnOpen As System.Windows.Forms.Button
    Private WithEvents btnRecognize As System.Windows.Forms.Button
	Private textBox1 As System.Windows.Forms.TextBox
	Private lblFormat As System.Windows.Forms.Label
	Private lblMaxNum As System.Windows.Forms.Label
	Private cbxFormat As System.Windows.Forms.ComboBox
	Private tbxMaxNum As System.Windows.Forms.TextBox
	Private gbSelectedArea As System.Windows.Forms.GroupBox
	Private tbxTop As System.Windows.Forms.TextBox
	Private tbxBottom As System.Windows.Forms.TextBox
	Private tbxRight As System.Windows.Forms.TextBox
	Private tbxLeft As System.Windows.Forms.TextBox
	Private lblTop As System.Windows.Forms.Label
	Private lblBottom As System.Windows.Forms.Label
	Private lblLeft As System.Windows.Forms.Label
	Private lblRight As System.Windows.Forms.Label
	Private label1 As System.Windows.Forms.Label
	Private dsViewer1 As Dynamsoft.Forms.DSViewer
End Class

