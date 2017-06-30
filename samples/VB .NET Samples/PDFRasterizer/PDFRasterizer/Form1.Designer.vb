Namespace Rasterizer
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
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.btnLoadPDF = New System.Windows.Forms.Button()
			Me.cmbPDFResolution = New System.Windows.Forms.ComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.groupBox2 = New System.Windows.Forms.GroupBox()
			Me.labMsg = New System.Windows.Forms.Label()
			Me.btnSave = New System.Windows.Forms.Button()
			Me.chbMultiPagePDF = New System.Windows.Forms.CheckBox()
			Me.chbMultiPageTIFF = New System.Windows.Forms.CheckBox()
			Me.rdbPDF = New System.Windows.Forms.RadioButton()
			Me.rdbTIFF = New System.Windows.Forms.RadioButton()
			Me.rdbPNG = New System.Windows.Forms.RadioButton()
			Me.rdbJPEG = New System.Windows.Forms.RadioButton()
			Me.rdbBMP = New System.Windows.Forms.RadioButton()
			Me.dsViewer1 = New Dynamsoft.Forms.DSViewer()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.btnLoadPDF)
			Me.groupBox1.Controls.Add(Me.cmbPDFResolution)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Location = New System.Drawing.Point(267, 8)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(270, 115)
			Me.groupBox1.TabIndex = 1
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Load a local PDF file"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(226, 29)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(27, 13)
			Me.label2.TabIndex = 3
			Me.label2.Text = "(dpi)"
			' 
			' btnLoadPDF
			' 
			Me.btnLoadPDF.Location = New System.Drawing.Point(68, 64)
			Me.btnLoadPDF.Name = "btnLoadPDF"
			Me.btnLoadPDF.Size = New System.Drawing.Size(136, 33)
			Me.btnLoadPDF.TabIndex = 2
			Me.btnLoadPDF.Text = "Load PDF"
			Me.btnLoadPDF.UseVisualStyleBackColor = True
			AddHandler Me.btnLoadPDF.Click, New System.EventHandler(AddressOf Me.btnLoadPDF_Click)
			' 
			' cmbPDFResolution
			' 
			Me.cmbPDFResolution.FormattingEnabled = True
			Me.cmbPDFResolution.Location = New System.Drawing.Point(119, 26)
			Me.cmbPDFResolution.Name = "cmbPDFResolution"
			Me.cmbPDFResolution.Size = New System.Drawing.Size(101, 21)
			Me.cmbPDFResolution.TabIndex = 1
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(10, 29)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(103, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Set PDF Resolution:"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.labMsg)
			Me.groupBox2.Controls.Add(Me.btnSave)
			Me.groupBox2.Controls.Add(Me.chbMultiPagePDF)
			Me.groupBox2.Controls.Add(Me.chbMultiPageTIFF)
			Me.groupBox2.Controls.Add(Me.rdbPDF)
			Me.groupBox2.Controls.Add(Me.rdbTIFF)
			Me.groupBox2.Controls.Add(Me.rdbPNG)
			Me.groupBox2.Controls.Add(Me.rdbJPEG)
			Me.groupBox2.Controls.Add(Me.rdbBMP)
			Me.groupBox2.Location = New System.Drawing.Point(267, 129)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(270, 179)
			Me.groupBox2.TabIndex = 2
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Save Images"
			' 
			' labMsg
			' 
			Me.labMsg.AutoSize = True
			Me.labMsg.Location = New System.Drawing.Point(75, 157)
			Me.labMsg.Name = "labMsg"
			Me.labMsg.Size = New System.Drawing.Size(0, 13)
			Me.labMsg.TabIndex = 8
			' 
			' btnSave
			' 
			Me.btnSave.Location = New System.Drawing.Point(68, 121)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New System.Drawing.Size(136, 33)
			Me.btnSave.TabIndex = 7
			Me.btnSave.Text = "Save"
			Me.btnSave.UseVisualStyleBackColor = True
			AddHandler Me.btnSave.Click, New System.EventHandler(AddressOf Me.btnSave_Click)
			' 
			' chbMultiPagePDF
			' 
			Me.chbMultiPagePDF.AutoSize = True
			Me.chbMultiPagePDF.Location = New System.Drawing.Point(147, 76)
			Me.chbMultiPagePDF.Name = "chbMultiPagePDF"
			Me.chbMultiPagePDF.Size = New System.Drawing.Size(100, 17)
			Me.chbMultiPagePDF.TabIndex = 6
			Me.chbMultiPagePDF.Text = "Multi-Page PDF"
			Me.chbMultiPagePDF.UseVisualStyleBackColor = True
			' 
			' chbMultiPageTIFF
			' 
			Me.chbMultiPageTIFF.AutoSize = True
			Me.chbMultiPageTIFF.Location = New System.Drawing.Point(29, 76)
			Me.chbMultiPageTIFF.Name = "chbMultiPageTIFF"
			Me.chbMultiPageTIFF.Size = New System.Drawing.Size(101, 17)
			Me.chbMultiPageTIFF.TabIndex = 5
			Me.chbMultiPageTIFF.Text = "Multi-Page TIFF"
			Me.chbMultiPageTIFF.UseVisualStyleBackColor = True
			' 
			' rdbPDF
			' 
			Me.rdbPDF.AutoSize = True
			Me.rdbPDF.Location = New System.Drawing.Point(220, 39)
			Me.rdbPDF.Name = "rdbPDF"
			Me.rdbPDF.Size = New System.Drawing.Size(46, 17)
			Me.rdbPDF.TabIndex = 4
			Me.rdbPDF.TabStop = True
			Me.rdbPDF.Text = "PDF"
			Me.rdbPDF.UseVisualStyleBackColor = True
			AddHandler Me.rdbPDF.CheckedChanged, New System.EventHandler(AddressOf Me.rdbPDF_CheckedChanged)
			' 
			' rdbTIFF
			' 
			Me.rdbTIFF.AutoSize = True
			Me.rdbTIFF.Location = New System.Drawing.Point(166, 38)
			Me.rdbTIFF.Name = "rdbTIFF"
			Me.rdbTIFF.Size = New System.Drawing.Size(47, 17)
			Me.rdbTIFF.TabIndex = 3
			Me.rdbTIFF.TabStop = True
			Me.rdbTIFF.Text = "TIFF"
			Me.rdbTIFF.UseVisualStyleBackColor = True
			AddHandler Me.rdbTIFF.CheckedChanged, New System.EventHandler(AddressOf Me.rdbTIFF_CheckedChanged)
			' 
			' rdbPNG
			' 
			Me.rdbPNG.AutoSize = True
			Me.rdbPNG.Location = New System.Drawing.Point(115, 38)
			Me.rdbPNG.Name = "rdbPNG"
			Me.rdbPNG.Size = New System.Drawing.Size(48, 17)
			Me.rdbPNG.TabIndex = 2
			Me.rdbPNG.TabStop = True
			Me.rdbPNG.Text = "PNG"
			Me.rdbPNG.UseVisualStyleBackColor = True
			AddHandler Me.rdbPNG.CheckedChanged, New System.EventHandler(AddressOf Me.rdbPNG_CheckedChanged)
			' 
			' rdbJPEG
			' 
			Me.rdbJPEG.AutoSize = True
			Me.rdbJPEG.Location = New System.Drawing.Point(60, 38)
			Me.rdbJPEG.Name = "rdbJPEG"
			Me.rdbJPEG.Size = New System.Drawing.Size(52, 17)
			Me.rdbJPEG.TabIndex = 1
			Me.rdbJPEG.TabStop = True
			Me.rdbJPEG.Text = "JPEG"
			Me.rdbJPEG.UseVisualStyleBackColor = True
			AddHandler Me.rdbJPEG.CheckedChanged, New System.EventHandler(AddressOf Me.rdbJPEG_CheckedChanged)
			' 
			' rdbBMP
			' 
			Me.rdbBMP.AutoSize = True
			Me.rdbBMP.Location = New System.Drawing.Point(11, 38)
			Me.rdbBMP.Name = "rdbBMP"
			Me.rdbBMP.Size = New System.Drawing.Size(48, 17)
			Me.rdbBMP.TabIndex = 0
			Me.rdbBMP.TabStop = True
			Me.rdbBMP.Text = "BMP"
			Me.rdbBMP.UseVisualStyleBackColor = True
			AddHandler Me.rdbBMP.Click, New System.EventHandler(AddressOf Me.rdbBMP_CheckedChanged)
			' 
			' dsViewer1
			' 
			Me.dsViewer1.Location = New System.Drawing.Point(12, 12)
			Me.dsViewer1.Name = "dsViewer1"
			Me.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.dsViewer1.SelectionRectAspectRatio = 0
			Me.dsViewer1.Size = New System.Drawing.Size(249, 292)
			Me.dsViewer1.TabIndex = 3
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(544, 316)
			Me.Controls.Add(Me.dsViewer1)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.Name = "Form1"
			Me.Text = "PDF Rasterizer"
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox2.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region


		Private groupBox1 As System.Windows.Forms.GroupBox
		Private btnLoadPDF As System.Windows.Forms.Button
		Private cmbPDFResolution As System.Windows.Forms.ComboBox
		Private label1 As System.Windows.Forms.Label
		Private groupBox2 As System.Windows.Forms.GroupBox
		Private rdbTIFF As System.Windows.Forms.RadioButton
		Private rdbPNG As System.Windows.Forms.RadioButton
		Private rdbJPEG As System.Windows.Forms.RadioButton
		Private rdbBMP As System.Windows.Forms.RadioButton
		Private btnSave As System.Windows.Forms.Button
		Private chbMultiPagePDF As System.Windows.Forms.CheckBox
		Private chbMultiPageTIFF As System.Windows.Forms.CheckBox
		Private rdbPDF As System.Windows.Forms.RadioButton
		Private label2 As System.Windows.Forms.Label
		Private labMsg As System.Windows.Forms.Label
		Private dsViewer1 As Dynamsoft.Forms.DSViewer
	End Class
End Namespace

