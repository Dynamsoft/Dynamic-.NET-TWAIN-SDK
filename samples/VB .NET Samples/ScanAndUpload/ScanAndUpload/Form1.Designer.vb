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
		Me.txtboxErrMessage = New System.Windows.Forms.TextBox()
		Me.groupBox2 = New System.Windows.Forms.GroupBox()
		Me.btnScan = New System.Windows.Forms.Button()
		Me.chkboxIfShowUI = New System.Windows.Forms.CheckBox()
		Me.label1 = New System.Windows.Forms.Label()
		Me.cmbSource = New System.Windows.Forms.ComboBox()
		Me.groupBox3 = New System.Windows.Forms.GroupBox()
		Me.lbNote = New System.Windows.Forms.Label()
		Me.label8 = New System.Windows.Forms.Label()
		Me.txtboxExtraTxt = New System.Windows.Forms.TextBox()
		Me.label7 = New System.Windows.Forms.Label()
		Me.label6 = New System.Windows.Forms.Label()
		Me.label5 = New System.Windows.Forms.Label()
		Me.label4 = New System.Windows.Forms.Label()
		Me.label3 = New System.Windows.Forms.Label()
		Me.label2 = New System.Windows.Forms.Label()
		Me.btnUpload = New System.Windows.Forms.Button()
		Me.chkboxMultiPage = New System.Windows.Forms.CheckBox()
		Me.rdbtnPDF = New System.Windows.Forms.RadioButton()
		Me.rdbtnPNG = New System.Windows.Forms.RadioButton()
		Me.rdbtnTIFF = New System.Windows.Forms.RadioButton()
		Me.rdbtnJPEG = New System.Windows.Forms.RadioButton()
		Me.txtboxFileName = New System.Windows.Forms.TextBox()
		Me.txtboxActionPage = New System.Windows.Forms.TextBox()
		Me.txtboxPwd = New System.Windows.Forms.TextBox()
		Me.txtboxName = New System.Windows.Forms.TextBox()
		Me.txtboxPort = New System.Windows.Forms.TextBox()
		Me.txtboxServer = New System.Windows.Forms.TextBox()
		Me.dsViewer1 = New Dynamsoft.Forms.DSViewer()
		Me.groupBox1.SuspendLayout()
		Me.groupBox2.SuspendLayout()
		Me.groupBox3.SuspendLayout()
		Me.SuspendLayout()
		' 
		' groupBox1
		' 
		Me.groupBox1.Controls.Add(Me.txtboxErrMessage)
		Me.groupBox1.Location = New System.Drawing.Point(7, 400)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(284, 108)
		Me.groupBox1.TabIndex = 1
		Me.groupBox1.TabStop = False
		Me.groupBox1.Text = "Message"
		' 
		' txtboxErrMessage
		' 
		Me.txtboxErrMessage.Location = New System.Drawing.Point(10, 19)
		Me.txtboxErrMessage.Multiline = True
		Me.txtboxErrMessage.Name = "txtboxErrMessage"
		Me.txtboxErrMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtboxErrMessage.Size = New System.Drawing.Size(264, 83)
		Me.txtboxErrMessage.TabIndex = 0
		' 
		' groupBox2
		' 
		Me.groupBox2.Controls.Add(Me.btnScan)
		Me.groupBox2.Controls.Add(Me.chkboxIfShowUI)
		Me.groupBox2.Controls.Add(Me.label1)
		Me.groupBox2.Controls.Add(Me.cmbSource)
		Me.groupBox2.Location = New System.Drawing.Point(298, 9)
		Me.groupBox2.Name = "groupBox2"
		Me.groupBox2.Size = New System.Drawing.Size(269, 112)
		Me.groupBox2.TabIndex = 2
		Me.groupBox2.TabStop = False
		Me.groupBox2.Text = "Custom Scan"
		' 
		' btnScan
		' 
		Me.btnScan.Location = New System.Drawing.Point(107, 64)
		Me.btnScan.Name = "btnScan"
		Me.btnScan.Size = New System.Drawing.Size(150, 29)
		Me.btnScan.TabIndex = 3
		Me.btnScan.Text = "Scan"
		Me.btnScan.UseVisualStyleBackColor = True
		AddHandler Me.btnScan.Click, New System.EventHandler(AddressOf Me.btnScan_Click)
		' 
		' chkboxIfShowUI
		' 
		Me.chkboxIfShowUI.AutoSize = True
		Me.chkboxIfShowUI.Location = New System.Drawing.Point(21, 71)
		Me.chkboxIfShowUI.Name = "chkboxIfShowUI"
		Me.chkboxIfShowUI.Size = New System.Drawing.Size(67, 17)
		Me.chkboxIfShowUI.TabIndex = 2
		Me.chkboxIfShowUI.Text = "Show UI"
		Me.chkboxIfShowUI.UseVisualStyleBackColor = True
		' 
		' label1
		' 
		Me.label1.AutoSize = True
		Me.label1.Location = New System.Drawing.Point(8, 35)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(77, 13)
		Me.label1.TabIndex = 1
		Me.label1.Text = "Select Source:"
		' 
		' cmbSource
		' 
		Me.cmbSource.FormattingEnabled = True
		Me.cmbSource.Location = New System.Drawing.Point(86, 30)
		Me.cmbSource.Name = "cmbSource"
		Me.cmbSource.Size = New System.Drawing.Size(172, 21)
		Me.cmbSource.TabIndex = 0
		' 
		' groupBox3
		' 
		Me.groupBox3.Controls.Add(Me.lbNote)
		Me.groupBox3.Controls.Add(Me.label8)
		Me.groupBox3.Controls.Add(Me.txtboxExtraTxt)
		Me.groupBox3.Controls.Add(Me.label7)
		Me.groupBox3.Controls.Add(Me.label6)
		Me.groupBox3.Controls.Add(Me.label5)
		Me.groupBox3.Controls.Add(Me.label4)
		Me.groupBox3.Controls.Add(Me.label3)
		Me.groupBox3.Controls.Add(Me.label2)
		Me.groupBox3.Controls.Add(Me.btnUpload)
		Me.groupBox3.Controls.Add(Me.chkboxMultiPage)
		Me.groupBox3.Controls.Add(Me.rdbtnPDF)
		Me.groupBox3.Controls.Add(Me.rdbtnPNG)
		Me.groupBox3.Controls.Add(Me.rdbtnTIFF)
		Me.groupBox3.Controls.Add(Me.rdbtnJPEG)
		Me.groupBox3.Controls.Add(Me.txtboxFileName)
		Me.groupBox3.Controls.Add(Me.txtboxActionPage)
		Me.groupBox3.Controls.Add(Me.txtboxPwd)
		Me.groupBox3.Controls.Add(Me.txtboxName)
		Me.groupBox3.Controls.Add(Me.txtboxPort)
		Me.groupBox3.Controls.Add(Me.txtboxServer)
		Me.groupBox3.Location = New System.Drawing.Point(298, 141)
		Me.groupBox3.Name = "groupBox3"
		Me.groupBox3.Size = New System.Drawing.Size(268, 367)
		Me.groupBox3.TabIndex = 3
		Me.groupBox3.TabStop = False
		Me.groupBox3.Text = "Upload To DB"
		' 
		' lbNote
		' 
		Me.lbNote.AutoSize = True
		Me.lbNote.ForeColor = System.Drawing.Color.Blue
		Me.lbNote.Location = New System.Drawing.Point(84, 55)
		Me.lbNote.Name = "lbNote"
		Me.lbNote.Size = New System.Drawing.Size(151, 13)
		Me.lbNote.TabIndex = 20
        Me.lbNote.Text = "File size shouldn't exceed 2.5M"
		' 
		' label8
		' 
		Me.label8.AutoSize = True
		Me.label8.Location = New System.Drawing.Point(9, 262)
		Me.label8.Name = "label8"
		Me.label8.Size = New System.Drawing.Size(54, 13)
		Me.label8.TabIndex = 19
		Me.label8.Text = "Extra text:"
		' 
		' txtboxExtraTxt
		' 
		Me.txtboxExtraTxt.Location = New System.Drawing.Point(86, 259)
		Me.txtboxExtraTxt.Name = "txtboxExtraTxt"
		Me.txtboxExtraTxt.Size = New System.Drawing.Size(164, 20)
		Me.txtboxExtraTxt.TabIndex = 18
		' 
		' label7
		' 
		Me.label7.AutoSize = True
		Me.label7.Location = New System.Drawing.Point(9, 222)
		Me.label7.Name = "label7"
		Me.label7.Size = New System.Drawing.Size(57, 13)
		Me.label7.TabIndex = 17
		Me.label7.Text = "File Name:"
		' 
		' label6
		' 
		Me.label6.AutoSize = True
		Me.label6.Location = New System.Drawing.Point(9, 185)
		Me.label6.Name = "label6"
		Me.label6.Size = New System.Drawing.Size(68, 13)
		Me.label6.TabIndex = 16
		Me.label6.Text = "Action Page:"
		' 
		' label5
		' 
		Me.label5.AutoSize = True
		Me.label5.Location = New System.Drawing.Point(8, 147)
		Me.label5.Name = "label5"
		Me.label5.Size = New System.Drawing.Size(56, 13)
		Me.label5.TabIndex = 15
		Me.label5.Text = "Password:"
		' 
		' label4
		' 
		Me.label4.AutoSize = True
		Me.label4.Location = New System.Drawing.Point(8, 112)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(63, 13)
		Me.label4.TabIndex = 14
		Me.label4.Text = "User Name:"
		' 
		' label3
		' 
		Me.label3.AutoSize = True
		Me.label3.Location = New System.Drawing.Point(8, 74)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(61, 13)
		Me.label3.TabIndex = 13
		Me.label3.Text = "HTTP Port:"
		' 
		' label2
		' 
		Me.label2.AutoSize = True
		Me.label2.Location = New System.Drawing.Point(8, 35)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(73, 13)
		Me.label2.TabIndex = 12
		Me.label2.Text = "HTTP Server:"
		' 
		' btnUpload
		' 
		Me.btnUpload.Location = New System.Drawing.Point(107, 321)
		Me.btnUpload.Name = "btnUpload"
		Me.btnUpload.Size = New System.Drawing.Size(138, 30)
		Me.btnUpload.TabIndex = 11
		Me.btnUpload.Text = "Upload To DB"
		Me.btnUpload.UseVisualStyleBackColor = True
		AddHandler Me.btnUpload.Click, New System.EventHandler(AddressOf Me.btnUpload_Click)
		' 
		' chkboxMultiPage
		' 
		Me.chkboxMultiPage.AutoSize = True
		Me.chkboxMultiPage.Location = New System.Drawing.Point(23, 329)
		Me.chkboxMultiPage.Name = "chkboxMultiPage"
		Me.chkboxMultiPage.Size = New System.Drawing.Size(76, 17)
		Me.chkboxMultiPage.TabIndex = 10
		Me.chkboxMultiPage.Text = "Multi-Page"
		Me.chkboxMultiPage.UseVisualStyleBackColor = True
		' 
		' rdbtnPDF
		' 
		Me.rdbtnPDF.AutoSize = True
		Me.rdbtnPDF.Location = New System.Drawing.Point(195, 299)
		Me.rdbtnPDF.Name = "rdbtnPDF"
		Me.rdbtnPDF.Size = New System.Drawing.Size(46, 17)
		Me.rdbtnPDF.TabIndex = 9
		Me.rdbtnPDF.TabStop = True
		Me.rdbtnPDF.Text = "PDF"
		Me.rdbtnPDF.UseVisualStyleBackColor = True
		AddHandler Me.rdbtnPDF.CheckedChanged, New System.EventHandler(AddressOf Me.rdbtnPDF_CheckedChanged)
		' 
		' rdbtnPNG
		' 
		Me.rdbtnPNG.AutoSize = True
		Me.rdbtnPNG.Location = New System.Drawing.Point(138, 299)
		Me.rdbtnPNG.Name = "rdbtnPNG"
		Me.rdbtnPNG.Size = New System.Drawing.Size(48, 17)
		Me.rdbtnPNG.TabIndex = 8
		Me.rdbtnPNG.TabStop = True
		Me.rdbtnPNG.Text = "PNG"
		Me.rdbtnPNG.UseVisualStyleBackColor = True
		' 
		' rdbtnTIFF
		' 
		Me.rdbtnTIFF.AutoSize = True
		Me.rdbtnTIFF.Location = New System.Drawing.Point(83, 299)
		Me.rdbtnTIFF.Name = "rdbtnTIFF"
		Me.rdbtnTIFF.Size = New System.Drawing.Size(47, 17)
		Me.rdbtnTIFF.TabIndex = 7
		Me.rdbtnTIFF.TabStop = True
		Me.rdbtnTIFF.Text = "TIFF"
		Me.rdbtnTIFF.UseVisualStyleBackColor = True
		AddHandler Me.rdbtnTIFF.CheckedChanged, New System.EventHandler(AddressOf Me.rdbtnTIFF_CheckedChanged)
		' 
		' rdbtnJPEG
		' 
		Me.rdbtnJPEG.AutoSize = True
		Me.rdbtnJPEG.Location = New System.Drawing.Point(23, 299)
		Me.rdbtnJPEG.Name = "rdbtnJPEG"
		Me.rdbtnJPEG.Size = New System.Drawing.Size(52, 17)
		Me.rdbtnJPEG.TabIndex = 6
		Me.rdbtnJPEG.TabStop = True
		Me.rdbtnJPEG.Text = "JPEG"
		Me.rdbtnJPEG.UseVisualStyleBackColor = True
		' 
		' txtboxFileName
		' 
		Me.txtboxFileName.Location = New System.Drawing.Point(87, 219)
		Me.txtboxFileName.Name = "txtboxFileName"
		Me.txtboxFileName.Size = New System.Drawing.Size(164, 20)
		Me.txtboxFileName.TabIndex = 5
		' 
		' txtboxActionPage
		' 
		Me.txtboxActionPage.Location = New System.Drawing.Point(87, 182)
		Me.txtboxActionPage.Name = "txtboxActionPage"
		Me.txtboxActionPage.Size = New System.Drawing.Size(165, 20)
		Me.txtboxActionPage.TabIndex = 4
		' 
		' txtboxPwd
		' 
		Me.txtboxPwd.Location = New System.Drawing.Point(87, 144)
		Me.txtboxPwd.Name = "txtboxPwd"
		Me.txtboxPwd.Size = New System.Drawing.Size(166, 20)
		Me.txtboxPwd.TabIndex = 3
		' 
		' txtboxName
		' 
		Me.txtboxName.Location = New System.Drawing.Point(87, 109)
		Me.txtboxName.Name = "txtboxName"
		Me.txtboxName.Size = New System.Drawing.Size(167, 20)
		Me.txtboxName.TabIndex = 2
		' 
		' txtboxPort
		' 
		Me.txtboxPort.Location = New System.Drawing.Point(87, 71)
		Me.txtboxPort.Name = "txtboxPort"
		Me.txtboxPort.Size = New System.Drawing.Size(168, 20)
		Me.txtboxPort.TabIndex = 1
		' 
		' txtboxServer
		' 
		Me.txtboxServer.Location = New System.Drawing.Point(87, 32)
		Me.txtboxServer.Name = "txtboxServer"
		Me.txtboxServer.Size = New System.Drawing.Size(169, 20)
		Me.txtboxServer.TabIndex = 0
		AddHandler Me.txtboxServer.TextChanged, New System.EventHandler(AddressOf Me.txtboxServer_TextChanged)
		' 
		' dsViewer1
		' 
		Me.dsViewer1.Location = New System.Drawing.Point(0, 0)
		Me.dsViewer1.Name = "dsViewer1"
		Me.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.dsViewer1.SelectionRectAspectRatio = 0
		Me.dsViewer1.Size = New System.Drawing.Size(291, 394)
		Me.dsViewer1.TabIndex = 0
		' 
		' Form1
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(571, 516)
		Me.Controls.Add(Me.dsViewer1)
		Me.Controls.Add(Me.groupBox3)
		Me.Controls.Add(Me.groupBox2)
		Me.Controls.Add(Me.groupBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.Name = "Form1"
		Me.Text = "Scan and Upload"
		AddHandler Me.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Me.Form1_FormClosed)
		Me.groupBox1.ResumeLayout(False)
		Me.groupBox1.PerformLayout()
		Me.groupBox2.ResumeLayout(False)
		Me.groupBox2.PerformLayout()
		Me.groupBox3.ResumeLayout(False)
		Me.groupBox3.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private groupBox1 As System.Windows.Forms.GroupBox
	Private txtboxErrMessage As System.Windows.Forms.TextBox
	Private groupBox2 As System.Windows.Forms.GroupBox
	Private label1 As System.Windows.Forms.Label
	Private cmbSource As System.Windows.Forms.ComboBox
	Private btnScan As System.Windows.Forms.Button
	Private chkboxIfShowUI As System.Windows.Forms.CheckBox
	Private groupBox3 As System.Windows.Forms.GroupBox
	Private rdbtnPNG As System.Windows.Forms.RadioButton
	Private rdbtnTIFF As System.Windows.Forms.RadioButton
	Private rdbtnJPEG As System.Windows.Forms.RadioButton
	Private txtboxFileName As System.Windows.Forms.TextBox
	Private txtboxActionPage As System.Windows.Forms.TextBox
	Private txtboxPwd As System.Windows.Forms.TextBox
	Private txtboxName As System.Windows.Forms.TextBox
	Private txtboxPort As System.Windows.Forms.TextBox
	Private txtboxServer As System.Windows.Forms.TextBox
	Private label7 As System.Windows.Forms.Label
	Private label6 As System.Windows.Forms.Label
	Private label5 As System.Windows.Forms.Label
	Private label4 As System.Windows.Forms.Label
	Private label3 As System.Windows.Forms.Label
	Private label2 As System.Windows.Forms.Label
	Private btnUpload As System.Windows.Forms.Button
	Private chkboxMultiPage As System.Windows.Forms.CheckBox
	Private rdbtnPDF As System.Windows.Forms.RadioButton
	Private txtboxExtraTxt As System.Windows.Forms.TextBox
	Private label8 As System.Windows.Forms.Label
	Private lbNote As System.Windows.Forms.Label
	Private dsViewer1 As Dynamsoft.Forms.DSViewer
End Class

