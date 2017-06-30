Partial Class ZoomForm
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
		Me.btnOK = New System.Windows.Forms.Button()
		Me.tbxZoomRatio = New System.Windows.Forms.TextBox()
		Me.label1 = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		' 
		' btnCancel
		' 
		Me.btnCancel.Font = New System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.btnCancel.Location = New System.Drawing.Point(144, 35)
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
		Me.lnAngle.Location = New System.Drawing.Point(12, 9)
		Me.lnAngle.Name = "lnAngle"
		Me.lnAngle.Size = New System.Drawing.Size(71, 15)
		Me.lnAngle.TabIndex = 1
		Me.lnAngle.Text = "Zoom Ratio:"
		' 
		' btnOK
		' 
		Me.btnOK.Font = New System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.btnOK.Location = New System.Drawing.Point(27, 35)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(75, 25)
		Me.btnOK.TabIndex = 7
		Me.btnOK.Text = "OK"
		Me.btnOK.UseVisualStyleBackColor = True
		AddHandler Me.btnOK.Click, New System.EventHandler(AddressOf Me.btnOK_Click)
		' 
		' tbxZoomRatio
		' 
		Me.tbxZoomRatio.Location = New System.Drawing.Point(89, 7)
		Me.tbxZoomRatio.Name = "tbxZoomRatio"
		Me.tbxZoomRatio.Size = New System.Drawing.Size(47, 22)
		Me.tbxZoomRatio.TabIndex = 8
		Me.tbxZoomRatio.Text = "1000"
		Me.tbxZoomRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		AddHandler Me.tbxZoomRatio.KeyPress, New System.Windows.Forms.KeyPressEventHandler(AddressOf Me.tbxZoomRatio_KeyPress)
		' 
		' label1
		' 
		Me.label1.AutoSize = True
		Me.label1.Font = New System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.label1.Location = New System.Drawing.Point(136, 9)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(98, 15)
		Me.label1.TabIndex = 9
		Me.label1.Text = "%   (2% ~ 6500%)"
		' 
		' ZoomForm
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 14F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(246, 72)
		Me.Controls.Add(Me.label1)
		Me.Controls.Add(Me.tbxZoomRatio)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.lnAngle)
		Me.Controls.Add(Me.btnCancel)
		Me.Font = New System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.Name = "ZoomForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Zoom Image"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Public btnOK As System.Windows.Forms.Button
	Public btnCancel As System.Windows.Forms.Button
	Public lnAngle As System.Windows.Forms.Label
	Private tbxZoomRatio As System.Windows.Forms.TextBox
	Public label1 As System.Windows.Forms.Label
End Class
