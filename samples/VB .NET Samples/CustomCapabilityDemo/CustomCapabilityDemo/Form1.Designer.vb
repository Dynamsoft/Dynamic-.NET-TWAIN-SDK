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
		Me.btnSetCapability = New System.Windows.Forms.Button()
		Me.button1 = New System.Windows.Forms.Button()
		Me.button2 = New System.Windows.Forms.Button()
		Me.dsViewer1 = New Dynamsoft.Forms.DSViewer()
		Me.SuspendLayout()
		' 
		' btnSetCapability
		' 
		Me.btnSetCapability.Location = New System.Drawing.Point(12, 325)
		Me.btnSetCapability.Name = "btnSetCapability"
		Me.btnSetCapability.Size = New System.Drawing.Size(159, 23)
		Me.btnSetCapability.TabIndex = 1
		Me.btnSetCapability.Text = "Set Custom CAP 0x:8001"
		Me.btnSetCapability.UseVisualStyleBackColor = True
		AddHandler Me.btnSetCapability.Click, New System.EventHandler(AddressOf Me.btnSetCapability_Click)
		' 
		' button1
		' 
		Me.button1.Location = New System.Drawing.Point(177, 325)
		Me.button1.Name = "button1"
		Me.button1.Size = New System.Drawing.Size(163, 23)
		Me.button1.TabIndex = 2
		Me.button1.Text = "Set Custom CAP 0x:8002"
		Me.button1.UseVisualStyleBackColor = True
		AddHandler Me.button1.Click, New System.EventHandler(AddressOf Me.button1_Click)
		' 
		' button2
		' 
		Me.button2.Location = New System.Drawing.Point(12, 354)
		Me.button2.Name = "button2"
		Me.button2.Size = New System.Drawing.Size(159, 23)
		Me.button2.TabIndex = 4
		Me.button2.Text = "Scan"
		Me.button2.UseVisualStyleBackColor = True
		AddHandler Me.button2.Click, New System.EventHandler(AddressOf Me.button2_Click)
		' 
		' dsViewer1
		' 
		Me.dsViewer1.Location = New System.Drawing.Point(12, 12)
		Me.dsViewer1.Name = "dsViewer1"
		Me.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.dsViewer1.SelectionRectAspectRatio = 0.0
		Me.dsViewer1.Size = New System.Drawing.Size(331, 307)
		Me.dsViewer1.TabIndex = 5
		' 
		' Form1
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(355, 393)
		Me.Controls.Add(Me.dsViewer1)
		Me.Controls.Add(Me.button1)
		Me.Controls.Add(Me.btnSetCapability)
		Me.Controls.Add(Me.button2)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.Name = "Form1"
		Me.Text = "Custom Capability Demo"
		AddHandler Me.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Me.Form1_FormClosed)
		Me.ResumeLayout(False)

	End Sub

	#End Region


	Private btnSetCapability As System.Windows.Forms.Button
	Private button1 As System.Windows.Forms.Button
	Private button2 As System.Windows.Forms.Button
	Private dsViewer1 As Dynamsoft.Forms.DSViewer
End Class

