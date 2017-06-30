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
		Me.groupBox2 = New System.Windows.Forms.GroupBox()
		Me.edtFrameNumber = New System.Windows.Forms.TextBox()
		Me.edtPageNumber = New System.Windows.Forms.TextBox()
		Me.edtDocNumber = New System.Windows.Forms.TextBox()
		Me.edtFrameBottom = New System.Windows.Forms.TextBox()
		Me.edtFrameRight = New System.Windows.Forms.TextBox()
		Me.edtFrameTop = New System.Windows.Forms.TextBox()
		Me.edtFrameLeft = New System.Windows.Forms.TextBox()
		Me.label13 = New System.Windows.Forms.Label()
		Me.label12 = New System.Windows.Forms.Label()
		Me.label11 = New System.Windows.Forms.Label()
		Me.label10 = New System.Windows.Forms.Label()
		Me.label9 = New System.Windows.Forms.Label()
		Me.label8 = New System.Windows.Forms.Label()
		Me.label7 = New System.Windows.Forms.Label()
		Me.groupBox1 = New System.Windows.Forms.GroupBox()
		Me.edtBitsPerPixel = New System.Windows.Forms.TextBox()
		Me.label6 = New System.Windows.Forms.Label()
		Me.label5 = New System.Windows.Forms.Label()
		Me.label4 = New System.Windows.Forms.Label()
		Me.label3 = New System.Windows.Forms.Label()
		Me.edtPixelType = New System.Windows.Forms.TextBox()
		Me.edtLength = New System.Windows.Forms.TextBox()
		Me.edtWidth = New System.Windows.Forms.TextBox()
		Me.edtYResolution = New System.Windows.Forms.TextBox()
		Me.edtXResolution = New System.Windows.Forms.TextBox()
		Me.label2 = New System.Windows.Forms.Label()
		Me.label1 = New System.Windows.Forms.Label()
		Me.btnScan = New System.Windows.Forms.Button()
		Me.BMPradio = New System.Windows.Forms.RadioButton()
		Me.JPEGradio = New System.Windows.Forms.RadioButton()
		Me.groupBox3 = New System.Windows.Forms.GroupBox()
		Me.txtFileSize = New System.Windows.Forms.TextBox()
		Me.label14 = New System.Windows.Forms.Label()
		Me.MultiPDF = New System.Windows.Forms.CheckBox()
		Me.MultiTIFF = New System.Windows.Forms.CheckBox()
		Me.PDFradio = New System.Windows.Forms.RadioButton()
		Me.TIFFradio = New System.Windows.Forms.RadioButton()
		Me.PNGradio = New System.Windows.Forms.RadioButton()
		Me.btnRemove = New System.Windows.Forms.Button()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.dlgFileSave = New System.Windows.Forms.SaveFileDialog()
		Me.dsViewer1 = New Dynamsoft.Forms.DSViewer()
		Me.groupBox2.SuspendLayout()
		Me.groupBox1.SuspendLayout()
		Me.groupBox3.SuspendLayout()
		Me.SuspendLayout()
		' 
		' groupBox2
		' 
		Me.groupBox2.Controls.Add(Me.edtFrameNumber)
		Me.groupBox2.Controls.Add(Me.edtPageNumber)
		Me.groupBox2.Controls.Add(Me.edtDocNumber)
		Me.groupBox2.Controls.Add(Me.edtFrameBottom)
		Me.groupBox2.Controls.Add(Me.edtFrameRight)
		Me.groupBox2.Controls.Add(Me.edtFrameTop)
		Me.groupBox2.Controls.Add(Me.edtFrameLeft)
		Me.groupBox2.Controls.Add(Me.label13)
		Me.groupBox2.Controls.Add(Me.label12)
		Me.groupBox2.Controls.Add(Me.label11)
		Me.groupBox2.Controls.Add(Me.label10)
		Me.groupBox2.Controls.Add(Me.label9)
		Me.groupBox2.Controls.Add(Me.label8)
		Me.groupBox2.Controls.Add(Me.label7)
		Me.groupBox2.Location = New System.Drawing.Point(267, 143)
		Me.groupBox2.Name = "groupBox2"
		Me.groupBox2.Size = New System.Drawing.Size(365, 163)
		Me.groupBox2.TabIndex = 5
		Me.groupBox2.TabStop = False
		Me.groupBox2.Text = "Image Layout Info"
		' 
		' edtFrameNumber
		' 
		Me.edtFrameNumber.Location = New System.Drawing.Point(128, 128)
		Me.edtFrameNumber.Name = "edtFrameNumber"
		Me.edtFrameNumber.[ReadOnly] = True
		Me.edtFrameNumber.Size = New System.Drawing.Size(43, 20)
		Me.edtFrameNumber.TabIndex = 13
		' 
		' edtPageNumber
		' 
		Me.edtPageNumber.Location = New System.Drawing.Point(273, 94)
		Me.edtPageNumber.Name = "edtPageNumber"
		Me.edtPageNumber.[ReadOnly] = True
		Me.edtPageNumber.Size = New System.Drawing.Size(43, 20)
		Me.edtPageNumber.TabIndex = 12
		' 
		' edtDocNumber
		' 
		Me.edtDocNumber.Location = New System.Drawing.Point(128, 94)
		Me.edtDocNumber.Name = "edtDocNumber"
		Me.edtDocNumber.[ReadOnly] = True
		Me.edtDocNumber.Size = New System.Drawing.Size(43, 20)
		Me.edtDocNumber.TabIndex = 11
		' 
		' edtFrameBottom
		' 
		Me.edtFrameBottom.Location = New System.Drawing.Point(273, 60)
		Me.edtFrameBottom.Name = "edtFrameBottom"
		Me.edtFrameBottom.[ReadOnly] = True
		Me.edtFrameBottom.Size = New System.Drawing.Size(43, 20)
		Me.edtFrameBottom.TabIndex = 10
		' 
		' edtFrameRight
		' 
		Me.edtFrameRight.Location = New System.Drawing.Point(128, 60)
		Me.edtFrameRight.Name = "edtFrameRight"
		Me.edtFrameRight.[ReadOnly] = True
		Me.edtFrameRight.Size = New System.Drawing.Size(43, 20)
		Me.edtFrameRight.TabIndex = 9
		' 
		' edtFrameTop
		' 
		Me.edtFrameTop.Location = New System.Drawing.Point(273, 26)
		Me.edtFrameTop.Name = "edtFrameTop"
		Me.edtFrameTop.[ReadOnly] = True
		Me.edtFrameTop.Size = New System.Drawing.Size(43, 20)
		Me.edtFrameTop.TabIndex = 8
		' 
		' edtFrameLeft
		' 
		Me.edtFrameLeft.Location = New System.Drawing.Point(128, 26)
		Me.edtFrameLeft.Name = "edtFrameLeft"
		Me.edtFrameLeft.[ReadOnly] = True
		Me.edtFrameLeft.Size = New System.Drawing.Size(43, 20)
		Me.edtFrameLeft.TabIndex = 7
		' 
		' label13
		' 
		Me.label13.Location = New System.Drawing.Point(34, 128)
		Me.label13.Name = "label13"
		Me.label13.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label13.Size = New System.Drawing.Size(94, 18)
		Me.label13.TabIndex = 6
		Me.label13.Text = "Frame Number:"
		Me.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' label12
		' 
		Me.label12.Location = New System.Drawing.Point(179, 94)
		Me.label12.Name = "label12"
		Me.label12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label12.Size = New System.Drawing.Size(85, 17)
		Me.label12.TabIndex = 5
		Me.label12.Text = "Page Number:"
		Me.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' label11
		' 
		Me.label11.Location = New System.Drawing.Point(17, 94)
		Me.label11.Name = "label11"
		Me.label11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label11.Size = New System.Drawing.Size(111, 17)
		Me.label11.TabIndex = 4
		Me.label11.Text = "Document Number:"
		Me.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' label10
		' 
		Me.label10.Location = New System.Drawing.Point(187, 60)
		Me.label10.Name = "label10"
		Me.label10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label10.Size = New System.Drawing.Size(86, 17)
		Me.label10.TabIndex = 3
		Me.label10.Text = "Frame Bottom:"
		Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' label9
		' 
		Me.label9.Location = New System.Drawing.Point(51, 60)
		Me.label9.Name = "label9"
		Me.label9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label9.Size = New System.Drawing.Size(77, 17)
		Me.label9.TabIndex = 2
		Me.label9.Text = "Frame Right:"
		Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' label8
		' 
		Me.label8.Location = New System.Drawing.Point(197, 26)
		Me.label8.Name = "label8"
		Me.label8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label8.Size = New System.Drawing.Size(67, 16)
		Me.label8.TabIndex = 1
		Me.label8.Text = "Frame Top:"
		Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' label7
		' 
		Me.label7.Location = New System.Drawing.Point(60, 26)
		Me.label7.Name = "label7"
		Me.label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label7.Size = New System.Drawing.Size(68, 16)
		Me.label7.TabIndex = 0
		Me.label7.Text = "Frame Left:"
		Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' groupBox1
		' 
		Me.groupBox1.Controls.Add(Me.edtBitsPerPixel)
		Me.groupBox1.Controls.Add(Me.label6)
		Me.groupBox1.Controls.Add(Me.label5)
		Me.groupBox1.Controls.Add(Me.label4)
		Me.groupBox1.Controls.Add(Me.label3)
		Me.groupBox1.Controls.Add(Me.edtPixelType)
		Me.groupBox1.Controls.Add(Me.edtLength)
		Me.groupBox1.Controls.Add(Me.edtWidth)
		Me.groupBox1.Controls.Add(Me.edtYResolution)
		Me.groupBox1.Controls.Add(Me.edtXResolution)
		Me.groupBox1.Controls.Add(Me.label2)
		Me.groupBox1.Controls.Add(Me.label1)
		Me.groupBox1.Location = New System.Drawing.Point(267, 12)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(365, 125)
		Me.groupBox1.TabIndex = 4
		Me.groupBox1.TabStop = False
		Me.groupBox1.Text = "Image Info"
		' 
		' edtBitsPerPixel
		' 
		Me.edtBitsPerPixel.Location = New System.Drawing.Point(128, 94)
		Me.edtBitsPerPixel.Name = "edtBitsPerPixel"
		Me.edtBitsPerPixel.[ReadOnly] = True
		Me.edtBitsPerPixel.Size = New System.Drawing.Size(43, 20)
		Me.edtBitsPerPixel.TabIndex = 12
		' 
		' label6
		' 
		Me.label6.Location = New System.Drawing.Point(197, 94)
		Me.label6.Name = "label6"
		Me.label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label6.Size = New System.Drawing.Size(67, 17)
		Me.label6.TabIndex = 11
		Me.label6.Text = "Pixel Type:"
		Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' label5
		' 
		Me.label5.Location = New System.Drawing.Point(42, 94)
		Me.label5.Name = "label5"
		Me.label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label5.Size = New System.Drawing.Size(86, 17)
		Me.label5.TabIndex = 10
		Me.label5.Text = "Bits Per Pixel:"
		Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' label4
		' 
		Me.label4.Location = New System.Drawing.Point(213, 60)
		Me.label4.Name = "label4"
		Me.label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label4.Size = New System.Drawing.Size(51, 17)
		Me.label4.TabIndex = 9
		Me.label4.Text = "Length:"
		Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' label3
		' 
		Me.label3.Location = New System.Drawing.Point(85, 60)
		Me.label3.Name = "label3"
		Me.label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label3.Size = New System.Drawing.Size(43, 17)
		Me.label3.TabIndex = 8
		Me.label3.Text = "Width:"
		Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' edtPixelType
		' 
		Me.edtPixelType.Location = New System.Drawing.Point(273, 94)
		Me.edtPixelType.Name = "edtPixelType"
		Me.edtPixelType.[ReadOnly] = True
		Me.edtPixelType.Size = New System.Drawing.Size(43, 20)
		Me.edtPixelType.TabIndex = 7
		' 
		' edtLength
		' 
		Me.edtLength.Location = New System.Drawing.Point(273, 60)
		Me.edtLength.Name = "edtLength"
		Me.edtLength.[ReadOnly] = True
		Me.edtLength.Size = New System.Drawing.Size(43, 20)
		Me.edtLength.TabIndex = 5
		' 
		' edtWidth
		' 
		Me.edtWidth.Location = New System.Drawing.Point(128, 60)
		Me.edtWidth.Name = "edtWidth"
		Me.edtWidth.[ReadOnly] = True
		Me.edtWidth.Size = New System.Drawing.Size(43, 20)
		Me.edtWidth.TabIndex = 4
		' 
		' edtYResolution
		' 
		Me.edtYResolution.Location = New System.Drawing.Point(273, 26)
		Me.edtYResolution.Name = "edtYResolution"
		Me.edtYResolution.[ReadOnly] = True
		Me.edtYResolution.Size = New System.Drawing.Size(43, 20)
		Me.edtYResolution.TabIndex = 3
		' 
		' edtXResolution
		' 
		Me.edtXResolution.Location = New System.Drawing.Point(128, 26)
		Me.edtXResolution.Name = "edtXResolution"
		Me.edtXResolution.[ReadOnly] = True
		Me.edtXResolution.Size = New System.Drawing.Size(43, 20)
		Me.edtXResolution.TabIndex = 2
		' 
		' label2
		' 
		Me.label2.Location = New System.Drawing.Point(187, 26)
		Me.label2.Name = "label2"
		Me.label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label2.Size = New System.Drawing.Size(77, 16)
		Me.label2.TabIndex = 1
		Me.label2.Text = "Y Resolution:"
		Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' label1
		' 
		Me.label1.Location = New System.Drawing.Point(51, 26)
		Me.label1.Name = "label1"
		Me.label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label1.Size = New System.Drawing.Size(77, 16)
		Me.label1.TabIndex = 0
		Me.label1.Text = "X Resolution:"
		Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' btnScan
		' 
		Me.btnScan.Location = New System.Drawing.Point(567, 321)
		Me.btnScan.Name = "btnScan"
		Me.btnScan.Size = New System.Drawing.Size(65, 24)
		Me.btnScan.TabIndex = 6
		Me.btnScan.Text = "Scan"
		AddHandler Me.btnScan.Click, New System.EventHandler(AddressOf Me.btnScan_Click)
		' 
		' BMPradio
		' 
		Me.BMPradio.AutoSize = True
		Me.BMPradio.Location = New System.Drawing.Point(20, 29)
		Me.BMPradio.Name = "BMPradio"
		Me.BMPradio.Size = New System.Drawing.Size(48, 17)
		Me.BMPradio.TabIndex = 0
		Me.BMPradio.TabStop = True
		Me.BMPradio.Text = "BMP"
		Me.BMPradio.UseVisualStyleBackColor = True
		AddHandler Me.BMPradio.CheckedChanged, New System.EventHandler(AddressOf Me.BMPradio_CheckedChanged)
		' 
		' JPEGradio
		' 
		Me.JPEGradio.AutoSize = True
		Me.JPEGradio.Location = New System.Drawing.Point(74, 29)
		Me.JPEGradio.Name = "JPEGradio"
		Me.JPEGradio.Size = New System.Drawing.Size(52, 17)
		Me.JPEGradio.TabIndex = 1
		Me.JPEGradio.TabStop = True
		Me.JPEGradio.Text = "JPEG"
		Me.JPEGradio.UseVisualStyleBackColor = True
		AddHandler Me.JPEGradio.CheckedChanged, New System.EventHandler(AddressOf Me.JPEGradio_CheckedChanged)
		' 
		' groupBox3
		' 
		Me.groupBox3.Controls.Add(Me.txtFileSize)
		Me.groupBox3.Controls.Add(Me.label14)
		Me.groupBox3.Controls.Add(Me.MultiPDF)
		Me.groupBox3.Controls.Add(Me.MultiTIFF)
		Me.groupBox3.Controls.Add(Me.PDFradio)
		Me.groupBox3.Controls.Add(Me.TIFFradio)
		Me.groupBox3.Controls.Add(Me.PNGradio)
		Me.groupBox3.Controls.Add(Me.JPEGradio)
		Me.groupBox3.Controls.Add(Me.BMPradio)
		Me.groupBox3.Location = New System.Drawing.Point(267, 311)
		Me.groupBox3.Name = "groupBox3"
		Me.groupBox3.Size = New System.Drawing.Size(294, 137)
		Me.groupBox3.TabIndex = 7
		Me.groupBox3.TabStop = False
		Me.groupBox3.Text = "Save Images"
		' 
		' txtFileSize
		' 
		Me.txtFileSize.Location = New System.Drawing.Point(165, 103)
		Me.txtFileSize.Name = "txtFileSize"
		Me.txtFileSize.[ReadOnly] = True
		Me.txtFileSize.Size = New System.Drawing.Size(84, 20)
		Me.txtFileSize.TabIndex = 15
		' 
		' label14
		' 
		Me.label14.Location = New System.Drawing.Point(50, 103)
		Me.label14.Name = "label14"
		Me.label14.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label14.Size = New System.Drawing.Size(110, 18)
		Me.label14.TabIndex = 14
		Me.label14.Text = "Current Image Size:"
		Me.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' MultiPDF
		' 
		Me.MultiPDF.AutoSize = True
		Me.MultiPDF.Enabled = False
		Me.MultiPDF.Location = New System.Drawing.Point(149, 68)
		Me.MultiPDF.Name = "MultiPDF"
		Me.MultiPDF.Size = New System.Drawing.Size(100, 17)
		Me.MultiPDF.TabIndex = 6
		Me.MultiPDF.Text = "Multi-Page PDF"
		Me.MultiPDF.UseVisualStyleBackColor = True
		' 
		' MultiTIFF
		' 
		Me.MultiTIFF.AutoSize = True
		Me.MultiTIFF.Enabled = False
		Me.MultiTIFF.Location = New System.Drawing.Point(27, 68)
		Me.MultiTIFF.Name = "MultiTIFF"
		Me.MultiTIFF.Size = New System.Drawing.Size(101, 17)
		Me.MultiTIFF.TabIndex = 5
		Me.MultiTIFF.Text = "Multi-Page TIFF"
		Me.MultiTIFF.UseVisualStyleBackColor = True
		' 
		' PDFradio
		' 
		Me.PDFradio.AutoSize = True
		Me.PDFradio.Location = New System.Drawing.Point(235, 29)
		Me.PDFradio.Name = "PDFradio"
		Me.PDFradio.Size = New System.Drawing.Size(46, 17)
		Me.PDFradio.TabIndex = 4
		Me.PDFradio.TabStop = True
		Me.PDFradio.Text = "PDF"
		Me.PDFradio.UseVisualStyleBackColor = True
		AddHandler Me.PDFradio.CheckedChanged, New System.EventHandler(AddressOf Me.PDFradio_CheckedChanged)
		' 
		' TIFFradio
		' 
		Me.TIFFradio.AutoSize = True
		Me.TIFFradio.Location = New System.Drawing.Point(182, 29)
		Me.TIFFradio.Name = "TIFFradio"
		Me.TIFFradio.Size = New System.Drawing.Size(47, 17)
		Me.TIFFradio.TabIndex = 3
		Me.TIFFradio.TabStop = True
		Me.TIFFradio.Text = "TIFF"
		Me.TIFFradio.UseVisualStyleBackColor = True
		AddHandler Me.TIFFradio.CheckedChanged, New System.EventHandler(AddressOf Me.TIFFradio_CheckedChanged)
		' 
		' PNGradio
		' 
		Me.PNGradio.AutoSize = True
		Me.PNGradio.Location = New System.Drawing.Point(132, 29)
		Me.PNGradio.Name = "PNGradio"
		Me.PNGradio.Size = New System.Drawing.Size(48, 17)
		Me.PNGradio.TabIndex = 2
		Me.PNGradio.TabStop = True
		Me.PNGradio.Text = "PNG"
		Me.PNGradio.UseVisualStyleBackColor = True
		AddHandler Me.PNGradio.CheckedChanged, New System.EventHandler(AddressOf Me.PNGradio_CheckedChanged)
		' 
		' btnRemove
		' 
		Me.btnRemove.Location = New System.Drawing.Point(567, 424)
		Me.btnRemove.Name = "btnRemove"
		Me.btnRemove.Size = New System.Drawing.Size(65, 24)
		Me.btnRemove.TabIndex = 8
		Me.btnRemove.Text = "Remove"
		AddHandler Me.btnRemove.Click, New System.EventHandler(AddressOf Me.btnRemove_Click)
		' 
		' btnSave
		' 
		Me.btnSave.Location = New System.Drawing.Point(567, 372)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(65, 24)
		Me.btnSave.TabIndex = 9
		Me.btnSave.Text = "Save"
		AddHandler Me.btnSave.Click, New System.EventHandler(AddressOf Me.btnSave_Click)
		' 
		' dsViewer1
		' 
		Me.dsViewer1.Location = New System.Drawing.Point(2, 2)
		Me.dsViewer1.Name = "dsViewer1"
		Me.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.dsViewer1.SelectionRectAspectRatio = 0
		Me.dsViewer1.Size = New System.Drawing.Size(259, 446)
		Me.dsViewer1.TabIndex = 10
		' 
		' Form1
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(649, 502)
		Me.Controls.Add(Me.dsViewer1)
		Me.Controls.Add(Me.btnSave)
		Me.Controls.Add(Me.btnRemove)
		Me.Controls.Add(Me.groupBox3)
		Me.Controls.Add(Me.btnScan)
		Me.Controls.Add(Me.groupBox2)
		Me.Controls.Add(Me.groupBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.Name = "Form1"
		Me.Text = "Show Image Info and Save Scanned Images"
		AddHandler Me.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Me.Form1_FormClosed)
		Me.groupBox2.ResumeLayout(False)
		Me.groupBox2.PerformLayout()
		Me.groupBox1.ResumeLayout(False)
		Me.groupBox1.PerformLayout()
		Me.groupBox3.ResumeLayout(False)
		Me.groupBox3.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	#End Region


	Private groupBox2 As System.Windows.Forms.GroupBox
	Private edtFrameNumber As System.Windows.Forms.TextBox
	Private edtPageNumber As System.Windows.Forms.TextBox
	Private edtDocNumber As System.Windows.Forms.TextBox
	Private edtFrameBottom As System.Windows.Forms.TextBox
	Private edtFrameRight As System.Windows.Forms.TextBox
	Private edtFrameTop As System.Windows.Forms.TextBox
	Private edtFrameLeft As System.Windows.Forms.TextBox
	Private label13 As System.Windows.Forms.Label
	Private label12 As System.Windows.Forms.Label
	Private label11 As System.Windows.Forms.Label
	Private label10 As System.Windows.Forms.Label
	Private label9 As System.Windows.Forms.Label
	Private label8 As System.Windows.Forms.Label
	Private label7 As System.Windows.Forms.Label
	Private groupBox1 As System.Windows.Forms.GroupBox
	Private edtBitsPerPixel As System.Windows.Forms.TextBox
	Private label6 As System.Windows.Forms.Label
	Private label5 As System.Windows.Forms.Label
	Private label4 As System.Windows.Forms.Label
	Private label3 As System.Windows.Forms.Label
	Private edtPixelType As System.Windows.Forms.TextBox
	Private edtLength As System.Windows.Forms.TextBox
	Private edtWidth As System.Windows.Forms.TextBox
	Private edtYResolution As System.Windows.Forms.TextBox
	Private edtXResolution As System.Windows.Forms.TextBox
	Private label2 As System.Windows.Forms.Label
	Private label1 As System.Windows.Forms.Label
	Private btnScan As System.Windows.Forms.Button
	Private BMPradio As System.Windows.Forms.RadioButton
	Private JPEGradio As System.Windows.Forms.RadioButton
	Private groupBox3 As System.Windows.Forms.GroupBox
	Private PDFradio As System.Windows.Forms.RadioButton
	Private TIFFradio As System.Windows.Forms.RadioButton
	Private PNGradio As System.Windows.Forms.RadioButton
	Private txtFileSize As System.Windows.Forms.TextBox
	Private label14 As System.Windows.Forms.Label
	Private MultiPDF As System.Windows.Forms.CheckBox
	Private MultiTIFF As System.Windows.Forms.CheckBox
	Private btnRemove As System.Windows.Forms.Button
	Private btnSave As System.Windows.Forms.Button
	Private dlgFileSave As System.Windows.Forms.SaveFileDialog
	Private dsViewer1 As Dynamsoft.Forms.DSViewer
End Class

