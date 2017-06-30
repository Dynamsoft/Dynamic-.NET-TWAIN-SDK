Partial Class Form2
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
		Me.tbxPDFName = New System.Windows.Forms.TextBox()
		Me.tbxSetFileName = New System.Windows.Forms.Button()
		Me.lblPDFName = New System.Windows.Forms.Label()
		Me.label1 = New System.Windows.Forms.Label()
		Me.groupBox1 = New System.Windows.Forms.GroupBox()
		Me.label3 = New System.Windows.Forms.Label()
		Me.groupBox1.SuspendLayout()
		Me.SuspendLayout()
		' 
		' tbxPDFName
		' 
		Me.tbxPDFName.Location = New System.Drawing.Point(15, 154)
		Me.tbxPDFName.Name = "tbxPDFName"
		Me.tbxPDFName.Size = New System.Drawing.Size(239, 20)
		Me.tbxPDFName.TabIndex = 0
		' 
		' tbxSetFileName
		' 
		Me.tbxSetFileName.Location = New System.Drawing.Point(87, 198)
		Me.tbxSetFileName.Name = "tbxSetFileName"
		Me.tbxSetFileName.Size = New System.Drawing.Size(89, 23)
		Me.tbxSetFileName.TabIndex = 1
		Me.tbxSetFileName.Text = "Set File Name"
		Me.tbxSetFileName.UseVisualStyleBackColor = True
		AddHandler Me.tbxSetFileName.Click, New System.EventHandler(AddressOf Me.tbxSetFileName_Click)
		' 
		' lblPDFName
		' 
		Me.lblPDFName.AutoSize = True
		Me.lblPDFName.Location = New System.Drawing.Point(12, 127)
		Me.lblPDFName.Name = "lblPDFName"
		Me.lblPDFName.Size = New System.Drawing.Size(81, 13)
		Me.lblPDFName.TabIndex = 2
		Me.lblPDFName.Text = "PDF File Name:"
		' 
		' label1
		' 
		Me.label1.AutoSize = True
		Me.label1.Location = New System.Drawing.Point(6, 25)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(233, 13)
		Me.label1.TabIndex = 4
		Me.label1.Text = "The name of  PDF file contains  illegal character"
		' 
		' groupBox1
		' 
		Me.groupBox1.Controls.Add(Me.label3)
		Me.groupBox1.Controls.Add(Me.label1)
		Me.groupBox1.Location = New System.Drawing.Point(15, 12)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(242, 100)
		Me.groupBox1.TabIndex = 7
		Me.groupBox1.TabStop = False
		Me.groupBox1.Text = "Note:"
		' 
		' label3
		' 
		Me.label3.AutoSize = True
		Me.label3.Location = New System.Drawing.Point(6, 47)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(115, 13)
		Me.label3.TabIndex = 6
		Me.label3.Text = "Please reset the name."
		' 
		' Form2
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(269, 262)
		Me.Controls.Add(Me.groupBox1)
		Me.Controls.Add(Me.lblPDFName)
		Me.Controls.Add(Me.tbxSetFileName)
		Me.Controls.Add(Me.tbxPDFName)
		Me.Name = "Form2"
		Me.Text = "Set PDF File Name"
		Me.groupBox1.ResumeLayout(False)
		Me.groupBox1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Private tbxPDFName As System.Windows.Forms.TextBox
	Private tbxSetFileName As System.Windows.Forms.Button
	Private lblPDFName As System.Windows.Forms.Label
	Private label1 As System.Windows.Forms.Label
	Private groupBox1 As System.Windows.Forms.GroupBox
	Private label3 As System.Windows.Forms.Label
End Class
