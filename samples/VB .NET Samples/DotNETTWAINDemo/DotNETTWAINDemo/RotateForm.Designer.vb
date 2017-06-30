Partial Class RotateForm
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
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.lnAngle = New System.Windows.Forms.Label()
		Me.tbxAngle = New System.Windows.Forms.TextBox()
		Me.lbInterPolation = New System.Windows.Forms.Label()
		Me.cbxInterPolation = New System.Windows.Forms.ComboBox()
		Me.cbxKeepSize = New System.Windows.Forms.CheckBox()
		Me.groupBox1 = New System.Windows.Forms.GroupBox()
		Me.tbxB = New System.Windows.Forms.TextBox()
		Me.tbxG = New System.Windows.Forms.TextBox()
		Me.tbxR = New System.Windows.Forms.TextBox()
		Me.lbB = New System.Windows.Forms.Label()
		Me.lbG = New System.Windows.Forms.Label()
		Me.lbR = New System.Windows.Forms.Label()
		Me.btnOK = New System.Windows.Forms.Button()
		Me.groupBox1.SuspendLayout()
		Me.SuspendLayout()
		' 
		' btnCancel
		' 
		Me.btnCancel.Font = New System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.btnCancel.Location = New System.Drawing.Point(134, 210)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 25)
		Me.btnCancel.TabIndex = 6
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		AddHandler Me.btnCancel.Click, New System.EventHandler(AddressOf Me.btnCancel_Click)
		' 
		' lnAngle
		' 
		Me.lnAngle.AutoSize = True
		Me.lnAngle.Font = New System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.lnAngle.Location = New System.Drawing.Point(23, 25)
		Me.lnAngle.Name = "lnAngle"
		Me.lnAngle.Size = New System.Drawing.Size(40, 15)
		Me.lnAngle.TabIndex = 1
		Me.lnAngle.Text = "Angle:"
		' 
		' tbxAngle
		' 
		Me.tbxAngle.Font = New System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.tbxAngle.Location = New System.Drawing.Point(109, 17)
		Me.tbxAngle.Name = "tbxAngle"
		Me.tbxAngle.Size = New System.Drawing.Size(122, 23)
		Me.tbxAngle.TabIndex = 0
		' 
		' lbInterPolation
		' 
		Me.lbInterPolation.AutoSize = True
		Me.lbInterPolation.Font = New System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.lbInterPolation.Location = New System.Drawing.Point(23, 66)
		Me.lbInterPolation.Name = "lbInterPolation"
		Me.lbInterPolation.Size = New System.Drawing.Size(82, 15)
		Me.lbInterPolation.TabIndex = 1
		Me.lbInterPolation.Text = "Interpolation:"
		' 
		' cbxInterPolation
		' 
		Me.cbxInterPolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbxInterPolation.Font = New System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.cbxInterPolation.FormattingEnabled = True
		Me.cbxInterPolation.Items.AddRange(New Object() {"Bicubic", "Bilinear", "NearestNeighbour"})
		Me.cbxInterPolation.Location = New System.Drawing.Point(109, 58)
		Me.cbxInterPolation.Name = "cbxInterPolation"
		Me.cbxInterPolation.Size = New System.Drawing.Size(121, 23)
		Me.cbxInterPolation.TabIndex = 1
		' 
		' cbxKeepSize
		' 
		Me.cbxKeepSize.AutoSize = True
		Me.cbxKeepSize.Font = New System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.cbxKeepSize.Location = New System.Drawing.Point(109, 101)
		Me.cbxKeepSize.Name = "cbxKeepSize"
		Me.cbxKeepSize.Size = New System.Drawing.Size(76, 19)
		Me.cbxKeepSize.TabIndex = 2
		Me.cbxKeepSize.Text = "Keep Size"
		Me.cbxKeepSize.UseVisualStyleBackColor = True
		' 
		' groupBox1
		' 
		Me.groupBox1.Controls.Add(Me.tbxB)
		Me.groupBox1.Controls.Add(Me.tbxG)
		Me.groupBox1.Controls.Add(Me.tbxR)
		Me.groupBox1.Controls.Add(Me.lbB)
		Me.groupBox1.Controls.Add(Me.lbG)
		Me.groupBox1.Controls.Add(Me.lbR)
		Me.groupBox1.Font = New System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.groupBox1.Location = New System.Drawing.Point(17, 129)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(228, 66)
		Me.groupBox1.TabIndex = 6
		Me.groupBox1.TabStop = False
		Me.groupBox1.Text = "Fill Color:"
		' 
		' tbxB
		' 
		Me.tbxB.Location = New System.Drawing.Point(175, 27)
		Me.tbxB.Name = "tbxB"
		Me.tbxB.Size = New System.Drawing.Size(46, 23)
		Me.tbxB.TabIndex = 5
		' 
		' tbxG
		' 
		Me.tbxG.Location = New System.Drawing.Point(101, 27)
		Me.tbxG.Name = "tbxG"
		Me.tbxG.Size = New System.Drawing.Size(46, 23)
		Me.tbxG.TabIndex = 4
		' 
		' tbxR
		' 
		Me.tbxR.Location = New System.Drawing.Point(27, 27)
		Me.tbxR.Name = "tbxR"
		Me.tbxR.Size = New System.Drawing.Size(46, 23)
		Me.tbxR.TabIndex = 3
		' 
		' lbB
		' 
		Me.lbB.AutoSize = True
		Me.lbB.Location = New System.Drawing.Point(153, 30)
		Me.lbB.Name = "lbB"
		Me.lbB.Size = New System.Drawing.Size(17, 15)
		Me.lbB.TabIndex = 2
		Me.lbB.Text = "B:"
		' 
		' lbG
		' 
		Me.lbG.AutoSize = True
		Me.lbG.Location = New System.Drawing.Point(80, 30)
		Me.lbG.Name = "lbG"
		Me.lbG.Size = New System.Drawing.Size(18, 15)
		Me.lbG.TabIndex = 1
		Me.lbG.Text = "G:"
		' 
		' lbR
		' 
		Me.lbR.AutoSize = True
		Me.lbR.Location = New System.Drawing.Point(7, 30)
		Me.lbR.Name = "lbR"
		Me.lbR.Size = New System.Drawing.Size(17, 15)
		Me.lbR.TabIndex = 0
		Me.lbR.Text = "R:"
		' 
		' btnOK
		' 
		Me.btnOK.Font = New System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.btnOK.Location = New System.Drawing.Point(40, 210)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(75, 25)
		Me.btnOK.TabIndex = 7
		Me.btnOK.Text = "OK"
		Me.btnOK.UseVisualStyleBackColor = True
		AddHandler Me.btnOK.Click, New System.EventHandler(AddressOf Me.btnOK_Click)
		' 
		' RotateForm
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 14F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(259, 256)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.groupBox1)
		Me.Controls.Add(Me.cbxKeepSize)
		Me.Controls.Add(Me.cbxInterPolation)
		Me.Controls.Add(Me.tbxAngle)
		Me.Controls.Add(Me.lbInterPolation)
		Me.Controls.Add(Me.lnAngle)
		Me.Controls.Add(Me.btnCancel)
		Me.Font = New System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.Name = "RotateForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Rotate Image"
		Me.groupBox1.ResumeLayout(False)
		Me.groupBox1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Public tbxAngle As System.Windows.Forms.TextBox
	Public cbxInterPolation As System.Windows.Forms.ComboBox
	Public cbxKeepSize As System.Windows.Forms.CheckBox
	Public tbxB As System.Windows.Forms.TextBox
	Public tbxG As System.Windows.Forms.TextBox
	Public tbxR As System.Windows.Forms.TextBox
	Public btnOK As System.Windows.Forms.Button
	Public btnCancel As System.Windows.Forms.Button
	Public lnAngle As System.Windows.Forms.Label
	Public lbInterPolation As System.Windows.Forms.Label
	Public groupBox1 As System.Windows.Forms.GroupBox
	Public lbB As System.Windows.Forms.Label
	Public lbG As System.Windows.Forms.Label
	Public lbR As System.Windows.Forms.Label
End Class
