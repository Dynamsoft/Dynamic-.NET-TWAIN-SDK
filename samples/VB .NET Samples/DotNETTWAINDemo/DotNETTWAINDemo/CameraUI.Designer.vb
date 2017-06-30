Partial Class CameraUI
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
		Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.optionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.menuStrip1.SuspendLayout()
		Me.SuspendLayout()
		' 
		' menuStrip1
		' 
		Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.optionsToolStripMenuItem})
		Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.menuStrip1.Name = "menuStrip1"
		Me.menuStrip1.Size = New System.Drawing.Size(543, 24)
		Me.menuStrip1.TabIndex = 0
		Me.menuStrip1.Text = "menuStrip1"
		' 
		' optionsToolStripMenuItem
		' 
		Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
		Me.optionsToolStripMenuItem.Size = New System.Drawing.Size(105, 20)
		Me.optionsToolStripMenuItem.Text = "Video Properties"
		AddHandler Me.optionsToolStripMenuItem.Click, New System.EventHandler(AddressOf Me.optionsToolStripMenuItem_Click)
		' 
		' CameraUI
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(543, 454)
		Me.Controls.Add(Me.menuStrip1)
		Me.MainMenuStrip = Me.menuStrip1
		Me.Name = "CameraUI"
		Me.Text = "CameraUI"
		AddHandler Me.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Me.CameraUI_FormClosed)
		AddHandler Me.SizeChanged, New System.EventHandler(AddressOf Me.CameraUI_SizeChanged)
		Me.menuStrip1.ResumeLayout(False)
		Me.menuStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Private menuStrip1 As System.Windows.Forms.MenuStrip
	Private optionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
