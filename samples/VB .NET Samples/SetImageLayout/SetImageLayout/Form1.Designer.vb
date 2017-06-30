Imports System.Windows.Forms
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
		Me.lblFrameBottom = New System.Windows.Forms.Label()
		Me.lblFrameTop = New System.Windows.Forms.Label()
		Me.lblFrameRight = New System.Windows.Forms.Label()
		Me.lblFrameLeft = New System.Windows.Forms.Label()
		Me.cbxSources = New System.Windows.Forms.ComboBox()
		Me.label5 = New System.Windows.Forms.Label()
		Me.edtFrameRight = New System.Windows.Forms.TextBox()
		Me.edtFrameTop = New System.Windows.Forms.TextBox()
		Me.btnSetAndAcquire = New System.Windows.Forms.Button()
		Me.edtFrameLeft = New System.Windows.Forms.TextBox()
		Me.label4 = New System.Windows.Forms.Label()
		Me.label3 = New System.Windows.Forms.Label()
		Me.label2 = New System.Windows.Forms.Label()
		Me.label1 = New System.Windows.Forms.Label()
		Me.edtFrameBottom = New System.Windows.Forms.TextBox()
		Me.dsViewer1 = New Dynamsoft.Forms.DSViewer()
		Me.groupBox1.SuspendLayout()
		Me.SuspendLayout()
		' 
		' groupBox1
		' 
		Me.groupBox1.Controls.Add(Me.lblFrameBottom)
		Me.groupBox1.Controls.Add(Me.lblFrameTop)
		Me.groupBox1.Controls.Add(Me.lblFrameRight)
		Me.groupBox1.Controls.Add(Me.lblFrameLeft)
		Me.groupBox1.Controls.Add(Me.cbxSources)
		Me.groupBox1.Controls.Add(Me.label5)
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
		Me.groupBox1.Size = New System.Drawing.Size(448, 168)
		Me.groupBox1.TabIndex = 10
		Me.groupBox1.TabStop = False
		Me.groupBox1.Text = "Image Layout Information"
		' 
		' lblFrameBottom
		' 
		Me.lblFrameBottom.AutoSize = True
		Me.lblFrameBottom.Location = New System.Drawing.Point(382, 103)
		Me.lblFrameBottom.Name = "lblFrameBottom"
		Me.lblFrameBottom.Size = New System.Drawing.Size(0, 13)
		Me.lblFrameBottom.TabIndex = 18
		' 
		' lblFrameTop
		' 
		Me.lblFrameTop.AutoSize = True
		Me.lblFrameTop.Location = New System.Drawing.Point(382, 68)
		Me.lblFrameTop.Name = "lblFrameTop"
		Me.lblFrameTop.Size = New System.Drawing.Size(0, 13)
		Me.lblFrameTop.TabIndex = 17
		' 
		' lblFrameRight
		' 
		Me.lblFrameRight.AutoSize = True
		Me.lblFrameRight.Location = New System.Drawing.Point(155, 103)
		Me.lblFrameRight.Name = "lblFrameRight"
		Me.lblFrameRight.Size = New System.Drawing.Size(0, 13)
		Me.lblFrameRight.TabIndex = 16
		' 
		' lblFrameLeft
		' 
		Me.lblFrameLeft.AutoSize = True
		Me.lblFrameLeft.Location = New System.Drawing.Point(155, 69)
		Me.lblFrameLeft.Name = "lblFrameLeft"
		Me.lblFrameLeft.Size = New System.Drawing.Size(0, 13)
		Me.lblFrameLeft.TabIndex = 15
		' 
		' cbxSources
		' 
		Me.cbxSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbxSources.FormattingEnabled = True
		Me.cbxSources.Location = New System.Drawing.Point(167, 25)
		Me.cbxSources.Name = "cbxSources"
		Me.cbxSources.Size = New System.Drawing.Size(131, 21)
		Me.cbxSources.TabIndex = 14
		' 
		' label5
		' 
		Me.label5.Location = New System.Drawing.Point(49, 26)
		Me.label5.Name = "label5"
		Me.label5.Size = New System.Drawing.Size(90, 16)
		Me.label5.TabIndex = 11
		Me.label5.Text = "Select Scources:"
		Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' edtFrameRight
		' 
		Me.edtFrameRight.Location = New System.Drawing.Point(91, 100)
		Me.edtFrameRight.Name = "edtFrameRight"
		Me.edtFrameRight.Size = New System.Drawing.Size(48, 20)
		Me.edtFrameRight.TabIndex = 6
		' 
		' edtFrameTop
		' 
		Me.edtFrameTop.Location = New System.Drawing.Point(313, 66)
		Me.edtFrameTop.Name = "edtFrameTop"
		Me.edtFrameTop.Size = New System.Drawing.Size(51, 20)
		Me.edtFrameTop.TabIndex = 5
		' 
		' btnSetAndAcquire
		' 
		Me.btnSetAndAcquire.Location = New System.Drawing.Point(21, 134)
		Me.btnSetAndAcquire.Name = "btnSetAndAcquire"
		Me.btnSetAndAcquire.Size = New System.Drawing.Size(102, 25)
		Me.btnSetAndAcquire.TabIndex = 8
		Me.btnSetAndAcquire.Text = "Set And Acquire"
		AddHandler Me.btnSetAndAcquire.Click, New System.EventHandler(AddressOf Me.btnSetAndAcquire_Click)
		' 
		' edtFrameLeft
		' 
		Me.edtFrameLeft.Location = New System.Drawing.Point(91, 66)
		Me.edtFrameLeft.Name = "edtFrameLeft"
		Me.edtFrameLeft.Size = New System.Drawing.Size(48, 20)
		Me.edtFrameLeft.TabIndex = 0
		' 
		' label4
		' 
		Me.label4.Location = New System.Drawing.Point(218, 102)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(80, 18)
		Me.label4.TabIndex = 3
		Me.label4.Text = "Frame Bottom:"
		Me.label4.TextAlign = System.Drawing.ContentAlignment.TopRight
		' 
		' label3
		' 
		Me.label3.Location = New System.Drawing.Point(11, 100)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(72, 18)
		Me.label3.TabIndex = 2
		Me.label3.Text = "Frame Right:"
		Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' label2
		' 
		Me.label2.Location = New System.Drawing.Point(19, 66)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(64, 17)
		Me.label2.TabIndex = 10
		Me.label2.Text = "Frame Left:"
		Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' label1
		' 
		Me.label1.Location = New System.Drawing.Point(234, 67)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(64, 17)
		Me.label1.TabIndex = 0
		Me.label1.Text = "Frame Top:"
		Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' edtFrameBottom
		' 
		Me.edtFrameBottom.Location = New System.Drawing.Point(313, 100)
		Me.edtFrameBottom.Name = "edtFrameBottom"
		Me.edtFrameBottom.Size = New System.Drawing.Size(51, 20)
		Me.edtFrameBottom.TabIndex = 7
		' 
		' dsViewer1
		' 
		Me.dsViewer1.Location = New System.Drawing.Point(13, 183)
		Me.dsViewer1.Name = "dsViewer1"
		Me.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.dsViewer1.SelectionRectAspectRatio = 0.0
		Me.dsViewer1.Size = New System.Drawing.Size(443, 286)
		Me.dsViewer1.TabIndex = 11
		' 
		' Form1
		' 
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(468, 481)
		Me.Controls.Add(Me.dsViewer1)
		Me.Controls.Add(Me.groupBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.Name = "Form1"
		Me.Text = "Set Image Layout"
		AddHandler Me.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Me.Form1_FormClosed)
		Me.groupBox1.ResumeLayout(False)
		Me.groupBox1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub


	Private groupBox1 As System.Windows.Forms.GroupBox
	Private label1 As System.Windows.Forms.Label
	Private label2 As System.Windows.Forms.Label
	Private label3 As System.Windows.Forms.Label
	Private label4 As System.Windows.Forms.Label
	Private edtFrameLeft As System.Windows.Forms.TextBox
	Private btnSetAndAcquire As System.Windows.Forms.Button
	Private edtFrameTop As System.Windows.Forms.TextBox
	Private edtFrameRight As System.Windows.Forms.TextBox
	Private edtFrameBottom As System.Windows.Forms.TextBox
	Private label5 As Label
	Private cbxSources As ComboBox
	Private lblFrameBottom As Label
	Private lblFrameTop As Label
	Private lblFrameRight As Label
	Private lblFrameLeft As Label
	#End Region
	Private dsViewer1 As Dynamsoft.Forms.DSViewer
End Class

